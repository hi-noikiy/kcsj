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
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing;
using Epoint.Frame.Common;

namespace HTProject.Pages
{
    public partial class ReadTempImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strRnd = CreateRnd(5);
            Response.Cookies.Add(new HttpCookie("CheckCode", strRnd));
            string TempNumber = strRnd;// Request.QueryString["Uid"];
            //TempNumber = Epoint.Frame.Bizlogic.common.Decrypt(TempNumber, "EpointPW");

            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(MapPath(Epoint.Frame.Bizlogic.common.GetApplicationPath() + "Images/Rzm_bg.gif"));
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

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);
            addWatermarkText(g, towidth, toheight, TempNumber);


            MemoryStream ms = new MemoryStream();
            byte[] imagedata = null;
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            imagedata = ms.GetBuffer();

            bitmap.Dispose();
            g.Dispose();

            Response.ContentType = "image/gif";
            Response.BinaryWrite(imagedata);// 在此处放置用户代码以初始化页面// 在此处放置用户代码以初始化页面
        }
        /// <summary>
        /// 加水印文字
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="_width">原始图片的宽度</param>
        /// <param name="_height">原始图片的高度.</param>
        private void addWatermarkText(Graphics picture, int _width, int _height, string WaterText)
        {
            Font crFont = null;
            SizeF crSize = new SizeF();

            crFont = new Font("Arial", 13f, FontStyle.Bold);
            crSize = picture.MeasureString(WaterText, crFont);


            float xpos = 0;
            float ypos = 0;
            xpos = ((float)_width * (float).01) + (crSize.Width / 2);
            ypos = (float)_height * (float).01;


            StringFormat StrFormat = new StringFormat();
            StrFormat.Alignment = StringAlignment.Center;

            SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(153, 0, 0, 0));
            picture.DrawString(WaterText, crFont, semiTransBrush2, xpos + 1, ypos + 1, StrFormat);

            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));
            picture.DrawString(WaterText, crFont, semiTransBrush, xpos, ypos, StrFormat);


            semiTransBrush2.Dispose();
            semiTransBrush.Dispose();

        }

        public string CreateRnd(int Leng)
        {
            string Ar1 = "A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z,2,3,4,5,6,7,8,9";
            //登录页面验证是否简单验证，即验证码为数字组成，否则由数字+字母组成。如果简单=1,否则=0
            string LoginSimpleVlidate = ApplicationOperate.GetConfigValueByName("LoginSimpleVlidate");
            if (LoginSimpleVlidate == "1")
                Ar1 = "0,1,2,3,4,5,6,7,8,9";

            string[] ListAr = Ar1.Split(',');
            Random RD = new Random();
            int rnd = 0;
            string strRnd = "";
            for (int j = 1; j < Leng; j++)
            {
                rnd = RD.Next(0, ListAr.Length);
                strRnd += ListAr[rnd];
            }
            return strRnd;
        }
    }
}
