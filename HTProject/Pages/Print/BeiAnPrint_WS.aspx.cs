using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Epoint.MisBizLogic2;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Reporting.WebForms;
using CrystalDecisions.Web;
using HTProject_Bizlogic;
using System.IO;
using Epoint.Frame.Bizlogic;
using iTextSharp.text.pdf;

namespace HTProject.Pages.Print
{
    public partial class BeiAnPrint_WS : BasePage
    {
        Epoint.MisBizLogic2.Code.DB_CodeMain DB_CM = new Epoint.MisBizLogic2.Code.DB_CodeMain();
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //先处理下附件文件夹中的备案表，防止过大
                DeleteSignedFile(Server.MapPath(Request.ApplicationPath + "/AttachStorage/"));
                HeTongBeiAn_WS myReport = new HeTongBeiAn_WS();
                string strSql = "";
                //先初始化项目信息

                //看看该公司所在的地区

                CRS_BeiAn.Report.FileName = System.Configuration.ConfigurationManager.AppSettings["BeiAnPrint_SW"];// Epoint.Frame.Common.ApplicationOperate.GetConfigValueByName("BeiAnPrint_SW", ""); ;
                //CRS_BeiAn.Report.
                #region
                HeTongInfo ds = new HeTongInfo();
                strSql = "select * from RG_XMAndRY RY where XMGuid='" + Request["RowGuid"] + "' order by substring(RY.ZhuanYeCode,1,4) asc,ddrole desc";
                DataView dvRY = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);

                for (int i = 0; i < dvRY.Count; i++)
                {
                    DataRow dr4;
                    dr4 = ds.Tables["RYOfXM"].NewRow();
                    dr4["ZiZhiText"] = dvRY[i]["ZiZhiText"].ToString();
                    dr4["ZhuanYeText"] = dvRY[i]["ZhuanYeText"].ToString();
                    dr4["RYName"] = dvRY[i]["RYName"].ToString();
                    dr4["IDNum"] = dvRY[i]["IDNum"];//Convert.ToDecimal(
                    dr4["ZhiCheng"] = DB_CM.GetCodeText_FromHash("职称", Convert.ToString(dvRY[i]["ZhiCheng"])); ;
                    dr4["YinZhangNo"] = dvRY[i]["YinZhangNo"].ToString();
                    dr4["ZhuanYeSX"] = dvRY[i]["ZhuanYeSX"].ToString();

                    //处理下从事的专业，尽量缩小
                    string ZhuanYeCS = dvRY[i]["ZhuanYeCS"].ToString();
                    
                    dr4["ZhuanYeCS"] = ZhuanYeCS;
                    dr4["GongLing"] = dvRY[i]["GongLing"];
                    dr4["DDRole"] = DB_CM.GetCodeText_FromHash("项目角色", Convert.ToString(dvRY[i]["DDRole"]));
                    dr4["OrNo"] = i + 1;
                    ds.Tables["RYOfXM"].Rows.Add(dr4);
                }
                
                //HeTongBeiAn oCR = new HeTongBeiAn();
                myReport.SetDataSource(ds.Tables["RYOfXM"]);
                #endregion

                #region 参数
                strSql = "select * from RG_XMBeiAn where RowGuid='" + Request["RowGuid"] + "'";
                DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
                
                string XMAdd = "";
                
