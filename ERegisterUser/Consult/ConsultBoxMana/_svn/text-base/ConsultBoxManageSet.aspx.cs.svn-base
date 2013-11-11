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
using Infragistics.WebUI.UltraWebTab;
using Epoint.RegisterUser.Bizlogic.Consult;
using Epoint.Frame.Bizlogic.UserManage;

namespace EpointRegisterUser.Consult.ConsultBoxMana
{
    public partial class ConsultBoxManageSet : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster 
    {
        Db_ConsultBoxMana BoxRight = new Db_ConsultBoxMana();
        User users = new User();
        OU depts = new OU();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               this.CurrentPosition = "权限设置";
               BindList();
            }
        }

        protected void BindList()
        {
            string BoxGuid = Request.QueryString["BoxGuid"];
            DataView dvBoxRight = BoxRight.SelectHandleUser(BoxGuid);
            dvBoxRight.RowFilter = "HandleType='P'";//人员
            lstUser.Items.Clear();
            string UserGuid = "";
            string UserName = "";
            string UserGuidList = "";
            for (int i = 0; i < dvBoxRight.Count; i++)
            {
                UserGuid = dvBoxRight[i]["HandleDetail"].ToString();
                UserName = users.GetDetailByUserGuid(UserGuid).DisplayName;
                lstUser.Items.Add(new ListItem(UserName,UserGuid));
                UserGuidList += UserGuid + "★";
            }
            HidUserList.Value = UserGuidList;

            dvBoxRight.RowFilter = "HandleType='D'";//部门
            lstOu.Items.Clear();
            string DeptGuid = "";
            string DeptName = "";
            string DeptGuidList = "";
            for (int i = 0; i < dvBoxRight.Count; i++)
            {
                DeptGuid = dvBoxRight[i]["HandleDetail"].ToString();
                DeptName = depts.GetDetail(DeptGuid).OUName;
                lstOu.Items.Add(new ListItem(DeptName, DeptGuid));
                DeptGuidList += DeptGuid + "★";
            }
            HidOuList.Value = DeptGuidList;
                
        }
        protected void btnAddClose_Click(object sender, EventArgs e)
        {
            string BoxGuid = Request.QueryString["BoxGuid"];
            BoxRight.DeleteHandleUser(BoxGuid);//先删除所有的权限

            string[] ListOu = HidOuList.Value.Split('★');
            for (int i = 0; i < ListOu.Length; i++)
            {
                if(ListOu[i]!="")
                    BoxRight.InsertHandleUser(BoxGuid, "D", ListOu[i]);
            }

            string[] ListUser = HidUserList.Value.Split('★');
            for (int i = 0; i < ListUser.Length; i++)
            {
                if(ListUser[i]!="")
                    BoxRight.InsertHandleUser(BoxGuid, "P", ListUser[i]);
            }
            WriteScript("rtnValue(\"\")");
        }
    }
}
