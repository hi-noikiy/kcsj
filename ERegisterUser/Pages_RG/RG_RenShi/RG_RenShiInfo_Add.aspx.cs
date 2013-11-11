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

namespace EpointRegisterUser.Pages_RG.RG_RenShi
{
 
    public partial class RG_RenShiInfo_Add : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
	
	public int TableID=2022;		

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
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage,tdContainer);
                //����ϴ��ļ��Ĵ�С�����ͼ��
                this.Add_FileUploadCheck_Script();

                int thisYear = DateTime.Now.Year;
                int thisMonth = DateTime.Now.Month;
                for (int i = thisYear - 15; i <= thisYear; i++)
                {
                    jpdYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                for (int i = 1, tag = 1; i <= 12; i = i + 3, tag++)
                {
                    jpdMonth.Items.Add(new ListItem(tag.ToString(), i.ToString()));
                }

                jpdYear.SelectedValue = thisYear.ToString();
                if (thisMonth.ToString() == "1" || thisMonth.ToString() == "2" || thisMonth.ToString() == "3")
                {
                    jpdMonth.SelectedIndex = 0;
                }
                else if (thisMonth.ToString() == "4" || thisMonth.ToString() == "5" || thisMonth.ToString() == "6")
                {
                    jpdMonth.SelectedIndex = 1;
                }
                else if (thisMonth.ToString() == "7" || thisMonth.ToString() == "8" || thisMonth.ToString() == "9")
                {
                    jpdMonth.SelectedIndex = 2;
                }
                else
                {
                    jpdMonth.SelectedIndex = 3;
                }

                //HaiGuiInfo_2022.Attributes.AddAttributes("Value='��������ҵԺУ����Ҫ��������������˾����ְ��Ŀ��'");
            }

        }


        override protected void OnInit(EventArgs e)
        {
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);           
            base.OnInit(e);
        }


        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            //string RowGuid = Guid.NewGuid().ToString();
            //oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);

            ////����Ǹ���Ҫת����༭ҳ��
            //if (oAddPage.TableDetail.TableType == 1)
            //{
            //    Response.Redirect("MultiPageTab.aspx?mode=Mode&TableID=" + oAddPage.TableDetail.TableID + "&RowGuid=" + RowGuid);
            //}
            //else
            //{
            //    this.WriteAjaxMessage ("refreshParent();");
            //}
            //Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
            //this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'���ݱ���ɹ�')");           

            string RowGuid = Request["RowGuid"];
            string DWGuid = Request["DWGuid"];
            this.s_qiJian_2022.Text = this.jpdYear.SelectedValue + "-" + this.jpdMonth.SelectedValue + "-" + "1";
            HaiGuiInfo_2022.Text = HaiGuiInfo.Text;
            if (HaiGuiInfo_2022.Text.Trim() == "��������ҵԺУ����Ҫ��������������˾����ְ���")
            {
                HaiGuiInfo_2022.Text = "";
            }
            UpdateUserName_2022.Text = this.DisplayName;
            UpdateUserGuid_2022.Text = this.UserGuid;
            IsHistory_2022.Text = "0";
            UpdateTime_2022.Text = DateTime.Now.ToString();
            Status_2022.Text = EpointRegisterUser_Bizlogic.OUStatus.�༭��;//0:�༭   1�������   2��ͨ��
            DWGuid_2022.Text = DWGuid;
            string strSql = " select top(1) EnterpriseName from rg_ouinfo where DWGuid='" + Request["DWGuid"] + "' order by row_id desc ";
            DWName_2022.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);

            string url = "RG_RenShiInfo_Edit.aspx?RowGuid=" + RowGuid + "&DWGuid=" + DWGuid + "&sType=0";
            this.WriteAjaxMessage("alert('��ӳɹ�');window.location.href='" + url + "';");

        }		

    }
}


