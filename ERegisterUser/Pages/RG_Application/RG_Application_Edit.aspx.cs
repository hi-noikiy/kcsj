using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Specialized;
using Epoint.Web.UI.WebControls2X;
using Epoint.RegisterUser.DataSyn.Bizlogic;

namespace EpointRegisterUser.Pages.RG_Application
{
    public partial class RG_Application_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 118;
        Epoint.MisBizLogic2.Web.EditPage oEditPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                if (!oRow.R_HasFilled)
                {
                    btnEdit.Visible = false;
                    this.AlertAjaxMessage("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
                //添加上传文件的大小和类型检查
                this.Add_FileUploadCheck_Script();
              
                AddTopNodes();
            }
        }

        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            base.OnInit(e);
        }

        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select UserName,UserPwd from RG_Application where AppGuid<>'"+Request["RowGuid"]+"'");
            foreach (DataRowView row in dv)
            {
                if (row["UserName"].ToString() == UserName_118.Text && row["UserPwd"].ToString() == UserPwd_118.Text)
                {
                    AlertAjaxMessage("该用户名密码已被使用，请重新填写！");
                    return;
                }
            }
            if (ShortcutText_118.Text == "")
                ShortcutText_118.Text = AppName_118.Text;
         
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_Application", "RowGuid", Request["RowGuid"]);
            string IsHoldCurPage = Epoint.Frame.Bizlogic.Frame_Config.GetConfigValue("IsHoldCurPage");
            if (IsHoldCurPage == "1")
                this.WriteAjaxMessage("refreshParentHoldCurPage();");
            else
                this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");
            this.WriteAjaxMessage("rtnValue(\"\")");
        }
 
        private void AddTopNodes()
        {
            AppManager.Text = Epoint.MisBizLogic2.DB.ExecuteToString("select DisplayName from Frame_User inner join RG_Application on Frame_User.UserGuid=RG_Application.UserGuid where RowGuid='" + Request["RowGuid"] + "'");
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select OUName,OUGuid from Frame_OU ");
            EpointTreeNode node;
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dv[i]["OUName"].ToString();
                node.Value = dv[i]["OUGuid"].ToString();
                int count = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(UserGuid) from Frame_User where OUGuid='" + node.Value + "'");
                if (count > 0)
                    node.PopulateOnDemand = true;
                else
                    node.PopulateOnDemand = false;
                node.ShowInputCtrl = false;
                AppManager.Nodes.Add(node);
            }  
        }

        protected void AppManager_TreeNodePopulate(object sender, EpointTreeNodeEventArgs e)
        {
            EpointTreeNode pNode = e.Node;
            DataView dvMo = Epoint.MisBizLogic2.DB.ExecuteDataView("select DisplayName,UserGuid from Frame_User where OUGuid='" + pNode.Value + "'");
            EpointTreeNode node;
            for (int i = 0; i < dvMo.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dvMo[i]["DisplayName"].ToString();
                node.Value = dvMo[i]["UserGuid"].ToString();
                node.PopulateOnDemand = false;
                pNode.ChildNodes.Add(node);
            }
        }
    }
}
