using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System;

namespace EpointRegisterUser.Pages.RG_OuTypeRight
{
    public partial class OuType_List : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.RefreshGrid();
            }
        }

        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            Pager.CurrentPageIndex = 0;
            this.RefreshGrid();
        }

        protected void btnRefresh_Click(object sender, System.EventArgs e)
        {
            this.RefreshGrid();
        }

        private void RefreshGrid()
        {
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select ItemText,ItemValue from Code_Items inner join Code_Main on Code_Items.CodeID=Code_Main.CodeID where Code_Main.CodeName='RG_会员单位'");
            Pager.RecordCount = dv.Count;
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = Pager.PageSize;
            pds.CurrentPageIndex = Pager.CurrentPageIndex - 1;
            pds.DataSource = dv;
            Datagrid1.DataSource = pds;
            Datagrid1.DataBind();
            LblRecordEveryPage1.Text = "每页:" + "<font color='blue'><b>" + Pager.PageSize.ToString() + "</b></font>";
            LblCurrentIndex1.Text = "当前页:" + "<font color='red'><b>" + Pager.CurrentPageIndex.ToString() + "</b></font>";
            LblPageCount1.Text = "总页数:" + "<font color='blue'><b>" + Pager.PageCount.ToString() + "</b></font>";
            LblRecordCount1.Text = "记录总数：" + "<font color='blue'><b>" + Pager.RecordCount + "</b></font>";
        }


        protected void Pager_PageChanged(object src, Wuqi.Webdiyer.PageChangedEventArgs e)
        {
            Pager.CurrentPageIndex = e.NewPageIndex;
            this.RefreshGrid();
        }

        protected void Datagrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            // oListPage.PrepareForSortCommand(e.SortExpression);
            Pager.CurrentPageIndex = 0;
            this.RefreshGrid();
        }

        protected void Datagrid1_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            //oListPage.GenerateSerialNumColumn(e.Item);
        }

        protected void GridExcel_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                for (int i = 0; i < e.Item.Cells.Count; i++)
                    e.Item.Cells[i].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
            }
        }
    }
}
