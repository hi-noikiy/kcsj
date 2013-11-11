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
using Epoint.Frame.Common;
using HTProject_Bizlogic;
namespace HTProject.Pages.RG_QYZiZhi
{
 
    public partial class RG_QYZiZhi_Add : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
	
		public int TableID=2020;
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
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
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage,tdContainer);
                //����ϴ��ļ��Ĵ�С�����ͼ��
                this.Add_FileUploadCheck_Script();
                ZiZhiEndDate_2020.Text = "2013-06-30";
                InitTree();
            }
            
        }


        override protected void OnInit(EventArgs e)
        {
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);           
            base.OnInit(e);
        }


        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            //if (RG_DW.IsExistByZiZhi(ZiZhiCode_2020.Text.Trim()))
            //{
            //    this.WriteAjaxMessage("alert('�����ʱ���Ѵ���');");
            //    return;
            //}
            string RowGuid = Guid.NewGuid().ToString();
            DWGuid_2020.Text = Request["DWGuid"];
            ZiZhiText_2020.Text = RegionTreeView.Text;
            ZiZhiTextCode_2020.Text = RegionTreeView.Value;
            string strSql = "select ZuZhiJGDM from RG_OUInfo where RowGuid='" + Request["DWGuid"] + "'";
            ZuZhiJGDM_2020.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            DelStatus_2020.SelectedValue = "0";
            if(oAddPage.SaveTableValues_CheckExist(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]))
            {
		
                ////����Ǹ���Ҫת����༭ҳ��
                //if (oAddPage.TableDetail.TableType == 1)
                //{
                //    Response.Redirect("MultiPageTab.aspx?mode=Mode&TableID=" + oAddPage.TableDetail.TableID + "&RowGuid=" + RowGuid);
                //}
                //Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
                //if (ApplicationOperate.GetConfigValueByName("IsHoldCurPage", "0") == "1")
                //    this.WriteAjaxMessage("refreshParentHoldCurPage();EP_ShowMessageDiv(" + tdContainer.ClientID + ",'���ݱ���ɹ�')");
                //else
                //    this.WriteAjaxMessage("refreshParent();EP_ShowMessageDiv(" + tdContainer.ClientID + ",'���ݱ���ɹ�')");
                this.WriteAjaxMessage("window.location.href='RG_QYZiZhi_Edit.aspx?RowGuid=" + RowGuid + "';alert('����ɹ�');refreshParent();");
			}
        }

        #region "��"
        /// <summary>
        /// ��ʼ��ע��������ṹ
        /// </summary>
        private void InitTree()
        {
            RegionTreeView.Nodes.Clear();
            EpointTreeNode node = new EpointTreeNode();
            DataView dv = DataBaseFunc.Instace.GetTree("f7f84f2a-de8a-4bc2-b13d-e541f73b12a8", "");
            DataView dvCopy = dv.Table.Copy().DefaultView;
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode(dv[i]["ItemText"].ToString(), dv[i]["ItemCode"].ToString());
                DataView dv2 = DataBaseFunc.Instace.GetTreeLevelTwo(dv[i]["ItemCode"].ToString(), "f7f84f2a-de8a-4bc2-b13d-e541f73b12a8", "");
                if (dv2.Count > 0)
                {
                    node.PopulateOnDemand = true;
                    node.ShowInputCtrl = false;
                    node.ExpandOnCheckedChanged = false;
                    node.ShowImage = true;
                    node.SelectLeafForTextTreeView = false;
                }
                else
                {
                    node.PopulateOnDemand = false;
                    node.ShowInputCtrl = true;
                    node.ShowImage = true;
                }
                RegionTreeView.Nodes.Add(node);
            }
        }

        /// <summary>
        /// ע��������νṹչ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RegionTreeView_TreeNodePopulate(object sender, EpointTreeNodeEventArgs e)
        {
            EpointTreeNode nodeArg = e.Node;
            EpointTreeNode nodeVar;
            DataView dv;
            int i = 0;

            dv = DataBaseFunc.Instace.GetTreeLevelTwo(nodeArg.Value, "f7f84f2a-de8a-4bc2-b13d-e541f73b12a8", "");
            for (i = 0; i < dv.Count; i++)
            {
                nodeVar = new EpointTreeNode(dv[i]["ItemText"].ToString(), dv[i]["ItemCode"].ToString());   //ʵ����һ���ڵ�
                DataView dv2 = DataBaseFunc.Instace.GetTreeLevelTwo(dv[i]["ItemCode"].ToString(), "f7f84f2a-de8a-4bc2-b13d-e541f73b12a8", "");
                if (dv2.Count > 0)
                {
                    nodeVar.ShowInputCtrl = false;
                    nodeVar.PopulateOnDemand = true;
                    nodeVar.ExpandOnCheckedChanged = false;
                    nodeVar.SelectLeafForTextTreeView = false;
                    nodeVar.ShowImage = false;
                }
                else
                {
                    nodeVar.ShowInputCtrl = true;
                    nodeVar.PopulateOnDemand = false;
                    nodeVar.ShowImage = false;
                    nodeVar.SelectLeafForTextTreeView = true;
                    nodeVar.CanSelectForTextTreeView = true;
                    nodeVar.ReturnFullPath = true;
                }
                nodeArg.ChildNodes.Add(nodeVar);
            }

        }
        #endregion

		
    }
}


