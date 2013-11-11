using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.RegisterUser.DataSyn.Bizlogic;

namespace EpointRegisterUser.Pages.RG_Application
{
    public partial class RG_Application_UserRight : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string AppGuid = Request.QueryString["AppGuid"];
                DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select S.DispName,S.RowGuid from RG_User as S INNER JOIN RG_Application_Right as C ON(S.RowGuid = C.AllowGuid) where  C.AllowType = 'User' and C.AppGuid='" + AppGuid + "'");
                lstUser.DataSource = dv;
                lstUser.DataTextField = "DispName";
                lstUser.DataValueField = "RowGuid";
                lstUser.DataBind();
                string temp = "";
                for (int i = 0; i < lstUser.Items.Count; i++)
                {
                    temp = temp + lstUser.Items[i].Value + ';';
                }
                HidUserList.Value = temp;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string str = Convert.ToString(HidUserList.Value);
            string AppGuid = Request.QueryString["AppGuid"];
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select AllowGuid from RG_Application_Right where AppGuid='" + AppGuid + "'and AllowType='User'");
            if (str.Length == 0)
            {
                new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Application_Right", "AppGuid='" + AppGuid + "'and AllowType='User'", "RowGuid");

                Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Application_Right where AppGuid='" + AppGuid + "'and AllowType='User'");
            }
            else
            {
                str = str.Substring(0, str.Length - 1);
                string[] strArray = str.Split(';');
                foreach (string s in strArray)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        string RowGuid = Guid.NewGuid().ToString();
                        int count = 0;
                        foreach (DataRowView row in dv)
                        {
                            if (Convert.ToString(row[0]) == s)
                            {
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            Epoint.MisBizLogic2.Data.MisGuidRow orow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Application_Right", RowGuid);
                            orow["AppGuid"] = AppGuid;
                            orow["AllowGuid"] = s;
                            orow["AllowType"] = "User";
                            orow["AppType"] = Request["AppType"];
                            orow.Insert();
                            new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_Application_Right", "RowGuid", RowGuid);
                        }
                    }

                }
                foreach (DataRowView row in dv)
                {
                    int count = 0;
                    foreach (string s in strArray)
                    {
                        if (Convert.ToString(row[0]) == s)
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Application_Right", "AllowGuid='" + Convert.ToString(row[0]) + "'and AppGuid='" + AppGuid + "'and AllowType='User'", "RowGuid");
                        Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Application_Right where AllowGuid='" + Convert.ToString(row[0]) + "'and AppGuid='" + AppGuid + "'and AllowType='User'");
                    }
                }
            }
            WriteAjaxMessage("window.close();");
        }
    }
}
