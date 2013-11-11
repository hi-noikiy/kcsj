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
using Epoint.Frame.Bizlogic.UserManage;
using Epoint.Frame.Bizlogic;

namespace EpointRegisterUser.Consult
{
    public partial class HandleConsultantToXinFang : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        OU dept = new OU();

        Db_ConsultBoxMana BoxMana = new Db_ConsultBoxMana();
        Db_ConsultMana mana = new Db_ConsultMana();

        private string ConsultHandleDateSpan = Frame_Config.GetConfigValue("ConsultHandleDateSpan","10");//new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("ConsultHandleDateSpan").ConfigValue;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.CurrentPosition = "�ż�����";

               // btnChange.Visible = false;
                BtnDel.Visible = false;
                BtnZbcl.Visible = false;
                BtnHfcl.Visible = false;
                BtnOk.Visible = false;
                btnReply.Visible = false;

                string HistoryGuid = Request.QueryString["HistoryGuid"];
                Detail_RG_ConsultHistory ConsultHistory = mana.GetDetail(HistoryGuid);
                Detail_RG_ConsultBox ConsultBoxDetail = BoxMana.GetDetail(ConsultHistory.UserSendToBoxGuid);
                ViewState["UserSendToBoxGuid"] = ConsultHistory.UserSendToBoxGuid;
                treeSendToBox.Value = ConsultHistory.UserSendToBoxGuid;
                treeSendToBox.Text = ConsultBoxDetail.BoxName;


                #region ��ʼ��ҳ����Ϣ
                if (string.IsNullOrEmpty(ConsultHandleDateSpan))
                    throw new Exception("û������ϵͳ������ConsultHandleDateSpan");

                int HandleDays = ConsultBoxDetail.HandleDays;
                DateTime PostDate=ConsultHistory.PostDate;
                DateTime dt = DateTime.Now;
                //DateTime HandleEndDate = new Epoint.Frame.Webbuilder.Bizlogic.WorkingDay.DB_WorkingDay().GetEndWorkingDate(dt, HandleDays);
                //txtEndDate.Text = HandleEndDate.ToString("yyyy-M-d");
                txtEndDate.Text = PostDate.AddDays(HandleDays).ToString("yyyy-M-d");
                spnbeizhu.InnerText = "��������ֹ���ڻظ����㳬ʱ�ظ���Ĭ�Ͻ�ֹ�������ַ��������" + HandleDays + "�������ա���";

                lblSubject.Text = ConsultHistory.Subject;
               // lblSex.Text = ConsultHistory.Sex;
                lblPostUserName.Text = ConsultHistory.PostUserName;
                lblPostDate.Text = ConsultHistory.PostDate.ToString();
                //lblPhone.Text = ConsultHistory.Tel;
                //lblEmail.Text = ConsultHistory.Email;
                //lblAddress.Text = ConsultHistory.Address;
                txtContent.Text = ConsultHistory.Content;
                //txtReplyOption.Text = ConsultHistory.ReplyOpinion;
                lblIP.Text = ConsultHistory.UserIP;

                if (ConsultHistory.PublishOnWeb)
                {
                    lblToWeb.Text = "����������";
                }
                else
                {
                    lblToWeb.Text = "������";
                }

                /// �ж��Ƿ��������Ϸ�����
                if (new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("Consult_EnablePubAtReply").ConfigValue == "1" || ConsultHistory.InfoStatus==9)
                {
                    if (ConsultHistory.PublishOnWeb)
                        RblPublishOnweb.SelectedIndex = 0;
                    else
                        RblPublishOnweb.SelectedIndex = 1;
                }

                ViewState["ReplyType"] = ConsultHistory.ReplyType == "��վ�ظ�" ? 2 : 1;

                RblType.SelectedIndex = RblType.Items.IndexOf(RblType.Items.FindByValue(ConsultHistory.ReplyType));

                if (ConsultHistory.IsDelete)
                {
                    lblHandled.Text = "�ݲ�����";
                }
                else
                {
                    lblHandled.Text = mana.SelectAllHandleStr(HistoryGuid);//�������
                }

                #endregion

