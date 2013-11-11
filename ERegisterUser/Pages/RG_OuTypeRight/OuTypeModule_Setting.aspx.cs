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
namespace EpointRegisterUser.Pages.RG_OuTypeRight
{
    public partial class OuTypeModule_Setting : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string OuTypeValue = Request["OuTypeValue"].ToString();

                string moduleGuidLst = "";
                string moduleGuidLstALL = "";
                ViewState["AllowTo"] = OuTypeValue;

                //DataView dvAll = Epoint.MisBizLogic2.DB.ExecuteDataView("select ModuleGuid from RG_Module_Right where AllowGuid='All'");//ModuleRights.Select_ByAllow("ALL", "role");
                //for (int i = 0; i < dvAll.Count; i++)
                //    moduleGuidLstALL += dvAll[i]["ModuleGuid"] + ";";

                //if (Request["AllowType"].ToLower() == "user")
                //{
                //Detail_Frame_User dt_user = user.GetDetailByUserGuid(argsGuid);
                string OuTypeName = Epoint.MisBizLogic2.DB.ExecuteToString("select ItemText from Code_Items inner join Code_Main on Code_Main.CodeID=Code_Items.CodeID where ItemValue='" + OuTypeValue + "'and Code_Main.CodeName='RG_会员单位'");
                lblName.Text = "所选会员单位：<font color='red'>" + OuTypeName + "</font>&nbsp;&nbsp;";
                //lblOuName.Text = "所在部门：<font color='red'>" + ous.GetDetail(dt_user.OUGuid).OUName + "</font>";
                this.CurrentPosition = "会员单位模块设置";
                this.Title = "会员单位模块设置";

