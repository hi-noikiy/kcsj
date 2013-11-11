using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.Web.UI.WebControls2X;

namespace EpointRegisterUser.Group
{
    public partial class DataGroup_LeftTree : Epoint.Frame.Bizlogic.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TreeView1.ImgFolds = "../../Images/TreeImages";
                TreeView1.Target = "FrameRight";

                TreeView1.RootNodeText = "业务数据归档";

                TreeView1.RootNodeUrl = "DataGroup_List.aspx?ParentGuid=";
                AddTopNodes();
            }
        }

        private void AddTopNodes()
        {
            string sqlstr = "select * from RG_DataGroup where ParentGuid=''";
            sqlstr += " order by OrderNum desc";
            DataView dvMo = Epoint.MisBizLogic2.DB.ExecuteDataView(sqlstr);
            EpointTreeNode node;
            for (int i = 0; i < dvMo.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dvMo[i]["GroupName"].ToString();
                node.Value = dvMo[i]["RowGuid"].ToString();
                if (IsLeaf(node))
                    node.PopulateOnDemand = false;
                else
                    node.PopulateOnDemand = true;
                node.NavigateUrl = "DataGroup_List.aspx?ParentGuid=" + node.Value;
                TreeView1.Nodes.Add(node);

            }
        }

        protected void TreeView1_TreeNodePopulate1(object sender, EpointTreeNodeEventArgs e)
        {
            EpointTreeNode pNode = e.Node;
            DataView dvMo = SelectSecond(pNode.Value);
            EpointTreeNode node;
            for (int i = 0; i < dvMo.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dvMo[i]["GroupName"].ToString();
                node.Value = dvMo[i]["RowGuid"].ToString();
                if (IsLeaf(node))
                    node.PopulateOnDemand = false;
                else
                    node.PopulateOnDemand = true;
                node.NavigateUrl = "DataGroup_List.aspx?ParentGuid=" + node.Value;

                pNode.ChildNodes.Add(node);
            }
        }

        public DataView SelectSecond(string ParentGuid)
        {
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select * from RG_DataGroup where ParentGuid='" + ParentGuid + "' order by OrderNum desc");
            return dv;
        }

        public Boolean IsLeaf(EpointTreeNode node)
        {
            return Epoint.MisBizLogic2.DB.ExecuteToInt("select count(*) from RG_DataGroup where ParentGuid='" + node.Value + "'") == 0;
        }
    }
}