                if (ConsultHistory.IsDelete)//�ָ�����ť�ɼ�
                {
                    BtnHfcl.Visible = true;
                }
                else
                {
                    if (ConsultHistory.InfoStatus == 0)//��ʼʱ����ֱ��ͬ�⴦��
                    {
                        BtnOk.Visible = true;
                        BtnZbcl.Visible = true;
                        BtnDel.Visible = true;
                    }

                    //btnChange.Visible = true;


                    txtReplyOption.Text = ConsultHistory.ReplyOpinion;

                    if (Convert.ToDateTime("0001-1-1 0:00:00") == ConsultHistory.HandleDate)//��û�д���
                    {
                        DataView dvHandle = mana.SelectAllHandle(HistoryGuid);
                        ViewState["AlowSendaAgain"] = "";
                        if (dvHandle.Count > 0)
                        {
                            // dvHandle.RowFilter = "HandleDate is not null and BoxGuid<>''";
                            //if (dvHandle.Count == 0)
                            //{//�Ѿ��ַ� �ڻ�û����ǰ��������ת��
                           // btnChange.Text = "���·ַ�";
                            ViewState["AlowSendaAgain"] = "���·ַ�";
                        }
                    }
                    else//�Ѿ�����
                    {
                       // btnChange.Visible = false;
                        BtnOk.Visible = false;
                    }
                    btnReply.Visible = true;

                }

