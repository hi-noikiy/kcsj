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
using Epoint.RegisterUser.DataSyn.Bizlogic;

namespace EpointRegisterUser.Pages.RG_Application
{
    public partial class RG_Application_Matter : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        protected string AppGuid
        {
            get
            {
                if (string.IsNullOrEmpty(Request["AppGuid"]))
                    return "";
                else
                    return Request["AppGuid"];
            }
        }
        public int TableID = 131;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.RefreshGrid();
            }
        }

        override protected void OnInit(System.EventArgs e)
        {
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, null);//如果没有导出Excel的Grid，就设置为null

            //此处添加全局通用条件 
            oListPage.OtherCondition = " and AppGuid='" + AppGuid + "'";
            oListPage.SortExpression = " OrderNum desc";
            oListPage.CustomMode = true;
            //此方法解决删除错位问题。可以使查询条件的值自动从ViewState中恢复。
            controlHolder.Controls.Add(oListPage.RenderSearchCondition());

            base.OnInit(e);
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
    }
}


