using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace HTProject_Bizlogic
{
    public class BeiAnImageUtil
    {
        private String folder = "E:\\"; //Test only

        public byte[] createImage(String sourceImagePath, String beiAnNumber, String beiAnStampImagePath)
        {
            Bitmap bitMapImage = new System.Drawing.Bitmap(sourceImagePath);
            return this.createImage(bitMapImage, beiAnNumber, beiAnStampImagePath);
        }

        public int getTimeStamp()
        {
            int timestamp = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            return timestamp;
        }

        public byte[] createImage(Bitmap bitMapImage, String beiAnNumber, String beiAnStampImagePath)
        {
            Graphics graphicImage = Graphics.FromImage(bitMapImage);

            //Smooth graphics is nice.
            graphicImage.SmoothingMode = SmoothingMode.AntiAlias;

            //Write your text.
            //graphicImage.DrawString("That's my boy!",
            //   new Font("Arial", 12, FontStyle.Bold),
            //   SystemBrushes.WindowText, new Point(0, 0));

            Size size = bitMapImage.Size;
            Font font = new Font("Tahoma", 12);
            //int x_axis = 910;
            int y_axis = 25;
            int x_axis = size.Width - 220;
            //int y_axis = size.Height-100;
            int distance = 25;
            graphicImage.DrawString(beiAnNumber, font, Brushes.Black, new PointF(x_axis, y_axis));
            graphicImage.DrawString(DateTime.Now.ToString("yyyy-MM-dd"), font, Brushes.Black, new PointF(x_axis + 90, y_axis + distance));
            String validDate = DateTime.Now.AddYears(2).ToString("yyyy-MM-dd");
            graphicImage.DrawString("有效期至:" + validDate, font, Brushes.Black, new PointF(x_axis, y_axis + distance * 2));

            String tempFile = folder + getTimeStamp() + ".jpeg";
            bitMapImage.Save(tempFile, ImageFormat.Jpeg);
            MemoryStream ms = new MemoryStream();
            //bitMapImage.Save(ms, ImageFormat.Jpeg);
            //graphicImage.Save();

            //I am drawing a oval around my text.
            //graphicImage.DrawArc(new Pen(Color.Red, 3), 90, 235, 150, 50, 0, 360);

            //Set the content type
            //Response.ContentType = "image/jpeg";
            //Save the new image to the response output stream.
            //bitMapImage.Save(Response.OutputStream, ImageFormat.Jpeg);

            //Clean house.
            //graphicImage.Dispose();
            //bitMapImage.Dispose();
            byte[] bytes = MergeJpeg(tempFile, beiAnStampImagePath);

            //Delete temp file
            if (System.IO.File.Exists(tempFile))
            {
                // Use a try block to catch IOExceptions, to 
                // handle the case of the file already being 
                // opened by another process. 
                try
                {
                    System.IO.File.Delete(tempFile);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return bytes;
                }
            }
            return bytes;
        }

        //在左上角盖章，右上角动态写有效期
        public void addStampAndDate(Image bitMapImage, Graphics graphicImage, String beiAnNumber, String beiAnStampImagePath, int width)
        {
            //Draw valid date range
            //Smooth graphics is nice.
            graphicImage.SmoothingMode = SmoothingMode.AntiAlias;


            Size size = bitMapImage.Size;
            Font font = new Font("Tahoma", 12);
            //int x_axis = 910;
            int y_axis = 5;
            int x_axis = width;
            //int y_axis = size.Height-100;
            //int distance = 25;
            graphicImage.DrawString(beiAnNumber, font, Brushes.Black, new PointF(x_axis, y_axis));
            //graphicImage.DrawString(DateTime.Now.ToString("yyyy-MM-dd"), font, Brushes.Black, new PointF(x_axis + 90, y_axis + distance));
            //String validDate = DateTime.Now.AddYears(2).ToString("yyyy-MM-dd");
            //graphicImage.DrawString("有效期至:" + validDate, font, Brushes.Black, new PointF(x_axis, y_axis + distance * 2));

            //Add Stamp
            Image image2 = Image.FromFile(beiAnStampImagePath);

            //graphics.Clear(Color.Black);

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
            Point stampPoint = new Point(30, 20);
            //Add stamp on top
            //graphicImage.DrawImage(image2, stampPoint);

            //Add stamp as watermark
            //graphics.DrawImage(image2, new Rectangle(30, 20, image2.Width, image2.Height), 0, 0, image2.Width, image2.Height, GraphicsUnit.Pixel, imageAttributes);
            //graphics.DrawImage(image2, new Point(0, image1.Height - image2.Height));

            graphicImage.Dispose();
            image2.Dispose();            
        }

        public void addDate(Image bitMapImage, Graphics graphicImage, String beiAnNumber)
        {
            Size size = bitMapImage.Size;
            Font font = new Font("Tahoma", 12);
            //int x_axis = 910;
            int y_axis = 25;
            int x_axis = size.Width - 220;
            //int y_axis = size.Height-100;
            int distance = 25;
            graphicImage.DrawString(beiAnNumber, font, Brushes.Black, new PointF(x_axis, y_axis));
            graphicImage.DrawString(DateTime.Now.ToString("yyyy-MM-dd"), font, Brushes.Black, new PointF(x_axis + 90, y_axis + distance));
            String validDate = DateTime.Now.AddYears(2).ToString("yyyy-MM-dd");
            graphicImage.DrawString("有效期至:" + validDate, font, Brushes.Black, new PointF(x_axis, y_axis + distance * 2));
        }
        /// <summary>
        /// Merges two Jpeg images vertically
        /// </summary>
        /// <param name="inputJpeg1">filename with complete path of the first jpeg file.</param>
        /// <param name="inputJpeg2">filname with complete path of the second jpeg file.</param>
        /// <param name="outputJpeg">filename with complete path where you want to save the output jpeg file.</param>
        private byte[] MergeJpeg(string inputJpeg1, string inputJpeg2)
        {

            Image image1 = Image.FromFile(inputJpeg1);
            Image image2 = Image.FromFile(inputJpeg2);

            int width = Math.Max(image1.Width, image2.Width);
            int height = image1.Height + image2.Height;

            Bitmap outputImage = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(outputImage);

            graphics.Clear(Color.Black);
            graphics.DrawImage(image1, new Point(0, 0));

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
            Point stampPoint = new Point(30, 20);
            //Add stamp on top
            graphics.DrawImage(image2, stampPoint);

            //Add stamp as watermark
            //graphics.DrawImage(image2, new Rectangle(30, 20, image2.Width, image2.Height), 0, 0, image2.Width, image2.Height, GraphicsUnit.Pixel, imageAttributes);
            //graphics.DrawImage(image2, new Point(0, image1.Height - image2.Height));

            graphics.Dispose();
            image1.Dispose();
            image2.Dispose();

            MemoryStream stream = new MemoryStream();
            //outputImage.Save(outputJpeg, System.Drawing.Imaging.ImageFormat.Jpeg);
            outputImage.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            outputImage.Dispose();
            return stream.ToArray();
        }

        public void addStamp(Graphics graphics, String stampImagePath)
        {

            Image image2 = Image.FromFile(stampImagePath);

            //graphics.Clear(Color.Black);

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
            Point stampPoint = new Point(30, 20);
            //Add stamp on top
            graphics.DrawImage(image2, stampPoint);

            //Add stamp as watermark
            //graphics.DrawImage(image2, new Rectangle(30, 20, image2.Width, image2.Height), 0, 0, image2.Width, image2.Height, GraphicsUnit.Pixel, imageAttributes);
            //graphics.DrawImage(image2, new Point(0, image1.Height - image2.Height));

            graphics.Dispose();
            image2.Dispose();            
            
        }

        public Bitmap ByteArraytoBitmap(Byte[] byteArray)
        {
            MemoryStream stream = new MemoryStream(byteArray);

            return new System.Drawing.Bitmap(stream);
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }


        static void Main(string[] args)
        {
            BeiAnImageUtil util = new BeiAnImageUtil();
            String folder = "E:\\";
            //Bitmap bitMapImage = new System.Drawing.Bitmap(folder + "sj001_R.jpg");
            Bitmap bitMapImage = new System.Drawing.Bitmap(folder + "test.jpg");
            byte[] imageBytes = util.imageToByteArray(bitMapImage);
            //util.createImage(folder + "test.jpg", "SN-XQ-S-201311250025", folder + "test2.jpg");
            Bitmap b = util.ByteArraytoBitmap(imageBytes);

            byte[] output = util.createImage(b, "SN-XQ-S-201311250025", folder + "test2.jpg");
            Bitmap bm = util.ByteArraytoBitmap(output);
            bm.Save(folder + util.getTimeStamp() + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }


    }
}