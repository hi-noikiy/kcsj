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

namespace EpointRegisterUser.Pages_RG.RG_CaiWu
{

    public partial class RG_YueDuCaiWu_Add : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2020;
        CommonFunc CF = new CommonFunc();
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
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
                //添加上传文件的大小和类型检查
                this.Add_FileUploadCheck_Script();
                string strSql = " select top(1) DWGuid from rg_ouinfo where DWGuid=(select distinct DanWeiGuid from RG_User where RowGuid='" + Session["UserGuid"].ToString() + "') order by row_id desc ";
                DWGuid_2020.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                strSql = " select top(1) EnterpriseName from rg_ouinfo where DWGuid=(select distinct DanWeiGuid from RG_User where RowGuid='" + Session["UserGuid"].ToString() + "') order by row_id desc ";
                DWName_2020.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                CF.BindYearDDL(ddlYear, 2012, true);
                CF.BindMonthDDL(ddlMonth, "0");
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
            //先判断下某个月是否已经提交过
            string strSql = string.Format( "select count(*) from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and Month='{2}'",DWGuid_2020.Text,ddlYear.SelectedValue,ddlMonth.SelectedValue);
            if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) != "0")//说明已经有了
            {
                //进行提示
                WriteAjaxMessage("alert('该月已经存在财务信息');");
                return;
            }
            //一些字段的保存
            Year_2020.Text = ddlYear.SelectedValue;
            Month_2020.Text = ddlMonth.SelectedValue;
            YearMonth_2020.Text = ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-01 00:00:00";
            UpdateUserName_2020.Text = this.DisplayName;
            UpdateUserGuid_2020.Text = this.UserGuid;
            UpdateTime_2020.Text = DateTime.Now.ToString();
            Status_2020.Text = EpointRegisterUser_Bizlogic.OUStatus.编辑中;
            IsHistory_2020.Text = "0";
            oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);

            //如果是父表，要转入多表编辑页面
            //if (oAddPage.TableDetail.TableType == 1)
            //{
            //    Response.Redirect("MultiPageTab.aspx?mode=Mode&TableID=" + oAddPage.TableDetail.TableID + "&RowGuid=" + RowGuid);
            //}
            //else
            //{
            //    this.WriteAjaxMessage("refreshParent();");
            //}
            //Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
            //this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");

            string url = "RG_YueDuCaiWu_Edit.aspx?RowGuid=" + RowGuid + "&DWGuid=" + DWGuid_2020.Text + "&sType=0";
            this.WriteAjaxMessage("refreshParent();alert('添加成功');window.location.href='" + url + "';");

        }

    }
}


