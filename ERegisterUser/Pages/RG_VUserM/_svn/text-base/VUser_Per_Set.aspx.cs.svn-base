using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.RegisterUser.DataSyn.Bizlogic;

namespace EpointRegisterUser.Pages.RG_VUserM
{
    public partial class VUser_Per_Set : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string VUserGuid = Request.QueryString["RowGuid"];
                DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select S.DisplayName,S.UserGuid from Frame_User as S INNER JOIN RG_VUser as C ON(S.UserGuid = C.MapGuid) where  C.MapType = 'User' and C.VUserGuid='" + VUserGuid + "'");
                lstUser.DataSource = dv;
                lstUser.DataTextField = "DisplayName";
                lstUser.DataValueField = "UserGuid";
                lstUser.DataBind();
                string temp = "";
                for (int i = 0; i < lstUser.Items.Count; i++)
                {
                    temp = temp + lstUser.Items[i].Value + '★';
                }
                HidUserList.Value = temp;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string str = Convert.ToString(HidUserList.Value);

            string VUserGuid = Request.QueryString["RowGuid"];
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select MapGuid from RG_VUser where VUserGuid='" + VUserGuid + "'and MapType='User'");
            if (str.Length == 0)
            {
                new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_VUser", " VUserGuid='" + VUserGuid + "'and MapType='User'", "RowGuid");

                Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_VUser where VUserGuid='" + VUserGuid + "'and MapType='User'");
            }
            else
            {
                str = str.Substring(0, str.Length - 1);
                string[] strArray = str.Split('★');
                foreach (string s in strArray)
                {
                    string RowGuid = Guid.NewGuid().ToString();
                    string MapType = "User";
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
                        Epoint.MisBizLogic2.Data.MisGuidRow orow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_VUser", RowGuid);
                        orow["VUserGuid"] = VUserGuid;
                        orow["MapType"] = MapType;
                        orow["MapGuid"] = s;
                        orow.Insert();
                        new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_VUser", "RowGuid", RowGuid);
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
                        new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_VUser", "MapGuid='" + Convert.ToString(row[0]) + "'and VUserGuid='" + VUserGuid + "'and MapType='User'", "RowGuid");

                        Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_VUser where MapGuid='" + Convert.ToString(row[0]) + "'and VUserGuid='" + VUserGuid + "'and MapType='User'");
                    }
                }
            }
            WriteAjaxMessage("window.close();");
            
        }
    }
}
