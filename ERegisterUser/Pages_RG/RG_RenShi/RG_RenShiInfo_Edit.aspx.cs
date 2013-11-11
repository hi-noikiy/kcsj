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

    public partial class RG_RenShiInfo_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 2022;
        Epoint.MisBizLogic2.Web.EditPage oEditPage;
        Epoint.MisBizLogic2.Web.AddPage oAddPage;
        Epoint.MisBizLogic2.Web.ListPage oListPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string DWGuid = "";
                string RowGuid = "";
                string strURL = "";
                //���ж��Ƿ�����ת������
                if (String.IsNullOrEmpty(Request["RowGuid"]))//������ת
                {
                    //�ж���û�м�¼�����û�м�¼�Ļ�����ֱ����ת������ҳ��
                    string strSql = " select top(1) DWGuid from rg_ouinfo where DWGuid=(select distinct DanWeiGuid from RG_User where RowGuid='" + Session["UserGuid"].ToString() + "') order by row_id desc ";
                    DWGuid = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                    strSql = " select top(1) RowGuid from RG_RenShiInfo   where DWGuid='" + DWGuid + "' order by row_id desc  ";
                    RowGuid = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                    if (RowGuid == "")//˵��û�м�¼������ת������ҳ��
                    {
                        strURL = "RG_RenShiInfo_Add.aspx?ParentRowGuid=&RowGuid=" + Guid.NewGuid().ToString() + "&DWGuid=" + DWGuid + "";
                        this.WriteAjaxMessage("window.location.href='" + strURL + "';");
                        return;
                    }
                    else//����м�¼��ҲҪ��ת����ҳ�����¼���
                    {
                        strURL = "RG_RenShiInfo_Edit.aspx?RowGuid=" + RowGuid + "&DWGuid=" + DWGuid + "";
                        this.WriteAjaxMessage("window.location.href='" + strURL + "';");
                        return;
                    }
                }
                else//����ת
                {
                    RowGuid = Request["RowGuid"];
                    DWGuid = Request["DWGuid"];
                }

                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, RowGuid);
                if (!oRow.R_HasFilled)
                {
                    btnEdit.Visible = false;
                    this.AlertAjaxMessage("û�ж�Ӧ�����ݼ�¼��");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
                //����ϴ��ļ��Ĵ�С�����ͼ��
                this.Add_FileUploadCheck_Script();

                RefreshGrid();

                if (Status_2022.Text == EpointRegisterUser_Bizlogic.OUStatus.�����)
                {
                    btnEdit.Visible = false;
                }
                if (HaiGuiInfo_2022.Text != "" && HaiGuiInfo_2022.Text.Trim() != "��������ҵԺУ����Ҫ��������������˾����ְ���")
                {
                    HaiGuiInfo.Text = HaiGuiInfo_2022.Text;
                }
                #region
                if (this.s_qiJian_2022.Text == "")
                {
                    this.s_qiJian_2022.Text = DateTime.Now.ToString();
                }
                int thisYear = DateTime.Parse(this.s_qiJian_2022.Text.ToString()).Year;
                int thisMonth = DateTime.Parse(this.s_qiJian_2022.Text.ToString()).Month;
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
                #endregion
            }
        }


        override protected void OnInit(EventArgs e)
        {
            oListPage = new Epoint.MisBizLogic2.Web.ListPage(TableID, Datagrid1, controlHolder, Pager, null);//���û�е���Excel��Grid��������Ϊnull
            oListPage.CustomMode = true;
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);
            base.OnInit(e);
        }

        #region �б�
        private void RefreshGrid()
        {
            string str = "";

            str += " and DWGuid='" + Request["DWGuid"] + "' and RowGuid<>'" + Request["RowGuid"] + "' ";
            oListPage.OtherCondition += str;
            oListPage.SortExpression = " order by row_id asc ";
            oListPage.GenerateSearchResult();
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

        protected string GetStatus(object Status)
        {
            if (Status.ToString() != "0")
            {
                return EpointRegisterUser_Bizlogic.OUStatus.GetTextByValue(Status.ToString());
            }
            return "";
        }
        #endregion
        Epoint.Messages.Bizlogic.DB_Messages_Center msg = new Epoint.Messages.Bizlogic.DB_Messages_Center();
        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            string RowGuid = Request["RowGuid"];
            string DWGuid = Request["DWGuid"];
            string strSql = "SELECT top(1) EnterpriseName FROM RG_OUInfo WHERE dwGuid='" + DWGuid + "' order by row_ID desc";
            string EnterpriseName = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            //�Ȼ�ȡͶ�ʾ���            
            strSql = "SELECT s_xiangmujl_guid,s_xiangmujl FROM VIEW_CurrentVersion WHERE dwGuid='" + DWGuid + "'";
            DataView dvUser = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            if (dvUser.Count == 0)
            {
                WriteAjaxMessage("����ҵû�ж�Ӧ����Ŀ������ϵϵͳ����Ա��");
                return;
            }
            //�ж��ǲ����Ѿ�����
            this.s_qiJian_2022.Text = this.jpdYear.SelectedValue + "-" + this.jpdMonth.SelectedValue + "-" + "1";
            HaiGuiInfo_2022.Text = HaiGuiInfo.Text;
            if (HaiGuiInfo_2022.Text.Trim() == "��������ҵԺУ����Ҫ��������������˾����ְ���")
            {
                HaiGuiInfo_2022.Text = "";
            }
             strSql = string.Format("select count(*) from RG_RenShiInfo where DWGuid='{0}'", Request["DWGuid"]);
            if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) == "1")//˵��û��
            {
                //�ύʱֱ���ύ�����ñ���汾
                UpdateUserName_2022.Text = this.DisplayName;
                UpdateUserGuid_2022.Text = this.UserGuid;
                UpdateTime_2022.Text = DateTime.Now.ToString();
                Status_2022.Text = EpointRegisterUser_Bizlogic.OUStatus.�����;
                IsHistory_2022.Text = "0";
                oEditPage.SaveTableValues(RowGuid, tdContainer);
            }
            else
            {
                //�Ƚ�ԭ��������Ϊ��ʷ��¼
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                oRow["IsHistory"] = "1";
                //oRow["UpdateUserName"] = this.DisplayName;
                //oRow["UpdateUserGuid"] = this.UserGuid;
                //oRow["UpdateTime"] = DateTime.Now;
                oRow.Update();
                //Ȼ���ٽ����汾�����ύ���
                UpdateUserName_2022.Text = this.DisplayName;
                UpdateUserGuid_2022.Text = this.UserGuid;
                UpdateTime_2022.Text = DateTime.Now.ToString();
                Status_2022.Text = EpointRegisterUser_Bizlogic.OUStatus.�����;
                IsHistory_2022.Text = "0";
                RowGuid = Guid.NewGuid().ToString();
                oAddPage.SaveTableValues(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]);
            }

            #region ֪ͨͶ�ʾ���
            
            for (int m = 0; m < dvUser.Count; m++)
            {
                msg.WaitHandle_Insert(
                                Guid.NewGuid().ToString(),
                                "����ˡ�" + EnterpriseName + "������Ϣ",
                                "",
                                dvUser[m]["s_xiangmujl_guid"].ToString(),
                                dvUser[m]["s_xiangmujl"].ToString(),
                                Session["UserGuid"].ToString(),
                                Session["DisplayName"].ToString(),
                                "",
                                "EpointRegisterUser/Pages_RG/RG_RenShi/RG_RenShiInfo_DetailForCheck.aspx?RowGuid=" + RowGuid + "&DWGuid=" + DWGuid,
                                "",
                                "",
                                1,
                                "",
                                "",
                                ""
                         );
            }

            #endregion
            this.WriteAjaxMessage("alert('�ύ�ɹ�');");
            RefreshGrid();

            btnEdit.Visible = false;

        }

        protected string GetJD(object s_qiJian)
        {
            string qijian = s_qiJian.ToString();
            string JD = "";
            if (qijian.ToString() != "")
            {
                try
                {
                    int thisYear = DateTime.Parse(qijian).Year;
                    int thisMonth = DateTime.Parse(qijian).Month;

                    JD += thisYear.ToString() + "��";
                    if (thisMonth.ToString() == "1" || thisMonth.ToString() == "2" || thisMonth.ToString() == "3")
                    {
                        JD += "1����";
                    }
                    else if (thisMonth.ToString() == "4" || thisMonth.ToString() == "5" || thisMonth.ToString() == "6")
                    {
                        JD += "2����";
                    }
                    else if (thisMonth.ToString() == "7" || thisMonth.ToString() == "8" || thisMonth.ToString() == "9")
                    {
                        JD += "3����";
                    }
                    else
                    {
                        JD += "4����";
                    }
                    return JD;
                }
                catch
                {
                    return JD;
                }
            }
            return JD;
        }
    }
}
