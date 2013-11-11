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
using EpointRegisterUser_Bizlogic;

namespace EpointRegisterUser.Pages.RG_OU
{

    public partial class RG_OU_List : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2017;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblTableName.Text = oListPage.TableDetail.TableName;
                this.CurrentHead = oListPage.TableDetail.TableName;

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
            oListPage.CustomMode = true;
            oListPage.SortExpression = " order by Row_ID desc";
            //此方法解决删除错位问题。可以使查询条件的值自动从ViewState中恢复。
            controlHolder.Controls.Add(oListPage.RenderSearchCondition());

            base.OnInit(e);
        }


        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            Pager.CurrentPageIndex = 0;
            this.RefreshGrid();
        }


        private void RefreshGrid()
        {
            string strWhere = " and ishistory='0' ";
            switch (statusSel.SelectedValue)
            {
                case "0":

                    tdrecover.Style["display"] = "none";
                    tddel.Style["display"] = "";
                    break;
                case "1":

                    tdrecover.Style["display"] = "";
                    tddel.Style["display"] = "none";
                    break;
                case "":

                    tdrecover.Style["display"] = "none";
                    tddel.Style["display"] = "";
                    break;
                default:
                    break;
            }
            if (statusSel.SelectedIndex > 0)
            {
                strWhere += " and DelFlag='" + statusSel.SelectedValue + "' ";
            }
            oListPage.OtherCondition += strWhere;
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
                    Epoint.MisBizLogic2.Data.CommonDataTable.DeleteRecord_FromSqlTable(
                       oListPage.TableID,
                       oListPage.TableDetail.SQL_TableName,
                       Convert.ToString(Datagrid1.DataKeys[i])
                       );
                }
            }
            this.RefreshGrid();
        }

        protected void btnZS_Click(object sender, System.EventArgs e)
        {
            CheckBox chk;
            for (int i = 0; i < Datagrid1.Items.Count; i++)
            {
                chk = (CheckBox)Datagrid1.Items[i].FindControl("chkAdd");
                if (chk.Checked)
                {
                    //Epoint.MisBizLogic2.Data.CommonDataTable.DeleteRecord_FromSqlTable(
                    //   oListPage.TableID,
                    //   oListPage.TableDetail.SQL_TableName,
                    //   Convert.ToString(Datagrid1.DataKeys[i])
                    //   );
                    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oListPage.TableDetail.SQL_TableName, Convert.ToString(Datagrid1.DataKeys[i]));
                    oRow["DelFlag"] = "1";
                    oRow.Update();
                }
            }
            this.RefreshGrid();
        }

        protected void statusSel_Changed(object sender, System.EventArgs e)
        {
            this.RefreshGrid();
        }

        protected void btnRecover_Click(object sender, System.EventArgs e)
        {
            CheckBox chk;
            for (int i = 0; i < Datagrid1.Items.Count; i++)
            {
                chk = (CheckBox)Datagrid1.Items[i].FindControl("chkAdd");
                if (chk.Checked)
                {
                    Epoint.MisBizLogic2.DB.ExecuteNonQuery("update RG_OUInfo set DelFlag=0 where RowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    //new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_OUInfo", "RowGuid", Convert.ToString(Datagrid1.DataKeys[i]));
                }
            }
            this.RefreshGrid();
            tddel.Style["display"] = "";
        }

        protected void btnExcel_ServerClick(object sender, System.EventArgs e)
        {
            if (hidSelectedFields.Value != "")
            {
                oListPage.GenerateExcelGrid_SelectColumns(this.lblTableName.Text,
                   "",
                   "",
                   0,
                   hidSelectedFields.Value
                   );
            }
            else
            {
                this.AlertAjaxMessage("请选择导出的字段！");
            }
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

        protected string GetStatus(object Status)
        {
            return OUStatus.GetTextByValue(Status.ToString());
            //switch (Status.ToString())
            //{
            //    case "1":
            //        return "编辑中";
            //    case "2":
            //        return "待审核";
            //    case "3":
            //        return "已通过";
            //    default:
            //        return "";
            //}
        }

    }
}


