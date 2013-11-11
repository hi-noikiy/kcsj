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

namespace HTProject.Pages.RG_OU
{
	
	public partial class RG_OU_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
	{

	public int TableID=2017;

	Epoint.MisBizLogic2.Web.DetailPage oDetailPage;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack )
			{

				ViewState ["TableName"]=oDetailPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);
				
                if (!oRow.R_HasFilled)
                {			
					//lblMessage.Visible=true;
					this.AlertAjaxMessage ("û�ж�Ӧ�����ݼ�¼��");
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

                if (Status_2017.Text != "�����")
                {
                    btnNoPass.Visible = false;
                    btnPass.Visible = false;
                }
                //���ֻ�ǲ鿴����ôҲ����ʾ��ť
                if (String.IsNullOrEmpty(Request["MessageItemGuid"]))
                {
                    btnNoPass.Visible = false;
                    btnPass.Visible = false;
                }
			}
		
		}

        override protected void OnInit(EventArgs e)
        {
            oDetailPage = new Epoint.MisBizLogic2.Web.DetailPage (TableID);            
            base.OnInit(e);
        }

        protected void btnPass_Click(object sender, System.EventArgs e)
        {
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            oRow["Status"] = "90";
            oRow["CheckUserName"] = this.DisplayName;
            oRow["CheckUserGuid"] = this.UserGuid;
            oRow["CheckTime"] = DateTime.Now.ToString();
            oRow.Update();
            //AlertAjaxMessage("�����ɹ�");
            btnNoPass.Visible = false;
            btnPass.Visible = false;
            //ɾ����������
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("�����ҵ", Request["RowGuid"]);
            AlertAjaxMessage("�����ɹ�");

            this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("window.close();");
        }

        protected void btnNoPass_Click(object sender, System.EventArgs e)
        {
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            oRow["Status"] = "80";
            oRow["CheckUserName"] = this.DisplayName;
            oRow["CheckUserGuid"] = this.UserGuid;
            oRow["CheckTime"] = DateTime.Now.ToString();
            oRow.Update();
            
            btnNoPass.Visible = false;
            btnPass.Visible = false;
            //AlertAjaxMessage("�����ɹ�");
            //ɾ����������
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("�����ҵ", Request["RowGuid"]);
            AlertAjaxMessage("�����ɹ�");
            
            this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("window.close();");
        }
   }
}

