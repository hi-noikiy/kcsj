using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace HTProject.Pages.RG_XMBeiAn
{
    public partial class RetrieveImageData : System.Web.UI.Page
    {
        string WatermarkImageUrl = "";
        string WatermarkText = "";

        protected void Page_Load(object sender, System.EventArgs e)
        {
            WatermarkImageUrl = Request.ApplicationPath + "/HTProject/Pages/Images/合同备案水印.jpg";
            WatermarkText = new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("AppDeptName").ConfigValue;

            Response.Clear();
            //string ProcessType = Request.QueryString["ProcessType"];
            string FlipType = Request.QueryString["FlipType"];
            //通过人员的Guid，获取个人签名的AttachGuid
            Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom StorgCom = new Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom();
            string CliGuid = Request["RYGuid"] + "RY_GRQM";
            DataView dvAttch = StorgCom.Select(CliGuid);
            dvAttch.Sort = " Row_ID DESC ";
            string AttachGuid = "";
            if (dvAttch.Count > 0)
            {
                AttachGuid = dvAttch[0]["AttachGuid"].ToString();
            }
            else
            {
                //如果没有签名，就加载个默认的提示
                Response.Redirect(Request.ApplicationPath + "/HTProject/Pages/Images/WQM.gif");////////////////////////////////////////////////
                return;
            }
            //string AttachGuid = Request.QueryString["AttachGuid"];
            string Attach_ConnectionStringName = Request.QueryString["ConnName"];
            string Attach_ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EpointMis_ConnectionString"].ConnectionString;
            if (Attach_ConnectionStringName != null && Attach_ConnectionStringName != "")
            {
                string strCon = new HTProject_Bizlogic.AttachManage.DB_Frame_Attach().GetAttach_ConnectionString(Attach_ConnectionStringName);
                if (strCon != "")
                {
                    Attach_ConnectionString = strCon;
                }
            }

            Epoint.MisBizLogic2.Data.CommonDataRow oRow = new Epoint.MisBizLogic2.Data.CommonDataRow("Frame_AttachStorage", "AttachGuid", AttachGuid, Attach_ConnectionString);

            string fileName = "";

            #region 如果采用生成文件的方式，会在服务器的Web程序目录下面创建临时文件，
            if (oRow.R_HasFilled && !Convert.IsDBNull(oRow["Content"]))
            {
                if (oRow["AttachFileName"] != null)
                {
                    fileName = oRow["AttachFileName"].ToString();
                }
                else
                {
                    fileName = Guid.NewGuid().ToString();
                }

                //替换开始
                FileStream objFileStream;
                BinaryWriter objBinaryWriter;
                string attPath = Request.ApplicationPath + "/AttachStorage/";
                if (!Directory.Exists(Server.MapPath(attPath + "/" + AttachGuid)))
                {
                    Directory.CreateDirectory(Server.MapPath(attPath + "/" + AttachGuid));
                }

                string strFullFilePath = Server.MapPath(attPath + "/" + AttachGuid + "/" + fileName);

                //二进制文件写必须用binaryWrite,不需要制定encoding方式
                if (!File.Exists(strFullFilePath))
                {
                    objFileStream = new FileStream(strFullFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                    objBinaryWriter = new BinaryWriter(objFileStream);
                    objBinaryWriter.Write((byte[])oRow["Content"]);
                    objBinaryWriter.Close();
                    objFileStream.Close();
                }

                #region 图片翻转
                //翻转后的文件名
                string fileNameR = "";
                int site = fileName.IndexOf('.');
                fileNameR = fileName.Substring(0, site) + "_R" + fileName.Substring(site, fileName.Length - site);
                string strFullFilePathR = Server.MapPath(attPath + "/" + AttachGuid + "/" + fileNameR);

                Bitmap image = new Bitmap(strFullFilePath);
                if (FlipType == "0")
                {
                    image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                }
                else if (FlipType == "1")
                {
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else if (FlipType == "2")
                {
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                else if (FlipType == "3")
                {
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                }
                image.Save(strFullFilePathR);

                objFileStream = new FileStream(strFullFilePathR, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryReader br = new BinaryReader(objFileStream);
                byte[] imagebytes = br.ReadBytes(Convert.ToInt32(objFileStream.Length));

                objFileStream.Close();
                image.Dispose();

                ////翻转后存入数据库
                //if (ProcessType.Equals("Save"))
                //{
                //    //保存到数据库
                //    new ZLJDMis.BizLogic.AttachManage.DB_Frame_Attach().UpdateAttachContent(AttachGuid, imagebytes);
                //    //修改默认生成的图片
                //    File.Delete(strFullFilePath);
                //    strFullFilePath = Server.MapPath(attPath + "/" + AttachGuid + "/" + fileName);
                //    Bitmap imageDB = new Bitmap(strFullFilePathR);
                //    imageDB.Save(strFullFilePath);
                //    imageDB.Dispose();
                //}
                #endregion

                MakeThumbnail_And_AddWaterMark(strFullFilePathR);
                Response.Redirect(attPath + "/" + AttachGuid + "/" + fileNameR);
            }
            #endregion

        }

        #region 添加水印
        /// <summary>
        /// 生成缩略图，添加水印
        /// </summary>
        /// <param name="originalImagePath">原始图</param>
        /// <param name="width">缩略后的宽度</param>
        /// <param name="height">缩略后的高度</param>     
        private void MakeThumbnail_And_AddWaterMark(string originalImagePath)
        {
            string strFileExt = originalImagePath.Substring(originalImagePath.LastIndexOf(".") + 1).ToUpper();
            string strPath = originalImagePath.Substring(0, originalImagePath.LastIndexOf("\\"));
            string sFileName = originalImagePath.Substring(originalImagePath.LastIndexOf("\\") + 1).Replace("." + strFileExt.ToLower(), "");
            string sRawImagePath = strPath + "\\" + sFileName + "_Raw." + strFileExt;

            System.IO.File.Copy(originalImagePath, sRawImagePath, true);

            string smallImagePath = originalImagePath;//直接覆盖原来的大图片

            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(sRawImagePath);


            int towidth = originalImage.Width;
            int toheight = originalImage.Height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            //新建一个bmp图片
            System.Drawing.Image bitmap = new Bitmap(towidth, toheight);

            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighQuality;

            ////清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                        new Rectangle(x, y, ow, oh),
                        GraphicsUnit.Pixel);


            if (this.WatermarkImageUrl != "")
            {
                this.addWatermarkImage(g, towidth, toheight, HTProject_Bizlogic.CommonEnum.WaterMarkPosition.TOP_LEFT);
            }
            else if (this.WatermarkText != "")
            {
                this.addWatermarkText(g, towidth, toheight, HTProject_Bizlogic.CommonEnum.WaterMarkPosition.BOTTOM_LEFT);
            }
            try
            {
                //保存高清晰度的缩略图
                if (strFileExt == "JPG" || strFileExt == "JPEG")
                {
                    bitmap.Save(smallImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (strFileExt == "GIF")
                {
                    bitmap.Save(smallImagePath, System.Drawing.Imaging.ImageFormat.Gif);
                }
                else if (strFileExt == "PNG")
                {
                    bitmap.Save(smallImagePath, System.Drawing.Imaging.ImageFormat.Png);
                }
                else if (strFileExt == "BMP")
                {
                    bitmap.Save(smallImagePath, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }

            System.IO.File.Delete(sRawImagePath);//删除原来的文件
        }


        /// <summary>
        /// 加水印文字
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="_width">原始图片的宽度</param>
        /// <param name="_height">原始图片的高度.</param>
        private void addWatermarkText(Graphics picture, int _width, int _height, HTProject_Bizlogic.CommonEnum.WaterMarkPosition Pos)
        {
            int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };
            Font crFont = null;
            SizeF crSize = new SizeF();
            for (int i = 0; i < 7; i++)
            {
                crFont = new Font("arial", sizes[i], FontStyle.Bold);
                crSize = picture.MeasureString(this.WatermarkText, crFont);

                if ((ushort)crSize.Width < (ushort)_width)
                    break;
            }

            float xpos = 0;
            float ypos = 0;


            switch (Pos)
            {
                case HTProject_Bizlogic.CommonEnum.WaterMarkPosition.TOP_LEFT:
                    xpos = ((float)_width * (float).01) + (crSize.Width / 2);
                    ypos = (float)_height * (float).01;
                    break;
                case HTProject_Bizlogic.CommonEnum.WaterMarkPosition.TOP_RIGHT:
                    xpos = ((float)_width * (float).99) - (crSize.Width / 2);
                    ypos = (float)_height * (float).01;
                    break;
                case HTProject_Bizlogic.CommonEnum.WaterMarkPosition.BOTTOM_RIGHT:
                    xpos = ((float)_width * (float).99) - (crSize.Width / 2);
                    ypos = ((float)_height * (float).99) - crSize.Height;
                    break;
                case HTProject_Bizlogic.CommonEnum.WaterMarkPosition.BOTTOM_LEFT:
                    xpos = ((float)_width * (float).01) + (crSize.Width / 2);
                    ypos = ((float)_height * (float).99) - crSize.Height;
                    break;
            }

            StringFormat StrFormat = new StringFormat();
            StrFormat.Alignment = StringAlignment.Center;

            SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(153, 0, 0, 0));
            picture.DrawString(this.WatermarkText, crFont, semiTransBrush2, xpos + 1, ypos + 1, StrFormat);

            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));
            picture.DrawString(this.WatermarkText, crFont, semiTransBrush, xpos, ypos, StrFormat);


            semiTransBrush2.Dispose();
            semiTransBrush.Dispose();
        }

        /// <summary>
        /// 加水印图片
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="_width">原始图片的宽度</param>
        /// <param name="_height">原始图片的高度.</param>
        private void addWatermarkImage(Graphics picture, int _width, int _height, HTProject_Bizlogic.CommonEnum.WaterMarkPosition Pos)
        {
            if (!System.IO.File.Exists(this.Page.MapPath(this.WatermarkImageUrl)))
            {
                return;
            }
            System.Drawing.Image watermark = new Bitmap(this.Page.MapPath(this.WatermarkImageUrl));

            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();

            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            float[][] colorMatrixElements = {
                                                new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                                new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                                 new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},
                                                new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                             };

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            int xpos = 0;
            int ypos = 0;
            int WatermarkWidth = 0;
            int WatermarkHeight = 0;
            double bl = 1d;
            //计算水印图片的比率
            //取背景的1/4宽度来比较
            //if ((_width > watermark.Width * 4) && (_height > watermark.Height * 4))
            //{
            //    bl = 1;
            //}
            //else if ((_width > watermark.Width * 4) && (_height < watermark.Height * 4))
            //{
            //    bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);

            //}
            //else

            //    if ((_width < watermark.Width * 4) && (_height > watermark.Height * 4))
            //    {
            //        bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);
            //    }
            //    else
            //    {
            //        if ((_width * watermark.Height) > (_height * watermark.Width))
            //        {
            //            bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);

            //        }
            //        else
            //        {
            //            bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);

            //        }

            //    }
            WatermarkWidth = watermark.Width; //Convert.ToInt32(_width);
            WatermarkHeight = watermark.Height;// Convert.ToInt32(_height);

            //switch (Pos)
            //{
            //    case HTProject_Bizlogic.CommonEnum.WaterMarkPosition.TOP_LEFT:
            //        xpos = 0;
            //        ypos = 0;
            //        break;
            //    case HTProject_Bizlogic.CommonEnum.WaterMarkPosition.TOP_RIGHT:
            //        xpos = _width - WatermarkWidth - 10;
            //        ypos = 10;
            //        break;
            //    case HTProject_Bizlogic.CommonEnum.WaterMarkPosition.BOTTOM_RIGHT:
            //        xpos = _width - WatermarkWidth - 10;
            //        ypos = _height - WatermarkHeight - 10;
            //        break;
            //    case HTProject_Bizlogic.CommonEnum.WaterMarkPosition.BOTTOM_LEFT:
            //        xpos = 0;
            //        ypos = _height - WatermarkHeight - 10;
            //        break;
            //}

            //picture.DrawImage(watermark, new Rectangle(xpos, ypos, WatermarkWidth, WatermarkHeight), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);
            //循环加上水印
            for (int y = 0; y < _height; y = y + WatermarkHeight)
            {
                for (int x = 0; x < _width; x = x + WatermarkWidth)
                {
                    //switch (Pos)
                    //{
                    //    case HTProject_Bizlogic.CommonEnum.WaterMarkPosition.TOP_LEFT:
                    //        xpos = 0;
                    //        ypos = 0;
                    //        break;
                    //    case HTProject_Bizlogic.CommonEnum.WaterMarkPosition.TOP_RIGHT:
                    //        xpos = _width - WatermarkWidth - 10;
                    //        ypos = 10;
                    //        break;
                    //    case HTProject_Bizlogic.CommonEnum.WaterMarkPosition.BOTTOM_RIGHT:
                    //        xpos = _width - WatermarkWidth - 10;
                    //        ypos = _height - WatermarkHeight - 10;
                    //        break;
                    //    case HTProject_Bizlogic.CommonEnum.WaterMarkPosition.BOTTOM_LEFT:
                    //        xpos = 0;
                    //        ypos = _height - WatermarkHeight - 10;
                    //        break;
                    //}
                    xpos = x;
                    ypos = y;
                    picture.DrawImage(watermark, new Rectangle(xpos, ypos, WatermarkWidth, WatermarkHeight), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);
                }
            }

            watermark.Dispose();
            imageAttributes.Dispose();
        }
        #endregion




    }
}
