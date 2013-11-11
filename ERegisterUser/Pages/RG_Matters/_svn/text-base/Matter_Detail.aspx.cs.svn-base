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

namespace EpointRegisterUser.Pages.RG_Matters
{
	
	public partial class Matter_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
	{

	public int TableID=131;

	Epoint.MisBizLogic2.Web.DetailPage oDetailPage;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack )
			{

				//ViewState ["TableName"]=oDetailPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);
				
                if (!oRow.R_HasFilled)
                {			
					//lblMessage.Visible=true;
					this.AlertAjaxMessage ("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
					return;
				}
				Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_DetailPage(oDetailPage, tdContainer, oRow);
			}
		
		}

        override protected void OnInit(EventArgs e)
        {
            oDetailPage = new Epoint.MisBizLogic2.Web.DetailPage (TableID);            
            base.OnInit(e);
        }
   }
}

