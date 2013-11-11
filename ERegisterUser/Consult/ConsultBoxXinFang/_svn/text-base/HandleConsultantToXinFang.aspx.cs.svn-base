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
                this.CurrentPosition = "信件处理";

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


                #region 初始化页面信息
                if (string.IsNullOrEmpty(ConsultHandleDateSpan))
                    throw new Exception("没有配置系统变量：ConsultHandleDateSpan");

                int HandleDays = ConsultBoxDetail.HandleDays;
                DateTime PostDate=ConsultHistory.PostDate;
                DateTime dt = DateTime.Now;
                //DateTime HandleEndDate = new Epoint.Frame.Webbuilder.Bizlogic.WorkingDay.DB_WorkingDay().GetEndWorkingDate(dt, HandleDays);
                //txtEndDate.Text = HandleEndDate.ToString("yyyy-M-d");
                txtEndDate.Text = PostDate.AddDays(HandleDays).ToString("yyyy-M-d");
                spnbeizhu.InnerText = "（超过截止日期回复则算超时回复，默认截止日期至分发日期相隔" + HandleDays + "个工作日。）";

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
                    lblToWeb.Text = "发布到网上";
                }
                else
                {
                    lblToWeb.Text = "不发布";
                }

                /// 判断是否现在网上发布行
                if (new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("Consult_EnablePubAtReply").ConfigValue == "1" || ConsultHistory.InfoStatus==9)
                {
                    if (ConsultHistory.PublishOnWeb)
                        RblPublishOnweb.SelectedIndex = 0;
                    else
                        RblPublishOnweb.SelectedIndex = 1;
                }

                ViewState["ReplyType"] = ConsultHistory.ReplyType == "网站回复" ? 2 : 1;

                RblType.SelectedIndex = RblType.Items.IndexOf(RblType.Items.FindByValue(ConsultHistory.ReplyType));

                if (ConsultHistory.IsDelete)
                {
                    lblHandled.Text = "暂不处理";
                }
                else
                {
                    lblHandled.Text = mana.SelectAllHandleStr(HistoryGuid);//处理情况
                }

                #endregion

                if (ConsultHistory.IsDelete)//恢复处理按钮可见
                {
                    BtnHfcl.Visible = true;
                }
                else
                {
                    if (ConsultHistory.InfoStatus == 0)//初始时可以直接同意处理
                    {
                        BtnOk.Visible = true;
                        BtnZbcl.Visible = true;
                        BtnDel.Visible = true;
                    }

                    //btnChange.Visible = true;


                    txtReplyOption.Text = ConsultHistory.ReplyOpinion;

                    if (Convert.ToDateTime("0001-1-1 0:00:00") == ConsultHistory.HandleDate)//还没有处理
                    {
                        DataView dvHandle = mana.SelectAllHandle(HistoryGuid);
                        ViewState["AlowSendaAgain"] = "";
                        if (dvHandle.Count > 0)
                        {
                            // dvHandle.RowFilter = "HandleDate is not null and BoxGuid<>''";
                            //if (dvHandle.Count == 0)
                            //{//已经分发 在还没处理前可以重新转发
                           // btnChange.Text = "重新分发";
                            ViewState["AlowSendaAgain"] = "重新分发";
                        }
                    }
                    else//已经处理
                    {
                       // btnChange.Visible = false;
                        BtnOk.Visible = false;
                    }
                    btnReply.Visible = true;

                }

                /// 判断是否现 回复方式
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
                if (Request.Form["__EVENTTARGET"] == "ReSend")//信件分发
                {
                    string HistoryGuid = Request.QueryString["HistoryGuid"];
                    mana.UpdateUserSendToBox(HistoryGuid, treeSendToBox.Value);

                    if (ViewState["AlowSendaAgain"].ToString() == "重新分发")//删除未处理的流程
                    {
                        mana.DeleteNotHandle(HistoryGuid);
                    }

                    string[] RetValue = Request.Form["__EVENTARGUMENT"].Split('★');
                    string[] BoxGuidList = RetValue[0].Split(';');

                    int SelectNum = 0;//选择的数量
                    for (int i = 0; i < BoxGuidList.Length; i++)
                    {
                        if (BoxGuidList[i] != "")
                        {
                            SelectNum += 1;
                        }
                    }

                    string Typr = "普通件";
                    if (SelectNum > 1)
                    {
                        Typr = "联办件";
                    }

                    for (int i = 0; i < BoxGuidList.Length; i++)//添加处理记录
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
                        node.ChildNodes.Add(newnode);
                    }
                }
                treeSendToBox.Nodes.Add(node);
            }
        }
        /// <summary>
        /// 得到信箱分类组
        /// </summary>
        private void AddGroupNodes()
        {
            Db_ConsultMana mana = new Db_ConsultMana();

            EpointTreeNode node;
            DataView dvBox = BoxMana.BoxSelectAll();//选择所有的邮箱

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

                dvBox.RowFilter = "BoxGroupID='" + BoxGroupID + "'";//判断组下是否有信箱
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
        /// 删除信件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            mana.DeleteAll(Request.QueryString["HistoryGuid"]);
            WriteScript("refreshParent(\"\");window.close();");
        }

        /// <summary>
        /// 暂不处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnZbcl_Click(object sender, EventArgs e)
        {
            mana.UpdateIsDelete(Request.QueryString["HistoryGuid"], true);
            WriteScript("refreshParent(\"\");window.close();");
        }

        /// <summary>
        /// 恢复处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnHfcl_Click(object sender, EventArgs e)
        {
            mana.UpdateIsDelete(Request.QueryString["HistoryGuid"], false);
            WriteScript("refreshParent(\"\");window.location=window.location;");
        }
        /// <summary>
        /// 同意处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnOk_Click(object sender, EventArgs e)
        {

            DateTime Times = DateTime.Now;
            string Typr = "普通件";
            string HistoryGuid = Request.QueryString["HistoryGuid"];
            mana.InsertHandle(treeSendToBox.Value, HistoryGuid, Typr, "", "", "", 0, Convert.ToDateTime(txtEndDate.Text + " " + DateTime.Now.ToShortTimeString()));
            mana.UpdateReplyType(HistoryGuid, RblType.SelectedValue);
            mana.UpdatePublishOnWeb(HistoryGuid, RblPublishOnweb.SelectedIndex == 0 ? true : false);
            mana.Update(HistoryGuid, 1);
            mana.UpdateUserSendToBox(HistoryGuid, treeSendToBox.Value);
            WriteScript("refreshParent(\"\");window.close();");
        }


        /// <summary>
        /// 直接回复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReply_Click(object sender, EventArgs e)
        {
            if (txtReplyOption.Text == "")
            {
                AlertAjaxMessage("请输入回复意见");
            }
            if (txtReplyOption.Text != "")
            {
                DateTime Times = DateTime.Now;
                string Typr = "普通件";
                string HistoryGuid = Request.QueryString["HistoryGuid"];
                Detail_RG_ConsultHistory historyDetail = mana.GetDetail(HistoryGuid);
                mana.UpdateUserSendToBox(HistoryGuid, treeSendToBox.Value);
                DataView handleDV = mana.SelectAllHandle(HistoryGuid);
                if (handleDV.Count == 0)
                {
                    // 信件不经过分发，直接就回复
                    mana.InsertHandle(treeSendToBox.Value, HistoryGuid, Typr, "", "", "", 0, Convert.ToDateTime(txtEndDate.Text + " " + DateTime.Now.ToShortTimeString()));
                    mana.UpdateHandle(HistoryGuid, treeSendToBox.Value, Times, txtReplyOption.Text, Session["UserGuid"].ToString());//结束自己的办理流程
                    mana.UpdateHandleStatus(HistoryGuid, treeSendToBox.Value, 9);
                }
                else
                {
                    // 信件已经分发
                    handleDV.RowFilter = "HandleStatus=9";
                    if (handleDV.Count == 0)
                    { 
                        // 没有回复
                        mana.InsertHandle(treeSendToBox.Value, HistoryGuid, Typr, "", "", "", 0, Convert.ToDateTime(txtEndDate.Text + " " + DateTime.Now.ToShortTimeString()));
                        mana.UpdateHandle(HistoryGuid, treeSendToBox.Value, Times, txtReplyOption.Text, Session["UserGuid"].ToString());//结束自己的办理流程
                        mana.UpdateHandleStatus(HistoryGuid, treeSendToBox.Value, 9);
                    }
                }

                mana.UpdateOver(HistoryGuid, Times, Session["DisplayName"].ToString(),
                           txtReplyOption.Text, RblType.SelectedValue, RblPublishOnweb.SelectedIndex == 0 ? true : false);//将信件结束

                mana.UpdateReplyType(HistoryGuid, RblType.SelectedValue);
                mana.UpdatePublishOnWeb(HistoryGuid, RblPublishOnweb.SelectedIndex == 0 ? true : false);
                mana.Update(HistoryGuid, 9);
                //if(RblPublishOnweb.SelectedIndex == 0)
                    //AddCatch();
            }
            WriteScript("refreshParent(\"\");window.close();");
        }

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string HistoryGuid = Request.QueryString["HistoryGuid"];
            Detail_RG_ConsultHistory historyDetail = mana.GetDetail(HistoryGuid);
            mana.UpdateUserSendToBox(HistoryGuid, treeSendToBox.Value);

            mana.UpdateOver(HistoryGuid, Session["DisplayName"].ToString(),
                txtReplyOption.Text, RblType.SelectedValue, RblPublishOnweb.SelectedIndex == 0 ? true : false);//将信件结束

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
        /// 通知系统生成首页面
        /// </summary>
        //protected void AddCatch()
        //{
        //    //生成首页静态页面
        //    DB_NeedRemoveCache DBCache = new DB_NeedRemoveCache();
        //    DBCache.ConnectionString = Epoint.WebbuilderInfo.Bizlogic.Conn.GetConnectionStringName("WebbuilderConsult_ConnectionString");
        //    if (DBCache.CheckNeedReWrite("Home") == false)
        //        DBCache.Insert("Home");
        //}
    }
}
