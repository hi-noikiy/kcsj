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
using Epoint.Frame.Bizlogic.UserManage;
using Epoint.Web.UI.WebControls2X;
using System.Web.Services;
using Epoint.RegisterUser.Bizlogic;
using Epoint.Frame.Bizlogic;

namespace EpointRegisterUser.Consult.ConslultBoxMana
{
    public partial class GetRGUserTree : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Frame_Config FC = new Frame_Config();

        OU ous = new OU();
        User user = new User();
        DB_Frame_Module Module = new DB_Frame_Module();
        DB_Frame_ModuleRights mdl = new DB_Frame_ModuleRights();
        Role role = new Role();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ///注意设置图片目录，图片以袁勋的梅花雪树为准
                TreeView1.ImgFolds = "../../Images/TreeImages";
                TreeView1.Target = "main1";

                DataView dvRight = new Epoint.Frame.Webbuilder.Bizlogic.Site.DB_Site_Right().SelectAll();
                dvRight.RowFilter = "SiteGuid='" + this.SiteGuid + "' and AllowTo='All' and AllowType='Role'";
                if (FC.GetDetail("ConsultMainSite").ConfigValue == "1" || dvRight.Count > 0)
                {
                    TreeView1.RootNodeText = "所有用户";
                }
                else
                {
                    TreeView1.RootNodeText = "本站点用户";
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
                int HasChildOu = 0, HasChildUser = 0;
                for (int i = 0; i < dv.Count; i++)
                {
                    node = new EpointTreeNode();
                    node.Text = dv[i]["OUName"].ToString();
                    node.Value = dv[i]["OUGuid"].ToString();

                    HasChildOu = Epoint.Common.Functions.IntNull(Convert.ToString(dv[i]["HasChildOu"]));
                    HasChildUser = Epoint.Common.Functions.IntNull(Convert.ToString(dv[i]["HasChildUser"]));

                    if (HasChildOu + HasChildUser > 0)
                    {
                        node.PopulateOnDemand = true;
                        node.CtrlClickFunction = "AutoSetPValue_OuGuid(this,'" + node.Value + "')";
                    }
                    node.ShowInputCtrl = true;
                    TreeView1.Nodes.Add(node);
                }
            }
            else
            {
                DataView dv = new Epoint.WebbuilderInfo.Bizlogic.UserManage.DB_Frame_SiteUser().SelectSiteUser(this.SiteGuid, "");
                EpointTreeNode node;
                for (int i = 0; i < dv.Count; i++)
                {
                    node = new EpointTreeNode();
                    node.Text = dv[i]["displayname"].ToString();
                    node.Value = dv[i]["UserGuid"].ToString();

                    node.CtrlClickFunction = "AutoSetUserValue(this,'" + node.Text + "','" + node.Value + "');";
                    node.ImageUrl = "../../Images/TreeImages/person.gif";

                    node.RunClickEvtOnInit = true;//是否在生成checkbox的时候运行click事件
                    node.PopulateOnDemand = false;
                    node.ShowInputCtrl = true;

                    TreeView1.Nodes.Add(node);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hasSelectGuidLst">已选择用户Guid列表</param>
        /// <param name="hasSelectDisplayNameLst">已选择用户显示名称列表</param>
        /// <param name="OuGuid">当前选择部门Guid</param>
        /// <param name="isSelect">选择或取消</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public static string getAllUserByOuGuid(string hasSelectGuidLst, string hasSelectDisplayNameLst, string OuGuid, Boolean isSelect)
        {
            return Epoint.Frame.Bizlogic.UserManage.User.getAllUserByOuGuidInTree(hasSelectGuidLst, hasSelectDisplayNameLst, OuGuid, isSelect);
        }

        protected void TreeView1_TreeNodePopulate1(object sender, EpointTreeNodeEventArgs e)
        {
            EpointTreeNode pNode = e.Node;
            DataView dvOu = ous.Select(pNode.Value);
            DataView dvUser = user.Select(pNode.Value);
            EpointTreeNode node;

            for (int j = 0; j < dvUser.Count; j++)
            {
                node = new EpointTreeNode();
                node.Text = dvUser[j]["DisplayName"].ToString();
                node.Value = dvUser[j]["userGuid"].ToString();

                //当节点为人员时,添加选择框事件
                node.CtrlClickFunction = "AutoSetUserValue(this,'" + node.Text + "','" + node.Value + "');";
                node.ImageUrl = "../../Images/TreeImages/person.gif";
                //节点为人员时,不能展开
                node.RunClickEvtOnInit = true;//是否在生成checkbox的时候运行click事件
                node.PopulateOnDemand = false;
                node.ShowInputCtrl = true;
                node.Checked = pNode.Checked;
                pNode.ChildNodes.Add(node);
            }
            int HasChildOu = 0, HasChildUser = 0;
            for (int i = 0; i < dvOu.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dvOu[i]["OUName"].ToString();
                node.Value = dvOu[i]["OUGuid"].ToString();

                HasChildOu = Epoint.Common.Functions.IntNull(Convert.ToString(dvOu[i]["HasChildOu"]));
                HasChildUser = Epoint.Common.Functions.IntNull(Convert.ToString(dvOu[i]["HasChildUser"]));

                if (HasChildOu + HasChildUser > 0)
                {
                    node.PopulateOnDemand = true;
                    node.CtrlClickFunction = "AutoSetPValue_OuGuid(this,'" + node.Value + "')";
                }
                node.ShowInputCtrl = true;
                node.Checked = pNode.Checked;
                pNode.ChildNodes.Add(node);
            }
        }
    }
}
