using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HTProject_Bizlogic;
using Epoint.Frame.Common;

namespace HTProject.Pages.RG_XMBeiAn
{

    public partial class RG_XMBeiAnAD_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2021;
        HTProject_Bizlogic.DataBaseFunc DBF = new DataBaseFunc();
        Epoint.MisBizLogic2.Web.DetailPage oDetailPage;
        protected HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                ViewState["TableName"] = oDetailPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);

                if (!oRow.R_HasFilled)
                {
                    //lblMessage.Visible=true;
                    this.AlertAjaxMessage("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_DetailPage(oDetailPage, tdContainer, oRow);
                BindZhuanYe();
                //HTBA.ClientGuid = Request["RowGuid"] + "HTBA";
                //HTBA.NodeCode = DWGuid_2021.Text;
                //HTBA.MisRowGuid = Request["RowGuid"];
                XM_HTBA.ClientGuid = Request["RowGuid"] + "XM_HTBA";
                XM_HTBA.NodeCode = DWGuid_2021.Text;
                XM_HTBA.MisRowGuid = Request["RowGuid"];
                XM_HTBA.Status = oRow["Status"].ToString();

                SJHT.ClientGuid = Request["RowGuid"] + "XM_SJHT";
                SJHT.NodeCode = DWGuid_2021.Text;
                SJHT.MisRowGuid = Request["RowGuid"];

                QY_CXZM.ClientGuid = Request["RowGuid"] + "QY_CXZM";
                QY_CXZM.NodeCode = DWGuid_2021.Text;
                QY_CXZM.MisRowGuid = Request["RowGuid"];

                //判断是否该显示操作按钮
                if (String.IsNullOrEmpty(Request["MessageItemGuid"]))
                {
                    tabOP.Visible = false;
                }

                lblSHOpinion.Text = RG_DW.GetSHOpinion(Request["RowGuid"], "");

                
                string QYZCD2 = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT RegistAddressCode FROM RG_OUInfo WHERE RowGuid='" + DWGuid_2021.Text + "'");
                if (QYZCD2.Substring(0, 2) == "32")
                {
                    lblTips.Text = RG_DW.GetTip(oRow["Status"], "", "0", oRow["XMAdd"].ToString());
                }
                else
                {
                    lblTips.Text = RG_DW.GetTip(oRow["Status"], "", "1", oRow["XMAdd"].ToString());
                }

                lblOUName.Text = RG_DW.GetDWName(DWGuid_2021.Text);

                lblCS.Text = new DB_RG_DW().CreateXMBH(Request["RowGuid"], DWGuid_2021.Text, oRow["XMAdd"], "K", "320282", 2015);
            }
            //如果是省内的，就不要显示
            string QYZCD = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT RegistAddressCode FROM RG_OUInfo WHERE RowGuid='" + DWGuid_2021.Text + "'");
            if (QYZCD.Substring(0, 2) == "32")
            {
                XM_HTBA.SAdd = "SN";
                YeWuFW_2021.Visible = false;
                FuZaCD_2021.Visible = false;
                WriteAjaxMessage("document.getElementById('trFW').style.display = 'none';");
                WriteAjaxMessage("document.getElementById('trFZ').style.display = 'none';");
            }
            else
            {
                XM_HTBA.SAdd = "SW";
            }
            
        }

        override protected void OnInit(EventArgs e)
        {
            oDetailPage = new Epoint.MisBizLogic2.Web.DetailPage(TableID);
            base.OnInit(e);
        }

        protected void BindZhuanYe()
        {
            string strSql = " select * from RG_XMAndZY where 1=1  and XMGuid='" + Request["RowGuid"] + "' ";
            strSql += " and DWGuid='" + DWGuid_2021.Text + "' and ZiZhiCode='" + ZiZhiDJCode_2021.Text + "' ";
            strSql += " ORDER BY ZhuanYeCode asc ";
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            DGZhuanYe.DataSource = dv;
            DGZhuanYe.DataBind();
        }

        protected DataView GetRY(object ZhuanYeCode)
        {
            string strSql = " select * from RG_XMAndRY RY where 1=1  and XMGuid='" + Request["RowGuid"] + "' ";
            strSql += " and DWGuid='" + DWGuid_2021.Text + "' and ZiZhiCode='" + ZiZhiDJCode_2021.Text + "' and ZhuanYeCode='" + ZhuanYeCode + "' ";
            strSql += " ORDER BY RY.ZhuanYeCode asc,RY.DDRole desc ";
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            return dv;
        }

        HTProject_Bizlogic.SMS HTSMS = new SMS();
        DB_RG_User DB_R_User = new DB_RG_User(); 
        protected void btnPass_Click(object sender, System.EventArgs e)
        {
            //这个地方要注意，如果是江阴、宜兴的项目，要先到江阴、宜兴审核，然后再到市总办审核
            //特别注意：2013-09-24新增变更，如果是省外的、年度备案的企业，如果在区县的，只要区县建设局审核即可
            DataView dv = new DataView(); //DBF.GetUserByRoleName("备案信息审核");
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            bool IsND = false;//如果是省外、年度备案企业，则更改为true；
            #region 对企业进行判断
            string strSql = "SELECT IsNDBA,RegistAddress,* FROM RG_OUInfo WHERE ROWGUID='"+ DWGuid_2021.Text +"'";
            string qyzcd = "";
            DataView dvQY = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            if (dvQY.Count > 0)
            {
                qyzcd = dvQY[0]["RegistAddressCode"].ToString().Substring(0, 2);
                if (dvQY[0]["IsNDBA"].ToString() == "1")
                {
                    IsND = true;
                }
                else if (qyzcd == "32")
                {
                    IsND = true;
                }

                
            }
            #endregion
            string srStatus = oRow["Status"].ToString();
            if (oRow["XMAdd"].ToString() == "320282")//宜兴
            {
                #region 宜兴建设局
                if (srStatus == "69")//区县初审，要转到区县审批
                {
                    oRow["Status"] = "68";
                    oRow["QXTG_Date"] = DateTime.Now.ToString();
                    oRow.Update();

                    dv = DBF.GetUserByRoleName("宜兴备案信息审批");
                    
                    SaveOpinion("宜兴建设局", false);
                    SendMessage(dv, "备案审核");
                }
                else if (srStatus == "68")//区县审批
                {
                    if (IsND)// 先区县初审，在区县审批，然后结束
                    {
                        oRow["Status"] = "90";
                        oRow["QXTG_Date"] = DateTime.Now.ToString();
                        if (oRow["XMBH"].ToString() == "")
                        {
                            oRow["XMBH"] = RG_DW.CreateXMBH(Request["RowGuid"], DWGuid_2021.Text, oRow["XMAdd"], oRow["XMLB"], qyzcd);
                        }
                        oRow["TGDate"] = DateTime.Now.ToString();
                        oRow.Update();
                        SaveOpinion("宜兴建设局", true);
                    }
                    else// 先区县初审，在区县审批，然后转市里
                    {
                        oRow["Status"] = "70";
                        oRow["QXTG_Date"] = DateTime.Now.ToString();
                        oRow.Update();

                        dv = DBF.GetUserByRoleName("备案信息初审");//备案信息初审
                        
                        SaveOpinion("宜兴建设局", false);
                        SendMessage(dv, "备案初审");
                    }
                }
                else if (srStatus == "70")//处于初审中，则下一步就是审核中
                {
                    dv = DBF.GetUserByRoleName("备案信息审核");
                    oRow["Status"] = "86";
                    oRow["XMBH"] = ""; //RG_DW.CreateXMBH(Request["RowGuid"], DWGuid_2021.Text, oRow["XMAdd"], oRow["XMLB"], qyzcd);
                    oRow["TGDate"] = DateTime.Now.ToString();
                    oRow.Update();

                    SaveOpinion("无锡建设局", true);
                    SendMessage(dv, "备案审核");
                }
                else if (srStatus == "86")//处于审核中，则下一步就是审批中
                {
                    dv = DBF.GetUserByRoleName("备案信息审批");
                    oRow["Status"] = "87";
                    oRow["XMBH"] = "";// RG_DW.CreateXMBH(Request["RowGuid"], DWGuid_2021.Text, oRow["XMAdd"], oRow["XMLB"], qyzcd);
                    oRow["TGDate"] = DateTime.Now.ToString();
                    oRow.Update();

                    SaveOpinion("无锡建设局", true);
                    SendMessage(dv, "备案审批");
                }
                else
                {
                    oRow["Status"] = "90";
                    if (oRow["XMBH"].ToString() == "")
                    {
                        oRow["XMBH"] = RG_DW.CreateXMBH(Request["RowGuid"], DWGuid_2021.Text, oRow["XMAdd"], oRow["XMLB"], qyzcd);
                    }
                    oRow["TGDate"] = DateTime.Now.ToString();
                    oRow.Update();
                    SaveOpinion("无锡建设局", true);
                }
                #endregion
            }
            else if (oRow["XMAdd"].ToString() == "320281")//江阴
            {
                #region 江阴
                if (srStatus == "69")//区县初审，要转到区县审批
                {
                    oRow["Status"] = "68";
                    oRow["QXTG_Date"] = DateTime.Now.ToString();
                    oRow.Update();

                    dv = DBF.GetUserByRoleName("江阴备案信息审批");
                    
                    SaveOpinion("江阴建设局", false);
                    SendMessage(dv, "备案审核");
                }
                else if (srStatus == "68")//区县审批
                {
                    if (IsND)// 先区县初审，在区县审批，然后结束
                    {
                        oRow["Status"] = "90";
                        oRow["QXTG_Date"] = DateTime.Now.ToString();
                        if (oRow["XMBH"].ToString() == "")
                        {
                            oRow["XMBH"] = RG_DW.CreateXMBH(Request["RowGuid"], DWGuid_2021.Text, oRow["XMAdd"], oRow["XMLB"], qyzcd);
                        }
                        oRow["TGDate"] = DateTime.Now.ToString();
                        oRow.Update();
                        SaveOpinion("江阴建设局", true);
                    }
                    else// 先区县初审，在区县审批，然后转市里
                    {
                        oRow["Status"] = "70";
                        oRow["QXTG_Date"] = DateTime.Now.ToString();
                        oRow.Update();

                        dv = DBF.GetUserByRoleName("备案信息初审");
                        
                        SaveOpinion("江阴建设局", false);
                        SendMessage(dv, "备案初审");
                    }
                }
                else if (srStatus == "70")//处于初审中，则下一步就是审核中
                {
                    dv = DBF.GetUserByRoleName("备案信息审核");
                    oRow["Status"] = "86";
                    oRow["XMBH"] = ""; //RG_DW.CreateXMBH(Request["RowGuid"], DWGuid_2021.Text, oRow["XMAdd"], oRow["XMLB"], qyzcd);
                    oRow["TGDate"] = DateTime.Now.ToString();
                    oRow.Update();

                    SaveOpinion("无锡建设局", true);
                    SendMessage(dv, "备案审核");
                }
                else if (srStatus == "86")//处于审核中，则下一步就是审批中
                {
                    dv = DBF.GetUserByRoleName("备案信息审批");
                    oRow["Status"] = "87";
                    oRow["XMBH"] = "";// RG_DW.CreateXMBH(Request["RowGuid"], DWGuid_2021.Text, oRow["XMAdd"], oRow["XMLB"], qyzcd);
                    oRow["TGDate"] = DateTime.Now.ToString();
                    oRow.Update();

                    SaveOpinion("无锡建设局", true);
                    SendMessage(dv, "备案审批");
                }
                else
                {
                    oRow["Status"] = "90";
                    if (oRow["XMBH"].ToString() == "")
                    {
                        oRow["XMBH"] = RG_DW.CreateXMBH(Request["RowGuid"], DWGuid_2021.Text, oRow["XMAdd"], oRow["XMLB"], qyzcd);
                    }
                    oRow["TGDate"] = DateTime.Now.ToString();
                    oRow.Update();
                    SaveOpinion("无锡建设局", true);
                }
                #endregion
            }
            else
            {
                #region 其他
                if (srStatus == "70")//处于初审中，则下一步就是审核中
                {
                    dv = DBF.GetUserByRoleName("备案信息审核");
                    oRow["Status"] = "86";
                    oRow["XMBH"] = ""; //RG_DW.CreateXMBH(Request["RowGuid"], DWGuid_2021.Text, oRow["XMAdd"], oRow["XMLB"], qyzcd);
                    oRow["TGDate"] = DateTime.Now.ToString();
                    oRow.Update();
                   
                    SaveOpinion("无锡建设局", true);
                    SendMessage(dv, "备案初审");
                }
                else if (srStatus == "86")//处于审核中，则下一步就是审批中
                {
                    dv = DBF.GetUserByRoleName("备案信息审批");
                    oRow["Status"] = "87";
                    oRow["XMBH"] = "";// RG_DW.CreateXMBH(Request["RowGuid"], DWGuid_2021.Text, oRow["XMAdd"], oRow["XMLB"], qyzcd);
                    oRow["TGDate"] = DateTime.Now.ToString();
                    oRow.Update();
                    
                    SaveOpinion("无锡建设局", true);
                    SendMessage(dv, "备案审批");
                }
                else
                {
                    oRow["Status"] = "90";
                    if (oRow["XMBH"].ToString() == "")
                    {
                        oRow["XMBH"] = RG_DW.CreateXMBH(Request["RowGuid"], DWGuid_2021.Text, oRow["XMAdd"], oRow["XMLB"], qyzcd);
                    }
                    oRow["TGDate"] = DateTime.Now.ToString();
                    oRow.Update();
                    SaveOpinion("无锡建设局", true);
                }
                #endregion
            }
            

            this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("window.close();");
        }
        /// <summary>
        /// 发送待办事宜
        /// </summary>
        /// <param name="dvUser"></param>
        protected void SendMessage(DataView dvUser,string mesType)
        {
            for (int m = 0; m < dvUser.Count; m++)
            {
                string messageGuid = Guid.NewGuid().ToString();
                new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Insert(messageGuid,
                                    XMName_2021.Text + mesType,//"备案审核",
                                    "",
                                    dvUser[m]["UserGuid"].ToString(),
                                    dvUser[m]["DisplayName"].ToString(),
                                    "",
                                    "",
                                    "",
                                    @"HTProject/Pages/RG_XMBeiAn/RG_XMBeiAnAD_Detail.aspx?RowGuid=" + Request["RowGuid"],
                                    "",
                                    "",
                                    1,
                                    "",
                                    "",
                                    ""
                             );
                //更新标志位
                string strSql = "update messages_center set PType='备案信息审核',PGuid='" + Request["RowGuid"] + "' where MessageItemGuid='" + messageGuid + "'";
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);
            }
        }

        protected void SaveOpinion(string Opinion2,bool needSendSMS)
        {
            string Opinion = "审核通过";

            if (SHOpinion.Text.Trim() != "")
            {
                Opinion += "，审核意见为：" + Epoint.MisBizLogic2.DB.SQL_Encode(SHOpinion.Text.Trim());
            }
            RG_DW.InsertSHOpinion(Request["RowGuid"], this.DisplayName, Opinion, "");
            //AlertAjaxMessage("操作成功");
            tabOP.Visible = false;
            //删除待办事宜
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("备案信息审核", Request["RowGuid"]);
            AlertAjaxMessage("操作成功");

            if (needSendSMS)
            {
                //添加短信
                string IsSendSMS = ApplicationOperate.GetConfigValueByName("IsSendOUSMS");
                if (IsSendSMS == "1")
                {
                    Detail_RG_User D_R_User = DB_R_User.GetDetail(TJRGuid_2021.Text);
                    if (D_R_User.Mobile != "")
                    {
                        HTSMS.SendSMS(this.DisplayName, D_R_User.DispName, "您提交的" + XMName_2021.Text + "的项目备案信息已被" + Opinion2 + "审核通过，请及时关注，谢谢", D_R_User.Mobile);
                    }
                }
            }
        }

        protected void btnNoPass_Click(object sender, System.EventArgs e)
        {
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            oRow["Status"] = "80";

            oRow.Update();
            string Opinion = "审核不通过";
            if (SHOpinion.Text.Trim() != "")
            {
                Opinion += "，审核意见为：" + Epoint.MisBizLogic2.DB.SQL_Encode(SHOpinion.Text.Trim());
            }
            RG_DW.InsertSHOpinion(Request["RowGuid"], this.DisplayName, Opinion, "");
            tabOP.Visible = false;
            //AlertAjaxMessage("操作成功");
            //删除待办事宜
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("备案信息审核", Request["RowGuid"]);
            AlertAjaxMessage("操作成功");

            //添加短信
            string IsSendSMS = ApplicationOperate.GetConfigValueByName("IsSendOUSMS");
            if (IsSendSMS == "1")
            {
                Detail_RG_User D_R_User = DB_R_User.GetDetail(TJRGuid_2021.Text);
                if (D_R_User.Mobile != "")
                {
                    HTSMS.SendSMS(this.DisplayName, D_R_User.DispName, "您提交的" + XMName_2021.Text + "的项目备案信息审核未通过，请及时关注，谢谢", D_R_User.Mobile);
                }
            }

            this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("window.close();");
        }

        protected void btnXZ_Click(object sender, System.EventArgs e)
        {
            bool IsND = false;//如果是省外、年度备案企业，则更改为true；
            #region 对企业进行判断
            string strSql = "SELECT IsNDBA,RegistAddress,* FROM RG_OUInfo WHERE ROWGUID='" + DWGuid_2021.Text + "'";
            string qyzcd = "";
            DataView dvQY = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            if (dvQY.Count > 0)
            {
                qyzcd = dvQY[0]["RegistAddressCode"].ToString().Substring(0, 2);
                if (dvQY[0]["IsNDBA"].ToString() == "1" && qyzcd != "32")
                {
                    IsND = true;
                }

            }
            #endregion
            //string QYZCD = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT RegistAddressCode FROM RG_OUInfo WHERE RowGuid='" + DWGuid_2021.Text + "'");
            if (qyzcd == "32")
            {
                WriteAjaxMessage("OpenWindow('../Print/BeiAnPrint.aspx?RowGuid=" + Request["RowGuid"] + "', '800', '700');");
            }
            else
            {
                if (IsND)
                {
                    WriteAjaxMessage("OpenWindow('../Print/BeiAnPrint_ND.aspx?RowGuid=" + Request["RowGuid"] + "', '800', '700');");
                }
                else
                {
                    WriteAjaxMessage("OpenWindow('../Print/BeiAnPrint_WS.aspx?RowGuid=" + Request["RowGuid"] + "', '800', '700');");
                }
            }
            //最后
            
        }
    }
}

