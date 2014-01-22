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
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager,GridExcel );//���û�е���Excel��Grid��������Ϊnull
            
            //�˴����ȫ��ͨ������ 
            oListPage.OtherCondition = " and DelStatus='0' and Status='90' and DWGuid='" + Request["DWGuid"] + "' ";
            //�����˵��Ͷ���ͬʱ��ɸѡ
            oListPage.OtherCondition += " and HeTongEndDate>='" + DateTime.Now.ToString("yyyy-MM-dd") + "'  ";
            //�����˵����֤����ʱ��ɸѡ
            oListPage.OtherCondition += " and sfzyxqz>='" + DateTime.Now.ToString("yyyy-MM-dd") + "'  ";
            //�����˵��籣֤��ʱ��ɸѡ
            //��ʱ�����籣֤�������ݿ��籣֤��ʱ������!
            //oListPage.OtherCondition += " and Exists(SELECT 1 FROM RG_OUINFO WHERE ROWGUID=RG_QYUser.DWGUID AND SMJZSJ>'" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND STATUS='90' ) ";
            //ע������Ч��
            oListPage.OtherCondition += " and ((YinZhangNo='') or (YinZhangNo!='' and ZCZ_YXQ>'" + DateTime.Now.ToString("yyyy-MM-dd") + "') or (YinZhangNo1='') or (YinZhangNo1!='' and ZCZ_YXQ1>'" + DateTime.Now.ToString("yyyy-MM-dd") + "') or (YinZhangNo2='') or (YinZhangNo2!='' and ZCZ_YXQ2>'" + DateTime.Now.ToString("yyyy-MM-dd") + "') ) ";
            oListPage.CustomMode = true;            
            //�˷������ɾ����λ���⡣����ʹ��ѯ������ֵ�Զ���ViewState�лָ���
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
            //���ӶԴ���רҵ��˧ѡ����Ҫע����ǣ�һ�����˿��Բ������������
            if (Server.UrlDecode(Request["ItemText"]).IndexOf("����") > 0)
            {
                int ordNo = Epoint.MisBizLogic2.DB.ExecuteToInt("select OrderNumber from Frame_Code_Item where ItemCode='" + Request["ZYCode"] + "'  and MainGuid='29b7967e-8098-42d5-8b40-ec757b0865a5'");
                string code = getGGJB(Server.UrlDecode(Request["ItemText"]).Replace("����", "һ��"), ordNo + 1);
                oListPage.OtherCondition += " and (ZhuanYeCSCode like '%" + Request["ZYCode"] + ";%' or ZhuanYeCSCode like '%" + code + ";%')";
            }
            else
            {
                //���������(0067)�ģ������Դ��¡����졢��ơ�ˮ�ġ���̽����⡢���顱��Ҳ����˵����Ǻ��ߣ� ���ɴ�����(0067)��ѡ��
                if (Request["ZYCode"] == "0070" || Request["ZYCode"] == "0071" || Request["ZYCode"] == "0072" || Request["ZYCode"] == "0073" 
                    || Request["ZYCode"] == "0074" || Request["ZYCode"] == "0075" || Request["ZYCode"] == "0076" || Request["ZYCode"] == "0077")
                {
                    oListPage.OtherCondition += " and (ZhuanYeCSCode like '0067%' or ZhuanYeCSCode like '%" + Request["ZYCode"] + "%') ";
                }
                else if(Request["ZYCode"].Length == 8)
                {
                    oListPage.OtherCondition += " and ZhuanYeCSCode like '%" + Request["ZYCode"] + ";%' ";
                }
                else if (Request["ZYCode"].Length == 4)//����00700001��00070001�޷����֣�������˱��취�����5��
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
            if (btnSearch.Text == "������")
            {
                btnSearch.Text = "�ر�����";
                tdCl.Style.Add("display","");
            }
            else
            {
                btnSearch.Text = "������";
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
            if (ItemText.IndexOf('��') > 0)
            {
                ItemText = ItemText.Substring(ItemText.IndexOf('��') + 1);
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