                string XMBH = "";
                string STATUS = "";
                if (dv.Count > 0)
                {
                    strSql = "select * from RG_OUInfo where RowGuid='" + dv[0]["DWGuid"] + "'";
                    DataView dvDW = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
                    if (dvDW.Count > 0)
                    {
                        STATUS = dv[0]["STATUS"].ToString();
                        myReport.SetParameterValue("DWName", dvDW[0]["EnterpriseName"]);
                        myReport.SetParameterValue("DWAddress", dvDW[0]["ZhuCeDi_XX"].ToString());
                        myReport.SetParameterValue("DWYB", dvDW[0]["YouZhengCode"].ToString());
                        myReport.SetParameterValue("DWXZ", dvDW[0]["DanWeiXZ"].ToString());
                        myReport.SetParameterValue("DWFR", dvDW[0]["FaRen"].ToString());
                        myReport.SetParameterValue("DWDH", dvDW[0]["DanWeiTel"].ToString());
                        myReport.SetParameterValue("DWLXR", dvDW[0]["LianXiRen"].ToString());
                        myReport.SetParameterValue("DWLXRDH", dvDW[0]["LianXiRenTel"].ToString());
                        string tb = dv[0]["TJDate"].ToString() == "" ? dv[0]["OperateDate"].ToString() : dv[0]["TJDate"].ToString();
                        myReport.SetParameterValue("TBDate", DateTime.Parse(tb).ToString("yyyy-MM-dd"));
                        myReport.SetParameterValue("FuZaCD", dv[0]["FuZaCD"].ToString());
                        myReport.SetParameterValue("YeWuFW", dv[0]["YeWuFW"].ToString());
                    }
                    else
                    {
                        myReport.SetParameterValue("DWName", "");
                        myReport.SetParameterValue("DWAddress", "");
                        myReport.SetParameterValue("DWYB", "");
                        myReport.SetParameterValue("DWXZ", "");
                        myReport.SetParameterValue("DWFR", "");
                        myReport.SetParameterValue("DWDH", "");
                        myReport.SetParameterValue("DWLXR", "");
                        myReport.SetParameterValue("DWLXRDH", "");
                    }
                    //注意处理，如果没有的话，就把编号的前面取出来
                    XMBH = RG_DW.GetXMBH(dv[0]["RowGuid"], dv[0]["DWGuid"], dv[0]["XMAdd"], dv[0]["XMBH"], dv[0]["XMLB"]);
                    myReport.SetParameterValue("XMBH", XMBH);
                    XMAdd = dv[0]["XMAdd"].ToString();
                    //加区县通过时间和市建设局通过时间
                    //看看有没有市的通过时间，如果有就加在后面，否则加在区县的后面
                    
                    string YXQ = "";
                    if (dv[0]["TGDate"].ToString() == "")
                    {
                        if (dv[0]["QXTG_Date"].ToString() == "")
                        {
                            DateTime dtPass = DateTime.Parse(dv[0]["QXTG_Date"].ToString());
                            string qxTGDate = dtPass.ToString("yyyy 年 MM 月 dd 日 ");
                            YXQ = "有效期至：" + dtPass.AddYears(2).ToString("yyyy年MM月dd日");
                            myReport.SetParameterValue("QXTGDate", qxTGDate + "\n" + YXQ);
                        }
                        else
                        {
                            string qxTGDate = "      年    月    日 ";
                            myReport.SetParameterValue("QXTGDate", qxTGDate);
                        }
                        myReport.SetParameterValue("TGDate", "      年    月    日 ");
                    }
                    else
                    {
                        if (dv[0]["QXTG_Date"].ToString() != "")
                        {
                            myReport.SetParameterValue("QXTGDate", DateTime.Parse(dv[0]["QXTG_Date"].ToString()).ToString("yyyy年MM月dd日"));
                        }
                        else
                        {
                            myReport.SetParameterValue("QXTGDate", "      年    月    日 ");
                        }
                        DateTime dtPass = DateTime.Parse(dv[0]["TGDate"].ToString());
                        string TGDate = dtPass.ToString("yyyy年MM月dd日");
                        YXQ = "有效期至：" + dtPass.AddYears(2).ToString("yyyy年MM月dd日");
                        myReport.SetParameterValue("TGDate", TGDate + "\n" + YXQ);
                    }
                }

                #endregion

                CrystalDecisions.Shared.DiskFileDestinationOptions DiskOpts = new CrystalDecisions.Shared.DiskFileDestinationOptions();
                myReport.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
                myReport.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
                string timeNow = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string fileName = timeNow + "XMBA.pdf";
                DiskOpts.DiskFileName = Server.MapPath(Request.ApplicationPath + "/AttachStorage/" + fileName);
                myReport.ExportOptions.DestinationOptions = DiskOpts;
                myReport.Export();

