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
using Epoint.RegisterUser.Bizlogic.Consult;

namespace EpointRegisterUser.Consult.ConsultBoxTongJi
{
    public partial class ConsultBoxTongJi : Epoint.Frame.Bizlogic.BasePage
    {
        Db_ConsultBoxMana mana = new Db_ConsultBoxMana();
        Db_ConsultMana Consult = new Db_ConsultMana(); 
        OU dept = new OU();

        string mGroupID = "";
        string BoxGuid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["BoxGroupID"] != null && Request.QueryString["BoxGroupID"].ToString() != "")
                mGroupID = Request.QueryString["BoxGroupID"].ToString();

            if (Request.QueryString["BoxGuid"] != null && Request.QueryString["BoxGuid"].ToString() != "")
                BoxGuid = Request.QueryString["BoxGuid"].ToString();

            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            DataView myDt = mana.BoxSelectAll();
            if (mGroupID != "")
                myDt = mana.BoxSelectByBoxGroupID(mGroupID);

            if (BoxGuid != "")
                myDt.RowFilter = "BoxGuid='" + BoxGuid + "'";
            else
            {
                DataView dvRight = mana.SelectHandleUser();
                string FilterStr = "(HandleType='P' and HandleDetail='" + Session["UserGuid"].ToString() + "') ";
                string OuGuid = Session["OuGuid"].ToString();
                while (OuGuid != "")
                {
                    FilterStr += " or (HandleType='D' and HandleDetail='" + OuGuid + "') ";
                    OuGuid = dept.GetDetail(OuGuid).ParentOUGuid;
                }
                dvRight.RowFilter = FilterStr;

                string FilterBox = "";
                for (int i = 0; i < dvRight.Count;i++ )
                {
                    FilterBox += "BoxGuid='" + dvRight[i]["BoxGuid"] + "'";
                    if(i<dvRight.Count-1)
                    {
                        FilterBox += " or ";
                    }
                }

                if (FilterBox != "")
                {
                    myDt.RowFilter = FilterBox;
                }
                else
                {
                    myDt.RowFilter = "1=2";
                }
            }

