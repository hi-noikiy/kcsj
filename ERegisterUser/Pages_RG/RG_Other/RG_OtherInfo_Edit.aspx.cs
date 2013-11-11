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
using EpointRegisterUser_Bizlogic;

namespace EpointRegisterUser.Pages_RG.RG_Other
{
	
	public partial class RG_OtherInfo_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
	{
	    public int TableID=2021;
	    Epoint.MisBizLogic2.Web.EditPage oEditPage;
        Epoint.MisBizLogic2.Web.AddPage oAddPage;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        CommonFunc CF = new CommonFunc();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack )
			{
                string DWGuid = "";
                string RowGuid = "";
                string strURL = "";
                //���ж��Ƿ�����ת������
                if (String.IsNullOrEmpty(Request["RowGuid"]))//������ת
                {
                    //�ж���û�м�¼�����û�м�¼�Ļ�����ֱ����ת������ҳ��
                    string strSql = " select top(1) DWGuid from rg_ouinfo where DWGuid=(select distinct DanWeiGuid from RG_User where RowGuid='" + Session["UserGuid"].ToString() + "') order by row_id desc ";
                    DWGuid = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                    strSql = " select top(1) RowGuid from RG_OtherInfo   where DWGuid='" + DWGuid + "' order by row_id desc  ";
                    RowGuid = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                    if (RowGuid == "")//˵��û�м�¼������ת������ҳ��
                    {
                        strURL = "RG_OtherInfo_Add.aspx?ParentRowGuid=&RowGuid=" + Guid.NewGuid().ToString() + "&DWGuid=" + DWGuid + "";
                        this.WriteAjaxMessage("window.location.href='" + strURL + "';");
                        return;
                    }
                    else//����м�¼��ҲҪ��ת����ҳ�����¼���
                    {
                        strURL = "RG_OtherInfo_Edit.aspx?RowGuid=" + RowGuid + "&DWGuid=" + DWGuid + "";
                        this.WriteAjaxMessage("window.location.href='" + strURL + "';");
                        return;
                    }
                }
                else//����ת
                {
                    RowGuid = Request["RowGuid"];
                    DWGuid = Request["DWGuid"];
                }

                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, RowGuid);
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

                CF.BindYearDDL(ddlYear, 2012, true);
                CF.BindMonthDDL(ddlMonth, "0");

                ddlYear.SelectedValue = Year_2021.Text;
                ddlMonth.SelectedValue = Month_2021.Text;

                #region ����
                CL_CWBB.MisRowGuid = DWGuid;
                CL_CWBB.MisTableID = TableID;
                CL_CWBB.ProjectGuid = "";
                CL_CWBB.Comment = DWGuid;
                CL_CWBB.d_TiJiaoSJ = DateTime.Now.ToString();

                CL_NDSJBG.MisRowGuid = DWGuid;
                CL_NDSJBG.MisTableID = TableID;
                CL_NDSJBG.ProjectGuid = "";
                CL_NDSJBG.Comment = DWGuid;
                CL_NDSJBG.d_TiJiaoSJ = DateTime.Now.ToString();

                #endregion

                RefreshGrid();

