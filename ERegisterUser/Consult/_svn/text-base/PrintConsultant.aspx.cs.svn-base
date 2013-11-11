using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Epoint.Frame.Bizlogic;
using Epoint.RegisterUser.Bizlogic.Consult;

namespace EpointRegisterUser.Consult
{
    public partial class PrintConsultant : System.Web.UI.Page
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
                trfenfa.Visible = false;
                trfenfadate.Visible = false;

                string HistoryGuid = Request.QueryString["HistoryGuid"];
                Detail_RG_ConsultHistory ConsultHistory = mana.GetDetail(HistoryGuid);

                #region 初始化ConsultHistory页面信息

                lblXjbh.Text = ConsultHistory.Consultflowsn;
                
                lblSubject.Text = ConsultHistory.Subject;
                lblSex.Text = ConsultHistory.Sex;
                lblPostUserName.Text = ConsultHistory.PostUserName;
                lblPostDate.Text = ConsultHistory.PostDate.ToString("yyyy-MM-dd");
                lblPhone.Text = ConsultHistory.Tel;
                lblEmail.Text = ConsultHistory.Email;
                lblAddress.Text = ConsultHistory.Address;
                lblContent.Text = ConsultHistory.Content;
                lblUserIP.Text = ConsultHistory.UserIP;

                

                if (ConsultHistory.IsDelete)
                {
                    lblHandled.Text = "暂不处理";
                }
                else
                {
                    lblHandled.Text = mana.SelectAllHandleStr(HistoryGuid).Replace("<p>", "<div>").Replace("</p>", "</div>");//处理情况
                }

                #endregion

                Detail_RG_ConsultBox DetailBox = BoxMana.GetDetail(ConsultHistory.UserSendToBoxGuid);

                lblBoxName.Text = DetailBox.BoxName;

                int Row_ID = Convert.ToInt32(Request.QueryString["Row_ID"]);
                Detail_RG_ConsultHandle ConsultHandle = mana.GetDetailHanDle(Row_ID);

                lblReplyOption.Text = ConsultHandle.strComment;

                if (ConsultHandle.HandleStatus != 2 && ConsultHandle.HandleStatus != 3)//已退回、已转发 操作按钮都不可见
                {
                    if (DetailBox.NeedAudit == 1)//不启用信访局过滤
                    {
                        #region 分发意见

                        trfenfa.Visible = true;
                        trfenfadate.Visible = true;
                        lbzfcomment.Text = ConsultHandle.strFenfaComment;
                        lblFenfaDate.Text = ConsultHandle.dtFenfaDate.ToString("yyyy-MM-dd");

                        #endregion
                        
                    }
                }

            }
        }
    }
}
