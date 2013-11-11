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
using Epoint.RegisterUser.Bizlogic.Consult;
using Epoint.Web.UI.WebControls2X.TextBoxControls;
using Epoint.Web.UI.WebControls2X;
using Epoint.Web.UI.WebControls2X.TreeViewControls;

namespace EpointRegisterUser.Consult
{
    public partial class HandleChuanFa : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Db_ConsultBoxMana BoxMana = new Db_ConsultBoxMana();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CurrentPosition = "信件转发";
            this.Title = "信件转发";
            
            //TextTreeView1.MultiSelect = true;
            AddTopNodes();
        }
        /// <summary>
        /// 得到信箱分类组
        /// </summary>
        private void AddTopNodes()
        {

            EpointTreeNode node;
            DataView dvBox = BoxMana.BoxSelectAll();//选择所有的邮箱
            DataView dvGroup = BoxMana.BoxGroupSelectAll();//选择所有的信箱分类

            //循环生成树顶级节点
            for (int i = 0; i < dvGroup.Count; i++)
            {
                node = new EpointTreeNode();
                node.Selected = false;
                node.Text = dvGroup[i]["BoxGroupName"].ToString();
                node.Value = dvGroup[i]["BoxGroupID"].ToString();
                dvBox.RowFilter = "BoxGroupID='" + dvGroup[i]["BoxGroupID"] + "'";//判断组下是否有信箱
                node.ShowInputCtrl = false;
                if (dvBox.Count > 0)
                {
                    node.PopulateOnDemand = true;
                }
                TextTreeView1.Nodes.Add(node);
            }
        }

        /// <summary>
        /// 添加信箱
        /// </summary>
        protected void TextTreeView1_TreeNodePopulate(object sender, EpointTreeNodeEventArgs e)
        {
            EpointTreeNode PNode = e.Node;
            PNode.ShowInputCtrl = true;
            DataView dv = BoxMana.BoxSelectByBoxGroupID(PNode.Value);//选择组别下所有的邮箱
            EpointTreeNode node;
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode();
                node.ShowInputCtrl = true;
                node.Text = dv[i]["BoxName"].ToString();
                node.Value = dv[i]["BoxGuid"].ToString();
                PNode.ChildNodes.Add(node);
            }
        }
    }
}
