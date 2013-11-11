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
using System.Text;
using HTProject_Bizlogic;

namespace HTProject.Pages.TongJi
{
    public partial class ZiZhiHeYan_SW : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 2021;
        //Epoint.MisBizLogic2.Web.ListPage oListPage;
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //lblTableName.Text = oListPage.TableDetail.TableName;
                //this.CurrentHead = oListPage.TableDetail.TableName;

                HYDate.FromText = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                //RG_DW.InitSHStatus(ddlStatus);

                this.RefreshGrid();

            }
        }

        override protected void OnInit(System.EventArgs e)
        {
            //oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, GridExcel);//如果没有导出Excel的Grid，就设置为null

            //此处添加全局通用条件 
            //oListPage.OtherCondition = "  and DelStatus='0' ";
            //if (!String.IsNullOrEmpty(Request["Status"]))
            //{
            //    oListPage.OtherCondition += " and Status in('" + Request["Status"].Replace(",", "','") + "') ";
            //}
            //if (!String.IsNullOrEmpty(Request["DWGuid"]))
            //{
            //    oListPage.OtherCondition += " and DWGuid='" + Request["DWGuid"] + "' ";
            //}
            //oListPage.SortExpression = " order by Row_ID desc";
            //oListPage.CustomMode = true;
            //此方法解决删除错位问题。可以使查询条件的值自动从ViewState中恢复。
            //controlHolder.Controls.Add(oListPage.RenderSearchCondition());

            base.OnInit(e);
        }


        protected void btnOK_Click(object sender, System.EventArgs e)
        {
            this.RefreshGrid();

        }

        protected void btnRefresh_Click(object sender, System.EventArgs e)
        {
            this.RefreshGrid();
        }

        private void RefreshGrid()
        {
            string strSql = "SELECT XMName,XMAddress,FuZaCD,ZiZhiDJ,YeWuFW,XMLXR_KS,LXDH_KS,TGDate,DWName,BeiZhu FROM RG_XMBeiAn BA WHERE 1=1 AND DelStatus='0' AND STATUS='90' ";
            //另外再加点时间的筛选
            if (HYDate.FromText != "")
            {
                strSql += " AND TGDate>='"+ HYDate.FromText +" 00:00:00' ";
            }
            if (HYDate.ToText != "")
            {
                strSql += " AND TGDate<='" + HYDate.ToText + " 23:00:00' ";
            }
            //还要排除无锡的
            strSql += " AND EXISTS(SELECT 1 FROM RG_OUINFO WHERE RegistAddressCode NOT LIKE '32%' AND RowGuid=BA.DWGUID) ";
            
            strSql += " order by Row_ID desc";
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);

            //开始生成表
            StringBuilder sb = new StringBuilder();
            sb.Append("<table width='100%' cellspacing='1' align='center' id='report'>");
            sb.Append("<tr><td height='26' align='center' colspan='11' style='font-size:24px'>省外勘察设计单位承接江苏省勘察设计业务单项工程资质核验汇总表</td></tr>");
            sb.Append("<tr><td height='26' align='center' colspan='11'>&nbsp;</td></tr>");
            sb.Append("<tr><td height='26' align='left' colspan='8'>单位名称：（加盖省辖市住房城乡建设主管部门公章）</td><td height='26' align='center' colspan='3'>" + DateTime.Now.ToString("yyyy年MM月dd日") + "</td></tr>");
            //形成表头
            sb.Append("<tr><td class='TableSpecial' height='26' align='center' width='30px'>序号</td>");
            sb.Append("<td class='TableSpecial' height='26' align='center'>项目各称</td>");
            sb.Append("<td class='TableSpecial' height='26' align='center'>项目地点</td>");
            sb.Append("<td class='TableSpecial' height='26' align='center' width='200px'>项目规模及复<br />杂程度</td>");
            sb.Append("<td class='TableSpecial' height='26' align='center'>项目所属<br />行业类别</td>");
            sb.Append("<td class='TableSpecial' height='26' align='center'>承接勘察设<br />计业务单位</td>");
            sb.Append("<td class='TableSpecial' height='26' align='center' width='200px'>单位资质等<br />级及业务范围</td>");
            sb.Append("<td class='TableSpecial' height='26' align='center' width='50px'>单位联<br />系人</td>");
            sb.Append("<td class='TableSpecial' height='26' align='center' width='100px'>联系人<br />电话</td>");
            sb.Append("<td class='TableSpecial' height='26' align='center' width='80px'>完成单项<br />工程资质<br />核验时间</td>");
            sb.Append("<td class='TableSpecial' height='26' align='center' width='100px'>备注</td></tr>");
            //组织数据
            for (int m = 0; m < dv.Count; m++)
            {
                sb.Append("<tr><td class='TableSpecial' height='26' align='center' width='30px'>" + (m + 1) + "</td>");
                sb.Append("<td class='TableSpecial' height='26' align='left'>" + dv[m]["XMName"] + "</td>");
                sb.Append("<td class='TableSpecial' height='26' align='left'>" + dv[m]["XMAddress"] + "</td>");
                sb.Append("<td class='TableSpecial' height='26' align='left' width='200px'>" + dv[m]["FuZaCD"] + "</td>");
                sb.Append("<td class='TableSpecial' height='26' align='left'>" + dv[m]["ZiZhiDJ"] + "</td>");
                sb.Append("<td class='TableSpecial' height='26' align='left'>" + dv[m]["DWName"] + "</td>");
                sb.Append("<td class='TableSpecial' height='26' align='left' width='200px'>" + dv[m]["YeWuFW"] + "</td>");
                sb.Append("<td class='TableSpecial' height='26' align='left' width='50px'>" + dv[m]["XMLXR_KS"] + "</td>");
                sb.Append("<td class='TableSpecial' height='26' align='left' width='100px'>" + dv[m]["LXDH_KS"] + "</td>");
                sb.Append("<td class='TableSpecial' height='26' align='left' width='80px'>" + (dv[m]["TGDate"].ToString() != "" ? DateTime.Parse(dv[m]["TGDate"].ToString()).ToString("yyyy-MM-dd") : "") + "</td>");
                sb.Append("<td class='TableSpecial' height='26' align='left' width='100px'>" + dv[m]["BeiZhu"] + "</td></tr>");
            }
            //结束
            sb.Append("</table>");
            tdExcel.InnerHtml = sb.ToString();
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

