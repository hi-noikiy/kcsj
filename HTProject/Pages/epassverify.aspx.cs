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
    /// ePassVerify ��ժҪ˵����
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

        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
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
            //    userPin = myReader["ePassND_KeyPinNumber"].ToString();//��Projects_Users���ж�ȡePassND_KeyPinNumber�ֶ���Ϣ(ePassND_KeyPinNumber�Ǽ�������pin��)
            //    userSourceID = myReader["Source_Project_UserID"].ToString();//��Projects_Users���ж�ȡSource_Project_UserID�ֶ���Ϣ(Source_Project_UserID��OAϵͳ��ԭ�����û���½��)
            //}
            //myReader.Close();
            //ConnEpassND.Close();

            //string loginID = userSourceID.Trim();
            //string userpwd = userPin.Trim();

            //�жϵ�ǰ�û��Ƿ���������¼
            string RegisterUserRow_ID = "";

            Session["USBKeyLogin"] = "0";
            string strSql = "select * from RG_User where PINCode='" + userSN + "' and PassWord='" + common.authPassword(PassWord) + "' and IsValid='0' and DelStatus='1' and DelFlag='1' ";
            
            //�ж��Ƿ���δ������˺�
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            Boolean needActivate = dv.Count > 0;
            if (needActivate)
            {
                //string url = "RG_UserActivation.aspx?UserGuid=" + dv[0]["RowGuid"].ToString();
                AlertAjaxMessage("���ʺ�δ�������ϵ����Ա");
                return;
            }
            strSql = "select * from RG_User where PINCode='" + userSN + "' and PassWord='" + common.authPassword(PassWord) + "' ";
            DataView dv2 = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            if (dv2.Count > 0)
            {
                //�жϵ�ǰ�û��Ƿ��Ѿ�����key����������ã����鵱ǰϵͳ�Ƿ�������key�����������key���ټ���Ƿ������˲�������ͨ��¼
                LoginID = dv2[0]["loginID"].ToString();
                RegisterUserRow_ID = rgUser.RegisterUserLogin(LoginID, dv2[0]["Password"].ToString());
                
            }

            if (RegisterUserRow_ID == "")
            {
                #region      ��¼ʧ������£����û�����ʾ
                if (Convert.ToInt32(ViewState["LoginErrorTimes"]) != 0)
                {
                    if (Convert.ToInt32(ViewState["ErrorTimes"]) >= Convert.ToInt32(ViewState["LoginErrorTimes"]))
                    {
                        WriteAjaxMessage("alert('���������Ѿ��������3�Σ�ϵͳ���Զ��رգ�');window.close();");
                        string RowGuid = Guid.NewGuid().ToString();
                        Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Login", RowGuid);
                        oRow["RGGuid"] = LoginID;
                        oRow["LoginTime"] = System.DateTime.Now.ToString();
                        oRow["IsLoginSuccess"] = 0;
                        oRow["Message"] = "" + LoginID + "��PIN���������3�Σ�ϵͳ�Զ��رգ�";
                        oRow.Insert();
                        return;
                    }
                    else
                    {
                        AlertAjaxMessage("ϵͳ����������ĵ�¼�����������������Ƿ���ȷ��");
                        WriteAjaxMessage("window.location='epasslogin.aspx';");
                    }

                    ViewState["ErrorTimes"] = Convert.ToInt32(ViewState["ErrorTimes"]) + 1;
                    
                    return;
                }
                else
                {

                    AlertAjaxMessage("ϵͳ����������ĵ�¼�����������������Ƿ���ȷ��");
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
        /// ��Ա��¼
        /// </summary>
        /// <param name="RGUserGuid"></param>
        /// <param name="RGUserName"></param>
        private void RG_Login(string RGLoginID)
        {

            #region
            rgUser.RefreshSession(RGLoginID);
            //��ȡ����
            //string pwd
            FormsAuthentication.SetAuthCookie(HttpUtility.UrlEncode(RGLoginID), false);
            //�����¼����HttpCookie
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
                EnableDays = 180;//Ĭ�Ͼ൱ǰ180��
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            DateTime dt = DateTime.Now.AddDays(0 - EnableDays);
            // ��������ڽϾõĵ�½��¼����ֹRG_Login�����
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
            oRow["Message"] = "�ɹ���½";
            oRow.Insert();
        }

        
    }
}
