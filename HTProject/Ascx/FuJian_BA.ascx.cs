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
using System.IO;

namespace HTProject.Ascx
{
    public partial class FuJian_BA : System.Web.UI.UserControl
    {
         
        /// <summary>
        /// 附件所属的应用名称，如：DBMail\WebInfo\ZtbMis
        /// </summary>
        public string ClientTag
        {
            get { return Convert.ToString(ViewState[this.ID + "ClientTag"]); }
            set { ViewState[this.ID + "ClientTag"] = value; }
        }

        private string _Status;

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _SAdd;

        public string SAdd
        {
            get { return _SAdd; }
            set { _SAdd = value; }
        }
        

        public string MisRowGuid
        {
            get { return Convert.ToString(ViewState[this.ID + "MisRowGuid"]); }
            set { ViewState[this.ID + "MisRowGuid"] = value; }
        }
      
        /// <summary>
        /// 附件所属的原始数据库记录Ｇｕｉｄ
        /// </summary>
        public string ClientGuid
        {
            get { return ViewState[this.ID + "ClientGuid"].ToString(); }
            set
            {
                if (Convert.ToString(ViewState[this.ID + "ClientGuid"]) != value && value != "")
                {
                    //更新附件库中对应记录的ClientGuid为新的Guid
                    if (ViewState[this.ID + "ClientGuid"] != null && Convert.ToString( ViewState[this.ID + "ClientGuid"]) != "")
                    {
                        Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom StorgCom = new Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom();
                        StorgCom.UpdateClientGuid(Convert.ToString(ViewState[this.ID + "ClientGuid"]), value);
                    }
                    ViewState[this.ID + "ClientGuid"] = value;
                }
            }
        }

        
        public string NodeCode
        {
            set
            {
                ViewState[this.ID + "NodeCode"] = value;
            }
        }

        /// <summary>
        /// 允许上传的最大附件个数
        /// </summary>
        public int MaxAttachCount
        {
            get { return Convert.ToInt32 (ViewState[this.ID + "MaxAttachCount"]); }
            set { ViewState[this.ID + "MaxAttachCount"] = value; }
        }

