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
using System.Data.SqlClient;

namespace WuxiJSJMis
{
    /// <summary>
    /// ePassVerify 的摘要说明。
    /// </summary>
    public partial class ePassVerify : BasePage
    {
        public string userPin;
        public string userSourceID;
        Epoint.RegisterUser.Front.Bizlogic.RegisterUser.RegisterUser rgUser = new Epoint.RegisterUser.Front.Bizlogic.RegisterUser.RegisterUser();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                data1change();

            }
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
        }
        #endregion

        private void data1change()
        {
            string ePassNDstring = ConfigurationManager.AppSettings["ePassND"];
            userPin = "";
            string RandomData = Session["Message"].ToString();
            string userSN = Request["SN_SERAL"];
            string clientdigest = Request["Digest"];
            string PassWord = Request["PassWord"];

            string Key1 = "01234567890123456";
            string Key2 = "01234567890123456";
            string ServerDigest = "01234567890123456";
            object oKey1 = (string)Key1;
            object oKey2 = (string)Key2;
            object oServerDigest = (string)ServerDigest;
            string LoginID = "";

            //SqlConnection ConnEpassND;
            //ConnEpassND = new SqlConnection(ePassNDstring);
            //string sql = "SELECT * From [Projects_Users] where ePassND_KeySerialNumber ='" + userSN + "'";
            //SqlCommand myCMD = new SqlCommand(sql, ConnEpassND);
            //ConnEpassND.Open();
            //SqlDataReader myReader = myCMD.ExecuteReader();
            //if (myReader.Read())
            //{
            //    userPin = myReader["ePassND_KeyPinNumber"].ToString();//从Projects_Users表中读取ePassND_KeyPinNumber字段信息(ePassND_KeyPinNumber是加密锁的pin码)
            //    userSourceID = myReader["Source_Project_UserID"].ToString();//从Projects_Users表中读取Source_Project_UserID字段信息(Source_Project_UserID是OA系统的原来的用户登陆名)
            //}
            //myReader.Close();
            //ConnEpassND.Close();

            //string loginID = userSourceID.Trim();
            //string userpwd = userPin.Trim();

            //判断当前用户是否能正常登录
            string RegisterUserRow_ID = "";

            Session["USBKeyLogin"] = "0";
            string strSql = "select * from RG_User where PINCode='" + userSN + "' and PassWord='" + common.authPassword(PassWord) + "' and IsValid='0' and DelStatus='1' and DelFlag='1' ";
            
            //判断是否是未激活的账号
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            Boolean needActivate = dv.Count > 0;
            if (needActivate)
            {
                //string url = "RG_UserActivation.aspx?UserGuid=" + dv[0]["RowGuid"].ToString();
                AlertAjaxMessage("本帐号未激活，请联系管理员");
                return;
            }
            strSql = "select * from RG_User where PINCode='" + userSN + "' and PassWord='" + common.authPassword(PassWord) + "' ";
            DataView dv2 = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            if (dv2.Count > 0)
            {
                //判断当前用户是否已经配置key，如果已配置，则检查当前系统是否启用了key，如果启用了key，再检查是否配置了不运行普通登录
                LoginID = dv2[0]["loginID"].ToString();
                RegisterUserRow_ID = rgUser.RegisterUserLogin(LoginID, dv2[0]["Password"].ToString());
                
            }

            if (RegisterUserRow_ID == "")
            {
                #region      登录失败情况下，给用户的提示
                if (Convert.ToInt32(ViewState["LoginErrorTimes"]) != 0)
                {
                    if (Convert.ToInt32(ViewState["ErrorTimes"]) >= Convert.ToInt32(ViewState["LoginErrorTimes"]))
                    {
                        WriteAjaxMessage("alert('您的密码已经输错超过了3次，系统将自动关闭！');window.close();");
                        string RowGuid = Guid.NewGuid().ToString();
                        Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Login", RowGuid);
                        oRow["RGGuid"] = LoginID;
                        oRow["LoginTime"] = System.DateTime.Now.ToString();
                        oRow["IsLoginSuccess"] = 0;
                        oRow["Message"] = "" + LoginID + "的PIN密码输错了3次，系统自动关闭！";
                        oRow.Insert();
                        return;
                    }
                    else
                    {
                        AlertAjaxMessage("系统不能完成您的登录请求，请检查您的密码是否正确！");
                        WriteAjaxMessage("window.location='epasslogin.aspx';");
                    }

                    ViewState["ErrorTimes"] = Convert.ToInt32(ViewState["ErrorTimes"]) + 1;
                    
                    return;
                }
                else
                {

                    AlertAjaxMessage("系统不能完成您的登录请求，请检查您的密码是否正确！");
                    WriteAjaxMessage("window.location='epasslogin.aspx';");
                    
                    return;
                }
                #endregion
            }
            else
            {
                RG_Login(LoginID);
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
            //获取密码
            //string pwd
            FormsAuthentication.SetAuthCookie(HttpUtility.UrlEncode(RGLoginID), false);
            //保存登录名到HttpCookie
            HttpCookie cookie1 = new HttpCookie("RegisterUser_LoginID");
            cookie1.Value = HttpUtility.UrlEncode(RGLoginID);
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

        
    }
}
