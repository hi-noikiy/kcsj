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
using System.Text;

namespace EpointRegisterUser.Ascx
{
    public partial class CaiLiao : System.Web.UI.UserControl
    {

        EpointRegisterUser_Bizlogic.Common Com = new EpointRegisterUser_Bizlogic.Common();

        /// <summary>
        /// 需要使用材料的mis表tableid
        /// </summary>
        public int MisTableID
        {
            get
            {
                return Convert.ToInt32(ViewState["MisTableID"]);
            }
            set
            {
                ViewState["MisTableID"] = value;
            }
        }

        /// <summary>
        /// 具体mis表中的哪条记录的rowguid
        /// </summary>
        public string MisRowGuid
        {
            get
            {
                return Convert.ToString(ViewState["MisRowGuid"]);
            }
            set
            {
                ViewState["MisRowGuid"] = value;
            }
        }

        /// <summary>
        /// ProjectGuid同步时保存项目信息
        /// </summary>
        public string ProjectGuid
        {
            get
            {
                return Convert.ToString(ViewState["ProjectGuid"]);
            }
            set
            {
                ViewState["ProjectGuid"] = value;
            }
        }


        /// <summary>
        /// Comment记录企业Guid
        /// </summary>
        public string Comment
        {
            get
            {
                return Convert.ToString(ViewState["Comment"]);
            }
            set
            {
                ViewState["Comment"] = value;
            }
        }


        /// <summary>
        /// 所属业务的名称,查看代码[公用_业务配置]
        /// </summary>
        public string YeWuMC
        {
            get
            {
                return Convert.ToString(ViewState["YeWuMC"]);
            }
            set
            {
                ViewState["YeWuMC"] = value;
            }
        }