            DataList1.DataSource = myDt;
            DataList1.DataBind();
        }

        public string GetCount1(object BoxGuid)
        {
            string strCondition = "where UserSendToBoxGuid='" + BoxGuid + "' and HandleDate is null and TimeOut=1 and IsDelete=0";
            if (DateFromTo1.FromValue != "")
                strCondition += " and PostDate >= convert(datetime,'" + DateFromTo1.FromValue + "') ";
            if (DateFromTo1.ToValue != "")
                strCondition += " and PostDate <= convert(datetime,'" + DateFromTo1.ToValue + "') ";
            return Consult.SelectHistoryCount(strCondition);
        }

        public string GetCount2(object BoxGuid)
        {
            string strCondition = "where UserSendToBoxGuid='" + BoxGuid + "' and HandleDate is null and TimeOut=0  and IsDelete=0";
            if (DateFromTo1.FromValue != "")
                strCondition += " and PostDate >= convert(datetime,'" + DateFromTo1.FromValue + "') ";
            if (DateFromTo1.ToValue != "")
                strCondition += " and PostDate <= convert(datetime,'" + DateFromTo1.ToValue + "') ";
            return Consult.SelectHistoryCount(strCondition);
        }

        public string GetCount3(object BoxGuid)
        {
            string strCondition = "where UserSendToBoxGuid='" + BoxGuid + "' and  HandleDate is not null and TimeOut=1  and IsDelete=0";
            if (DateFromTo1.FromValue != "")
                strCondition += " and PostDate >= convert(datetime,'" + DateFromTo1.FromValue + "') ";
            if (DateFromTo1.ToValue != "")
                strCondition += " and PostDate <= convert(datetime,'" + DateFromTo1.ToValue + "') ";
            return Consult.SelectHistoryCount(strCondition);
        }

        public string GetCount4(object BoxGuid)
        {
            string strCondition = "where UserSendToBoxGuid='" + BoxGuid + "' and  HandleDate is not null and TimeOut=0  and IsDelete=0";
            if (DateFromTo1.FromValue != "")
                strCondition += " and PostDate >= convert(datetime,'" + DateFromTo1.FromValue + "') ";
            if (DateFromTo1.ToValue != "")
                strCondition += " and PostDate <= convert(datetime,'" + DateFromTo1.ToValue + "') ";
            return Consult.SelectHistoryCount(strCondition);
        }

        public string GetCount5(object BoxGuid)
        {
            string strCondition = "where UserSendToBoxGuid='" + BoxGuid + "' and  HandleDate is not null and ReplyType='个人回复'  and IsDelete=0";
            if (DateFromTo1.FromValue != "")
                strCondition += " and PostDate >= convert(datetime,'" + DateFromTo1.FromValue + "') ";
            if (DateFromTo1.ToValue != "")
                strCondition += " and PostDate <= convert(datetime,'" + DateFromTo1.ToValue + "') ";
            return Consult.SelectHistoryCount(strCondition);
        }

        public string GetCount6(object BoxGuid)
        {
            string strCondition = "where UserSendToBoxGuid='" + BoxGuid + "' and  HandleDate is not null and ReplyType='网站回复'  and IsDelete=0";
            if (DateFromTo1.FromValue != "")
                strCondition += " and PostDate >= convert(datetime,'" + DateFromTo1.FromValue + "') ";
            if (DateFromTo1.ToValue != "")
                strCondition += " and PostDate <= convert(datetime,'" + DateFromTo1.ToValue + "') ";
            return Consult.SelectHistoryCount(strCondition);
        }

        public string GetCount7(object BoxGuid)
        {
            string strCondition = "where UserSendToBoxGuid='" + BoxGuid + "' and   IsDelete=1";
            if (DateFromTo1.FromValue != "")
                strCondition += " and PostDate >= convert(datetime,'" + DateFromTo1.FromValue + "') ";
            if (DateFromTo1.ToValue != "")
                strCondition += " and PostDate <= convert(datetime,'" + DateFromTo1.ToValue + "') ";
            return Consult.SelectHistoryCount(strCondition);
        }

        public string GetCount8(object BoxGuid)
        {
            string strCondition = "where UserSendToBoxGuid='" + BoxGuid + "' and   FanKui=1";
            if (DateFromTo1.FromValue != "")
                strCondition += " and PostDate >= convert(datetime,'" + DateFromTo1.FromValue + "') ";
            if (DateFromTo1.ToValue != "")
                strCondition += " and PostDate <= convert(datetime,'" + DateFromTo1.ToValue + "') ";
            return Consult.SelectHistoryCount(strCondition);
        }

        public string GetCount9(object BoxGuid)
        {
            string strCondition = "where UserSendToBoxGuid='" + BoxGuid + "' and   FanKui=2";
            if (DateFromTo1.FromValue != "")
                strCondition += " and PostDate >= convert(datetime,'" + DateFromTo1.FromValue + "') ";
            if (DateFromTo1.ToValue != "")
                strCondition += " and PostDate <= convert(datetime,'" + DateFromTo1.ToValue + "') ";
            return Consult.SelectHistoryCount(strCondition);
        }

        public string GetCount10(object BoxGuid)
        {
            string strCondition = "where UserSendToBoxGuid='" + BoxGuid + "' and   FanKui=3";
            if (DateFromTo1.FromValue != "")
                strCondition += " and PostDate >= convert(datetime,'" + DateFromTo1.FromValue + "') ";
            if (DateFromTo1.ToValue != "")
                strCondition += " and PostDate <= convert(datetime,'" + DateFromTo1.ToValue + "') ";
            return Consult.SelectHistoryCount(strCondition);
        }

        public string GetCount11(object BoxGuid)
        {
            string strCondition = "where UserSendToBoxGuid='" + BoxGuid + "' and   FanKui is null";
            if (DateFromTo1.FromValue != "")
                strCondition += " and PostDate >= convert(datetime,'" + DateFromTo1.FromValue + "') ";
            if (DateFromTo1.ToValue != "")
                strCondition += " and PostDate <= convert(datetime,'" + DateFromTo1.ToValue + "') ";
            return Consult.SelectHistoryCount(strCondition);
        }

        public void btnSearch_Click(object sender, System.EventArgs e)
        {
            BindGrid();
        }
    }
}
