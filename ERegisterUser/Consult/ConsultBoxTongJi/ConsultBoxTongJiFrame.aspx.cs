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

namespace EpointRegisterUser.Consult.ConsultBoxTongJi
{
    public partial class ConsultBoxTongJiFrame : Epoint.Frame.Bizlogic.BaseContentPage_UsingMasterWithTree
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CurrentLeftPosition = "�����б�";
            this.CurrentRightPosition = "�����б�";
            this.CurrentPosition = "����ͳ��";
            this.CurrentTitle = "����ͳ��";
        }
    }
}
