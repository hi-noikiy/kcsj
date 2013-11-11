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

namespace EpointRegisterUser.Pages_RG.RG_DongTai
{
 
    public partial class RG_DongTai_Add : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
	
	public int TableID=2019;		

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

                
            }

        }


        override protected void OnInit(EventArgs e)
        {
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);           
            base.OnInit(e);
        }


        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            string RowGuid = Request["RowGuid"];
            string DWGuid = Request["DWGuid"];

            UpdateUserName_2019.Text = this.DisplayName;
            UpdateUserGuid_2019.Text = this.UserGuid;
            IsHistory_2019.Text = "0";
            UpdateTime_2019.Text = DateTime.Now.ToString();
            Status_2019.Text = EpointRegisterUser_Bizlogic.OUStatus.编辑中;//0:编辑   1：待审核   2：通过
            DWGuid_2019.Text = DWGuid;
            oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);

            #region 保存附件
            CL_ZLJS.MisRowGuid = DWGuid;
            CL_ZLJS.MisTableID = TableID;
            CL_ZLJS.ProjectGuid = "";
            CL_ZLJS.Comment = DWGuid;
            CL_ZLJS.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_ZLJS.Save();

            CL_YYZZ.MisRowGuid = DWGuid;
            CL_YYZZ.MisTableID = TableID;
            CL_YYZZ.ProjectGuid = "";
            CL_YYZZ.Comment = DWGuid;
            CL_YYZZ.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_YYZZ.Save();

            CL_SWDJZ.MisRowGuid = DWGuid;
            CL_SWDJZ.MisTableID = TableID;
            CL_SWDJZ.ProjectGuid = "";
            CL_SWDJZ.Comment = DWGuid;
            CL_SWDJZ.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_SWDJZ.Save();

            CL_ZZJGDM.MisRowGuid = DWGuid;
            CL_ZZJGDM.MisTableID = TableID;
            CL_ZZJGDM.ProjectGuid = "";
            CL_ZZJGDM.Comment = DWGuid;
            CL_ZZJGDM.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_ZZJGDM.Save();

            CL_SWPZZ.MisRowGuid = DWGuid;
            CL_SWPZZ.MisTableID = TableID;
            CL_SWPZZ.ProjectGuid = "";
            CL_SWPZZ.Comment = DWGuid;
            CL_SWPZZ.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_SWPZZ.Save();

            CL_QTFJ.MisRowGuid = DWGuid;
            CL_QTFJ.MisTableID = TableID;
            CL_QTFJ.ProjectGuid = "";
            CL_QTFJ.Comment = DWGuid;
            CL_QTFJ.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_QTFJ.Save();
            #endregion

            ////如果是父表，要转入多表编辑页面
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
            string url = "RG_DongTai_Edit.aspx?RowGuid=" + RowGuid + "&DWGuid=" + DWGuid +"&sType=0";
            this.WriteAjaxMessage("refreshParent();alert('添加成功');window.location.href='" + url + "';");

        }		

    }
}


