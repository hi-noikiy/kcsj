using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Specialized ;
using Epoint.Web.UI.WebControls2X;
using Epoint.Frame.Common;
using HTProject_Bizlogic;

namespace HTProject.Pages.RG_XMBeiAn
{
	
	public partial class RG_XMBeiAn_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
	{
	    public int TableID=2021;
        public int TableXMZYID = 2023;
	    Epoint.MisBizLogic2.Web.EditPage oEditPage;
        protected HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        HTProject_Bizlogic.DataBaseFunc DBF = new DataBaseFunc();
        //Epoint.MisBizLogic2.Web.ListPage oListPage;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack )
			{
                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
				if (!oRow.R_HasFilled)
				{
					btnEdit.Visible = false;
				    this.AlertAjaxMessage ("û�ж�Ӧ�����ݼ�¼��");
                    this.WriteAjaxMessage("window.close();");
					return;
				}
				Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
				//����ϴ��ļ��Ĵ�С�����ͼ��
                this.Add_FileUploadCheck_Script();

                BindZhuanYe();

                XM_HTBA.ClientGuid = Request["RowGuid"] + "XM_HTBA";
                XM_HTBA.NodeCode = DWGuid_2021.Text;
                XM_HTBA.MisRowGuid = Request["RowGuid"];
                XM_HTBA.Status = oRow["Status"].ToString();
                

                XM_SJHT.ClientGuid = Request["RowGuid"] + "XM_SJHT";
                XM_SJHT.NodeCode = DWGuid_2021.Text;
                XM_SJHT.MisRowGuid = Request["RowGuid"];


                QY_CXZM.ClientGuid = Request["RowGuid"] + "QY_CXZM";
                QY_CXZM.NodeCode = DWGuid_2021.Text;
                QY_CXZM.MisRowGuid = Request["RowGuid"];

                if (oRow["Status"].ToString() == "90")//ͨ��
                {
                    btnEdit.Visible = false;
                }
                else if (oRow["Status"].ToString() == "80")//��ͨ��
                {
                    //btnEdit.Visible = false;
                }
                else if (oRow["Status"].ToString() == "70")//�����
                {
                    btnEdit.Visible = false;
                    btnSub.Visible = false;
                    XM_HTBA.ReadOnly = true;
                    XM_SJHT.ReadOnly = true;
                }

                

                lblSHOpinion.Text = RG_DW.GetSHOpinion(Request["RowGuid"], "");
                string QYZCD2 = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT RegistAddressCode FROM RG_OUInfo WHERE RowGuid='" + DWGuid_2021.Text + "'");
                if (QYZCD2.Substring(0, 2) == "32")
                {
                    lblTips.Text = RG_DW.GetTip(oRow["Status"], "Edit", "0", oRow["XMAdd"].ToString());
                }
                else
                {
                    lblTips.Text = RG_DW.GetTip(oRow["Status"], "Edit", "1", oRow["XMAdd"].ToString());
                }
                //�����ʡ�ڵģ��Ͳ�Ҫ��ʾ
                string QYZCD = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT RegistAddressCode FROM RG_OUInfo WHERE RowGuid='" + DWGuid_2021.Text + "'");
                hiQYZCD.Value = QYZCD.Substring(0, 2);
			}

            if (hiQYZCD.Value == "32")
            {
                XM_HTBA.SAdd = "SN";
                YeWuFW_2021.Visible = false;
                FuZaCD_2021.Visible = false;
                WriteAjaxMessage("document.getElementById('trFW').style.display = 'none';");
                WriteAjaxMessage("document.getElementById('trFZ').style.display = 'none';");
            }
            else
            {
                XM_HTBA.SAdd = "SW";
            }
		}


        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage (TableID);
            //oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableXMZYID, DGZhuanYe, null, null, null);
            //oListPage.OtherCondition = " and XMGuid='" + Request["RowGuid"] + "' ";

