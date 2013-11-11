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
using Microsoft.Practices.EnterpriseLibrary.Data;
using Epoint.Web.UI.WebControls2X;
using System.Data.Common;

namespace EpointRegisterUser.Pages_RG.RG_CaiWu
{

    public partial class RG_YueDuCaiWu_FenXi : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2020;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        Epoint.MisBizLogic2.Web.DetailPage oDetailPage;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //�����
                for (int year = 2012; year <= DateTime.Now.Year; year++)
                {
                    DDLYear.Items.Add(new ListItem(year.ToString(),year.ToString()));
                }
                DDLYear.SelectedValue = DateTime.Now.Year.ToString();

                BindAllChart();
            }

        }

        protected void BindAllChart()
        {
            string Month = DateTime.Now.Month.ToString("D2");
            string sql = string.Format("select isnull(HuiBiZiJin,0) as HuiBiZiJin,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, DateTime.Now.Month.ToString("D2"));
            //�����ʽ�
            BindData(chart_HuoBiZiJin, sql, ChartType.Column, "Month", "HuiBiZiJin");

            //BindHuoBiZiJin();

            //����Ӧ�տ�
            //BindQiTaYingShou();
            sql = string.Format("select isnull(OtherShouKuan,0) as OtherShouKuan,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_QiTaYingShou, sql, ChartType.Column, "Month", "OtherShouKuan");
            //chart_QiTaYingShou.AxesX.Title = DDLYear.SelectedValue + "-�·�";

            //Ӧ���˿�
            //BindYingShouZhangKuan();
            sql = string.Format("select isnull(YingShouZhangKuan,0) as YingShouZhangKuan,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_YingShouZhangKuan, sql, ChartType.Column, "Month", "YingShouZhangKuan");

            //���
            //BindCunHuo();
            sql = string.Format("select isnull(CunHuo,0) as CunHuo,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_CunHuo, sql, ChartType.Column, "Month", "CunHuo");

            //�����ʲ�
            sql = string.Format("select isnull(LiuDongZiChan,0) as LiuDongZiChan,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_LiuDongZiChan, sql, ChartType.Column, "Month", "LiuDongZiChan");

            //���ʲ�
            sql = string.Format("select isnull(ZongZiChan,0) as ZongZiChan,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_ZongZiChan, sql, ChartType.Column, "Month", "ZongZiChan");

            //������ծ
            sql = string.Format("select isnull(LiuDongFuZhai,0) as LiuDongFuZhai,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_LiuDongFuZhai, sql, ChartType.Column, "Month", "LiuDongFuZhai");

            //�ܸ�ծ
            sql = string.Format("select isnull(ZongFuZhai,0) as ZongFuZhai,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_ZongFuZhai, sql, ChartType.Column, "Month", "ZongFuZhai");

            //������Ȩ��
            sql = string.Format("select isnull(SuoYouZheQY,0) as SuoYouZheQY,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_SuoYouQuanYi, sql, ChartType.Column, "Month", "SuoYouZheQY");

            //����������
            sql = string.Format("select isnull(DangQiZongShouRu,0) as DangQiZongShouRu,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_ZongShouRu, sql, ChartType.Column, "Month", "DangQiZongShouRu");

            //��Ӫҵ������
            sql = string.Format("select isnull(ZhuYingShouRu,0) as ZhuYingShouRu,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_ZhuYingShouRu, sql, ChartType.Column, "Month", "ZhuYingShouRu");

            //ë����
            sql = string.Format("select isnull(MaoLiLv,0) as MaoLiLv,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_MaoLiLv, sql, ChartType.Column, "Month", "MaoLiLv");

            //�������
            sql = string.Format("select isnull(GuanLiFeiYong,0) as GuanLiFeiYong,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_GuanLiFei, sql, ChartType.Column, "Month", "GuanLiFeiYong");

            //�з�����
            sql = string.Format("select isnull(YanFaFeiYong,0) as YanFaFeiYong,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_YanFaFei, sql, ChartType.Column, "Month", "YanFaFeiYong");

            //��������
            sql = string.Format("select isnull(DangQiLiRun,0) as DangQiLiRun,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_DangQiLiRun, sql, ChartType.Column, "Month", "DangQiLiRun");

            //���ھ�����
            sql = string.Format("select isnull(DangQiJingLiRun,0) as DangQiJingLiRun,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_DangQiJingLi, sql, ChartType.Column, "Month", "DangQiJingLiRun");

            //Ӫ���ʱ�
            sql = string.Format("select (isnull(LiuDongZiChan,0)-isnull(LiuDongFuZhai,0)) as YingYun,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_YingYun, sql, ChartType.Column, "Month", "YingYun");

            //��������  isnull(NULLIF(LiuDongFuZhai,0),1)
            sql = string.Format("select (isnull(LiuDongZiChan,0)/isnull(NULLIF(LiuDongFuZhai,0),1)) as YingYun,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_LiuDongBiLv, sql, ChartType.Column, "Month", "YingYun");

            //�ʲ���ծ��  isnull(NULLIF(ZongZiChan,0),1)
            sql = string.Format("select (isnull(ZongFuZhai,0)/isnull(NULLIF(ZongZiChan,0),1))*100 as YingYun,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_ZiChanFuZhaiLv, sql, ChartType.Column, "Month", "YingYun");

            //���۾�����  isnull(NULLIF(ZhuYingShouRu,0),1)
            sql = string.Format("select (isnull(DangQiJingLiRun,0)/isnull(NULLIF(ZhuYingShouRu,0),1))*100 as YingYun,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_XiaoShouJingLiLv, sql, ChartType.Column, "Month", "YingYun");

            //���ʲ�������  isnull(NULLIF(ZongZiChan,0),1)
            sql = string.Format("select (isnull(DangQiJingLiRun,0)/isnull(NULLIF(ZongZiChan,0),1))*100 as ZongZiLv,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_ZongZiChanJingLiLv, sql, ChartType.Column, "Month", "ZongZiLv");

            //Ȩ�澻����  isnull(NULLIF(SuoYouZheQY,0),1)
            sql = string.Format("select (isnull(DangQiJingLiRun,0)/isnull(NULLIF(SuoYouZheQY,0),1))*100 as QuanYiLv,[Month] from RG_YueDuCaiWu where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            BindData(chart_QuanYiJingLiLv, sql, ChartType.Column, "Month", "QuanYiLv");

            //н���ܶ�
            //sql = string.Format("select (isnull(DangQiJingLiRun,0)/isnull(SuoYouZheQY,1))*100 as QuanYiLv,[Month] from RG_OtherInfo where DWGuid='{0}' and Year='{1}' and isHistory='0' order by Month asc", Request["DWGuid"], DDLYear.SelectedValue, Month);
            //BindData(chart_XinChou, sql, ChartType.Column, "Month", "QuanYiLv");
        }

        protected void BindData(Chart Chart_B, string strSql, ChartType CT, string XField, string YField)
        {
            Database db = DatabaseFactory.CreateDatabase(Epoint.Frame.Bizlogic.Conn.GetConnectionStringName("EpointMis_ConnectionString"));
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            DataView dv = db.ExecuteDataView(cmd);
            Chart_B.ChartSeries = new DataSeriesCollection(dv);
            DataSeries ds = new DataSeries(CT, "", XField, YField, null);
            Chart_B.ChartSeries.Add(ds);

            Chart_B.BindChart();
        }

        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            BindAllChart();
        }
    }
}

