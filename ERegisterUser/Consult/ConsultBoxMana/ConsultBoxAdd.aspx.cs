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
using Epoint.RegisterUser.Bizlogic.Consult;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace EpointRegisterUser.Consult.ConsultBoxMana
{
    public partial class ConsultBoxAdd : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Db_ConsultBoxMana BoxMana = new Db_ConsultBoxMana();
        Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom StorgCom = new Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                JpdGroup.DataSource = BoxMana.BoxGroupSelectAll();
                JpdGroup.DataTextField = "BoxGroupName";
                JpdGroup.DataValueField = "BoxGroupID";
                JpdGroup.DataBind();
                JpdGroup.Items.Insert(0, new ListItem("请选择所属组别", "未分配组别"));

                if (Request.QueryString["BoxGuid"] != "" && Request.QueryString["BoxGuid"] != null)
                {
                    this.CurrentPosition = "信箱修改";
                    this.Title = "信箱修改";
                    btnAddClose.Text = "保存修改";
                    btnCancel.Text = "取消修改";
                    btnAdd.Visible = false;
                    Detail_RG_ConsultBox BoxDetial = BoxMana.GetDetail(Request.QueryString["BoxGuid"]);
                    txtTitle.Text = BoxDetial.BoxName;
                    txtDesc.Text = BoxDetial.Description;
                    txtOrderNum.Text = BoxDetial.OrderNum.ToString();
                    Check_Audit.Checked = (BoxDetial.NeedAudit == 1 ? true : false);
                    try
                    {
                        JpdGroup.Items.FindByValue(BoxDetial.BoxGroupID).Selected = true;
                    }
                    catch
                    {
                    }

                    DataView dvup;
                    if (new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("ConsultMainSite").ConfigValue == "1")
                    {
                        dvup = new Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom().Select(Request.QueryString["BoxGuid"]);
                    }
                    else
                    {
                        dvup = StorgCom.Select(Request.QueryString["BoxGuid"]);
                    }
                    if (dvup.Count > 0)
                        spanimg.InnerHtml = "<a target=\"_blank\"  href='ReadAttachFile.aspx?AttachID=" + dvup[0]["AttachID"] + "'> <font color=\"red\">" + dvup[0]["filename"] + "</font></a>";
                }
                else
                {
                    this.CurrentPosition = "信箱添加";
                }
            }

        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="parentOuGuid"></param>
        /// <returns></returns>
        private string AddDqestion()
        {
            int OrderNum = 0;
            try
            {
                OrderNum = Convert.ToInt32(txtOrderNum.Text);
            }
            catch { }

            int HandleDays = 1000;
            try
            {
                HandleDays = Convert.ToInt32(txtHandleDays.Text);
            }
            catch { }

            int IsNeedCheck = 0;
            if (Check_Audit.Checked)
                IsNeedCheck = 1;
            if (JpdGroup.SelectedIndex != 0)
            {
                if (Request.QueryString["BoxGuid"] != "" && Request.QueryString["BoxGuid"] != null)
                {//修改信息
                    BoxMana.BoxUpdate(Request.QueryString["BoxGuid"], txtTitle.Text, txtDesc.Text, JpdGroup.SelectedValue, OrderNum, HandleDays, IsNeedCheck);
                    AddAttach(Request.QueryString["BoxGuid"]);//添加附件
                }
                else//添加信息
                {
                    string newguid = Guid.NewGuid().ToString();
                    BoxMana.BoxInsert(newguid, txtTitle.Text, txtDesc.Text, JpdGroup.SelectedValue, OrderNum, HandleDays, IsNeedCheck);
                    AddAttach(newguid);//添加附件
                }
                return "";
            }
            else
            {
                return "Null";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string scriptStr = "";
            if (AddDqestion() == "Null")
            {
                scriptStr = "所属组别必须选择！";
            }
            else
            {

                #region 继续添加选中则不关闭添加页面；
                scriptStr = "★";
                txtDesc.Text = "";
                txtOrderNum.Text = "";
                txtTitle.Text = "";
                #endregion
            }
            WriteScript("rtnValue(\"" + scriptStr + "\")");
        }


        /// <summary>
        /// 保存并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddClose_Click(object sender, EventArgs e)
        {
            string scriptStr = "";
            if (AddDqestion() == "Null")
            {
                scriptStr = "所属组别必须选择！";
            }
            WriteScript("rtnValue(\"" + scriptStr + "\")");
        }


        public void AddAttach(string InfoID)
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            HttpPostedFile upFileName;
            //循环插入记录
            for (int i = 0; i < files.Count; i++)
            {
                upFileName = files[i];
                if (upFileName.ContentLength > 0)
                {
                    string[] filesplit = upFileName.FileName.Split('\\');//分析文件名称
                    string filename = filesplit[filesplit.Length - 1];
                    string contentType = files[i].ContentType;
                    string length = files[i].ContentLength.ToString();
                    byte[] fileContent = new byte[upFileName.ContentLength];
                    upFileName.InputStream.Read(fileContent, 0, upFileName.ContentLength);

                    Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom MainDBUpfiles = new Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom();

                    //添加附件信息
                    //string newguid = Guid.NewGuid().ToString();
                    MainDBUpfiles.Delete(InfoID);
                    MainDBUpfiles.Insert(
                        Guid.NewGuid().ToString(),
                    filename,
                    contentType,
                    "",
                    "RG_Consult",
                    InfoID,
                    "",
                    Convert.ToInt32(length),
                    fileContent
                    );

                    upFileName.InputStream.Close();
                }
            }
        }
    }
}
