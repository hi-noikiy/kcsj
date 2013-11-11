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
using Epoint.RegisterUser.DataSyn.Bizlogic;

namespace HTProject.Pages.RG_User
{
    public partial class Record_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        
        Epoint.RegisterUser.Front.Bizlogic.UserMailandSMS.Sipac_SMS_Send SMS_Send = new Epoint.RegisterUser.Front.Bizlogic.UserMailandSMS.Sipac_SMS_Send();

        Epoint.RegisterUser.Front.Bizlogic.SymmetricMethod SymmetricMethod = new Epoint.RegisterUser.Front.Bizlogic.SymmetricMethod();
        Epoint.RegisterUser.Front.Bizlogic.UserMailandSMS.UserMail usermail = new Epoint.RegisterUser.Front.Bizlogic.UserMailandSMS.UserMail();
        public int TableID = 99;
        Epoint.MisBizLogic2.Web.DetailPage oDetailPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            Epoint.MisBizLogic2.Code.DB_CodeMain codemain = new Epoint.MisBizLogic2.Code.DB_CodeMain();
            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oDetailPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                if (!oRow.R_HasFilled)
                {
                    this.AlertAjaxMessage("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }
                if (Convert.ToString(oRow["UserType"]) == "001")
                {
                    trperson.Style["display"] = "";
                    tabou.Style["display"] = "none";
                    trDanwei.Style["display"] = "none";
                    trOuType.Style["display"] = "none";
                }
                else
                    if (Convert.ToString(oRow["UserType"]) == "003")
                    {
                        trperson.Style["display"] = "";
                        tabou.Style["display"] = "none";
                        trDanwei.Style["display"] = "";
                        trOuType.Style["display"] = "";
                        Epoint.MisBizLogic2.Data.MisGuidRow userrow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_User", Request["RowGuid"]);
                        OUBelong.Text = Epoint.MisBizLogic2.DB.ExecuteToString("select EnterpriseName from RG_OUInfo where RowGuid='" + userrow["DanWeiGuid"].ToString() + "'");
                        DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select * FROM RG_OuType_Relate WHERE RelatedGuid='" + Request["RowGuid"] + "'and RelatedType='User'");
                        string Type = "";
                        foreach (DataRowView row in dv)
                        {
                            Type += codemain.GetCodeText_FromHash("RG_会员单位", row["OuType"].ToString()) + ';';
                        }
                        OUType.Text = Type;
                    }
                    else
                    {
                        trperson.Style["display"] = "none";
                        tabou.Style["display"] = "";
                        trDanwei.Style["display"] = "none";
                        trOuType.Style["display"] = "none";
                        BindOUInfo();
                    }
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_DetailPage(oDetailPage, tdContainer, oRow);
                isEnableSMS.Text = showisEnableSMS(Convert.ToString(oRow["EnableSMS"]));
                EnableOnlineChat.Text = showEnableOnlineChat(Convert.ToString(oRow["EnableOnlineChat"]));
                BindRoleName();
            }
        }

        protected void BindRoleName()
        {
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select RoleName from RG_Role inner join RG_User_Role on RG_Role.RowGuid=RG_User_Role.RoleGuid where RG_User_Role.RGUserGuid='" + Request["RowGuid"] + "'");
            foreach (DataRowView row in dv)
            {
                RoleName.Text += row["RoleName"].ToString() + "; ";
            }
        }

