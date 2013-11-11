using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Epoint.RegisterUser.DataSyn.Bizlogic;

namespace EpointRegisterUser.Pages.RG_User
{
    public partial class RG_UserActivation : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Epoint.RegisterUser.Front.Bizlogic.SymmetricMethod SymmetricMethod = new Epoint.RegisterUser.Front.Bizlogic.SymmetricMethod();

        protected void Page_Load(object sender, EventArgs e)
        {
            TimeSpan ts = System.DateTime.Now - Convert.ToDateTime(SymmetricMethod.Decrypto(Request["SendTime"]));
            if (ts.Days > 3)
            {
                AlertAjaxMessage("激活链接已过期，请重新获取！");
                return;
            }
            if (string.IsNullOrEmpty(Request["UserGuid"]))
                AlertAjaxMessage("缺少账号标识，无法激活！");
            else
            {
                string UserGuid = SymmetricMethod.Decrypto(Request["UserGuid"]);
                Epoint.MisBizLogic2.DB.ExecuteNonQuery("update RG_User set IsValid='1' where RowGuid='" + UserGuid + "'");
                new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_User", "RowGuid", UserGuid);
                AlertAjaxMessage("恭喜，您的账号激活成功！");
            }
            WriteAjaxMessage("window.close();");
        }
    }
}