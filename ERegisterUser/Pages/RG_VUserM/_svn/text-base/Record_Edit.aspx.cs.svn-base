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
using System.Text;
using System.Data.SqlClient;
using System.Collections.Specialized ;
using Epoint.Web.UI.WebControls2X;
using Epoint.RegisterUser.DataSyn.Bizlogic;

namespace EpointRegisterUser.Pages.RG_VUserM
{
	
	public partial class Record_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
	{
	    public int TableID=100;
	    Epoint.MisBizLogic2.Web.EditPage oEditPage;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if (!Page.IsPostBack )
			{
                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
				if (!oRow.R_HasFilled)
				{
					btnEdit.Visible = false;
				    this.AlertAjaxMessage ("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
					return;
				}
				
				
				
				Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
				//添加上传文件的大小和类型检查
                this.Add_FileUploadCheck_Script();
			}		
		}


        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage (TableID);
            base.OnInit(e);
        }
	

		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_VUserM", "RowGuid", Request["RowGuid"]);
			this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");
            this.WriteAjaxMessage("rtnValue(\"\");");
		}

		

		
   }
}
