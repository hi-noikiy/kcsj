using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Epoint.Frame.Bizlogic.UserManage;
using Epoint.RegisterUser.Bizlogic.Consult;

namespace EpointRegisterUser.Consult.ConsultBoxTongJi
{
    public partial class ConsultBoxTongJiTopTen : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Infragistics.WebUI.UltraWebTab.Tab tab0 = new Infragistics.WebUI.UltraWebTab.Tab();
                tab0.Text = "受理总数";
                tab0.ContentPane.TargetUrl = "ConsultBoxTongJiTopTenUrl.aspx";
                tab0.ContentPane.BorderWidth = 0;
                UltraWebTab1.Tabs.Add(tab0);

                Infragistics.WebUI.UltraWebTab.Tab tab1 = new Infragistics.WebUI.UltraWebTab.Tab();
                tab1.Text = "回 复 率";
                tab1.ContentPane.TargetUrl = "ConsultBoxTongJiTopTenUrl.aspx?type=1";
                tab1.ContentPane.BorderWidth = 0;
                UltraWebTab1.Tabs.Add(tab1);

                Infragistics.WebUI.UltraWebTab.Tab tab2 = new Infragistics.WebUI.UltraWebTab.Tab();
                tab2.Text = "及 时 率";
                tab2.ContentPane.TargetUrl = "ConsultBoxTongJiTopTenUrl.aspx?type=2";
                tab2.ContentPane.BorderWidth = 0;
                UltraWebTab1.Tabs.Add(tab2);

                Infragistics.WebUI.UltraWebTab.Tab tab3 = new Infragistics.WebUI.UltraWebTab.Tab();
                tab3.Text = "满 意 度";
                tab3.ContentPane.TargetUrl = "ConsultBoxTongJiTopTenUrl.aspx?type=3";
                tab3.ContentPane.BorderWidth = 0;
                UltraWebTab1.Tabs.Add(tab3);

                UltraWebTab1.SelectedTab = 0;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultBoxTongJiFrame.aspx");
        }
    }
}
