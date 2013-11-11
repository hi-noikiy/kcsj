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
using System.IO;
using System.Text;
using Epoint.RegisterUser.Bizlogic.Consult;

namespace EpointRegisterUser.Consult
{
    public partial class ReadXmlData : System.Web.UI.Page
    {
        Db_ConsultMana DB_Consult = new Db_ConsultMana();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/xml";
            Response.ContentEncoding = Encoding.UTF8;

            TextWriter textWriter = new StreamWriter(Response.OutputStream, Encoding.UTF8);
            textWriter.Write(WriteXML());

            textWriter.Flush();
            textWriter.Close();
            Response.Flush();
            Response.End();
        }

        public string WriteXML()
        {
            string[] color = { "AFD8F8", "F6BD0F", "8BBA00", "FF8E46", "008E8E", "D64646", "8E468E", "588526", "B3AA00", "008ED6", "9D080D", "A186BE" };

            StringBuilder sb = new StringBuilder();

            switch (Request.QueryString["type"])
            {
                case "1":
                    sb.Append("<graph caption='信件回复率' xAxisName='' yAxisName='' decimalPrecision='0' formatNumberScale='0'>");
                    DataView dv1 = DB_Consult.GetHandleCount_HF();
                    dv1.Sort = "回复率 desc";
                    try
                    {
                        if (dv1[0]["回复率"].ToString() != "0")
                        {
                            for (int i = 0; i < dv1.Count && i < 10; i++)
                            {
                                sb.Append("<set name='" + dv1[i]["信箱名称"] + "' value='" + dv1[i]["回复率"] + "' color='" + color[i] + "' />");
                            }
                        }
                    }
                    catch { }
                    sb.Append("</graph>");
                    break;
                case "2":
                    sb.Append("<graph caption='回复及时率' xAxisName='' yAxisName='' decimalPrecision='0' formatNumberScale='0'>");
                    DataView dv2 = DB_Consult.GetHandleCount_JS();
                    dv2.Sort = "及时率 desc";
                    try
                    {
                        if (dv2[0]["及时率"].ToString() != "0")
                        {
                            for (int i = 0; i < dv2.Count && i < 10; i++)
                            {
                                sb.Append("<set name='" + dv2[i]["信箱名称"] + "' value='" + dv2[i]["及时率"] + "' color='" + color[i] + "' />");
                            }
                        }
                    }
                    catch { }
                    sb.Append("</graph>");
                    break;
                case "3":
                    sb.Append("<graph caption='回复满意率' xAxisName='' yAxisName='' decimalPrecision='0' formatNumberScale='0'>");
                    DataView dv3 = DB_Consult.GetHandleCount_MY();
                    dv3.Sort = "满意率 desc";
                    try
                    {
                        if (dv3[0]["满意率"].ToString() != "0")
                        {
                            for (int i = 0; i < dv3.Count && i < 10; i++)
                            {
                                sb.Append("<set name='" + dv3[i]["信箱名称"] + "' value='" + dv3[i]["满意率"] + "' color='" + color[i] + "' />");
                            }
                        }
                    }
                    catch { }
                    sb.Append("</graph>");
                    break;
                default:
                    sb.Append("<graph caption='受理总数' xAxisName='' yAxisName='' decimalPrecision='0' formatNumberScale='0'>");
                    DataView dv4 = DB_Consult.GetHandleCount();
                    dv4.Sort = "总数 desc";
                    try
                    {
                        if (dv4[0]["总数"].ToString() != "0")
                        {
                            for (int i = 0; i < dv4.Count && i < 10; i++)
                            {
                                sb.Append("<set name='" + dv4[i]["信箱名称"] + "' value='" + dv4[i]["总数"] + "' color='" + color[i] + "' />");
                            }
                        }
                    }
                    catch { }
                    sb.Append("</graph>");
                    break;
            }

            return sb.ToString();
        }
    }
}
