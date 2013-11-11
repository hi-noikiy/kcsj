using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System;
using Epoint.Frame.Bizlogic;

namespace HTProject.Pages.RG_XMBeiAn
{

    public partial class ZZZYGX_Frame : BaseContentPage_UsingMasterWithTree
    {
        // Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CurrentLeftPosition = "资质类别";
            base.CurrentRightPosition = "专业设置列表";
            base.CurrentPosition = "资质与专业对应关系";
            this.Session["MainGuid"] = Request["MainGuid"];
            
        }
    }


}


