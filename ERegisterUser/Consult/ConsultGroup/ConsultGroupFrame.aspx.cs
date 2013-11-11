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

namespace EpointRegisterUser.Consult.ConsultGroup
{
    public partial class ConsultGroupFrame : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Db_ConsultBoxMana BoxGroup = new Db_ConsultBoxMana();
        //Common common = new Common();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.CurrentPosition = "组别管理";
                this.CurrentTitle = "组别管理";
                this.bindGrid();
            }
        }

        public void bindGrid()
        {
            DataView myDt=BoxGroup.BoxGroupSelectAll();
            DgrBoxGroup.DataSource = myDt;
            DgrBoxGroup.DataBind();
        }

        protected void DgrBoxGroup_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
            {
                e.Item.Cells[0].Text = "<p align=center>" + Convert.ToString(e.Item.ItemIndex + 1) + "</p>";
            }
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            CheckBox chkdel;
            for (int i = 0; i < DgrBoxGroup.Items.Count; i++)
            {
                chkdel = (CheckBox)DgrBoxGroup.Items[i].FindControl("chksel");
                if (chkdel.Checked)
                {
                   BoxGroup.BoxGroupDelete(DgrBoxGroup.DataKeys[i].ToString());
                }
            }
            bindGrid();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            TextBox txtOrder;
            Epoint.Web.UI.WebControls2X.TextBox GroupName;
            for (int i = 0; i < DgrBoxGroup.Items.Count; i++)
            {
                txtOrder = (TextBox)DgrBoxGroup.Items[i].FindControl("txtordernum");
                GroupName = (Epoint.Web.UI.WebControls2X.TextBox)DgrBoxGroup.Items[i].FindControl("txtGroupName");
                int OrderNum = 0;
                try
                {
                    OrderNum = Convert.ToInt32(txtOrder.Text);
                }
                catch { }
                if(GroupName.Text!="")
                    BoxGroup.BoxGroupUpdate(DgrBoxGroup.DataKeys[i].ToString(),GroupName.Text, OrderNum);
            }
            bindGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                string newguid = Guid.NewGuid().ToString();
                BoxGroup.BoxGroupInsert(newguid, txtName.Text, 0);
                bindGrid();
            }
        }
    }
}
