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
    public partial class Matter_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 131;
        Epoint.MisBizLogic2.Web.EditPage oEditPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                if (!oRow.R_HasFilled)
                {
                    btnEdit.Visible = false;
                    this.AlertAjaxMessage("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
                BindApp(oRow["AppGuid"].ToString());
                Content.Text = oRow["Instruction"].ToString();
                //添加上传文件的大小和类型检查
                this.Add_FileUploadCheck_Script();
                if (Epoint.MisBizLogic2.DB.ExecuteToString("select ParentGuid from RG_Matters where RowGuid='" + oRow["RowGuid"].ToString() + "'") == "")
                {
                    trIsHangPage.Style["display"] = "";
                    trInstr.Style["display"] = "none";
                }
                else
                {
                    trIsHangPage.Style["display"] = "none";
                    trInstr.Style["display"] = "";
                }
                if (oRow["IsDefault"].ToString() == "0")
                    MatterNameSel.Style["display"] = "none";
                else
                {
                    MatterNameSel.Style["display"] = "";
                    BindMatterName();
                    dplMatterName.SelectedIndex = dplMatterName.Items.IndexOf(dplMatterName.Items.FindByValue(oRow["UniqueID"].ToString()));
                }
            }
        }


        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            base.OnInit(e);
        }

        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (IsDefault_131.SelectedValue == "1")
                UniqueID_131.Text = dplMatterName.SelectedValue;
            else
                UniqueID_131.Text = "";
            if (OrderNum_131.Text == "")
                OrderNum_131.Text = "-1";
            Instruction_131.Text = Content.Text;
            AppGuid_131.Text = App.SelectedValue;
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_Matters", "RowGuid", Request["RowGuid"]);
            //string IsHoldCurPage = Epoint.Frame.Bizlogic.Frame_Config.GetConfigValue("IsHoldCurPage", "0");
            //if (IsHoldCurPage == "1")
            //    this.WriteAjaxMessage("refreshParentHoldCurPage();");
            //else
            this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");
        }

        protected void BindApp(string AppGuid)
        {
            DataView appdv = Epoint.MisBizLogic2.DB.ExecuteDataView("select AppName,AppGuid from RG_Application order by OrderNum desc");
            App.Items.Add(new ListItem("", ""));
            foreach (DataRowView row in appdv)
            {
                App.Items.Add(new ListItem(row["AppName"].ToString(), row["AppGuid"].ToString()));
            }
            App.SelectedIndex = App.Items.IndexOf(App.Items.FindByValue("" + AppGuid + ""));
        }

        protected void statusSel_Changed(object sender, EventArgs e)
        {
            if (IsDefault_131.SelectedValue == "0")
                MatterNameSel.Style["display"] = "none";
            else
            {
                MatterNameSel.Style["display"] = "";
                BindMatterName();
            }
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
