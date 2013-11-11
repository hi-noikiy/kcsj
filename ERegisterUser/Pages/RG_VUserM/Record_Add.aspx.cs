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
using Epoint.Web.UI.WebControls2X;
using Epoint.RegisterUser.DataSyn.Bizlogic;
namespace EpointRegisterUser.Pages.RG_VUserM
{

    public partial class Record_Add : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 100;

        Epoint.MisBizLogic2.Web.AddPage oAddPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oAddPage.TableDetail.TableName;
                #region 判断是否是辅表，如果是辅表，并且没有父表的RowID，自动转到相应的主表
                string ParentRowGuid = Request.QueryString["ParentRowGuid"];
                if (oAddPage.TableDetail.TableType == 2)
                {
                    if (ParentRowGuid == null || ParentRowGuid == "")
                    {
                        this.AlertAjaxMessage("禁止直接对子表添加记录！");
                        return;
                    }
                }
                #endregion
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
                //添加上传文件的大小和类型检查
                this.Add_FileUploadCheck_Script();
            }
        }


        override protected void OnInit(EventArgs e)
        {
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);
            base.OnInit(e);
        }


        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            string RowGuid = Guid.NewGuid().ToString();
            oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);
            new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_VUserM", "RowGuid", RowGuid);
            if (Request["type"] == "bieming")
                SaveRelation(RowGuid);
            //如果是父表，要转入多表编辑页面
            if (oAddPage.TableDetail.TableType == 1)
            {
                Response.Redirect("MultiPageTab.aspx?mode=Mode&TableID=" + oAddPage.TableDetail.TableID + "&RowGuid=" + RowGuid);
            }
            Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
            this.WriteAjaxMessage("refreshParent();EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");
            this.WriteAjaxMessage("rtnValue(\"\");");
        }

        protected void SaveRelation(string VUserGuid)
        {
            string RowGuid = Guid.NewGuid().ToString();
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_VUser");
            oRow["RowGuid"] = RowGuid;
            oRow["VUserGuid"] = VUserGuid;
            oRow["MapGuid"] = Session["UserGuid"];
            oRow["MapType"] = "User";
            oRow.Insert();
            new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_VUser", "RowGuid", RowGuid);
        }
    }
}


