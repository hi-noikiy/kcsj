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

namespace EpointRegisterUser.Pages_RG.RG_CaiWu
{

    public partial class RG_YueDuCaiWu_DetailForCheck : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2020;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        Epoint.MisBizLogic2.Web.DetailPage oDetailPage;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                ViewState["TableName"] = oDetailPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);

                if (!oRow.R_HasFilled)
                {
                    //lblMessage.Visible=true;
                    this.AlertAjaxMessage("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_DetailPage(oDetailPage, tdContainer, oRow);

                RefreshGrid();
            }

        }

        override protected void OnInit(EventArgs e)
        {
            oDetailPage = new Epoint.MisBizLogic2.Web.DetailPage(TableID);
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, null);//如果没有导出Excel的Grid，就设置为null
            oListPage.CustomMode = true;
            base.OnInit(e);
        }

        #region 列表
        private void RefreshGrid()
        {
            string str = "";

            str += " and DWGuid='" + Request["DWGuid"] + "' and IsHistory='1' and YearMonth='" + Year_2020.Text + "-" + Month_2020.Text + "-01 00:00:00" + "' and RowGuid<>'" + Request["RowGuid"] + "' ";
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
        protected void btnYes_Click(object sender, System.EventArgs e)
        {
            string RowGuid = Request["RowGuid"];
            string DWGuid = Request["DWGuid"];

            //先将原来的设置为历史记录
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            oRow["Status"] = EpointRegisterUser_Bizlogic.OUStatus.通过;
            oRow["CheckUserName"] = this.DisplayName;
            oRow["CheckUserGuid"] = this.UserGuid;
            oRow["CheckTime"] = DateTime.Now;
            oRow.Update();

            btnNo.Visible = false;
            btnYes.Visible = false;

            if (!String.IsNullOrEmpty(Request["MessageItemGuid"]))
            {
                msg.WaitHandle_Delete(Request["MessageItemGuid"]);
            }

            WriteAjaxMessage("refreshParent();alert('审核通过');window.close();");
        }

        protected void btnNo_Click(object sender, System.EventArgs e)
        {
            string RowGuid = Request["RowGuid"];
            string DWGuid = Request["DWGuid"];

            //先将原来的设置为历史记录
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            oRow["Status"] = EpointRegisterUser_Bizlogic.OUStatus.不通过;
            oRow["CheckUserName"] = this.DisplayName;
            oRow["CheckUserGuid"] = this.UserGuid;
            oRow["CheckTime"] = DateTime.Now;
            oRow.Update();

            btnNo.Visible = false;
            btnYes.Visible = false;

            if (!String.IsNullOrEmpty(Request["MessageItemGuid"]))
            {
                msg.WaitHandle_Delete(Request["MessageItemGuid"]);
            }

            WriteAjaxMessage("refreshParent();alert('审核不通过');window.close();");
        }
    }
}

