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
using Epoint.Frame.Bizlogic.UserManage;
using Epoint.Frame.Bizlogic;
using Epoint.RegisterUser.Bizlogic.Consult;

namespace EpointRegisterUser.Consult.ConsultBoxManage
{
    public partial class ConsultBoxListMana : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Db_ConsultBoxMana BoxMana = new Db_ConsultBoxMana();
        Db_ConsultMana mana = new Db_ConsultMana();
        OU dept = new OU();
        // 允许直接在回复的时候直接发布到网上，回复状态为9， 不允许直接回复，回复状态为8
        private int handledStatusCode = Frame_Config.GetConfigValue("Consult_EnablePubAtReply") == "1" ? 9 : 8;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("IsNeedBoxGroup").ConfigValue == "1")
                {
                    if (Request.QueryString["BoxGroupID"] == null && Request.QueryString["BoxGuid"] == null)
                    {
                        Response.Write("<script>alert('请选择组别!')</script>");
                        Pager.Visible = false;
                        DataGrid1.Visible = false;
                        AspNetPager1.Visible = false;
                        return;
                    }
                }

                Pager.PageSize = Convert.ToInt32(Session["GridItemsCount"]);
                AspNetPager1.PageSize = Convert.ToInt32(Session["GridItemsCount"]);
                if (Request["jpdProcesstype"] != null)
                    jpdProcesstype.SelectedIndex = jpdProcesstype.Items.IndexOf(jpdProcesstype.Items.FindByValue(Request["jpdProcesstype"]));
                bindGrid();

                //信箱需要信访过滤的，在信件回复页删除按钮不现实
                BtnDel.Visible = false;
                if (Request.QueryString["BoxGuid"] != "" && Request.QueryString["BoxGuid"] != null)
                {
                    Detail_RG_ConsultBox BoxDetial = BoxMana.GetDetail(Request.QueryString["BoxGuid"]);
                    if (BoxDetial.NeedAudit == 0)//信箱不需要信访过滤的，在信件回复页删除按钮才现实
                        BtnDel.Visible = true;
                }
            }
        }

        public void bindGrid()
        {
            DataGrid1.Columns[2].Visible = false;
            string Sql = " where 1=1 ";
            switch (jpdProcesstype.SelectedValue)
            {
                case "0":  //未处理
                    Sql += " and HandleDate is null and Isdelete=0 and HandleStatus=0 ";
                    DataGrid1.Columns[2].Visible = true;
                    break;
                case "1":  //已处理
                    Sql += " and HandleDate is not null and Isdelete=0 and (HandleStatus=9 or HandleStatus=8 or HandleStatus=3 or HandleStatus=2) ";
                    break;
                case "2":  //暂不处理
                    Sql += " and Isdelete=1 and HandleStatus!=3 and HandleBoxGuid='' ";
                    break;
                case "3":  //全部
                    break;
            }

            #region 选出可用的信箱过滤
            if (Request.QueryString["BoxGuid"] != "" && Request.QueryString["BoxGuid"] != null)
            {
                //选择单个信箱的内容
                Sql += " and BoxGuid='" + Request.QueryString["BoxGuid"] + "'";
            }
            else
            {
                //先选出所有具有权限的信箱
                string FilterStr = "(HandleType='P' and HandleDetail='" + Session["UserGuid"].ToString() + "') ";
                string OuGuid = Session["OuGuid"].ToString();
                while (OuGuid != "")
                {
                    FilterStr += " or (HandleType='D' and HandleDetail='" + OuGuid + "') ";
                    OuGuid = dept.GetDetail(OuGuid).ParentOUGuid;
                }
                DataView dvRight = BoxMana.SelectHandleUserBySql(FilterStr);

                if (Request.QueryString["BoxGroupID"] != "" && Request.QueryString["BoxGroupID"] != null)
                {//选择单个组别下的
                    DataView dvGroups = BoxMana.BoxSelectByBoxGroupID(Request.QueryString["BoxGroupID"]);//选择组别下所有的邮箱

                    FilterStr = "(";
                    for (int i = 0; i < dvGroups.Count; i++)
                    {
                        dvRight.RowFilter = "BoxGuid='" + dvGroups[i]["BoxGuid"] + "'";
                        if (dvRight.Count > 0)
                        {
                            FilterStr += "'" + dvRight[0]["BoxGuid"].ToString() + "',";
                        }
                    }
                    if (FilterStr != "(")
                    {
                        Sql += " and BoxGuid in " + FilterStr.Substring(0, FilterStr.Length - 1) + ") ";
                    }
                }
                else//选择所有的
                {
                    if (dvRight.Count == 0)//没有可用的信箱
                    {
                        Sql += " and 1=2";
                    }
                    else
                    {
                        if (dvRight.Count == 1)
                        {
                            Sql += " and BoxGuid='" + dvRight[0]["BoxGuid"].ToString() + "'";
                        }
                        else
                        {
                            //FilterStr = "(";
                            //for (int i = 0; i < dvRight.Count; i++)
                            //{
                            //    FilterStr += "'" + dvRight[i]["BoxGuid"].ToString() + "',";
                            //}
                            //Sql += " and BoxGuid in " + FilterStr.Substring(0, FilterStr.Length - 1) + ") ";

                            for (int i = 0; i < dvRight.Count; i++)
                            {
                                if(i==0)
                                    FilterStr = "('" + dvRight[i]["BoxGuid"].ToString() + "'";
                                else if (i == dvRight.Count-1)
                                    FilterStr += ",'" + dvRight[i]["BoxGuid"].ToString() + "')";
                                else
                                    FilterStr += ",'" + dvRight[i]["BoxGuid"].ToString() + "'";
                            }
                            Sql += " and BoxGuid in " + FilterStr.ToString() +"  ";


                        }
                    }
                }
            }
            #endregion

            if (txtpostuser.Text.Trim().Replace("'", "") != "")
                Sql += " and PostUserName like '%" + txtpostuser.Text.Trim().Replace("'", "") + "%'";

            // added by lulj at 2009/4/27
            if (this.txtConsultPWD.Text.Trim().Replace("'", "") != "")
            {
                Sql += " and ConsultPWD like '%" + txtConsultPWD.Text.Trim().Replace("'", "") + "%'";
            }
            if (this.txtShouLiDept.Text.Trim().Replace("'", "") != "")
            {
                Sql += " and OUName like '%" + txtShouLiDept.Text.Trim().Replace("'", "") + "%'";
            }
            
            int TotalNum = 0;
            DataView myDt;
            myDt = mana.GetDataPage(
                "*",
                "VIEW_WEBDBCONSULTANDHANDLE",//
                  Sql,
                " order by OrderNum desc,Row_ID desc",
                "Row_ID",
                Pager.PageSize,
                Pager.CurrentPageIndex,
                txtTitle.Text,
                DateFromTo1.FromValue,
                DateFromTo1.ToValue,
                out TotalNum
                );

            Pager.RecordCount = TotalNum;
            Pager.CustomInfoText = "记录总数：<font color=\"blue\"><b>" + Pager.RecordCount.ToString() + "</b></font>";
            Pager.CustomInfoText += " 每页：<font color=\"blue\"><b>" + Pager.PageSize.ToString() + "</b></font>";
            Pager.CustomInfoText += " 总页数：<font color=\"blue\"><b>" + Pager.PageCount.ToString() + "</b></font>";
            Pager.CustomInfoText += " 当前页：<font color=\"red\"><b>" + Pager.CurrentPageIndex.ToString() + "</b></font>";

            AspNetPager1.RecordCount = TotalNum;
            AspNetPager1.CustomInfoText = "记录总数：<font color=\"blue\"><b>" + Pager.RecordCount.ToString() + "</b></font>";
            AspNetPager1.CustomInfoText += " 每页：<font color=\"blue\"><b>" + Pager.PageSize.ToString() + "</b></font>";
            AspNetPager1.CustomInfoText += " 总页数：<font color=\"blue\"><b>" + Pager.PageCount.ToString() + "</b></font>";
            AspNetPager1.CustomInfoText += " 当前页：<font color=\"red\"><b>" + Pager.CurrentPageIndex.ToString() + "</b></font>";

            Epoint.Frame.Bizlogic.common.DisplayPagerControl(Pager.PageCount, Pp1, Pp2);

            DataGrid1.DataSource = myDt;
            DataGrid1.DataBind();

            /// 判断是否现实在网上发布列
            if (new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("Consult_EnablePubAtReply").ConfigValue == "0")
            {
                foreach (DataGridColumn column in DataGrid1.Columns)
                {
                    if (column.HeaderText == "网上发布")
                        column.Visible = false;
                }
            }

            if (new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("IsShowConsultBoxManyidu").ConfigValue == "0")
            {
                foreach (DataGridColumn column in DataGrid1.Columns)
                {
                    if (column.HeaderText== "满意度反馈")
                        column.Visible = false;
                }
            }
               
        }

        protected void Pager_PageChanged(object src, Wuqi.Webdiyer.PageChangedEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            Pager.CurrentPageIndex = e.NewPageIndex;
            bindGrid();
        }

        public string GetMYD(object fankui)
        {
            string Strreturn = "未反馈";
            if (!Convert.IsDBNull(fankui))
            {
                switch (Convert.ToString(fankui))
                {
                    case "1":
                        Strreturn = "满意";
                        break;
                    case "2":
                        Strreturn = "比较满意";
                        break;
                    case "3":
                        Strreturn = "不满意";
                        break;
                }
            }
            return Strreturn;
        }

        protected void DgrQuestionnaire_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
            {
                e.Item.Cells[0].Text = "<p align=center>" + Convert.ToString((Pager.CurrentPageIndex - 1) * Pager.PageSize + e.Item.ItemIndex + 1) + "</p>";
            }
        }

        public string GetBoxName(object BoxGuid)
        {//受理人
            return BoxMana.GetDetail(BoxGuid.ToString()).BoxName;
        }

        public string GetLight(object _HandleEndDate)
        {
            DateTime HandleEndDate = DateTime.MaxValue;
            string tooltip="";
            if (_HandleEndDate != DBNull.Value)
            {
                HandleEndDate = Convert.ToDateTime(_HandleEndDate);
                tooltip = "title='请在" + HandleEndDate.ToString("yyyy年M月d日") + "之前回复！'";
            }

            string strReturn = "<img src=\"../../../images/greenLight.gif\" " + (string.IsNullOrEmpty(tooltip) ? "" : tooltip) + "/>";
            if (DateTime.Now.AddDays(3) >= HandleEndDate && DateTime.Now <= HandleEndDate)
            {
                strReturn = "<img src=\"../../../images/yellowLight.gif\" title='请及时回复此信件！'/>";
            }
            else if (DateTime.Now > HandleEndDate)
            {
                strReturn = "<img src=\"../../z../images/redLight.gif\" title='请马上回复此信件！'/>";
            }

            return strReturn;
        }

        public string gettype(object publishonweb)
        {
            string state = "不发布";
            if (Convert.IsDBNull(publishonweb))
                state = "不发布";
            else if (Convert.ToBoolean(publishonweb))
                state = "<font color=\"red\">发布到网上</font>";
            else
                state = "不发布";
            return state;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {//查询
            Pager.CurrentPageIndex = 1;
            bindGrid();
        }

        public string getHandleStat(object HandleStatus, object IsDelete)
        {
            string stat = "<font color=\"red\">待回复</font>";
            if (HandleStatus.ToString() == "3")
            {
                stat = "<font color=\"blue\">已转发</font>";
            }
            else
            {
                if (Convert.ToBoolean(IsDelete))
                    stat = "<font color=\"#CE670C\">暂不处理</font>";
                else
                {
                    switch (HandleStatus.ToString())
                    {
                        case "2":
                            stat = "<font color=\"blue\">已退回</font>";
                            break;
                        case "9":
                        case "8":
                            stat = "<font color=\"green\">已处理</font>";
                            break;
                        default:
                            break;
                    }
                }
            }
            return stat;
        }

        protected void BtnDel_Click(object sender, EventArgs e)//删除 直接删除全部
        {
            CheckBox chkdel;
            for (int i = 0; i < DataGrid1.Items.Count; i++)
            {
                chkdel = (CheckBox)DataGrid1.Items[i].FindControl("chksel");
                if (chkdel.Checked)
                {
                    mana.DeleteAll(DataGrid1.DataKeys[i].ToString());
                }
            }
            //AddCatch();
            bindGrid();
        }

        protected void BtnEditOrderNum_Click(object sender, EventArgs e)//排序
        {
            TextBox txtOrder;
            for (int i = 0; i < DataGrid1.Items.Count; i++)
            {
                txtOrder = (TextBox)DataGrid1.Items[i].FindControl("txtXuHao");
                int OrderNum = 0;
                try
                {
                    OrderNum = Convert.ToInt32(txtOrder.Text);
                }
                catch { }
                mana.UpdateOrderNum(DataGrid1.DataKeys[i].ToString(), OrderNum);
            }
            // AddCatch();
            bindGrid();
        }

        protected void btnOnWeb_Click(object sender, EventArgs e)//发布状态
        {
            CheckBox chkdel;
            for (int i = 0; i < DataGrid1.Items.Count; i++)
            {
                chkdel = (CheckBox)DataGrid1.Items[i].FindControl("chkOnWeb");
                mana.UpdatePublishOnWeb(DataGrid1.DataKeys[i].ToString(), chkdel.Checked);
            }
            //AddCatch();
            bindGrid();
        }

        protected void jpdProcesstype_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindGrid();
        }

        /// <summary>
        /// 通知系统生成首页面
        /// </summary>
        //protected void AddCatch()
        //{
        //    //生成首页静态页面
        //    DB_NeedRemoveCache DBCache = new DB_NeedRemoveCache();
        //    DBCache.ConnectionString = Epoint.Frame.Bizlogic.Conn.GetConnectionStringName("EpointMis_ConnectionString");

        //    if (DBCache.CheckNeedReWrite("Home") == false)
        //        DBCache.Insert("Home");
        //}
    }
}
