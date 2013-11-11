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

    public partial class RG_OU_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2017;

        Epoint.MisBizLogic2.Web.DetailPage oDetailPage;
        public int GGTableID = 2023;
        Epoint.MisBizLogic2.Web.ListPage oListPage2;
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

                RefreshGrid2();
            }

        }

        override protected void OnInit(EventArgs e)
        {
            oDetailPage = new Epoint.MisBizLogic2.Web.DetailPage(TableID);
            oListPage2 = new Epoint.MisBizLogic2.Web.ListPage(GGTableID, Datagrid2, null, Pager2, null);//如果没有导出Excel的Grid，就设置为null
            oListPage2.CustomMode = true;
            base.OnInit(e);
        }

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

