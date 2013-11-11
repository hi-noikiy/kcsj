using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Epoint.Frame.Bizlogic;
using Epoint.Messages.Bizlogic;
using Epoint.Frame.Common;

namespace HTProject.Pages.WaitBL
{
    public partial class WaitHandle_NeedHandle_Banli : BaseContentPage_UsingMaster
    {
        HTProject_Bizlogic.DB_Messages_Center Msg = new HTProject_Bizlogic.DB_Messages_Center();
        HTProject_Bizlogic.Detail_Messages_Center detail_msg = new HTProject_Bizlogic.Detail_Messages_Center();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //this.CurrentPosition = "�����";

                //DataView dv = Msg.GetWaitHandleType();
                //dropType.DataSource = dv;
                //dropType.DataTextField = "HandleType";
                //dropType.DataValueField = "HandleType";
                //dropType.DataBind();
                //dropType.Items.Insert(0, new ListItem("����", ""));
                //if (dropType.Items.Count == 1)
                //{
                //    dropType.Visible = false;
                //    tdtype.Visible = false;
                //}

                String WaitHandleShowArchiveNo = new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("WaitHandleShowArchiveNo").ConfigValue;
                if (WaitHandleShowArchiveNo == "1")
                {
                    tdArchiveS1.Style.Add("display", "");
                    tdArchiveS2.Style.Add("display", "");

                    //for(int i = 0; i < GridHandle.Columns.Count; i++)
                    //{
                    //    if(GridHandle.Columns[i].HeaderText == "�ĺ�")
                    //    {
                    //    }
                    //}
                }
                else
                {
                    tdArchiveS1.Style.Add("display", "none");
                    tdArchiveS2.Style.Add("display", "none");

                    for (int i = 0; i < GridHandle.Columns.Count; i++)
                    {
                        if (GridHandle.Columns[i].HeaderText == "�ĺ�")
                            GridHandle.Columns[i].Visible = false;
                    }
                }


                btnAddFavorite.Visible = !(new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("Favorite_NoCanAdd").ConfigValue == "1");


                dropType.Visible = false;
                tdtype.Visible = false;

                btn_Huanban.Visible = false; //ApplicationOperate.IsNeedHuanBan;

