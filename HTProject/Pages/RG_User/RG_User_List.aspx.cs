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

namespace HTProject.Pages.RG_User
{
    public partial class RG_User_List : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public string DanWeiGuid
        {
            get
            {
                return Request["DanWeiGuid"];
            }
        }
        Epoint.RegisterUser.Front.Bizlogic.RegisterModule.RegisterModule rgModule = new Epoint.RegisterUser.Front.Bizlogic.RegisterModule.RegisterModule();

        public int TableID = 2010;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblTableName.Text = oListPage.TableDetail.TableName;
                //this.CurrentHead   = oListPage.TableDetail.TableName;				
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
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, null);//如果没有导出Excel的Grid，就设置为null
            //此处添加全局通用条件 

            tdrecover.Style["display"] = "none";
            oListPage.CustomMode = true;
            oListPage.SortExpression = " order by Row_ID desc";
            //此方法解决删除错位问题。可以使查询条件的值自动从ViewState中恢复。
            controlHolder.Controls.Add(oListPage.RenderSearchCondition());
            base.OnInit(e);
        }
        protected void statusSel_Changed(object sender, System.EventArgs e)
        {
            this.RefreshGrid();
        }

        protected void btnRecover(object sender, System.EventArgs e)
        {
            CheckBox chk;
            for (int i = 0; i < Datagrid1.Items.Count; i++)
            {
                chk = (CheckBox)Datagrid1.Items[i].FindControl("chkAdd");
                if (chk.Checked)
                {
                    string LoginID = Epoint.MisBizLogic2.DB.ExecuteToString("select LoginID from RG_User where RowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    Boolean IsExisted = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(1) from RG_User where LoginID='" + LoginID + "' and DelFlag=0") > 0;
                    if (IsExisted)
                    {
                        AlertAjaxMessage("存在未被删除的相同登录名‘" + LoginID + "’,请修改为不同后再恢复。");
                        return;
                    }
                    else
                    {
                        Epoint.MisBizLogic2.DB.ExecuteNonQuery("update RG_User set DelFlag=0 where RowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                        new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_User", "RowGuid", Convert.ToString(Datagrid1.DataKeys[i]));
                    }
                }
            }
            this.RefreshGrid();

            tddel.Style["display"] = "";
            tdadd.Style["display"] = "";
        }

        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            Pager.CurrentPageIndex = 0;
            this.RefreshGrid();
        }

        private void RefreshGrid()
        {
            switch (statusSel.SelectedValue)
            {
                case "0":
                    oListPage.OtherCondition = " and DelFlag=0";
                    tdrecover.Style["display"] = "none";
                    tddel.Style["display"] = "";
                    break;
                case "1":
                    oListPage.OtherCondition = " and DelFlag=1";
                    tdrecover.Style["display"] = "";
                    tddel.Style["display"] = "none";
                    break;
                case "2":
                    oListPage.OtherCondition = " and DelFlag=0 and UserStatus = '002'";
                    tdrecover.Style["display"] = "none";
                    tddel.Style["display"] = "";
                    break;
                case "3":
                    oListPage.OtherCondition = " and DelFlag=0 and UserStatus = '001'";
                    tdrecover.Style["display"] = "none";
                    tddel.Style["display"] = "";
                    break;
                case "all":
                    oListPage.OtherCondition = "";
                    tdrecover.Style["display"] = "none";
                    tddel.Style["display"] = "";
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(Request["DanWeiGuid"]))
            {
                oListPage.OtherCondition += " and DanWeiGuid='" + DanWeiGuid + "'";
            }
            if (DWName.Text.Trim() != "")
            {
                oListPage.OtherCondition += " AND EXISTS(SELECT 1 FROM RG_OUInfo OU WHERE OU.ROWGUID=RG_User.DanWeiGuid AND EnterpriseName LIKE '%" + Epoint.MisBizLogic2.DB.SQL_Encode(DWName.Text) + "%') ";
            }
            if (DispName.Text.Trim() != "")
            {
                oListPage.OtherCondition += " AND DispName LIKE '%" + Epoint.MisBizLogic2.DB.SQL_Encode(DispName.Text) + "%' ";
            }
            if (LoginID.Text.Trim() != "")
            {
                oListPage.OtherCondition += " AND LoginID LIKE '%" + Epoint.MisBizLogic2.DB.SQL_Encode(LoginID.Text) + "%' ";
            }
            if (PINCode.Text.Trim() != "")
            {
                oListPage.OtherCondition += " AND PINCode LIKE '%" + Epoint.MisBizLogic2.DB.SQL_Encode(PINCode.Text) + "%' ";
            }
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
                    
                    Epoint.MisBizLogic2.DB.ExecuteNonQuery("update RG_User set DelFlag=1 where RowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_User", "RowGuid", Convert.ToString(Datagrid1.DataKeys[i]));

                    // 删除会员相关的应用系统权限
                    //new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Application_Right", "AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'", "RowGuid");
                    // 删除会员相关的模块权限
                    new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Module_Right", "AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'", "RowGuid");
                    // 删除会员相关的快捷菜单权限
                    new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_ShortcutMenu_Right", "AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'", "RowGuid");
                    // 删除会员相关的角色关联
                    new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_User_Role", "RGUserGUID='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'", "RowGuid");
                    // 删除会员相关的分类信息权限
                    new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_WebInfoCateRight", "AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'", "RowGuid");

                    //Epoint.MisBizLogic2.DB.ExecuteNonQuery("DELETE FROM RG_Application_Right WHERE AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    Epoint.MisBizLogic2.DB.ExecuteNonQuery("DELETE FROM RG_Module_Right WHERE AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    Epoint.MisBizLogic2.DB.ExecuteNonQuery("DELETE FROM RG_ShortcutMenu_Right WHERE AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    Epoint.MisBizLogic2.DB.ExecuteNonQuery("DELETE FROM RG_User_Role WHERE RGUserGUID='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    Epoint.MisBizLogic2.DB.ExecuteNonQuery("DELETE FROM RG_WebInfoCateRight WHERE AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                }
            }
            this.RefreshGrid();
        }


        protected void btnRemove_Click(object sender, System.EventArgs e)
        {
            CheckBox chk;
            for (int i = 0; i < Datagrid1.Items.Count; i++)
            {
                chk = (CheckBox)Datagrid1.Items[i].FindControl("chkAdd");
                if (chk.Checked)
                {
                    string DanWeiGuid = Epoint.MisBizLogic2.DB.ExecuteToString("select DanWeiGuid from RG_User where RowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    //if (!string.IsNullOrEmpty(DanWeiGuid))
                    //{
                    //    DataView dvApp = rgModule.GetAppForSyn(DanWeiGuid);
                    //    if (dvApp.Count > 0)
                    //    {
                    //        foreach (DataRowView row in dvApp)
                    //        {
                    //            new ComDataSyn().DeleteWithKeyValue(row["SynTargetAddr"].ToString(), "RG_User", "RowGuid", Convert.ToString(Datagrid1.DataKeys[i]));
                    //        }
                    //    }
                    //}
                    Epoint.MisBizLogic2.DB.ExecuteNonQuery("Delete From RG_User where RowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    //new ComDataSyn().DeleteWithKeyValue(DataSynTarget.BackEndToFront, "RG_User", "RowGuid", Convert.ToString(Datagrid1.DataKeys[i]));

                    // 删除会员相关的应用系统权限
                    //new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Application_Right", "AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'", "RowGuid");
                    // 删除会员相关的模块权限
                    new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Module_Right", "AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'", "RowGuid");
                    // 删除会员相关的快捷菜单权限
                    //new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_ShortcutMenu_Right", "AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'", "RowGuid");
                    // 删除会员相关的角色关联
                    new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_User_Role", "RGUserGUID='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'", "RowGuid");
                    // 删除会员相关的分类信息权限
                    //new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_WebInfoCateRight", "AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'", "RowGuid");

                    //Epoint.MisBizLogic2.DB.ExecuteNonQuery("DELETE FROM RG_Application_Right WHERE AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    Epoint.MisBizLogic2.DB.ExecuteNonQuery("DELETE FROM RG_Module_Right WHERE AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    //Epoint.MisBizLogic2.DB.ExecuteNonQuery("DELETE FROM RG_ShortcutMenu_Right WHERE AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    Epoint.MisBizLogic2.DB.ExecuteNonQuery("DELETE FROM RG_User_Role WHERE RGUserGUID='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    //Epoint.MisBizLogic2.DB.ExecuteNonQuery("DELETE FROM RG_WebInfoCateRight WHERE AllowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                }
            }
            this.AlertAjaxMessage("删除成功！");
            this.RefreshGrid();
        }
        protected void btnPass_Click(object sender, System.EventArgs e)
        {
            CheckBox chk;
            for (int i = 0; i < Datagrid1.Items.Count; i++)
            {
                chk = (CheckBox)Datagrid1.Items[i].FindControl("chkAdd");
                if (chk.Checked)
                {
                    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_User", Convert.ToString(Datagrid1.DataKeys[i]));
                    oRow["UserStatus"] = "002";
                    oRow["IsValid"] = "1";
                    oRow.Update();
                    new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_User", "RowGuid", Convert.ToString(Datagrid1.DataKeys[i]));
                }
            }
            this.AlertAjaxMessage("审核完成！");
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

        protected string GetOUName(object DWGuid)
        {
            string strSql = " select top(1) EnterpriseName from rg_ouinfo where RowGuid='" + DWGuid + "' order by row_id desc ";
            return Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
        }
    }
}


