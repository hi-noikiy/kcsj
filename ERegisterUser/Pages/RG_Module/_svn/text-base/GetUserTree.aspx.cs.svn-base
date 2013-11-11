using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.Web.UI.WebControls2X;
using Epoint.RegisterUser.Bizlogic;

namespace EpointRegisterUser.Pages.RG_Module
{
    public partial class GetUserTree : Epoint.Frame.Bizlogic.BasePage
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
                    return "ctl00_ContentPlaceHolder1_lstUser";
                else
                    return Request["SelectID"];
            }
        }

        protected string HiddenValueID
        {
            get
            {
                if (string.IsNullOrEmpty(Request["HiddenValueID"]))
                    return "ctl00_ContentPlaceHolder2_HidUserList";
                else
                    return Request["HiddenValueID"];
            }
        }


        protected string HiddenNameID
        {
            get
            {
                if (string.IsNullOrEmpty(Request["HiddenNameID"]))
                    return "ctl00_ContentPlaceHolder2_HidUserNameList";
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
            else
            {
                // 现在处理检索
                ProcessQuery();
            }

        }

        /// <summary>
        /// 检索用户
        /// </summary>
        private void ProcessQuery()
        {
            TreeViewUserList.Nodes.Clear();
            if (string.IsNullOrEmpty(txtDisplayName.Text))
            {
                AddTopNodes();
            }
            else
            {
                // 根据名称检索到所有的用户。
                Epoint.RegisterUser.Bizlogic.RegisterUser rguser = new Epoint.RegisterUser.Bizlogic.RegisterUser();
                DataView dvUser = rguser.GetRGUser(txtDisplayName.Text);
                EpointTreeNode node;

                for (int j = 0; j < dvUser.Count; j++)
                {
                    if (Convert.ToString(dvUser[j]["DispName"]) != "")
                    {
                        node = new EpointTreeNode();
                        node.Text = dvUser[j]["DispName"].ToString();
                        node.Value = dvUser[j]["RowGuid"].ToString();
                        node.PopulateOnDemand = false;
                        node.CtrlClickFunction = "AutoSetPValue(this, '" + node.Text + "', '" + node.Value + "')";
                        TreeViewUserList.Nodes.Add(node);
                    }
                }
            }
        }

        private void AddTopNodes()
        {
            DataView dv = new Epoint.MisBizLogic2.Code.DB_CodeItem().Get_Items_By_CodeName("RG_会员类别");
            EpointTreeNode node;
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dv[i]["ItemText"].ToString();
                node.Value = dv[i]["ItemValue"].ToString();
                //int count = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(RoleName) from RG_Role where UserType='" + node.Value + "'");
                int count = Convert.ToInt32(Epoint.MisBizLogic2.DB.ExecuteToString("select count(Row_ID) from RG_User where usertype like '%" + node.Value + ";%'"));

                //int count2 = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(S.DispName) from RG_User as S where  not exists(select * from RG_User_Role where S.RowGuid=RG_User_Role.RGUserGuid)  and  UserType='" + node.Value + "' and S.UserStatus=002 and S.IsValid=1 and DelFlag=0");
                if (count == 0)//
                {
                    node.PopulateOnDemand = false;
                }
                else
                    node.PopulateOnDemand = true;
                node.ShowInputCtrl = false;
                TreeViewUserList.Nodes.Add(node);
            }
        }
        protected void TreeViewUserList_TreeNodePopulate(object sender, EpointTreeNodeEventArgs e)
        {
            EpointTreeNode pNode = e.Node;
            //DataView dvMo = Epoint.MisBizLogic2.DB.ExecuteDataView("select RoleName,RowGuid from RG_Role where UserType='" + pNode.Value + "'");
            //DataView dvMo2 = Epoint.MisBizLogic2.DB.ExecuteDataView("select S.DispName,S.RowGuid from RG_User as S inner join RG_User_Role as C on(S.RowGuid=C.RGUserGuid) where C.RoleGuid='" + pNode.Value + "' and S.UserStatus=002 and S.IsValid=1 and DelFlag=0");
            //DataView dvMo3 = Epoint.MisBizLogic2.DB.ExecuteDataView("select S.DispName,S.RowGUid from RG_User as S where  not exists(select * from RG_User_Role where S.RowGuid=RG_User_Role.RGUserGuid)  and  UserType='" + pNode.Value + "' and S.UserStatus=002 and S.IsValid=1 and DelFlag=0");
            DataView dvMo = Epoint.MisBizLogic2.DB.ExecuteDataView("select DispName,RowGuid from RG_User where usertype like '%" + pNode.Value + ";%'");
            EpointTreeNode node;
            if (dvMo.Count > 0)
            {
                for (int i = 0; i < dvMo.Count; i++)
                {
                    node = new EpointTreeNode();
                    node.Text = dvMo[i]["DispName"].ToString();
                    node.Value = dvMo[i]["RowGuid"].ToString();
                    //Boolean isleaf = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(S.RowGuid) from RG_User as S inner join RG_User_Role as C on(S.RowGuid=C.RGUserGuid) where C.RoleGuid='" + node.Value + "' and S.UserStatus=002 and S.IsValid=1 and DelFlag=0") == 0;
                    //if (isleaf)
                    node.PopulateOnDemand = false;
                    //else
                    //    node.PopulateOnDemand = true;
                    node.ShowInputCtrl = true;
                    node.CtrlClickFunction = "AutoSetPValue(this, '" + node.Text + "', '" + node.Value + "')";
                    //node.CtrlClickFunction = "AutoSetPValue(this, '" + node.Text + "', '" + node.Value + "')";
                    pNode.ChildNodes.Add(node);
                }
            }
            //else if (dvMo2.Count > 0)
            //{
            //    for (int j = 0; j < dvMo2.Count; j++)
            //    {
            //        node = new EpointTreeNode();
            //        node.Text = dvMo2[j]["DispName"].ToString();
            //        node.Value = dvMo2[j]["RowGuid"].ToString();
            //        node.PopulateOnDemand = false;
            //        node.CtrlClickFunction = "AutoSetPValue(this, '" + node.Text + "', '" + node.Value + "')";
            //        pNode.ChildNodes.Add(node);
            //    }
            //}
            //if (dvMo3.Count > 0)
            //{
            //    for (int k = 0; k < dvMo3.Count; k++)
            //    {
            //        node = new EpointTreeNode();
            //        node.Text = dvMo3[k]["DispName"].ToString();
            //        node.Value = dvMo3[k]["RowGuid"].ToString();
            //        node.PopulateOnDemand = false;
            //        node.ShowInputCtrl = true;
            //        node.CtrlClickFunction = "AutoSetPValue(this, '" + node.Text + "', '" + node.Value + "')";
            //        pNode.ChildNodes.Add(node);
            //    }
            //}

        }
    }
}
