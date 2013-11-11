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
using Epoint.Frame.Bizlogic;
using Epoint.Frame.Bizlogic.Code;
using Epoint.Frame.Bizlogic.OperationLog;
using Epoint.Common;

namespace HTProject.Pages.Code
{
    public partial class Code_Item_AddInfo : BaseContentPage_UsingMaster
    {
        private DB_Frame_Code_Item CodeItem = new DB_Frame_Code_Item();
        private string AddCode(string ItemCode, string MainGuid, int isAutoGenCode)
        {
            string itemGuid = Guid.NewGuid().ToString();
            string str2 = "";
            string itemCode = "";
            bool canSelect = false;
            DataView view = this.CodeItem.SelectNextOneLevel(MainGuid, ItemCode, out canSelect);
            if (view.Count == 0)
            {
                if (isAutoGenCode == 1)
                {
                    itemCode = ItemCode + "1".PadLeft(4, '0');
                }
                else
                {
                    DataView view2 = new DB_Frame_Code_Level().Select(MainGuid);
                    view2.RowFilter = "CurrentLevalBit>" + ItemCode.Length.ToString();
                    view2.Sort = " CurrentLevalBit asc ";
                    int num = 0;
                    if (view2.Count > 0)
                    {
                        num = Convert.ToInt32(view2[0]["CurrentLevalBit"]);
                    }
                    else
                    {
                        return "��ǰ��ӵĴ��뼶��δ�ڴ��뼶���ж��壬���ȶ�����뼶����";
                    }
                    itemCode = ItemCode + "1".PadLeft(num - ItemCode.Length, '0');
                }
                this.CodeItem.Insert(itemGuid, MainGuid, this.txtItemText.Text, this.txtItemValue.Text, itemCode, this.txtPinYinJc.Text, Functions.IntNull(this.txtOrderNumber.Text));
                DB_Frame_OperationLog.Insert(DB_Frame_OperationLog.LOG_OPERATOR_TYPE_ADD, DB_Frame_OperationLog.LOG_SUBSYSTEM_TYPE_Frame, this.Session["UserGuid"].ToString(), this.Session["DisplayName"].ToString(), "��Ӵ���������������ƣ�" + this.ViewState["CodeName"].ToString() + "���������Guid��" + this.ViewState["MainGuid"].ToString() + "�����������ƣ�" + this.txtItemText.Text + "������ֵ���ƣ�" + this.txtItemValue.Text + "��������ItemGuid��" + itemGuid, "", this.Session["BaseOUGuid"].ToString());
                return str2;
            }
            view.Sort = "ItemCode desc";
            string str4 = view[0]["ItemCode"].ToString();
            string str5 = str4.Substring(ItemCode.Length);
            itemCode = ItemCode + Convert.ToString((int)(Convert.ToInt32(str5) + 1)).PadLeft(str5.Length, '0');
            if (itemCode.Length > str4.Length)
            {
                return "��ǰ���뼶����λ���Ѿ���������Ĵ��뼶�����������¶�����뼶����";
            }
            this.CodeItem.Insert(itemGuid, MainGuid, this.txtItemText.Text, this.txtItemValue.Text, itemCode, this.txtPinYinJc.Text, Functions.IntNull(this.txtOrderNumber.Text));
            DB_Frame_OperationLog.Insert(DB_Frame_OperationLog.LOG_OPERATOR_TYPE_ADD, DB_Frame_OperationLog.LOG_SUBSYSTEM_TYPE_Frame, this.Session["UserGuid"].ToString(), this.Session["DisplayName"].ToString(), "��Ӵ���������������ƣ�" + this.ViewState["CodeName"].ToString() + "���������Guid��" + this.ViewState["MainGuid"].ToString() + "�����������ƣ�" + this.txtItemText.Text + "������ֵ���ƣ�" + this.txtItemValue.Text + "��������ItemGuid��" + itemGuid, "", this.Session["BaseOUGuid"].ToString());
            return str2;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string itemCode = this.ViewState["ItemCode"].ToString();
            string mainGuid = this.ViewState["MainGuid"].ToString();
            int isAutoGenCode = new DB_Frame_Code_Main().GetDetail(mainGuid).isAutoGenCode;
            if (this.CodeItem.CheckCodeItemTextIsExist(mainGuid, this.txtItemText.Text))
            {
                base.AlertAjaxMessage("�˴�����ʾ�����Ѿ��ظ��������������");
            }
            else if (this.CodeItem.CheckCodeItemValueIsExist(mainGuid, this.txtItemValue.Text))
            {
                base.AlertAjaxMessage("�˴�����ʾ�����Ѿ��ظ��������������");
            }
            else
            {
                string scriptValue = this.AddCode(itemCode, mainGuid, isAutoGenCode);
                if (scriptValue != "")
                {
                    base.AlertAjaxMessage(scriptValue);
                }
                else
                {
                    this.txtItemText.Text = "";
                    this.txtItemValue.Text = "";
                    this.txtOrderNumber.Text = "";
                    this.txtPinYinJc.Text = "";
                }
            }
        }

        protected void btnAddClose_Click(object sender, EventArgs e)
        {
            string itemCode = this.ViewState["ItemCode"].ToString();
            string mainGuid = this.ViewState["MainGuid"].ToString();
            int isAutoGenCode = new DB_Frame_Code_Main().GetDetail(mainGuid).isAutoGenCode;
            if (this.CodeItem.CheckCodeItemTextIsExist(mainGuid, this.txtItemText.Text))
            {
                base.AlertAjaxMessage("�˴�����ʾ�����Ѿ��ظ��������������");
            }
            else if (this.CodeItem.CheckCodeItemValueIsExist(mainGuid, this.txtItemValue.Text))
            {
                AlertAjaxMessage("�˴�����ʾ�����Ѿ��ظ��������������");
            }
            else
            {
                string scriptValue = this.AddCode(itemCode, mainGuid, isAutoGenCode);
                if (scriptValue != "")
                {
                    AlertAjaxMessage(scriptValue);
                }
                else
                {
                    WriteAjaxMessage("rtnValue('');");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CurrentPosition = "���������";
            this.CurrentTitle = "���������";
            this.Title = "���������";
            if (!this.Page.IsPostBack)
            {
                this.ViewState["ItemCode"] = Request["ItemCode"];
                this.ViewState["MainGuid"] = Request["MainGuid"];
                this.ViewState["CodeName"] = new DB_Frame_Code_Main().GetDetail(this.ViewState["MainGuid"].ToString()).CodeName;
                Detail_Frame_Code_Item item = new DB_Frame_Code_Item().GetDetail_ItemCode(this.ViewState["MainGuid"].ToString(), this.ViewState["ItemCode"].ToString());
                this.txtPreItemName.Text = item.ItemText;
                if (this.txtPreItemName.Text == "")
                {
                    this.txtPreItemName.Text = "��";
                }
            }
        }

    }
}
