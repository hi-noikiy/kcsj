using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.Web.UI.WebControls2X;

namespace EpointRegisterUser.Pages.RG_Matters
{
    public partial class Matter_LeftTree : Epoint.Frame.Bizlogic.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                TreeView1.ImgFolds = "../../../Images/TreeImages";
                TreeView1.Target = "FrameRight";
                TreeView1.RootNodeText = "所有事项";
                TreeView1.RootNodeUrl = "Matter_List.aspx?ParentGuid=";
                AddTopNodes();
            }
        }

        private void AddTopNodes()
        {
            DataView dvMo = Epoint.MisBizLogic2.DB.ExecuteDataView("select * from RG_Matters where ParentGuid='' Order By OrderNum Desc");
            EpointTreeNode node;
            for (int i = 0; i < dvMo.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dvMo[i]["MatterName"].ToString();
                node.Value = dvMo[i]["RowGuid"].ToString();
                //if (!Convert.ToBoolean(dvGroup[i]["IsLeaf"]))
                if (IsLeaf(node))
                    node.PopulateOnDemand = false;
                else
                 
                    node.PopulateOnDemand = true;
                    node.NavigateUrl = "Matter_List.aspx?ParentGuid=" + node.Value;
                 
                TreeView1.Nodes.Add(node);
            }
        }

        protected void TreeView1_TreeNodePopulate1(object sender, EpointTreeNodeEventArgs e)
        {
            EpointTreeNode pNode = e.Node;
            DataView dvMa = null;
            EpointTreeNode node;
            //Boolean IsApp = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(RowGuid) from RG_Application where RowGuid='" + pNode.Value + "'") == 1;//节点是否是子系统
            dvMa = NextFloor(pNode.Value);
            for (int i = 0; i < dvMa.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dvMa[i]["MatterName"].ToString();
                node.Value = dvMa[i]["RowGuid"].ToString();

                if (IsLeaf(node))
                    node.PopulateOnDemand = false;
                else
                 
                    node.PopulateOnDemand = true;
                    node.NavigateUrl = "Matter_List.aspx?ParentGuid=" + node.Value;
                 
                pNode.ChildNodes.Add(node);
            }

        }

        public DataView NextFloor(string Guid)
        {
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select * from RG_Matters where ParentGuid='" + Guid + "' Order By OrderNum Desc");

            return dv;
        }

        //事项是否是叶节点
        public Boolean IsLeaf(EpointTreeNode node)
        {
            Boolean isleaf = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(RowGuid) from RG_Matters where ParentGuid='" + node.Value + "'") == 0;
            return isleaf;
        }
    }
}
