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

namespace HTProject.Pages.RG_QYUser
{

    public partial class RG_QYUser_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2019;

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

                
                //如果只是查看，那么也不显示按钮
                if (String.IsNullOrEmpty(Request["MessageItemGuid"]))
                {
                    tabOP.Visible = false;
                }
                SFZ.ClientGuid = Request["RowGuid"] + "RY_SFZ";
                SFZ.NodeCode = DWGuid_2019.Text;
                SFZ.MisRowGuid = Request["RowGuid"];

                BYZ.ClientGuid = Request["RowGuid"] + "RY_BYZ";
                BYZ.NodeCode = DWGuid_2019.Text;
                BYZ.MisRowGuid = Request["RowGuid"];

                ZCZJ.ClientGuid = Request["RowGuid"] + "RY_ZCZJ";
                ZCZJ.NodeCode = DWGuid_2019.Text;
                ZCZJ.MisRowGuid = Request["RowGuid"];

                ZhiCheng.ClientGuid = Request["RowGuid"] + "RY_ZhiCheng";
                ZhiCheng.NodeCode = DWGuid_2019.Text;
                ZhiCheng.MisRowGuid = Request["RowGuid"];

                LDHT.ClientGuid = Request["RowGuid"] + "RY_LDHT";
                LDHT.NodeCode = DWGuid_2019.Text;
                LDHT.MisRowGuid = Request["RowGuid"];

                GRQT.ClientGuid = Request["RowGuid"] + "RY_GRQT";
                GRQT.NodeCode = DWGuid_2019.Text;
                GRQT.MisRowGuid = Request["RowGuid"];

                GRQM.ClientGuid = Request["RowGuid"] + "RY_GRQM";
                GRQM.NodeCode = DWGuid_2019.Text;
                GRQM.MisRowGuid = Request["RowGuid"];

                Epoint.MisBizLogic2.Data.MisGuidRow oRowOU = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailOUPage.TableDetail.SQL_TableName, DWGuid_2019.Text);
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_DetailPage(oDetailOUPage, tdContainer, oRowOU);

                GSZZ_Z.ClientGuid = DWGuid_2019.Text + "QY_GSZZ_Z";
                GSZZ_Z.ClientTag = "工商营业执照(正本)";
                GSZZ_Z.NodeCode = DWGuid_2019.Text;
                GSZZ_Z.MisRowGuid = DWGuid_2019.Text;

                GSZZ_F.ClientGuid = DWGuid_2019.Text + "QY_GSZZ_F";
                GSZZ_F.ClientTag = "工商营业执照(副本)";
                GSZZ_F.NodeCode = DWGuid_2019.Text;
                GSZZ_Z.MisRowGuid = DWGuid_2019.Text;

                ZZJGDMZ.ClientGuid = DWGuid_2019.Text + "QY_ZZJGDMZ";
                ZZJGDMZ.ClientTag = "组织机构代码证";
                ZZJGDMZ.NodeCode = DWGuid_2019.Text;
                ZZJGDMZ.MisRowGuid = DWGuid_2019.Text;

                FRSFZ.ClientGuid = DWGuid_2019.Text + "QY_FRSFZ";
                FRSFZ.ClientTag = "法定代表人身份证";
                FRSFZ.NodeCode = DWGuid_2019.Text;
                FRSFZ.MisRowGuid = DWGuid_2019.Text;


                FRQM.ClientGuid = DWGuid_2019.Text + "QY_FRQM";
                FRQM.ClientTag = "法定代表人签名";
                FRQM.NodeCode = DWGuid_2019.Text;
                FRQM.MisRowGuid = DWGuid_2019.Text;


                SBZM.ClientGuid = DWGuid_2019.Text + "QY_SBZM";
                SBZM.ClientTag = "社会保险证明材料(近6个月)";
                SBZM.NodeCode = DWGuid_2019.Text;
                GSZZ_Z.MisRowGuid = DWGuid_2019.Text;

                QT.ClientGuid = DWGuid_2019.Text + "QY_QYQT";
                QT.ClientTag = "企业其它文件";
                QT.NodeCode = DWGuid_2019.Text;
                QT.MisRowGuid = DWGuid_2019.Text;

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

            oRow.Update();
            //AlertAjaxMessage("操作成功");
            tabOP.Visible = false;
            //删除待办事宜
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("人员信息审核", Request["RowGuid"]);
            AlertAjaxMessage("操作成功");
            //添加短信
            string IsSendSMS = ApplicationOperate.GetConfigValueByName("IsSendOUSMS");
            if (IsSendSMS == "1")
            {
                //重新获取提交人信息
                Detail_RG_User D_R_User = DB_R_User.GetDetail(TJRGuid_2019.Text);
                if (D_R_User.Mobile != "")
                {
                    HTSMS.SendSMS(this.DisplayName, D_R_User.DispName, "您提交的" + XM_2019.Text + "的信息已审核通过，请及时关注，谢谢", D_R_User.Mobile);
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

            tabOP.Visible = false;
            //AlertAjaxMessage("操作成功");
            //删除待办事宜
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("人员信息审核", Request["RowGuid"]);
            AlertAjaxMessage("操作成功");
            //添加短信
            string IsSendSMS = ApplicationOperate.GetConfigValueByName("IsSendOUSMS");
            if (IsSendSMS == "1")
            {
                Detail_RG_User D_R_User = DB_R_User.GetDetail(TJRGuid_2019.Text);
                if (D_R_User.Mobile != "")
                {
                    HTSMS.SendSMS(this.DisplayName, D_R_User.DispName, "您提交的" + XM_2019.Text + "的信息审核未通过，请及时关注，谢谢", D_R_User.Mobile);
                }
            }
            this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("window.close();");
        }
    }
}