        protected void Check_Click(object sender, EventArgs e)
        {
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);//<a href='http://www.baidu.com'>点击激活</a>
            oRow["UserStatus"] = "002";
            //oRow["IsValid"] = "1";
            oRow.Update();
            new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_User", "RowGuid", Request["RowGuid"]);
            string EncryptedUserGuid = SymmetricMethod.Encrypto(Request["RowGuid"]);
            string Addr = System.Configuration.ConfigurationManager.AppSettings["Addr"].ToString();
            string SmtpServer = System.Configuration.ConfigurationManager.AppSettings["SmtpServer"].ToString();
            string EmailFrom = System.Configuration.ConfigurationManager.AppSettings["EmailFrom"].ToString();
            string EmailAccount = System.Configuration.ConfigurationManager.AppSettings["EmailAccount"].ToString();
            string EmailPassword = System.Configuration.ConfigurationManager.AppSettings["EmailPassword"].ToString();
            string time = SymmetricMethod.Encrypto(System.DateTime.Now.ToString());
            string ActivationAddr = Addr+"?UserGuid=" + EncryptedUserGuid + "&SendTime=" + time;
            Boolean IsSendSuccess = usermail.sendMail(SmtpServer, EmailAccount, EmailPassword, EmailFrom, oRow["EMail"].ToString(), "请点击链接激活您的会员账号！", "如果不能直接点击，请右键打开新窗口……\r\n <a href='" + ActivationAddr + "'>点击激活</a>");
            if (!IsSendSuccess)
            {
                AlertAjaxMessage("激活邮件发送失败！");
                return;
            }
            if (oRow["EnableSMS"].ToString() == "1")
            {
                string VerifyCode=CreateRnd(6);
                string content = "请使用以下验证码激活账号：" + VerifyCode;
                Epoint.MisBizLogic2.DB.ExecuteNonQuery("update RG_User set VerifyCode='" + VerifyCode + "',SendVCodeDate='"+System.DateTime.Now.ToString()+"' where RowGuid='"+Request["RowGuid"]+"'");
                new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront,"RG_User","RowGuid",Request["RowGuid"]);
                string SendMobilephone = System.Configuration.ConfigurationManager.AppSettings["SendMobilephone"].ToString();
                string SystemID = System.Configuration.ConfigurationManager.AppSettings["SystemID"].ToString();
                SMS_Send.SendSMS("管理员", SendMobilephone, oRow["Mobile"].ToString(), content, SystemID);
            }
            this.AlertAjaxMessage("审核完成！");
            this.WriteAjaxMessage("refreshParent();window.close();");
        }

        protected void NotPass_Click(object sender,EventArgs e)
        {
            Epoint.MisBizLogic2.DB.ExecuteNonQuery("update RG_User set UserStatus='002',DelFlag=1 where RowGuid='"+Request["RowGuid"]+"'");
            new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront,"RG_User","RowGuid",Request["RowGuid"]);
            WriteAjaxMessage("rtnValue(\"\");");
        }

        override protected void OnInit(EventArgs e)
        {
            oDetailPage = new Epoint.MisBizLogic2.Web.DetailPage(TableID);
            base.OnInit(e);
        }

        public string showisEnableSMS(string str)
        {
            if (str == "1")
                return "接受";
            else
                if (str == "0")
                    return "不接受";
            return "";
        }
        public string showEnableOnlineChat(string str)
        {
            if (str == "1")
                return "启用";
            else
                if (str == "0")
                    return "不启用";
            return "";
        }

        protected void BindOUInfo()
        {
            Epoint.MisBizLogic2.Code.DB_CodeMain codemain = new Epoint.MisBizLogic2.Code.DB_CodeMain();
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_User", Request["RowGuid"]);
            Epoint.MisBizLogic2.Data.MisGuidRow arow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_OUInfo", oRow["DanWeiGuid"].ToString());
            EnterpriseName.Text = arow["EnterpriseName"].ToString();
            CodeCertificate.Text = arow["CodeCertificate"].ToString();
            EnterpriseType.Text = arow["EnterpriseType"].ToString();
            LegalPerson.Text = arow["LegalPerson"].ToString();
            RegionCharacter.Text = arow["RegionCharacter"].ToString();
            BusinessLicenseNO.Text = arow["BusinessLicenseNO"].ToString();
            Contacter.Text = arow["Contacter"].ToString();
            Tel.Text = arow["Tel"].ToString();
            ContacterID.Text = arow["ContacterID"].ToString();
            Email.Text = arow["Email"].ToString();
            Address.Text = arow["Address"].ToString();
            RegistAddress.Text = arow["RegistAddress"].ToString();
            BeiZhu.Text = arow["BeiZhu"].ToString();
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select * FROM RG_OuType_Relate WHERE RelatedGuid='" + oRow["DanWeiGuid"].ToString() + "'and RelatedType='OU'");
            string Type = "";
            foreach (DataRowView row in dv)
            {
                Type += codemain.GetCodeText_FromHash("RG_会员单位", row["OuType"].ToString()) + ';';
            }
            EnterpriseType.Text = Type;
        }

        /// <summary>
        /// 产生随机数
        /// </summary>
        /// <param name="Leng"></param>
        /// <returns></returns>
        public string CreateRnd(int Leng)
        {
            string Ar1 = "0,1,2,3,4,5,6,7,8,9";

            string[] ListAr = Ar1.Split(',');
            Random RD = new Random();
            int rnd = 0;
            string strRnd = "";
            for (int j = 0; j < Leng; j++)
            {
                rnd = RD.Next(0, ListAr.Length);
                strRnd += ListAr[rnd];
            }
            return strRnd;
        }
    }
}

