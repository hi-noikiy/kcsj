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
using Epoint.Frame.Bizlogic;
namespace EpointRegisterUser.Consult
{
    public partial class HandleConsultant : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Db_ConsultBoxMana BoxMana = new Db_ConsultBoxMana();
        Db_ConsultMana mana = new Db_ConsultMana();

        // 允许直接在回复的时候直接发布到网上，回复状态为9， 不允许直接回复，回复状态为8
        private int handledStatusCode = Frame_Config.GetConfigValue("Consult_EnablePubAtReply") == "1" ? 9 : 8;

        private string ConsultHandleDateSpan = new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("ConsultHandleDateSpan").ConfigValue;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.CurrentPosition = "咨询回复";

                BtnDel.Visible = false;
                BtnReply.Visible = false;
                btnSave.Visible = false;
                btnBack.Visible = false;
                BtnChange.Visible = false;
                BtnZbcl.Visible = false;
                BtnHfcl.Visible = false;

                trfenfa.Visible = false;
                trfenfadate.Visible = false;

                string HistoryGuid = Request.QueryString["HistoryGuid"];
                Detail_RG_ConsultHistory ConsultHistory = mana.GetDetail(HistoryGuid);

                #region 初始化ConsultHistory页面信息

                lblSubject.Text = ConsultHistory.Subject;
                //lblSex.Text = ConsultHistory.Sex;
                lblPostUserName.Text = ConsultHistory.PostUserName;
                lblPostDate.Text = ConsultHistory.PostDate.ToString();
                //lblPhone.Text = ConsultHistory.Tel;
                //lblEmail.Text = ConsultHistory.Email;
                //lblAddress.Text = ConsultHistory.Address;
                txtContent.Text = ConsultHistory.Content;
                lblUserIP.Text = ConsultHistory.UserIP;

                if (ConsultHistory.PublishOnWeb)
                    RblPublishOnweb.SelectedIndex = 0;
                else
                    RblPublishOnweb.SelectedIndex = 1;
                
                if (ConsultHistory.ReplyType == "网站回复")
                {
                    Rdo_HuiFu.SelectedIndex = 1;
                }

                if (ConsultHistory.IsDelete)
                {
                    lblHandled.Text = "暂不处理";
                }
                else
                {
                    lblHandled.Text = mana.SelectAllHandleStr(HistoryGuid);//处理情况
                }

                #endregion

                Detail_RG_ConsultBox DetailBox = BoxMana.GetDetail(ConsultHistory.UserSendToBoxGuid);

                int Row_ID = Convert.ToInt32(Request.QueryString["Row_ID"]);
                Detail_RG_ConsultHandle ConsultHandle = mana.GetDetailHanDle(Row_ID);

                ViewState["ReplayType"] = ConsultHandle.HandleType;
                ViewState["BoxGuid"] = ConsultHandle.BoxGuid;

                txtReplyOption.Text = ConsultHandle.strComment;

