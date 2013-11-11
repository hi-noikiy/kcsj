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

namespace EpointRegisterUser.Pages_RG.RG_DongTai
{

    public partial class RG_DongTai_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2019;

        Epoint.MisBizLogic2.Web.DetailPage oDetailPage;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        public int ZLTableID = 2026;
        Epoint.MisBizLogic2.Web.ListPage oListPage2;
        EpointRegisterUser_Bizlogic.DongTai DT = new EpointRegisterUser_Bizlogic.DongTai();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string RowGuid = Request["RowGuid"];
                string DWGuid = Request["DWGuid"];

                ViewState["TableName"] = oDetailPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);

                if (!oRow.R_HasFilled)
                {
                    //lblMessage.Visible=true;
                    //this.AlertAjaxMessage("没有对应的数据记录！");
                    //this.WriteAjaxMessage("window.close();");
                    return;
                }
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_DetailPage(oDetailPage, tdContainer, oRow);

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
            }

        }

        override protected void OnInit(EventArgs e)
        {
            oDetailPage = new Epoint.MisBizLogic2.Web.DetailPage(TableID);
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, null);//如果没有导出Excel的Grid，就设置为null
            oListPage.CustomMode = true;
            oListPage2 = new Epoint.MisBizLogic2.Web.ListPage(ZLTableID, Datagrid2, null, Pager2, null);//如果没有导出Excel的Grid，就设置为null
            oListPage2.CustomMode = true;
            base.OnInit(e);
        }

        #region 列表
        private void RefreshGrid()
        {
            string str = "";

            str += " and DWGuid='" + Request["DWGuid"] + "'  ";
            str += " and RowGuid<>'" + Request["RowGuid"] + "' ";
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

        protected void BindGongSi()
        {
            DataView dv = DT.GetRongYuList(Request["DWGuid"].ToString(), "0");
            grdGongSi.DataSource = dv;
            grdGongSi.DataBind();
            grdGongSi.ShowFooter = true;
        }

        protected void BindTuanDui()
        {
            DataView dv = DT.GetRongYuList(Request["DWGuid"].ToString(), "1");
            grdTuanDui.DataSource = dv;
            grdTuanDui.DataBind();
            grdTuanDui.ShowFooter = true;
        }

        protected void BindBuTie()
        {
            DataView dvBT = DT.GetBTDV(Request["DWGuid"].ToString());
            grdBuTie.DataSource = dvBT;
            grdBuTie.DataBind();
            grdBuTie.ShowFooter = true;
        }

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

