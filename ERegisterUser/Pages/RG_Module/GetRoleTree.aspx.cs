using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.Web.UI.WebControls2X;

namespace EpointRegisterUser.Pages.RG_Module
{
    public partial class GetRoleTree : Epoint.Frame.Bizlogic.BasePage
    {
        /// <summary>
        /// 父页面的列表页面
        ///
        /// </summary>
        protected string SelectID
        {
            get
            {
                if (string.IsNullOrEmpty(Request["SelectID"]))
                    return "ctl00_ContentPlaceHolder1_lstRole";
                else
                    return Request["SelectID"];
            }
        }

        protected string HiddenValueID
        {
            get
            {
                if (string.IsNullOrEmpty(Request["HiddenValueID"]))
                    return "ctl00_ContentPlaceHolder2_HidRoleList";
                else
                    return Request["HiddenValueID"];
            }
        }


        protected string HiddenNameID
        {
            get
            {
                if (string.IsNullOrEmpty(Request["HiddenNameID"]))
                    return "ctl00_ContentPlaceHolder2_HidRoleNameList";
                else
                    return Request["HiddenNameID"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AddTopNodes();
            }

        }
        /// <summary>
        /// 加载RG_会员类别
        /// </summary>
        private void AddTopNodes()
        {
            DataView dv = new Epoint.MisBizLogic2.Code.DB_CodeItem().Get_Items_By_CodeName("RG_会员类别");
            EpointTreeNode node;
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dv[i]["ItemText"].ToString();
                node.Value = dv[i]["ItemValue"].ToString() + "@UserType";
                Boolean hasChild = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(RoleName) from RG_Role where UserType='" + dv[i]["ItemValue"].ToString() + "'") > 0;
                if (hasChild)
                    node.PopulateOnDemand = true;
                else
                    node.PopulateOnDemand = false;
                node.CtrlClickFunction = "AutoSetPValue(this, '" + node.Text + "', '" + node.Value + "')";
                TreeViewRoleList.Nodes.Add(node);
            }
        }

        /// <summary>
        /// 加载会员角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TreeViewRoleList_TreeNodePopulate(object sender, EpointTreeNodeEventArgs e)
        {
            EpointTreeNode pNode = e.Node;
            DataView dvMo = Epoint.MisBizLogic2.DB.ExecuteDataView("select RoleName,RowGuid from RG_Role where UserType='" + pNode.Value.Split('@')[0] + "'");
            EpointTreeNode node;
            for (int i = 0; i < dvMo.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dvMo[i]["RoleName"].ToString();
                node.Value = dvMo[i]["RowGuid"].ToString() + "@Role";

                node.PopulateOnDemand = false;
                node.CtrlClickFunction = "AutoSetPValue(this, '" + node.Text + "', '" + node.Value + "')";
                pNode.ChildNodes.Add(node);
            }

        }
    }
}
