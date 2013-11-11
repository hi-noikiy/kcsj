using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Epoint.RegisterUser.Bizlogic.Consult;

namespace EpointRegisterUser.Consult.ConsultBoxMana
{
    public partial class ConsultBoxMana : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster 
    {
        protected DataView dvGroup;
        Db_ConsultBoxMana BoxGroup = new Db_ConsultBoxMana();
        Db_ConsultBoxMana Box = new Db_ConsultBoxMana();

        string mGroupID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["BoxGroupID"] != null && Request.QueryString["BoxGroupID"].ToString() != "")
                mGroupID = Request.QueryString["BoxGroupID"].ToString();


            if (!Page.IsPostBack)
            {
                this.CurrentPosition = "信箱管理";
                this.CurrentTitle = "信箱管理";
                this.bindGrid();
            }
        }

        public void bindGrid()
        {
            dvGroup = BoxGroup.BoxGroupSelectAll();
            DataView myDt = Box.BoxSelectAll();
            if(mGroupID!="")
                myDt = Box.BoxSelectByBoxGroupID(mGroupID);
            DgrBox.DataSource = myDt;
            DgrBox.DataBind();
        }

        public string GetGroupName(object BoxGuid)
        {
            string BoxGroupID = BoxGroup.GetDetail(BoxGuid.ToString()).BoxGroupID;
            return BoxGroup.BoxGroupGetDetail(BoxGroupID).BoxGroupName;
        }

        protected void BoxGuid_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
            {
                e.Item.Cells[0].Text = "<p align=center>" + Convert.ToString(e.Item.ItemIndex + 1) + "</p>";
            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            CheckBox chkdel;
            for (int i = 0; i < DgrBox.Items.Count; i++)
            {
                chkdel = (CheckBox)DgrBox.Items[i].FindControl("chksel");
                if (chkdel.Checked)
                {
                    Box.BoxDelete(DgrBox.DataKeys[i].ToString());
                }
            }
            bindGrid();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int DefaultHandleDays = Convert.ToInt32(new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("ConsultHandleDateSpan").ConfigValue);
            TextBox txtOrder,txtHandleDays;
            for (int i = 0; i < DgrBox.Items.Count; i++)
            {
                txtOrder = (TextBox)DgrBox.Items[i].FindControl("txtordernum");
                txtHandleDays = (TextBox)DgrBox.Items[i].FindControl("txtHandleDays");
                int OrderNum = 0;
                try
                {
                    OrderNum = Convert.ToInt32(txtOrder.Text);
                }
                catch { }

                int HandleDays = DefaultHandleDays;
                try
                {
                    HandleDays = Convert.ToInt32(txtHandleDays.Text);
                }
                catch { }
                Box.BoxUpdate(DgrBox.DataKeys[i].ToString(), OrderNum,HandleDays);
            }
            bindGrid();
        }
    }
}
