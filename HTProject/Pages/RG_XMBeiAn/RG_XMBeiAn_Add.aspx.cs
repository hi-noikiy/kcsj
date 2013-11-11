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
using System.Text;
using System.Data.SqlClient;
using System.Collections.Specialized;
using Epoint.Web.UI.WebControls2X;
using Epoint.Frame.Common;
using HTProject_Bizlogic;
namespace HTProject.Pages.RG_XMBeiAn
{

    public partial class RG_XMBeiAn_Add : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2021;
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        Epoint.MisBizLogic2.Web.AddPage oAddPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oAddPage.TableDetail.TableName;
                #region �ж��Ƿ��Ǹ�������Ǹ�������û�и����RowID���Զ�ת����Ӧ������
                string ParentRowGuid = Request.QueryString["ParentRowGuid"];
                if (oAddPage.TableDetail.TableType == 2)
                {
                    if (ParentRowGuid == null || ParentRowGuid == "")
                    {
                        this.AlertAjaxMessage("��ֱֹ�Ӷ��ӱ���Ӽ�¼��");
                        return;
                    }
                }
                #endregion
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
                //����ϴ��ļ��Ĵ�С�����ͼ��
                this.Add_FileUploadCheck_Script();

                //��ȡ���ʵȼ���֤��
                //string strSql = "select * from RG_QiYeZiZhi where ZiZhiEndDate>='"+ DateTime.Now.ToString("yyyy-MM-dd") +"' and DelStatus='1' and Status='90' and DWGuid='" + Request["DWGuid"]+"' ";
                DataView dv = RG_DW.GetZiZhiByDWGuid(Request["DWGuid"]); //Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
                ZiZHiDJ.DataSource = dv;
                ZiZHiDJ.DataTextField = "ZiZhiText";
                ZiZHiDJ.DataValueField = "RowGuid";
                ZiZHiDJ.DataBind();
                if (dv.Count > 0)
                {
                    ZiZhiDJ_2021.Text = dv[0]["ZiZhiText"].ToString();
                    ZiZhiDJCode_2021.Text = dv[0]["ZiZhiTextCode"].ToString();
                    ZiZhiDJRowGuid_2021.Text = dv[0]["RowGuid"].ToString();
                    ZiZhiBH_2021.Text = dv[0]["ZiZhiCode"].ToString();
                }
                lblTips.Text = RG_DW.GetTip("60", "Add","0","");
                string strSql = "SELECT EnterpriseName FROM RG_OUInfo WHERE RowGuid='" + Request["DWGuid"] + "'";
                DWName_2021.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            }
        }


        override protected void OnInit(EventArgs e)
        {
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);
            base.OnInit(e);
        }


        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            string RowGuid = Guid.NewGuid().ToString();
            DWGuid_2021.Text = Request["DWGuid"];
            DelStatus_2021.SelectedValue = "0";
            if (RG_DW.IsExistZZGX(ZiZhiDJCode_2021.Text))
            {
                if (oAddPage.SaveTableValues_CheckExist(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]))
                {
                    //��������רҵ�Ķ�Ӧ��ϵ���Ƴ���Ŀ��רҵ�Ķ�Ӧ��ϵ

                    RG_DW.CopyZZZYToXM(ZiZhiDJCode_2021.Text, RowGuid, Request["DWGuid"]);
                    WriteAjaxMessage("window.location.href='RG_XMBeiAn_Edit.aspx?RowGuid=" + RowGuid + "';alert('����ɹ�');refreshParent();");

                }
            }
            else
            {
                this.WriteAjaxMessage("alert('����ҵ/ר��/������û������רҵ������ϵ����Ա');");
            }
        }

        protected void ZiZHiDJ_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv = RG_DW.GetZiZhiByDWGuid(Request["DWGuid"]);
            dv.RowFilter = "RowGuid='" + ZiZHiDJ.SelectedItem.Value + "'";

            if (dv.Count > 0)
            {
                ZiZhiDJ_2021.Text = dv[0]["ZiZhiText"].ToString();
                ZiZhiDJCode_2021.Text = dv[0]["ZiZhiTextCode"].ToString();
                ZiZhiDJRowGuid_2021.Text = dv[0]["RowGuid"].ToString();
                ZiZhiBH_2021.Text = dv[0]["ZiZhiCode"].ToString();
            }
        }


    }
}


