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
using EpointRegisterUser_Bizlogic;

namespace EpointRegisterUser.Pages_RG.RG_DingQi
{
	
	public partial class RG_DingQi_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
	{
	    public int TableID=2027;
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

                #region
                if (this.d_qiJian_2027.Text == "")
                {
                    this.d_qiJian_2027.Text = DateTime.Now.ToString();
                }
                int thisYear = DateTime.Parse(this.d_qiJian_2027.Text.ToString()).Year;
                int thisMonth = DateTime.Parse(this.d_qiJian_2027.Text.ToString()).Month;
                for (int i = thisYear - 15; i <= thisYear; i++)
                {
                    jpdYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                for (int i = 1; i <= 12; i++)
                {
                    jpdMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                jpdYear.SelectedValue = thisYear.ToString();
                jpdMonth.SelectedValue = thisMonth.ToString();

                #endregion

                if (s_Status_2027.Text == DQStatus.已完成)
                {
                    btnEdit.Visible = false;
                    btnWC.Visible = false;
                    CL_DQSX.ReadOnly = true;
                }

                CL_DQSX.MisRowGuid = Request["RowGuid"];
                CL_DQSX.MisTableID = TableID;
                CL_DQSX.ProjectGuid = "";
                CL_DQSX.Comment = Request["DWGuid"];
                CL_DQSX.d_TiJiaoSJ = DateTime.Now.ToString();
			}		
		}


        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage (TableID);
            base.OnInit(e);
        }
	

		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
            s_Status_2027.Text = DQStatus.编辑中;
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            //this.WriteAjaxMessage("refreshParent();"); 
            //this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");
            CL_DQSX.MisRowGuid = Request["RowGuid"];
            CL_DQSX.MisTableID = TableID;
            CL_DQSX.ProjectGuid = "";
            CL_DQSX.Comment = Request["DWGuid"];
            CL_DQSX.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_DQSX.Save();

            this.WriteAjaxMessage("refreshParent();alert('保存成功');");
		
		}
        protected void btnWC_Click(object sender, System.EventArgs e)
        {
            s_Status_2027.Text = DQStatus.已完成;
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            //this.WriteAjaxMessage("refreshParent();"); 
            //this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");
            CL_DQSX.MisRowGuid = Request["RowGuid"];
            CL_DQSX.MisTableID = TableID;
            CL_DQSX.ProjectGuid = "";
            CL_DQSX.Comment = Request["DWGuid"];
            CL_DQSX.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_DQSX.Save();

            this.WriteAjaxMessage("refreshParent();alert('完成成功');window.location=window.location;");

        }
   }
}
