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
                    this.AlertAjaxMessage("û�ж�Ӧ�����ݼ�¼��");
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
                GSZZ_Z.ClientTag = "����Ӫҵִ��(����)";
                GSZZ_Z.NodeCode = DWGuid_2020.Text;
                GSZZ_Z.MisRowGuid = DWGuid_2020.Text;

                GSZZ_F.ClientGuid = DWGuid_2020.Text + "QY_GSZZ_F";
                GSZZ_F.ClientTag = "����Ӫҵִ��(����)";
                GSZZ_F.NodeCode = DWGuid_2020.Text;
                GSZZ_Z.MisRowGuid = DWGuid_2020.Text;

                ZZJGDMZ.ClientGuid = DWGuid_2020.Text + "QY_ZZJGDMZ";
                ZZJGDMZ.ClientTag = "��֯��������֤";
                ZZJGDMZ.NodeCode = DWGuid_2020.Text;
                ZZJGDMZ.MisRowGuid = DWGuid_2020.Text;

                FRSFZ.ClientGuid = DWGuid_2020.Text + "QY_FRSFZ";
                FRSFZ.ClientTag = "�������������֤";
                FRSFZ.NodeCode = DWGuid_2020.Text;
                FRSFZ.MisRowGuid = DWGuid_2020.Text;


                FRQM.ClientGuid = DWGuid_2020.Text + "QY_FRQM";
                FRQM.ClientTag = "����������ǩ��";
                FRQM.NodeCode = DWGuid_2020.Text;
                FRQM.MisRowGuid = DWGuid_2020.Text;


                SBZM.ClientGuid = DWGuid_2020.Text + "QY_SBZM";
                SBZM.ClientTag = "��ᱣ��֤������(��6����)";
                SBZM.NodeCode = DWGuid_2020.Text;
                GSZZ_Z.MisRowGuid = DWGuid_2020.Text;

                QT.ClientGuid = DWGuid_2020.Text + "QY_QYQT";
                QT.ClientTag = "��ҵ�����ļ�";
                QT.NodeCode = DWGuid_2020.Text;
                QT.MisRowGuid = DWGuid_2020.Text;

                if (Status_2020.Text != "�����")
                {
                    tabOP.Visible = false;
                }
                //���ֻ�ǲ鿴����ôҲ����ʾ��ť
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
            //AlertAjaxMessage("�����ɹ�");
            string Opinion = "���ͨ��";
            if (SHOpinion.Text.Trim() != "")
            {
                Opinion += "��������Ϊ��" + Epoint.MisBizLogic2.DB.SQL_Encode(SHOpinion.Text.Trim());
            }
            RG_DW.InsertSHOpinion(Request["RowGuid"], this.DisplayName, Opinion, "");
            //AlertAjaxMessage("�����ɹ�");
            tabOP.Visible = false;
            //ɾ����������
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("�����ҵ����", Request["RowGuid"]);
            AlertAjaxMessage("�����ɹ�");

            //��Ӷ���
            string IsSendSMS = ApplicationOperate.GetConfigValueByName("IsSendOUSMS");
            if (IsSendSMS == "1")
            {
                Detail_RG_User D_R_User = DB_R_User.GetDetail(this.UserGuid);
                if (D_R_User.Mobile != "")
                {
                    HTSMS.SendSMS(this.DisplayName, D_R_User.DispName, "���ύ��" + ZiZhiText_2020.Text + "��������Ϣ�����ͨ�����뼰ʱ��ע��лл", D_R_User.Mobile);
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
            string Opinion = "��˲�ͨ��";
            if (SHOpinion.Text.Trim() != "")
            {
                Opinion += "��������Ϊ��" + Epoint.MisBizLogic2.DB.SQL_Encode(SHOpinion.Text.Trim());
            }
            RG_DW.InsertSHOpinion(Request["RowGuid"], this.DisplayName, Opinion, "");
            tabOP.Visible = false;
            //AlertAjaxMessage("�����ɹ�");
            //ɾ����������
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("�����ҵ����", Request["RowGuid"]);
            AlertAjaxMessage("�����ɹ�");

            //��Ӷ���
            string IsSendSMS = ApplicationOperate.GetConfigValueByName("IsSendOUSMS");
            if (IsSendSMS == "1")
            {
                Detail_RG_User D_R_User = DB_R_User.GetDetail(this.UserGuid);
                if (D_R_User.Mobile != "")
                {
                    HTSMS.SendSMS(this.DisplayName, D_R_User.DispName, "���ύ��" + ZiZhiText_2020.Text + "��������Ϣ���δͨ�����뼰ʱ��ע��лл", D_R_User.Mobile);
                }
            }

            this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("window.close();");
        }
    }
}

