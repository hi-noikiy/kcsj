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
//using Epoint.WebbuilderInfo.Bizlogic;
using Epoint.Frame.Bizlogic.UserManage;
using Epoint.RegisterUser.Bizlogic;
using Epoint.RegisterUser.Bizlogic.Consult;

namespace EpointRegisterUser.Consult.ConsultBoxManage
{
    public partial class ConsultBoxListTree : Epoint.Frame.Bizlogic.BasePage
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
                TreeView1.RootNodeUrl = "ConsultBoxListMana.aspx";
                AddTopNodes();
            }
        }

        private void AddTopNodes()
        {
            EpointTreeNode node;

            DataView dv = mana.BoxSelectAll();//选择所有的邮箱
            //if (System.Configuration.ConfigurationManager.AppSettings["IfNeedXinFangJu"] != "true")
            //{//只选择具有权限的信箱
            //选择具有权限的信箱
            DataView dvRight = mana.SelectHandleUser();
            string FilterStr = "(HandleType='P' and HandleDetail='" + Session["UserGuid"].ToString() + "') ";
            string OuGuid = Session["OuGuid"].ToString();
            while (OuGuid != "")
            {
                FilterStr += " or (HandleType='D' and HandleDetail='" + OuGuid + "') ";
                OuGuid = dept.GetDetail(OuGuid).ParentOUGuid;
            }
            dvRight.RowFilter = FilterStr;

            //选择所有的组别
            DataView dvGroup = mana.BoxGroupSelectAll();

            for (int i = 0; i < dvGroup.Count; i++)
            {
                //有信箱才添加
                for (int j = 0; j < dvRight.Count; j++)//
                {
                    dv.RowFilter = "BoxGroupID='" + dvGroup[i]["BoxGroupID"] + "' and BoxGuid='" + dvRight[j]["BoxGuid"] + "'";//选出组下有权限的信箱
                    if (dv.Count > 0)
                    {
                        node = new EpointTreeNode();
                        node.Text = dvGroup[i]["BoxGroupName"].ToString();
                        node.Value = dvGroup[i]["BoxGroupID"].ToString();
                        if (i == 0)
                            node.Selected = true;
                        node.NavigateUrl = "ConsultBoxListMana.aspx?BoxGroupID=" + dvGroup[i]["BoxGroupID"];
                        node.PopulateOnDemand = true;
                        TreeView1.Nodes.Add(node);
                        break;
                    }
                }

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
                            node.NavigateUrl = "ConsultBoxListMana.aspx?BoxGuid=" + dv[i]["BoxGuid"];

                            EpointTreeNode node2 = new EpointTreeNode();
                            node2.Text = "未处理";
                            node2.Value = "未处理";
                            node2.PopulateOnDemand = false;
                            node2.NavigateUrl = "ConsultBoxListMana.aspx?BoxGuid=" + dv[i]["BoxGuid"] + "&jpdProcesstype=0";
                            node.ChildNodes.Add(node2);
                            node2 = new EpointTreeNode();
                            node2.Text = "已处理";
                            node2.Value = "已处理";
                            node2.PopulateOnDemand = false;
                            node2.NavigateUrl = "ConsultBoxListMana.aspx?BoxGuid=" + dv[i]["BoxGuid"] + "&jpdProcesstype=1";
                            node.ChildNodes.Add(node2);

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
