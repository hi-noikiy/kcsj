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
namespace EpointRegisterUser.Pages.RG_Matters
{
    public partial class Matter_Add : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 131;
        Epoint.MisBizLogic2.Web.AddPage oAddPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindApp();
                BindMatterName();
                MatterNameSel.Style["display"] = "none";
                if (Request["ParentGuid"] == "")
                {
                    trIsHangPage.Style["display"] = "";
                    trInstr.Style["display"] = "none";
                }
                else
                {
                    trIsHangPage.Style["display"] = "none";
                    trInstr.Style["display"] = "";
                }
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
            string parentguid = Request["ParentGuid"];
            if (string.IsNullOrEmpty(Request["ParentGuid"]) && string.IsNullOrEmpty(Request["AppGuid"]))
                parentguid = "";
            string RowGuid = Guid.NewGuid().ToString();
            if (IsDefault_131.SelectedValue == "1")
                UniqueID_131.Text = dplMatterName.SelectedValue;
            else
                UniqueID_131.Text = "";
            AppGuid_131.Text = App.SelectedValue;
            if (OrderNum_131.Text == "")
                OrderNum_131.Text = "-1";
            Instruction_131.Text = Content.Text;
            ParentGuid_131.Text = parentguid;
            oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);
            new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_Matters", "RowGuid", RowGuid);

            this.WriteAjaxMessage("refreshParent();EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");
        }

        protected void BindApp()
        {
            DataView appdv = Epoint.MisBizLogic2.DB.ExecuteDataView("select AppName,AppGuid from RG_Application order by OrderNum desc");

            App.Items.Add(new ListItem("", ""));
            foreach (DataRowView row in appdv)
            {
                App.Items.Add(new ListItem(row["AppName"].ToString(), row["AppGuid"].ToString()));
            }
        }

        protected void statusSel_Changed(object sender, EventArgs e)
        {
            if (IsDefault_131.SelectedValue == "0")
                MatterNameSel.Style["display"] = "none";
            else
                MatterNameSel.Style["display"] = "";
        }

        protected void BindMatterName()
        {
            DataView dvDefaultMatter = new Epoint.MisBizLogic2.Code.DB_CodeItem().Get_Items_By_CodeName("RG_默认事项");
            dplMatterName.DataSource = dvDefaultMatter;
            dplMatterName.DataTextField = "ItemText";
            dplMatterName.DataValueField = "ItemValue";
            dplMatterName.DataBind();
        }
    }
}


