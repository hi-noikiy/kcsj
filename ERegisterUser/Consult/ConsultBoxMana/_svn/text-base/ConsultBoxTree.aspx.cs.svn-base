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
using Epoint.Web.UI.WebControls2X;
using System.IO;
using Epoint.Frame.Bizlogic.UserManage;
using Epoint.RegisterUser.Bizlogic.Consult;

namespace EpointRegisterUser.Consult.ConsultBoxMana
{
    public partial class ConsultBoxTree : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster 
    {
        OU dept = new OU();
        Db_ConsultBoxMana mana = new Db_ConsultBoxMana();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TreeView1.ImgFolds = Request.ApplicationPath + "/Images/TreeImages";
                TreeView1.Target = "main1";
                TreeView1.RootNodeText = "信箱列表";
                TreeView1.RootNodeUrl = "ConsultBoxMana.aspx";
                AddTopNodes();
            }
        }

        private void AddTopNodes()
        {
            EpointTreeNode node;
            //选择所有的组别
            DataView dvGroup = mana.BoxGroupSelectAll();
            for (int i = 0; i < dvGroup.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dvGroup[i]["BoxGroupName"].ToString();
                node.Value = dvGroup[i]["BoxGroupID"].ToString();
                if (i == 0)
                    node.Selected = true;
                node.NavigateUrl = "ConsultBoxMana.aspx?BoxGroupID=" + dvGroup[i]["BoxGroupID"];
                node.PopulateOnDemand = false;
                TreeView1.Nodes.Add(node);
            }
        }

        protected void TreeView1_TreeNodePopulate1(object sender, EpointTreeNodeEventArgs e)
        {
            try
            {

                EpointTreeNode pNode = e.Node;
                DataView dv = mana.BoxSelectByBoxGroupID(pNode.Value);//选择组别下所有的邮箱
                DataView dvRight = mana.SelectHandleUser();//选择权限
                string FilterStr = "(HandleType='P' and HandleDetail='" + Session["UserGuid"].ToString() + "') ";
                string OuGuid = Session["OuGuid"].ToString();
                while (OuGuid != "")
                {
                    FilterStr += " or (HandleType='D' and HandleDetail='" + OuGuid + "') ";
                    OuGuid = dept.GetDetail(OuGuid).ParentOUGuid;
                }
                dvRight.RowFilter = FilterStr;
                EpointTreeNode node;
                for (int i = 0; i < dv.Count; i++)
                {
                    for (int j = 0; j < dvRight.Count; j++)
                    {
                        if (dvRight[j]["BoxGuid"].ToString() == dv[i]["BoxGuid"].ToString())
                        {
                            node = new EpointTreeNode();
                            node.Text = dv[i]["BoxName"].ToString();
                            node.Value = dv[i]["BoxGuid"].ToString();
                            node.PopulateOnDemand = false;
                            node.NavigateUrl = "ConsultBoxMana.aspx?BoxGuid=" + dv[i]["BoxGuid"];

                            pNode.ChildNodes.Add(node);
                            break;
                        }
                    }
                }

            }
            catch (Exception er)
            {
                Epoint.Common.Log.WriteLog(er.ToString());
            }
        }
    }
}