                /// �ж��Ƿ��� �ظ���ʽ
                if (new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("Consult_EnableReplyType").ConfigValue == "1")
                {
                    trReplyType.Visible = true;
                }
                else
                {
                    trReplyType.Visible = false;
                }


            }
            else
            {
                Epoint.Common.Log.WriteLog(Request.Form["txtPostBack"]);
                if (Request.Form["__EVENTTARGET"] == "ReSend")//�ż��ַ�
                {
                    string HistoryGuid = Request.QueryString["HistoryGuid"];
                    mana.UpdateUserSendToBox(HistoryGuid, treeSendToBox.Value);

                    if (ViewState["AlowSendaAgain"].ToString() == "���·ַ�")//ɾ��δ���������
                    {
                        mana.DeleteNotHandle(HistoryGuid);
                    }

                    string[] RetValue = Request.Form["__EVENTARGUMENT"].Split('��');
                    string[] BoxGuidList = RetValue[0].Split(';');

                    int SelectNum = 0;//ѡ�������
                    for (int i = 0; i < BoxGuidList.Length; i++)
                    {
                        if (BoxGuidList[i] != "")
                        {
                            SelectNum += 1;
                        }
                    }

                    string Typr = "��ͨ��";
                    if (SelectNum > 1)
                    {
                        Typr = "�����";
                    }

                    for (int i = 0; i < BoxGuidList.Length; i++)//��Ӵ����¼
                    {
                        if (BoxGuidList[i] != "")
                        {
                            mana.InsertHandle(BoxGuidList[i], HistoryGuid, Typr, "", RetValue[2], Session["UserGuid"].ToString(), 0, Convert.ToDateTime(txtEndDate.Text + " " + DateTime.Now.ToShortTimeString()));
                        }
                    }
                    mana.UpdateReplyType(HistoryGuid, RetValue[1]);
                    mana.Update(HistoryGuid, 1);
                    WriteAjaxMessage("refreshParent(\"\");window.close();");
                }
            }

            if (string.IsNullOrEmpty(Frame_Config.GetConfigValue("Consult_UserSendToGroup")))
            {
                AddTopNodes();
            }
            else
            {
                AddGroupNodes();

            }
        }
        /// <summary>
        /// �õ����������
        /// </summary>
        private void AddTopNodes()
        {
            Db_ConsultMana mana = new Db_ConsultMana();
            bool isNeedCheck = new Db_ConsultMana().GetDetail(Request.QueryString["HistoryGuid"]).InfoStatus == 0 ? false : true;

            EpointTreeNode node;
            DataView dvBox = BoxMana.BoxSelectAll();//ѡ�����е�����
            DataView dvGroup = BoxMana.BoxGroupSelectAll();//ѡ�����е��������

            //ѭ�������������ڵ�
            for (int i = 0; i < dvGroup.Count; i++)
            {
                node = new EpointTreeNode();
                node.Text = dvGroup[i]["BoxGroupName"].ToString();
                node.Value = dvGroup[i]["BoxGroupID"].ToString();
                dvBox.RowFilter = "BoxGroupID='" + dvGroup[i]["BoxGroupID"] + "'";//�ж������Ƿ�������
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
                        node.ChildNodes.Add(newnode);
                    }
                }
                treeSendToBox.Nodes.Add(node);
            }
        }
        /// <summary>
        /// �õ����������
        /// </summary>
        private void AddGroupNodes()
        {
            Db_ConsultMana mana = new Db_ConsultMana();

            EpointTreeNode node;
            DataView dvBox = BoxMana.BoxSelectAll();//ѡ�����е�����

            string tmpBoxGroupID = "";

            if ("TopGroup" == Frame_Config.GetConfigValue("Consult_UserSendToGroup"))
            {

                tmpBoxGroupID = BoxMana.GetDetail(treeSendToBox.Value).BoxGroupID;
            }
            else
            {
                tmpBoxGroupID = Frame_Config.GetConfigValue("Consult_UserSendToGroup");
            }

            string[] BoxGroupIDs = tmpBoxGroupID.Split('|');
            foreach (string BoxGroupID in BoxGroupIDs)
            {
                if (string.IsNullOrEmpty(BoxGroupID))
                    continue;
                node = new EpointTreeNode();
                Detail_RG_ConsultBoxGroup boxgroup= BoxMana.BoxGroupGetDetail(BoxGroupID);

                node.Text = boxgroup.BoxGroupName;
                node.Value = boxgroup.BoxGroupID;
                node.ShowInputCtrl = false;

                dvBox.RowFilter = "BoxGroupID='" + BoxGroupID + "'";//�ж������Ƿ�������
                if (dvBox.Count > 0)
                {
                    EpointTreeNode newnode;
                    for (int j = 0; j < dvBox.Count; j++)
                    {
                        newnode = new EpointTreeNode();
                        newnode.ShowInputCtrl = true;
                        newnode.Text = dvBox[j]["BoxName"].ToString();
                        newnode.Value = dvBox[j]["BoxGuid"].ToString();
                        node.ChildNodes.Add(newnode);
                    }
                }
                treeSendToBox.Nodes.Add(node);
            }

        }


        /// <summary>
        /// ɾ���ż�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            mana.DeleteAll(Request.QueryString["HistoryGuid"]);
            WriteScript("refreshParent(\"\");window.close();");
        }

        /// <summary>
        /// �ݲ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnZbcl_Click(object sender, EventArgs e)
        {
            mana.UpdateIsDelete(Request.QueryString["HistoryGuid"], true);
            WriteScript("refreshParent(\"\");window.close();");
        }

        /// <summary>
        /// �ָ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnHfcl_Click(object sender, EventArgs e)
        {
            mana.UpdateIsDelete(Request.QueryString["HistoryGuid"], false);
            WriteScript("refreshParent(\"\");window.location=window.location;");
        }
        /// <summary>
        /// ͬ�⴦��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnOk_Click(object sender, EventArgs e)
        {

            DateTime Times = DateTime.Now;
            string Typr = "��ͨ��";
            string HistoryGuid = Request.QueryString["HistoryGuid"];
            mana.InsertHandle(treeSendToBox.Value, HistoryGuid, Typr, "", "", "", 0, Convert.ToDateTime(txtEndDate.Text + " " + DateTime.Now.ToShortTimeString()));
            mana.UpdateReplyType(HistoryGuid, RblType.SelectedValue);
            mana.UpdatePublishOnWeb(HistoryGuid, RblPublishOnweb.SelectedIndex == 0 ? true : false);
            mana.Update(HistoryGuid, 1);
            mana.UpdateUserSendToBox(HistoryGuid, treeSendToBox.Value);
            WriteScript("refreshParent(\"\");window.close();");
        }


        /// <summary>
        /// ֱ�ӻظ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReply_Click(object sender, EventArgs e)
        {
            if (txtReplyOption.Text == "")
            {
                AlertAjaxMessage("������ظ����");
            }
            if (txtReplyOption.Text != "")
            {
                DateTime Times = DateTime.Now;
                string Typr = "��ͨ��";
                string HistoryGuid = Request.QueryString["HistoryGuid"];
                Detail_RG_ConsultHistory historyDetail = mana.GetDetail(HistoryGuid);
                mana.UpdateUserSendToBox(HistoryGuid, treeSendToBox.Value);
                DataView handleDV = mana.SelectAllHandle(HistoryGuid);
                if (handleDV.Count == 0)
                {
                    // �ż��������ַ���ֱ�Ӿͻظ�
                    mana.InsertHandle(treeSendToBox.Value, HistoryGuid, Typr, "", "", "", 0, Convert.ToDateTime(txtEndDate.Text + " " + DateTime.Now.ToShortTimeString()));
                    mana.UpdateHandle(HistoryGuid, treeSendToBox.Value, Times, txtReplyOption.Text, Session["UserGuid"].ToString());//�����Լ��İ�������
                    mana.UpdateHandleStatus(HistoryGuid, treeSendToBox.Value, 9);
                }
                else
                {
                    // �ż��Ѿ��ַ�
                    handleDV.RowFilter = "HandleStatus=9";
                    if (handleDV.Count == 0)
                    { 
                        // û�лظ�
                        mana.InsertHandle(treeSendToBox.Value, HistoryGuid, Typr, "", "", "", 0, Convert.ToDateTime(txtEndDate.Text + " " + DateTime.Now.ToShortTimeString()));
                        mana.UpdateHandle(HistoryGuid, treeSendToBox.Value, Times, txtReplyOption.Text, Session["UserGuid"].ToString());//�����Լ��İ�������
                        mana.UpdateHandleStatus(HistoryGuid, treeSendToBox.Value, 9);
                    }
                }

                mana.UpdateOver(HistoryGuid, Times, Session["DisplayName"].ToString(),
                           txtReplyOption.Text, RblType.SelectedValue, RblPublishOnweb.SelectedIndex == 0 ? true : false);//���ż�����

                mana.UpdateReplyType(HistoryGuid, RblType.SelectedValue);
                mana.UpdatePublishOnWeb(HistoryGuid, RblPublishOnweb.SelectedIndex == 0 ? true : false);
                mana.Update(HistoryGuid, 9);
                //if(RblPublishOnweb.SelectedIndex == 0)
                    //AddCatch();
            }
            WriteScript("refreshParent(\"\");window.close();");
        }

        /// <summary>
        /// �����޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string HistoryGuid = Request.QueryString["HistoryGuid"];
            Detail_RG_ConsultHistory historyDetail = mana.GetDetail(HistoryGuid);
            mana.UpdateUserSendToBox(HistoryGuid, treeSendToBox.Value);

            mana.UpdateOver(HistoryGuid, Session["DisplayName"].ToString(),
                txtReplyOption.Text, RblType.SelectedValue, RblPublishOnweb.SelectedIndex == 0 ? true : false);//���ż�����

            mana.UpdateReplyType(HistoryGuid, RblType.SelectedValue);
            mana.UpdatePublishOnWeb(HistoryGuid, RblPublishOnweb.SelectedIndex == 0 ? true : false);
            WriteScript("refreshParent(\"\");window.close();");
        }


        private bool HaveRightToProcess()
        {
            DataView dvRight = BoxMana.SelectHandleUser(treeSendToBox.Value);
            string FilterStr = "(HandleType='P' and HandleDetail='" + Session["UserGuid"].ToString() + "') ";
            string OuGuid = Session["OuGuid"].ToString();
            while (OuGuid != "")
            {
                FilterStr += " or (HandleType='D' and HandleDetail='" + OuGuid + "') ";
                OuGuid = dept.GetDetail(OuGuid).ParentOUGuid;
            }
            dvRight.RowFilter = FilterStr;

            return dvRight.Count > 0;
        }


        /// <summary>
        /// ֪ͨϵͳ������ҳ��
        /// </summary>
        //protected void AddCatch()
        //{
        //    //������ҳ��̬ҳ��
        //    DB_NeedRemoveCache DBCache = new DB_NeedRemoveCache();
        //    DBCache.ConnectionString = Epoint.WebbuilderInfo.Bizlogic.Conn.GetConnectionStringName("WebbuilderConsult_ConnectionString");
        //    if (DBCache.CheckNeedReWrite("Home") == false)
        //        DBCache.Insert("Home");
        //}
    }
}
