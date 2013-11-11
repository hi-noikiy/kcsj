using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.Web.UI.WebControls2X;


namespace EpointRegisterUser.Pages.RG_Module
{
    public partial class Record_LeftTree : Epoint.Frame.Bizlogic.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                TreeView1.ImgFolds = "../../../Images/TreeImages";
                TreeView1.Target = "FrameRight";
                TreeView1.RootNodeText = "所有模块";
                TreeView1.RootNodeUrl = "Record_List.aspx?ParentGuid=&IsBelongtoApp=0";
                AddTopNodes();
            }
        }

        private void AddTopNodes()
        {
            string sqlstr = "select * from RG_Module";

            sqlstr += " where ParentGuid ='' and IsBelongtoApp=0";
            sqlstr += " Order By OrderNum Desc";
            DataView dvMo = Epoint.MisBizLogic2.DB.ExecuteDataView(sqlstr);
            EpointTreeNode node;
            if (dvMo.Count == 0)
                return;
            else
                for (int i = 0; i < dvMo.Count; i++)
                {
                    node = new EpointTreeNode();
                    node.Text = dvMo[i]["ModuleName"].ToString();
                    node.Value = dvMo[i]["RowGuid"].ToString();
                    //if (!Convert.ToBoolean(dvGroup[i]["IsLeaf"]))
                    if (IsLeaf(node))
                        node.PopulateOnDemand = false;
                    else

                        node.PopulateOnDemand = true;
                    node.NavigateUrl = "Record_List.aspx?IsBelongtoApp=0&ParentGuid=" + node.Value;

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
                node.Text = dvMo[i]["ModuleName"].ToString();
                node.Value = dvMo[i]["RowGuid"].ToString();
                //if (!Convert.ToBoolean(Dv_Category[i]["IsLeaf"]))
                if (IsLeaf(node))
                    node.PopulateOnDemand = false;
                else

                    node.PopulateOnDemand = true;
                node.NavigateUrl = "Record_List.aspx?IsBelongtoApp=0&ParentGuid=" + node.Value;

                pNode.ChildNodes.Add(node);
            }
        }
        public DataView SelectSecond(string Guid)
        {
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select * from RG_Module where ParentGuid='" + Guid + "'  Order By OrderNum Desc");
            return dv;
        }
        public Boolean IsLeaf(EpointTreeNode node)
        {
            Boolean isleaf = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(ParentGuid) from RG_Module where ParentGuid='" + node.Value + "'") == 0;
            return isleaf;
        }
    }
}
