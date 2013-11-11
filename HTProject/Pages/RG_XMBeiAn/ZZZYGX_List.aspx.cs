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

namespace HTProject.Pages.RG_XMBeiAn
{

    public partial class ZZZYGX_List : BaseContentPage_UsingMaster
    {
        // Fields
        private DB_Frame_Code_Item CodeItem = new DB_Frame_Code_Item();
        protected HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        // Methods
        private void bindGrid()
        {
            DataView view = RG_DW.GetZYbyZZ(Request["ItemCode"]);// this.CodeItem.SelectNextOneLevel(this.Session["MainGuid"].ToString(), base.Request.Params["ItemCode"], out canSelect);
            this.grdList.DataSource = view;
            this.grdList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string RowGuid = "";
            string strSql = "update RG_XMAndZY set NeedRY='{2}' where zizhicode='{0}' and ZhuanYeCode='{1}'";
            for (int i = 0; i < this.grdList.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)this.grdList.Items[i].FindControl("chkAddNP");
                TextBox box4 = (TextBox)this.grdList.Items[i].FindControl("tOrderNumber");
                string needp = cb.Checked ? "1" : "0";
                RowGuid = this.grdList.DataKeys[i].ToString();
                RG_DW.UpdateZZZYGX(RowGuid, Functions.IntNull(box4.Text), needp);
                //DB_Frame_OperationLog.Insert(DB_Frame_OperationLog.LOG_OPERATOR_TYPE_MODIFY, DB_Frame_OperationLog.LOG_SUBSYSTEM_TYPE_Frame, this.Session["UserGuid"].ToString(), this.Session["DisplayName"].ToString(), "修改代码项。代码类别名称：" + this.lblCodeName.Text + "；新代码项名称：" + box.Text + "；新代码值名称：" + box2.Text + "；代码项ItemGuid：" + itemGuid, "", this.Session["BaseOUGuid"].ToString());
                try
                {
                    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_ZiZhiZhuanYe", RowGuid);
                    Epoint.MisBizLogic2.DB.ExecuteNonQuery(string.Format(strSql, oRow["zizhicode"], oRow["ZhuanYeCode"], needp));
                }
                catch (Exception ex)
                { }
            }
            AlertAjaxMessage("保存成功");
            this.bindGrid();
            
        }

        protected void grdList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            Button commandSource = (Button)e.CommandSource;
            string itemCode = Convert.ToString(e.CommandArgument);
            if (commandSource.CommandName.ToLower() == "del")
            {
                RG_DW.DeleteZZZYGX(itemCode);
                //Detail_Frame_Code_Item item = this.CodeItem.GetDetail_ItemCode(this.Session["MainGuid"].ToString(), itemCode);
                //DB_Frame_OperationLog.Insert(DB_Frame_OperationLog.LOG_OPERATOR_TYPE_MODIFY, DB_Frame_OperationLog.LOG_SUBSYSTEM_TYPE_Frame, this.Session["UserGuid"].ToString(), this.Session["DisplayName"].ToString(), "删除代码项。代码类别名称：" + this.lblCodeName.Text + "；代码项名称：" + item.ItemText + "；代码值名称：" + item.ItemValue + "；代码项ItemGuid：" + item.ItemGuid, "", this.Session["BaseOUGuid"].ToString());
            }
            this.bindGrid();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                base.CurrentPosition = "部门管理";
                //string str = base.Request.Params["ItemCode"];
                //this.lblCodeName.Text = new DB_Frame_Code_Main().GetDetail(this.Session["MainGuid"].ToString()).CodeName;
                this.bindGrid();
            }
        }
    }



}


