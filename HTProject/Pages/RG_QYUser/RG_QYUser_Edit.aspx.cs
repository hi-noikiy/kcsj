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

namespace HTProject.Pages.RG_QYUser
{

    public partial class RG_QYUser_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 2019;
        Epoint.MisBizLogic2.Web.EditPage oEditPage;
        HTProject_Bizlogic.DataBaseFunc DBF = new DataBaseFunc();
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                if (!oRow.R_HasFilled)
                {
                    btnEdit.Visible = false;
                    this.AlertAjaxMessage("û�ж�Ӧ�����ݼ�¼��");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }


                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
                //����ϴ��ļ��Ĵ�С�����ͼ��
                this.Add_FileUploadCheck_Script();

                RY_SFZ.ClientGuid = Request["RowGuid"] + "RY_SFZ";
                RY_SFZ.NodeCode = DWGuid_2019.Text;
                RY_SFZ.MisRowGuid = Request["RowGuid"];

                RY_BYZ.ClientGuid = Request["RowGuid"] + "RY_BYZ";
                RY_BYZ.NodeCode = DWGuid_2019.Text;
                RY_BYZ.MisRowGuid = Request["RowGuid"];

                RY_ZCZJ.ClientGuid = Request["RowGuid"] + "RY_ZCZJ";
                RY_ZCZJ.NodeCode = DWGuid_2019.Text;
                RY_ZCZJ.MisRowGuid = Request["RowGuid"];

                RY_ZhiCheng.ClientGuid = Request["RowGuid"] + "RY_ZhiCheng";
                RY_ZhiCheng.NodeCode = DWGuid_2019.Text;
                RY_ZhiCheng.MisRowGuid = Request["RowGuid"];

                RY_LDHT.ClientGuid = Request["RowGuid"] + "RY_LDHT";
                RY_LDHT.NodeCode = DWGuid_2019.Text;
                RY_LDHT.MisRowGuid = Request["RowGuid"];

                RY_GRQT.ClientGuid = Request["RowGuid"] + "RY_GRQT";
                RY_GRQT.NodeCode = DWGuid_2019.Text;
                RY_GRQT.MisRowGuid = Request["RowGuid"];

                RY_GRQM.ClientGuid = Request["RowGuid"] + "RY_GRQM";
                RY_GRQM.NodeCode = DWGuid_2019.Text;
                RY_GRQM.MisRowGuid = Request["RowGuid"];

                
                RegionTreeView.Text = ZhuanYeCS_2019.Text;
                RegionTreeView.Value = ZhuanYeCSCode_2019.Text;

