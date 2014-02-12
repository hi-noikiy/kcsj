/*
 *ͨ���ġ�����е�
 *�����ٴ��޸�
 */
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
using Epoint.Frame.Bizlogic;

namespace HTProject.Pages.RG_OU
{

    public partial class RG_OU_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 2017;
        Epoint.MisBizLogic2.Web.EditPage oEditPage;
        HTProject_Bizlogic.DataBaseFunc DBF = new DataBaseFunc();
        protected HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
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

               
                RegionTreeView.Text = RegistAddress_2017.Text;
                RegionTreeView.Value = RegistAddressCode_2017.Text;

                QY_GSZZ_Z.ClientGuid = Request["RowGuid"] + "QY_GSZZ_Z";
                QY_GSZZ_Z.ClientTag = "����Ӫҵִ��(����)";
                QY_GSZZ_Z.NodeCode = Request["RowGuid"];
                QY_GSZZ_Z.MisRowGuid = Request["RowGuid"];

                QY_GSZZ_F.ClientGuid = Request["RowGuid"] + "QY_GSZZ_F";
                QY_GSZZ_F.ClientTag = "����Ӫҵִ��(����)";
                QY_GSZZ_F.NodeCode = Request["RowGuid"];
                QY_GSZZ_Z.MisRowGuid = Request["RowGuid"];

                QY_ZZJGDMZ.ClientGuid = Request["RowGuid"] + "QY_ZZJGDMZ";
                QY_ZZJGDMZ.ClientTag = "��֯��������֤";
                QY_ZZJGDMZ.NodeCode = Request["RowGuid"];
                QY_ZZJGDMZ.MisRowGuid = Request["RowGuid"];

                QY_FRSFZ.ClientGuid = Request["RowGuid"] + "QY_FRSFZ";
                QY_FRSFZ.ClientTag = "�������������֤";
                QY_FRSFZ.NodeCode = Request["RowGuid"];
                QY_FRSFZ.MisRowGuid = Request["RowGuid"];


                QY_FRQM.ClientGuid = Request["RowGuid"] + "QY_FRQM";
                QY_FRQM.ClientTag = "����������ǩ��";
                QY_FRQM.NodeCode = Request["RowGuid"];
                QY_FRQM.MisRowGuid = Request["RowGuid"];


                QY_SBZM.ClientGuid = Request["RowGuid"] + "QY_SBZM";
                QY_SBZM.ClientTag = "��ᱣ��֤������(��6����)";
                QY_SBZM.NodeCode = Request["RowGuid"];
                QY_GSZZ_Z.MisRowGuid = Request["RowGuid"];

                QY_QYQT.ClientGuid = Request["RowGuid"] + "QY_QYQT";
                QY_QYQT.ClientTag = "��ҵ�����ļ�";
                QY_QYQT.NodeCode = Request["RowGuid"];
                QY_QYQT.MisRowGuid = Request["RowGuid"];

