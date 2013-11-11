using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.Web.UI.WebControls2X;

namespace EpointRegisterUser.Pages.RG_Application
{
    public partial class RG_Application_LeftTree : Epoint.Frame.Bizlogic.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                TreeView1.ImgFolds = "../../../Images/TreeImages";
                TreeView1.Target = "FrameRight";
                TreeView1.RootNodeText = "应用子系统及其模块";
                TreeView1.RootNodeUrl = "../RG_Module/Record_List.aspx?IsBelongtoApp=1&ParentGuid=&AppGuid=all";
                AddTopNodes();
            }
        }

        private void AddTopNodes()
        {
            DataView dvMo = Epoint.MisBizLogic2.DB.ExecuteDataView("select * from RG_Application where UserGuid='" + Session["UserGuid"].ToString() + "' Order By OrderNum Desc");
            EpointTreeNode node;
            for (int i = 0; i < dvMo.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dvMo[i]["AppName"].ToString();
                node.Value = dvMo[i]["RowGuid"].ToString();
                //if (!Convert.ToBoolean(dvGroup[i]["IsLeaf"]))
                if (IsLeaf(node))
                    node.PopulateOnDemand = false;
                else
                 
                    node.PopulateOnDemand = true;
                node.NavigateUrl = "../RG_Module/Record_List.aspx?IsBelongtoApp=1&ParentGuid=&AppGuid=" + node.Value;
                 
                TreeView1.Nodes.Add(node);
            }
        }

        protected void TreeView1_TreeNodePopulate1(object sender, EpointTreeNodeEventArgs e)
        {
            EpointTreeNode pNode = e.Node;
            Boolean IsApp = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(RowGuid) from RG_Application where RowGuid='" + pNode.Value + "'") == 1;//pNode是否子系统
            DataView dvMo = NextFloor(pNode.Value, IsApp);
            EpointTreeNode node;

            for (int i = 0; i < dvMo.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dvMo[i]["ModuleName"].ToString();
                node.Value = dvMo[i]["RowGuid"].ToString();

                if (IsLeafextra(node))
                    node.PopulateOnDemand = false;
                else
                 
                    node.PopulateOnDemand = true;
                    node.NavigateUrl = "../RG_Module/Record_List.aspx?IsBelongtoApp=1&ParentGuid=" + node.Value + "&AppGuid=" + dvMo[i]["AppGuid"].ToString();
                 
                pNode.ChildNodes.Add(node);
            }
        }

        public DataView NextFloor(string Guid, Boolean IsApp)
        {
            if (IsApp)
            {
                DataView dv1 = Epoint.MisBizLogic2.DB.ExecuteDataView("select ModuleName,RowGuid,AppGuid from RG_Module where ParentGuid=''and AppGuid='" + Guid + "'and IsBelongtoApp=1");
                return dv1;
            }
            else
            {
                DataView dv2 = Epoint.MisBizLogic2.DB.ExecuteDataView("select ModuleName,RowGuid,AppGuid from RG_Module where ParentGuid='" + Guid + "' and IsBelongtoApp=1 Order By OrderNum Desc");
                return dv2;
            }
        }

        //子系统是否是叶子节点
        public Boolean IsLeaf(EpointTreeNode node)
        {
            Boolean isleaf = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(RowGuid) from RG_Module where ParentGuid='' and AppGuid='" + node.Value + "'and IsBelongtoApp=1") == 0;
            return isleaf;
        }
        //模块是否是叶子节点
        public Boolean IsLeafextra(EpointTreeNode node)
        {
            Boolean isleaf = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(RowGuid) from RG_Module where ParentGuid='" + node.Value + "'") == 0;
            return isleaf;
        }
    }
}
