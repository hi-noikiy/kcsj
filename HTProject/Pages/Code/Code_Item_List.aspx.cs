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
using Epoint.Frame.Bizlogic;
using Epoint.Frame.Bizlogic.Code;
using Epoint.Frame.Bizlogic.OperationLog;
using Epoint.Common;
using HTProject_Bizlogic;

namespace HTProject.Pages.Code
{

    public partial class Code_Item_List : BaseContentPage_UsingMaster
    {
        private DB_Frame_Code_Item CodeItem = new DB_Frame_Code_Item();
        private void bindGrid()
        {
            bool canSelect = false;
            DataView view = this.CodeItem.SelectNextOneLevel(this.Session["MainGuid"].ToString(), Request["ItemCode"], out canSelect);
            this.grdList.DataSource = view;
            this.grdList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string itemGuid = "";
            for (int i = 0; i < this.grdList.Items.Count; i++)
            {
                TextBox box = (TextBox)this.grdList.Items[i].FindControl("tItemText");
                TextBox box2 = (TextBox)this.grdList.Items[i].FindControl("tItemValue");
                TextBox box3 = (TextBox)this.grdList.Items[i].FindControl("tPinYinJc");
                TextBox box4 = (TextBox)this.grdList.Items[i].FindControl("tOrderNumber");
                itemGuid = this.grdList.DataKeys[i].ToString();
                this.CodeItem.Update(itemGuid, box.Text, box2.Text, box3.Text, Functions.IntNull(box4.Text));
                DB_Frame_OperationLog.Insert(DB_Frame_OperationLog.LOG_OPERATOR_TYPE_MODIFY, DB_Frame_OperationLog.LOG_SUBSYSTEM_TYPE_Frame, this.Session["UserGuid"].ToString(), this.Session["DisplayName"].ToString(), "修改代码项。代码类别名称：" + this.lblCodeName.Text + "；新代码项名称：" + box.Text + "；新代码值名称：" + box2.Text + "；代码项ItemGuid：" + itemGuid, "", this.Session["BaseOUGuid"].ToString());
            }
            this.bindGrid();
        }

        protected void grdList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            Button commandSource = (Button)e.CommandSource;
            string itemCode = Convert.ToString(e.CommandArgument);
            if (commandSource.CommandName.ToLower() == "del")
            {
                this.CodeItem.Delete(this.Session["MainGuid"].ToString(), itemCode);
                Detail_Frame_Code_Item item = this.CodeItem.GetDetail_ItemCode(this.Session["MainGuid"].ToString(), itemCode);
                DB_Frame_OperationLog.Insert(DB_Frame_OperationLog.LOG_OPERATOR_TYPE_MODIFY, DB_Frame_OperationLog.LOG_SUBSYSTEM_TYPE_Frame, this.Session["UserGuid"].ToString(), this.Session["DisplayName"].ToString(), "删除代码项。代码类别名称：" + this.lblCodeName.Text + "；代码项名称：" + item.ItemText + "；代码值名称：" + item.ItemValue + "；代码项ItemGuid：" + item.ItemGuid, "", this.Session["BaseOUGuid"].ToString());
            }
            this.bindGrid();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                base.CurrentPosition = "部门管理";
                string str = base.Request.Params["ItemCode"];
                this.lblCodeName.Text = new DB_Frame_Code_Main().GetDetail(this.Session["MainGuid"].ToString()).CodeName;
                this.bindGrid();
            }
        }

    }
}