                lblSHOpinion.Text = RG_DW.GetSHOpinion(Request["RowGuid"], "");

            }
            InitCityTree();
        }


        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            base.OnInit(e);
        }


        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            Status_2017.Text = "85";//�����
            RegistAddress_2017.Text = RegionTreeView.Text;
            RegistAddressCode_2017.Text = RegionTreeView.Value;
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            oRow["Status"] = "85";
            oRow.Update();
            if (ApplicationOperate.GetConfigValueByName("IsHoldCurPage", "0") == "1")
                this.WriteAjaxMessage("refreshParentHoldCurPage();");
            else
                this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'���ݱ���ɹ�')");
        }

        HTProject_Bizlogic.SMS HTSMS = new SMS();
        protected void btSubmit_Click(object sender, System.EventArgs e)
        {
            //�Ƚ�ԭ����ɾ������ֹ�ظ�
            new HTProject_Bizlogic.DB_Messages_Center().DeleteWH("�����ҵ", Request["RowGuid"]);
            RegistAddress_2017.Text = RegionTreeView.Text;
            RegistAddressCode_2017.Text = RegionTreeView.Value;
            TJRGuid_2017.Text = this.UserGuid;
            //Status_2017.Text = "70";
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            oRow["Status"] = "70";
            oRow["UpdateUserName"] = this.DisplayName;
            oRow["UpdateUserGuid"] = this.UserGuid;
            oRow["UpdateTime"] = DateTime.Now.ToString();
            oRow.Update();
            //this.WriteAjaxMessage("refreshParent();");
            //this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'���ݱ���ɹ�')");
            //���ʹ�������ˣ����ݽ�ɫ��
            DataView dv = DBF.GetUserByRoleName("��ҵ��Ϣ���");

            for (int m = 0; m < dv.Count; m++)
            {
                string messageGuid = Guid.NewGuid().ToString();
                new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Insert(messageGuid,
                                    EnterpriseName_2017.Text + "��Ϣ���",
                                    "",
                                    dv[m]["UserGuid"].ToString(),
                                    dv[m]["DisplayName"].ToString(),
                                    "",
                                    "",
                                    "",
                                    @"HTProject/Pages/RG_OU/RG_OU_All_Detail.aspx?stype=shenhe&RowGuid=" + Request["RowGuid"],
                                    "",
                                    "",
                                    1,
                                    "",
                                    "",
                                    ""
                             );
                //���±�־λ
                string strSql = "update messages_center set PType='�����ҵ',PGuid='"+ Request["RowGuid"] +"' where MessageItemGuid='" + messageGuid + "'";
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);
                //��Ӷ���
                string IsSendADSMS = ApplicationOperate.GetConfigValueByName("IsSendADSMS");
                if (IsSendADSMS == "1")
                {
                    if (dv[m]["Mobile"].ToString() != "")
                    {
                        HTSMS.SendSMS(this.DisplayName, dv[m]["DisplayName"], EnterpriseName_2017.Text + "�ύ��ҵ��Ϣ���", dv[m]["Mobile"]);
                    }
                }
            }
            AlertAjaxMessage("�ύ�ɹ�");
            this.WriteAjaxMessage("refreshParent();window.close();");
        }


        #region "�йش���ע���������ط���"
        /// <summary>
        /// ��ʼ��ע��������ṹ
        /// </summary>
        private void InitCityTree()
        {
            RegionTreeView.Nodes.Clear();
            EpointTreeNode node = new EpointTreeNode();
            DataView dv = DataBaseFunc.Instace.GetCity();
            DataView dvCopy = dv.Table.Copy().DefaultView;
            dv.RowFilter = "substring(CityCode,3,4)='0000'";
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode(dv[i]["CityName"].ToString(), dv[i]["CityCode"].ToString());
                dvCopy.RowFilter = "substring(CityCode,1,2)='" + CommonFunc.Left(dv[i]["CityCode"].ToString(), 2) + "'";
                if (dvCopy.Count > 1)
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
                    node.ShowImage = false;
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
            string strLeft = "";
            DataView dv;
            int i = 0;
            if (CommonFunc.Right(nodeArg.Value, 4) == "0000")    //��һ�����صڶ���
            {
                strLeft = CommonFunc.Left(nodeArg.Value, 2);
                dv = DataBaseFunc.Instace.GetCityLevelTwo(strLeft, nodeArg.Value);
                for (i = 0; i < dv.Count; i++)
                {
                    nodeVar = new EpointTreeNode(dv[i]["CityName"].ToString(), dv[i]["CityCode"].ToString());   //ʵ����һ���ڵ�
                    nodeVar.ExpandOnCheckedChanged = true;
                    nodeVar.Checked = false;
                    nodeVar.ShowInputCtrl = false;
                    nodeVar.RunClickEvtOnInit = true;
                    nodeVar.PopulateOnDemand = true;
                    nodeVar.ReturnFullPath = true;
                    nodeVar.ShowImage = true;
                    nodeVar.SelectLeafForTextTreeView = false;
                    nodeArg.ChildNodes.Add(nodeVar);
                }
            }
            if (CommonFunc.Right(nodeArg.Value, 2) == "00")  //�ڶ������ص�����
            {
                strLeft = CommonFunc.Left(nodeArg.Value, 4);
                dv = DataBaseFunc.Instace.GetCityLevelThree(strLeft);
                for (i = 0; i < dv.Count; i++)
                {
                    nodeVar = new EpointTreeNode(dv[i]["CityName"].ToString(), dv[i]["CityCode"].ToString());   //ʵ����һ���ڵ�
                    nodeVar.ExpandOnCheckedChanged = true;
                    nodeVar.ShowInputCtrl = true;
                    if (nodeVar.Value == RegionTreeView.Value)
                    {
                        nodeVar.Checked = true;
                    }
                    else
                    {
                        nodeVar.Checked = false;
                    }
                    nodeVar.RunClickEvtOnInit = true;
                    nodeVar.PopulateOnDemand = false;
                    nodeVar.ReturnFullPath = true;
                    nodeVar.ShowImage = false;
                    nodeArg.ChildNodes.Add(nodeVar);
                }
            }
        }
        #endregion

    }
}
