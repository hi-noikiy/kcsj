using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace HTProject.Pages.RG_QYUser
{
    public partial class GetUserImageByte : System.Web.UI.Page
    {

        /// <summary>
        /// 学员报名表TableID
        /// </summary>
        public int TableID = 2019;

        protected void Page_Load(object sender, EventArgs e)
        {
            Epoint.MisBizLogic2.Data.MisGuidRow oRowBM = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_QYUser", Request["RowGuid"]);
            if (oRowBM["CardIMG"] != DBNull.Value)
            {
                Response.Buffer = true;
                Response.Clear();
                //Response.BinaryWrite((byte[])(oRowBM["CardIMG"]));
                Response.ContentType = "image/pjpeg";
                string s = HttpUtility.UrlEncode(System.Text.UTF8Encoding.UTF8.GetBytes(oRowBM["XM"].ToString()));

                Response.AddHeader("Content-Disposition", "attachment;filename=" + s + ".jpg");
                object dbValue = oRowBM["CardIMG"];
                byte[] file = (byte[])dbValue;

                Response.BinaryWrite(file);
                Response.Flush();
                //Response.End();

                //Response.ContentType = "";
                //string s = HttpUtility.UrlEncode(System.Text.UTF8Encoding.UTF8.GetBytes("" + dt1.Rows[0]["name"].ToString() + ""));

                //Response.AddHeader("Content-Disposition", "attachment;filename=" + s + "");
                //object dbValue = dt1.Rows[0]["data"];
                //byte[] file = (byte[])dbValue;

                //Response.BinaryWrite(file);
                ////Response.BinaryWrite(file);
                //Response.Flush();
            }
            

        }
    }
}
