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

namespace EpointRegisterUser.Pages.RG_OU
{

    public partial class RG_OU_DetailForPro : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2017;

        Epoint.MisBizLogic2.Web.DetailPage oDetailPage;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        public int GGTableID = 2023;
        Epoint.MisBizLogic2.Web.ListPage oListPage2;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string DWGuid = Request["DWGuid"];
                string strSql = " select top(1) RowGuid from rg_ouinfo where DWGuid='" + DWGuid + "' order by row_id desc ";

                string RowGuid = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                
                
                ViewState["TableName"] = oDetailPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, RowGuid);

                if (!oRow.R_HasFilled)
                {
                    //lblMessage.Visible=true;
                    this.AlertAjaxMessage("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_DetailPage(oDetailPage, tdContainer, oRow);

                #region 附件
                CL_SB.MisRowGuid = DWGuid;
                CL_SB.MisTableID = TableID;
                CL_SB.ProjectGuid = "";
                CL_SB.Comment = DWGuid;
                CL_SB.d_TiJiaoSJ = DateTime.Now.ToString();
                //CL_SB.s

                CL_Logo.MisRowGuid = DWGuid;
                CL_Logo.MisTableID = TableID;
                CL_Logo.ProjectGuid = "";
                CL_Logo.Comment = DWGuid;
                CL_Logo.d_TiJiaoSJ = DateTime.Now.ToString();

                CL_GSJS.MisRowGuid = DWGuid;
                CL_GSJS.MisTableID = TableID;
                CL_GSJS.ProjectGuid = "";
                CL_GSJS.Comment = DWGuid;
                CL_GSJS.d_TiJiaoSJ = DateTime.Now.ToString();

                CL_ZS.MisRowGuid = DWGuid;
                CL_ZS.MisTableID = TableID;
                CL_ZS.ProjectGuid = "";
                CL_ZS.Comment = DWGuid;
                CL_ZS.d_TiJiaoSJ = DateTime.Now.ToString();
                #endregion

                RefreshGrid();
                RefreshGrid2();

                #region 动态信息
                string RowGuid2 = "";
                strSql = " select top(1) RowGuid from RG_DongTaiInfo where DWGuid='" + DWGuid + "' order by row_id desc ";
                RowGuid2 = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                ifDT.Attributes["src"] = "../../Pages_RG/RG_DongTai/RG_DongTai_Detail.aspx?RowGuid=" + RowGuid2 + "&DWGuid=" + DWGuid;
                #endregion

                #region 财务信息
                //string RowGuid2 = "";
                //strSql = " select top(1) RowGuid from RG_DongTaiInfo where DWGuid='" + DWGuid + "' order by row_id desc ";
                RowGuid2 = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                ifCW.Attributes["src"] = "../../Pages_RG/RG_CaiWu/RG_YueDuCaiWuView_List.aspx?DWGuid=" + DWGuid;
                #endregion

                #region 其他重要信息
                string RowGuid3 = "";
                strSql = " select top(1) RowGuid from RG_OtherInfo where DWGuid='" + DWGuid + "' order by row_id desc ";
                RowGuid3 = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                ifOther.Attributes["src"] = "../../Pages_RG/RG_Other/RG_OtherInfo_Detail.aspx?RowGuid=" + RowGuid3 + "&DWGuid=" + DWGuid;
                #endregion

                #region 人事信息
                string RowGuid4 = "";
                strSql = " select top(1) RowGuid from RG_RenShiInfo where DWGuid='" + DWGuid + "' order by row_id desc ";
                RowGuid4 = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                ifRS.Attributes["src"] = "../../Pages_RG/RG_RenShi/RG_RenShiInfo_Detail.aspx?RowGuid=" + RowGuid4 + "&DWGuid=" + DWGuid;
                #endregion

                //if (Request["sType"] == "read")
                //{
                //    MultiTab.Tabs[5].Visible = false;
                //}
                //else
                //{
                #region ifDQ
                ifDQ.Attributes["src"] = "../../Pages_RG/RG_DingQi/RG_DingQi_List.aspx?DWGuid=" + DWGuid + "&sType=" + Request["sType"] ;
                #endregion
                //}

                #region 趋势分析
                ifCWFX.Attributes["src"] = "../../Pages_RG/RG_CaiWu/RG_YueDuCaiWu_FenXi.aspx?DWGuid=" + DWGuid;
                #endregion
            }

        }

        override protected void OnInit(EventArgs e)
        {
            oDetailPage = new Epoint.MisBizLogic2.Web.DetailPage(TableID);
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, null);//如果没有导出Excel的Grid，就设置为null
            oListPage.CustomMode = true;
            oListPage2 = new Epoint.MisBizLogic2.Web.ListPage(GGTableID, Datagrid2, null, Pager2, null);//如果没有导出Excel的Grid，就设置为null
            oListPage2.CustomMode = true;
            base.OnInit(e);
        }

        #region 列表
        private void RefreshGrid()
        {
            string strSql = " select top(1) RowGuid from rg_ouinfo where DWGuid='" + Request["UserGuid"] + "' order by row_id desc ";

            string RowGuid = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            string str = "";

            str += " and DWGuid='" + Request["DWGuid"] + "' and IsHistory='1' ";
            str += " and RowGuid<>'" + RowGuid + "' ";
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

        #region 高管信息
        private void RefreshGrid2()
        {
            oListPage2.OtherCondition = " and DWGuid='" + Request["DWGuid"] + "' ";//and PGuid='" + Request["RowGuid"] + "' ";
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

