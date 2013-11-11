
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

namespace EpointRegisterUser.Pages.RG_ShortcutMenu
{

    public partial class ShortcutMenu_List : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 114;
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
            oListPage.OtherCondition = " ";
            oListPage.SortExpression = " Order by Row_ID Desc ";
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
                    new ComDataSyn().DeleteWithKeyValue(DataSynTarget.BackEndToFront, "RG_ShortcutMenu", "RowGuid", Convert.ToString(Datagrid1.DataKeys[i]));

                    // DeleteChildModule(Convert.ToString(Datagrid1.DataKeys[i])) ;
                    Epoint.MisBizLogic2.Data.CommonDataTable.DeleteRecord_FromSqlTable(
                      oListPage.TableID,
                      oListPage.TableDetail.SQL_TableName,
                      Convert.ToString(Datagrid1.DataKeys[i])
                      );
                    new ComDataSyn().DeleteWithKeyValue(DataSynTarget.BackEndToFront, "RG_ShortcutMenu_Right", "ShortcutGuid", Convert.ToString(Datagrid1.DataKeys[i]));

                    Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_ShortcutMenu_Right where ShortcutGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
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
        protected void btnQuickNew_Click(object sender, EventArgs e)
        {
            string RowGuid = Guid.NewGuid().ToString();
            Epoint.MisBizLogic2.Data.MisGuidRow orow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_ShortcutMenu", RowGuid);
            orow["ShortcutText"] = "快捷方式名称";          
            orow["ShortcutType"] = 1;
            orow["IsBlank"] = 0;
            orow.Insert();
            new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_ShortcutMenu", "RowGuid", RowGuid);
            this.RefreshGrid();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Datagrid1.Items.Count; i++)
            {
                TextBox txtName = (TextBox)Datagrid1.Items[i].FindControl("txtName");
                TextBox txtAddress = (TextBox)Datagrid1.Items[i].FindControl("txtAddress");
                // TextBox txtOrderNum = (TextBox)Datagrid1.Items[i].FindControl("txtOrderNum");
                string gd = Convert.ToString(Datagrid1.DataKeys[i]);
                Epoint.MisBizLogic2.Data.MisGuidRow orow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_ShortcutMenu", gd);
                orow["ShortcutText"] = txtName.Text;
                orow["ShortcutUrl"] = txtAddress.Text;
                orow.Update();
                new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_ShortcutMenu", "RowGuid", gd);
            }
            this.RefreshGrid();
        }

        /// <summary>
        /// 生成模块菜单的脚本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGenerateSQL_Click(object sender, EventArgs e)
        {
            CheckBox chkSel;
            txtSQL.Text = "";
            for (int i = 0; i < Datagrid1.Items.Count; i++)
            {
                chkSel = (CheckBox)Datagrid1.Items[i].FindControl("chkAdd");
                if (chkSel.Checked)
                {
                    string strSQL;
                    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_ShortcutMenu", Datagrid1.DataKeys[i].ToString());
                    strSQL = "if not exists(select 1 from RG_ShortcutMenu where RowGuid = '" + oRow["RowGuid"] + "')\r\n";
                    strSQL += " begin \r\n";
                    strSQL += " insert into RG_ShortcutMenu(IsBlank, ShortcutType, ShortcutImg, ShortcutUrl, ShortcutText, BelongXiaQuCode, OperateUserName, OperateDate, Row_ID, YearFlag, RowGuid, IsReloadTree)";
                    strSQL += " values('" + oRow["IsBlank"] + "',";
                    strSQL += "'" + oRow["ShortcutType"] + "',";
                    strSQL += "'" + oRow["ShortcutImg"] + "',";
                    strSQL += "'" + oRow["ShortcutUrl"] + "',";
                    strSQL += "'" + oRow["ShortcutText"] + "',";
                    strSQL += "'" + oRow["BelongXiaQuCode"] + "',";
                    strSQL += "'" + oRow["OperateUserName"] + "',";
                    strSQL += "'" + oRow["OperateDate"] + "',";
                    strSQL += "'" + oRow["Row_ID"] + "',";
                    strSQL += "'" + oRow["YearFlag"] + "',";
                    strSQL += "'" + oRow["RowGuid"] + "',";
                    strSQL += "'" + oRow["IsReloadTree"] + "'";
                    strSQL += ")\r\n";
                    strSQL += " end \r\n";
                    txtSQL.Text += strSQL;
                }
            }
        }

    }
}


