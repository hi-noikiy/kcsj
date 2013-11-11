using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Specialized;
using Epoint.Web.UI.WebControls2X;
using Epoint.Frame.Bizlogic;
using Epoint.RegisterUser.DataSyn.Bizlogic;
using System.Net.Sockets;
using System.IO;
namespace HTProject.Pages.RG_User
{
    public partial class Record_Add : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Epoint.RegisterUser.Front.Bizlogic.UserMailandSMS.UserMail usermail = new Epoint.RegisterUser.Front.Bizlogic.UserMailandSMS.UserMail();
        Epoint.RegisterUser.Front.Bizlogic.RegisterModule.RegisterModule rgModule = new Epoint.RegisterUser.Front.Bizlogic.RegisterModule.RegisterModule();

        /// <summary>
        /// 申请的会员所属单位的GUid
        /// </summary>
        public string ApplyDanWeiGuid
        {
            get
            {
                return Request["DanWeiGuid"];
            }
        }
        public int TableID = 2010;
        Epoint.MisBizLogic2.Web.AddPage oAddPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oAddPage.TableDetail.TableName;
                #region 判断是否是辅表，如果是辅表，并且没有父表的RowID，自动转到相应的主表
                string ParentRowGuid = Request.QueryString["ParentRowGuid"];
                if (oAddPage.TableDetail.TableType == 2)
                {
                    if (ParentRowGuid == null || ParentRowGuid == "")
                    {
                        this.AlertAjaxMessage("禁止直接对子表添加记录！");
                        return;
                    }
                }
                #endregion
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
                //添加上传文件的大小和类型检查
                this.Add_FileUploadCheck_Script();
                //BindRoleName();
                //InitUser();
                //if (!string.IsNullOrEmpty(ApplyDanWeiGuid))
                //{
                //    BindOuType(ApplyDanWeiGuid);
                //}
                //else
                //    BindOuType(dpDanWeiGuid.SelectedValue);
                //UserType_2010.Attributes.Add("onchange", "if(!confirm('确定要修改类型吗？')){this.selectedIndex=" + UserType_2010.SelectedIndex + "; return false;}");
            }
        }

        /// <summary>
        /// 绑定单位的单位类别
        /// </summary>
        private void BindOuType()
        {
            if (UserType_2010.SelectedItem.Value == "002")
            {
                DataView dvOuType = new Epoint.MisBizLogic2.Code.DB_CodeItem().Get_Items_By_CodeName("RG_会员单位");
                if (dvOuType.Count > 0)
                {
                    cblOUTypeOU.DataTextField = "ItemText";
                    cblOUTypeOU.DataValueField = "ItemValue";
                    cblOUTypeOU.DataSource = dvOuType;
                    cblOUTypeOU.DataBind();
                }
            }
        }
        /// <summary>
        /// 保存单位的单位类别
        /// </summary>
        private void SaveOuType(string ouGuid)
        {
            foreach (ListItem item in cblOUTypeOU.Items)
            {
                if (item.Selected)
                {
                    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_OuType_Relate");
                    oRow["RelatedGuid"] = ouGuid;
                    oRow["OuType"] = item.Value;
                    oRow["RelatedType"] = "Ou";
                    oRow["RowGuid"] = Guid.NewGuid().ToString();
                    oRow.Insert();
                    //new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_OuType_Relate", "RowGuid", oRow["RowGuid"].ToString());
                }
            }
            new ComDataSyn().InsertWithCondition(DataSynTarget.BackEndToFront, "RG_OuType_Relate", "RelatedGuid='" + ouGuid + "'", "RowGuid");
        }
        /// <summary>
        /// 绑定会员的单位类别
        /// </summary>
        private void BindOuType(string danweiguid)
        {
            // 获得所属单位的单位类别
            DataView dvOuType = Epoint.MisBizLogic2.DB.ExecuteDataView("select OuType from RG_OuType_Relate where RelatedType='Ou' AND RelatedGuid='" + danweiguid + "'");
            if (dvOuType.Count > 0)
            {
                Epoint.MisBizLogic2.Code.DB_CodeMain oCodeMain = new Epoint.MisBizLogic2.Code.DB_CodeMain();
                foreach (DataRowView item in dvOuType)
                {
                    cblOUType.Items.Add(new ListItem(oCodeMain.GetCodeText_FromHash("RG_会员单位", item[0].ToString()), item[0].ToString()));
                }
            }
        }
        /// <summary>
        /// 保存会员的单位类别
        /// </summary>
        private void SaveOuTypeForUser(string rgUserGuid)
        {
            foreach (ListItem item in cblOUType.Items)
            {
                if (item.Selected)
                {
                    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_OuType_Relate");
                    oRow["RelatedGuid"] = rgUserGuid;
                    oRow["OuType"] = item.Value;
                    oRow["RelatedType"] = "User";
                    oRow["RowGuid"] = Guid.NewGuid().ToString();
                    oRow.Insert();
                    //new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_OuType_Relate", "RowGuid", oRow["RowGuid"].ToString());
                }
            }
            new ComDataSyn().InsertWithCondition(DataSynTarget.BackEndToFront, "RG_OuType_Relate", "RelatedGuid='" + rgUserGuid + "'", "RowGuid");
        }

        override protected void OnInit(EventArgs e)
        {
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);
            base.OnInit(e);
        }



        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            //string ServerIP = System.Configuration.ConfigurationManager.AppSettings["ServerIP"].ToString();
            //string SmtpServer = System.Configuration.ConfigurationManager.AppSettings["SmtpServer"].ToString();
            //string EmailFrom = System.Configuration.ConfigurationManager.AppSettings["EmailFrom"].ToString();
            //string EmailAccount = System.Configuration.ConfigurationManager.AppSettings["EmailAccount"].ToString();
            //string EmailPassword = System.Configuration.ConfigurationManager.AppSettings["EmailPassword"].ToString();

            //Boolean IsSendSuccess = usermail.sendMail(SmtpServer, EmailAccount, EmailPassword, EmailFrom, EMail_2010.Text, "测试邮件地址是否有效。", "Test……");
            //if (!IsSendSuccess)
            //{
            //    AlertAjaxMessage("您填写的邮件地址无效，请确认！");
            //    return;
            //}
            UserIdendity_2010.Text = UserIdendity.Text;
            if (!string.IsNullOrEmpty(PIN_2010.Value))
            {
                if (Epoint.MisBizLogic2.DB.Check_Item_Exist("RG_User", "UserKey='" + common.authPassword(PIN_2010.Value) + "'"))
                {
                    AlertAjaxMessage("此证书在本系统中已经被用过");
                    return;
                }
                else
                {
                    UserKey_2010.Text = common.authPassword(PIN_2010.Value);
                }
            }

            if (string.IsNullOrEmpty(UserKey_2010.Text))
            {
                // 初始化密码
                Password_2010.Text = common.authPassword("11111");
            }
            Boolean UserExisted = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(RowGuid) from RG_User where LoginID='" + LoginID_2010.Text + "' and DelFlag=0") > 0;
            if (UserExisted)
            {
                AlertAjaxMessage("该登录名已被使用,请更换登录名！");
                return;
            }
            string RowGuid = Guid.NewGuid().ToString();
            //if (!string.IsNullOrEmpty(ApplyDanWeiGuid))
            //{
            //    DanWeiGuid_2010.Text = ApplyDanWeiGuid;
            //}
            //else
            //    if (UserType_2010.SelectedItem.Value == "002")
            //    {
            //        Epoint.MisBizLogic2.Data.MisGuidRow arow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_OUInfo");
            //        arow["RowGuid"] = Guid.NewGuid().ToString();
            //        arow["EnterpriseName"] = EnterpriseName.Text.Trim();
            //        arow["CodeCertificate"] = CodeCertificate.Text.Trim();
            //        arow["LegalPerson"] = LegalPerson.Text.Trim();
            //        arow["RegionCharacter"] = RegionCharacter.Text.Trim();
            //        arow["BusinessLicenseNO"] = BusinessLicenseNO.Text.Trim();
            //        arow["Contacter"] = Contacter.Text.Trim();
            //        arow["Tel"] = Tel.Text.Trim();
            //        arow["ContacterID"] = ContacterID.Text.Trim();
            //        arow["Email"] = Email.Text.Trim();
            //        arow["Address"] = Address.Text.Trim();
            //        arow["RegistAddress"] = RegistAddress.Text.Trim();
            //        //EpointNetoffice7.Ascx.CtlAttachments Att = new EpointNetoffice7.Ascx.CtlAttachments();

            //        //arow["AttachGuid"] = ((EpointNetoffice7.Ascx.CtlMisAttachments)AttachGuid).AttachGroupGuid;
            //        arow["BeiZhu"] = BeiZhu.Text.Trim();
            //        arow["DelFlag"] = "0";
            //        arow.Insert();
            //        new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_OUInfo", "RowGuid", arow["RowGuid"].ToString());
            //        DanWeiGuid_2010.Text = arow["RowGuid"].ToString();
            //        SaveOuType(arow["RowGuid"].ToString());
            //    }
            //else
            //{
            //    DanWeiGuid_2010.Text = dpDanWeiGuid.SelectedValue;
            //}
            //if (UserType_2010.SelectedValue != "001")
            //    SaveOuTypeForUser(RowGuid);
            DelFlag_2010.Text = "0";
            oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);
            //new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_User", "RowGuid", RowGuid);
            //if (!string.IsNullOrEmpty(DanWeiGuid_2010.Text))
            //{
            //    DataView dvApp = rgModule.GetAppForSyn(DanWeiGuid_2010.Text);
            //    if (dvApp.Count > 0)
            //    {
            //        foreach (DataRowView row in dvApp)
            //        {
            //            new ComDataSyn().InsertWithKeyValue(row["SynTargetAddr"].ToString(), "RG_User", "RowGuid", RowGuid);
            //        }
            //    }
            //}
            //SaveUserRole(RowGuid);

            //如果是父表，要转入多表编辑页面
            if (oAddPage.TableDetail.TableType == 1)
            {
                Response.Redirect("MultiPageTab.aspx?mode=Mode&TableID=了" + oAddPage.TableDetail.TableID + "&RowGuid=" + RowGuid);
            }
            Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oAddPage.TableDetail.SQL_TableName, RowGuid);
            oRow["UserStatus"] = "002";
            //oRow["DanWeiGuid"] = DanWeiGuid_2010.Text;
            oRow.Update();
            string url = "Record_Edit.aspx?RowGuid=" + RowGuid ;
            this.WriteAjaxMessage("refreshParent();alert('添加成功');window.location.href='" + url + "';");
        }

        /// <summary>
        /// 保存会员角色信息
        /// </summary>
        protected void SaveUserRole(string rowguid)
        {
            // 添加现有角色信息
            foreach (ListItem item in jpdRoleName.Items)
            {
                if (item.Selected)
                {
                    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_User_Role");
                    oRow["RGUserGUID"] = rowguid;
                    oRow["RoleGuid"] = item.Value;
                    oRow["RowGuid"] = Guid.NewGuid().ToString();
                    oRow.Insert();
                }
            }
            new ComDataSyn().InsertWithCondition(DataSynTarget.BackEndToFront, "RG_User_Role", "RGUserGUID='" + rowguid + "'", "RowGuid");

        }

        /// <summary>
        /// 初始化信息
        /// </summary>
        protected void InitUser()
        {
            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["EnableChart"]))
                EnableOnlineChat_2010.SelectedIndex = EnableOnlineChat_2010.Items.IndexOf(EnableOnlineChat_2010.Items.FindByValue(System.Configuration.ConfigurationManager.AppSettings["EnableChart"]));
            else
                EnableOnlineChat_2010.SelectedIndex = EnableOnlineChat_2010.Items.IndexOf(EnableOnlineChat_2010.Items.FindByValue("0"));
            if (UserType_2010.SelectedItem.Value == "001")
            {
                // 如果RG_会员类别是个人会员，不需要显示所属单位和单位信息
                trOUInfo.Visible = false;
                trDanwei.Style["display"] = "none";
                trOuType.Style["display"] = "none";
            }
            else if (UserType_2010.SelectedItem.Value == "002")
            {
                // 如果RG_会员类别是单位管理员，不需要显示所属单位
                trOUInfo.Visible = true;
                trOuType.Style["display"] = "";
                trDanwei.Style["display"] = "none";
                // 如果已经存在单位，不需要显示单位信息
                if (!string.IsNullOrEmpty(ApplyDanWeiGuid))
                { trOUInfo.Visible = false; }
            }
            else if (UserType_2010.SelectedItem.Value == "003")
            {
                // 如果RG_会员类别是单位子账号，不需要显示单位信息，但是需要显示所属单位
                trOUInfo.Visible = false;
                trOuType.Style["display"] = "";
                trDanwei.Style["display"] = "";
                // 绑定所属单位
                if (string.IsNullOrEmpty(ApplyDanWeiGuid))
                {
                    DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select EnterpriseName, RowGuid from RG_OUInfo WHERE DelFlag=0");
                    dpDanWeiGuid.DataSource = dv;
                    dpDanWeiGuid.DataTextField = "EnterpriseName";
                    dpDanWeiGuid.DataValueField = "RowGuid";
                    dpDanWeiGuid.DataBind();
                    dpDanWeiGuid.Items.Insert(0, new ListItem("", ""));
                }
                else
                {
                    DanWeiGuid_2010.Text = ApplyDanWeiGuid;
                    trDanwei.Style["display"] = "none";
                }
            }
        }

        /// <summary>
        /// 绑定所属的
        /// </summary>
        protected void BindRoleName()
        {
            if (!string.IsNullOrEmpty(ApplyDanWeiGuid))
            {
                // 根据是否存在单位管理员，确定是要否申请单位子账号
                bool isExistsAdmin = Epoint.MisBizLogic2.DB.Check_Item_Exist("RG_User", " DelFlag=0 AND UserType='002' AND DanWeiGuid='" + Epoint.Frame.Bizlogic.common.strReplaceSql(ApplyDanWeiGuid) + "'");
                if (!isExistsAdmin)
                {
                    // 还没有单位管理员
                    UserType_2010.SelectedValue = "002";
                    AlertAjaxMessage("还没有添加单位管理员，当前用户将保存为单位管理员。");
                }
                else
                {
                    UserType_2010.SelectedValue = "003";
                }
                trUserType.Style["display"] = "none";
            }
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select RoleName,RowGuid from RG_Role where UserType='" + UserType_2010.SelectedItem.Value + "'");
            jpdRoleName.DataSource = dv;
            if (dv.Count > 0)
            {
                jpdRoleName.DataTextField = "RoleName";
                jpdRoleName.DataValueField = "RowGuid";
                jpdRoleName.DataBind();
                trRoleList.Style["display"] = "";
            }
            else
            {
                trRoleList.Style["display"] = "none";
            }
        }

        protected void UserType_2010_SelectedIndexChanged(object sender, EventArgs e)
        {
            cblOUType.Items.Clear();
            BindRoleName();
            InitUser();
            BindOuType();
        }

        protected void dpDanWeiGuid_SelectedIndexChanged(object sender, EventArgs e)
        {
            cblOUType.Items.Clear();
            BindOuType(dpDanWeiGuid.SelectedValue);
        }
    }
}


