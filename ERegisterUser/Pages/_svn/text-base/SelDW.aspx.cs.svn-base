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

namespace EpointRegisterUser.Pages
{

    public partial class SelDW : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2017;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindOuType();

                this.RefreshGrid();
            }

        }

        override protected void OnInit(System.EventArgs e)
        {
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, null);//如果没有导出Excel的Grid，就设置为null

            oListPage.CustomMode = true;
            //此方法解决删除错位问题。可以使查询条件的值自动从ViewState中恢复。
            controlHolder.Controls.Add(oListPage.RenderSearchCondition());

            base.OnInit(e);
        }

        /// <summary>
        /// 绑定单位类别
        /// </summary>
        private void BindOuType()
        {
            //CommonEnum.DWType.Instace.InitListItems(RadioDWType.Items, false);
            //RadioDWType.Items.Insert(0, new ListItem("所有", "所有"));
            //RadioDWType.SelectedIndex = 0;
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
            string strCondition = " and DelFlag='0' and ishistory='0' ";
            //if (RadioAuditStatus.SelectedValue != CommonEnum.AuditStatus.所有)
            //{
            //    strCondition += " AND AuditStatus='" + RadioAuditStatus.SelectedValue + "'";
            //}
            //if (RadioDWType.SelectedValue != "所有")
            //{
            //    strCondition += " AND EnterpriseType LIKE '%" + RadioDWType.SelectedValue + "%'";
            //}
            if (TxtMC.Text.Trim() != "")
            {
                strCondition += " AND EnterpriseName LIKE '%" + TxtMC.Text.Trim() + "%'";
            }
            //if (TxtCode.Text.Trim() != "")
            //{
            //    strCondition += " AND CodeCertificate LIKE '%" + TxtCode.Text.Trim() + "%'";
            //}

            //列表信息
            oListPage.SelectFields = " * ";
            oListPage.OtherCondition = strCondition;
            oListPage.SortExpression = " Row_ID desc ";

            oListPage.GenerateSearchResult();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "打开搜索")
            {
                btnSearch.Text = "关闭搜索";
                tdCl.Style.Add("display", "");
            }
            else
            {
                btnSearch.Text = "打开搜索";
                tdCl.Style.Add("display", "none");
            }

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

        //审核状态选择变更
        protected void RadioAuditStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 0;
            this.RefreshGrid();
        }

        //单位类型选择变更
        protected void RadioDWType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 0;
            this.RefreshGrid();
        }
    }
}