                if (Status_2021.Text == EpointRegisterUser_Bizlogic.OUStatus.�����)
                {
                    btnEdit.Visible = false;
                    CL_CWBB.ReadOnly = true;
                    CL_NDSJBG.ReadOnly = true;
                }
			}		
		}


        override protected void OnInit(EventArgs e)
        {
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, null);//���û�е���Excel��Grid��������Ϊnull
            oListPage.CustomMode = true;
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);
            base.OnInit(e);
        }

        #region �б�
        private void RefreshGrid()
        {
            string str = "";

            str += " and DWGuid='" + Request["DWGuid"] + "' and IsHistory='1' ";
            oListPage.OtherCondition += str;
            oListPage.SortExpression = " order by row_id asc ";
            oListPage.GenerateSearchResult();
        }
        protected void Pager_PageChanged(object src, Wuqi.Webdiyer.PageChangedEventArgs e)
        {
            Pager.CurrentPageIndex = e.NewPageIndex;
            this.RefreshGrid();
        }

        protected void Datagrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            oListPage.PrepareForSortCommand(e.SortExpression);
            Pager.CurrentPageIndex = 0;
            this.RefreshGrid();
        }

        protected void Datagrid1_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            oListPage.GenerateSerialNumColumn(e.Item);
        }

        protected void GridExcel_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                for (int i = 0; i < e.Item.Cells.Count; i++)
                    e.Item.Cells[i].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
            }
        }

        protected string GetStatus(object Status)
        {
            if (Status.ToString() != "0")
            {
                return EpointRegisterUser_Bizlogic.OUStatus.GetTextByValue(Status.ToString());
            }
            return "";
        }
        #endregion

        Epoint.Messages.Bizlogic.DB_Messages_Center msg = new Epoint.Messages.Bizlogic.DB_Messages_Center();
		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
            //oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            //this.WriteAjaxMessage("refreshParent();"); 
            //this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'���ݱ���ɹ�')");           
            string RowGuid = Request["RowGuid"];
            string DWGuid = Request["DWGuid"];
            string strSql = "SELECT top(1) EnterpriseName FROM RG_OUInfo WHERE dwGuid='" + DWGuid + "' order by row_ID desc";
            string EnterpriseName = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            //�Ȼ�ȡͶ�ʾ���            
            strSql = "SELECT s_xiangmujl_guid,s_xiangmujl FROM VIEW_CurrentVersion WHERE dwGuid='" + DWGuid + "'";
            DataView dvUser = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            if (dvUser.Count == 0)
            {
                WriteAjaxMessage("����ҵû�ж�Ӧ����Ŀ������ϵϵͳ����Ա��");
                return;
            }
            //�ж��ǲ����Ѿ�����
             strSql = string.Format("select count(*) from RG_OtherInfo where DWGuid='{0}'", Request["DWGuid"]);
            if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) == "1")//˵��û��
            {
                //�ύʱֱ���ύ�����ñ���汾
                Year_2021.Text = ddlYear.SelectedValue;
                Month_2021.Text = ddlMonth.SelectedValue;
                YearMonth_2021.Text = ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-01 00:00:00";
                UpdateUserName_2021.Text = this.DisplayName;
                UpdateUserGuid_2021.Text = this.UserGuid;
                UpdateTime_2021.Text = DateTime.Now.ToString();
                Status_2021.Text = EpointRegisterUser_Bizlogic.OUStatus.�����;
                IsHistory_2021.Text = "0";
                oEditPage.SaveTableValues(RowGuid, tdContainer);
            }
            else
            {
                //�Ƚ�ԭ��������Ϊ��ʷ��¼
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                oRow["IsHistory"] = "1";
                //oRow["UpdateUserName"] = this.DisplayName;
                //oRow["UpdateUserGuid"] = this.UserGuid;
                //oRow["UpdateTime"] = DateTime.Now;
                oRow.Update();
                //Ȼ���ٽ����汾�����ύ���
                Year_2021.Text = ddlYear.SelectedValue;
                Month_2021.Text = ddlMonth.SelectedValue;
                YearMonth_2021.Text = ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-01 00:00:00";
                UpdateUserName_2021.Text = this.DisplayName;
                UpdateUserGuid_2021.Text = this.UserGuid;
                UpdateTime_2021.Text = DateTime.Now.ToString();
                Status_2021.Text = EpointRegisterUser_Bizlogic.OUStatus.�����;
                IsHistory_2021.Text = "0";
                RowGuid = Guid.NewGuid().ToString();
                oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);
            }

            #region ���渽��
            CL_CWBB.MisRowGuid = DWGuid;
            CL_CWBB.MisTableID = TableID;
            CL_CWBB.ProjectGuid = "";
            CL_CWBB.Comment = DWGuid;
            CL_CWBB.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_CWBB.Save();

            CL_NDSJBG.MisRowGuid = DWGuid;
            CL_NDSJBG.MisTableID = TableID;
            CL_NDSJBG.ProjectGuid = "";
            CL_NDSJBG.Comment = DWGuid;
            CL_NDSJBG.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_NDSJBG.Save();

            #endregion


            #region ֪ͨͶ�ʾ���
            
            for (int m = 0; m < dvUser.Count; m++)
            {
                msg.WaitHandle_Insert(
                                Guid.NewGuid().ToString(),
                                "����ˡ�" + EnterpriseName + "������Ҫ��������",
                                "",
                                dvUser[m]["s_xiangmujl_guid"].ToString(),
                                dvUser[m]["s_xiangmujl"].ToString(),
                                Session["UserGuid"].ToString(),
                                Session["DisplayName"].ToString(),
                                "",
                                "EpointRegisterUser/Pages_RG/RG_Other/RG_OtherInfo_DetailForCheck.aspx?RowGuid=" + RowGuid + "&DWGuid=" + DWGuid,
                                "",
                                "",
                                1,
                                "",
                                "",
                                ""
                         );
            }

            #endregion

            //this.WriteAjaxMessage("refreshParent();");
            //this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'���ݱ���ɹ�')");
            this.WriteAjaxMessage("alert('�ύ�ɹ�');");
            RefreshGrid();

            btnEdit.Visible = false;
		
		}

   }
}