            //oListPage.CustomMode = true;   
            base.OnInit(e);
        }
		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
            //if (TJDate_2021.Text == "")
            //{
            //    TJDate_2021.Text = DateTime.Now.ToString();
            //}
            string message = "";
            //message = RG_DW.ChenkZYFuZeRen(Request["RowGuid"], DWGuid_2021.Text, ZiZhiDJCode_2021.Text);
            //if (message != "")//˵����Щרҵû��������
            //{
            //    WriteAjaxMessage("alert('" + message + "');");
            //    return;
            //}
            TJRGuid_2021.Text = this.UserGuid;
            TJDate_2021.Text = DateTime.Now.ToString();
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
			
            if (ApplicationOperate.GetConfigValueByName("IsHoldCurPage", "0") == "1")
                this.WriteAjaxMessage("refreshParentHoldCurPage();"); 
            else
                this.WriteAjaxMessage("refreshParent();"); 
			this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'���ݱ���ɹ�')");           
		}

        protected void BindZhuanYe()
        {
            string strSql = " select * from RG_XMAndZY where 1=1  and XMGuid='" + Request["RowGuid"] + "' ";
            strSql += " and DWGuid='" + DWGuid_2021.Text + "' and ZiZhiCode='" + ZiZhiDJCode_2021.Text + "' ";
            strSql += " ORDER BY ZhuanYeCode ASC ";
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            DGZhuanYe.DataSource = dv;
            DGZhuanYe.DataBind();
        }

        protected DataView GetRY(object ZhuanYeCode)
        {
            string strSql = " select * from RG_XMAndRY where 1=1  and XMGuid='" + Request["RowGuid"] + "' ";
            strSql += " and DWGuid='" + DWGuid_2021.Text + "' and ZiZhiCode='" + ZiZhiDJCode_2021.Text + "' and ZhuanYeCode='" + ZhuanYeCode + "' ";
            strSql += " ORDER BY ddrole desc ";
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            return dv;
        }

        protected void DGRenYuan_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            System.Web.UI.WebControls.Button commandSource = (System.Web.UI.WebControls.Button)e.CommandSource;
            string itemCode = Convert.ToString(e.CommandArgument);
            if (commandSource.CommandName.ToLower() == "del")
            {
                RG_DW.DeleteRYOfXM(itemCode);
                this.BindZhuanYe();
                //RG_DW.DeleteZZZYGX(itemCode);
                //Detail_Frame_Code_Item item = this.CodeItem.GetDetail_ItemCode(this.Session["MainGuid"].ToString(), itemCode);
                //DB_Frame_OperationLog.Insert(DB_Frame_OperationLog.LOG_OPERATOR_TYPE_MODIFY, DB_Frame_OperationLog.LOG_SUBSYSTEM_TYPE_Frame, this.Session["UserGuid"].ToString(), this.Session["DisplayName"].ToString(), "ɾ�����������������ƣ�" + this.lblCodeName.Text + "�����������ƣ�" + item.ItemText + "������ֵ���ƣ�" + item.ItemValue + "��������ItemGuid��" + item.ItemGuid, "", this.Session["BaseOUGuid"].ToString());
            }
            if (commandSource.CommandName.ToLower() == "upd")
            {
                //��ȡרҵ
                string strSql = " select ZhuanYeCode from RG_XMAndRY where 1=1  and RowGuid='" + itemCode + "' ";
                string ZYCode = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                WriteAjaxMessage("OpenDialogRefresh('RG_XMAndRY_Edit.aspx?RowGuid=" + itemCode + "&GMValue=" + GuiMoDJ_2021.SelectedValue + "&ZYCode=" + ZYCode 
                    + "&ZiZhiDJCode="+ ZiZhiDJCode_2021.Text +"&QYZCD="+ hiQYZCD.Value +"', '" + Request["RowGuid"] + "', '600', '300');");
            }
            
        }

        protected void btInsertRY_Click(object sender, EventArgs e)
        {
            //��ʼ������Ա����Ϣ��ע�⣬����Ѿ������˾Ͳ��ٽ��д���
            if (hiRYGuids.Text.Trim().ToLower() != "undefined")
            {
                string[] RYGuids = hiRYGuids.Text.Trim().Split(';');
                string RYG = "";
                string NoUsers = "";
                for (int m = 0; m < RYGuids.Length; m++)
                {
                    RYG = RYGuids[m];
                    if (RYG != "")
                    {
                        Epoint.MisBizLogic2.Data.MisGuidRow oRowRY = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_QYUser", RYG);
                        if (!RG_DW.IsExistRYOfXM(RYG, Request["RowGuid"]))
                        {
                            RG_DW.InsertXMRY(ZiZhiDJCode_2021.Text, ZiZhiDJ_2021.Text, hiZYCode.Text, RYG, oRowRY["XM"], Request["RowGuid"], DWGuid_2021.Text, oRowRY["IDNum"], oRowRY["ZhiCheng"],
                                RG_DW.GetZCZ( oRowRY["YinZhangNo"] ,oRowRY["YinZhangNo1"],oRowRY["YinZhangNo2"]), oRowRY["ZhuanYe"], oRowRY["ZhuanYeCS"], oRowRY["ZhuanYeCSCode"], oRowRY["GongLing"], "85", hiZYText.Text);
                        }
                        else
                        {
                            NoUsers += oRowRY["XM"] + ";";
                        }
                    }
                }
                if (NoUsers != "")
                {
                    WriteAjaxMessage("alert('������Ա�Ѿ������ڱ���Ŀ�У�" + NoUsers + "');");
                }
                BindZhuanYe();
            }
        }

        HTProject_Bizlogic.SMS HTSMS = new SMS();
        protected void btnSub_Click(object sender, System.EventArgs e)
        {
            string message = "";
            if (this.LoginID != "lift")
            {
                //���Ӷ���Ա������
                message = RG_DW.ChenkZYRY(Request["RowGuid"], DWGuid_2021.Text, ZiZhiDJCode_2021.Text);
                if (message != "")//˵����Щ����������רҵû��������
                {
                    WriteAjaxMessage("alert('" + message + "');");
                    return;
                }
                //��Ŀ������
                message = RG_DW.CheckXMFuZeRen(Request["RowGuid"]);
                if (message != "")//��Ŀ����������ֻ��һ����
                {
                    WriteAjaxMessage("alert('" + message + "');");
                    return;
                }
                //רҵ������
                message = RG_DW.ChenkZYFuZeRen(Request["RowGuid"], DWGuid_2021.Text, ZiZhiDJCode_2021.Text);
                if (message != "")//רҵ�����˲�����Ҫ��
                {
                    WriteAjaxMessage("alert('" + message + "');");
                    return;
                }
                //������û�б�����û�б�����Ͳ����ύ
                Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom StorgCom = new Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom();
                string CliGuid = Request["RowGuid"] + "XM_HTBA";
                DataView dvAttch = StorgCom.Select(CliGuid);
                if (dvAttch.Count == 0)
                {
                    this.WriteAjaxMessage("alert('���ϴ���Ŀ������');");
                    return;
                }
                CliGuid = Request["RowGuid"] + "XM_SJHT";
                dvAttch = StorgCom.Select(CliGuid);
                if (dvAttch.Count == 0)
                {
                    this.WriteAjaxMessage("alert('���ϴ���ͬ');");
                    return;
                }
            }
            
            //���ʹ�������ˣ����ݽ�ɫ��
            //��Ҫ���ǲ����������ˡ���������Ŀ������ǣ������»�ȡ
            //Status_2021.SelectedValue = "70";//����ط�Ҫע�⣬����ǽ��������˵���Ŀ��Ҫ�ȵ�������������ˣ�Ȼ���ٵ����ܰ����
            DataView dv = DBF.GetUserByRoleName("������Ϣ����");
            if (XMAdd_2021.SelectedValue == "320282")//����
            {
                dv = DBF.GetUserByRoleName("���˱�����Ϣ���");
                Status_2021.SelectedValue = "69";
            }
            else if (XMAdd_2021.SelectedValue == "320281")//����
            {
                dv = DBF.GetUserByRoleName("����������Ϣ���");
                Status_2021.SelectedValue = "69";
            }
            else
            {
                Status_2021.SelectedValue = "70";
            }
            TJRGuid_2021.Text = this.UserGuid;
            TJDate_2021.Text = DateTime.Now.ToString("yyyy-MM-dd");
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            for (int m = 0; m < dv.Count; m++)
            {
                string messageGuid = Guid.NewGuid().ToString();
                new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Insert(messageGuid,
                                    XMName_2021.Text + "��������",
                                    "",
                                    dv[m]["UserGuid"].ToString(),
                                    dv[m]["DisplayName"].ToString(),
                                    "",
                                    "",
                                    "",
                                    @"HTProject/Pages/RG_XMBeiAn/RG_XMBeiAnAD_Detail.aspx?RowGuid=" + Request["RowGuid"],
                                    "",
                                    "",
                                    1,
                                    "",
                                    "",
                                    ""
                             );
                //���±�־λ
                string strSql = "update messages_center set PType='������Ϣ���',PGuid='" + Request["RowGuid"] + "' where MessageItemGuid='" + messageGuid + "'";
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);

                //��Ӷ���
                string IsSendADSMS = ApplicationOperate.GetConfigValueByName("IsSendADSMS");
                if (IsSendADSMS == "1")
                {
                    if (dv[m]["Mobile"].ToString() != "")
                    {
                        HTSMS.SendSMS(this.DisplayName, dv[m]["DisplayName"], XMName_2021.Text + "�ύ������Ϣ���", dv[m]["Mobile"]);
                    }
                }
            }
            AlertAjaxMessage("�ύ�ɹ�");
            this.WriteAjaxMessage("refreshParent();window.close();");
        }

        protected void btnXZ_Click(object sender, System.EventArgs e)
        {

            bool IsND = false;//�����ʡ�⡢��ȱ�����ҵ�������Ϊtrue��
            #region ����ҵ�����ж�
            string strSql = "SELECT IsNDBA,RegistAddress,* FROM RG_OUInfo WHERE ROWGUID='" + DWGuid_2021.Text + "'";
            string qyzcd = "";
            DataView dvQY = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            if (dvQY.Count > 0)
            {
                qyzcd = dvQY[0]["RegistAddressCode"].ToString().Substring(0, 2);
                if (dvQY[0]["IsNDBA"].ToString() == "1" && qyzcd != "32")
                {
                    IsND = true;
                }

            }
            #endregion
            //string QYZCD = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT RegistAddressCode FROM RG_OUInfo WHERE RowGuid='" + DWGuid_2021.Text + "'");
            if (qyzcd == "32")
            {
                WriteAjaxMessage("OpenWindow('../Print/BeiAnPrint.aspx?RowGuid=" + Request["RowGuid"] + "', '800', '700');");
            }
            else
            {
                if (IsND)
                {
                    WriteAjaxMessage("OpenWindow('../Print/BeiAnPrint_ND.aspx?RowGuid=" + Request["RowGuid"] + "', '800', '700');");
                }
                else
                {
                    WriteAjaxMessage("OpenWindow('../Print/BeiAnPrint_WS.aspx?RowGuid=" + Request["RowGuid"] + "', '800', '700');");
                }
            }
        }
    }
}
