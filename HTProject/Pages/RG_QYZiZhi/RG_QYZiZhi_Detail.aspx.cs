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

namespace HTProject.Pages.RG_QYZiZhi
{

    public partial class RG_QYZiZhi_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2020;

        Epoint.MisBizLogic2.Web.DetailPage oDetailPage;
        public int TableOUID = 2017;
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        Epoint.MisBizLogic2.Web.DetailPage oDetailOUPage;

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

                ZiZhiZS_Z.ClientGuid = Request["RowGuid"] + "ZZ_ZS_Z";
                ZiZhiZS_Z.NodeCode = DWGuid_2020.Text;
                ZiZhiZS_Z.MisRowGuid = Request["RowGuid"];

                ZiZhiZS_F.ClientGuid = Request["RowGuid"] + "ZZ_ZS_F";
                ZiZhiZS_F.NodeCode = DWGuid_2020.Text;
                ZiZhiZS_F.MisRowGuid = Request["RowGuid"];

                Epoint.MisBizLogic2.Data.MisGuidRow oRowOU = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailOUPage.TableDetail.SQL_TableName, DWGuid_2020.Text);
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_DetailPage(oDetailOUPage, tdContainer, oRowOU);

                GSZZ_Z.ClientGuid = DWGuid_2020.Text + "QY_GSZZ_Z";
                GSZZ_Z.ClientTag = "工商营业执照(正本)";
                GSZZ_Z.NodeCode = DWGuid_2020.Text;
                GSZZ_Z.MisRowGuid = DWGuid_2020.Text;

                GSZZ_F.ClientGuid = DWGuid_2020.Text + "QY_GSZZ_F";
                GSZZ_F.ClientTag = "工商营业执照(副本)";
                GSZZ_F.NodeCode = DWGuid_2020.Text;
                GSZZ_Z.MisRowGuid = DWGuid_2020.Text;

                ZZJGDMZ.ClientGuid = DWGuid_2020.Text + "QY_ZZJGDMZ";
                ZZJGDMZ.ClientTag = "组织机构代码证";
                ZZJGDMZ.NodeCode = DWGuid_2020.Text;
                ZZJGDMZ.MisRowGuid = DWGuid_2020.Text;

                FRSFZ.ClientGuid = DWGuid_2020.Text + "QY_FRSFZ";
                FRSFZ.ClientTag = "法定代表人身份证";
                FRSFZ.NodeCode = DWGuid_2020.Text;
                FRSFZ.MisRowGuid = DWGuid_2020.Text;


                FRQM.ClientGuid = DWGuid_2020.Text + "QY_FRQM";
                FRQM.ClientTag = "法定代表人签名";
                FRQM.NodeCode = DWGuid_2020.Text;
                FRQM.MisRowGuid = DWGuid_2020.Text;


                SBZM.ClientGuid = DWGuid_2020.Text + "QY_SBZM";
                SBZM.ClientTag = "社会保险证明材料(近6个月)";
                SBZM.NodeCode = DWGuid_2020.Text;
                GSZZ_Z.MisRowGuid = DWGuid_2020.Text;

                QT.ClientGuid = DWGuid_2020.Text + "QY_QYQT";
                QT.ClientTag = "企业其它文件";
                QT.NodeCode = DWGuid_2020.Text;
                QT.MisRowGuid = DWGuid_2020.Text;

                if (Status_2020.Text != "待审核")
                {
                    tabOP.Visible = false;
                }
                //如果只是查看，那么也不显示按钮
                if (String.IsNullOrEmpty(Request["MessageItemGuid"]))
                {
                    tabOP.Visible = false;
                }
                else
                {
                    tabOP.Visible = true;
                }

                lblSHOpinion.Text = RG_DW.GetSHOpinion(Request["RowGuid"], "");
            }

        }

        override protected void OnInit(EventArgs e)
        {
            oDetailPage = new Epoint.MisBizLogic2.Web.DetailPage(TableID);
            oDetailOUPage = new Epoint.MisBizLogic2.Web.DetailPage(TableOUID);
            base.OnInit(e);
        }

        HTProject_Bizlogic.SMS HTSMS = new SMS();
        DB_RG_User DB_R_User = new DB_RG_User(); 
        protected void btnPass_Click(object sender, System.EventArgs e)
        {
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            oRow["Status"] = "90";
            oRow["TG_Date"] = DateTime.Now.ToString();
            oRow.Update();
            //AlertAjaxMessage("操作成功");
            string Opinion = "审核通过";
            if (SHOpinion.Text.Trim() != "")
            {
                Opinion += "，审核意见为：" + Epoint.MisBizLogic2.DB.SQL_Encode(SHOpinion.Text.Trim());
            }
            RG_DW.InsertSHOpinion(Request["RowGuid"], this.DisplayName, Opinion, "");
            //AlertAjaxMessage("操作成功");
            tabOP.Visible = false;
            //删除待办事宜
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("审核企业资质", Request["RowGuid"]);
            AlertAjaxMessage("操作成功");

            //添加短信
            string IsSendSMS = ApplicationOperate.GetConfigValueByName("IsSendOUSMS");
            if (IsSendSMS == "1")
            {
                Detail_RG_User D_R_User = DB_R_User.GetDetail(this.UserGuid);
                if (D_R_User.Mobile != "")
                {
                    HTSMS.SendSMS(this.DisplayName, D_R_User.DispName, "您提交的" + ZiZhiText_2020.Text + "的资质信息已审核通过，请及时关注，谢谢", D_R_User.Mobile);
                }
            }

            this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("window.close();");
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
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("审核企业资质", Request["RowGuid"]);
            AlertAjaxMessage("操作成功");

            //添加短信
            string IsSendSMS = ApplicationOperate.GetConfigValueByName("IsSendOUSMS");
            if (IsSendSMS == "1")
            {
                Detail_RG_User D_R_User = DB_R_User.GetDetail(this.UserGuid);
                if (D_R_User.Mobile != "")
                {
                    HTSMS.SendSMS(this.DisplayName, D_R_User.DispName, "您提交的" + ZiZhiText_2020.Text + "的资质信息审核未通过，请及时关注，谢谢", D_R_User.Mobile);
                }
            }

            this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("window.close();");
        }
    }
}

