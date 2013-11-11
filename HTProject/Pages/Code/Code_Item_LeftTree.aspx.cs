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
using Epoint.Web.UI.WebControls2X;

namespace HTProject.Pages.Code
{

    public partial class Code_Item_LeftTree : BasePage
    {
        // Fields
        private DB_Frame_Code_Item CodeItem = new DB_Frame_Code_Item();

        // Methods
        private void AddTopNodes()
        {
            bool canSelect = false;
            DataView view = this.CodeItem.SelectNextOneLevel(this.ViewState["MainGuid"].ToString(), Request["ItemCode"], out canSelect);
            if (!String.IsNullOrEmpty(Request["LEN"]))
            {
                view.RowFilter = "  Len(ItemCode)=4 ";
            }
            for (int i = 0; i < view.Count; i++)
            {
                EpointTreeNode child = new EpointTreeNode
                {
                    Text = view[i]["ItemText"].ToString(),
                    Value = view[i]["ItemValue"].ToString()
                };
                DataView dvZC = CodeItem.SelectNextOneLevel(this.ViewState["MainGuid"].ToString(), view[i]["ItemCode"].ToString(), out canSelect);
                if (!String.IsNullOrEmpty(Request["LEN"]))
                {
                    dvZC.RowFilter = "  Len(ItemCode)=4 ";
                }
                if (dvZC.Count > 0)
                {
                    child.PopulateOnDemand = true;
                }
                child.NavigateUrl = "Code_Item_List.aspx?ItemCode=" + view[i]["ItemCode"].ToString() + "&MainGuid=" + this.ViewState["MainGuid"].ToString();
                this.TreeView1.Nodes.Add(child);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.ViewState["MainGuid"] = Request["MainGuid"];
                //this.TreeView1.ImgFolds = "../../Images/TreeImages";
                //this.TreeView1.Target = "main1";
                //this.TreeView1.RootNodeText = "所有代码项";
                this.AddTopNodes();
            }
        }

        protected void TreeView1_TreeNodePopulate1(object sender, EpointTreeNodeEventArgs e)
        {
            bool canSelect = false;
            EpointTreeNode node = e.Node;
            string itemCode = this.CodeItem.GetDetail_ItemValue(this.ViewState["MainGuid"].ToString(), node.Value).ItemCode;
            DataView view = this.CodeItem.SelectNextOneLevel(this.ViewState["MainGuid"].ToString(), itemCode, out canSelect);
            for (int i = 0; i < view.Count; i++)
            {
                EpointTreeNode child = new EpointTreeNode
                {
                    Text = view[i]["ItemText"].ToString(),
                    Value = view[i]["ItemValue"].ToString()
                };
                if (this.CodeItem.SelectNextOneLevel(this.ViewState["MainGuid"].ToString(), view[i]["ItemCode"].ToString(), out canSelect).Count > 0)
                {
                    child.PopulateOnDemand = true;
                }
                child.NavigateUrl = "Code_Item_List.aspx?ItemCode=" + view[i]["ItemCode"].ToString() + "&MainGuid=" + this.ViewState["MainGuid"].ToString();
                node.ChildNodes.Add(child);
            }
        }
    }




}


