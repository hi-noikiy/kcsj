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
using System.Collections.Generic;

namespace HTProject.Pages.RG_User
{
    public partial class Record_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Epoint.RegisterUser.Front.Bizlogic.UserMailandSMS.UserMail usermail = new Epoint.RegisterUser.Front.Bizlogic.UserMailandSMS.UserMail();

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
        Epoint.MisBizLogic2.Web.EditPage oEditPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                if (!oRow.R_HasFilled)
                {
                    btnEdit.Visible = false;
                    this.AlertAjaxMessage("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
                UserIdendity.Text = oRow["UserIdendity"].ToString();
                //BindRoleName();
                //InitUser();

                // 绑定单位类别
                //BindOuType();
                //添加上传文件的大小和类型检查
                this.Add_FileUploadCheck_Script();

                string strSql = " select top(1) EnterpriseName from rg_ouinfo where RowGuid='" + DanWeiGuid_2010.Text + "' order by row_id desc ";
                TxtDanWei.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);


            }
        }

        /// <summary>
        /// 绑定单位类别
        /// </summary>
        private void BindOuType()
        {
            string rguserguid = Epoint.Frame.Bizlogic.common.strReplaceSql(Request["RowGuid"]);
            string danweiguid = Epoint.Frame.Bizlogic.common.strReplaceSql(dpDanWeiGuid.SelectedValue);
            if (string.IsNullOrEmpty(danweiguid))
                danweiguid = Epoint.Frame.Bizlogic.common.strReplaceSql(DanWeiGuid_2010.Text);
            // 获得所属单位的单位类别
            DataView dvOuType = Epoint.MisBizLogic2.DB.ExecuteDataView("select OuType from RG_OuType_Relate where RelatedType='Ou' AND RelatedGuid='" + danweiguid + "'");
            DataView dvOuType1 = Epoint.MisBizLogic2.DB.ExecuteDataView("select OuType from RG_OuType_Relate where RelatedType='User' AND RelatedGuid='" + rguserguid + "'");

            List<string> lstOuType = new List<string>();
            foreach (DataRowView item in dvOuType1)
            {
                lstOuType.Add(item[0].ToString());
            }
            if (dvOuType.Count > 0)
            {
                Epoint.MisBizLogic2.Code.DB_CodeMain oCodeMain = new Epoint.MisBizLogic2.Code.DB_CodeMain();
                foreach (DataRowView item in dvOuType)
                {
                    ListItem li = new ListItem(oCodeMain.GetCodeText_FromHash("RG_会员单位", item[0].ToString()), item[0].ToString());
                    li.Selected = lstOuType.IndexOf(item[0].ToString()) >= 0;
                    cblOUType.Items.Add(li);
                }
            }
            else
            {
                //trOuType.Visible = false;
            }
        }


        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            base.OnInit(e);
        }


        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            //Boolean IsSendSuccess = usermail.sendMail("smtp.163.com", "zhuwb8719", "z721054587", "zhuwb8719@163.com", EMail_2010.Text, "测试注册邮箱是否有效……", "");
            //if (!IsSendSuccess)
            //{
            //    AlertAjaxMessage("注册邮箱无效，请确认！");
            //    return;
            //}
            //UserIdendity_2010.Text = UserIdendity.Text;
            Boolean UserExisted = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(RowGuid) from RG_User where LoginID='" + LoginID_2010.Text + "'") > 1;
            if (UserExisted)
            {
                AlertAjaxMessage("该登录名已被使用,请修改登录名！");
                return;
            }
            //if (UserType_2010.SelectedItem.Value == "002")
            //{
            //    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            //    Epoint.MisBizLogic2.Data.MisGuidRow arow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_OUInfo", oRow["DanWeiGuid"].ToString());
            //    arow["EnterpriseName"] = EnterpriseName.Text.Trim();
            //    arow["CodeCertificate"] = CodeCertificate.Text.Trim();
            //    // arow["EnterpriseType"] = EnterpriseType.Text.Trim();
            //    arow["LegalPerson"] = LegalPerson.Text.Trim();
            //    arow["RegionCharacter"] = RegionCharacter.Text.Trim();
            //    arow["BusinessLicenseNO"] = BusinessLicenseNO.Text.Trim();
            //    arow["Contacter"] = Contacter.Text.Trim();
            //    arow["Tel"] = Tel.Text.Trim();
            //    arow["ContacterID"] = ContacterID.Text.Trim();
            //    arow["Email"] = Email.Text.Trim();
            //    arow["Address"] = Address.Text.Trim();
            //    arow["RegistAddress"] = RegistAddress.Text.Trim();
            //    arow["AttachGuid"] = ((EpointNetoffice7.Ascx.CtlMisAttachments)AttachGuid).AttachGroupGuid;
            //    arow["BeiZhu"] = BeiZhu.Text.Trim();
            //    arow.Update();
            //    new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_OUInfo", "RowGuid", arow["RowGuid"].ToString());
            //    SaveOuType(oRow["DanWeiGuid"].ToString());
            //}
            //if (!string.IsNullOrEmpty(ApplyDanWeiGuid))
            //{
            //    DanWeiGuid_2010.Text = ApplyDanWeiGuid;
            //}
            //else
            //{
            //    DanWeiGuid_2010.Text = dpDanWeiGuid.SelectedValue;
            //}

            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);

            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            oRow["UserStatus"] = "002";
            oRow["DanWeiGuid"] = DanWeiGuid_2010.Text;
            oRow.Update();
            //new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_User", "RowGuid", Request["RowGuid"]);
           // new ComDataSyn().Syn(DataSynTarget.BackEndToFront, "RG_User", "RowGuid='" + Request["RowGuid"] + "'", "RowGuid");

            //SaveUserRole();

            //SaveOuTypeForUser(Request["RowGuid"]);

            //if (HidTag.Value == "0")
            //{
            //    this.AlertAjaxMessage("请分配对应角色！");
            //    return;
            //}
            //else
            this.WriteAjaxMessage("alert('修改成功');refreshParent();");
        }


        /// <summary>
        /// 保存单位类别
        /// </summary>
        


        /// <summary>
        /// 初始化信息
        /// </summary>
        //protected void InitUser()
        //{
        //    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);

        //    if (UserType_2010.SelectedItem.Value == "001")
        //    {
        //        // 如果RG_会员类别是个人会员，不需要显示所属单位和单位信息
        //        trOUInfo.Visible = false;
        //        trDanwei.Style["display"] = "none";
        //    }
        //    else if (UserType_2010.SelectedItem.Value == "002")
        //    {
        //        // 如果RG_会员类别是单位管理员，不需要显示所属单位
        //        trDanwei.Style["display"] = "none";

        //        Epoint.MisBizLogic2.Data.MisGuidRow arow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_OUInfo", oRow["DanWeiGuid"].ToString());
        //        EnterpriseName.Text = arow["EnterpriseName"].ToString();
        //        CodeCertificate.Text = arow["CodeCertificate"].ToString();
        //        LegalPerson.Text = arow["LegalPerson"].ToString();
        //        RegionCharacter.Text = arow["RegionCharacter"].ToString();
        //        BusinessLicenseNO.Text = arow["BusinessLicenseNO"].ToString();
        //        Contacter.Text = arow["Contacter"].ToString();
        //        Tel.Text = arow["Tel"].ToString();
        //        ContacterID.Text = arow["ContacterID"].ToString();
        //        Email.Text = arow["Email"].ToString();
        //        Address.Text = arow["Address"].ToString();
        //        RegistAddress.Text = arow["RegistAddress"].ToString();
        //        ((EpointNetoffice7.Ascx.CtlMisAttachments)AttachGuid).AttachGroupGuid = arow["AttachGuid"].ToString();
        //        BeiZhu.Text = arow["BeiZhu"].ToString();
        //        if (!string.IsNullOrEmpty(oRow["DanWeiGuid"].ToString()))
        //            BindOuType(oRow["DanWeiGuid"].ToString());
        //    }
        //    else if (UserType_2010.SelectedItem.Value == "003")
        //    {
        //        // 如果RG_会员类别是单位子账号，不需要显示单位信息，但是需要显示所属单位
        //        trOUInfo.Visible = false;
        //        // 绑定所属单位
        //        if (string.IsNullOrEmpty(ApplyDanWeiGuid))
        //        {
        //            // 绑定所属单位
        //            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select EnterpriseName, RowGuid from RG_OUInfo WHERE DelFlag=0");
        //            dpDanWeiGuid.DataSource = dv;
        //            dpDanWeiGuid.DataTextField = "EnterpriseName";
        //            dpDanWeiGuid.DataValueField = "RowGuid";
        //            dpDanWeiGuid.DataBind();
        //            dpDanWeiGuid.Items.Insert(0, new ListItem("", ""));
        //            dpDanWeiGuid.SelectedValue = DanWeiGuid_2010.Text;
        //        }
        //        else
        //        {
        //            DanWeiGuid_2010.Text = ApplyDanWeiGuid;
        //            trDanwei.Style["display"] = "none";
        //        }
        //    }
        //}

        ///// <summary>
        ///// 绑定角色
        ///// </summary>
        //protected void BindRoleName()
        //{
        //    DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select RoleName,RowGuid from RG_Role where UserType='" + UserType_2010.SelectedItem.Value + "'");
        //    if (dv.Count > 0)
        //    {
        //        jpdRoleName.DataSource = dv;
        //        jpdRoleName.DataTextField = "RoleName";
        //        jpdRoleName.DataValueField = "RowGuid";
        //        jpdRoleName.DataBind();
        //        string RowGuid = Request["RowGuid"];
        //        DataView dv2 = Epoint.MisBizLogic2.DB.ExecuteDataView("select RoleGuid from RG_User_Role where RGUserGUID='" + RowGuid + "'");
        //        foreach (DataRowView row in dv2)
        //        {
        //            foreach (ListItem item in jpdRoleName.Items)
        //            {
        //                if (Convert.ToString(row[0]) == item.Value)
        //                    item.Selected = true;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        trRoleList.Style["display"] = "none";
        //    }
        //}
        //protected void UserType_2010_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindRoleName();
        //    InitUser();
        //}

        //protected void dpDanWeiGuid_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindOuType();
        //}

        /// <summary>
        /// 初始化密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInitPwd_Click(object sender, EventArgs e)
        {
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_User", Request["RowGuid"]);
            if (oRow.R_HasFilled)
            {
                string pwd = LoginID_2010.Text;
                oRow["Password"] = common.authPassword(pwd);
                oRow.Update();
                AlertAjaxMessage("初始化密码成功，已初始化为您的登录帐号。");
                new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_User", "RowGuid", Request["RowGuid"]);

            }
        }
        /// <summary>
        /// 初始化EPass
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnInitEPwd_Click(object sender, EventArgs e)
        //{
        //    if (Epoint.MisBizLogic2.DB.Check_Item_Exist("RG_User", "UserKey='" + common.authPassword(PIN_2010.Value) + "' AND RowGuid<>'" + Request["RowGuid"] + "'"))
        //    {
        //        AlertAjaxMessage("此证书在本系统中已经被用过");
        //        return;
        //    }
        //    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_User", Request["RowGuid"]);
        //    if (oRow.R_HasFilled)
        //    {
        //        string pwd = PIN_2010.Value;
        //        oRow["UserKey"] = common.authPassword(pwd);
        //        oRow.Update();
        //        AlertAjaxMessage("初始化证书成功");
        //        new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_User", "RowGuid", Request["RowGuid"]);

        //    }
        //}
        /// <summary>
        /// 绑定单位类别
        /// </summary>
        //private void BindOuType(string ouGuid)
        //{
        //    DataView dvOuType = new Epoint.MisBizLogic2.Code.DB_CodeItem().Get_Items_By_CodeName("RG_会员单位");
        //    if (dvOuType.Count > 0)
        //    {
        //        OUType.DataTextField = "ItemText";
        //        OUType.DataValueField = "ItemValue";
        //        OUType.DataSource = dvOuType;
        //        OUType.DataBind();
        //    }
        //    DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("select * from RG_OuType_Relate where RelatedType='OU' and RelatedGuid='" + ouGuid + "'");
        //    foreach (DataRowView Row in dv)
        //        OUType.Items.FindByValue(Row["OuType"].ToString()).Selected = true;
        //}


        /// <summary>
        /// 保存单位类别
        /// </summary>
        //private void SaveOuType(string ouGuid)
        //{
        //    ouGuid = Epoint.Frame.Bizlogic.common.strReplaceSql(ouGuid);
        //    foreach (ListItem item in OUType.Items)
        //    {
        //        Boolean IsExisted = Epoint.MisBizLogic2.DB.ExecuteToInt("select count(*) from RG_OuType_Relate where RelatedGuid='" + ouGuid + "'and OuType='" + item.Value + "'and RelatedType='Ou'") > 0;
        //        if (item.Selected)
        //        {
        //            if (!IsExisted)
        //            {
        //                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_OuType_Relate");
        //                oRow["RelatedGuid"] = ouGuid;
        //                oRow["OuType"] = item.Value;
        //                oRow["RelatedType"] = "Ou";
        //                oRow["RowGuid"] = Guid.NewGuid().ToString();
        //                oRow.Insert();
        //                new ComDataSyn().InsertWithKeyValue(DataSynTarget.BackEndToFront, "RG_OuType_Relate", "RowGuid", oRow["RowGuid"].ToString());
        //            }
        //        }
        //        else
        //        {
        //            if (IsExisted)
        //            {
        //                new ComDataSyn().DeleteWithCondition(DataSynTarget.BackEndToFront, "RG_OuType_Relate", "RelatedGuid='" + ouGuid + "'and OuType='" + item.Value + "'and RelatedType='Ou'", "RowGuid");
        //                Epoint.MisBizLogic2.DB.ExecuteNonQuery("delete from RG_OuType_Relate where RelatedGuid='" + ouGuid + "'and OuType='" + item.Value + "'and RelatedType='Ou'");
        //            }
        //        }
        //    }
        //}
    }
}
