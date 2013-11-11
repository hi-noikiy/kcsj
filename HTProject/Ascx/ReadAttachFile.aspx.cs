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



namespace HTProject.Ascx
{
    public partial class ReadAttachFile : System.Web.UI.Page
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
                        #region 如果是图片，则加上水印
                        #endregion
                    }
                    string AttachFileURL = attPath + att.AttachGuid + "/" + att.AttachFileName.Replace("\"", "“");
                    Response.Redirect(AttachFileURL);
                }
                #endregion
            }
        }



    }
}
