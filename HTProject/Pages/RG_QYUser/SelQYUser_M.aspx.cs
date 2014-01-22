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
using HTProject_Bizlogic;

namespace HTProject.Pages.RG_QYUser
{

    public partial class SelQYUser_M : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster 
	{
	
		public int TableID=2019;	
		Epoint.MisBizLogic2.Web.ListPage oListPage;
        protected HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack )
			{
				lblTableName.Text=oListPage.TableDetail.TableName;
				this.CurrentHead   = oListPage.TableDetail.TableName;				
           

				this.RefreshGrid();	
			}
			
		}

        override protected void OnInit(System.EventArgs e)
        {
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager,GridExcel );//如果没有导出Excel的Grid，就设置为null
            
            //此处添加全局通用条件 
            oListPage.OtherCondition = " and DelStatus='0' and Status='90' and DWGuid='" + Request["DWGuid"] + "' ";
            //将个人的劳动合同时间筛选
            oListPage.OtherCondition += " and HeTongEndDate>='" + DateTime.Now.ToString("yyyy-MM-dd") + "'  ";
            //将个人的身份证到期时间筛选
            oListPage.OtherCondition += " and sfzyxqz>='" + DateTime.Now.ToString("yyyy-MM-dd") + "'  ";
            //将个人的社保证明时间筛选
            //暂时不看社保证明，数据库社保证明时间有误!
            //oListPage.OtherCondition += " and Exists(SELECT 1 FROM RG_OUINFO WHERE ROWGUID=RG_QYUser.DWGUID AND SMJZSJ>'" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND STATUS='90' ) ";
            //注册章有效期
            oListPage.OtherCondition += " and ((YinZhangNo='') or (YinZhangNo!='' and ZCZ_YXQ>'" + DateTime.Now.ToString("yyyy-MM-dd") + "') or (YinZhangNo1='') or (YinZhangNo1!='' and ZCZ_YXQ1>'" + DateTime.Now.ToString("yyyy-MM-dd") + "') or (YinZhangNo2='') or (YinZhangNo2!='' and ZCZ_YXQ2>'" + DateTime.Now.ToString("yyyy-MM-dd") + "') ) ";
            oListPage.CustomMode = true;            
            //此方法解决删除错位问题。可以使查询条件的值自动从ViewState中恢复。
            controlHolder.Controls.Add(oListPage.RenderSearchCondition());
            
            base.OnInit(e);
        }


		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			Pager.CurrentPageIndex=0;
			this.RefreshGrid();	
		}

		protected void btnRefresh_Click(object sender, System.EventArgs e)
        {
            this.RefreshGrid();
        }

		private void RefreshGrid()
		{
            //增加对从事专业的帅选，需要注意的是，一级的人可以参与二级的事情
            if (Server.UrlDecode(Request["ItemText"]).IndexOf("二级") > 0)
            {
                int ordNo = Epoint.MisBizLogic2.DB.ExecuteToInt("select OrderNumber from Frame_Code_Item where ItemCode='" + Request["ZYCode"] + "'  and MainGuid='29b7967e-8098-42d5-8b40-ec757b0865a5'");
                string code = getGGJB(Server.UrlDecode(Request["ItemText"]).Replace("二级", "一级"), ordNo + 1);
                oListPage.OtherCondition += " and (ZhuanYeCSCode like '%" + Request["ZYCode"] + ";%' or ZhuanYeCSCode like '%" + code + ";%')";
            }
            else
            {
                //如果是岩土(0067)的，均可以从事“勘察、设计、水文、物探、检测、试验”，也就是说如果是后者， 均可从岩土(0067)中选择
                if (Request["ZYCode"] == "0070" || Request["ZYCode"] == "0071" || Request["ZYCode"] == "0072" || Request["ZYCode"] == "0073" 
                    || Request["ZYCode"] == "0074" || Request["ZYCode"] == "0075" || Request["ZYCode"] == "0076" || Request["ZYCode"] == "0077")
                {
                    oListPage.OtherCondition += " and (ZhuanYeCSCode like '0067%' or ZhuanYeCSCode like '%" + Request["ZYCode"] + "%') ";
                }
                else if(Request["ZYCode"].Length == 8)
                {
                    oListPage.OtherCondition += " and ZhuanYeCSCode like '%" + Request["ZYCode"] + ";%' ";
                }
                else if (Request["ZYCode"].Length == 4)//由于00700001和00070001无法区分，因此用了笨办法，最多5个
                {
                    oListPage.OtherCondition += " and (ZhuanYeCSCode like '%" + Request["ZYCode"] + "0001;%' or ZhuanYeCSCode like '%" + Request["ZYCode"] + "0002;%' or ZhuanYeCSCode like '%"
                        + Request["ZYCode"] + "0003;%' or ZhuanYeCSCode like '%" + Request["ZYCode"] + "0004;%' or ZhuanYeCSCode like '%" + Request["ZYCode"]
                        + "0005;%' or (ZhuanYeCSCode like '%" + Request["ZYCode"] + ";%' and ZhuanYeCS like '%" + Request["ItemText"] + "%' ))";//and len(ZhuanYeCSCode)=5 
                }
            }
            oListPage.GenerateSearchResult();			
		}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "打开搜索")
            {
                btnSearch.Text = "关闭搜索";
                tdCl.Style.Add("display","");
            }
            else
            {
                btnSearch.Text = "打开搜索";
                tdCl.Style.Add("display", "none");
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.WriteAjaxMessage("RT();");
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
        
        protected void GridExcel_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                for (int i = 0; i < e.Item.Cells.Count; i++)
                    e.Item.Cells[i].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
            }
        }

        protected string getGGJB(string ItemText, int OrNum)
        {
            if (ItemText.IndexOf('·') > 0)
            {
                ItemText = ItemText.Substring(ItemText.IndexOf('·') + 1);
            }
            string strSql = " select ItemCode from Frame_Code_Item where ItemText='" + ItemText + "' and OrderNumber='" + OrNum + "' and MainGuid='29b7967e-8098-42d5-8b40-ec757b0865a5'";
            //DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            //if (dv.Count > 0)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["RowGuid"] = pRGuid + dv[0]["ItemCode"].ToString();
            //    dr["ZiZhiText"] = ZiZhiText;
            //    dr["ZiZhiTextCode"] = dv[0]["ItemCode"].ToString();
            //    dr["ZiZhiCode"] = ZiZhiCode;
            //    dt.Rows.Add(dr);
            //}
            return Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
        }

   }
}


