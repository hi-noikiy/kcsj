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
namespace EpointRegisterUser.Pages.RG_User
{
    public partial class RG_SendMessage : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Epoint.RegisterUser.Front.Bizlogic.UserMailandSMS.UserMail usermail = new Epoint.RegisterUser.Front.Bizlogic.UserMailandSMS.UserMail();
        Epoint.RegisterUser.Front.Bizlogic.UserMailandSMS.Sipac_SMS_Send SMS_Send = new Epoint.RegisterUser.Front.Bizlogic.UserMailandSMS.Sipac_SMS_Send();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select * from RG_User where RowGuid='" + Request["UserGuid"] + "'");
            string EmailTo = dv[0]["EMail"].ToString();
            string SmtpServer = System.Configuration.ConfigurationManager.AppSettings["SmtpServer"].ToString();
            string EmailFrom = System.Configuration.ConfigurationManager.AppSettings["EmailFrom"].ToString();
            string EmailAccount = System.Configuration.ConfigurationManager.AppSettings["EmailAccount"].ToString();
            string EmailPassword = System.Configuration.ConfigurationManager.AppSettings["EmailPassword"].ToString();
            Boolean IsSendSuccess = usermail.sendMail(SmtpServer, EmailAccount, EmailPassword, EmailFrom, EmailTo, "您申请的会员账号没有审核通过，请查看原因……", Reason.Text);
            if (!IsSendSuccess)
            {
                AlertAjaxMessage("邮件发送失败！");
                return;
            }
            if (dv[0]["EnableSMS"].ToString() == "1")
            {
                string SendMobilephone = System.Configuration.ConfigurationManager.AppSettings["SendMobilephone"].ToString();
                string SystemID = System.Configuration.ConfigurationManager.AppSettings["SystemID"].ToString();
                SMS_Send.SendSMS("管理员", SendMobilephone, dv[0]["Mobile"].ToString(), Reason.Text, SystemID);
            }
            WriteAjaxMessage("rtnValue(\"\");window.close();");

        }
    }
}


