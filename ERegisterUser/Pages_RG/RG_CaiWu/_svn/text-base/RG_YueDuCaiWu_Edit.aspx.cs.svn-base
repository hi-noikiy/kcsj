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

namespace EpointRegisterUser.Pages_RG.RG_CaiWu
{
	
	public partial class RG_YueDuCaiWu_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
	{
	    public int TableID=2020;
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
                //先判断是否是跳转过来的
                if (String.IsNullOrEmpty(Request["RowGuid"]))//不是跳转
                {
                    //判断有没有记录，如果没有记录的话，就直接跳转到新增页面
                    string strSql = " select top(1) DWGuid from rg_ouinfo where DWGuid=(select distinct DanWeiGuid from RG_User where RowGuid='" + Session["UserGuid"].ToString() + "') order by row_id desc ";
                    DWGuid = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                    strSql = " select top(1) RowGuid from RG_YueDuCaiWu   where DWGuid='" + DWGuid + "' order by row_id desc  ";
                    RowGuid = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                    if (RowGuid == "")//说明没有记录，就跳转到新增页面
                    {
                        strURL = "RG_YueDuCaiWu_Add.aspx?ParentRowGuid=&RowGuid=" + Guid.NewGuid().ToString() + "&DWGuid=" + DWGuid + "";
                        this.WriteAjaxMessage("window.location.href='" + strURL + "';");
                        return;
                    }
                    else//如果有记录，也要跳转到本页面重新加载
                    {
                        strURL = "RG_YueDuCaiWu_Edit.aspx?RowGuid=" + RowGuid + "&DWGuid=" + DWGuid + "";
                        this.WriteAjaxMessage("window.location.href='" + strURL + "';");
                        return;
                    }
                }
                else//是跳转
                {
                    RowGuid = Request["RowGuid"];
                    DWGuid = Request["DWGuid"];
                }
                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, RowGuid);
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

                CF.BindYearDDL(ddlYear, 2012, true);
                CF.BindMonthDDL(ddlMonth, "0");

                ddlYear.SelectedValue = Year_2020.Text;
                ddlMonth.SelectedValue = Month_2020.Text;

                if (Status_2020.Text == OUStatus.待审核 || Status_2020.Text == OUStatus.通过)
                {
                    string url = "RG_YueDuCaiWu_Detail.aspx?RowGuid=" + RowGuid + "&DWGuid=" + DWGuid_2020.Text + "&sType=0";
                    this.WriteAjaxMessage("window.location.href='" + url + "';");
                }

                RefreshGrid();
			}		
		}


        override protected void OnInit(EventArgs e)
        {
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, null);//如果没有导出Excel的Grid，就设置为null
            oListPage.CustomMode = true;
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);
            base.OnInit(e);
        }

        #region 列表
        private void RefreshGrid()
        {
            string str = "";

            str += " and DWGuid='" + Request["DWGuid"] + "' and IsHistory='1' and YearMonth='" + ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-01 00:00:00" + "' and RowGuid<>'" + Request["RowGuid"] + "' ";
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
            string strSql = "SELECT s_xiangmujl_guid,s_xiangmujl FROM VIEW_CurrentVersion WHERE dwGuid='" + DWGuid_2020.Text + "'";
            DataView dvUser = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            if (dvUser.Count == 0)
            {
                WriteAjaxMessage("该企业没有对应的项目，请联系系统管理员。");
                return;
            }
            string RowGuid = Request["RowGuid"];
            //先判断下某个月是否已经提交过
             strSql = string.Format("select count(*) from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and Month='{2}'", DWGuid_2020.Text, ddlYear.SelectedValue, ddlMonth.SelectedValue);
            //if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) != "0")//说明已经有了
            //{
            //    //进行提示
            //    WriteAjaxMessage("alert('该月已经存在财务信息');");
            //    return;
            //}
            //如果是第一条，那么就直接提交，不要再新增一个版本了
            strSql = string.Format("select count(*) from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and Month='{2}' and RowGuid<>'{3}'", DWGuid_2020.Text, ddlYear.SelectedValue, ddlMonth.SelectedValue, RowGuid);
            if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) != "0")//说明已经有了,那么就要出现新版本了
            {
                //先将原来的保存为一个版本
                //先将原来的设置为历史记录
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                oRow["IsHistory"] = "1";
                //oRow["UpdateUserName"] = this.DisplayName;
                //oRow["UpdateUserGuid"] = this.UserGuid;
                //oRow["UpdateTime"] = DateTime.Now;
                oRow.Update();
                //然后再将本版本进行提交审核
                Year_2020.Text = ddlYear.SelectedValue;
                Month_2020.Text = ddlMonth.SelectedValue;
                YearMonth_2020.Text = ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-01 00:00:00";
                UpdateUserName_2020.Text = this.DisplayName;
                UpdateUserGuid_2020.Text = this.UserGuid;
                UpdateTime_2020.Text = DateTime.Now.ToString();
                Status_2020.Text = EpointRegisterUser_Bizlogic.OUStatus.待审核;
                IsHistory_2020.Text = "0";
                RowGuid = Guid.NewGuid().ToString();
                oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);
            }
            else//第一次
            {
                Year_2020.Text = ddlYear.SelectedValue;
                Month_2020.Text = ddlMonth.SelectedValue;
                YearMonth_2020.Text = ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-01 00:00:00";
                UpdateUserName_2020.Text = this.DisplayName;
                UpdateUserGuid_2020.Text = this.UserGuid;
                UpdateTime_2020.Text = DateTime.Now.ToString();
                Status_2020.Text = EpointRegisterUser_Bizlogic.OUStatus.待审核;
                IsHistory_2020.Text = "0";
                oEditPage.SaveTableValues(RowGuid, tdContainer);
            }

            #region 通知投资经理
            //strSql = "SELECT top(1) EnterpriseName FROM RG_OUInfo WHERE dwGuid='" + DWGuid + "' order by row_ID desc";
            //string EnterpriseName = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            //先获取投资经理            
            
            if (DWGuid_2020.Text != "")
            {
                for (int m = 0; m < dvUser.Count; m++)
                {
                    msg.WaitHandle_Insert(
                                    Guid.NewGuid().ToString(),
                                    "【审核】" + DWName_2020.Text + Year_2020.Text + "年" + Month_2020.Text + "月财务信息",
                                    "",
                                    dvUser[m]["s_xiangmujl_guid"].ToString(),
                                    dvUser[m]["s_xiangmujl"].ToString(),
                                    Session["UserGuid"].ToString(),
                                    Session["DisplayName"].ToString(),
                                    "",
                                    "EpointRegisterUser/Pages_RG/RG_CaiWu/RG_YueDuCaiWu_DetailForCheck.aspx?RowGuid=" + RowGuid + "&DWGuid=" + DWGuid_2020,
                                    "",
                                    "",
                                    1,
                                    "",
                                    "",
                                    ""
                             );
                }
            }

            #endregion

            this.WriteAjaxMessage("refreshParent();alert('提交成功');window.close();"); 
            //this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");           
       
		
		}

   }
}