        public bool ReadOnly
        {
            set
            {
                ViewState[this.ID + "ReadOnly"] = value;
                //this.SetReadOnly();
            }
            get
            {
                if (ViewState[this.ID + "ReadOnly"] == null)
                    return false;
                else
                    return (bool)ViewState[this.ID + "ReadOnly"];
            }
        }


        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!this.ReadOnly)
                {
                    if (ViewState[this.ID + "NodeCode"]!=null)
                    {
                        drpAttachType.Visible = true;
                        this.InitDrpAttachType(ViewState[this.ID + "NodeCode"].ToString());
                    }
                    else
                    {
                        drpAttachType.Visible = false;
                    }
                    string sID = this.ID;
                }
                this.InitDrpAttachType(ViewState[this.ID + "NodeCode"].ToString());
                this.BindAttach();
                SetReadOnly();
            }
        }

        private void SetReadOnly()
        {
            if (this.ReadOnly)
            {
                dgAttachment.Columns[3].Visible = false;
                trAdd.Visible = false;
                trRemark.Visible = false;
            }
            else
            {
                dgAttachment.Columns[3].Visible = true;
                trAdd.Visible = true;
                trRemark.Visible = true;
            }

        }

        private void BindAttach()
        {
            Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom StorgCom = new Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom();
            string CliGuid = Convert.ToString(ViewState[this.ID + "ClientGuid"]);
            if (CliGuid == "")
            {
                CliGuid = Guid.NewGuid().ToString();
            }
            //DataView dvAttch = StorgCom.Select(Convert.ToString(ViewState[this.ID + "ClientGuid"]));
            DataView dvAttch = StorgCom.Select(CliGuid);
            dgAttachment.DataSource = dvAttch;
            dgAttachment.DataBind();           

            //超过附件个数，禁止上传
            if (dvAttch.Count >= MaxAttachCount  && MaxAttachCount>0)
            {
                trAdd.Visible = false;
                trRemark.Visible = false;
            }
            else
            {
                trAdd.Visible = true;
                trRemark.Visible = true;
            }

            if (dvAttch.Count == 0 && this.ReadOnly)
            {
                //tabMain.Visible = false;
                dgAttachment.Visible = false;
                labMsg.Text = "无附件";
                labMsg.Visible = true;
                
            }
            else
            {
                
                if (this.ReadOnly)
                {
                    trAdd.Visible = false;
                    trRemark.Visible = false;
                }
                labMsg.Visible = false;
            }
            
        }

      

        public string getAttachInfo(object AttachGuid, object AttachFileName,object ContentType)
        {
            string rtnHtml = "";
            if (ContentType.ToString().IndexOf("image") > -1)
            {
                rtnHtml = "<a   target='_blank'  href='" + Epoint.Frame.Bizlogic.common.GetApplicationPath() + "HTProject/Ascx/RetrieveImageData.aspx?AttachGuid=" + AttachGuid + "'> <font color=\"red\">" + AttachFileName.ToString() + "</font></a>";//target=\"_blank\"
            }
            else
            {
                if (_Status == "90")//加盖公章
                {
                    rtnHtml = "<a   target='_blank'  href='" + Epoint.Frame.Bizlogic.common.GetApplicationPath() + "HTProject/Ascx/ReadAttachFileWithZhang.aspx?AttachGuid=" + AttachGuid + "&SAdd=" + _SAdd + "'> <font color=\"red\">" + AttachFileName.ToString() + "</font></a>";//target=\"_blank\"
                }
                else
                {
                    rtnHtml = "<a   target='_blank'  href='" + Epoint.Frame.Bizlogic.common.GetApplicationPath() + "HTProject/Ascx/ReadAttachFile.aspx?AttachGuid=" + AttachGuid + "'> <font color=\"red\">" + AttachFileName.ToString() + "</font></a>";//target=\"_blank\"
                }
            }
            return rtnHtml;
        }


        protected void cmdAttach_Click(object sender, System.EventArgs e)
        {
            Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom StorgCom = new Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom();

            //string strFileName = "";
            //string strFName = "";   //不带路径的文件名
            //string strAttachXml = "";
            string UserGuid = (string)Session["UserGuid"];
            string DisplayName = Session["DisplayName"].ToString();

            if (dgAttachment.Items.Count >= MaxAttachCount && MaxAttachCount>0)
            {
                trAdd.Visible = false;
                trRemark.Visible = false;
                Response.Write("<script language=javascript>alert('最多可上传" + MaxAttachCount + "个附件！');</script>");
                return;
            }

            if (File1.PostedFile != null)
            {
                HttpPostedFile upFileName = File1.PostedFile;
                if (upFileName.ContentLength > 0)
                {

                    string[] filesplit = upFileName.FileName.Split('\\');//分析文件名称
                    string fileName = filesplit[filesplit.Length - 1];
                    byte[] fileContent = new byte[upFileName.ContentLength];
                    upFileName.InputStream.Read(fileContent, 0, upFileName.ContentLength);
                    string strAttachGuid = Guid.NewGuid().ToString();

                    string DocumentType = fileName.Substring(fileName.LastIndexOf('.'), fileName.Length - fileName.LastIndexOf('.'));
                    StorgCom.Insert(strAttachGuid,
                        fileName,
                        upFileName.ContentType,
                        DocumentType,
                        Convert.ToString(ViewState[this.ID + "ClientTag"]),
                        ViewState[this.ID + "ClientGuid"].ToString(),
                        drpAttachType.SelectedValue,
                        upFileName.ContentLength,
                        fileContent);
                    upFileName.InputStream.Close();

                    this.BindAttach();
                    txtFile.Value = string.Empty;
                    //string strSql = string.Format("update rg_ouinfo set SMJZSJ='{1}' where  RowGuid='{0}' ", MisRowGuid, DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
                    //Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);
                    //如果是社保证明，就同步更新下
                    if (this.ID == "SBZM")
                    {
                        string strSql = string.Format("update rg_ouinfo set SMJZSJ='{1}' where  RowGuid='{0}' ", ViewState[this.ID + "ClientGuid"].ToString().Replace("SBZM", ""), DateTime.Now.AddMonths(6).ToString("yyyy-MM-dd") + " 23:59:59");
                        Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);
                    }
                    UpdateStatus(this.ID, ViewState[this.ID + "ClientGuid"].ToString());
                }
            }
        }

        private void InitDrpAttachType(string NodeCode)
        {
             // new Epoint.MisBizLogic2.Code.DB_CodeMain().GetDetail("业务附件类型");
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView("Select itemvalue,itemtext from view_codemain_codeitems where codename='业务附件类型'");
            drpAttachType.DataSource = dv;
            drpAttachType.DataValueField = "itemvalue";
            drpAttachType.DataTextField = "itemtext";
            drpAttachType.DataBind();
        }

        protected void dgAttachment_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
                
            //}
        }

        protected void dgAttachment_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom StorgCom = new Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom();

            string AttachGuid =dgAttachment.DataKeys[e.Item.ItemIndex].ToString() ;
            StorgCom.Delete_Attach(AttachGuid);
            if (this.ID == "SBZM")
            {
                string strSql = string.Format("update rg_ouinfo set SMJZSJ='{1}' where  RowGuid='{0}' ", ViewState[this.ID + "ClientGuid"].ToString().Replace("SBZM", ""), DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);
            }
            UpdateStatus(this.ID, ViewState[this.ID + "ClientGuid"].ToString());
            this.BindAttach();
         
        }
        public string getFuJianType(object AttachGuid)
        {
            string FuJianType = "";
            string Type = Epoint.MisBizLogic2.DB.ExecuteToString("select documenttype from Frame_AttachStorage where  attachguid='" + AttachGuid.ToString()+ "'");
            if (Type.Length > 0)
            {
                FuJianType = Type;
            }
            return FuJianType;
        }
        public string getFuJianDX(object AttachGuid)
        {
            string FuJianDX = "";
            string DX = Epoint.MisBizLogic2.DB.ExecuteToString("select attachlength from Frame_AttachInfo where  attachguid='" + AttachGuid.ToString() + "'");
            if (DX.Length > 0)
            {
                double ZHDX = Convert.ToDouble((Convert.ToInt32(DX))/1024);
                FuJianDX = Convert.ToString(ZHDX) + "k";
            }
            return FuJianDX;
        }

        protected void UpdateStatus(string CID,string CGuid)
        {
            Epoint.MisBizLogic2.Data.MisGuidRow oRow ;// = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            string TableName = "";
            string lb = CID.Substring(0, 2);
            if (lb == "QY")
            {
                TableName = "RG_OUInfo";
                
            }
            else if (lb == "RY")
            {
                TableName = "RG_QYUser";
            }
            else if (lb == "ZZ")
            {
                TableName = "RG_QiYeZiZhi";
            }
            else if (lb == "XM")
            {
                TableName = "RG_XMBeiAn";
            }
            else
            {
                TableName = "RG_OUInfo";
            }
            oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(TableName, CGuid.Replace(CID, ""));
            if (oRow["Status"].ToString() == "90")//如果已经通过，当附件变化是，变成变更中
            {
                oRow["Status"] = "85";
                oRow.Update();
            }
            
        }
    }
}