                Pager.PageSize = Convert.ToInt32(Session["GridItemsCount"]);
                AspNetPager1.PageSize = Convert.ToInt32(Session["GridItemsCount"]);
                BindGrid();
            }
        }


        protected void BindGrid()
        {
            int TotalNum = 0;
            string HandleType = "";// dropType.SelectedItem.Value;
            DataView Dv = Msg.WaitHandle_PageView(
                this.UserGuid,
                this.JobLst,
                0,
                DateFromTo.FromValue,
                DateFromTo.ToValue,
                txtTitle.Text,
                "����",
                HandleType,
                 "Messages_Center",
                 "",
                 "",
                 Pager.PageSize,
                 Pager.CurrentPageIndex,
                 "",
                 txtArchiveNo.Text,
                 3,
                    out TotalNum, Request["PType"]);

            GridHandle.DataSource = Dv;
            GridHandle.DataBind();

            //��̬�����û��Զ����ı�����
            Pager.RecordCount = TotalNum;
            Pager.CustomInfoText = "��¼������<font color=\"blue\"><b>" + Pager.RecordCount.ToString() + "</b></font>";
            Pager.CustomInfoText += " ÿҳ��<font color=\"blue\"><b>" + Pager.PageSize.ToString() + "</b></font>";
            Pager.CustomInfoText += " ��ҳ����<font color=\"blue\"><b>" + Pager.PageCount.ToString() + "</b></font>";
            Pager.CustomInfoText += " ��ǰҳ��<font color=\"red\"><b>" + Pager.CurrentPageIndex.ToString() + "</b></font>";

            AspNetPager1.RecordCount = TotalNum;
            AspNetPager1.CustomInfoText = Pager.CustomInfoText;

            Epoint.Frame.Bizlogic.common.DisplayPagerControl(Pager.PageCount, Pp1, Pp2);
        }

        public string getTopic(object MessageItemGuid, object Title, object HandleUrl)
        {
            string strHandleUrl = HandleUrl.ToString();
            if (strHandleUrl.IndexOf("?") > 0)
                strHandleUrl += "&MessageItemGuid=" + MessageItemGuid.ToString();
            else
                strHandleUrl += "?MessageItemGuid=" + MessageItemGuid.ToString();

            return "<a  class=\"HomeTitle\" href =\"javascript:OpenWindow('" + UrlOperate.GetHandlelUrl(strHandleUrl) + "')\" title=\"" + Title + "\">" + Title + "</a>";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 0;
            AspNetPager1.CurrentPageIndex = 0;
            BindGrid();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            string MessageItemGuid = "";
            
            for (int i = 0; i < GridHandle.Items.Count; i++)
            {
                System.Web.UI.HtmlControls.HtmlInputCheckBox ckb = (System.Web.UI.HtmlControls.HtmlInputCheckBox)GridHandle.Items[i].FindControl("toSelect");
                if (ckb.Checked)
                {
                    MessageItemGuid = GridHandle.DataKeys[i].ToString();
                    detail_msg = Msg.GetDetail(MessageItemGuid);
                    Msg.WaitHandle_Delete(MessageItemGuid);

                    //��¼������־
                    Epoint.Frame.Bizlogic.OperationLog.DB_Frame_OperationLog.Insert(
                        Epoint.Frame.Bizlogic.OperationLog.DB_Frame_OperationLog.LOG_OPERATOR_TYPE_DELETE,
                        Epoint.Frame.Bizlogic.OperationLog.DB_Frame_OperationLog.LOG_SUBSYSTEM_TYPE_Frame,
                        Session["UserGuid"].ToString(),
                        Session["DisplayName"].ToString(),
                        "ɾ���������ˡ����⣺" + detail_msg.Title + "��Ψһ��ʶMessageItemGuid��" + MessageItemGuid,
                        "",
                        Session["BaseOUGuid"].ToString());
                }
            }
            BindGrid();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object src, Wuqi.Webdiyer.PageChangedEventArgs e)
        {
            Pager.CurrentPageIndex = e.NewPageIndex;
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// �����ղؼ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddFavorite_Click(object sender, EventArgs e)
        {
            ArrayList arrHandleTitle = new ArrayList();
            ArrayList arrHandleUrl = new ArrayList();

            string MessageItemGuid = "";
            //ZLJDMis.BizLogic.ZLJD.Detail_Messages_Center detail_msg = new ZLJDMis.BizLogic.ZLJD.Detail_Messages_Center();
            for (int i = 0; i < GridHandle.Items.Count; i++)
            {
                System.Web.UI.HtmlControls.HtmlInputCheckBox ckb = (System.Web.UI.HtmlControls.HtmlInputCheckBox)GridHandle.Items[i].FindControl("toSelect");
                if (ckb.Checked)
                {
                    MessageItemGuid = GridHandle.DataKeys[i].ToString();
                    detail_msg = Msg.GetDetail(MessageItemGuid);

                    arrHandleTitle.Add("[��������]" + detail_msg.Title);
                    arrHandleUrl.Add(detail_msg.HandleUrl);
                }
            }

            if (arrHandleTitle.Count == 0)
            {
                AlertAjaxMessage("��û��ѡ����Ҫ�����ղؼеĴ������ˣ�");
                return;
            }
            else
            {
                Session["arrHandleTitle"] = arrHandleTitle;
                Session["arrHandleUrl"] = arrHandleUrl;
                WriteAjaxMessage("OpenDialogArgs('../../EpointOAMisc/Pages/Favorite/Misc_Favorite_InfoSelectCat.aspx','','300','500');");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Huanban_Click(object sender, EventArgs e)
        {
            string MessageItemGuid = "";
            //ZLJDMis.BizLogic.ZLJD.Detail_Messages_Center detail_msg = new ZLJDMis.BizLogic.ZLJD.Detail_Messages_Center();
            for (int i = 0; i < GridHandle.Items.Count; i++)
            {
                System.Web.UI.HtmlControls.HtmlInputCheckBox ckb = (System.Web.UI.HtmlControls.HtmlInputCheckBox)GridHandle.Items[i].FindControl("toSelect");
                if (ckb.Checked)
                {
                    MessageItemGuid = GridHandle.DataKeys[i].ToString();
                    detail_msg = Msg.GetDetail(MessageItemGuid);
                    Msg.WaitHandle_UpdateMessageType(MessageItemGuid, "����");

                    //��¼������־
                    Epoint.Frame.Bizlogic.OperationLog.DB_Frame_OperationLog.Insert(
                        Epoint.Frame.Bizlogic.OperationLog.DB_Frame_OperationLog.LOG_OPERATOR_TYPE_MODIFY,
                        Epoint.Frame.Bizlogic.OperationLog.DB_Frame_OperationLog.LOG_SUBSYSTEM_TYPE_Frame,
                        Session["UserGuid"].ToString(),
                        Session["DisplayName"].ToString(),
                        "ת��������״̬Ϊ���졣���⣺" + detail_msg.Title + "��Ψһ��ʶMessageItemGuid��" + MessageItemGuid,
                        "",
                        Session["BaseOUGuid"].ToString());
                }
            }
            BindGrid();
        }
    }
}
