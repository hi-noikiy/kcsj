using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace HTProject.Ascx
{
    public partial class OUEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取当前企业的guid
            string strSql = "select DanWeiGuid from RG_USER where ROWGUID='"+ Session["UserGuid"] +"'";
            ViewState["DWGuid"] = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            string QYStatus = Epoint.MisBizLogic2.DB.ExecuteToString( "SELECT STATUS FROM RG_OUInfo WHERE ROWGUID='" + ViewState["DWGuid"] + "'");
            //获取状态，编辑中、审核退回的，到edit2
            if(QYStatus == "60" || QYStatus == "80")
            {
                lblQYEditMessage.Text = "企业信息修改";
                OE.Attributes.Add("onclick", "OpenWindow('Pages/RG_OU/RG_OU_Edit2.aspx?RowGuid=" + ViewState["DWGuid"].ToString() + "',800,700);");
            }
            //通过的、变更中的，到edit
            else if (QYStatus == "85" || QYStatus == "90")
            {
                lblQYEditMessage.Text = "企业信息修改";
                OE.Attributes.Add("onclick", "OpenWindow('Pages/RG_OU/RG_OU_Edit.aspx?RowGuid=" + ViewState["DWGuid"].ToString() + "',800,700);");
            }
            else//查看
            {
                lblQYEditMessage.Text = "企业信息查看";
                OE.Attributes.Add("onclick", "OpenWindow('Pages/RG_OU/RG_OU_All_Detail.aspx?RowGuid=" + ViewState["DWGuid"].ToString() + "',800,700);");
            }

            //获取未审核通过的企业职业人员数
            strSql = "select Count(*) from RG_QYUser where DWGuid='" + ViewState["DWGuid"] + "' and DelStatus='1' and Status in('60','80')";
            lblNoPassRYCount.Text = "("+ Epoint.MisBizLogic2.DB.ExecuteToString(strSql) +")";

            //获取未审核通过的企业资质数
            strSql = "select Count(*) from RG_QiYeZiZhi where DWGuid='" + ViewState["DWGuid"] + "' and DelStatus='1' and Status in('60','80')";
            lblQYZZCount.Text = "(" + Epoint.MisBizLogic2.DB.ExecuteToString(strSql) + ")";

            //获取未审核通过的企业资质数
            strSql = "select Count(*) from RG_XMBeiAn where DWGuid='" + ViewState["DWGuid"] + "' and DelStatus='1' and Status in('60','80')";
            lblBACount.Text = "(" + Epoint.MisBizLogic2.DB.ExecuteToString(strSql) + ")";
        }
    }
}