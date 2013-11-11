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
using Epoint.Frame.Bizlogic;
using Epoint.Frame.Entity;
using Epoint.Frame.Bizlogic.UserManage;
using System.IO;
using System.Web.Services;
using Epoint.Frame.Bizlogic.SystemInfo;
using Epoint.Frame.Common;
using Epoint.Frame.Bizlogic.UserConfig;
using System.Runtime.InteropServices;
using Epoint.Frame.Bizlogic;

namespace HTProject.Pages
{
    public partial class tensunlogin : BasePage
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
            //string WindowName = "win" + System.DateTime.Now.Ticks.ToString();
            //Page.RegisterOnSubmitStatement("js", "window.open('','" + WindowName + "','width=600,height=200')");
            //form1.Target = WindowName;
            string noPassName = System.Configuration.ConfigurationManager.AppSettings["noPassName"];
            if (Request["stype"] == noPassName)
            { }
            else
            {
                Response.Redirect("epasslogin.aspx");
            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            //if (loginname.Text.Length < 1)
            //{
            //    Response.Write("<script language=javascript>alert('您没有输入登陆名！');</script>");
            //}
            //else
            //{
            //    SqlCommand mycommand1;
            //    SqlConnection Myconnection = allcommand.allcommand.GreatConn();
            //    string sqlstr = "select id from userqx where loginname=@loginname and password=@password";
            //    mycommand1 = new SqlCommand(sqlstr, Myconnection);
            //    mycommand1.Parameters.Add(new SqlParameter("@loginname", SqlDbType.NVarChar));
            //    mycommand1.Parameters["@loginname"].Value = loginname.Text.Trim();

            //    mycommand1.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
            //    mycommand1.Parameters["@password"].Value = password.Text.Trim();
            //    string ID = "";
            //    try
            //    {
            //        mycommand1.Connection.Open();
            //        ID = mycommand1.ExecuteScalar().ToString();
            //        mycommand1.Connection.Close();
            //        HttpCookie cookie = new HttpCookie("ZJC_CW_ID");
            //        HttpCookie cookie1 = new HttpCookie("web_office_comp");
            //        HttpCookie cookie2 = new HttpCookie("web_office_user");
            //        cookie.Value = ID;
            //        cookie1.Value = "BA37-0910141109010002";
            //        cookie2.Value = "U-CQ-091014-0001";
            //        Response.AppendCookie(cookie);
            //        Response.AppendCookie(cookie1);
            //        Response.AppendCookie(cookie2);
            //        //通过loginid获取人员信息、部门给session
            //        DataTable dtUser = allcommand.allcommand.GetTable("select * from userqx where loginname='" + loginname.Text.Trim() + "' ");
            //        Session["UserGuid"] = dtUser.Rows[0]["id"].ToString();
            //        Session["UserName"] = dtUser.Rows[0]["username"].ToString();
            //        Session["OUName"] = dtUser.Rows[0]["bumen"].ToString();
            //        Session["OUGuid"] = dtUser.Rows[0]["bumenid"].ToString();
            //        //Response.Write("<script>winioffice=window.open('main/FrameAll.aspx','','toolbar=yes,status=yes,resizable=yes');winioffice.moveTo(-4,-4); winioffice.resizeTo(window.screen.availWidth+8,window.screen.availHeight+8);window.opener = top;window.close();</script>");
            //        Response.Redirect("main/FrameAll.aspx");
            //    }
            //    catch(Exception et)
            //    {
            //        Response.Write("<script language=javascript>alert('您的用户名或者密码输入有错误，请重新登陆！');</script>");
            //    } 
            //    //DataTable dt1 = mycommand1.ExecuteScalar // allcommand.allcommand.GetTable("select id from userqx where loginname='" + loginname.Text + "' and password='" + password.Text + "'");
            //    //if (dt1.Rows.Count > 0)
            //    //{
            //    //    HttpCookie cookie = new HttpCookie("ZJC_CW_ID");
            //    //    HttpCookie cookie1 = new HttpCookie("web_office_comp");
            //    //    HttpCookie cookie2 = new HttpCookie("web_office_user");
            //    //    cookie.Value = Convert.ToString(dt1.Rows[0]["id"]);
            //    //    cookie1.Value = "BA37-0910141109010002";
            //    //    cookie2.Value = "U-CQ-091014-0001";
            //    //    Response.AppendCookie(cookie);
            //    //    Response.AppendCookie(cookie1);
            //    //    Response.AppendCookie(cookie2);
            //    //    //通过loginid获取人员信息、部门给session
            //    //    DataTable dtUser = allcommand.allcommand.GetTable("select * from userqx where loginname='" + loginname.Text + "' ");
            //    //    Session["UserGuid"] = dtUser.Rows[0]["id"].ToString();
            //    //    Session["UserName"] = dtUser.Rows[0]["username"].ToString();
            //    //    Session["OUName"] = dtUser.Rows[0]["bumen"].ToString();
            //    //    Session["OUGuid"] = dtUser.Rows[0]["bumenid"].ToString();
            //    //    //Response.Write("<script>winioffice=window.open('main/FrameAll.aspx','','toolbar=yes,status=yes,resizable=yes');winioffice.moveTo(-4,-4); winioffice.resizeTo(window.screen.availWidth+8,window.screen.availHeight+8);window.opener = top;window.close();</script>");
            //    //    Response.Redirect("main/FrameAll.aspx");
            //    //}
            //    //else
            //    //{
            //    //    Response.Write("<script language=javascript>alert('您的用户名或者密码输入有错误，请重新登陆！');</script>");

            //    //}
            //}

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            //判断当前用户是否能正常登录
            bool IsSuperAdmin = false;
            bool isUsingASP = false;
            string UserGuid = "";
            string LoginID = loginname.Text;
            UserGuid = user.UserLogin(this.loginname.Text, this.password.Text, out IsSuperAdmin, out isUsingASP);
            

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
