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
using System.Text;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace EpointRegisterUser.Pages_RG.RG_DongTai
{

    public partial class RG_DongTai_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 2019;
        Epoint.MisBizLogic2.Web.EditPage oEditPage;
        Epoint.MisBizLogic2.Web.AddPage oAddPage;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        public int ZLTableID = 2026;
        Epoint.MisBizLogic2.Web.ListPage oListPage2;
        EpointRegisterUser_Bizlogic.DongTai DT = new EpointRegisterUser_Bizlogic.DongTai();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string DWGuid = "";
                string RowGuid = "";
                string strURL = "";
                //先判断是否是跳转过来的
                if (String.IsNullOrEmpty(Request["RowGuid"]))//不是跳转
                {
                    //判断有没有记录，如果没有记录的话，就直接跳转到新增页面
                    string strSql = " select top(1) DWGuid from rg_ouinfo where DWGuid=(select distinct DanWeiGuid from RG_User where RowGuid='" + Session["UserGuid"].ToString() + "') order by row_id desc ";
                    DWGuid = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                    strSql = " select top(1) RowGuid from RG_DongTaiInfo   where DWGuid='" + DWGuid + "' order by row_id desc  ";
                    RowGuid = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                    if (RowGuid == "")//说明没有记录，就跳转到新增页面
                    {
                        strURL = "RG_DongTai_Add.aspx?ParentRowGuid=&RowGuid=" + Guid.NewGuid().ToString() + "&DWGuid=" + DWGuid + "";
                        this.WriteAjaxMessage("window.location.href='" + strURL + "';");
                        return;
                    }
                    else//如果有记录，也要跳转到本页面重新加载
                    {
                        strURL = "RG_DongTai_Edit.aspx?RowGuid=" + RowGuid + "&DWGuid=" + DWGuid + "";
                        this.WriteAjaxMessage("window.location.href='" + strURL + "';");
                        return;
                    }
                }
                else//是跳转
                {
                    RowGuid = Request["RowGuid"];
                    DWGuid = Request["DWGuid"];
                }
                
                //string DWGuid = Request["DWGuid"];
                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, RowGuid);
                if (!oRow.R_HasFilled)
                {
                    btnEdit.Visible = false;
                    this.AlertAjaxMessage("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
                //添加上传文件的大小和类型检查
                this.Add_FileUploadCheck_Script();

                #region 附件
                //CL_ZLJS.MisRowGuid = DWGuid;
                //CL_ZLJS.MisTableID = TableID;
                //CL_ZLJS.ProjectGuid = "";
                //CL_ZLJS.Comment = DWGuid;
                //CL_ZLJS.d_TiJiaoSJ = DateTime.Now.ToString();

                CL_YYZZ.MisRowGuid = DWGuid;
                CL_YYZZ.MisTableID = TableID;
                CL_YYZZ.ProjectGuid = "";
                CL_YYZZ.Comment = DWGuid;
                CL_YYZZ.d_TiJiaoSJ = DateTime.Now.ToString();

                CL_SWDJZ.MisRowGuid = DWGuid;
                CL_SWDJZ.MisTableID = TableID;
                CL_SWDJZ.ProjectGuid = "";
                CL_SWDJZ.Comment = DWGuid;
                CL_SWDJZ.d_TiJiaoSJ = DateTime.Now.ToString();

                CL_ZZJGDM.MisRowGuid = DWGuid;
                CL_ZZJGDM.MisTableID = TableID;
                CL_ZZJGDM.ProjectGuid = "";
                CL_ZZJGDM.Comment = DWGuid;
                CL_ZZJGDM.d_TiJiaoSJ = DateTime.Now.ToString();

                CL_SWPZZ.MisRowGuid = DWGuid;
                CL_SWPZZ.MisTableID = TableID;
                CL_SWPZZ.ProjectGuid = "";
                CL_SWPZZ.Comment = DWGuid;
                CL_SWPZZ.d_TiJiaoSJ = DateTime.Now.ToString();

                CL_QTFJ.MisRowGuid = DWGuid;
                CL_QTFJ.MisTableID = TableID;
                CL_QTFJ.ProjectGuid = "";
                CL_QTFJ.Comment = DWGuid;
                CL_QTFJ.d_TiJiaoSJ = DateTime.Now.ToString();
                #endregion

                RefreshGrid();
                RefreshGrid2();
                BindGongSi();
                BindTuanDui();
                BindBuTie();

                //注：待审核状态的，不能修改？
                if (Status_2019.Text == EpointRegisterUser_Bizlogic.OUStatus.待审核)
                {
                    btnEdit.Visible = false;
                    //CL_ZLJS.ReadOnly = true;
                    CL_YYZZ.ReadOnly = true;
                    CL_SWDJZ.ReadOnly = true;
                    CL_ZZJGDM.ReadOnly = true;
                    CL_SWPZZ.ReadOnly = true;
                    CL_QTFJ.ReadOnly = true;
                    btUpdateGongSi.Visible = false;
                    btUpdateTuanDui.Visible = false;
                    btUpdateBuTie.Visible = false;
                    this.grdBuTie.ShowFooter = false;
                    this.grdGongSi.Columns[5].Visible = false;
                    this.grdTuanDui.ShowFooter = false;
                    this.grdBuTie.Columns[5].Visible = false;
                    this.grdGongSi.ShowFooter = false;
                    this.grdTuanDui.Columns[5].Visible = false;
                    btnAddZL.Visible = false;
                    btnDelZL.Visible = false;
                    this.Datagrid2.Columns[8].Visible = false;
                }
            }
        }


        override protected void OnInit(EventArgs e)
        {
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, null);//如果没有导出Excel的Grid，就设置为null
            oListPage.CustomMode = true;            
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);
            oListPage2 = new Epoint.MisBizLogic2.Web.ListPage(ZLTableID, Datagrid2, null, Pager2, null);//如果没有导出Excel的Grid，就设置为null
            oListPage2.CustomMode = true;
            base.OnInit(e);
        }

        #region 列表
        private void RefreshGrid()
        {
            string str = "";

            str += " and DWGuid='" + Request["DWGuid"] + "' and IsHistory='1' ";
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
        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            string RowGuid = Request["RowGuid"];
            string DWGuid = Request["DWGuid"];
            string strSql = "SELECT top(1) EnterpriseName FROM RG_OUInfo WHERE dwGuid='" + DWGuid + "' order by row_ID desc";
            string EnterpriseName = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            //先获取投资经理            
            strSql = "SELECT s_xiangmujl_guid,s_xiangmujl FROM VIEW_CurrentVersion WHERE dwGuid='" + DWGuid + "'";
            DataView dvUser = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            if (dvUser.Count == 0)
            {
                WriteAjaxMessage("该企业没有对应的项目，请联系系统管理员。");
                return;
            }
            if (Request["sType"] == "0")
            {
                //说明是通过新增后提交审核，那么提交审核时就不要再新增一个版本了
                UpdateUserName_2019.Text = this.DisplayName;
                UpdateUserGuid_2019.Text = this.UserGuid;
                Status_2019.Text = EpointRegisterUser_Bizlogic.OUStatus.待审核;
                UpdateTime_2019.Text = DateTime.Now.ToString();
                IsHistory_2019.Text = "0";
                oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            }
            else
            {
                //先将原来的设置为历史记录
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                oRow["IsHistory"] = "1";
                //oRow["UpdateUserName"] = this.DisplayName;
                //oRow["UpdateUserGuid"] = this.UserGuid;
                //oRow["UpdateTime"] = DateTime.Now;
                oRow.Update();

                //再新增一个即可
                UpdateUserName_2019.Text = this.DisplayName;
                UpdateUserGuid_2019.Text = this.UserGuid;
                IsHistory_2019.Text = "0";
                UpdateTime_2019.Text = DateTime.Now.ToString();
                Status_2019.Text = EpointRegisterUser_Bizlogic.OUStatus.待审核;// "1";//0:编辑   1：待审核   2：通过
                //DelFlag_2019.Text = "0";
                RowGuid = Guid.NewGuid().ToString();
                oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);
            }
            #region 保存附件
            

            CL_YYZZ.MisRowGuid = DWGuid;
            CL_YYZZ.MisTableID = TableID;
            CL_YYZZ.ProjectGuid = "";
            CL_YYZZ.Comment = DWGuid;
            CL_YYZZ.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_YYZZ.Save();

            CL_SWDJZ.MisRowGuid = DWGuid;
            CL_SWDJZ.MisTableID = TableID;
            CL_SWDJZ.ProjectGuid = "";
            CL_SWDJZ.Comment = DWGuid;
            CL_SWDJZ.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_SWDJZ.Save();

            CL_ZZJGDM.MisRowGuid = DWGuid;
            CL_ZZJGDM.MisTableID = TableID;
            CL_ZZJGDM.ProjectGuid = "";
            CL_ZZJGDM.Comment = DWGuid;
            CL_ZZJGDM.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_ZZJGDM.Save();

            CL_SWPZZ.MisRowGuid = DWGuid;
            CL_SWPZZ.MisTableID = TableID;
            CL_SWPZZ.ProjectGuid = "";
            CL_SWPZZ.Comment = DWGuid;
            CL_SWPZZ.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_SWPZZ.Save();

            CL_QTFJ.MisRowGuid = DWGuid;
            CL_QTFJ.MisTableID = TableID;
            CL_QTFJ.ProjectGuid = "";
            CL_QTFJ.Comment = DWGuid;
            CL_QTFJ.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_QTFJ.Save();
            #endregion

            #region 通知投资经理
            
            for (int m = 0; m < dvUser.Count; m++)
            {
                msg.WaitHandle_Insert(
                                Guid.NewGuid().ToString(),
                                "【审核】" + EnterpriseName + "动态信息",
                                "",
                                dvUser[m]["s_xiangmujl_guid"].ToString(),
                                dvUser[m]["s_xiangmujl"].ToString(),
                                Session["UserGuid"].ToString(),
                                Session["DisplayName"].ToString(),
                                "",
                                "EpointRegisterUser/Pages_RG/RG_DongTai/RG_DongTai_DetailForCheck.aspx?RowGuid=" + RowGuid + "&DWGuid=" + DWGuid,
                                "",
                                "",
                                1,
                                "",
                                "",
                                ""
                         );
            }

            #endregion

            //oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            this.WriteAjaxMessage("alert('提交成功');");
            RefreshGrid();

            btnEdit.Visible = false;
        }

        #region 公司荣誉
        protected void BindGongSi()
        {
            DataView dv = DT.GetRongYuList(Request["DWGuid"].ToString(), "0");
            grdGongSi.DataSource = dv;
            grdGongSi.DataBind();
            grdGongSi.ShowFooter = true;
        }

        protected void grdGongSi_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "alert")
            {
                foreach (DataGridItem item in grdGongSi.Controls[0].Controls)
                {
                    if (item.ItemType == ListItemType.Footer)
                    {
                        //用item.FindControl查找相应的控件  
                        string name = ((TextBox)item.FindControl("tbRongYuNameNew")).Text;
                        string gaiYao = ((TextBox)item.FindControl("tbNeiRongGYNew")).Text;
                        string getDate = ((Epoint.Web.UI.WebControls2X.DateTextBox)item.FindControl("tbGetDateNew")).Text;
                        string danWei = ((TextBox)item.FindControl("tbBanFaDWNew")).Text;
                        DT.InsertRongYu(name, Request["DWGuid"].ToString(), gaiYao, danWei, getDate, "0");
                    }
                }

            }
            if (e.CommandName == "dele")
            {
                string Guid = e.CommandArgument.ToString();
                DT.DeleteRongYu(Guid);

            }
            BindGongSi();
        }

        protected void btGongSi_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < this.grdGongSi.Items.Count; i++)
            {
                string RowGuid = Convert.ToString(grdGongSi.DataKeys[i]);
                string name = ((TextBox)grdGongSi.Items[i].FindControl("tbRongYuName")).Text;
                string gaiYao = ((TextBox)grdGongSi.Items[i].FindControl("tbNeiRongGY")).Text;
                string getDate = ((Epoint.Web.UI.WebControls2X.DateTextBox)grdGongSi.Items[i].FindControl("tbGetDate")).Text;
                string danWei = ((TextBox)grdGongSi.Items[i].FindControl("tbBanFaDW")).Text;
                DT.UpdateRongYu(RowGuid, name, gaiYao, danWei, getDate);
            }
            this.BindGongSi();

            this.WriteAjaxMessage("alert('保存公司荣誉成功');");
        }
        #region 导出
        protected void btnGSRYExcel_Click(object sender, System.EventArgs e)
        {
            string strUrl = "RongYu_Print.aspx?tt=1";

            strUrl += "&ProjectGuid=" + Request["DWGuid"].ToString() + "&Type=0";
            string strScript = "OpenWindow('" + strUrl + "',800,700);";
            this.WriteAjaxMessage(strScript);
        }
        #endregion
        #endregion

        #region 团队荣誉
        protected void BindTuanDui()
        {
            DataView dv = DT.GetRongYuList(Request["DWGuid"].ToString(), "1");
            grdTuanDui.DataSource = dv;
            grdTuanDui.DataBind();
            grdTuanDui.ShowFooter = true;
        }
        protected void grdTuanDui_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "alert")
            {
                foreach (DataGridItem item in grdTuanDui.Controls[0].Controls)
                {
                    if (item.ItemType == ListItemType.Footer)
                    {
                        //用item.FindControl查找相应的控件  
                        string name = ((TextBox)item.FindControl("tbRongYuNameNew")).Text;
                        string gaiYao = ((TextBox)item.FindControl("tbNeiRongGYNew")).Text;
                        string getDate = ((Epoint.Web.UI.WebControls2X.DateTextBox)item.FindControl("tbGetDateNew")).Text;
                        string danWei = ((TextBox)item.FindControl("tbBanFaDWNew")).Text;
                        DT.InsertRongYu(name, Request["DWGuid"].ToString(), gaiYao, danWei, getDate, "1");
                    }
                }

            }
            if (e.CommandName == "dele")
            {
                string Guid = e.CommandArgument.ToString();
                DT.DeleteRongYu(Guid);

            }
            BindTuanDui();
        }

        protected void btTuanDui_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < this.grdTuanDui.Items.Count; i++)
            {
                string RowGuid = Convert.ToString(grdTuanDui.DataKeys[i]);
                string name = ((TextBox)grdTuanDui.Items[i].FindControl("tbRongYuName")).Text;
                string gaiYao = ((TextBox)grdTuanDui.Items[i].FindControl("tbNeiRongGY")).Text;
                string getDate = ((Epoint.Web.UI.WebControls2X.DateTextBox)grdTuanDui.Items[i].FindControl("tbGetDate")).Text;
                string danWei = ((TextBox)grdTuanDui.Items[i].FindControl("tbBanFaDW")).Text;
                DT.UpdateRongYu(RowGuid, name, gaiYao, danWei, getDate);
            }
            this.BindTuanDui();

            this.WriteAjaxMessage("alert('保存团队荣誉成功');");
        }
        #region 导出
        protected void btnTDRYExcel_Click(object sender, System.EventArgs e)
        {
            string strUrl = "RongYu_Print.aspx?tt=1";

            strUrl += "&ProjectGuid=" + Request["DWGuid"].ToString() + "&Type=1";
            string strScript = "OpenWindow('" + strUrl + "',800,700);";
            this.WriteAjaxMessage(strScript);
        }
        #endregion
        #endregion

        #region 补贴列表
        protected void BindBuTie()
        {
            DataView dvBT = DT.GetBTDV(Request["DWGuid"].ToString());
            grdBuTie.DataSource = dvBT;
            grdBuTie.DataBind();
            grdBuTie.ShowFooter = true;
        }

        protected void grdBuTie_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "alert")
            {
                //保存
                foreach (DataGridItem item in grdBuTie.Controls[0].Controls)
                {
                    if (item.ItemType == ListItemType.Footer)
                    {
                        //保存
                        string name = ((TextBox)item.FindControl("tbMingChenNew")).Text;
                        string jine = ((TextBox)item.FindControl("tbJinENew")).Text;
                        string qixian = ((TextBox)item.FindControl("tbQiXianNew")).Text;
                        string getDate = ((Epoint.Web.UI.WebControls2X.DateTextBox)item.FindControl("tbGetDateNew")).Text;
                        DT.InsertBT(Request["DWGuid"].ToString(), name, jine, qixian, getDate);
                    }
                }

            }
            if (e.CommandName == "dele")
            {
                string BTGuid = e.CommandArgument.ToString();
                DT.DeleteBT(BTGuid);

            }
            BindBuTie();
        }

        protected void btBuTie_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < this.grdBuTie.Items.Count; i++)
            {
                string RowGuid = Convert.ToString(grdBuTie.DataKeys[i]);
                string name = ((TextBox)grdBuTie.Items[i].FindControl("tbMingChen")).Text;
                string jine = ((TextBox)grdBuTie.Items[i].FindControl("tbJinE")).Text;
                string qixian = ((TextBox)grdBuTie.Items[i].FindControl("tbQiXian")).Text;
                string getDate = ((Epoint.Web.UI.WebControls2X.DateTextBox)grdBuTie.Items[i].FindControl("tbGetDate")).Text;

                DT.UpdateBT(RowGuid, name, jine, qixian, getDate);
            }
            this.BindBuTie();
            this.WriteAjaxMessage("alert('保存补贴成功');");
        }
        #region 导出
        protected void btnBTLBExcel_Click(object sender, System.EventArgs e)
        {
            string strUrl = "RongYu_PrintBT.aspx?tt=1";

            strUrl += "&ProjectGuid=" + Request["DWGuid"].ToString();
            string strScript = "OpenWindow('" + strUrl + "',800,700);";
            this.WriteAjaxMessage(strScript);
        }
        #endregion
        #endregion

        #region 专利
        private void RefreshGrid2()
        {
            oListPage2.OtherCondition = " and DWGuid='" + Request["DWGuid"] + "' ";//and PGuid='" + Request["RowGuid"] + "' ";
            oListPage2.SortExpression = " Row_ID desc ";
            oListPage2.GenerateSearchResult();
        }


        protected void btnDel_Click(object sender, System.EventArgs e)
        {
            CheckBox chk;
            for (int i = 0; i < Datagrid2.Items.Count; i++)
            {
                chk = (CheckBox)Datagrid2.Items[i].FindControl("chkAdd");
                if (chk.Checked)
                {
                    Epoint.MisBizLogic2.Data.CommonDataTable.DeleteRecord_FromSqlTable(
                       oListPage2.TableID,
                       oListPage2.TableDetail.SQL_TableName,
                       Convert.ToString(Datagrid2.DataKeys[i])
                       );
                }
            }
            this.RefreshGrid2();
        }



        protected void Datagrid2_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            oListPage2.PrepareForSortCommand(e.SortExpression);
            this.RefreshGrid2();
        }

        protected void Datagrid2_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            oListPage2.GenerateSerialNumColumn(e.Item);
        }
        #endregion

    }
}
