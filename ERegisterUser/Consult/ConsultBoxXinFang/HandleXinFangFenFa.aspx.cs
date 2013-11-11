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
using Epoint.Frame.Bizlogic;

namespace EpointRegisterUser.Consult
{
    public partial class HandleXinFangFenFa : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Db_ConsultBoxMana BoxMana = new Db_ConsultBoxMana();
        protected void Page_Load(object sender, EventArgs e)
        {

            this.CurrentPosition = "信件分发";
            this.Title = "信件分发";


            /// 判断是否现 回复方式
            if (new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("Consult_EnableReplyType").ConfigValue == "1")
            {
                trReplyType.Visible = true;
            }
            else
            {
                trReplyType.Visible = false;
            }

            if (string.IsNullOrEmpty(Frame_Config.GetConfigValue("Consult_FenFaGroup")))
            {
                AddTopNodes();
            }
            else
            {
                AddGroupNodes();

            }
        }
        /// <summary>
        /// 得到信箱分类组
        /// </summary>
        private void AddTopNodes()
        {
            Db_ConsultMana mana = new Db_ConsultMana();
            bool isNeedCheck = new Db_ConsultMana().GetDetail(Request.QueryString["HistoryGuid"]).InfoStatus == 0 ? false : true;

            EpointTreeNode node;
            DataView dvBox = BoxMana.BoxSelectAll();//选择所有的邮箱
            DataView dvGroup = BoxMana.BoxGroupSelectAll();//选择所有的信箱分类

            //循环生成树顶级节点
            for (int i = 0; i < dvGroup.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dvGroup[i]["BoxGroupName"].ToString();
                node.Value = dvGroup[i]["BoxGroupID"].ToString();
                dvBox.RowFilter = "BoxGroupID='" + dvGroup[i]["BoxGroupID"] + "'";//判断组下是否有信箱
                node.ShowInputCtrl = false;
                if (dvBox.Count > 0)
                {
                    node.PopulateOnDemand = true;
                    EpointTreeNode newnode;
                    for (int j = 0; j < dvBox.Count; j++)
                    {
                        newnode = new EpointTreeNode();
                        newnode.ShowInputCtrl = true;
                        node.PopulateOnDemand = false;
                        newnode.Text = dvBox[j]["BoxName"].ToString();
                        newnode.Value = dvBox[j]["BoxGuid"].ToString();
                        //if (isNeedCheck)//有未处理的则不能选择
                        //{
                        //    if (mana.IsNotHandle(Request.QueryString["HistoryGuid"], dvBox[j]["BoxGuid"].ToString()))
                        //    {
                        //        newnode.CtrlEnable = false;
                        //    }
                        //}
                        node.ChildNodes.Add(newnode);
                    }
                }
                TextTreeView1.Nodes.Add(node);
            }
        }
        /// <summary>
        /// 得到信箱分类组
        /// </summary>
        private void AddGroupNodes()
        {
            Db_ConsultMana mana = new Db_ConsultMana();
            bool isNeedCheck = new Db_ConsultMana().GetDetail(Request.QueryString["HistoryGuid"]).InfoStatus == 0 ? false : true;

            EpointTreeNode node;
            DataView dvBox = BoxMana.BoxSelectAll();//选择所有的邮箱

            dvBox.RowFilter = "BoxGroupID='" + Frame_Config.GetConfigValue("Consult_FenFaGroup") + "'";//判断组下是否有信箱
            if (dvBox.Count > 0)
            {
                EpointTreeNode newnode;
                for (int j = 0; j < dvBox.Count; j++)
                {
                    newnode = new EpointTreeNode();
                    newnode.ShowInputCtrl = true;
                    newnode.Text = dvBox[j]["BoxName"].ToString();
                    newnode.Value = dvBox[j]["BoxGuid"].ToString();
                    //if (isNeedCheck)//有未处理的则不能选择
                    //{
                    //    if (mana.IsNotHandle(Request.QueryString["HistoryGuid"], dvBox[j]["BoxGuid"].ToString()))
                    //    {
                    //        newnode.CtrlEnable = false;
                    //    }
                    //}
                    TextTreeView1.Nodes.Add(newnode);

                }
            }
        }
    }
}
