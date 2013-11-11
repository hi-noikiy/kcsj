using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.RegisterUser.DataSyn.Bizlogic;

namespace EpointRegisterUser.Pages.RG_Application
{
    public partial class RG_Application_OUTypeRight : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string AppGuid = Request.QueryString["AppGuid"];
                //DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select S.OUTypeName,S.RowGuid from RG_OUType as S INNER JOIN RG_Application_Right as C ON(S.RowGuid = C.AllowGuid) where  C.AllowType = 'OUType' and C.AppGuid='" + AppGuid + "'");
                DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select S.ItemText,S.ItemValue from Code_Items as S inner join Code_Main on S.CodeID=Code_Main.CodeID INNER JOIN RG_Application_Right as C ON(S.ItemValue = C.AllowGuid) where  C.AllowType = 'OUType' and C.AppGuid='" + AppGuid + "' and Code_Main.CodeName='RG_会员单位'");
                lstOUType.DataSource = dv;
                lstOUType.DataTextField = "ItemText";
                lstOUType.DataValueField = "ItemValue";
                lstOUType.DataBind();
                string temp = "";
                for (int i = 0; i < lstOUType.Items.Count; i++)
                {
                    temp = temp + lstOUType.Items[i].Value + ';';
                }
                HidOUTypeList.Value = temp;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string str = Convert.ToString(HidOUTypeList.Value);
            string AppGuid = Request.QueryString["AppGuid"];
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select AllowGuid from RG_Application_Right where AppGuid='" + AppGuid + "'and AllowType='OUType'");
            if (str.Length == 0)
            {
                new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Application_Right", "AppGuid='" + AppGuid + "'and AllowType='OUType'", "RowGuid");

                Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Application_Right where AppGuid='" + AppGuid + "'and AllowType='OUType'");
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
                            orow["AllowType"] = "OUType";
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
                        new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Application_Right", "AllowGuid='" + Convert.ToString(row[0]) + "'and AppGuid='" + AppGuid + "'and AllowType='OUType'", "RowGuid");
                        Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Application_Right where AllowGuid='" + Convert.ToString(row[0]) + "'and AppGuid='" + AppGuid + "'and AllowType='OUType'");
                    }
                }
            }
            WriteAjaxMessage("window.close();");
        }
    }
}
