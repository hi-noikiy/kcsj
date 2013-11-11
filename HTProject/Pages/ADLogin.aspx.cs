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
using Epoint.Frame.Bizlogic.SystemInfo;
using Epoint.Frame.Bizlogic.UserManage;

namespace HTProject
{
    public partial class ADLogin : BasePage
    {
        Epoint.Frame.Bizlogic.UserManage.User user = new Epoint.Frame.Bizlogic.UserManage.User();
        DB_Frame_User_ExtendInfo db_User_ExtendInfo = new DB_Frame_User_ExtendInfo();
        //处理Ｓｅｓｓｉｏｎ恢复事件
        private void RefreshSession(object sender, RefreshSessionEventArgs e)
        {
            common.RefreshSessionFromLoginID(e.loginID);
        }
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

            //判断当前用户是否能正常登录
            bool IsSuperAdmin = false;
            bool isUsingASP = false;
            string UserGuid = "";
            string LoginID = account.Value;
            UserGuid = user.UserLogin(this.account.Value, this.password.Value, out IsSuperAdmin, out isUsingASP);


            if (UserGuid == "")
            {
                #region      登录失败情况下，给用户的提示
                if (Convert.ToInt32(ViewState["LoginErrorTimes"]) != 0)
                {


                    if (Convert.ToInt32(ViewState["ErrorTimes"]) >= Convert.ToInt32(ViewState["LoginErrorTimes"]))
                    {
                        WriteAjaxMessage("alert('您的密码或者验证码已经输错超过了3次，系统将自动关闭！');window.close();");
                        return;
                    }
                    else
                        AlertAjaxMessage("系统不能完成您的登录请求，请检查您的用户名和密码是否匹配！");

                    ViewState["ErrorTimes"] = Convert.ToInt32(ViewState["ErrorTimes"]) + 1;
                    //CreatImg();
                    return;
                }
                else
                {
                    AlertAjaxMessage("系统不能完成您的登录请求，请检查您的用户名和密码是否匹配！");
                    //CreatImg();
                    return;
                }
                #endregion
            }
            else
            {
                Login2(UserGuid, LoginID, IsSuperAdmin);
            }
        }

        private void Login2(string UserGuid, string LoginID, Boolean IsSuperAdmin)
        {
            //在登录的时候，是否检查此用户是否已登录，如已登录，则提醒。如果=1，这检查，否则不检查
            String ISSingleLogin = ApplicationOperate.GetConfigValueByName("ISSingleLogin");
            string strAlertInfo = "";
            if (ISSingleLogin == "1")
            {
                Epoint.Frame.Bizlogic.UserManage.Detail_Frame_OnlineUser d_OnlineUser = new Epoint.Frame.Bizlogic.UserManage.DB_Frame_OnlineUser().GetDetail(UserGuid);
                if (d_OnlineUser.DisplayName != null && d_OnlineUser.DisplayName != "" && d_OnlineUser.IsOnline == 1)
                {
                    strAlertInfo = "请注意：此账号已经在IP地址为：" + d_OnlineUser.LoginIP + "的机器上登录，并正在使用中！";
                }
            }

            #region 2009.03.05 增加 判断当前是启用IP和用户对应关系，如果启用，判断当前用户的IP是否设置，如果设置，检查当前用户使用的IP是否和配置相同，如果不同，则提示
            //通过参数LoginCheckingIP=1来检查是否启用此判断
            if (ApplicationOperate.GetConfigValueByName("LoginCheckingIP") == "1")
            {
                String UserAllowIP = new DB_Frame_User_ExtendInfo().GetDetail(UserGuid).LoginIP;
                if (UserAllowIP != "")
                {
                    UserAllowIP = ";" + UserAllowIP + ";";
                    if (UserAllowIP.IndexOf(";" + common.GetClientIp() + ";") == -1)
                    {
                        AlertAjaxMessage("您当前使用的IP不在系统配置中，不允许登录，请联系系统管理员！");
                        return;
                    }
                }
            }
            #endregion

            #region
            FormsAuthentication.SetAuthCookie(HttpUtility.UrlEncode(LoginID), false);

            //保存登录名到HttpCookie
            HttpCookie cookie1 = new HttpCookie("EpointNetoffice7_LoginID");
            cookie1.Value = HttpUtility.UrlEncode(LoginID);
            DateTime dtNow = DateTime.Now;
            TimeSpan tsMinute = new TimeSpan(1000, 0, 0, 0);
            cookie1.Expires = dtNow + tsMinute;
            Response.AppendCookie(cookie1);
            BasePage.mySessionRefresh += new RefreshSessionHandler(RefreshSession);
            string TargetPage = "";
            //Add By XGC 添加是否有兼职的判断
            Session["UserGuid"] = UserGuid;

            AddLoginInfo(1);

            //if (new User().IsExists_SecondOU(UserGuid))
            //{
            //    string OUGuid = new DB_Frame_UserConfig().GetConfigValue_String(UserGuid, "IsDefaultOU");
            //    if (OUGuid != "")
            //        SessionOperate.RefreshSessionFromUserGuid(UserGuid, OUGuid, IsSuperAdmin);
            //    else
            //    {
            //        this.WriteAjaxMessage("ShowSecondOU('" + getTargetUrl(strAlertInfo, true) + "');");
            //        return;
            //    }
            //}
            //else
            common.RefreshSessionFromUserGuid(UserGuid, IsSuperAdmin);

            TargetPage = getTargetUrl(strAlertInfo, false);
            if (TargetPage != "")
                Response.Redirect(TargetPage);
            //定义引用

            #endregion
        }

