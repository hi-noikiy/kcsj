using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.Web.UI.WebControls2X;

namespace EpointRegisterUser.Pages.RG_Module
{
    public partial class GetOUUserTree : Epoint.Frame.Bizlogic.BasePage
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
                    return "ctl00_ContentPlaceHolder1_lstOUUser";
                else
                    return Request["SelectID"];
            }
        }

        protected string HiddenValueID
        {
            get
            {
                if (string.IsNullOrEmpty(Request["HiddenValueID"]))
                    return "ctl00_ContentPlaceHolder2_HidOUUserList";
                else
                    return Request["HiddenValueID"];
            }
        }


        protected string HiddenNameID
        {
            get
            {
                if (string.IsNullOrEmpty(Request["HiddenNameID"]))
                    return "ctl00_ContentPlaceHolder2_HidOUUserNameList";
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
        /// 加载会员单位类别
        /// </summary>
        private void AddTopNodes()
        {
            DataView dv = new Epoint.MisBizLogic2.Code.DB_CodeItem().Get_Items_By_CodeName("RG_会员单位");
            EpointTreeNode node;
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dv[i]["ItemText"].ToString();
                node.Value = dv[i]["ItemValue"].ToString() + "&0";
                node.PopulateOnDemand = true;
                node.ShowInputCtrl = false;
                TreeViewOUUserList.Nodes.Add(node);
            }
        }


        protected void TreeViewOUUserList_TreeNodePopulate(object sender, EpointTreeNodeEventArgs e)
        {
            EpointTreeNode pNode = e.Node;
            EpointTreeNode node;
            // 判断父节点是不是会员单位类别
            string[] nodevalues = e.Node.Value.Split('&');
            if (nodevalues.Length == 2 && nodevalues[1] == "0")
            {
                // 加载单位类别下的所有单位
                string sql = "SELECT RG_OuInfo.EnterpriseName, RG_OuInfo.RowGuid,RG_OuType_Relate.OuType  FROM RG_OuInfo INNER JOIN RG_OuType_Relate ON RG_OuInfo.rowguid=RG_OuType_Relate.relatedguid WHERE RG_OuType_Relate.RelatedType='Ou' AND RG_OuType_Relate.OuType='" + Epoint.Frame.Bizlogic.common.strReplaceSql(nodevalues[0]) + "'";
                DataView dvOu = Epoint.MisBizLogic2.DB.ExecuteDataView(sql);

                for (int i = 0; i < dvOu.Count; i++)
                {
                    node = new EpointTreeNode();
                    node.Text = dvOu[i]["EnterpriseName"].ToString();
                    node.Value = dvOu[i]["RowGuid"].ToString() + "&" + dvOu[i]["OuType"].ToString();
                    node.PopulateOnDemand = true;
                    node.ShowInputCtrl = true;
                    pNode.ChildNodes.Add(node);
                }
            }
            else
            {
                // 加载单位下的会员账号
                string sql = "SELECT RG_User.DispName, RG_User.RowGuid, RG_User.UserType from RG_User INNER JOIN RG_OuType_Relate ON RG_User.RowGuid=RG_OuType_Relate.RelatedGuid WHERE DanWeiGuid='" + Epoint.Frame.Bizlogic.common.strReplaceSql(nodevalues[0]) + "' AND RG_OuType_Relate.OuType='" + Epoint.Frame.Bizlogic.common.strReplaceSql(nodevalues[1]) + "'";

                // 判断是否需要加载 单位子帐号 的会员帐号
                if (!Convert.ToBoolean(Epoint.Frame.Bizlogic.Frame_Config.GetConfigValue("RegisterUser_RGMail_ShowAllDanWeiUser", "true")))
                {
                    sql += " AND RG_User.UserType='002'";// 仅仅显示单位管理员会员帐号
                }
                
                DataView dvOuUser = Epoint.MisBizLogic2.DB.ExecuteDataView(sql);

                for (int j = 0; j < dvOuUser.Count; j++)
                {
                    node = new EpointTreeNode();
                    node.Text = dvOuUser[j]["DispName"].ToString();
                    node.Value = dvOuUser[j]["RowGuid"].ToString() + "&" + nodevalues[1];
                    node.PopulateOnDemand = false;
                    node.CtrlClickFunction = "AutoSetPValue(this, '" + node.Text + "', '" + node.Value + "')";
                    pNode.ChildNodes.Add(node);
                }
            }

        }
    }
}
