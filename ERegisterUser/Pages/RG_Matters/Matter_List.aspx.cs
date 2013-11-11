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

namespace EpointRegisterUser.Pages.RG_Matters
{

    public partial class Matter_List : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        protected string ParentGuid
        {
            get
            {
                if (string.IsNullOrEmpty(Request["ParentGuid"]))
                    return "";
                else
                    return Request["ParentGuid"];
            }
        }
        public int TableID = 131;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
                if (ParentGuid == "all")
                {
                    tdQuickAdd.Style["display"] = "none";
                    tdSave.Style["display"] = "none";
                    tdAdd.Style["display"] = "none";
                }
                else
                {
                    tdQuickAdd.Style["display"] = "";
                    tdSave.Style["display"] = "";
                    tdAdd.Style["display"] = "";
                }

                this.RefreshGrid();
            }

        }

        override protected void OnInit(System.EventArgs e)
        {
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, null);//如果没有导出Excel的Grid，就设置为null

            //此处添加全局通用条件 
            oListPage.OtherCondition = " and ParentGuid='" + ParentGuid + "'";
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
                    if (Epoint.MisBizLogic2.DB.ExecuteToInt("select count(1) from RG_Matters where ParentGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'") > 0)
                    {
                        AlertAjaxMessage("所选事项中存在子事项分配，不允许删除！");
                        return;
                    }
                    new ComDataSyn().DeleteWithKeyValue(DataSynTarget.BackEndToFront, "RG_Matters", "RowGuid", Convert.ToString(Datagrid1.DataKeys[i]));
                    Epoint.MisBizLogic2.Data.CommonDataTable.DeleteRecord_FromSqlTable(
                       oListPage.TableID,
                       oListPage.TableDetail.SQL_TableName,
                       Convert.ToString(Datagrid1.DataKeys[i])
                       );
                    new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Matters", "ParentGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'", "RowGuid");
                    Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Matters where ParentGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                }
            }
            this.RefreshGrid();
        }


        //protected void btnExcel_ServerClick(object sender, System.EventArgs e)
        //{
        //    if (hidSelectedFields.Value != "")
        //    {
        //        oListPage.GenerateExcelGrid_SelectColumns(this.lblTableName.Text,
        //           "",
        //           "",
        //           0,
        //           hidSelectedFields.Value
        //           );
        //    }
        //    else
        //    {
        //        this.AlertAjaxMessage("请选择导出的字段！");
        //    }
        //}

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
            Epoint.MisBizLogic2.Data.MisGuidRow orow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Matters", RowGuid);
            orow["ParentGuid"] = ParentGuid;
            orow["MatterName"] = "事项名称";
            orow["InstrUrl"] = "";
            orow["IsForbidden"] = 0;
            orow["OrderNum"] = -1;
            orow["IsBlank"] = 0;
            orow["IsHidden"] = 0;
            orow["AppGuid"] = "";
            orow["OperateUserName"] = Session["DisplayName"];
            orow["OperateDate"] = System.DateTime.Now.ToString();
            orow.Insert();
            new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_Matters", "RowGuid", RowGuid);
            AlertAjaxMessage("快速新建成功！");
            this.RefreshGrid();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Datagrid1.Items.Count; i++)
            {
                TextBox txtName = (TextBox)Datagrid1.Items[i].FindControl("txtName");
                TextBox txtAddress = (TextBox)Datagrid1.Items[i].FindControl("txtAddress");
                TextBox txtOrderNum = (TextBox)Datagrid1.Items[i].FindControl("txtOrderNum");
                string gd = Convert.ToString(Datagrid1.DataKeys[i]);
                Epoint.MisBizLogic2.Data.MisGuidRow orow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Matters", gd);
                orow["MatterName"] = txtName.Text;
                orow["MatterUrl"] = txtAddress.Text;
                orow["OrderNum"] = txtOrderNum.Text;
                orow.Update();
                new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_Matters", "RowGuid", gd);
            }
            // new ComDataSyn().UpdateWithCondition(DataSynTarget.BackEndToFront, "RG_Matters", "ParentGuid='" + ParentGuid + "'and AppGuid='" + AppGuid + "'", "RowGuid");
            AlertAjaxMessage("修改成功！");
            this.RefreshGrid();
        }
        public string getSource(string MatterGuid)
        {
            if (Epoint.MisBizLogic2.DB.ExecuteToInt("select count(1) from RG_Matters where ParentGuid='" + MatterGuid + "'") > 0)
                return "";
            else
            {
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Matters",MatterGuid);
                if (string.IsNullOrEmpty(oRow["AppGuid"].ToString()))
                    return "平台提供";
                else return Epoint.MisBizLogic2.DB.ExecuteToString("select AppName from RG_Application where AppGuid='"+oRow["AppGuid"].ToString()+"'");
            }
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
                    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Matters", Datagrid1.DataKeys[i].ToString());
                    strSQL = "if not exists(select 1 from  RG_Matters where RowGuid = '" + oRow["RowGuid"] + "')\r\n";
                    strSQL += " begin \r\n";
                    strSQL += " insert into RG_Matters(ParentGuid, AppGuid, InstrUrl, MatterName, MatterUrl, OrderNum, IsForbidden, IsBlank, BelongXiaQuCode, OperateUserName, OperateDate, YearFlag, RowGuid,IsHidden,Instruction,IsDefault,UniqueID)";
                    strSQL += " values('" + oRow["ParentGuid"] + "',";
                    strSQL += "'" + oRow["AppGuid"] + "',";
                    strSQL += "'" + oRow["InstrUrl"] + "',";
                    strSQL += "'" + oRow["MatterName"] + "',";
                    strSQL += "'" + oRow["MatterUrl"] + "',";
                    strSQL += "'" + oRow["OrderNum"] + "',";
                    strSQL += "'" + oRow["IsForbidden"] + "',";
                    strSQL += "'" + oRow["IsBlank"] + "',";
                    strSQL += "'" + oRow["BelongXiaQuCode"] + "',";
                    strSQL += "'" + oRow["OperateUserName"] + "',";
                    strSQL += "'" + oRow["OperateDate"] + "',";
                    strSQL += "'" + oRow["YearFlag"] + "',";
                    strSQL += "'" + oRow["RowGuid"] + "',";
                    strSQL += "'" + oRow["IsHidden"] + "',";
                    strSQL += "'" + oRow["Instruction"] + "',";
                    strSQL += "'" + oRow["IsDefault"] + "',";
                    strSQL += "'" + oRow["UniqueID"] + "'";
                    strSQL += ")\r\n";
                    strSQL += " end \r\n";
                    txtSQL.Text += strSQL;
                }
            }
        }
    }
}


