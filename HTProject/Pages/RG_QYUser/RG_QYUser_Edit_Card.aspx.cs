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
using Epoint.Frame.Common;
using HTProject_Bizlogic;
namespace HTProject.Pages.RG_QYUser
{

    public partial class RG_QYUser_Edit_Card : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 2019;
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        Epoint.MisBizLogic2.Web.EditPage oEditPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                #region 判断是否是辅表，如果是辅表，并且没有父表的RowID，自动转到相应的主表
                string ParentRowGuid = Request.QueryString["ParentRowGuid"];
                //if (oAddPage.TableDetail.TableType == 2)
                //{
                //    if (ParentRowGuid == null || ParentRowGuid == "")
                //    {
                //        this.AlertAjaxMessage("禁止直接对子表添加记录！");
                //        return;
                //    }
                //}
                #endregion
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
                //添加上传文件的大小和类型检查
                this.Add_FileUploadCheck_Script();

                //image_View.InnerHtml = "<IMG style=\"HEIGHT: 126px\" SRC='GetUserImageByte.aspx?RowGuid=" + Request["RowGuid"] + "'>";
                RY_SFZ.ClientGuid = Request["RowGuid"] + "RY_SFZ";
                RY_SFZ.NodeCode = DWGuid_2019.Text;
                RY_SFZ.MisRowGuid = Request["RowGuid"];

                RY_BYZ.ClientGuid = Request["RowGuid"] + "RY_BYZ";
                RY_BYZ.NodeCode = DWGuid_2019.Text;
                RY_BYZ.MisRowGuid = Request["RowGuid"];

                RY_ZCZJ.ClientGuid = Request["RowGuid"] + "RY_ZCZJ";
                RY_ZCZJ.NodeCode = DWGuid_2019.Text;
                RY_ZCZJ.MisRowGuid = Request["RowGuid"];

                RY_ZhiCheng.ClientGuid = Request["RowGuid"] + "RY_ZhiCheng";
                RY_ZhiCheng.NodeCode = DWGuid_2019.Text;
                RY_ZhiCheng.MisRowGuid = Request["RowGuid"];

                RY_LDHT.ClientGuid = Request["RowGuid"] + "RY_LDHT";
                RY_LDHT.NodeCode = DWGuid_2019.Text;
                RY_LDHT.MisRowGuid = Request["RowGuid"];

                RY_GRQT.ClientGuid = Request["RowGuid"] + "RY_GRQT";
                RY_GRQT.NodeCode = DWGuid_2019.Text;
                RY_GRQT.MisRowGuid = Request["RowGuid"];

                RY_GRQM.ClientGuid = Request["RowGuid"] + "RY_GRQM";
                RY_GRQM.NodeCode = DWGuid_2019.Text;
                RY_GRQM.MisRowGuid = Request["RowGuid"];


                RegionTreeView.Text = ZhuanYeCS_2019.Text;
                RegionTreeView.Value = ZhuanYeCSCode_2019.Text;

            }
        }


        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            base.OnInit(e);
        }


        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            string RowGuid = Request["RowGuid"];
            if (cardJPG.Text != "")
            {
                //CardIMG_2019.Text = Convert.FromBase64String(cardJPG.Text).ToString();
                CardImgType_2019.Text = "image/pjpeg";                
            }
            //else
            //{
            //    this.WriteAjaxMessage("alert('抱歉！请重新点击[读卡]读取照片后[保存]！');");
            //    return;
            //}
            //判断下身份证s是否已经有了
            string oName = "";
            if (RG_DW.IsExistByIDNO(IDNum_2019.Text.Trim(), out oName, Request["RowGuid"]))
            {
                this.WriteAjaxMessage("alert('该身份证已经存在，姓名为：" + oName + "');");
                return;
            }
            
            DWGuid_2019.Text = Request["DWGuid"];
            DelStatus_2019.SelectedValue = "0";
            Status_2019.Text = "85";
            string strSql = "select ZuZhiJGDM from RG_OUInfo where RowGuid='" + Request["DWGuid"] + "'";
            ZuZhiJGDM_2019.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            if (cardJPG.Text != "")
            {
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                //strSql = "UPDATE RG_QYUser SET CardIMG='" + Convert.FromBase64String(cardJPG.Text) + "' where RowGuid='" + RowGuid + "'";
                //Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);
                oRow["CardIMG"] = Convert.FromBase64String(cardJPG.Text);
                oRow.Update();
            }
            this.WriteAjaxMessage("alert('保存成功');refreshParent();window.close();");
            
        }

        protected void btID_Click(object sender, System.EventArgs e)
        {
            string oName = "";
            if (RG_DW.IsExistByIDNO(IDNum_2019.Text.Trim(), out oName,Request["RowGuid"]))
            {
                IDNum_2019.Text = "";
                this.WriteAjaxMessage("alert('该身份证已经存在，姓名为：" + oName + "');");
                return;
            }
        }

    }
}