        /// <summary>
        /// 是否只读
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return Convert.ToBoolean(ViewState["ReadOnly"]);
            }
            set
            {
                ViewState["ReadOnly"] = value;
            }
        }

        /// <summary>
        /// 显示d_TiJiaoSJ日期之前的数据
        /// </summary>
        public string d_TiJiaoSJ
        {
            get
            {
                return Convert.ToString(ViewState["d_TiJiaoSJ"]);
            }
            set
            {
                ViewState["d_TiJiaoSJ"] = value;
            }
        }

        public bool ShowDelete
        {
            get
            {
                return Convert.ToBoolean(ViewState["ShowDelete"]);
            }
            set
            {
                ViewState["ShowDelete"] = value;
            }
        }
        


        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.RefreshGrid();
            }

        }

        override protected void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
        }

        private EpointRegisterUser_Bizlogic.CaiLiao caiLiao = new EpointRegisterUser_Bizlogic.CaiLiao();
        private int TableID = 392;
        private int fileTableID = 396;

        public void RefreshGrid()
        {
            DataView dv = caiLiao.GetCaiLiaoEntityList(Convert.ToString(ViewState["MisRowGuid"]), Convert.ToInt32(ViewState["MisTableID"]), Convert.ToString(ViewState["YeWuMC"]));
            if (dv.Count > 0)
            {
                if (dv[0]["ConfigRowGuid"] != DBNull.Value)
                {
                    ViewState["ConfigRowGuid"] = Convert.ToString(dv[0]["ConfigRowGuid"]);
                }
                if (dv[0]["RowGuid"] != DBNull.Value)
                {
                    ViewState["IsSaved"] = "1";
                    ViewState["RowGuid"] = dv[0]["RowGuid"].ToString();
                }
                else
                {
                    ViewState["IsSaved"] = "0";
                }

            }
        }

        /// <summary>
        /// 保存材料内容
        /// </summary>
        public void Save()
        {
            Epoint.MisBizLogic2.Data.MisGuidRow oRow;

            string RowGuid;
            string[] arrFileIndex = txtFileIndex.Text.Split('|');
            //判断是否是空
            StringBuilder sb = new StringBuilder();
            foreach (string fileIndex in arrFileIndex)
            {
                if (fileIndex != "")
                {
                    //上传附件
                    sb.Append(CheckFilesIsEmpty("attachfile" + fileIndex));
                }
            }
            if (sb.Length > 0)
            {
                //Parent.Page.ClientScript.RegisterStartupScript(this.GetType(), "2", string.Format("<script>alert('{0}');</script>", sb.ToString()));
                Response.Write("<Script   language='javascript'>");

                Response.Write(string.Format("alert('{0}');", sb.ToString()));

                Response.Write("</script>");
                //return;
            }
            if (Convert.ToString(ViewState["IsSaved"]) != "1")
            {
                RowGuid = Guid.NewGuid().ToString();
                //新材料的添加
                oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(Com.GetTableNameByID(TableID));
                oRow["RowGuid"] = RowGuid;
                oRow["ConfigRowGuid"] = Convert.ToString(ViewState["ConfigRowGuid"]);
                oRow["MisTableID"] = Convert.ToInt32(ViewState["MisTableID"]);
                oRow["MisRowGuid"] = Convert.ToString(ViewState["MisRowGuid"]);
                oRow["ProjectGuid"] = Convert.ToString(ViewState["ProjectGuid"]);
                oRow["Comment"] = Convert.ToString(ViewState["Comment"]);
                oRow["s_YeWuMC"] = Convert.ToString(ViewState["YeWuMC"]);
                oRow["s_ShiFouTiJiao"] = "1";
                oRow["d_TiJiaoSJ"] = DateTime.Now.AddSeconds(-1).ToString();

                oRow.Insert();
            }
            else
            {
                RowGuid = ViewState["RowGuid"].ToString();
            }

            
            foreach (string fileIndex in arrFileIndex)
            {
                if (fileIndex != "")
                {
                    //上传附件
                    uploadFiles("attachfile" + fileIndex, RowGuid);
                }
            }
            this.RefreshGrid();
        }

        /// <summary>
        /// 附件上传
        /// </summary>
        private void uploadFiles(string fileName, string EntityRowGuid)
        {
            Epoint.MisBizLogic2.Web.AddPage oAddPage = new Epoint.MisBizLogic2.Web.AddPage(fileTableID);
            Epoint.MisBizLogic2.Data.MisGuidRow oRow;

            HttpPostedFile upFileName = HttpContext.Current.Request.Files[fileName];
            string strAttachGuid = "";

            if (upFileName != null)
            {
                if (upFileName.ContentLength > 0)
                {
                    string[] filesplit = upFileName.FileName.Split('\\');//分析文件名称
                    string filename = filesplit[filesplit.Length - 1];
                    byte[] fileContent = new byte[upFileName.ContentLength];
                    upFileName.InputStream.Read(fileContent, 0, upFileName.ContentLength);
                    strAttachGuid = Guid.NewGuid().ToString();

                    //oAddPage.SaveTableValues(strAttachGuid, tdContainer, Request.QueryString["ParentRowGuid"]);

                    //本地表中插入附件信息
                    #region 插入附件信息
                    oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(Com.GetTableNameByID(fileTableID));
                    oRow["RowGuid"] = strAttachGuid;
                    oRow["pic_FuJian"] = fileContent;
                    oRow["pic_FuJian_ContentType"] = upFileName.ContentType;
                    oRow["pic_FuJian_FileName"] = filename;
                    oRow["d_UploadDate"] = DateTime.Now.AddSeconds(-1);//为了配合版本查询 add by xuz
                    oRow["EntityRowGuid"] = EntityRowGuid;
                    oRow["i_delete"] = 0;
                    oRow.Insert();

                    #endregion

                    upFileName.InputStream.Close();
                }
            }
        }

        /// <summary>
        /// 判断上传的文件是不是空文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string CheckFilesIsEmpty(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            HttpPostedFile upFileName = HttpContext.Current.Request.Files[fileName];
            if (upFileName != null)
            {
                if (upFileName.ContentLength <= 0)
                {
                    string[] filesplit = upFileName.FileName.Split('\\');//分析文件名称
                    string filename = filesplit[filesplit.Length - 1];

                    sb.Append(string.Format("您上传的文件【{0}】为空,不能进行上传\\r\\n", filename));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 得到附件连接地址
        /// </summary>
        /// <param name="AttachGuid"></param>
        /// <param name="AttachFileName"></param>
        /// <returns></returns>
        public string GetAttachInfo()
        {
            string DWGuid = Convert.ToString(ViewState["Comment"]);
            string rtnHtml = "";
            if (DWGuid != "")
            {
                DataView dvAttachInfo = caiLiao.GetCaiLiaoFuJianList(DWGuid, YeWuMC, Convert.ToString(ViewState["d_TiJiaoSJ"]));
                if (dvAttachInfo.Count > 0)
                {
                    for (int i = 0; i < dvAttachInfo.Count; i++)
                    {
                        if (Convert.ToBoolean(ViewState["ReadOnly"]) == true && i == 0)
                        {
                            rtnHtml += "<span name='span" + dvAttachInfo[i]["RowGuid"].ToString() + "'>&nbsp;[<a target='_blank'  href='" + Request.ApplicationPath + "/EpointMis/Pages/CommonPages/RetrieveImageData.aspx?TableName=GY_CaiLiaoEntityFuJian&FieldName=pic_FuJian&RowGuid=" + dvAttachInfo[i]["RowGuid"].ToString() + "'><font color='red'>" + dvAttachInfo[i]["pic_FuJian_FileName"].ToString() + "</font></a>";
                        }
                        else
                        {
                            rtnHtml += "<br /><span name='span" + dvAttachInfo[i]["RowGuid"].ToString() + "'>&nbsp;[<a target='_blank'  href='" + Request.ApplicationPath + "/EpointMis/Pages/CommonPages/RetrieveImageData.aspx?TableName=GY_CaiLiaoEntityFuJian&FieldName=pic_FuJian&RowGuid=" + dvAttachInfo[i]["RowGuid"].ToString() + "'><font color='red'>" + dvAttachInfo[i]["pic_FuJian_FileName"].ToString() + "</font></a>";
                        }
                        //if (Convert.ToBoolean(ViewState["ReadOnly"]) == false)
                        //{
                            if (Convert.ToInt32(dvAttachInfo[i]["i_delete"]) == 1)
                            {
                                rtnHtml += "&nbsp;<font color=blue>已删除</font>";
                            }
                            else
                            {
                                if (Convert.ToBoolean(ViewState["ReadOnly"]) == false)
                                {
                                    rtnHtml += "&nbsp;<a href=\"javascript:void(0);\" onclick=\"DelAttach('" + dvAttachInfo[i]["RowGuid"].ToString() + "',this);\">删除</a>";
                                }
                            }
                        //}
                        //else
                        //{
                        //    if (Convert.ToBoolean(ViewState["ReadOnly"]) == false)
                        //    {
                        //        rtnHtml += "&nbsp;<a href=\"javascript:void(0);\" onclick=\"DelAttach('" + dvAttachInfo[i]["RowGuid"].ToString() + "',this);\">删除</a>";
                        //    }
                        //}
                        rtnHtml += "]&nbsp;</span>";
                    }
                }
            }
            return rtnHtml;
        }

        public string GetAttachInfoTwo()
        {
            string DWGuid = Convert.ToString(ViewState["Comment"]);
            string rtnHtml = "";
            if (DWGuid != "")
            {
                DataView dvAttachInfo = caiLiao.GetCaiLiaoFuJianList(ViewState["MisRowGuid"].ToString(), DWGuid, YeWuMC, Convert.ToString(ViewState["d_TiJiaoSJ"]));
                if (dvAttachInfo.Count > 0)
                {
                    for (int i = 0; i < dvAttachInfo.Count; i++)
                    {
                        if (Convert.ToBoolean(ViewState["ReadOnly"]) == true && i == 0)
                        {
                            rtnHtml += "<span name='span" + dvAttachInfo[i]["RowGuid"].ToString() + "'>&nbsp;[<a target='_blank'  href='" + Request.ApplicationPath + "/EpointMis/Pages/CommonPages/RetrieveImageData.aspx?TableName=GY_CaiLiaoEntityFuJian&FieldName=pic_FuJian&RowGuid=" + dvAttachInfo[i]["RowGuid"].ToString() + "'><font color='red'>" + dvAttachInfo[i]["pic_FuJian_FileName"].ToString() + "</font></a>";
                        }
                        else
                        {
                            rtnHtml += "<br /><span name='span" + dvAttachInfo[i]["RowGuid"].ToString() + "'>&nbsp;[<a target='_blank'  href='" + Request.ApplicationPath + "/EpointMis/Pages/CommonPages/RetrieveImageData.aspx?TableName=GY_CaiLiaoEntityFuJian&FieldName=pic_FuJian&RowGuid=" + dvAttachInfo[i]["RowGuid"].ToString() + "'><font color='red'>" + dvAttachInfo[i]["pic_FuJian_FileName"].ToString() + "</font></a>";
                        }
                        //if (Convert.ToBoolean(ViewState["ReadOnly"]) == false)
                        //{
                        if (Convert.ToInt32(dvAttachInfo[i]["i_delete"]) == 1)
                        {
                            rtnHtml += "&nbsp;<font color=blue>已删除</font>";
                        }
                        else
                        {
                            if (Convert.ToBoolean(ViewState["ReadOnly"]) == false)
                            {
                                rtnHtml += "&nbsp;<a href=\"javascript:void(0);\" onclick=\"DelAttach('" + dvAttachInfo[i]["RowGuid"].ToString() + "',this);\">删除</a>";
                            }
                        }
                        //}
                        //else
                        //{
                        //    if (Convert.ToBoolean(ViewState["ReadOnly"]) == false)
                        //    {
                        //        rtnHtml += "&nbsp;<a href=\"javascript:void(0);\" onclick=\"DelAttach('" + dvAttachInfo[i]["RowGuid"].ToString() + "',this);\">删除</a>";
                        //    }
                        //}
                        rtnHtml += "]&nbsp;</span>";
                    }
                }
            }
            return rtnHtml;
        }


        protected void btnDelAttach_ServerClick(object sender, EventArgs e)
        {
            string AttachGuid = HidAttachDel.Value;
            caiLiao.UpdateCaiLiaoFuJianDelete(AttachGuid, 1, DateTime.Now);
            ViewState["ShowDelete"] = "1";
            RefreshGrid();
        }
    }
}