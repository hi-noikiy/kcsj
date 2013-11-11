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
using HTProject_Bizlogic;

namespace HTProject.Pages.RG_XMBeiAn
{

    public partial class RG_XMBeiAn_Detail : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2021;

        Epoint.MisBizLogic2.Web.DetailPage oDetailPage;

        protected HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                ViewState["TableName"] = oDetailPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oDetailPage.TableDetail.SQL_TableName, Request["RowGuid"]);

                if (!oRow.R_HasFilled)
                {
                    //lblMessage.Visible=true;
                    this.AlertAjaxMessage("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_DetailPage(oDetailPage, tdContainer, oRow);
                BindZhuanYe();
                //HTBA.ClientGuid = Request["RowGuid"] + "HTBA";
                //HTBA.NodeCode = DWGuid_2021.Text;
                //HTBA.MisRowGuid = Request["RowGuid"];
                XM_HTBA.ClientGuid = Request["RowGuid"] + "XM_HTBA";
                XM_HTBA.NodeCode = DWGuid_2021.Text;
                XM_HTBA.MisRowGuid = Request["RowGuid"];
                XM_HTBA.Status = oRow["Status"].ToString();

                SJHT.ClientGuid = Request["RowGuid"] + "XM_SJHT";
                SJHT.NodeCode = DWGuid_2021.Text;
                SJHT.MisRowGuid = Request["RowGuid"];

                QY_CXZM.ClientGuid = Request["RowGuid"] + "QY_CXZM";
                QY_CXZM.NodeCode = DWGuid_2021.Text;
                QY_CXZM.MisRowGuid = Request["RowGuid"];

                lblSHOpinion.Text = RG_DW.GetSHOpinion(Request["RowGuid"], "");

                //WriteAjaxMessage("window.moveTo(-4, -4);");
                //WriteAjaxMessage("window.resizeTo(screen.availWidth + 8, screen.availHeight + 8);");
                string QYZCD2 = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT RegistAddressCode FROM RG_OUInfo WHERE RowGuid='" + DWGuid_2021.Text + "'");
                if (QYZCD2.Substring(0, 2) == "32")
                {
                    lblTips.Text = RG_DW.GetTip(oRow["Status"], "", "0", oRow["XMAdd"].ToString());
                }
                else
                {
                    lblTips.Text = RG_DW.GetTip(oRow["Status"], "", "1", oRow["XMAdd"].ToString());
                }
            }
            //如果是省内的，就不要显示
            string QYZCD = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT RegistAddressCode FROM RG_OUInfo WHERE RowGuid='" + DWGuid_2021.Text + "'");
            if (QYZCD.Substring(0, 2) == "32")
            {
                XM_HTBA.SAdd = "SN";
                YeWuFW_2021.Visible = false;
                FuZaCD_2021.Visible = false;
                WriteAjaxMessage("document.getElementById('trFW').style.display = 'none';");
                WriteAjaxMessage("document.getElementById('trFZ').style.display = 'none';");
            }
            else
            {
                XM_HTBA.SAdd = "SW";
            }

        }

        override protected void OnInit(EventArgs e)
        {
            oDetailPage = new Epoint.MisBizLogic2.Web.DetailPage(TableID);
            base.OnInit(e);
        }

        protected void BindZhuanYe()
        {
            string strSql = " select * from RG_XMAndZY where 1=1  and XMGuid='" + Request["RowGuid"] + "' ";
            strSql += " and DWGuid='" + DWGuid_2021.Text + "' and ZiZhiCode='" + ZiZhiDJCode_2021.Text + "' ";
            strSql += " ORDER BY ZhuanYeCode ASC ";
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            DGZhuanYe.DataSource = dv;
            DGZhuanYe.DataBind();
        }

        protected DataView GetRY(object ZhuanYeCode)
        {
            string strSql = " select * from RG_XMAndRY RY where 1=1  and XMGuid='" + Request["RowGuid"] + "' ";
            strSql += " and DWGuid='" + DWGuid_2021.Text + "' and ZiZhiCode='" + ZiZhiDJCode_2021.Text + "' and ZhuanYeCode='" + ZhuanYeCode + "' ";
            strSql += " ORDER BY RY.ZhuanYeCode asc,RY.DDRole desc ";
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            return dv;
        }
        protected void btnXZ_Click(object sender, System.EventArgs e)
        {
            bool IsND = false;//如果是省外、年度备案企业，则更改为true；
            #region 对企业进行判断
            string strSql = "SELECT IsNDBA,RegistAddress,* FROM RG_OUInfo WHERE ROWGUID='" + DWGuid_2021.Text + "'";
            string qyzcd = "";
            DataView dvQY = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            if (dvQY.Count > 0)
            {
                qyzcd = dvQY[0]["RegistAddressCode"].ToString().Substring(0, 2);
                if (dvQY[0]["IsNDBA"].ToString() == "1" && qyzcd != "32")
                {
                    IsND = true;
                }

            }
            #endregion
            //string QYZCD = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT RegistAddressCode FROM RG_OUInfo WHERE RowGuid='" + DWGuid_2021.Text + "'");
            if (qyzcd == "32")
            {
                WriteAjaxMessage("OpenWindow('../Print/BeiAnPrint.aspx?RowGuid=" + Request["RowGuid"] + "', '800', '700');");
            }
            else
            {
                if (IsND)
                {
                    WriteAjaxMessage("OpenWindow('../Print/BeiAnPrint_ND.aspx?RowGuid=" + Request["RowGuid"] + "', '800', '700');");
                }
                else
                {
                    WriteAjaxMessage("OpenWindow('../Print/BeiAnPrint_WS.aspx?RowGuid=" + Request["RowGuid"] + "', '800', '700');");
                }
            }

        }
    }
}

