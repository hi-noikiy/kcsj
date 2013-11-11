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
using Epoint.Frame.Bizlogic;
using Epoint.Frame.Bizlogic.UserManage;

namespace HTProject
{
    public partial class ADDefault : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string loginID = "";
                if ((HttpContext.Current.Session["LoginID"] == null) || (Convert.ToString(this.Session["LoginID"]) == ""))
                {
                    string rawUrl = "";
                    string userGuid = "";
                    try
                    {
                        rawUrl = base.Request.RawUrl;
                    }
                    catch
                    {
                    }
                    if ((rawUrl.ToLower().IndexOf("login.aspx") == -1) && (rawUrl.ToLower().IndexOf("db_sql_update") == -1))
                    {
                        //DB_Frame_OperationLog.InsertSysLog("【BasePage】Session[\"LoginID\"] 不存在，RawUrl=" + rawUrl + "；需要 BasePage中重新初始化Session！");
                        if (base.IsGuid(HttpUtility.UrlDecode(this.Context.User.Identity.Name)))
                        {
                            userGuid = HttpUtility.UrlDecode(this.Context.User.Identity.Name);
                            loginID = new User().GetDetailByUserGuid(userGuid).LoginID;
                        }
                        else
                        {
                            loginID = HttpUtility.UrlDecode(this.Context.User.Identity.Name);
                            if (loginID.IndexOf(@"\") > -1)
                            {
                                loginID = loginID.Substring(loginID.IndexOf(@"\") + 1);
                            }
                            if (loginID.IndexOf("@") > -1)
                            {
                                loginID = loginID.Substring(0, loginID.IndexOf("@"));
                            }
                            userGuid = new User().GetDetailByLoginID(loginID).UserGuid;
                        }
                        //DB_Frame_OperationLog.InsertSysLog("【BasePage】开始初始化Session，获取：Context.User.Identity.Name，LoginID=" + loginID);
                        if (loginID != "")
                        {
                            //DB_Frame_OperationLog.InsertSysLog("【BasePage】初始化Session成功！");
                        }
                    }
                }
            }
        }
    }
}
