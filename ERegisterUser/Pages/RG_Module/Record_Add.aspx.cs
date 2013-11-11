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
using Epoint.Web.UI.WebControls2X;
using Epoint.RegisterUser.DataSyn.Bizlogic;
namespace EpointRegisterUser.Pages.RG_Module
{
    public partial class Record_Add : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Epoint.RegisterUser.Front.Bizlogic.RegisterModule.RegisterModule rgModule = new Epoint.RegisterUser.Front.Bizlogic.RegisterModule.RegisterModule();
        public int TableID = 103;
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
                IsForbid_103.SelectedIndex = IsForbid_103.Items.IndexOf(IsForbid_103.Items.FindByText("否"));
                if (Request["IsBelongtoApp"] == "1")
                    trBelongtoApp.Style["display"] = "none";
                else
                    BindApp();
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
            ParentGuid_103.Text = Request.QueryString["ParentGuid"];
            if (Request["ParentGuid"] == "" && rgModule.TopModuleCode("", 4) == "")
                ModuleCode_103.Text = "0001";
            else if (Request["ParentGuid"] == "")
                ModuleCode_103.Text = (Convert.ToInt64(rgModule.TopModuleCode("", 4)) + 1).ToString().PadLeft(4, '0');
            else
            {
                string ParentModuleCode = Epoint.MisBizLogic2.DB.ExecuteToString("select ModuleCode from RG_Module where RowGuid='" + Request["ParentGuid"] + "'");
                int CodeLength = ParentModuleCode.Length + 4;
                string LastModuleCode = rgModule.TopModuleCode(ParentModuleCode, CodeLength);//取得上一个ModuleCode
                if (string.IsNullOrEmpty(LastModuleCode))
                    LastModuleCode = ParentModuleCode + "0000";
                ModuleCode_103.Text = (Convert.ToInt64(LastModuleCode) + 1).ToString().PadLeft(CodeLength, '0');
            }
            if (string.IsNullOrEmpty(Request["AppGuid"]))
            {
                AppGuid_103.Text = BelongToApp.SelectedValue;
            }
            else
                AppGuid_103.Text = Request["AppGuid"];
            if (!string.IsNullOrEmpty(AppGuid_103.Text) && string.IsNullOrEmpty(HidUrl_103.Text))
                HidUrl_103.Text = Epoint.MisBizLogic2.DB.ExecuteToString("select HidUrl from RG_Application where AppGuid='" + AppGuid_103.Text + "'");
            IsBelongtoApp_103.SelectedValue = Request["IsBelongtoApp"];
            oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);
            new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_Module", "RowGuid", RowGuid);

            //如果是父表，要转入多表编辑页面
            if (oAddPage.TableDetail.TableType == 1)
            {
                Response.Redirect("MultiPageTab.aspx?mode=Mode&TableID=" + oAddPage.TableDetail.TableID + "&RowGuid=" + RowGuid);
            }
            Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
            this.WriteAjaxMessage("refreshParent();EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功');");
            this.WriteAjaxMessage("rtnValue(\"\")");
        }

        protected void BindApp()
        {
            BelongToApp.Items.Add(new ListItem("", ""));
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select AppName,AppGuid from RG_Application");
            foreach (DataRowView row in dv)
            {
                BelongToApp.Items.Add(new ListItem(row["AppName"].ToString(), row["AppGuid"].ToString()));
            }
        }
        ///// <summary>
        ///// 获取指定长度的ModuleCode的最大的一个
        ///// </summary>
        ///// <param name="length"></param>
        ///// <returns></returns>
        //protected string TopModuleCode(string ParentModuleCode, int CodeLength)
        //{
        //    string sqlstr = "";
        //    if (!string.IsNullOrEmpty(ParentModuleCode))
        //        sqlstr = "select top 1 ModuleCode from RG_Module where substring(ModuleCode,1, " + (CodeLength-4) + ")='" + ParentModuleCode + "'and len(ModuleCode)='" + CodeLength + "'order by ModuleCode desc";
        //    else
        //        sqlstr = "select top 1 ModuleCode from RG_Module where len(ModuleCode)='" + CodeLength + "' order by ModuleCode desc";
        //    return Epoint.MisBizLogic2.DB.ExecuteToString(sqlstr);
        //}
    }
}