                if (ConsultHandle.HandleStatus != 2 && ConsultHandle.HandleStatus != 3)//已退回、已转发 操作按钮都不可见
                {
                    if (ConsultHandle.HandleStatus == handledStatusCode)//已处理 保存按钮可见
                    {
                        btnSave.Visible = true;
                    }

                    if (DetailBox.NeedAudit == 0)//不启用信访局过滤
                    {
                        if (ConsultHistory.IsDelete)//恢复处理按钮可见
                        {
                            BtnHfcl.Visible = true;
                        }
                        else
                        {
                            BtnZbcl.Visible = true;

                            if (ConsultHandle.HandleStatus == 0)//未处理 转发、回复按钮可见
                            {
                                BtnReply.Visible = true;
                                BtnChange.Visible = true;

                                if (ConsultHistory.UserSendToBoxGuid == ConsultHandle.BoxGuid)
                                {
                                    BtnDel.Visible = true;
                                }
                            }
                        }
                    }
                    else//启用信访局过滤 只能回复和退回
                    {
                        #region 分发意见

                        trfenfa.Visible = true;
                        trfenfadate.Visible = true;
                        lbzfcomment.Text = ConsultHandle.strFenfaComment;
                        lblFenfaDate.Text = ConsultHandle.dtFenfaDate.ToString("yyyy-MM-dd");

                        #endregion

                        if (ConsultHandle.HandleStatus == 0)//ConsultHandle.HandleStatus
                        {
                            BtnReply.Visible = true;
                            btnBack.Visible = true;
                        }
                    }
                }
                /// 判断是否现在网上发布行
                if (new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("Consult_EnablePubAtReply").ConfigValue == "1")
                {
                    trIsPub.Visible = true;
                }
                else
                {
                    trIsPub.Visible = false;
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
                if (Request.Form["__EVENTTARGET"] == "SendBack")
                {
                    if (Request.Form["__EVENTARGUMENT"] != "")
                    {
                        //mana.InsertHandle("", Request.QueryString["HistoryGuid"], "普通件", "","","",2);//添加一条退回的记录
                        mana.UpdateHandle(Convert.ToInt32(Request.QueryString["Row_ID"]), DateTime.Now, Request.Form["__EVENTARGUMENT"], Session["UserGuid"].ToString());//结束自己的办理流程
                        mana.Update(Request.QueryString["HistoryGuid"], 2);
                        mana.UpdateHandleStatus(Convert.ToInt32(Request.QueryString["Row_ID"]), 2);
                        WriteAjaxMessage("refreshParent(\"\");window.close();");
                    }
                }
                if (Request.Form["__EVENTTARGET"] == "ReSend")//转发信件
                {
                    string AllInfo = Request.Form["__EVENTARGUMENT"];
                    if (AllInfo.IndexOf('★') > -1)
                    {
                        string BoxGuid = AllInfo.Split('★')[0].ToString();
                       // AlertAjaxMessage(BoxGuid);
                        string NoticeInfo = AllInfo.Replace(BoxGuid + "★", "");

                        int HandleDays = BoxMana.GetDetail(BoxGuid).HandleDays;
                        DateTime dt = DateTime.Now;
                        //DateTime HandleEndDate = new Epoint.Frame.Webbuilder.Bizlogic.WorkingDay.DB_WorkingDay().GetEndWorkingDate(dt, HandleDays)
                        DateTime HandleEndDate = dt.AddDays(HandleDays);
                        mana.InsertHandle(BoxGuid, Request.QueryString["HistoryGuid"], "普通件", "", "", "", 0, HandleEndDate);//添加一个待处理信息
                        mana.UpdateHandle(Convert.ToInt32(Request.QueryString["Row_ID"]), DateTime.Now, NoticeInfo, Session["UserGuid"].ToString());//结束自己的办理流程
                        mana.UpdateHandleStatus(Convert.ToInt32(Request.QueryString["Row_ID"]),3);
                        WriteAjaxMessage("refreshParent(\"\");window.close();");
                    }
                }
            }
        }

        /// <summary>
        /// 回复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnReply_Click(object sender, EventArgs e)
        {
            if (txtReplyOption.Text != "")
            {
                string HistoryGuid = Request.QueryString["HistoryGuid"];
                DateTime Times = DateTime.Now;
                mana.UpdateHandle(Convert.ToInt32(Request.QueryString["Row_ID"]), Times, txtReplyOption.Text, Session["UserGuid"].ToString());//结束自己的办理流程
                mana.UpdateHandleStatus(Convert.ToInt32(Request.QueryString["Row_ID"]), 9);
                if (ViewState["ReplayType"].ToString() != "普通件")//联办件传给了多个人，需要全部办完才结束
                {
                    Detail_RG_ConsultHistory detialHt = mana.GetDetail(HistoryGuid);
                    string BoxName = BoxMana.GetDetail(ViewState["BoxGuid"].ToString()).BoxName;
                    string ReplatOption = detialHt.ReplyOpinion + "<br>" + BoxName + "：" + txtReplyOption.Text + "<br>&nbsp;";

                    if (mana.SelectIFHandleOver(HistoryGuid))//全部办理完
                    {
                        mana.UpdateOver(HistoryGuid, Times, detialHt.HandleUser + Session["DisplayName"].ToString() + ";",
                        ReplatOption, Rdo_HuiFu.SelectedValue, RblPublishOnweb.SelectedIndex == 0 ? true : false);//将信件结束
                        mana.Update(Request.QueryString["HistoryGuid"], handledStatusCode);
                    }
                    else//没办理完 仅更新办理人 和办理意见 和回复方式
                    {
                        mana.UpdateOver(HistoryGuid, detialHt.HandleUser + Session["DisplayName"].ToString() + ";",
                       ReplatOption, Rdo_HuiFu.SelectedValue, RblPublishOnweb.SelectedIndex == 0 ? true : false);
                    }
                }
                else//普通件一个人办完就结束
                {
                    mana.UpdateOver(HistoryGuid, Times, Session["DisplayName"].ToString(),
                        txtReplyOption.Text, Rdo_HuiFu.SelectedValue, RblPublishOnweb.SelectedIndex == 0 ? true : false);//将信件结束
                    mana.Update(Request.QueryString["HistoryGuid"], handledStatusCode);
                }

                mana.UpdateAfterOver(HistoryGuid, lblSubject.Text, txtContent.Text,
                         txtReplyOption.Text, RblPublishOnweb.SelectedIndex == 0 ? true : false, Rdo_HuiFu.SelectedValue);
            }
            //AddCatch();
            WriteScript("refreshParent(\"\");window.close();");
        }

        //已处理信息的后期修改
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            DateTime Times = DateTime.Now;
            string HistoryGuid = Request.QueryString["HistoryGuid"];
            mana.UpdateAfterOver(HistoryGuid, lblSubject.Text, txtContent.Text,
                         txtReplyOption.Text, RblPublishOnweb.SelectedIndex == 0 ? true : false, Rdo_HuiFu.SelectedValue);
            mana.UpdateHandle(Convert.ToInt32(Request.QueryString["Row_ID"]), Times, txtReplyOption.Text, Session["UserGuid"].ToString());//更新流程里的办理意见
            //AddCatch();
            WriteScript("refreshParent(\"\");window.close();");
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

        protected void BtnZbcl_Click(object sender, EventArgs e)//不处理
        {
            mana.UpdateDelete(Request.QueryString["HistoryGuid"], true);
            WriteScript("refreshParent(\"\");window.close();");
        }

        protected void BtnHfcl_Click(object sender, EventArgs e)//恢复处理
        {
            mana.UpdateDelete(Request.QueryString["HistoryGuid"],false);
            WriteScript("refreshParent(\"\");window.location=window.location;");
        }

        ///// <summary>
        ///// 通知系统生成首页面
        ///// </summary>
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
