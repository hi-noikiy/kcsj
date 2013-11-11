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
using EpointRegisterUser_Bizlogic;

namespace EpointRegisterUser.Pages_RG.RG_OU
{

    public partial class RG_OU_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2017;
        public int GGTableID = 2023;	
        Epoint.MisBizLogic2.Web.DetailPage oDetailPage;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取该人员最近的一次企业信息记录
                string strSql = " select top(1) RowGuid from rg_ouinfo where DWGuid=(select distinct DanWeiGuid from RG_User where RowGuid='" + Session["UserGuid"].ToString() + "') order by row_id desc ";
                
                string RowGuid = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                lblRowGuid.Text = RowGuid;
                strSql = " select top(1) DWGuid from rg_ouinfo where DWGuid=(select distinct DanWeiGuid from RG_User where RowGuid='" + Session["UserGuid"].ToString() + "') order by row_id desc ";
                string DWGuid = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
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

                //根据状态和参数显示修改按钮
                if (Request["sType"] == "canedit")
                {
                    if (Status_2017.Text != OUStatus.待审核)
                    {
                        this.btnEdit.Visible = true;
                    }
                    
                }
                lblDWGuid.Text = DWGuid_2017.Text;
            }

        }

        override protected void OnInit(EventArgs e)
        {
            oDetailPage = new Epoint.MisBizLogic2.Web.DetailPage(TableID);
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(GGTableID, Datagrid1, null, Pager, null);//如果没有导出Excel的Grid，就设置为null
            oListPage.CustomMode = true;
            base.OnInit(e);
        }

        #region 高管信息
        private void RefreshGrid()
        {
            oListPage.OtherCondition = " and DWGuid='" + Request["DWGuid"] + "' ";//and PGuid='" + Request["RowGuid"] + "' ";
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



        protected void Datagrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            oListPage.PrepareForSortCommand(e.SortExpression);
            this.RefreshGrid();
        }

        protected void Datagrid1_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            oListPage.GenerateSerialNumColumn(e.Item);
        }
        #endregion
    }
}

