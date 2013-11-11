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

namespace EpointRegisterUser.Pages_RG.RG_DingQi
{
	
	public partial class RG_DingQi_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
	{

	public int TableID=2027;

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
					//this.AlertAjaxMessage ("没有对应的数据记录！");
                    //this.WriteAjaxMessage("window.close();");
					return;
				}
				Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_DetailPage(oDetailPage, tdContainer, oRow);
                CL_DQSX.MisRowGuid = Request["RowGuid"];
                CL_DQSX.MisTableID = TableID;
                CL_DQSX.ProjectGuid = "";
                CL_DQSX.Comment = Request["DWGuid"];
                CL_DQSX.d_TiJiaoSJ = DateTime.Now.ToString();
                if (d_qiJian_2027.Text != "")
                {
                    lblSJ.Text = DateTime.Parse(d_qiJian_2027.Text).ToString("yyyy年MM月");
                }
			}
		
		}

        override protected void OnInit(EventArgs e)
        {
            oDetailPage = new Epoint.MisBizLogic2.Web.DetailPage (TableID);            
            base.OnInit(e);
        }
   }
}