        private void AddLoginInfo(int LoginType)
        {
            string clientIP = NetOperate.GetClientIp();
            string macAddress = NetOperate.getClientMacAddress();
            if (LoginType == 1)
                new DB_Frame_LoginInfo().Insert(Guid.NewGuid().ToString(), LoginID, clientIP, macAddress, DateTime.Now, 1, "登录成功！");
            else
                new DB_Frame_LoginInfo().Insert(Guid.NewGuid().ToString(), LoginID, clientIP, macAddress, DateTime.Now, 0, "登录失败！");
        }

        private string getTargetUrl(string strAlertInfo, bool IsSecondOU)
        {
            string FramePageUrl = ApplicationOperate.FramePageUrl;
            //if (FramePageUrl == "")
            FramePageUrl = "../../Pages/FrameAll.aspx";
            //Add by Liqiang 2008-11-21   为顶级OA部门提供独立的Frame页面
            if (Session["BaseOU_HomePage"] != null)
                FramePageUrl = Session["BaseOU_HomePage"].ToString();

            if (Request.Params["ReturnUrl"] != null && Request.Params["ReturnUrl"] != "")
            {
                #region
                string ReturnUrl = Request.Params["ReturnUrl"];
                if (ReturnUrl.IndexOf("?") > 0)
                    ReturnUrl = ReturnUrl.Substring(0, ReturnUrl.IndexOf("?"));
                ReturnUrl = ReturnUrl.ToLower();
                if (ReturnUrl.IndexOf("default.aspx") >= 0 || ReturnUrl.ToLower().IndexOf("logout.aspx") >= 0)
                {
                    if (strAlertInfo != "")
                    {
                        AlertAjaxMessage(strAlertInfo);
                        if (!IsSecondOU)
                        {
                            WriteAjaxMessage("window.location='" + FramePageUrl + "';");
                            return "";
                        }
                        else
                            return FramePageUrl;
                    }
                    else
                        return FramePageUrl;
                }
                else
                {
                    if (strAlertInfo != "")
                    {
                        AlertAjaxMessage(strAlertInfo);
                        if (!IsSecondOU)
                        {
                            WriteAjaxMessage("window.location='" + Request.Params["ReturnUrl"] + "';");
                            return "";
                        }
                        else
                            return FramePageUrl;

                    }
                    else
                        return FramePageUrl;
                }
                #endregion
            }
            else
            {
                if (strAlertInfo != "")
                {
                    AlertAjaxMessage(strAlertInfo);
                    if (!IsSecondOU)
                    {
                        WriteAjaxMessage("window.location='" + FramePageUrl + "';");
                        return "";
                    }
                    else
                        return FramePageUrl;
                }
                else
                {
                    return FramePageUrl;
                }
            }
        }
    }


}
