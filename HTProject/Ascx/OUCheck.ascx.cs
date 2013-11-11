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

namespace HTProject.Ascx
{
    public partial class OUCheck : System.Web.UI.UserControl
    {
        HTProject_Bizlogic.DB_Messages_Center MsgCenter = new HTProject_Bizlogic.DB_Messages_Center();
        public int BanliCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BanliCount = MsgCenter.WaitHandle_GetMessageCount(Session["UserGuid"].ToString(), Session["JobLst"].ToString(), "办理", ApplicationOperate.newWaithandle_MsgClientIdentifier, hiID.Value);
                if (BanliCount > 0)
                {
                    lblMessageCount.ForeColor = System.Drawing.Color.Red;
                }
                lblMessageCount.Text = "需审核企业信息(" + BanliCount + ")";
            }
        }
    }
}