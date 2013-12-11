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
				    this.AlertAjaxMessage ("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
					return;
				}
				Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
				//添加上传文件的大小和类型检查
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

                if (oRow["Status"].ToString() == "90")//通过
                {
                    btnEdit.Visible = false;
                }
                else if (oRow["Status"].ToString() == "80")//不通过
                {
                    //btnEdit.Visible = false;
                }
                else if (oRow["Status"].ToString() == "70")//待审核
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
                //如果是省内的，就不要显示
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
            //if (message != "")//说明有些专业没有配置人
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
			this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");           
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
                //DB_Frame_OperationLog.Insert(DB_Frame_OperationLog.LOG_OPERATOR_TYPE_MODIFY, DB_Frame_OperationLog.LOG_SUBSYSTEM_TYPE_Frame, this.Session["UserGuid"].ToString(), this.Session["DisplayName"].ToString(), "删除代码项。代码类别名称：" + this.lblCodeName.Text + "；代码项名称：" + item.ItemText + "；代码值名称：" + item.ItemValue + "；代码项ItemGuid：" + item.ItemGuid, "", this.Session["BaseOUGuid"].ToString());
            }
            if (commandSource.CommandName.ToLower() == "upd")
            {
                //获取专业
                string strSql = " select ZhuanYeCode from RG_XMAndRY where 1=1  and RowGuid='" + itemCode + "' ";
                string ZYCode = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                WriteAjaxMessage("OpenDialogRefresh('RG_XMAndRY_Edit.aspx?RowGuid=" + itemCode + "&GMValue=" + GuiMoDJ_2021.SelectedValue + "&ZYCode=" + ZYCode 
                    + "&ZiZhiDJCode="+ ZiZhiDJCode_2021.Text +"&QYZCD="+ hiQYZCD.Value +"', '" + Request["RowGuid"] + "', '600', '300');");
            }
            
        }

        protected void btInsertRY_Click(object sender, EventArgs e)
        {
            //开始增加人员的信息，注意，如果已经存在了就不再进行处理
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
                    WriteAjaxMessage("alert('以下人员已经存在于本项目中：" + NoUsers + "');");
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
                //增加对人员的限制
                message = RG_DW.ChenkZYRY(Request["RowGuid"], DWGuid_2021.Text, ZiZhiDJCode_2021.Text);
                if (message != "")//说明有些必须配置人专业没有配置人
                {
                    WriteAjaxMessage("alert('" + message + "');");
                    return;
                }
                //项目负责人
                message = RG_DW.CheckXMFuZeRen(Request["RowGuid"]);
                if (message != "")//项目负责人有且只有一个人
                {
                    WriteAjaxMessage("alert('" + message + "');");
                    return;
                }
                //专业负责人
                message = RG_DW.ChenkZYFuZeRen(Request["RowGuid"], DWGuid_2021.Text, ZiZhiDJCode_2021.Text);
                if (message != "")//专业负责人不满足要求
                {
                    WriteAjaxMessage("alert('" + message + "');");
                    return;
                }
                //看看有没有备案表，没有备案表就不能提交
                Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom StorgCom = new Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom();
                string CliGuid = Request["RowGuid"] + "XM_HTBA";
                DataView dvAttch = StorgCom.Select(CliGuid);
                if (dvAttch.Count == 0)
                {
                    this.WriteAjaxMessage("alert('请上传项目备案表');");
                    return;
                }
                CliGuid = Request["RowGuid"] + "XM_SJHT";
                dvAttch = StorgCom.Select(CliGuid);
                if (dvAttch.Count == 0)
                {
                    this.WriteAjaxMessage("alert('请上传合同');");
                    return;
                }
            }
            
            //发送待审核事宜，根据角色来
            //还要看是不是属于宜兴、江阴的项目，如果是，就重新获取
            //Status_2021.SelectedValue = "70";//这个地方要注意，如果是江阴、宜兴的项目，要先到江阴、宜兴审核，然后再到市总办审核
            DataView dv = DBF.GetUserByRoleName("备案信息初审");
            if (XMAdd_2021.SelectedValue == "320282")//宜兴
            {
                dv = DBF.GetUserByRoleName("宜兴备案信息审核");
                Status_2021.SelectedValue = "69";
            }
            else if (XMAdd_2021.SelectedValue == "320281")//江阴
            {
                dv = DBF.GetUserByRoleName("江阴备案信息审核");
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
                                    XMName_2021.Text + "备案初审",
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
                //更新标志位
                string strSql = "update messages_center set PType='备案信息审核',PGuid='" + Request["RowGuid"] + "' where MessageItemGuid='" + messageGuid + "'";
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);

                //添加短信
                string IsSendADSMS = ApplicationOperate.GetConfigValueByName("IsSendADSMS");
                if (IsSendADSMS == "1")
                {
                    if (dv[m]["Mobile"].ToString() != "")
                    {
                        HTSMS.SendSMS(this.DisplayName, dv[m]["DisplayName"], XMName_2021.Text + "提交备案信息审核", dv[m]["Mobile"]);
                    }
                }
            }
            AlertAjaxMessage("提交成功");
            this.WriteAjaxMessage("refreshParent();window.close();");
        }

        protected void btnXZ_Click(object sender, System.EventArgs e)
        {

            bool IsND = false;//如果是省外、年度备案企业，则更改为true；
            #region 对企业进行判断
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
