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

namespace EpointRegisterUser.Pages.Pages_RG.RG_User
{
    public partial class ChangeUserInfo : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Epoint.RegisterUser.Front.Bizlogic.RegisterUser.RegisterUser rgUser = new Epoint.RegisterUser.Front.Bizlogic.RegisterUser.RegisterUser();
        public int TableID = 2010;
        Epoint.MisBizLogic2.Web.EditPage oEditPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, rgUser.GetCurrentRegisterUser().RegisterUserGuid);
               
                if (!oRow.R_HasFilled)
                {
                    btnEdit.Visible = false;
                    this.AlertAjaxMessage("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }
                //txtUserIdendity.Text = oRow["UserIdendity"].ToString();
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
                //添加上传文件的大小和类型检查

                this.Add_FileUploadCheck_Script();

                string strSql = " select top(1) EnterpriseName from rg_ouinfo where DWGuid='" + DanWeiGuid_2010.Text + "' order by row_id desc ";
                TxtDanWei.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            }
        }

        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            base.OnInit(e);
        }

        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
       
            //UserIdendity_2010.Text = txtUserIdendity.Text;
            string RowGuid = rgUser.GetCurrentRegisterUser().RegisterUserGuid;
            Boolean UserExisted = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(RowGuid) from RG_User where LoginID='" + LoginID_2010.Text + "' and RowGuid<>'" + RowGuid + "'") > 1;
            if (UserExisted)
            {
                AlertAjaxMessage("该登录名已被使用,请修改登录名！");
                return;
            }
            oEditPage.SaveTableValues(rgUser.GetCurrentRegisterUser().RegisterUserGuid, tdContainer);
            //new ComDataSyn().UpdateWithKeyValue(DataSynTarget.FrontToBackEnd, "RG_User", "RowGuid", rgUser.GetCurrentRegisterUser().RegisterUserGuid);
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, RowGuid);
            oRow["UserStatus"] = "002";
            //oRow["DanWeiGuid"] = DanWeiGuid_2010.Text;
            oRow.Update();
            this.WriteAjaxMessage("location.reload();EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");
        }
    }
}
