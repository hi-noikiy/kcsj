using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.Services;
using System.IO;

namespace HTProject
{
    public partial class RGDefault : Epoint.Frame.Bizlogic.BasePage
    {
        Epoint.RegisterUser.Front.Bizlogic.RegisterUser.RegisterUser rgUser = new Epoint.RegisterUser.Front.Bizlogic.RegisterUser.RegisterUser();
        Epoint.RegisterUser.Front.Bizlogic.RegisterModule.RegisterModule rgModule = new Epoint.RegisterUser.Front.Bizlogic.RegisterModule.RegisterModule();
        Epoint.Frame.Bizlogic.Frame_Config FC = new Epoint.Frame.Bizlogic.Frame_Config();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

    }
}
