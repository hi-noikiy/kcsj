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
using Epoint.RegisterUser.Bizlogic.Consult;
using Epoint.Frame.Bizlogic.UserManage;
 
namespace EpointRegisterUser.Consult.ConsultBoxXinFang
{
    public partial class ConsultBoxXinFangListMana : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        Db_ConsultBoxMana BoxMana = new Db_ConsultBoxMana();
        Db_ConsultMana mana = new Db_ConsultMana();
        OU dept = new OU();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pager.PageSize = Convert.ToInt32(Session["GridItemsCount"]);
                AspNetPager1.PageSize = Convert.ToInt32(Session["GridItemsCount"]);
                bindGrid();
            }
        }

        public void bindGrid()
        {
            string Sql = " where HandleBoxGuid='' ";
            switch (jpdProcesstype.SelectedValue)
            {
                case "0":  //未分发
                    Sql += " and (InfoStatus=0 or infostatus=2) and Isdelete='0'";
                    break;
                case "1":  //已分发
                    Sql += " and (InfoStatus =1 or infostatus=3) and Isdelete='0'";
                    break;
                case "2":  //暂不处理
                    Sql += " and Isdelete='1'";
                    break;
                case "4":  //待交办、已处理、未处理
                    Sql += " and Isdelete='0' and (InfoStatus =1 or infostatus=3 or InfoStatus=0 or infostatus=2 or InfoStatus=8)";
                    break;
                case "5":  //待交办
                    Sql += " and Isdelete='0' and (InfoStatus =0 or infostatus=2)";
                    break;
                case "6":  //未处理
                    Sql += " and Isdelete='0' and (InfoStatus =1 or infostatus=3)";
                    break;
                case "7":  //已处理
                    Sql += " and Isdelete='0' and (InfoStatus=8)";
                    break;
                case "8":  //已办结
                    Sql += " and Isdelete='0' and (InfoStatus=9)";
                    break;
                case "3":  //全部
                    break;
            }


            #region 选出可用的信箱过滤
            if (Request.QueryString["BoxGuid"] != "" && Request.QueryString["BoxGuid"] != null)
            {
                //选择单个信箱的内容
                Sql += " and UserSendToBoxGuid='" + Request.QueryString["BoxGuid"] + "'";
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
                        Sql += " and UserSendToBoxGuid in " + FilterStr.Substring(0, FilterStr.Length - 1) + ") ";
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
                            Sql += " and UserSendToBoxGuid='" + dvRight[0]["BoxGuid"].ToString() + "'";
                        }
                        else
                        {
                            for (int i = 0; i < dvRight.Count; i++)
                            {
                                if (i == 0)
                                    FilterStr = "('" + dvRight[i]["BoxGuid"].ToString() + "'";
                                else if (i == dvRight.Count - 1)
                                    FilterStr += ",'" + dvRight[i]["BoxGuid"].ToString() + "')";
                                else
                                    FilterStr += ",'" + dvRight[i]["BoxGuid"].ToString() + "'";
                            }
                            Sql += " and UserSendToBoxGuid in " + FilterStr.ToString() + "  ";


                        }
                    }
                }
            }
            #endregion

            if (txtpostuser.Text.Trim().Replace("'", "") != "")
                Sql += " and PostUserName like '%" + txtpostuser.Text.Trim().Replace("'", "") + "%'";

            int TotalNum = 0;
            DataView myDt;
            myDt = mana.GetDataPage(
                "*",
                "RG_ConsultHistory",
                  Sql,
                " order by OrderNum desc,InfoKey desc",
                "InfoKey",
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
        }

        protected void Pager_PageChanged(object src, Wuqi.Webdiyer.PageChangedEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            Pager.CurrentPageIndex = e.NewPageIndex;
            bindGrid();
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

        private string GetLightStr(object oDate, string actionStr)
        {
            DateTime myDate = DateTime.MaxValue;
            string tooltip = "";
            if (oDate != DBNull.Value)
            {
                myDate = Convert.ToDateTime(oDate);
                tooltip = "title='请在" + myDate.ToString("yyyy年M月d日") + "之前" + actionStr + "！'";
            }

            string strReturn = "<img src=\"../../../images/greenLight.gif\" " + (string.IsNullOrEmpty(tooltip) ? "" : tooltip) + "/>";
            if (DateTime.Now.AddDays(3) >= myDate && DateTime.Now <= myDate)
            {
                strReturn = "<img src=\"../../../images/yellowLight.gif\" title='请及时" + actionStr + "此信件！'/>";
            }
            else if (DateTime.Now > myDate)
            {
                strReturn = "<img src=\"../../../images/redLight.gif\" title='请马上" + actionStr + "此信件！'/>";
            }
            return strReturn;
        }
        private string ConsultHandleDateSpan = new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("ConsultHandleDateSpan").ConfigValue == "" ? "5" : new Epoint.Frame.Bizlogic.Frame_Config().GetDetail("ConsultHandleDateSpan").ConfigValue;

        public string GetLight(object historyGuid, object PostDate, object HandleDate, object InfoStatus, object IsDelete, object pubonweb)
        {
            string Strreturn = "";
            if (Convert.ToBoolean(IsDelete))
                Strreturn = "<img src=\"../../../images/grayLight.gif\" title='暂不处理'/>";
            else
            {
                switch (InfoStatus.ToString())
                {
                    case "0":
                        Strreturn = GetLightStr(Convert.ToDateTime(PostDate).AddDays(Convert.ToInt16(ConsultHandleDateSpan)), "交办/回复");
                        break;
                    case "1":
                        {
                            DataView dv = mana.SelectAllHandle(historyGuid.ToString());
                            dv.Sort = "HandleEndDate Desc";
                            if (dv.Count > 0)
                                Strreturn = GetLightStr(dv[0]["HandleEndDate"], "回复");
                            break;
                        }
                    case "2":
                        {
                            DataView dv = mana.SelectAllHandle(historyGuid.ToString());
                            dv.Sort = "HandleDate Desc";
                            if (dv.Count > 0)
                            {
                                if (dv[0]["HandleDate"] == DBNull.Value)
                                {
                                    Strreturn = GetLightStr(DBNull.Value, "交办/回复");

                                }
                                else
                                {
                                    Strreturn = GetLightStr(Convert.ToDateTime(dv[0]["HandleDate"]).AddDays(Convert.ToInt16(ConsultHandleDateSpan)), "交办/回复");
                                }

                            }
                            break;
                        }
                    case "9":
                        Strreturn = "<img src=\"../../../images/grayLight.gif\" title='已回复'/>";

                        break;
                    case "8":
                        {
                            DataView dv = mana.SelectAllHandle(historyGuid.ToString());
                            dv.Sort = "HandleDate Desc";
                            if (dv.Count > 0)
                            {
                                if (dv[0]["HandleDate"] == DBNull.Value)
                                {
                                    Strreturn = GetLightStr(DBNull.Value, "发布");

                                }
                                else
                                {
                                    Strreturn = GetLightStr(Convert.ToDateTime(dv[0]["HandleDate"]).AddDays(Convert.ToInt16(ConsultHandleDateSpan)), "发布");
                                }
                            }
                        }
                        break;
                }
            }
            return Strreturn;
        }

        public string GetInfoStatus(object infostatus, object IsDelete, object pubonweb)
        {
            string Strreturn = "";
            if (Convert.ToBoolean(IsDelete))
                Strreturn = "<font color=#CE670C>暂不处理</font>";
            else
            {
                switch (infostatus.ToString())
                {
                    case "0":
                        Strreturn = "<font color=red>待交办</font>";
                        break;
                    case "1":
                        Strreturn = "<font color=blue>未处理</font>";
                        break;
                    case "2":
                        Strreturn = "<font color=blue>待交办</font>";
                        break;
                    case "9":
                        Strreturn = "<font color=green>已办结</font>";
                        break;
                    case "8":
                        Strreturn = "<font color=green>已处理</font>";

                        break;
                }
            }
            return Strreturn;
        }


        protected void btnSearch_Click(object sender, EventArgs e)//查询
        {
            Pager.CurrentPageIndex = 1;
            bindGrid();
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
            //AddCatch();
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
            bindGrid();
        }

        protected void jpdProcesstype_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindGrid();
        }
    }
}
