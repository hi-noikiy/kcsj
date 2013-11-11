using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EpointRegisterUser.Group
{
    public partial class DataGroup_Frame : Epoint.Frame.Bizlogic.BaseContentPage_UsingMasterWithTree
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CurrentLeftPosition = "归档结构";
            this.CurrentRightPosition = "归档列表";
            this.CurrentPosition = "业务数据归档";
        }
    }
}
