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
namespace HTProject.Pages.RG_User
{

    public partial class ChangePwd : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Epoint.RegisterUser.Front.Bizlogic.RegisterUser.RegisterUser rgUser = new Epoint.RegisterUser.Front.Bizlogic.RegisterUser.RegisterUser();
        
        protected void Page_Load(object sender, System.EventArgs e)
        {
        }

        protected void btnSave_Click(Object sender, EventArgs args)
        {
            //判断老密码是否正确
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_User", rgUser.GetCurrentRegisterUser().RegisterUserGuid);
            if (Epoint.Frame.Bizlogic.common.authPassword(txtOldPwd.Text) != oRow["Password"].ToString())
            {
                AlertAjaxMessage("输入的老密码不正确");
                return;
            }
            // 判断重复密码是否正确
            if (txtNewPwd.Text != txtRptPwd.Text)
            {
                AlertAjaxMessage("两次输入的密码不正确");
                return;
            }

            // 保存密码
            oRow["Password"] = Epoint.Frame.Bizlogic.common.authPassword(txtRptPwd.Text);
            oRow.Update();
            new ComDataSyn().UpdateWithKeyValue(DataSynTarget.FrontToBackEnd, "RG_User", "RowGuid", rgUser.GetCurrentRegisterUser().RegisterUserGuid);
            AlertAjaxMessage("保存成功");
            WriteAjaxMessage("window.close();");

        }
    }
}


