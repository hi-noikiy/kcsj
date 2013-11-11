using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Epoint.RegisterUser.DataSyn.Bizlogic;

namespace EpointRegisterUser.Pages.RG_Module
{
    public partial class OUTypeRight : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ModuleGuid = Request.QueryString["ModuleGuid"];
                DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select S.ItemText,S.ItemValue from Code_Items as S inner join Code_Main on S.CodeID=Code_Main.CodeID INNER JOIN RG_Module_Right as C ON(S.ItemValue = C.AllowGuid) where  C.AllowType = 'OUType' and C.ModuleGuid='" + ModuleGuid + "' and Code_Main.CodeName='会员单位'");
                lstOUType.DataSource = dv;
                lstOUType.DataTextField = "ItemText";
                lstOUType.DataValueField = "ItemValue";
                lstOUType.DataBind();
                InitAllowToAll();
                string temp = "";
                for (int i = 0; i < lstOUType.Items.Count; i++)
                { 
                    temp = temp + lstOUType.Items[i].Value + ';';
                }
                HidOUTypeList.Value = temp;
            }
        }

        /// <summary>
        /// 初始化完全公开功能
        /// </summary>
        private void InitAllowToAll()
        {
            string ModuleGuid = Request.QueryString["ModuleGuid"];
            // 初始化是否完全公开
            bool isAllowToAll = Epoint.MisBizLogic2.DB.ExecuteToInt("select COUNT(*) FROM RG_Module_Right WHERE AllowType = 'OUType' AND AllowGuid='All' AND ModuleGuid='" + ModuleGuid + "'") > 0;

            if (isAllowToAll)
            {
                lstOUType.Enabled = false;
            }
            else
            {
                lstOUType.Enabled = true;
            }
            chkAllowToAll.Checked = isAllowToAll;
        }

        protected void SaveAllowToAll()
        {
            string ModuleGuid = Request.QueryString["ModuleGuid"];
            bool isExists = Epoint.MisBizLogic2.DB.ExecuteToInt("select COUNT(*) FROM RG_Module_Right WHERE AllowType = 'OUType' AND AllowGuid='All' and ModuleGuid='" + ModuleGuid + "'") > 0;
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
                    orow["AllowType"] = "OUType";
                    orow.Insert();
                    new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_Module_Right", "RowGuid", RowGuid);
                }
            }
            else
            {
                // 删除完全公开的配置 
                new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Module_Right", "AllowGuid='All'and ModuleGuid='" + ModuleGuid + "'and AllowType='OUType'", "RowGuid");
                Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Module_Right WHERE AllowGuid='All'and ModuleGuid='" + ModuleGuid + "'and AllowType='OUType'");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string str = Convert.ToString(HidOUTypeList.Value);
            string ModuleGuid = Request.QueryString["ModuleGuid"];
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select AllowGuid from RG_Module_Right where ModuleGuid='" + ModuleGuid + "'and AllowType='OUType'");
            if (str.Length == 0)
            {
                new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Module_Right", "ModuleGuid='" + ModuleGuid + "'and AllowType='OUType'", "RowGuid");
                Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Module_Right where ModuleGuid='" + ModuleGuid + "'and AllowType='OUType'");

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
                            Epoint.MisBizLogic2.Data.MisGuidRow orow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Module_Right");
                            orow["ModuleGuid"] = ModuleGuid;
                            orow["AllowGuid"] = s;
                            orow["AllowType"] = "OUType";
                            orow["RowGuid"] = RowGuid;
                            orow.Insert();
                            new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_Module_Right", "RowGuid", RowGuid);
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
                        new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_Module_Right", "AllowGuid='" + Convert.ToString(row[0]) + "'and ModuleGuid='" + ModuleGuid + "'and AllowType='OUType'", "RowGuid");
                        Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Module_Right where AllowGuid='" + Convert.ToString(row[0]) + "'and ModuleGuid='" + ModuleGuid + "'and AllowType='OUType'");

                    }
                }
            }
            SaveAllowToAll();
            WriteAjaxMessage("window.close();");
        }
    }
}
