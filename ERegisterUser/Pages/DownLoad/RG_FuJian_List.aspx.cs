using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System;
using System.IO;
using System.Text;
using Ionic.Zip;

namespace EpointRegisterUser.Pages.RG_OU
{

    public partial class RG_FuJian_List : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 396;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        ZipFile zip = new ZipFile(Encoding.Default);
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblTableName.Text = oListPage.TableDetail.TableName;
                //this.CurrentHead = oListPage.TableDetail.TableName;
                if (Request["type"] != "1")
                {
                    this.s_xiangMuJL.Enabled = false;
                }

                #region 是否联机表
                if (oListPage.TableDetail.Is_OnlineTable == "1")
                {
                    //btnAddRecord.Visible = false;
                    //btnDel.Visible = false;
                }
                else
                {
                    //btnAddRecord.Visible = true;
                    //btnDel.Visible = true;
                }
                #endregion

                #region 填充 项目来源
                DataView dv = new Epoint.MisBizLogic2.Code.DB_CodeItem().Get_Items_By_CodeName("苏州创投_项目来源");
                if (dv.Count > 0)
                {
                    for (int i = 0; i < dv.Count; i++)
                    {
                        this.s_xiangMuLY.Items.Add(new ListItem(dv[i]["ItemText"].ToString(), dv[i]["ItemValue"].ToString()));
                    }
                }
                #endregion

                #region 填充 管理平台
                DataView dv_GLPT = new SVGBLL.Pro_Fund().Select_guanLiPT_byUserGuid(Session["UserGuid"].ToString());
                if (dv_GLPT.Count > 0)
                {
                    for (int i = 0; i < dv_GLPT.Count; i++)
                    {
                        this.s_GuanLiPT.Items.Add(new ListItem(dv_GLPT[i]["s_guanlir"].ToString(), dv_GLPT[i]["rowguid"].ToString()));
                    }
                }
                #endregion

                #region 填充 项目状态
                dv = new Epoint.MisBizLogic2.Code.DB_CodeItem().Get_Items_By_CodeName("苏州创投_项目状态");
                if (dv.Count > 0)
                {
                    for (int i = 1; i < dv.Count; i++)
                    {
                        this.s_xiangMuZT.Items.Add(new ListItem(dv[i]["ItemText"].ToString(), dv[i]["ItemValue"].ToString()));
                    }
                }
                #endregion

