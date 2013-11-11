using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Epoint.RegisterUser.DataSyn.Bizlogic;

namespace EpointRegisterUser.Pages.RG_User
{
    public partial class RecordCheck_List : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster 
    {
        public int TableID = 99;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblTableName.Text = oListPage.TableDetail.TableName;
                //this.CurrentHead   = oListPage.TableDetail.TableName;				
                this.RefreshGrid();
            }

        }

        override protected void OnInit(System.EventArgs e)
        {
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, null);//���û�е���Excel��Grid��������Ϊnull
            //�˴����ȫ��ͨ������ 
            //oListPage.OtherCondition = " and (UserStatus is null or Userstatus=001) or IsValid=0";
            oListPage.CustomMode = true;
            oListPage.SortExpression = " order by Row_ID desc";
            //�˷������ɾ����λ���⡣����ʹ��ѯ������ֵ�Զ���ViewState�лָ���
            controlHolder.Controls.Add(oListPage.RenderSearchCondition());
            base.OnInit(e);
        }


        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            Pager.CurrentPageIndex = 0;
            this.RefreshGrid();
        }

        protected void statusSel_Changed(object sender, System.EventArgs e)
        {
            this.RefreshGrid();
        }
        private void RefreshGrid()
        {
            switch (statusSel.SelectedValue)
            {
                case "0":
                    oListPage.OtherCondition = " and UserStatus=001 and DelFlag=0";
                    break;
                case "1":
                    oListPage.OtherCondition = " and UserStatus=002";
                    break;
                case "2":
                    oListPage.OtherCondition = " and UserStatus=002 and IsValid=1 and DelFlag=0";
                    break;
                case "3":
                    oListPage.OtherCondition = " and UserStatus=002 and DelFlag=1 and IsValid=0";
                    break;
                case "all":
                    oListPage.OtherCondition = "";
                    break;
                default:
                    break;
            }
            //oListPage.OtherCondition += " and (DelFlag=0 or DelFlag is null)";
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
                    Epoint.MisBizLogic2.DB.ExecuteNonQuery("update RG_User set DelFlag=1 where RowGuid='" + Convert.ToString(Datagrid1.DataKeys[i]) + "'");
                    new ComDataSyn().UpdateWithKeyValue(DataSynTarget.BackEndToFront, "RG_User", "RowGuid", Convert.ToString(Datagrid1.DataKeys[i]));
                }
            }
            this.RefreshGrid();
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