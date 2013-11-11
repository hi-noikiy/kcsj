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
using Epoint.Frame.Bizlogic.AttachStorageInfo;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using iTextSharp.text.pdf;



namespace HTProject.Ascx
{
    public partial class ReadAttachFileWithZhang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AttachGuid = Request.QueryString["AttachGuid"];

            if (Request.QueryString["bytedata"] != null && Request.QueryString["bytedata"] == "1")
            {
                Detail_AttachInfo att = new StorageCom().GetDetail(AttachGuid);
                Response.BinaryWrite(att.Content);
                Response.End();
            }
            else
            {
                Detail_AttachInfo att = new StorageCom().GetDetail_NoContent(AttachGuid);
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                #region 采用临时文件方法
                if (att.StorageType.ToLower() == "file")//文件存储方式
                    Response.Redirect(Epoint.Frame.Bizlogic.common.GetApplicationPath() + att.FilePath);
                else
                {

                    string attPath = Epoint.Frame.Bizlogic.BasePage.GetApplicationPath() + "AttachStorage/";
                    Epoint.Frame.Bizlogic.common.CreatRootTempFolder();

                    if (!Directory.Exists(Server.MapPath(attPath + "/" + att.AttachGuid)))
                        Directory.CreateDirectory(Server.MapPath(attPath + "/" + att.AttachGuid));

                    string strFullFilePath = Server.MapPath(attPath + "/" + att.AttachGuid + "/" + att.AttachFileName.Replace("\"", "“"));

                    //当文件大小为0时删除文件重新生成
                    if (File.Exists(strFullFilePath) && new FileInfo(strFullFilePath).Length == 0)
                    {
                        File.Delete(strFullFilePath);
                    }
                    //二进制文件写必须用binaryWrite,不需要制定encoding方式
                    if (!File.Exists(strFullFilePath))
                    {
                        FileStream objFileStream = new FileStream(strFullFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                        BinaryWriter objBinaryWriter = new BinaryWriter(objFileStream);
                        objBinaryWriter.Write(new StorageCom().GetContentByAttachGuid(AttachGuid));
                        objBinaryWriter.Close();
                        objFileStream.Close();
                    }
                    string AttachFileURL = attPath + att.AttachGuid + "/" + att.AttachFileName.Replace("\"", "“");

                    string WatermarkImageUrl = Server.MapPath(Request.ApplicationPath + "/HTProject/Pages/Images/合同备案公章.gif");
                    string message = "";

                    string diskName = Server.MapPath(AttachFileURL); //Request.ApplicationPath + "/AttachStorage/" + fileName + "XMBA.pdf"
                    string fileNew = Request.ApplicationPath + "/AttachStorage/" + fileName + "_2XMBA.pdf";
                    if (Request["SAdd"] == "SN")
                    {
                        WatermarkPDF_SN(diskName, Server.MapPath(fileNew), WatermarkImageUrl, 200, 500, 115, 115, out message);
                    }
                    else
                    {
                        WatermarkPDF_SW(diskName, Server.MapPath(fileNew), WatermarkImageUrl, 568, 500, 115, 115, out message);
                    }
                    
                    Response.Redirect(fileNew);
                }
                #endregion
            }
        }

        public bool WatermarkPDF_SW(string SourcePdfPath, string OutputPdfPath, string WatermarkImageUrl, int positionX, int positionY, int WatermarkHeight, int WatermarkWidth, out string msg)
        {
            try
            {
                PdfReader reader = new PdfReader(SourcePdfPath);
                PdfStamper stamp = new PdfStamper(reader, new FileStream(OutputPdfPath, FileMode.Create));
                int n = reader.NumberOfPages;
                int i = 0;
                PdfContentByte under;
                WatermarkWidth = WatermarkWidth / n;
                //这个地方要注意，是根据页数来动态加载图片地址，有几页就加载几页的图片
                string WatermarkPath = Server.MapPath(Request.ApplicationPath + "/HTProject/Pages/Images/合同备案公章" + n + "/");
                string WatermarkPath2 = "";
                while (i < n)
                {
                    i++;
                    WatermarkPath2 = WatermarkPath + i + ".gif";
                    iTextSharp.text.Image im = iTextSharp.text.Image.GetInstance(WatermarkPath2);
                    im.SetAbsolutePosition(positionX, positionY);
                    im.ScaleAbsolute(WatermarkWidth, WatermarkHeight);

                    under = stamp.GetUnderContent(i);
                    under.AddImage(im, true);
                }
                stamp.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
            msg = "加水印成功！";
            return true;
        }

        public bool WatermarkPDF_SN(string SourcePdfPath, string OutputPdfPath, string WatermarkPath, int positionX, int positionY, int WatermarkHeight, int WatermarkWidth, out string msg)
        {
            try
            {
                PdfReader reader = new PdfReader(SourcePdfPath);
                PdfStamper stamp = new PdfStamper(reader, new FileStream(OutputPdfPath, FileMode.Create));
                int n = reader.NumberOfPages;
                int i = 0;
                PdfContentByte under;
                iTextSharp.text.Image im = iTextSharp.text.Image.GetInstance(WatermarkPath);
                im.SetAbsolutePosition(positionX, positionY);
                im.ScaleAbsolute(WatermarkWidth, WatermarkHeight);
                while (i < n)
                {
                    i++;
                    under = stamp.GetUnderContent(i);
                    under.AddImage(im, true);
                }
                stamp.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
            msg = "加水印成功！";
            return true;
        }

    }
}
