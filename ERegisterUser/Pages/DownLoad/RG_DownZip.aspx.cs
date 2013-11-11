using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EpointRegisterUser.Pages.DownLoad
{
    public partial class RG_DownZip : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tempGuid = this.UserGuid + "-LS";
            string strUrl = HttpContext.Current.Server.MapPath(GetApplicationPath()) + "AttachStorage\\" + tempGuid + "\\";
            Response.ContentType = "application/x-zip-compressed";
            Response.AddHeader("Content-Disposition", "attachment;filename="+Request["zipname"] + ".zip");
            string filename = strUrl + Request["zipname"] + ".zip";
            Response.TransmitFile(filename);

        }
    }
}