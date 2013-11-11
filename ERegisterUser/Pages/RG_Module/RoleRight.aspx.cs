using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.RegisterUser.DataSyn.Bizlogic;

namespace EpointRegisterUser.Pages.RG_Module
{
    public partial class RoleRight : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ModuleGuid = Request.QueryString["ModuleGuid"];
                string temp = "";
                DataView dvUserType = Epoint.MisBizLogic2.DB.ExecuteDataView("select Code_Items.ItemText,Code_Items.ItemValue from Code_Items inner join Code_Main on Code_Main.CodeID=Code_Items.CodeID inner join RG_Module_Right on RG_Module_Right.AllowGuid=Code_Items.ItemValue where Code_Main.CodeName='RG_会员类别' and RG_Module_Right.AllowType='UserType' and RG_Module_Right.ModuleGuid='"+ModuleGuid+"'");
                foreach (DataRowView rowUserType in dvUserType)
                {
                    lstRole.Items.Add(new ListItem(rowUserType["ItemText"].ToString(),rowUserType["ItemValue"].ToString()));
                    temp = temp + rowUserType["ItemValue"] + "@UserType" + ';';
                }

                DataView dvRole = Epoint.MisBizLogic2.DB.ExecuteDataView("select S.RoleName,S.RowGuid from RG_Role as S INNER JOIN RG_Module_Right as C ON(S.RowGuid = C.AllowGuid) where  C.AllowType = 'Role' and C.ModuleGuid='" + ModuleGuid + "'");
                //lstRole.DataSource = dvRole;
                //lstRole.DataTextField = "RoleName";
                //lstRole.DataValueField = "RowGuid";
                //lstRole.DataBind();
                foreach (DataRowView rowRole in dvRole)
                {
                    lstRole.Items.Add(new ListItem(rowRole["RoleName"].ToString(),rowRole["RowGuid"].ToString()));
                    temp = temp + rowRole["RowGuid"] + "@Role" + ';';
                }
                InitAllowToAll();
               
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
            string ModuleGuid = Request.QueryString["ModuleGuid"];
            // 初始化是否完全公开
            bool isAllowToAll = Epoint.MisBizLogic2.DB.ExecuteToInt("select COUNT(*) FROM RG_Module_Right WHERE AllowGuid='All' AND ModuleGuid='" + ModuleGuid + "'") > 0;

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
            string ModuleGuid = Request.QueryString["ModuleGuid"];
            bool isExists = Epoint.MisBizLogic2.DB.ExecuteToInt("select COUNT(*) FROM RG_Module_Right WHERE AllowGuid='All' and ModuleGuid='" + ModuleGuid + "'") > 0;
            if (chkAllowToAll.Checked)
            {
                // 添加完全公开的配置
                // 判断是否存在,如果存在,不需要添加配置
                if (!isExists)
                {
                    string RowGuid = Guid.NewGuid().ToString();
                    Epoint.MisBizLogic2.Data.MisGuidRow orow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Module_Right", RowGuid);
                    orow["ModuleGuid"] = ModuleGuid;
                    orow["AllowGuid"] = "All";
                    orow["AllowType"] = "";
                    orow.Insert();
                    new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_Module_Right", "RowGuid", RowGuid);
                }
            }
            else
            {
                // 删除完全公开的配置 
                new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Module_Right", "AllowGuid='All'and ModuleGuid='" + ModuleGuid + "'", "RowGuid");
                Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Module_Right WHERE AllowGuid='All'and ModuleGuid='" + ModuleGuid + "'");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string str = Convert.ToString(HidRoleList.Value);
            string ModuleGuid = Request.QueryString["ModuleGuid"];
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select AllowGuid,RowGuid from RG_Module_Right where ModuleGuid='" + ModuleGuid + "'and (AllowType='Role' or AllowType='UserType')");
            if (str.Length == 0)
            {
                new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Module_Right", "ModuleGuid='" + ModuleGuid + "'and (AllowType='Role' or AllowType='UserType')", "RowGuid");
                Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Module_Right where ModuleGuid='" + ModuleGuid + "'and (AllowType='Role' or AllowType='UserType')");

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
                        Boolean needtoAdd=true;
                        foreach (DataRowView row in dv)
                        {
                            if (Convert.ToString(row["AllowGuid"]) == s.Split('@')[0])
                            {
                                needtoAdd=false;
                            }
                        }
                        if (needtoAdd)
                        {
                            Epoint.MisBizLogic2.Data.MisGuidRow orow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Module_Right");
                            orow["ModuleGuid"] = ModuleGuid;
                            orow["AllowGuid"] = s.Split('@')[0];
                            orow["AllowType"] = s.Split('@')[1];
                            orow["RowGuid"] = RowGuid;
                            orow.Insert();
                            new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_Module_Right", "RowGuid", RowGuid);
                        }
                    }
                }
                foreach (DataRowView row in dv)
                {
                   Boolean needtoDel=true;
                    foreach (string s in strArray)
                    {
                        if (Convert.ToString(row["AllowGuid"]) == s.Split('@')[0])
                        {
                            needtoDel=false;
                        }
                    }
                    if (needtoDel)
                    {
                        new ComDataSyn().DeleteWithKeyValue(DataSynTarget.BackEndToFront, "RG_Module_Right", "RowGuid", row["RowGuid"].ToString());
                        Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Module_Right where RowGuid='"+row["RowGuid"].ToString()+"'");

                    }
                }
            }
            SaveAllowToAll();
            WriteAjaxMessage("window.close();");
        }
    }
}
