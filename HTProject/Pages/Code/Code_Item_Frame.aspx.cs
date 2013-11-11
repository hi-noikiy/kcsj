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

namespace HTProject.Pages.Code
{
    public partial class Code_Item_Frame : BaseContentPage_UsingMasterWithTree
    {
        // Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CurrentLeftPosition = "选择上级代码项";
            base.CurrentRightPosition = "代码项列表";
            base.CurrentPosition = "代码项管理";
            this.Session["MainGuid"] = Request["MainGuid"];
            this.Session["ItemCode"] = Request["ItemCode"];
            this.Session["LEN"] = Request["LEN"];
        }
    }
}

