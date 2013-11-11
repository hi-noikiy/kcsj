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

namespace EpointRegisterUser.Pages_RG.RG_RenShi
{

    public partial class RG_RenShiInfo_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2022;

        Epoint.MisBizLogic2.Web.DetailPage oDetailPage;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                ViewState["TableName"] = oDetailPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);

                if (!oRow.R_HasFilled)
                {
                    //lblMessage.Visible=true;
                    //this.AlertAjaxMessage("没有对应的数据记录！");
                    //this.WriteAjaxMessage("window.close();");
                    return;
                }
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_DetailPage(oDetailPage, tdContainer, oRow);

                RefreshGrid();

                lblJD.Text = GetJD(this.s_qiJian_2022.Text);
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

            str += " and DWGuid='" + Request["DWGuid"] + "'  and RowGuid<>'" + Request["RowGuid"] + "' ";
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

        protected string GetJD(object s_qiJian)
        {
            string qijian = s_qiJian.ToString();
            string JD = "";
            if (qijian.ToString() != "")
            {
                try
                {
                    int thisYear = DateTime.Parse(qijian).Year;
                    int thisMonth = DateTime.Parse(qijian).Month;

                    JD += thisYear.ToString() + "年";
                    if (thisMonth.ToString() == "1" || thisMonth.ToString() == "2" || thisMonth.ToString() == "3")
                    {
                        JD += "1季度";
                    }
                    else if (thisMonth.ToString() == "4" || thisMonth.ToString() == "5" || thisMonth.ToString() == "6")
                    {
                        JD += "2季度";
                    }
                    else if (thisMonth.ToString() == "7" || thisMonth.ToString() == "8" || thisMonth.ToString() == "9")
                    {
                        JD += "3季度";
                    }
                    else
                    {
                        JD += "4季度";
                    }
                    return JD;
                }
                catch
                {
                    return JD;
                }
            }
            return JD;
        }
    }
}

