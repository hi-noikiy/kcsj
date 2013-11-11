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

namespace HTProject.Pages.RG_OU
{

    public partial class RG_OU_All_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2017;
        protected HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        Epoint.MisBizLogic2.Web.DetailPage oDetailPage;
        public int TableZZID = 2020;
        Epoint.MisBizLogic2.Web.ListPage oZZListPage;
        public int TableRYID = 2019;
        Epoint.MisBizLogic2.Web.ListPage oRYListPage;
        public int TableXMID = 2021;
        Epoint.MisBizLogic2.Web.ListPage oXMListPage;
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

                GSZZ_Z.ClientGuid = Request["RowGuid"] + "QY_GSZZ_Z";
                GSZZ_Z.ClientTag = "����Ӫҵִ��(����)";
                GSZZ_Z.NodeCode = Request["RowGuid"];
                GSZZ_Z.MisRowGuid = Request["RowGuid"];

                GSZZ_F.ClientGuid = Request["RowGuid"] + "QY_GSZZ_F";
                GSZZ_F.ClientTag = "����Ӫҵִ��(����)";
                GSZZ_F.NodeCode = Request["RowGuid"];
                GSZZ_Z.MisRowGuid = Request["RowGuid"];

                ZZJGDMZ.ClientGuid = Request["RowGuid"] + "QY_ZZJGDMZ";
                ZZJGDMZ.ClientTag = "��֯��������֤";
                ZZJGDMZ.NodeCode = Request["RowGuid"];
                ZZJGDMZ.MisRowGuid = Request["RowGuid"];

                FRSFZ.ClientGuid = Request["RowGuid"] + "QY_FRSFZ";
                FRSFZ.ClientTag = "�������������֤";
                FRSFZ.NodeCode = Request["RowGuid"];
                FRSFZ.MisRowGuid = Request["RowGuid"];


                FRQM.ClientGuid = Request["RowGuid"] + "QY_FRQM";
                FRQM.ClientTag = "����������ǩ��";
                FRQM.NodeCode = Request["RowGuid"];
                FRQM.MisRowGuid = Request["RowGuid"];


                SBZM.ClientGuid = Request["RowGuid"] + "QY_SBZM";
                SBZM.ClientTag = "��ᱣ��֤������(��6����)";
                SBZM.NodeCode = Request["RowGuid"];
                SBZM.MisRowGuid = Request["RowGuid"];

                QT.ClientGuid = Request["RowGuid"] + "QY_QYQT";
                QT.ClientTag = "��ҵ�����ļ�";
                QT.NodeCode = Request["RowGuid"];
                QT.MisRowGuid = Request["RowGuid"];

                RefreshZZGrid();
                RefreshRYGrid();
                RefreshXMGrid();

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
            oZZListPage = new Epoint.MisBizLogic2.Web.ListPage(TableZZID, DGZZ, null, PagerZZ, null);//���û�е���Excel��Grid��������Ϊnull
            oZZListPage.OtherCondition = "  and DelStatus='0' and DWGuid='" + Request["RowGuid"] + "' ";
            oZZListPage.CustomMode = true;

            oRYListPage = new Epoint.MisBizLogic2.Web.ListPage(TableRYID, DGRY, null, PagerRY, null);//���û�е���Excel��Grid��������Ϊnull
            oRYListPage.OtherCondition = " and DelStatus='0' and DWGuid='" + Request["RowGuid"] + "' ";
            oRYListPage.CustomMode = true;

            oXMListPage = new Epoint.MisBizLogic2.Web.ListPage(TableXMID, DGXM, null, PagerXM, null);//���û�е���Excel��Grid��������Ϊnull
            oXMListPage.OtherCondition = " and DelStatus='0' and DWGuid='" + Request["RowGuid"] + "' ";
            oXMListPage.CustomMode = true;            
            base.OnInit(e);
        }

        private void RefreshZZGrid()
        {
            oZZListPage.GenerateSearchResult();
        }
        private void RefreshRYGrid()
        {
            oRYListPage.GenerateSearchResult();
        }
        private void RefreshXMGrid()
        {
            oXMListPage.GenerateSearchResult();
        }

        protected void PagerZZ_PageChanged(object src, Wuqi.Webdiyer.PageChangedEventArgs e)
        {
            PagerZZ.CurrentPageIndex = e.NewPageIndex;
            this.RefreshZZGrid();
        }
        protected void DGZZ_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            oZZListPage.GenerateSerialNumColumn(e.Item);
        }

        protected void PagerRY_PageChanged(object src, Wuqi.Webdiyer.PageChangedEventArgs e)
        {
            PagerRY.CurrentPageIndex = e.NewPageIndex;
            this.RefreshRYGrid();
        }
        protected void DGRY_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            oRYListPage.GenerateSerialNumColumn(e.Item);
        }

        protected void PagerXM_PageChanged(object src, Wuqi.Webdiyer.PageChangedEventArgs e)
        {
            PagerXM.CurrentPageIndex = e.NewPageIndex;
            this.RefreshXMGrid();
        }
        protected void DGXM_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            oXMListPage.GenerateSerialNumColumn(e.Item);
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
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("�����ҵ", Request["RowGuid"]);
            AlertAjaxMessage("�����ɹ�");

            //��Ӷ���
            string IsSendSMS = ApplicationOperate.GetConfigValueByName("IsSendOUSMS");
            if (IsSendSMS == "1")
            {
                Detail_RG_User D_R_User = DB_R_User.GetDetail(this.UserGuid);
                if (D_R_User.Mobile != "")
                {
                    HTSMS.SendSMS(this.DisplayName, D_R_User.DispName, "���ύ����ҵ��Ϣ�����ͨ�����뼰ʱ��ע��лл", D_R_User.Mobile);
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
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("�����ҵ", Request["RowGuid"]);
            AlertAjaxMessage("�����ɹ�");
            //��Ӷ���
            string IsSendSMS = ApplicationOperate.GetConfigValueByName("IsSendOUSMS");
            if (IsSendSMS == "1")
            {
                Detail_RG_User D_R_User = DB_R_User.GetDetail(this.UserGuid);
                if (D_R_User.Mobile != "")
                {
                    HTSMS.SendSMS(this.DisplayName, D_R_User.DispName, "���ύ����ҵ��Ϣ���в�����Ϣ���δͨ�����뼰ʱ��ע��лл", D_R_User.Mobile);
                }
            }
            this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("window.close();");
        }

        protected string GetButton(object Status,object RowGuid,object url)
        {
            string RTurl = "<a href='javascript:OpenWindow(\"{0}?RowGuid={1}\")'><img src='../../../images/{2}.gif' border='0'></a>";
            //����˵�Ҫ��ʾ��ˣ�ͨ���ľ�ֻ�鿴
            if (Status.ToString() == "90")
            {
                return string.Format(RTurl, url, RowGuid, "bigview");
            }
            else
            {
                return string.Format(RTurl, url, RowGuid + "&MessageItemGuid=1", "add1");
            }
        }
    }
}

