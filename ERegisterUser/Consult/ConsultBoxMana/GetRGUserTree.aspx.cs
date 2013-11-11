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
using Epoint.Frame.Bizlogic;
using Epoint.Frame.Bizlogic.UserManage;
using Epoint.Web.UI.WebControls2X;
using Epoint.RegisterUser.Bizlogic;

namespace EpointRegisterUser.Consult.ConsultBoxMana
{
    public partial class GetBGUserTree : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Frame_Config FC = new Frame_Config();

        OU ous = new OU();
        DB_Frame_Module Module = new DB_Frame_Module();
        DB_Frame_ModuleRights mdl = new DB_Frame_ModuleRights();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ///注意设置图片目录，图片以袁勋的梅花雪树为准
                TreeView1.ImgFolds = "../../../Images/TreeImages";
                TreeView1.Target = "main1";

                DataView dvRight = new Epoint.Frame.Webbuilder.Bizlogic.Site.DB_Site_Right().SelectAll();
                dvRight.RowFilter = "SiteGuid='" + this.SiteGuid + "' and AllowTo='All' and AllowType='Role'";
                if (FC.GetDetail("ConsultMainSite").ConfigValue == "1" || dvRight.Count > 0)
                {
                    TreeView1.RootNodeText = "所有部门";
                }
                else
                {
                    TreeView1.RootNodeText = "本站点部门";
                }
                AddSysNodes();
            }
        }

        private void AddSysNodes()
        {
            DataView dvRight = new Epoint.Frame.Webbuilder.Bizlogic.Site.DB_Site_Right().SelectAll();
            dvRight.RowFilter = "SiteGuid='" + this.SiteGuid + "' and AllowTo='All' and AllowType='Role'";
            if (FC.GetDetail("ConsultMainSite").ConfigValue == "1" || dvRight.Count > 0)
            {
                DataView dv = ous.Select("");
                EpointTreeNode node;
                int HasChildOu = 0;
                for (int i = 0; i < dv.Count; i++)
                {
                    node = new EpointTreeNode();
                    node.Text = dv[i]["OUName"].ToString();
                    node.Value = dv[i]["OUGuid"].ToString();

                    HasChildOu = Epoint.Common.Functions.IntNull(Convert.ToString(dv[i]["HasChildOu"]));
                    if (HasChildOu > 0)
                    {
                        node.PopulateOnDemand = true;
                        node.RunClickEvtOnInit = false;//是否在生成checkbox的时候运行click事件
                        node.ExpandOnCheckedChanged = false;//是否在checkbox变化的时候自动展开                   
                    }

                    node.ShowInputCtrl = true;
                    node.CtrlClickFunction = "AutoSetOuValue(this,'" + node.Text + "','" + node.Value + "');";
                    TreeView1.Nodes.Add(node);
                }
            }
            else
            {
                DataView dv = new Epoint.WebbuilderInfo.Bizlogic.UserManage.DB_Frame_SiteOU().SelectSiteOU(this.SiteGuid);
                EpointTreeNode node;
                int HasChildOu = 0;
                for (int i = 0; i < dv.Count; i++)
                {
                    node = new EpointTreeNode();
                    node.Text = dv[i]["OUName"].ToString();
                    node.Value = dv[i]["OUGuid"].ToString();

                    HasChildOu = Epoint.Common.Functions.IntNull(Convert.ToString(dv[i]["HasChildOu"]));
                    if (HasChildOu > 0)
                    {
                        node.PopulateOnDemand = true;
                        node.RunClickEvtOnInit = false;//是否在生成checkbox的时候运行click事件
                        node.ExpandOnCheckedChanged = false;//是否在checkbox变化的时候自动展开                   
                    }

                    node.ShowInputCtrl = true;
                    node.CtrlClickFunction = "AutoSetOuValue(this,'" + node.Text + "','" + node.Value + "');";
                    TreeView1.Nodes.Add(node);
                }
            }
        }


        protected void TreeView1_TreeNodePopulate1(object sender, EpointTreeNodeEventArgs e)
        {
            EpointTreeNode pNode = e.Node;
            DataView dv = ous.Select(pNode.Value);
            EpointTreeNode node;
            // string argsGuid = Request["argsGuid"].ToLower();
            int HasChildOu = 0;
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dv[i]["OUName"].ToString();
                node.Value = dv[i]["OUGuid"].ToString();

                HasChildOu = Epoint.Common.Functions.IntNull(Convert.ToString(dv[i]["HasChildOu"]));
                if (HasChildOu > 0)
                {
                    node.PopulateOnDemand = true;
                    node.RunClickEvtOnInit = false;//是否在生成checkbox的时候运行click事件
                    node.ExpandOnCheckedChanged = false;//是否在checkbox变化的时候自动展开
                }

                node.ShowInputCtrl = true;
                node.CtrlClickFunction = "AutoSetOuValue(this,'" + node.Text + "','" + node.Value + "');";
                pNode.ChildNodes.Add(node);
            }
        }
    }
}
