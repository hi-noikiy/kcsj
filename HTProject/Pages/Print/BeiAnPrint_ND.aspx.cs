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
using iTextSharp;
using iTextSharp.text.pdf;
using System.Drawing;
using Epoint.Frame.Bizlogic;

namespace HTProject.Pages.Print
{
    public partial class BeiAnPrint_ND : BasePage
    {
        Epoint.MisBizLogic2.Code.DB_CodeMain DB_CM = new Epoint.MisBizLogic2.Code.DB_CodeMain();
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //先处理下附件文件夹中的备案表，防止过大
                DeleteSignedFile(Server.MapPath(Request.ApplicationPath + "/AttachStorage/"));
                HeTongBeiAn_ND myReport = new HeTongBeiAn_ND();
                string strSql = "";
                string WatermarkImageUrl = Server.MapPath(Request.ApplicationPath + "/HTProject/Pages/Images/合同备案公章.gif");
                
                //先初始化项目信息

                //看看该公司所在的地区

                CRS_BeiAn.Report.FileName = System.Configuration.ConfigurationManager.AppSettings["BeiAnPrint_ND"]; 

                #region 人员
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

                myReport.SetDataSource(ds.Tables["RYOfXM"]);
                #endregion

                #region 参数
                strSql = "select * from RG_XMBeiAn where RowGuid='" + Request["RowGuid"] + "'";
                DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
                string DWName = "";
                string TJDate = "";
                string XMName = "";
                string XMAdd = "";
                string ToTalMoney = "";
                string GuiMoDJ = "";
                string JSDWName = "";
                string XMLXR_JS = "";
                string LXDH_JS = "";
                string XMLXR_KS = "";
                string LXDH_KS = "";
                string XMFZR = "";
                string ZiZhiDJ = "";
                string ZiZhiDJ_ZH = "";
                string HeTongMoney = "";
                string XMBH = "";
                string STATUS = "";
                //有效期
                string YXQ = "";
                if (dv.Count > 0)
                {
                    STATUS = dv[0]["STATUS"].ToString();
                    strSql = "select EnterpriseName from RG_OUInfo where RowGuid='" + dv[0]["DWGuid"] + "'";
                    DWName = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);