                DataView dvModuleRight = Epoint.MisBizLogic2.DB.ExecuteDataView("select ModuleGuid from RG_Module_Right where AllowGuid='" + OuTypeValue + "'and AllowType='OUType'");//ModuleRights.Select_ByAllow(argsGuid, "user");
                for (int i = 0; i < dvModuleRight.Count; i++)
                    moduleGuidLst += dvModuleRight[i]["ModuleGuid"] + ";";
                ViewState["moduleGuidLst"] = moduleGuidLst.ToLower();
                ViewState["moduleGuidLstALL"] = moduleGuidLstALL.ToLower();
                HidModuleGuid.Value = ViewState["moduleGuidLst"].ToString();
                bindRpt1();
                bindApp();
            }
        }
        private void bindRpt1()
        {
            DataView dvTopModule = Epoint.MisBizLogic2.DB.ExecuteDataView("select RowGuid,ModuleName,ModuleCode from RG_Module where ParentGuid='' and ModuleCode<>'' and IsBelongtoApp='0' order by OrderNum desc"); ;//db_fm.SelectOneNextLevelModuleView("", ViewState["moduleType"].ToString());
            Repeater1.DataSource = dvTopModule;
            Repeater1.DataBind();
        }
        public DataView bindRpt2(object AppGuid)
        {
            DataView dvAppTopModule = Epoint.MisBizLogic2.DB.ExecuteDataView("select RowGuid,ModuleName,ModuleCode from RG_Module where ParentGuid='' and ModuleCode<>'' and IsBelongtoApp='1' and AppGuid='" + AppGuid.ToString() + "' order by OrderNum desc"); ;//db_fm.SelectOneNextLevelModuleView("", ViewState["moduleType"].ToString());
            return dvAppTopModule;
        }
        private void bindApp()
        {
            DataView dvApp = Epoint.MisBizLogic2.DB.ExecuteDataView("select AppGuid,AppName from RG_Application order by OrderNum desc");
            Repeater3.DataSource = dvApp;
            Repeater3.DataBind();
        }

        public DataView getSubModuleView(object moduleCode, object type)
        {
            //DataView dvSub = db_fm.SelectOneNextLevelModuleView(moduleCode.ToString(), ViewState["moduleType"].ToString());
            DataView dvSub = Epoint.MisBizLogic2.DB.ExecuteDataView("select * from RG_Module where substring(ModuleCode,1," + moduleCode.ToString().Length + ")='" + moduleCode.ToString() + "'and len(ModuleCode)='" + (moduleCode.ToString().Length + 4) + "' order by OrderNum desc");
            return dvSub;
        }


        public string getModuleGuid(object ObjModuleGuid, Object ObjModuleCode, Object ObjmoduleName)
        {
            string moduleGuidLst = ViewState["moduleGuidLst"].ToString();
            //string moduleGuidLstALL = ViewState["moduleGuidLstALL"].ToString();
            //string moduleType = ViewState["moduleType"].ToString();
            string ModuleGuid = ObjModuleGuid.ToString();
            string ModuleCode = ObjModuleCode.ToString();
            string moduleName = ObjmoduleName.ToString();

            if (ModuleCode.Length <= 8) // 顶级菜单项只显示菜单名称；
            {
                //if (moduleGuidLstALL.IndexOf(ModuleGuid.ToLower()) >= 0)
                //    return "<input type=\"checkbox\" name=\"" + ModuleGuid + "\" checked='checked' disabled='true' onclick=\"GetParentClick(this,'" + ModuleGuid + "')\" onpropertychange=\"javascript:AutoSetMValue(this," + "'" + ModuleGuid + "')\" />" + moduleName;

                if (moduleGuidLst.IndexOf(ModuleGuid.ToLower()) >= 0)
                    return "<input type=\"checkbox\" name=\"" + ModuleCode + "\" checked='checked' onclick=\"GetParentClick(this,'" + ModuleCode + "')\" onpropertychange=\"javascript:AutoSetMValue(this," + "'" + ModuleGuid + "')\" />" + moduleName;
                else
                    return "<input type=\"checkbox\" name=\"" + ModuleCode + "\" onclick=\"GetParentClick(this,'" + ModuleCode + "')\" onpropertychange=\"javascript:AutoSetMValue(this," + "'" + ModuleGuid + "')\" />" + moduleName;
            }
            else
            {
                //取得包括其所有的子模块
                string rtnHtml = "";
                DataView dvSub = Epoint.MisBizLogic2.DB.ExecuteDataView("select RowGuid,ModuleCode,ModuleName from RG_Module where substring(ModuleCode,1," + ModuleCode.Length + ")='" + ModuleCode + "' order by OrderNum desc");//db_fm.Select_Sub_Module(ModuleCode, moduleType);
                for (int i = 0; i < dvSub.Count; i++)
                {
                    //if (moduleGuidLstALL.IndexOf(ModuleGuid.ToLower()) >= 0)
                    //    rtnHtml += "<input type=\"checkbox\" name=\"" + dvSub[i]["ModuleCode"].ToString() + "\" checked='checked' disabled='true' onclick=\"GetParentClick(this,'" + dvSub[i]["ModuleCode"].ToString() + "')\" onpropertychange=\"javascript:AutoSetMValue(this," + "'" + dvSub[i]["ModuleGuid"].ToString() + "')\" />" + dvSub[i]["moduleName"].ToString();
                    //else
                    //{
                    if (moduleGuidLst.IndexOf(dvSub[i]["RowGuid"].ToString().ToLower()) >= 0)
                        rtnHtml += "<input type=\"checkbox\" name=\"" + dvSub[i]["ModuleCode"].ToString() + "\" checked='checked' onclick=\"GetParentClick(this,'" + dvSub[i]["ModuleCode"].ToString() + "')\" onpropertychange=\"javascript:AutoSetMValue(this," + "'" + dvSub[i]["RowGuid"].ToString() + "')\" />" + dvSub[i]["moduleName"].ToString();
                    else
                        rtnHtml += "<input type=\"checkbox\" name=\"" + dvSub[i]["ModuleCode"].ToString() + "\" onclick=\"GetParentClick(this,'" + dvSub[i]["ModuleCode"].ToString() + "')\" onpropertychange=\"javascript:AutoSetMValue(this," + "'" + dvSub[i]["RowGuid"].ToString() + "')\" />" + dvSub[i]["moduleName"].ToString();
                    //}
                }
                return rtnHtml;
            }
        }


        protected void savbtn_Click(object sender, EventArgs e)
        {
            //string AllowType = ViewState["AllowType"].ToString();
            string AllowTo = ViewState["AllowTo"].ToString();

            //删除此用户原有配置的所有的模块
            //ModuleRights.Delete_Type(AllowTo, AllowType);
            Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_Module_Right where AllowGuid='" + ViewState["AllowTo"].ToString() + "'and AllowType='OUType'");

            //返回的模块列表包含其他独立管理部门设置的模块
            string strSelectMoGuid = HidModuleGuid.Value;
            string[] moduleGuisLst = strSelectMoGuid.Split(';');
            string moduleGuid = "";
            for (int i = 0; i < moduleGuisLst.Length; i++)
            {
                moduleGuid = moduleGuisLst[i];
                if (moduleGuid != "")
                //ModuleRights.ModuleRight_Insert(moduleGuid, AllowTo, AllowType);
                {
                    string RowGuid = Guid.NewGuid().ToString();
                    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_Module_Right");
                    oRow["RowGuid"] = RowGuid;
                    oRow["ModuleGuid"] = moduleGuid;
                    oRow["AllowGuid"] = ViewState["AllowTo"];
                    oRow["AllowType"] = "OUType";
                    oRow.Insert();
                }
            }
            WriteAjaxMessage("alert('权限设置成功！');rtnValue('');");
        }

        //public void ShowAppModule(object sender, EventArgs e)
        //{
        //    if (chkshowAppModule.Checked)
        //        trAppModule.Style["display"] = "";
        //    else trAppModule.Style["display"] = "none";
        //}
    }
}
