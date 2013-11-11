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

namespace EpointRegisterUser.Pages.RG_Application
{	
	public partial class RG_Application_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
	{
	public int TableID=118;
	Epoint.MisBizLogic2.Web.DetailPage oDetailPage;	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack )
			{
				ViewState ["TableName"]=oDetailPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);
				
                if (!oRow.R_HasFilled)
                {
					this.AlertAjaxMessage ("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
					return;
				}
				Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_DetailPage(oDetailPage, tdContainer, oRow);
                AppManager.Text=Epoint.MisBizLogic2.DB.ExecuteToString("select DisplayName from Frame_User inner join RG_Application on Frame_User.UserGuid=RG_Application.UserGuid where RowGuid='" + Request["RowGuid"] + "'");
			}		
		}
        override protected void OnInit(EventArgs e)
        {
            oDetailPage = new Epoint.MisBizLogic2.Web.DetailPage (TableID);            
            base.OnInit(e);
        }
   }
}

