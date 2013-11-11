using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EpointRegisterUser.Pages.RG_Module
{
    public partial class Record_Frame : Epoint.Frame.Bizlogic.BaseContentPage_UsingMasterWithTree 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CurrentLeftPosition = "选择模块";
            this.CurrentRightPosition = "模块列表";
            if (Request["IsApplication"] == "0")
                this.CurrentPosition = "会员模块";
            else
                this.CurrentPosition = "前台模块管理";
        }
    }
}