                string strSql = "SELECT EnterpriseName FROM RG_OUInfo WHERE RowGuid='" + DWGuid_2019.Text + "'";
                lblDWName.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);

                if (oRow["Status"].ToString() == "90")//ͨ��
                {
                    //btnEdit.Visible = false;
                }
                else if (oRow["Status"].ToString() == "80" || oRow["Status"].ToString() == "85")//��ͨ���������
                {
                    //btnEdit.Visible = false;
                }
                else if (oRow["Status"].ToString() == "70")//�����
                {
                    btnEdit.Visible = false;
                    btnSubmit.Visible = false;
                    RY_SFZ.ReadOnly = true;
                    RY_BYZ.ReadOnly = true;
                    RY_ZCZJ.ReadOnly = true;
                    RY_ZhiCheng.ReadOnly = true;
                    RY_LDHT.ReadOnly = true;
                    RY_GRQT.ReadOnly = true;
                    RY_GRQM.ReadOnly = true;
                }
                lblSHOpinion.Text = RG_DW.GetSHOpinion(Request["RowGuid"], "");
            }
            InitTree();
        }

        protected string STATUS
        {
            get
            {
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                return oRow["Status"].ToString();
            }
        }

        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            base.OnInit(e);
        }

        protected void btID_Click(object sender, System.EventArgs e)
        {
            string oName = "";
            if (RG_DW.IsExistByIDNO(IDNum_2019.Text.Trim(), out oName, Request["RowGuid"]))
            {
                IDNum_2019.Text = "";
                this.WriteAjaxMessage("alert('�����֤�Ѿ����ڣ�����Ϊ��" + oName + "');");
                return;
            }
        }

        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            //�ж������֤s�Ƿ��Ѿ�����
            string oName = "";
            if (RG_DW.IsExistByIDNO(IDNum_2019.Text.Trim(), out oName, Request["RowGuid"]))
            {
                this.WriteAjaxMessage("alert('�����֤�Ѿ����ڣ�����Ϊ��" + oName + "');");
                return;
            }
            //��ע����
            if (YinZhangNo_2019.Text.Trim() != "")
            {
                if (ZCZ_YXQ_2019.Text == "")
                {
                    //ZCZ_YXQ_2019.Text = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
                    this.WriteAjaxMessage("alert('����дע����1��Ч��');");
                    return;
                }
            }
            else
            {
                ZCZ_YXQ_2019.Text = "";
            }
            if (YinZhangNo1_2019.Text.Trim() != "")
            {
                if (ZCZ_YXQ1_2019.Text == "")
                {
                    //ZCZ_YXQ_2019.Text = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
                    this.WriteAjaxMessage("alert('����дע����2��Ч��');");
                    return;
                }
            }
            else
            {
                ZCZ_YXQ1_2019.Text = "";
            }
            if (YinZhangNo2_2019.Text.Trim() != "")
            {
                if (ZCZ_YXQ2_2019.Text == "")
                {
                    //ZCZ_YXQ_2019.Text = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
                    this.WriteAjaxMessage("alert('����дע����3��Ч��');");
                    return;
                }
            }
            else
            {
                ZCZ_YXQ2_2019.Text = "";
            }
            //����״̬���Ǳ༭�У�������ͨ��
            if (Status_2019.SelectedValue == "90")//���ͨ���ģ������Ǳ�ɱ��״̬
            {
                Status_2019.SelectedValue = "85";
            }
            ZhuanYeCS_2019.Text = RegionTreeView.Text;
            ZhuanYeCSCode_2019.Text = RegionTreeView.Value;
            TJRGuid_2019.Text = this.UserGuid;
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);

            if (ApplicationOperate.GetConfigValueByName("IsHoldCurPage", "0") == "1")
                this.WriteAjaxMessage("refreshParentHoldCurPage();");
            else
                this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'���ݱ���ɹ�')");
        }
        HTProject_Bizlogic.SMS HTSMS = new SMS();
        protected void btnSubmit_Click(object sender, System.EventArgs e)
        {
            //�ж������֤s�Ƿ��Ѿ�����
            string oName = "";
            if (RG_DW.IsExistByIDNO(IDNum_2019.Text.Trim(), out oName, Request["RowGuid"]))
            {
                this.WriteAjaxMessage("alert('�����֤�Ѿ����ڣ�����Ϊ��" + oName + "');");
                return;
            }
            //��ע����
            if (YinZhangNo_2019.Text.Trim() != "")
            {
                if (ZCZ_YXQ_2019.Text == "")
                {
                    //ZCZ_YXQ_2019.Text = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
                    this.WriteAjaxMessage("alert('����дע����1��Ч��');");
                    return;
                }
            }
            else
            {
                ZCZ_YXQ_2019.Text = "";
            }
            if (YinZhangNo1_2019.Text.Trim() != "")
            {
                if (ZCZ_YXQ1_2019.Text == "")
                {
                    //ZCZ_YXQ_2019.Text = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
                    this.WriteAjaxMessage("alert('����дע����2��Ч��');");
                    return;
                }
            }
            else
            {
                ZCZ_YXQ1_2019.Text = "";
            }
            if (YinZhangNo2_2019.Text.Trim() != "")
            {
                if (ZCZ_YXQ2_2019.Text == "")
                {
                    //ZCZ_YXQ_2019.Text = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
                    this.WriteAjaxMessage("alert('����дע����3��Ч��');");
                    return;
                }
            }
            else
            {
                ZCZ_YXQ2_2019.Text = "";
            }
            //������û���ϴ�����ǩ��
            Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom StorgCom = new Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom();
            string CliGuid = Request["RowGuid"] + "RY_GRQM";
            DataView dvAttch = StorgCom.Select(CliGuid);
            if (dvAttch.Count == 0)
            {
                this.WriteAjaxMessage("alert('���ϴ�����ǩ��');");
                return;
            }
            //�Ƚ�ԭ����ɾ������ֹ�ظ�
            new HTProject_Bizlogic.DB_Messages_Center().DeleteWH("��Ա��Ϣ���", Request["RowGuid"]);
            ZhuanYeCS_2019.Text = RegionTreeView.Text;
            ZhuanYeCSCode_2019.Text = RegionTreeView.Value;
            TJRGuid_2019.Text = this.UserGuid;
            Status_2019.SelectedValue = "70";
            TJ_Date_2019.Text = DateTime.Now.ToString("yyyy-MM-dd");
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);

            //if (ApplicationOperate.GetConfigValueByName("IsHoldCurPage", "0") == "1")
            //    this.WriteAjaxMessage("refreshParentHoldCurPage();");
            //else
            //    this.WriteAjaxMessage("refreshParent();");
            //this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'���ݱ���ɹ�')");
            //���ʹ�������ˣ����ݽ�ɫ��
            DataView dv = DBF.GetUserByRoleName("��Ա��Ϣ���");

            for (int m = 0; m < dv.Count; m++)
            {
                string messageGuid = Guid.NewGuid().ToString();
                new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Insert(messageGuid,
                                    XM_2019.Text + "[" + lblDWName.Text + "]��Ϣ���",
                                    "",
                                    dv[m]["UserGuid"].ToString(),
                                    dv[m]["DisplayName"].ToString(),
                                    "",
                                    "",
                                    "",
                                    @"HTProject/Pages/RG_QYUser/RG_QYUser_Detail.aspx?RowGuid=" + Request["RowGuid"],
                                    "",
                                    "",
                                    1,
                                    "",
                                    "",
                                    ""
                             );
                //���±�־λ
                string strSql = "update messages_center set PType='��Ա��Ϣ���',PGuid='" + Request["RowGuid"] + "' where MessageItemGuid='" + messageGuid + "'";
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);

                //��Ӷ���
                string IsSendADSMS = ApplicationOperate.GetConfigValueByName("IsSendADSMS");
                if (IsSendADSMS == "1")
                {
                    if (dv[m]["Mobile"].ToString() != "")
                    {
                        HTSMS.SendSMS(this.DisplayName, dv[m]["DisplayName"], lblDWName.Text + "�ύ��Ա��Ϣ���", dv[m]["Mobile"]);
                    }
                }
            }
            AlertAjaxMessage("�ύ�ɹ�");
        }

        protected void btnLiZhi_Click(object sender, System.EventArgs e)
        {
            TJRGuid_2019.Text = this.UserGuid;
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            
            //�Ƚ�ԭ����ɾ������ֹ�ظ�
            new HTProject_Bizlogic.DB_Messages_Center().DeleteWH("��Ա��Ϣ���", Request["RowGuid"]);
            
            //���ʹ�������ˣ����ݽ�ɫ��
            DataView dv = DBF.GetUserByRoleName("��Ա��Ϣ���");

            for (int m = 0; m < dv.Count; m++)
            {
                string messageGuid = Guid.NewGuid().ToString();
                new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Insert(messageGuid,
                                    oRow["XM"] + "[" + lblDWName.Text + "]��ְ�������",
                                    "",
                                    dv[m]["UserGuid"].ToString(),
                                    dv[m]["DisplayName"].ToString(),
                                    "",
                                    "",
                                    "",
                                    @"HTProject/Pages/RG_QYUser/RG_QYUser_LiZhi_Detail.aspx?RowGuid=" + Request["RowGuid"],
                                    "",
                                    "",
                                    1,
                                    "",
                                    "",
                                    ""
                             );
                //���±�־λ
                string strSql = "update messages_center set PType='��Ա��Ϣ���',PGuid='" + Request["RowGuid"] + "' where MessageItemGuid='" + messageGuid + "'";
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);

                //��Ӷ���
                string IsSendADSMS = ApplicationOperate.GetConfigValueByName("IsSendADSMS");
                if (IsSendADSMS == "1")
                {
                    if (dv[m]["Mobile"].ToString() != "")
                    {
                        HTSMS.SendSMS(this.DisplayName, dv[m]["DisplayName"], lblDWName.Text + "�ύ��Ա��ְ����", dv[m]["Mobile"]);
                    }
                }
            }
            AlertAjaxMessage("�ύ�ɹ�");
            WriteAjaxMessage("window.close();");
        }

        #region "��"
        /// <summary>
        /// ��ʼ��ע��������ṹ
        /// </summary>
        private void InitTree()
        {
            RegionTreeView.Nodes.Clear();
            EpointTreeNode node = new EpointTreeNode();
            DataView dv = DataBaseFunc.Instace.GetTree("29b7967e-8098-42d5-8b40-ec757b0865a5", "");
            DataView dvCopy = dv.Table.Copy().DefaultView;
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode(dv[i]["ItemText"].ToString(), dv[i]["ItemCode"].ToString());
                DataView dv2 = DataBaseFunc.Instace.GetTreeLevelTwo(dv[i]["ItemCode"].ToString(), "29b7967e-8098-42d5-8b40-ec757b0865a5", "");
                if (dv2.Count > 0)
                {
                    node.PopulateOnDemand = true;
                    node.ShowInputCtrl = true;//��Щû��ע��רҵ�������Ļ�Ҳ��ѡ��
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

            dv = DataBaseFunc.Instace.GetTreeLevelTwo(nodeArg.Value, "29b7967e-8098-42d5-8b40-ec757b0865a5", "");
            for (i = 0; i < dv.Count; i++)
            {
                nodeVar = new EpointTreeNode(dv[i]["ItemText"].ToString(), dv[i]["ItemCode"].ToString());   //ʵ����һ���ڵ�
                DataView dv2 = DataBaseFunc.Instace.GetTreeLevelTwo(dv[i]["ItemCode"].ToString(), "29b7967e-8098-42d5-8b40-ec757b0865a5", "");
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
