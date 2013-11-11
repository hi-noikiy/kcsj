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

namespace EpointRegisterUser.Group
{

    public partial class DataGroup_List : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 136;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //lblTableName.Text = oListPage.TableDetail.TableName;
                //this.CurrentHead = oListPage.TableDetail.TableName;

                #region 是否联机表
                if (oListPage.TableDetail.Is_OnlineTable == "1")
                {
                    btnAddRecord.Visible = false;
                    btnDel.Visible = false;
                }
                else
                {
                    btnAddRecord.Visible = true;
                    btnDel.Visible = true;
                }
                #endregion

                this.RefreshGrid();
            }

        }

        override protected void OnInit(System.EventArgs e)
        {
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, GridExcel);//如果没有导出Excel的Grid，就设置为null

            //此处添加全局通用条件 
            oListPage.OtherCondition = " and ParentGuid='"+Request["ParentGuid"]+"'";
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


        protected void btnDel_Click(object sender, System.EventArgs e)
        {
            CheckBox chk;
            for (int i = 0; i < Datagrid1.Items.Count; i++)
            {
                chk = (CheckBox)Datagrid1.Items[i].FindControl("chkAdd");
                if (chk.Checked)
                {
                    if (Epoint.MisBizLogic2.DB.ExecuteToInt("select count(1) from RG_DataGroup where ParentGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'") > 0)
                    {
                        AlertAjaxMessage("存在子归档，不允许删除……");
                        return;
                    }
                    else
                    {
                        new ComDataSyn().DeleteWithKeyValue(DataSynTarget.BackEndToFront, "RG_DataGroup", "RowGuid", Request["RowGuid"]);

                        Epoint.MisBizLogic2.Data.CommonDataTable.DeleteRecord_FromSqlTable(
                           oListPage.TableID,
                           oListPage.TableDetail.SQL_TableName,
                           Convert.ToString(Datagrid1.DataKeys[i])
                           );
                        new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_DataGroup_Relate", "GroupGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'", "RowGuid");
                        Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_DataGroup_Relate where GroupGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    }
                }
            }
            this.RefreshGrid();
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