                //判断下状态，如果是已经审核通过了，那么就处理公章，否则直接加载
                if (STATUS != "90")
                {
                    if (this.LoginID == "admin")
                    {
                        string WatermarkImageUrl = Server.MapPath(Request.ApplicationPath + "/HTProject/Pages/Images/合同备案公章.gif");
                        string message = "";
                        string fileNewName = timeNow + "_2XMBA.pdf";
                        string fileNew = Request.ApplicationPath + "/AttachStorage/" + fileNewName;
                        WatermarkPDF(DiskOpts.DiskFileName, Server.MapPath(fileNew), WatermarkImageUrl, 568, 500, 115, 115, out message, XMAdd);
                        Response.Write("<script language=javascript> window.location.href = 'pdfReader.aspx?fileName=" + fileNewName + "'; </script> ");
                    }
                    else
                    {
                        Response.Write("<script language=javascript> window.location.href = 'pdfReader.aspx?fileName=" + fileName + "'; </script> ");
                    }
                }
                else
                {
                    string WatermarkImageUrl = Server.MapPath(Request.ApplicationPath + "/HTProject/Pages/Images/合同备案公章.gif");
                    string message = "";
                    string fileNewName = timeNow + "_2XMBA.pdf";
                    string fileNew = Request.ApplicationPath + "/AttachStorage/" + fileNewName;
                    WatermarkPDF(DiskOpts.DiskFileName, Server.MapPath(fileNew), WatermarkImageUrl, 568, 500, 115, 115, out message, XMAdd);
                    Response.Write("<script language=javascript> window.location.href = 'pdfReader.aspx?fileName=" + fileNewName + "'; </script> ");
                }
                
            }
        }

        private void DeleteSignedFile(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            //遍历该路径下的所有文件 

            foreach (FileInfo fi in di.GetFiles())
            {

                string exname = fi.Name;//得到后缀名 //判断当前文件后缀名是否与给定后缀名一样 

                if (exname.IndexOf("XMBA") >= 0 && fi.CreationTime <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                {
                    try
                    {

                        File.Delete(path + "\\" + fi.Name);//删除当前文件
                    }
                    catch
                    { }
                }

            }


        }

        public bool WatermarkPDF(string SourcePdfPath, string OutputPdfPath, string WatermarkImageUrl, int positionX, int positionY, int WatermarkHeight, int WatermarkWidth, out string msg, string XMAdd)
        {
            try
            {
                PdfReader reader = new PdfReader(SourcePdfPath);
                PdfStamper stamp = new PdfStamper(reader, new FileStream(OutputPdfPath, FileMode.Create));
                int n = reader.NumberOfPages;
                int i = 0;
                PdfContentByte under;
                int WatermarkWidth2 = WatermarkWidth;
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
                    //还要在最后一页加盖公章，如果是江阴、宜兴的，要同时加盖他们对应的公章，然后再加上市建设局的公章
                    if (i == n)//表示是最后一页
                    {
                        string imgPath = "";
                        string imgHYPath = Server.MapPath(Request.ApplicationPath + "/HTProject/Pages/Images/核验章.png");
                        iTextSharp.text.Image imHY = iTextSharp.text.Image.GetInstance(imgHYPath);
                        
                        imHY.ScaleAbsolute(100, 50);
                        //江阴/宜兴
                        if (XMAdd == "320281")
                        {
                            imgPath = Server.MapPath(Request.ApplicationPath + "/HTProject/Pages/Images/江阴合同备案公章.gif");
                            iTextSharp.text.Image imQX = iTextSharp.text.Image.GetInstance(imgPath);
                            imQX.SetAbsolutePosition(400, 350);
                            imQX.ScaleAbsolute(WatermarkWidth2, WatermarkHeight);

                            under = stamp.GetUnderContent(i);
                            under.AddImage(imQX, true);

                            //加核验章
                            imHY.SetAbsolutePosition(200, 390);
                            under.AddImage(imHY, true);
                        }
                        else if (XMAdd == "320282")
                        {
                            imgPath = Server.MapPath(Request.ApplicationPath + "/HTProject/Pages/Images/宜兴合同备案公章.gif");
                            iTextSharp.text.Image imQX = iTextSharp.text.Image.GetInstance(imgPath);
                            imQX.SetAbsolutePosition(400, 350);
                            imQX.ScaleAbsolute(WatermarkWidth2, WatermarkHeight);

                            under = stamp.GetUnderContent(i);
                            under.AddImage(imQX, true);

                            //加核验章
                            imHY.SetAbsolutePosition(200, 390);
                            under.AddImage(imHY, true);
                        }

                        //无锡市
                        imgPath = Server.MapPath(Request.ApplicationPath + "/HTProject/Pages/Images/合同备案公章.gif");
                        iTextSharp.text.Image imWX = iTextSharp.text.Image.GetInstance(imgPath);
                        imWX.SetAbsolutePosition(400, 150);
                        imWX.ScaleAbsolute(WatermarkWidth2, WatermarkHeight);

                        under = stamp.GetUnderContent(i);
                        under.AddImage(imWX, true);

                        //加核验章
                        imHY.SetAbsolutePosition(200, 190);
                        under.AddImage(imHY, true);
                    }
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
