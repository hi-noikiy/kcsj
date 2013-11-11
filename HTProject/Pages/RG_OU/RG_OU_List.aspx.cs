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

namespace HTProject.Pages.RG_OU
{

	public partial class RG_OU_List : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster 
	{
	
		public int TableID=2017;	
		Epoint.MisBizLogic2.Web.ListPage oListPage;
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack )
			{
				lblTableName.Text=oListPage.TableDetail.TableName;
				this.CurrentHead   = oListPage.TableDetail.TableName;				
           
				#region �Ƿ�������
                if (oListPage.TableDetail.Is_OnlineTable == "1")
                {
                    btnAddRecord.Visible = false;
                    btnDel.Visible = false;
                }
                else
                {
                    btnAddRecord.Visible = true;
                    btnDel.Visible = true;
                }				
				#endregion
                RG_DW.InitSHStatus(ddlStatus);
				this.RefreshGrid();	
			}
			
		}

        override protected void OnInit(System.EventArgs e)
        {
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager,GridExcel );//���û�е���Excel��Grid��������Ϊnull
            
            //�˴����ȫ��ͨ������ 
            oListPage.OtherCondition = " and DelStatus='0' ";
            
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
            if (ddlStatus.SelectedValue != "")
            {
                oListPage.OtherCondition += " AND Status='" + ddlStatus.SelectedValue + "' ";
            }
            oListPage.GenerateSearchResult();			
		}


		protected void btnDel_Click(object sender, System.EventArgs e)
		{
            CheckBox chk;
            for (int i = 0; i < Datagrid1.Items.Count; i++)
            {
                chk = (CheckBox)Datagrid1.Items[i].FindControl("chkAdd");
                if (chk.Checked)
                {
                    //���ʺż���Ա��Ϣ������ɾ�����
                    RG_DW.DeleteRGUser(" AND DanWeiGuid='" + Datagrid1.DataKeys[i] + "' ");
                    RG_DW.DeleteByStatus("1", "RG_QYUser", " AND DWGuid='" + Datagrid1.DataKeys[i] + "' ");
                    RG_DW.DeleteByStatus("1", oListPage.TableDetail.SQL_TableName, " AND RowGuid='" + Datagrid1.DataKeys[i] + "' ");
                    //Epoint.MisBizLogic2.Data.CommonDataTable.DeleteRecord_FromSqlTable(
                    //   oListPage.TableID,
                    //   oListPage.TableDetail.SQL_TableName,
                    //   Convert.ToString(Datagrid1.DataKeys[i])
                    //   );
                }
            }
            this.AlertAjaxMessage("ɾ���ɹ���");
            this.RefreshGrid();
		}


		protected void btnExcel_ServerClick(object sender, System.EventArgs e)
		{
            if (hidSelectedFields.Value != "")
            {
                oListPage.GenerateExcelGrid_SelectColumns(this.lblTableName.Text,
                   "",
                   "",
                   0,
                   hidSelectedFields.Value
                   );
            }
            else
            {
                this.AlertAjaxMessage("��ѡ�񵼳����ֶΣ�");
            }
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

   }
}


