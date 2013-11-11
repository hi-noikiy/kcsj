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

namespace EpointRegisterUser.Consult.ConsultBoxXinFang
{
    public partial class ConsultBoxXinFangFrame : Epoint.Frame.Bizlogic.BaseContentPage_UsingMasterWithTree 
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CurrentLeftPosition = "信箱列表";
            this.CurrentRightPosition = "咨询信息";
            this.CurrentPosition = "信件分发";
            this.CurrentTitle = "信件分发";
        }
    }
}
