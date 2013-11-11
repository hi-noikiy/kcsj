using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.RegisterUser.DataSyn.Bizlogic;

namespace EpointRegisterUser.Pages.RG_Application
{
    public partial class RG_Application_RoleRight : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string AppGuid = Request.QueryString["AppGuid"];
                string temp = "";
                DataView dvUserType = Epoint.MisBizLogic2.DB.ExecuteDataView("select Code_Items.ItemText,Code_Items.ItemValue from Code_Items inner join Code_Main on Code_Main.CodeID=Code_Items.CodeID inner join RG_Application_Right on RG_Application_Right.AllowGuid=Code_Items.ItemValue where Code_Main.CodeName='RG_会员类别' and RG_Application_Right.AllowType='UserType' and RG_Application_Right.AppGuid='" + AppGuid + "'");
                foreach (DataRowView rowUserType in dvUserType)
                {
                    lstRole.Items.Add(new ListItem(rowUserType["ItemText"].ToString(), rowUserType["ItemValue"].ToString()));
                    temp = temp + rowUserType["ItemValue"] + "@UserType" + ';';
                }
                DataView dvRole = Epoint.MisBizLogic2.DB.ExecuteDataView("select S.RoleName,S.RowGuid from RG_Role as S INNER JOIN RG_Application_Right as C ON(S.RowGuid = C.AllowGuid) where  C.AllowType = 'Role' and C.AppGuid='" + AppGuid + "'");
                //lstRole.DataSource = dv;
                //lstRole.DataTextField = "RoleName";
                //lstRole.DataValueField = "RowGuid";
                //lstRole.DataBind();


                InitAllowToAll();
                foreach (DataRowView rowRole in dvRole)
                {
                    lstRole.Items.Add(new ListItem(rowRole["RoleName"].ToString(), rowRole["RowGuid"].ToString()));
                    temp = temp + rowRole["RowGuid"] + "@Role" + ';';
                }
                //string temp = "";
                //for (int i = 0; i < lstRole.Items.Count; i++)
                //{
                //    temp = temp + lstRole.Items[i].Value + ';';
                //}
                HidRoleList.Value = temp;
            }
        }

        /// <summary>
        /// 初始化完全公开功能
        /// </summary>
        private void InitAllowToAll()
        {
            string AppGuid = Request.QueryString["AppGuid"];
            // 初始化是否完全公开
            bool isAllowToAll = Epoint.MisBizLogic2.DB.ExecuteToInt("select COUNT(*) FROM RG_Application_Right WHERE AllowGuid='All' AND AppGuid='" + AppGuid + "'") > 0;

            if (isAllowToAll)
            {
                lstRole.Enabled = false;
            }
            else
            {
                lstRole.Enabled = true;
            }
            chkAllowToAll.Checked = isAllowToAll;
        }

        protected void SaveAllowToAll()
        {
            string AppGuid = Request.QueryString["AppGuid"];
            bool isExists = Epoint.MisBizLogic2.DB.ExecuteToInt("select COUNT(*) FROM RG_Application_Right WHERE AllowGuid='All' and AppGuid='" + AppGuid + "'") > 0;
            if (chkAllowToAll.Checked)
            {
                // 添加完全公开的配置
                // 判断是否存在,如果存在,不需要添加配置
                if (!isExists)
                {
                    string RowGuid = Guid.NewGuid().ToString();
                    Epoint.MisBizLogic2.Data.MisGuidRow orow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Application_Right", RowGuid);
                    orow["AppGuid"] = AppGuid;
                    orow["AllowGuid"] = "All";
                    orow["AllowType"] = "";
                    //orow["AppType"] = Request["AppType"];
                    orow.Insert();
                    new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_Application_Right", "RowGuid", RowGuid);
                }
            }
            else
            {
                // 删除完全公开的配置 
                new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Application_Right", "AllowGuid='All'and AppGuid='" + AppGuid + "'", "RowGuid");
                Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Application_Right WHERE AllowGuid='All'and AppGuid='" + AppGuid + "'");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string str = Convert.ToString(HidRoleList.Value);
            string AppGuid = Request.QueryString["AppGuid"];
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select AllowGuid,RowGuid from RG_Application_Right where AppGuid='" + AppGuid + "'and (AllowType='Role' or AllowGuid='UserType')");
            if (str.Length == 0)
            {
                new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Application_Right", "AppGuid='" + AppGuid + "'and (AllowType='Role' or AllowGuid='UserType')", "RowGuid");

                Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Application_Right where AppGuid='" + AppGuid + "'and (AllowType='Role' or AllowGuid='UserType')");
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
                        Boolean needtoAdd = true;
                        foreach (DataRowView row in dv)
                        {
                            if (Convert.ToString(row["AllowGuid"]) == s.Split('@')[0])
                            {
                                needtoAdd = false;
                            }
                        }
                        if (needtoAdd)
                        {
                            Epoint.MisBizLogic2.Data.MisGuidRow orow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Application_Right", RowGuid);
                            orow["AppGuid"] = AppGuid;
                            orow["AllowGuid"] = s.Split('@')[0];
                            orow["AllowType"] = s.Split('@')[1];
                            //orow["AppType"] = Request["AppType"];
                            orow.Insert();
                            new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_Application_Right", "RowGuid", RowGuid);
                        }
                    }

                }
                foreach (DataRowView row in dv)
                {
                    Boolean needtoDel = true;
                    foreach (string s in strArray)
                    {
                        if (Convert.ToString(row["AllowGuid"]) == s.Split('@')[0])
                        {
                            needtoDel = true;
                        }
                    }
                    if (needtoDel)
                    {
                        new ComDataSyn().DeleteWithKeyValue(DataSynTarget.BackEndToFront, "RG_Application_Right", "RowGuid", row["RowGuid"].ToString());
                        Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Application_Right where RowGuid='" + row["RowGuid"].ToString() + "'");
                    }
                }
            }
            SaveAllowToAll();
            WriteAjaxMessage("window.close();");
        }
    }
}
