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
namespace HTProject.Pages.RG_QYUser
{

    public partial class RG_QYUser_Add_Card : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 2019;
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
            if (cardJPG.Text != "")
            {
                //CardIMG_2019.Text = Convert.FromBase64String(cardJPG.Text);
                CardImgType_2019.Text = "image/pjpeg";                
            }
            else
            {
                this.WriteAjaxMessage("alert('��Ǹ�������µ��[����]��ȡ��Ƭ��[����]��');");
                return;
            }
            //�ж������֤s�Ƿ��Ѿ�����
            string oName = "";
            if(RG_DW.IsExistByIDNO(IDNum_2019.Text.Trim(),out oName))
            {
                this.WriteAjaxMessage("alert('�����֤�Ѿ����ڣ�����Ϊ��" + oName + "');");
                return;
            }
            
            DWGuid_2019.Text = Request["DWGuid"];
            DelStatus_2019.SelectedValue = "0";
            Status_2019.Text = "60";
            string strSql = "select ZuZhiJGDM from RG_OUInfo where RowGuid='" + Request["DWGuid"] + "'";
            ZuZhiJGDM_2019.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            if (oAddPage.SaveTableValues_CheckExist(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]))
            {
                if (cardJPG.Text != "")
                {
                    Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oAddPage.TableDetail.SQL_TableName, RowGuid);
                    //strSql = "UPDATE RG_QYUser SET CardIMG='" + Convert.FromBase64String(cardJPG.Text) + "' where RowGuid='" + RowGuid + "'";
                    //Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);
                    oRow["CardIMG"] = Convert.FromBase64String(cardJPG.Text);
                    oRow.Update();
                }
                this.WriteAjaxMessage("window.location.href='RG_QYUser_Edit_Card.aspx?RowGuid=" + RowGuid + "&DWGuid=" + Request["DWGuid"] + "';alert('����ɹ�');refreshParent();");
            }
        }

        protected void btID_Click(object sender, System.EventArgs e)
        {
            string oName = "";
            if (RG_DW.IsExistByIDNO(IDNum_2019.Text.Trim(), out oName))
            {
                IDNum_2019.Text = "";
                this.WriteAjaxMessage("alert('�����֤�Ѿ����ڣ�����Ϊ��" + oName + "');");
                return;
            }
        }

    }
}