                this.RefreshGrid();
            }

        }

        override protected void OnInit(System.EventArgs e)
        {
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, GridExcel);//如果没有导出Excel的Grid，就设置为null
            oListPage.CustomMode = true;
            oListPage.SortExpression = " order by Row_ID desc";
            //此方法解决删除错位问题。可以使查询条件的值自动从ViewState中恢复。
            controlHolder.Controls.Add(oListPage.RenderSearchCondition());

            base.OnInit(e);
        }


        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            Pager.CurrentPageIndex = 0;
            this.RefreshGrid();
        }


        private void RefreshGrid()
        {
            string str = " and s_Pro_Type='企业类'";

            if (Request["type"] == "1")
            {
                if (s_xiangMuJL.Text != "")
                {
                    str += " and s_xiangMuJL like '%" + this.s_xiangMuJL.Text.Replace("'", "''").Replace("_", "\\_").Replace("%", "\\%") + "%'";
                }
            }
            else
            {
                str += " and (s_xiangMuJL_Guid = '" + Session["UserGuid"].ToString() + "' or s_dengJiR_Guid= '" + Session["UserGuid"].ToString() + "')";
            }

            if (s_xiangMuMC.Text != "")
            {
                str += " and s_xiangMuMC like '%" + this.s_xiangMuMC.Text.Replace("'", "''").Replace("_", "\\_").Replace("%", "\\%") + "%'";
            }

            if (s_xiangMuGSQC.Text != "")
            {
                str += " and s_xiangMuGSQC like '%" + this.s_xiangMuGSQC.Text.Replace("'", "''").Replace("_", "\\_").Replace("%", "\\%") + "%'";
            }

            if (this.s_xiangmuBH.Text.Trim() != "")
            {
                str += " and s_xiangmuBH like '%" + this.s_xiangmuBH.Text.Trim().Replace("'", "''").Replace("_", "\\_").Replace("%", "\\%") + "%'";
            }


            if (s_dengJiR.Text != "")
            {
                str += " and s_dengJiR like '%" + this.s_dengJiR.Text.Replace("'", "''").Replace("_", "\\_").Replace("%", "\\%") + "%'";
            }

            if (this.d_dengJiRQ.FromText.ToString() != "")
            {
                str += " and d_dengJiRQ>'" + DateTime.Parse(this.d_dengJiRQ.FromText.ToString()).AddDays(-1) + "'";
            }
            if (this.d_dengJiRQ.ToText.ToString() != "")
            {
                str += " and d_dengJiRQ<'" + DateTime.Parse(this.d_dengJiRQ.ToText.ToString()).AddDays(1) + "'";
            }
            //决策时间
            if (this.d_TouZiJCSJ.FromText.ToString() != "")
            {
                str += " and d_TouZiJCSJ>'" + DateTime.Parse(this.d_TouZiJCSJ.FromText.ToString()).AddHours(-2) + "'";
            }
            if (this.d_TouZiJCSJ.ToText.ToString() != "")
            {
                str += " and d_TouZiJCSJ<'" + DateTime.Parse(this.d_TouZiJCSJ.ToText.ToString()).AddHours(23) + "'";
            }
            
            if (this.s_xiangMuLY.SelectedValue.ToString() != "")
            {
                str += " and s_xiangMuLY_Drop=" + this.s_xiangMuLY.SelectedValue.ToString();
            }
            if (this.s_GuanLiPT.SelectedValue.ToString() != "")
            {
                string GuanLiPT = rtn_GuanLiPT();

                str += " and s_guanLiPT in (" + GuanLiPT + ")";

            }
            if (this.s_xiangMuZT.SelectedValue.ToString() != "")
            {
                string xiangMuZTList = rtn_xiangMuZT();

                str += " and s_xiangMuZT in (" + xiangMuZTList + ")";
            }
            str += " and (s_del_TrueOrFalse is Null or s_del_TrueOrFalse='')";
            //还要加上关联的企业的
            str += "  ";
            string GuanLiPT_All = rtn_GuanLiPT_ForAll();

            str += " and s_guanLiPT in (" + GuanLiPT_All + ")";
            oListPage.OtherCondition = str;

            oListPage.TableDetail.SQL_TableName = "VIEW_AllFuJian";
            oListPage.GenerateSearchResult();

            HtmlInputCheckBox chk;
            for (int i = 0; i < Datagrid1.Items.Count; i++)
            {
                chk = (HtmlInputCheckBox)Datagrid1.Items[i].FindControl("chkAdd");
                if (hiFuJianList.Value.IndexOf(Datagrid1.DataKeys[i].ToString()) >= 0)
                {
                    chk.Checked = true;
                }
            }
        }

        //取得管理平台
        protected string rtn_GuanLiPT()
        {

            string GuanLiPT = "'-1',";
            if (s_GuanLiPT.Items.Count > 0)
            {
                for (int i = 0; i < s_GuanLiPT.Items.Count; i++)
                {
                    if (s_GuanLiPT.Items[i].Selected)
                    {
                        GuanLiPT += "'" + s_GuanLiPT.Items[i].Value + "',";
                    }
                }
            }

            if (GuanLiPT.Length > 1)
            {
                GuanLiPT = GuanLiPT.Substring(0, GuanLiPT.Length - 1);
            }
            return GuanLiPT;

        }


        //取得管理平台  限定当前人员的管理平台权限
        protected string rtn_GuanLiPT_ForAll()
        {

            DataView dv_GLPT = new SVGBLL.Pro_Fund().Select_guanLiPT_byUserGuid(Session["UserGuid"].ToString());

            string GuanLiPT = "'-1',";
            if (dv_GLPT.Count > 0)
            {
                for (int i = 0; i < dv_GLPT.Count; i++)
                {

                    GuanLiPT += "'" + dv_GLPT[i]["rowguid"].ToString() + "',";

                }
            }

            if (GuanLiPT.Length > 1)
            {
                return GuanLiPT.Substring(0, GuanLiPT.Length - 1);
            }
            return GuanLiPT;

        }

        //取得项目状态
        protected string rtn_xiangMuZT()
        {
            string xiangMuZTList = "";
            if (s_xiangMuZT.Items.Count > 0)
            {
                for (int i = 0; i < s_xiangMuZT.Items.Count; i++)
                {
                    if (s_xiangMuZT.Items[i].Selected)
                    {
                        xiangMuZTList += "'" + s_xiangMuZT.Items[i].Value + "',";
                    }
                }
            }
            return xiangMuZTList.Substring(0, xiangMuZTList.Length - 1);

        }

        protected void btnDown_Click(object sender, System.EventArgs e)
        {
            HtmlInputCheckBox chk;
            string tempGuid = this.UserGuid + "-LS";
            string strUrl = HttpContext.Current.Server.MapPath(GetApplicationPath()) + "AttachStorage\\" + tempGuid + "\\";
            DirectoryInfo Dir = new DirectoryInfo(strUrl);

            if (!Directory.Exists(strUrl))
            {
                Directory.CreateDirectory(strUrl);
            }
            foreach (string item in System.IO.Directory.GetFiles(strUrl))
            {
                FileInfo FI = new FileInfo(item);
                File.Delete(item);
            }
            for (int i = 0; i < Datagrid1.Items.Count; i++)
            {
                chk = (HtmlInputCheckBox)Datagrid1.Items[i].FindControl("chkAdd");
                //循环生成文件
                if (chk.Checked)
                {
                    StringBuilder sb = new StringBuilder();
                    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oListPage.TableDetail.SQL_TableName, Datagrid1.DataKeys[i].ToString());


                    string strFileName = oRow["pic_FuJian_FileName"].ToString();
                    strFileName = ChangFileName(strUrl, strFileName, 0);//检查是否需要重新命名
                    string filePath = strUrl + strFileName;
                    
                    FileStream objFileStream;
                    BinaryWriter objBinaryWriter;
                    objFileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                    objBinaryWriter = new BinaryWriter(objFileStream);
                    objBinaryWriter.Write((byte[])oRow["pic_FuJian"]);
                    objBinaryWriter.Close();
                    objFileStream.Close();
                }
            }

            //循环打包
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            zip.Name = fileName ;
            //zip = new ZipFile(strUrl + zip.Name + ".zip");
            foreach (string item in System.IO.Directory.GetFiles(strUrl))
            {
                zip.AddFile(item, "");
            }
            //zip.
            zip.Save(strUrl + zip.Name + ".zip");
            WriteAjaxMessage("OpenWindow('RG_DownZip.aspx?zipname=" + fileName + "'),800,600");
        }

        protected string ChangFileName(string filePath, string fileName,int count)
        {
            //xxx.jpg
            string allPath = filePath + fileName;
            if (File.Exists(allPath))
            {
                //存在，那么就重新生成新的名称
                count = count + 1;
                if (count == 1)
                {
                    fileName = "(" + count + ")" + fileName;
                }
                else
                {
                    fileName = fileName.Replace("(" + (count - 1).ToString() + ")", "(" + count + ")");
                }
                return ChangFileName(filePath, fileName, count);
            }
            return fileName;
        }

        protected void test()
        {
            /* 将C:\TMP\TMP2\01.jpg 文件压缩至 test01.zip 文件中的 TMP\TMP2\01.jpg     
             * 2:   * 将 D:\02.jpg文件压缩至 test01.zip 文件中的 02.jpg     
             * 3:   * 将 C:\TMP\03.jpg文件压缩至 test01.zip 文件中的 TMP\03.jpg   
             * 4:   */
            using (ZipFile zip = new ZipFile(@"C:\test01.zip"))
            {
                zip.AddFile(@"C:\TMP\TMP2\01.jpg");
                zip.AddFile(@"D:\02.jpg");
                zip.AddFile(@"C:\TMP\03.jpg");
                zip.Save();
            }
            // 将 TMP2 目录压缩至 test02.zip 文件中的 TMP\TMP2 目录  
            using (ZipFile zip = new ZipFile(@"C:\test02.zip"))
            {
                zip.AddDirectory(@"C:\TMP\TMP2");
                zip.Save();
            }
            /* 将 TMP2 目录压缩至 test03.zip 文件中的 TTT 目录   21:   
             * * 将 C:\TMP\03.jpg文件压缩至 test03.zip 文件中的 TTT\03.jpg   22:   */
            using (ZipFile zip = new ZipFile(@"C:\test03.zip"))
            {
                zip.AddFile(@"C:\TMP\03.jpg", "TTT");
                zip.AddItem(@"C:\TMP\TMP2", "TTT");
                zip.Save();
            }
            // 将 C:\test03.zip 文件解压缩至 C:\  
            using (ZipFile zip = new ZipFile(@"C:\test03.zip")) 
            { 
                zip.ExtractAll(@"C:\"); 
            }
        }

        protected void btnRecover_Click(object sender, System.EventArgs e)
        {
            CheckBox chk;
            for (int i = 0; i < Datagrid1.Items.Count; i++)
            {
                chk = (CheckBox)Datagrid1.Items[i].FindControl("chkAdd");
                if (chk.Checked)
                {
                    Epoint.MisBizLogic2.DB.ExecuteNonQuery("update RG_OUInfo set DelFlag=0 where RowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    //new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_OUInfo", "RowGuid", Convert.ToString(Datagrid1.DataKeys[i]));
                }
            }
            this.RefreshGrid();
            //tddel.Style["display"] = "";
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "打开搜索")
            {
                btnSearch.Text = "关闭搜索";
                tdCl.Style.Add("display", "");
            }
            else
            {
                btnSearch.Text = "打开搜索";
                tdCl.Style.Add("display", "none");
            }

        }

        protected void Pager_PageChanged(object src, Wuqi.Webdiyer.PageChangedEventArgs e)
        {
            Pager.CurrentPageIndex = e.NewPageIndex;
            this.RefreshGrid();
        }

        protected void Datagrid1_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            oListPage.PrepareForSortCommand(e.SortExpression);
            Pager.CurrentPageIndex = 0;
            this.RefreshGrid();
        }

        protected void Datagrid1_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            oListPage.GenerateSerialNumColumn(e.Item);

        }

        protected void Datagrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            CheckBox chk;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                for (int i = 0; i < e.Item.Cells.Count; i++)
                //e.Item.Cells[i].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
                {
                    chk = (CheckBox)Datagrid1.Items[i].FindControl("chkAdd");
                    chk.Attributes.Add("value ", "Chinese ");

                }
            }
        }


    }
}


