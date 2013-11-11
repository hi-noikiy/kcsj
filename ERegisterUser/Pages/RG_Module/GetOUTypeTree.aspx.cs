using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.Web.UI.WebControls2X;

namespace EpointRegisterUser.Pages.RG_Module
{
    public partial class GetOUTypeTree : Epoint.Frame.Bizlogic.BasePage
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
                    return "ctl00_ContentPlaceHolder1_lstOUType";
                else
                    return Request["SelectID"];
            }
        }

        protected string HiddenValueID
        {
            get
            {
                if (string.IsNullOrEmpty(Request["HiddenValueID"]))
                    return "ctl00_ContentPlaceHolder2_HidOUTypeList";
                else
                    return Request["HiddenValueID"];
            }
        }


        protected string HiddenNameID
        {
            get
            {
                if (string.IsNullOrEmpty(Request["HiddenNameID"]))
                    return "ctl00_ContentPlaceHolder2_HidOUTypeNameList";
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
            DataView dv = new Epoint.MisBizLogic2.Code.DB_CodeItem().Get_Items_By_CodeName("RG_会员单位");
            EpointTreeNode node;
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dv[i]["ItemText"].ToString();
                node.Value = dv[i]["ItemValue"].ToString();
                node.PopulateOnDemand = false;               
                node.ShowInputCtrl = true;
                node.CtrlClickFunction = "AutoSetPValue(this, '" + node.Text + "', '" + node.Value + "')";
                TreeViewOUTypeList.Nodes.Add(node);
            }
        }


    }
}