                    myReport.SetParameterValue("DWName", DWName);
                    if (dv[0]["TJDate"].ToString() != "")
                    {
                        TJDate = DateTime.Parse(dv[0]["TJDate"].ToString()).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        TJDate = "";
                    }
                    myReport.SetParameterValue("TJDate", TJDate);
                    XMName = dv[0]["XMName"].ToString();
                    myReport.SetParameterValue("XMName", XMName);
                    XMAdd = DB_CM.GetCodeText_FromHash("项目地点", Convert.ToString(dv[0]["XMAddress"]));
                    myReport.SetParameterValue("XMAddress", XMAdd);
                    ToTalMoney = dv[0]["ToTalMoney"] + "万元";
                    myReport.SetParameterValue("ToTalMoney", ToTalMoney);
                    ZiZhiDJ = dv[0]["ZiZhiDJ"].ToString();
                    ZiZhiDJ_ZH = dv[0]["ZiZhiBH"].ToString();
                    myReport.SetParameterValue("ZiZhiDJ", ZiZhiDJ);
                    //myReport.SetParameterValue("ZiZhiDJ_ZH", ZiZhiDJ_ZH);
                    HeTongMoney = dv[0]["HeTongMoney"] + "万元";
                    myReport.SetParameterValue("HeTongMoney", HeTongMoney);
                    GuiMoDJ = DB_CM.GetCodeText_FromHash("项目规模等级", Convert.ToString(dv[0]["GuiMoDJ"]));
                    myReport.SetParameterValue("GuiMoDJ", GuiMoDJ);
                    //JSDWName = dv[0]["JSDWName"].ToString();
                    //myReport.SetParameterValue("JSDWName", JSDWName);
                    //XMLXR_JS = dv[0]["XMLXR_JS"].ToString();
                    //myReport.SetParameterValue("XMLXR_JS", XMLXR_JS);
                    //LXDH_JS = dv[0]["LXDH_JS"].ToString();
                    //myReport.SetParameterValue("LXDH_JS", LXDH_JS);
                    XMLXR_KS = dv[0]["XMLXR_KS"].ToString();
                    myReport.SetParameterValue("XMLXR_KS", XMLXR_KS);
                    LXDH_KS = dv[0]["LXDH_KS"].ToString();//+ "/" + dv[0]["SJ_KS"].ToString()
                    myReport.SetParameterValue("LXDH_KS", LXDH_KS);
                    XMFZR = dv[0]["XMFZR"].ToString();
                    myReport.SetParameterValue("XMFZR", XMFZR);
                    XMBH = dv[0]["XMBH"].ToString();
                    //注意处理，如果没有的话，就把编号的前面取出来
                    XMBH = RG_DW.GetXMBH(dv[0]["RowGuid"], dv[0]["DWGuid"], dv[0]["XMAdd"], dv[0]["XMBH"], dv[0]["XMLB"]);
                    myReport.SetParameterValue("XMBH", XMBH);
                    //获取最后一次审核通过意见
                    if (dv[0]["Status"].ToString() == "90")
                    {
                        //myReport.SetParameterValue("SHOpinion", RG_DW.GetLastSHOpinion(Request["RowGuid"], ""));
                        if (dv[0]["TGDate"].ToString() != "")
                        {
                            //myReport.SetParameterValue("TGDate", DateTime.Parse(dv[0]["TGDate"].ToString()).ToString("yyyy年MM月dd日"));
                            DateTime dtPass = DateTime.Parse(dv[0]["TGDate"].ToString());
                            YXQ = "有效期至：" + dtPass.AddYears(2).ToString("yyyy年MM月dd日");
                            myReport.SetParameterValue("TGDate", dtPass.ToString("yyyy年MM月dd日") + "\n" + YXQ);
                        }
                        else
                        {
                            myReport.SetParameterValue("TGDate", "    年  月  日");
                        }
                    }
                    else
                    {
                        //myReport.SetParameterValue("SHOpinion", "");
                        myReport.SetParameterValue("TGDate", "    年  月  日");
                    }
                    //重点注意，要分地区加盖相应的公章，宜兴的就加盖宜兴，江阴的就加盖江阴公章
                    //判断是否是宜兴的或江阴的
                    if (dv[0]["XMAdd"].ToString() == "320281")//江阴
                    {
                        WatermarkImageUrl = Server.MapPath(Request.ApplicationPath + "/HTProject/Pages/Images/江阴合同备案公章.gif");
                    }
                    else if (dv[0]["XMAdd"].ToString() == "320282")//宜兴
                    {
                        WatermarkImageUrl = Server.MapPath(Request.ApplicationPath + "/HTProject/Pages/Images/宜兴合同备案公章.gif");
                    }
                }

                #endregion

