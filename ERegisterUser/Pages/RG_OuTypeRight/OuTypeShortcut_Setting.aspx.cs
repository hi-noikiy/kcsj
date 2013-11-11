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
using Epoint.Frame.Entity;
using Epoint.RegisterUser.DataSyn.Bizlogic;
namespace EpointRegisterUser.Pages.RG_OuTypeRight
{
    public partial class OuTypeShortcut_Setting : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string OuTypeValue = Request["OuTypeValue"].ToString();
                string ShortcutGuidLst = "";
                //string ShortcutGuidLstALL = "";
                ViewState["AllowTo"] = OuTypeValue;
                //DataView dvAll = Epoint.MisBizLogic2.DB.ExecuteDataView("select ShortcutGuid from RG_ShortcutMenu_Right where AllowGuid='All'");
                //for (int i = 0; i < dvAll.Count; i++)
                //    ShortcutGuidLstALL += dvAll[i]["ShortcutGuid"] + ";";
                string OuTypeName = Epoint.MisBizLogic2.DB.ExecuteToString("select ItemText from Code_Items inner join Code_Main on Code_Main.CodeID=Code_Items.CodeID where ItemValue='" + OuTypeValue + "'and Code_Main.CodeName='RG_会员单位'");
                lblName.Text = "所选会员单位：<font color='red'>" + OuTypeName + "</font>&nbsp;&nbsp;";
                this.CurrentPosition = "会员单位快捷菜单设置";
                this.Title = "会员单位快捷菜单设置";
                DataView dvShortcutRight = Epoint.MisBizLogic2.DB.ExecuteDataView("select ShortcutGuid from RG_ShortcutMenu_Right where AllowGuid='" + OuTypeValue + "'and AllowType='OUType'");
                for (int i = 0; i < dvShortcutRight.Count; i++)
                    ShortcutGuidLst += dvShortcutRight[i]["ShortcutGuid"] + ";";
                ViewState["ShortcutGuidLst"] = ShortcutGuidLst.ToLower();
                //ViewState["ShortcutGuidLstALL"] = ShortcutGuidLstALL.ToLower();
                HidShortcutGuid.Value = ViewState["ShortcutGuidLst"].ToString();
                bindRpt();
            }
        }
        /// <summary>
        /// 绑定快捷菜单类别
        /// </summary>
        private void bindRpt()
        {
            DataView dvTopShortcut = Epoint.MisBizLogic2.DB.ExecuteDataView("select ItemText,ItemValue from Code_Items inner join Code_Main on Code_Main.CodeID=Code_Items.CodeID where Code_Main.CodeName='快捷菜单类别' order by Code_Items.OrderNo desc");
            rptFirShortcut.DataSource = dvTopShortcut;
            rptFirShortcut.DataBind();
        }
        /// <summary>
        /// 取得对应类别的快捷菜单
        /// </summary>
        /// <param name="ShortcutType"></param>
        /// <returns></returns>
        public DataView getSubShortcutView(object ShortcutType)
        {
            DataView dvSub = Epoint.MisBizLogic2.DB.ExecuteDataView("select ShortcutText,RowGuid from RG_ShortcutMenu where ShortcutType='" + ShortcutType.ToString() + "'");
            return dvSub;
        }
        /// <summary>
        /// 绑定快捷菜单
        /// </summary>
        /// <param name="objShortcutText"></param>
        /// <param name="objShortcutGuid"></param>
        /// <returns></returns>
        public string getShortcutGuid(object objShortcutText, object objShortcutGuid)
        {
            string ShortcutText = objShortcutText.ToString();
            string ShortcutGuid = objShortcutGuid.ToString();
            string rtnHtml = "";
            rtnHtml += "<input type=\"checkbox\" name=\"" + ShortcutText + "\"";
            if (HasShortcutRight(ShortcutGuid, ViewState["AllowTo"].ToString()))
                rtnHtml += " checked='checked'";
            rtnHtml += " onpropertychange=\"javascript:AutoSetMValue(this," + "'" + ShortcutGuid + "')\" />" + ShortcutText;
            return rtnHtml;
        }


        protected void savbtn_Click(object sender, EventArgs e)
        {
            string AllowTo = ViewState["AllowTo"].ToString();

            //删除此会员单位原有配置的所有的快捷方式
            Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_ShortcutMenu_Right where AllowGuid='" + AllowTo + "'and AllowType='OUType'");
            new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_ShortcutMenu_Right", "AllowGuid='" + AllowTo + "'and AllowType='OUType'", "RowGuid");

            //保存有权限的快捷方式
            string strSelectMoGuid = HidShortcutGuid.Value;
            string[] ShortcutGuisLst = strSelectMoGuid.Split(';');
            string ShortcutGuid = "";
            for (int i = 0; i < ShortcutGuisLst.Length; i++)
            {
                ShortcutGuid = ShortcutGuisLst[i];
                if (ShortcutGuid != "")
                {
                    string RowGuid = Guid.NewGuid().ToString();
                    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_ShortcutMenu_Right");
                    oRow["RowGuid"] = RowGuid;
                    oRow["ShortcutGuid"] = ShortcutGuid;
                    oRow["AllowGuid"] = AllowTo;
                    oRow["AllowType"] = "OUType";
                    oRow.Insert();
                }
            }
            new ComDataSyn().InsertWithCondition(DataSynTarget.BackEndToFront, "RG_ShortcutMenu_Right", "AllowGuid='" + AllowTo + "'and AllowType='OUType'", "RowGuid");

            WriteAjaxMessage("alert('权限设置成功！');rtnValue('');");
        }
        /// <summary>
        /// 判断是否有快捷方式的权限
        /// </summary>
        /// <param name="ShortcutGuid"></param>
        /// <param name="OuTypeValue"></param>
        /// <returns></returns>
        protected Boolean HasShortcutRight(string ShortcutGuid, string OuTypeValue)
        {
            string sql = "select count(1) from RG_ShortcutMenu_Right where ShortcutGuid='" + ShortcutGuid + "'and AllowGuid='" + OuTypeValue + "'and AllowType='OUType'";
            return Epoint.MisBizLogic2.DB.ExecuteToInt(sql) > 0;
        }
    }
}
