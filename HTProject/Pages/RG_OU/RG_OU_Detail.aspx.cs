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
					this.AlertAjaxMessage ("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
					return;
				}
				Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_DetailPage(oDetailPage, tdContainer, oRow);

                GSZZ_Z.ClientGuid = Request["RowGuid"] + "QY_GSZZ_Z";
                GSZZ_Z.ClientTag = "工商营业执照(正本)";
                GSZZ_Z.NodeCode = Request["RowGuid"];
                GSZZ_Z.MisRowGuid = Request["RowGuid"];

                GSZZ_F.ClientGuid = Request["RowGuid"] + "QY_GSZZ_F";
                GSZZ_F.ClientTag = "工商营业执照(副本)";
                GSZZ_F.NodeCode = Request["RowGuid"];
                GSZZ_Z.MisRowGuid = Request["RowGuid"];

                ZZJGDMZ.ClientGuid = Request["RowGuid"] + "QY_ZZJGDMZ";
                ZZJGDMZ.ClientTag = "组织机构代码证";
                ZZJGDMZ.NodeCode = Request["RowGuid"];
                ZZJGDMZ.MisRowGuid = Request["RowGuid"];

                FRSFZ.ClientGuid = Request["RowGuid"] + "QY_FRSFZ";
                FRSFZ.ClientTag = "法定代表人身份证";
                FRSFZ.NodeCode = Request["RowGuid"];
                FRSFZ.MisRowGuid = Request["RowGuid"];


                FRQM.ClientGuid = Request["RowGuid"] + "QY_FRQM";
                FRQM.ClientTag = "法定代表人签名";
                FRQM.NodeCode = Request["RowGuid"];
                FRQM.MisRowGuid = Request["RowGuid"];


                SBZM.ClientGuid = Request["RowGuid"] + "QY_SBZM";
                SBZM.ClientTag = "社会保险证明材料(近6个月)";
                SBZM.NodeCode = Request["RowGuid"];
                SBZM.MisRowGuid = Request["RowGuid"];

                QT.ClientGuid = Request["RowGuid"] + "QY_QYQT";
                QT.ClientTag = "企业其它文件";
                QT.NodeCode = Request["RowGuid"];
                QT.MisRowGuid = Request["RowGuid"];

                if (Status_2017.Text != "待审核")
                {
                    btnNoPass.Visible = false;
                    btnPass.Visible = false;
                }
                //如果只是查看，那么也不显示按钮
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
            //AlertAjaxMessage("操作成功");
            btnNoPass.Visible = false;
            btnPass.Visible = false;
            //删除待办事宜
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("审核企业", Request["RowGuid"]);
            AlertAjaxMessage("操作成功");

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
            //AlertAjaxMessage("操作成功");
            //删除待办事宜
            new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Delete("审核企业", Request["RowGuid"]);
            AlertAjaxMessage("操作成功");
            
            this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("window.close();");
        }
   }
}

