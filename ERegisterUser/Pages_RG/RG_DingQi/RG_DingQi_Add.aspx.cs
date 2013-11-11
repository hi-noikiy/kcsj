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
using System.Collections.Specialized;
using EpointRegisterUser_Bizlogic;

namespace EpointRegisterUser.Pages_RG.RG_DingQi
{
 
    public partial class RG_DingQi_Add : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
	
	public int TableID=2027;		

		Epoint.MisBizLogic2.Web.AddPage oAddPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oAddPage.TableDetail.TableName; 
                #region 判断是否是辅表，如果是辅表，并且没有父表的RowID，自动转到相应的主表
                string ParentRowGuid = Request.QueryString["ParentRowGuid"];
                if (oAddPage.TableDetail.TableType == 2)
                {
                    if (ParentRowGuid == null || ParentRowGuid == "")
                    {
                        this.AlertAjaxMessage("禁止直接对子表添加记录！");
                        return;
                    }
                }
                #endregion
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage,tdContainer);
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
            }

        }


        override protected void OnInit(EventArgs e)
        {
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);           
            base.OnInit(e);
        }


        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            string RowGuid = Guid.NewGuid().ToString();
            this.d_qiJian_2027.Text = this.jpdYear.SelectedValue + "-" + this.jpdMonth.SelectedValue + "-" + "1";
            s_Status_2027.Text = DQStatus.编辑中;
            DWGuid_2027.Text = Request["DWGuid"];
            ProjectGuid_2027.Text = Request["ProjectGuid"];
            oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);

            CL_DQSX.MisRowGuid = RowGuid;// Request["DWGuid"];
            CL_DQSX.MisTableID = TableID;
            CL_DQSX.ProjectGuid = "";
            CL_DQSX.Comment = Request["DWGuid"];
            CL_DQSX.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_DQSX.Save();

            //如果是父表，要转入多表编辑页面
            //if (oAddPage.TableDetail.TableType == 1)
            //{
            //    Response.Redirect("MultiPageTab.aspx?mode=Mode&TableID=" + oAddPage.TableDetail.TableID + "&RowGuid=" + RowGuid);
            //}
            //else
            //{
            //    this.WriteAjaxMessage ("refreshParent();");
            //}
            //Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
            //this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");           
            string url = "RG_DingQi_Edit.aspx?RowGuid=" + RowGuid + "&DWGuid=" + Request["DWGuid"];
            this.WriteAjaxMessage("refreshParent();alert('添加成功');window.location.href='" + url + "';");
        }		

    }
}


