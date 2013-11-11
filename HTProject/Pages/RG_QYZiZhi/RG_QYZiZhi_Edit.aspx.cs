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
using System.Collections.Specialized ;
using Epoint.Web.UI.WebControls2X;
using Epoint.Frame.Common;
using HTProject_Bizlogic;

namespace HTProject.Pages.RG_QYZiZhi
{
	
	public partial class RG_QYZiZhi_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
	{
	    public int TableID=2020;
	    Epoint.MisBizLogic2.Web.EditPage oEditPage;
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        HTProject_Bizlogic.DataBaseFunc DBF = new DataBaseFunc();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if (!Page.IsPostBack )
			{
                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
				if (!oRow.R_HasFilled)
				{
					btnEdit.Visible = false;
				    this.AlertAjaxMessage ("û�ж�Ӧ�����ݼ�¼��");
                    this.WriteAjaxMessage("window.close();");
					return;
				}
				
				
				
				Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
				//����ϴ��ļ��Ĵ�С�����ͼ��
                this.Add_FileUploadCheck_Script();
                RegionTreeView.Text = ZiZhiText_2020.Text;
                RegionTreeView.Value = ZiZhiTextCode_2020.Text;
                string strSql = "SELECT EnterpriseName FROM RG_OUInfo WHERE RowGuid='" + DWGuid_2020.Text + "'";
                lblDWName.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);

                ZZ_ZS_Z.ClientGuid = Request["RowGuid"] + "ZZ_ZS_Z";
                ZZ_ZS_Z.NodeCode = DWGuid_2020.Text;
                ZZ_ZS_Z.MisRowGuid = Request["RowGuid"];

                ZZ_ZS_F.ClientGuid = Request["RowGuid"] + "ZZ_ZS_F";
                ZZ_ZS_F.NodeCode = DWGuid_2020.Text;
                ZZ_ZS_F.MisRowGuid = Request["RowGuid"];

                if (oRow["Status"].ToString() == "90")//ͨ��
                {
                    //btnEdit.Visible = false;
                }
                else if (oRow["Status"].ToString() == "80")//��ͨ��
                {
                    //btnEdit.Visible = false;
                }
                else if (oRow["Status"].ToString() == "70")//�����
                {
                    btnEdit.Visible = false;
                    btnSubmit.Visible = false;
                    ZZ_ZS_Z.ReadOnly = true;
                    ZZ_ZS_F.ReadOnly = true;
                }

                lblSHOpinion.Text = RG_DW.GetSHOpinion(Request["RowGuid"], "");
                
			}
            InitTree();
		}


        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage (TableID);
            base.OnInit(e);
        }
	

		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
            //if (RG_DW.IsExistByZiZhi(ZiZhiCode_2020.Text.Trim(), Request["RowGuid"]))
            //{
            //    this.WriteAjaxMessage("alert('�����ʱ���Ѵ���');");
            //    return;
            //}
            //����״̬���Ǳ༭�У�������ͨ��
            if (Status_2020.SelectedValue == "90")//���ͨ���ģ������Ǳ�ɱ��״̬
            {
                Status_2020.SelectedValue = "85";
            }
            ZiZhiText_2020.Text = RegionTreeView.Text;
            ZiZhiTextCode_2020.Text = RegionTreeView.Value;
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
			
            if (ApplicationOperate.GetConfigValueByName("IsHoldCurPage", "0") == "1")
                this.WriteAjaxMessage("refreshParentHoldCurPage();"); 
            else
                this.WriteAjaxMessage("refreshParent();"); 
			//this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'���ݱ���ɹ�')"); 
            this.WriteAjaxMessage("alert('����ɹ����뼰ʱ�ύ���');");
		}
        HTProject_Bizlogic.SMS HTSMS = new SMS();
        protected void btSubmit_Click(object sender, System.EventArgs e)
        {
            if (RG_DW.IsExistByZiZhi(ZiZhiCode_2020.Text.Trim(), Request["RowGuid"]))
            {
                this.WriteAjaxMessage("alert('�����ʱ���Ѵ���');");
                return;
            }
            //�Ƚ�ԭ����ɾ������ֹ�ظ�
            new HTProject_Bizlogic.DB_Messages_Center().DeleteWH("�����ҵ����", Request["RowGuid"]);
            ZiZhiText_2020.Text = RegionTreeView.Text;
            ZiZhiTextCode_2020.Text = RegionTreeView.Value;
            Status_2020.SelectedValue = "70";
            TJ_Date_2020.Text = DateTime.Now.ToString("yyyy-MM-dd");
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            //���ʹ�������ˣ����ݽ�ɫ��
            DataView dv = DBF.GetUserByRoleName("��ҵ�������");

            for (int m = 0; m < dv.Count; m++)
            {
                string messageGuid = Guid.NewGuid().ToString();
                new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Insert(messageGuid,
                                    lblDWName.Text + "������Ϣ���",
                                    "",
                                    dv[m]["UserGuid"].ToString(),
                                    dv[m]["DisplayName"].ToString(),
                                    "",
                                    "",
                                    "",
                                    @"HTProject/Pages/RG_QYZiZhi/RG_QYZiZhi_ADDetail.aspx?RowGuid=" + Request["RowGuid"],
                                    "",
                                    "",
                                    1,
                                    "",
                                    "",
                                    ""
                             );
                //���±�־λ
                string strSql = "update messages_center set PType='�����ҵ����',PGuid='" + Request["RowGuid"] + "' where MessageItemGuid='" + messageGuid + "'";
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);

                //��Ӷ���
                string IsSendADSMS = ApplicationOperate.GetConfigValueByName("IsSendADSMS");
                if (IsSendADSMS == "1")
                {
                    if (dv[m]["Mobile"].ToString() != "")
                    {
                        HTSMS.SendSMS(this.DisplayName, dv[m]["DisplayName"], lblDWName.Text + "�ύ������Ϣ���", dv[m]["Mobile"]);
                    }
                }

            }
            AlertAjaxMessage("�ύ�ɹ�");
            this.WriteAjaxMessage("refreshParent();window.close();");
        }

        #region "��"
        /// <summary>
        /// ��ʼ��ע��������ṹ
        /// </summary>
        private void InitTree()
        {
            RegionTreeView.Nodes.Clear();
            EpointTreeNode node = new EpointTreeNode();
            DataView dv = DataBaseFunc.Instace.GetTree("f7f84f2a-de8a-4bc2-b13d-e541f73b12a8","");
            DataView dvCopy = dv.Table.Copy().DefaultView;
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode(dv[i]["ItemText"].ToString(), dv[i]["ItemCode"].ToString());
                DataView dv2 = DataBaseFunc.Instace.GetTreeLevelTwo(dv[i]["ItemCode"].ToString(), "f7f84f2a-de8a-4bc2-b13d-e541f73b12a8", "");
                if (dv2.Count >= 1)
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
