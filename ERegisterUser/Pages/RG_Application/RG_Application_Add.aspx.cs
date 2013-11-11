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
    public partial class RG_Application_Add : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 118;
        Epoint.MisBizLogic2.Web.AddPage oAddPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oAddPage.TableDetail.TableName;
                #region �ж��Ƿ��Ǹ�������Ǹ�������û�и����RowID���Զ�ת����Ӧ������
                string ParentRowGuid = Request.QueryString["ParentRowGuid"];
                if (oAddPage.TableDetail.TableType == 2)
                {
                    if (ParentRowGuid == null || ParentRowGuid == "")
                    {
                        this.AlertAjaxMessage("��ֱֹ�Ӷ��ӱ���Ӽ�¼��");
                        return;
                    }
                }
                #endregion
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
                //����ϴ��ļ��Ĵ�С�����ͼ��
                this.Add_FileUploadCheck_Script();
                AddTopNodes();
                OrderNum_118.Text = "-1";
                TokenParam_118.Text = "token";
            }
        }

        override protected void OnInit(EventArgs e)
        {
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);
            base.OnInit(e);
        }

        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select UserName,UserPwd from RG_Application");
            foreach (DataRowView row in dv)
            {
                if (row["UserName"].ToString() == UserName_118.Text && row["UserPwd"].ToString() == UserPwd_118.Text)
                {
                    AlertAjaxMessage("���û��������ѱ�ʹ�ã���������д��");
                    return;
                }
            }
            string RowGuid = Guid.NewGuid().ToString();
            ParentGuid_118.Text = Request["ParentGuid"];
            AppGuid_118.Text = RowGuid;
            UserGuid_118.Text = AppManager.Value;
            if (ShortcutText_118.Text == "")
                ShortcutText_118.Text = AppName_118.Text;
           
            oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);
            new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_Application", "RowGuid", RowGuid);
            //����Ǹ���Ҫת����༭ҳ��
            if (oAddPage.TableDetail.TableType == 1)
            {
                Response.Redirect("MultiPageTab.aspx?mode=Mode&TableID=" + oAddPage.TableDetail.TableID + "&RowGuid=" + RowGuid);
            }
            Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
            string IsHoldCurPage = Epoint.Frame.Bizlogic.Frame_Config.GetConfigValue("IsHoldCurPage");
            if (IsHoldCurPage == "1")
                this.WriteAjaxMessage("refreshParentHoldCurPage();EP_ShowMessageDiv(" + tdContainer.ClientID + ",'���ݱ���ɹ�')");
            else
                this.WriteAjaxMessage("refreshParent();EP_ShowMessageDiv(" + tdContainer.ClientID + ",'���ݱ���ɹ�')");
            this.WriteAjaxMessage("rtnValue(\"\")");
        }

        
        /// <summary>
        ///  
        /// </summary>
        private void AddTopNodes()
        {
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

        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