                CrystalDecisions.Shared.DiskFileDestinationOptions DiskOpts = new CrystalDecisions.Shared.DiskFileDestinationOptions();
                myReport.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
                myReport.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
                string thisTime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string fileName = thisTime + "XMBA.pdf";
                DiskOpts.DiskFileName = Server.MapPath(Request.ApplicationPath + "/AttachStorage/" + fileName);
                myReport.ExportOptions.DestinationOptions = DiskOpts;
                myReport.Export();
                //判断下状态，如果是已经审核通过了，那么就处理公章，否则直接加载
                if (STATUS != "90")
                {
                    if (this.LoginID == "admin")
                    {
                        
                        string message = "";
                        string fileNewName = thisTime + "_2XMBA.pdf";
                        string fileNew = Request.ApplicationPath + "/AttachStorage/" + fileNewName;
                        WatermarkPDF(DiskOpts.DiskFileName, Server.MapPath(fileNew), WatermarkImageUrl, 400, 500, 115, 115, out message, dvRY.Count);
                        Response.Write("<script language=javascript> window.location.href = 'pdfReader.aspx?fileName=" + fileNewName + "'; </script> ");
                    }
                    else
                    {
                       
                        Response.Write("<script language=javascript> window.location.href = 'pdfReader.aspx?fileName=" + fileName + "'; </script> ");
                    }
                }
                else
                {
                    //string WatermarkImageUrl = Server.MapPath(Request.ApplicationPath + "/HTProject/Pages/Images/合同备案公章.gif");
                    string message = "";
                    string fileNewName = thisTime + "_2XMBA.pdf";
                    string fileNew = Request.ApplicationPath + "/AttachStorage/" + fileNewName;
                    WatermarkPDF(DiskOpts.DiskFileName, Server.MapPath(fileNew), WatermarkImageUrl, 400, 500, 115, 115, out message, dvRY.Count);
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

                if (exname.IndexOf("XMBA") >= 0 && fi.CreationTime <= DateTime.Now.AddMinutes(-30))//new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,DateTime.Now.Hour,DateTime.Now.Month-10,0)
                {
                    try
                    {
                        File.Delete(path + "\\" + fi.Name);//删除当前文件
                    }
                    catch
                    { }
                }
            }
            foreach (DirectoryInfo d in di.GetDirectories())
            {

                //string exname = fi.Name;//得到后缀名 //判断当前文件后缀名是否与给定后缀名一样 

                if (d.CreationTime <= DateTime.Now.AddDays(-10))//new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,DateTime.Now.Hour,DateTime.Now.Month-10,0)
                {
                    try
                    {
                        //Directory.Delete(path + "\\" + d.Name);
                        //File.Delete(path + "\\" + fi.Name);//删除当前文件
                        foreach (FileInfo fi in d.GetFiles())
                        {

                            string exname = fi.Name;//得到后缀名 //判断当前文件后缀名是否与给定后缀名一样 


                            try
                            {
                                File.Delete(path + d.Name + "\\" + fi.Name);//删除当前文件
                            }
                            catch
                            { }

                            Directory.Delete(path + d.Name);

                        }
                    }
                    catch (Exception e)
                    { }
                }
            }
        }

        public bool WatermarkPDF(string SourcePdfPath, string OutputPdfPath, string WatermarkPath, int positionX, int positionY, int WatermarkHeight, int WatermarkWidth, out string msg, int ryCount)
        {
            try
            {
                
                PdfReader reader = new PdfReader(SourcePdfPath);
                PdfStamper stamp = new PdfStamper(reader, new FileStream(OutputPdfPath, FileMode.Create));
                int n = reader.NumberOfPages;
                int i = 0;
                PdfContentByte under;
                
                while (i < n)
                {
                    i++;
                    under = stamp.GetUnderContent(i);
                    iTextSharp.text.Image im = iTextSharp.text.Image.GetInstance(WatermarkPath);
                    im.ScaleAbsolute(WatermarkWidth, WatermarkHeight);
                    //im.SetAbsolutePosition(positionX, positionY);

                    float height = 841;
                    if (i == n)
                    {
                        string imgHYPath = Server.MapPath(Request.ApplicationPath + "/HTProject/Pages/Images/核验章.png");
                        iTextSharp.text.Image imHY = iTextSharp.text.Image.GetInstance(imgHYPath);
                        imHY.ScaleAbsolute(100, 50);
                        if (i == 1)//说明就一页
                        {
                            height = height - 160 - ryCount * 23 - 115;
                            //再加上已核验的章
                            imHY.SetAbsolutePosition(200, height + 35);
                            
                        }
                        else
                        {
                            height = height - (ryCount - 18) * 23;
                            //再加上已核验的章
                            imHY.SetAbsolutePosition(200, height + 35);
                            
                        }
                        under.AddImage(imHY, true);
                        im.SetAbsolutePosition(positionX, height);
                    }
                    else//不是第一页，也不是最后一页
                    {
                        im.SetAbsolutePosition(positionX, positionY);
                    }
                    
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
