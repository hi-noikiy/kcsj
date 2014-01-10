using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Epoint.Frame.Common;
using Epoint.Frame.Bizlogic;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace HTProject
{
    public partial class Login : Epoint.Frame.Bizlogic.BasePage
    {
        Epoint.RegisterUser.Front.Bizlogic.RegisterUser.RegisterUser rgUser = new Epoint.RegisterUser.Front.Bizlogic.RegisterUser.RegisterUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Title = "";
                string systemName = ApplicationOperate.SystemName;
                if (systemName == "")
                {
                    this.Title = "协同办公系统";
                }
                this.Title = systemName;
                lblSysName.Text = systemName;
                //CreatImg();
            }
        }



        /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="RGUserGuid"></param>
        /// <param name="RGUserName"></param>
        private void RG_Login(string RGLoginID)
        {

            #region
            rgUser.RefreshSession(RGLoginID);
            FormsAuthentication.SetAuthCookie(HttpUtility.UrlEncode(account.Value), false);
            //保存登录名到HttpCookie
            HttpCookie cookie1 = new HttpCookie("RegisterUser_LoginID");
            cookie1.Value = HttpUtility.UrlEncode(account.Value);
            DateTime dtNow = DateTime.Now;
            TimeSpan tsMinute = new TimeSpan(1000, 0, 0, 0);
            cookie1.Expires = dtNow + tsMinute;
            Response.AppendCookie(cookie1);

            //CopyMail();
            LoginRecord();
            //InitOnlineChatSession();
            string FramePageUrl = ApplicationOperate.GetConfigValueByName("RegisterUser_FramePageUrl");
            if (FramePageUrl == "")
                FramePageUrl = "../../Pages/Frame2/Default.aspx";

            Response.Redirect(FramePageUrl);
            #endregion
        }

        private void LoginRecord()
        {
            int EnableDays;
            // EnableDays = Convert.ToInt32(Epoint.Frame.Bizlogic.Frame_Config.GetConfigValue("RGLoginEnableTime","180"));
            EnableDays = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["RGLoginEnableTime"]);
            if (EnableDays == 0)
                EnableDays = 180;//默认距当前180天
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            DateTime dt = DateTime.Now.AddDays(0 - EnableDays);
            // 清除离现在较久的登陆记录，防止RG_Login表过大
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "DELETE FROM RG_Login WHERE LoginTime<@LoginTime" :
                "DELETE FROM RG_Login WHERE LoginTime<:LoginTime");
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "LoginTime", DbType.DateTime, dt);
            db.ExecuteNonQuery(cmd);

            string RowGuid = Guid.NewGuid().ToString();
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Login", RowGuid);
            oRow["RGGuid"] = rgUser.GetCurrentRegisterUser().RegisterUserGuid;
            oRow["LoginTime"] = System.DateTime.Now.ToString();
            oRow["IsLoginSuccess"] = 1;
            oRow["Message"] = "成功登陆";
            oRow.Insert();
        }

        protected void LoginSys_Click(object sender, ImageClickEventArgs e)
        {



            // 判断验证码是否正确

            if (Request.Cookies["checkCode"].Value.ToLower() != userauthcode.Value.Trim().ToLower())
            {
                AlertAjaxMessage("您输入的验证码不正确!!");
                //CreatImg();
                WriteAjaxMessage("window.location=window.location;");
                return;
            }
            //}

            //string Hurl = Request.Url.Host;
            //if(Hurl

            //判断当前用户是否能正常登录
            string RegisterUserRow_ID = "";

            Session["USBKeyLogin"] = "0";
            string strSql = "select * from RG_User where LoginID='" + account.Value + "' and IsValid='0' and DelStatus='1' and DelFlag='1' ";
            //if (ViewState["LoginNeedVlidate"].ToString() == "1")
            //{
            //    strSql += " and VerifyCode is not null";
            //}
            //判断是否是未激活的账号
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            Boolean needActivate = dv.Count > 0;
            if (needActivate)
            {
                //string url = "RG_UserActivation.aspx?UserGuid=" + dv[0]["RowGuid"].ToString();
                AlertAjaxMessage("本帐号未激活，请联系管理员");
                return;
            }
            //判断有没有加密锁，如果有的话，就提示用加密锁登录
            strSql = "select PINCode from RG_User where LoginID='" + account.Value + "' ";
            string PINCode = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            if (PINCode.Length > 0)
            {
                //WriteAjaxMessage("alert('您已经有加密锁，请通过加密锁登录！');");
                //WriteAjaxMessage("window.location='epasslogin.aspx';");
                //return;
            }
            //判断当前用户是否已经配置key，如果已配置，则检查当前系统是否启用了key，如果启用了key，再检查是否配置了不运行普通登录
            RegisterUserRow_ID = rgUser.RegisterUserLogin(account.Value, common.authPassword(password.Value));



            if (RegisterUserRow_ID == "")
            {
                #region      登录失败情况下，给用户的提示
                if (Convert.ToInt32(ViewState["LoginErrorTimes"]) != 0)
                {
                    if (Convert.ToInt32(ViewState["ErrorTimes"]) >= Convert.ToInt32(ViewState["LoginErrorTimes"]))
                    {
                        WriteAjaxMessage("alert('您的密码或者验证码已经输错超过了3次，系统将自动关闭！');window.close();");
                        string RowGuid = Guid.NewGuid().ToString();
                        Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Login", RowGuid);
                        oRow["RGGuid"] = account.Value;
                        oRow["LoginTime"] = System.DateTime.Now.ToString();
                        oRow["IsLoginSuccess"] = 0;
                        oRow["Message"] = "" + account.Value + "的密码或验证码输错了3次，系统自动关闭！";
                        oRow.Insert();
                        return;
                    }
                    else
                    {
                        AlertAjaxMessage("系统不能完成您的登录请求，请检查您的用户名和密码是否匹配！");
                        WriteAjaxMessage("window.location=window.location;");
                    }

                    ViewState["ErrorTimes"] = Convert.ToInt32(ViewState["ErrorTimes"]) + 1;
                    //if (ViewState["LoginNeedVlidate"].ToString() == "1")
                    //    CreatImg();
                    return;
                }
                else
                {

                    AlertAjaxMessage("系统不能完成您的登录请求，请检查您的用户名和密码是否匹配！");
                    WriteAjaxMessage("window.location=window.location;");
                    //if (ViewState["LoginNeedVlidate"].ToString() == "1")
                    //    CreatImg();
                    return;
                }
                #endregion
            }
            else
            {
                //RG_Login(RegisterUserRow_ID, txtUserName.Value);
                RG_Login(account.Value);
            }

        }
    }


}
