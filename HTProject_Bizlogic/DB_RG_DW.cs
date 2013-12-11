using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Web.UI.WebControls;

namespace HTProject_Bizlogic
{
    /// <summary>
    /// 单位数据操作
    /// </summary>
    public class DB_RG_DW
    {
        #region 可删除与可编辑
        public bool CanOperate(object Status)
        {
            if (Status.ToString() == "70")
            {
                return false;
            }
            return true;
        }
        public bool CanOperate2(object Status)
        {
            if (Status.ToString() == "70" || Status.ToString() == "90")
            {
                return false;
            }
            return true;
        }
        public bool CanOperateButton(object Status)
        {
            if (Status.ToString() == "70")
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取编辑的操作按钮
        /// </summary>
        /// <param name="RowGuid"></param>
        /// <param name="Status"></param>
        /// <param name="url"></param>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        public string GetOperateButton(object RowGuid, object Status, string url, string imgUrl, string from)
        {
            string sRTN = "<a href='javascript:OpenWindow(\"{0}?RowGuid={1}&from={3}\")' ><img src='{2}' border='0'/></a>";
            if (CanOperateButton(Status))
            {
                return string.Format(sRTN, url, RowGuid, imgUrl, from);
            }
            return "";
        }
        public string GetOperateButton2(object RowGuid, object Status, string url, string imgUrl, string from)
        {
            string sRTN = "<a href='javascript:OpenWindow(\"{0}?RowGuid={1}&from={3}\")' ><img src='{2}' border='0'/></a>";
            if (CanOperate2(Status))
            {
                return string.Format(sRTN, url, RowGuid, imgUrl, from);
            }
            return "";
        }
        /// <summary>
        /// 获取查看的操作按钮
        /// </summary>
        /// <param name="RowGuid"></param>
        /// <param name="Status"></param>
        /// <param name="url"></param>
        /// <param name="imgUrl"></param>
        /// <returns></returns>
        public string GetViewButton(object RowGuid, object Status, string url, string imgUrl)
        {
            string sRTN = "<a href='javascript:OpenWindow(\"{0}?RowGuid={1}\")' ><img src='{2}' border='0'/></a>";
            if (!CanOperateButton(Status))
            {
                return string.Format(sRTN, url, RowGuid, imgUrl);
            }
            return "";
        }
        public string GetViewButton2(object RowGuid, object Status, string url, string imgUrl)
        {
            string sRTN = "<a href='javascript:OpenWindow(\"{0}?RowGuid={1}\")' ><img src='{2}' border='0'/></a>";
            if (!CanOperate2(Status))
            {
                return string.Format(sRTN, url, RowGuid, imgUrl);
            }
            return "";
        }
        #endregion

        #region 共用
        /// <summary>
        /// 获取企业名称
        /// </summary>
        /// <param name="DWGuid"></param>
        /// <returns></returns>
        public string GetDWName(object DWGuid)
        {
            string strSql = "SELECT EnterpriseName FROM RG_OUInfo WHERE ROWGUID='" + DWGuid + "'";
            return Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
        }
        public void InitSHStatus(DropDownList ddlStatus)
        {
            string strSql = "SELECT * FROM Code_Items WHERE CodeID='43' ORDER BY OrderNo DESC";
            ddlStatus.Items.Add(new ListItem("所有选项", ""));
            DataView dvCode = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            for (int m = 0; m < dvCode.Count; m++)
            {
                ddlStatus.Items.Add(new ListItem(dvCode[m]["ItemText"].ToString(), dvCode[m]["ItemValue"].ToString()));
            }
        }
        /// <summary>
        /// 保存审核意见
        /// </summary>
        /// <param name="FRowGuid"></param>
        /// <param name="UserName"></param>
        /// <param name="SHOpinion"></param>
        /// <param name="OtherGuid"></param>
        public void InsertSHOpinion(object FRowGuid, object UserName, string SHOpinion, object OtherGuid)
        {
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("ShenHeInfo");
            oRow["RowGuid"] = Guid.NewGuid().ToString();
            oRow["OperateUserName"] = UserName;
            oRow["OperateDate"] = DateTime.Now.ToString();
            oRow["SHOpinion"] = SHOpinion;
            oRow["FRowGuid"] = FRowGuid;
            oRow["OtherGuid"] = OtherGuid;
            oRow.Insert();
        }
        /// <summary>
        /// 获取审核意见
        /// </summary>
        /// <param name="FRowGuid"></param>
        /// <param name="OtherGuid"></param>
        /// <returns></returns>
        public string GetSHOpinion(object FRowGuid, object OtherGuid)
        {
            StringBuilder sb = new StringBuilder();
            string strSql = "SELECT * FROM ShenHeInfo WHERE FRowGuid='" + FRowGuid + "' ";
            if (OtherGuid.ToString() != "")
            {
                strSql += " AND OtherGuid='" + OtherGuid + "' ";
            }
            strSql += " ORDER BY ROW_ID DESC ";
            DataView dvOP = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            string strOpinion = "[{0}]在[{1}]，[{2}]";
            for (int m = 0; m < dvOP.Count; m++)
            {
                sb.Append(string.Format(strOpinion, dvOP[m]["OperateUserName"], dvOP[m]["OperateDate"], dvOP[m]["SHOpinion"]));
                sb.Append("<br/>");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取最后一次审核意见
        /// </summary>
        /// <param name="FRowGuid"></param>
        /// <param name="OtherGuid"></param>
        /// <returns></returns>
        public string GetLastSHOpinion(object FRowGuid, object OtherGuid)
        {
            StringBuilder sb = new StringBuilder();
            string strSql = "SELECT TOP(1) SHOpinion FROM ShenHeInfo WHERE FRowGuid='" + FRowGuid + "' ";
            if (OtherGuid.ToString() != "")
            {
                strSql += " AND OtherGuid='" + OtherGuid + "' ";
            }
            strSql += " ORDER BY ROW_ID DESC ";
            return Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
        }

        /// <summary>
        /// 根据企业注册地区、项目所在地区、时间、本年度流水号进行编号
        /// </summary>
        /// <param name="XMGuid"></param>
        /// <param name="DWGuid"></param>
        /// <param name="XMAdd"></param>
        /// <returns></returns>
        public string CreateXMBH(object XMGuid, object DWGuid, object XMAdd, object XMLB, string QYZCD)
        {
            string XMBH = "";
            //首先看企业注册地址，分为省内、省外，获取注册地区的前两位，如果是32，代表江苏
            //首先看企业注册地区
            //string QYZCD = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT RegistAddressCode FROM RG_OUInfo WHERE RowGuid='" + DWGuid + "'");
            if (QYZCD.Substring(0, 2) == "32")
            {
                XMBH += "SN-";
            }
            else
            {
                XMBH += "SW-";
            }
            string add = XMAdd.ToString();
            //项目所在地区，分为市区、江阴、宜兴
            if (add == "320281")//江阴
            {
                XMBH += "JY";
            }
            else if (add == "320282")//宜兴
            {
                XMBH += "YX";
            }
            else if (add == "320202")//崇安
            {
                XMBH += "CA";
            }
            else if (add == "320203")//南长区
            {
                XMBH += "NC";
            }
            else if (add == "320204")//北塘区
            {
                XMBH += "BT";
            }
            else if (add == "320205")//锡山区
            {
                XMBH += "XS";
            }
            else if (add == "320206")//惠山区
            {
                XMBH += "HS";
            }
            else if (add == "320211")//滨湖区
            {
                XMBH += "BH";
            }
            else if (add == "320207")//无锡新区
            {
                XMBH += "XQ";
            }
            else
            {
                XMBH += "SQ";
            }

            if (XMLB.ToString() == "")
            {
                XMBH += "-K-";
            }
            else
            {
                XMBH += "-" + XMLB + "-";
            }
            //再加上年月日
            XMBH += DateTime.Now.ToString("yyyyMMdd");
            //最后，再加一个年度流水号
            XMBH += GetMaxXMBH_LSH(DateTime.Now.Year);
            return XMBH;
        }

        public string GetXMBH(object XMGuid, object DWGuid, object XMAdd, object XMBH, object XMLB)
        {
            string bh = "";
            if (XMBH.ToString() != "")
            {
                return XMBH.ToString();
            }
            else
            {
                string QYZCD = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT RegistAddressCode FROM RG_OUInfo WHERE RowGuid='" + DWGuid + "'");
                if (QYZCD.Substring(0, 2) == "32")
                {
                    bh += "SN-";
                }
                else
                {
                    bh += "SW-";
                }

                string add = XMAdd.ToString();
                //项目所在地区，分为市区、江阴、宜兴
                if (add == "320281")//江阴
                {
                    XMBH += "JY";
                }
                else if (add == "320282")//宜兴
                {
                    XMBH += "YX";
                }
                else if (add == "320202")//崇安
                {
                    XMBH += "CA";
                }
                else if (add == "320203")//南长区
                {
                    XMBH += "NC";
                }
                else if (add == "320204")//北塘区
                {
                    XMBH += "BT";
                }
                else if (add == "320205")//锡山区
                {
                    XMBH += "XS";
                }
                else if (add == "320206")//惠山区
                {
                    XMBH += "HS";
                }
                else if (add == "320211")//滨湖区
                {
                    XMBH += "BH";
                }
                else if (add == "320207")//无锡新区
                {
                    XMBH += "XQ";
                }
                else
                {
                    XMBH += "SQ";
                }

                if (XMLB.ToString() == "")
                {
                    XMBH += "-K-";
                }
                else
                {
                    XMBH += "-" + XMLB + "-";
                }
                return bh + XMBH;
            }
        }

        public string GetMaxXMBH_LSH(int Year)
        {
            string strSql = "SELECT TOP(1) XMBH FROM RG_XMBeiAn WHERE XMBH LIKE '%" + Year + "%' ORDER BY XMBH DESC";
            string xmbh = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            if (xmbh == "")
            {
                return "0001";
            }
            else
            {
                int m = int.Parse(xmbh.Substring(xmbh.Length - 4));
                return (m + 1).ToString("D4");
            }
        }

        /// <summary>
        /// 获取某一代码值，有部分个性化,用于显示从事专业、注册专业
        /// </summary>
        /// <param name="MainGuid"></param>
        /// <param name="ItemCode"></param>
        /// <param name="LEN"></param>
        /// <returns></returns>
        public string GetItemTextByLen(object MainGuid, object ItemCode, int LEN)
        {
            string ItemCodeF = ItemCode.ToString();
            if (LEN > 0)
            {
                if (ItemCodeF.Length < LEN)
                {
                    return "";
                }
                else
                {
                    ItemCodeF = ItemCodeF.Substring(0, LEN);
                }
            }
            string strSql = "SELECT ItemText FROM Frame_Code_Item WHERE MainGuid='" + MainGuid + "' AND ItemCode='" + ItemCodeF + "'";
            return Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
        }

        public string GetItemTextSByLen(object MainGuid, object ItemCodeS, int LEN)
        {
            string ItemCodeF = ItemCodeS.ToString();
            string[] code = ItemCodeF.Split(';');
            string strRT = "";
            if (LEN > 0)
            {
                for (int m = 0; m < code.Length; m++)
                {
                    if (code[m].Length < LEN)
                    {
                        strRT += "";
                    }
                    else if (code[m] == "")
                    {
                        strRT += "";
                    }
                    else
                    {
                        //ItemCodeF = ItemCodeF.Substring(0, LEN);
                        string strSql = "SELECT ItemText FROM Frame_Code_Item WHERE MainGuid='" + MainGuid + "' AND ItemCode='" + code[m].Substring(0, LEN) + "'";
                        strRT += Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                        strRT += ";";
                    }
                }
            }
            return strRT;
        }

        /// <summary>
        /// 获取一批代码值，有部分个性化,用于显示从事专业、注册专业
        /// </summary>
        /// <param name="MainGuid"></param>
        /// <param name="ItemCodes"></param>
        /// <param name="LEN"></param>
        /// <returns></returns>
        public string GetItemTextByLen2(object MainGuid, object ItemCodes, int LEN)
        {
            StringBuilder sb = new StringBuilder();
            string[] codes = ItemCodes.ToString().Split(';');
            for (int m = 0; m < codes.Length; m++)
            {
                if (codes[m] != "")
                {
                    if (codes[m].Length == 4)
                    {
                        //sb.Append(GetItemText(codes[m],MainGuid ));
                        //sb.Append(";");
                    }
                    else
                    {
                        sb.Append(GetItemTextByLen(MainGuid, codes[m], LEN));
                        sb.Append(";");
                    }
                }
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }

        public string GetCSZY(object MainGuid, object ItemCodes, int LEN)
        {
            StringBuilder sb = new StringBuilder();
            string[] codes = ItemCodes.ToString().Split(';');
            string cszy = "";
            string zy = "";
            for (int m = 0; m < codes.Length; m++)
            {
                if (codes[m] != "")
                {
                    if (codes[m].Length == 4)
                    {
                        zy = GetItemText(codes[m], MainGuid);
                        if (!cszy.Contains(zy))
                        {
                            cszy += zy;
                            cszy += ";";
                        }
                    }
                    else
                    {
                        zy = GetItemText(codes[m].Substring(0, 4), MainGuid);
                        if (!cszy.Contains(zy))
                        {
                            cszy += zy;
                            cszy += ";";
                        }

                    }
                }
            }
            if (cszy.Length > 0)
            {
                cszy.Remove(cszy.Length - 1, 1);
            }
            return cszy;
        }


        public string GetItemText(object ITCode, object MainGuid)
        {
            string strSql = "SELECT ItemText FROM Frame_Code_Item WHERE MainGuid='" + MainGuid + "' AND ItemCode='" + ITCode + "'";
            return Epoint.MisBizLogic2.DB.ExecuteToString(strSql);

        }

        #endregion

        #region 企业下的人员
        /// <summary>
        /// 判断是否有重复身份证
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool IsExistByIDNO(string ID, out string Name)
        {
            //首选看看全部正式人员中是否已经有了
            string strSql = "SELECT XM FROM RG_QYUser WHERE delStatus='0' and IDNum='" + ID + "'";

            Name = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            if (Name != "")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 判断是否有重复身份证
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="RowGuid"></param>
        /// <returns></returns>
        public bool IsExistByIDNO(string ID, out string Name, string RowGuid)
        {
            //首选看看全部正式人员中是否已经有了
            string strSql = "SELECT XM FROM RG_QYUser WHERE delStatus='0' and IDNum='" + ID + "' and RowGuid<>'" + RowGuid + "'";
            Name = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            if (Name != "")
            {
                return true;
            }
            return false;
        }

        #endregion

        #region 企业资质
        /// <summary>
        /// 判断是否有重复身份证
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool IsExistByZiZhi(string zizhicode)
        {
            //首选看看全部正式人员中是否已经有了
            string strSql = "SELECT count(*) FROM rg_qiyezizhi WHERE delStatus='0' and zizhicode='" + zizhicode + "'";

            if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) != "0")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 判断是否有重复身份证
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="RowGuid"></param>
        /// <returns></returns>
        public bool IsExistByZiZhi(string zizhicode, string RowGuid)
        {
            //首选看看全部正式人员中是否已经有了
            string strSql = "SELECT count(*) FROM rg_qiyezizhi WHERE delStatus='0' and zizhicode='" + zizhicode + "' and RowGuid<>'" + RowGuid + "'";
            if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) != "0")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 特殊处理企业资质，高级的要能处理低级的
        /// </summary>
        /// <param name="DWGuid"></param>
        /// <returns></returns>
        public DataView GetZiZhiByDWGuid(string DWGuid)
        {
            DataView dvRT = new DataView();
            DataTable dt = new DataTable();
            string strSql = @"select zz.RowGuid,zz.ZiZhiCode,zz.ZiZhiText,zz.ZiZhiTextCode,ci.OrderNumber,ci.ItemCode,ci.ItemText from RG_QiYeZiZhi ZZ left join Frame_Code_Item CI
on ZZ.ZiZhiTextCode=CI.ItemCode
 where  DelStatus='0' and Status='90' and ZiZhiEndDate>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and DWGuid='" + DWGuid + "' and MainGuid='f7f84f2a-de8a-4bc2-b13d-e541f73b12a8' ";
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            if (dv.Count > 0)
            {
                dt = dv.Table.Copy();
                dt.Clear();
            }
            string RowGuid = "";
            string ZiZhiCode = "";
            string ZiZhiText = "";
            string ZiZhiTextCode = "";
            string ItemText = "";
            int OrderNumber = 0;
            //循环处理
            for (int m = 0; m < dv.Count; m++)
            {
                RowGuid = dv[m]["RowGuid"].ToString();
                ZiZhiCode = dv[m]["ZiZhiCode"].ToString();
                ZiZhiText = dv[m]["ZiZhiText"].ToString();
                ZiZhiTextCode = dv[m]["ZiZhiTextCode"].ToString();
                ItemText = dv[m]["ItemText"].ToString();
                OrderNumber = int.Parse(dv[m]["OrderNumber"].ToString());
                DataRow dr = dt.NewRow();
                //先把自己加上
                dr["RowGuid"] = RowGuid + ZiZhiTextCode;
                dr["ZiZhiText"] = ZiZhiText;
                dr["ZiZhiTextCode"] = ZiZhiTextCode;
                dr["ZiZhiCode"] = ZiZhiCode;
                dt.Rows.Add(dr);
                //再看是不是甲级、乙级
                //如果是甲级，就再加上乙级、丙级，乙级的处理类似
                if (ItemText.IndexOf("甲级") > 0)
                {
                    //把甲级、乙级都弄上
                    MakeDengJi(ItemText.Replace("甲级", "乙级"), OrderNumber - 1, RowGuid, dt, ZiZhiText.Replace("甲级", "乙级"), ZiZhiCode);

                    MakeDengJi(ItemText.Replace("甲级", "丙级"), OrderNumber - 2, RowGuid, dt, ZiZhiText.Replace("甲级", "丙级"), ZiZhiCode);

                    MakeDengJi(ItemText.Replace("甲级", "丁级"), OrderNumber - 3, RowGuid, dt, ZiZhiText.Replace("甲级", "丁级"), ZiZhiCode);
                }
                else if (ItemText.IndexOf("乙级") > 0)
                {
                    //丙级，防止出现
                    MakeDengJi(ItemText.Replace("乙级", "丙级"), OrderNumber - 1, RowGuid, dt, ZiZhiText.Replace("乙级", "丙级"), ZiZhiCode);

                    MakeDengJi(ItemText.Replace("乙级", "丁级"), OrderNumber - 2, RowGuid, dt, ZiZhiText.Replace("乙级", "丁级"), ZiZhiCode);
                }
                else if (ItemText.IndexOf("丙级") > 0)
                {
                    //出现过丁级
                    MakeDengJi(ItemText.Replace("丙级", "丁级"), OrderNumber - 1, RowGuid, dt, ZiZhiText.Replace("丙级", "丁级"), ZiZhiCode);
                }
            }
            dvRT = dt.DefaultView;
            return dvRT;
        }
        protected DataTable MakeDengJi(string ItemText, int OrNum, string pRGuid, DataTable dt, string ZiZhiText, string ZiZhiCode)
        {
            string strSql = " select * from Frame_Code_Item where ItemText='" + ItemText + "' and OrderNumber='" + OrNum + "' and MainGuid='f7f84f2a-de8a-4bc2-b13d-e541f73b12a8'";
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            if (dv.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["RowGuid"] = pRGuid + dv[0]["ItemCode"].ToString();
                dr["ZiZhiText"] = ZiZhiText;
                dr["ZiZhiTextCode"] = dv[0]["ItemCode"].ToString();
                dr["ZiZhiCode"] = ZiZhiCode;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

        #region 资质与专业关系
        /// <summary>
        /// 通过资质的Code获取关联上的专业
        /// </summary>
        /// <param name="ZZCode"></param>
        /// <returns></returns>
        public DataView GetZYbyZZ(string ZZCode)
        {
            string strSql = "SELECT * FROM RG_ZiZhiZhuanYe WHERE ZiZhiCode='" + ZZCode + "' order by OrderNo desc";
            return Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
        }

        public bool IsExistZZZYGX(string ZiZhiCode, string ZhuanYeCode)
        {
            string strSql = "SELECT COUNT(*) FROM RG_ZiZhiZhuanYe WHERE ZiZhiCode='" + ZiZhiCode + "' AND ZhuanYeCode='" + ZhuanYeCode + "' ";
            if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) == "0")
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 新增资质和专业的关系
        /// </summary>
        /// <param name="ZiZhiText"></param>
        /// <param name="ZiZhiCode"></param>
        /// <param name="ZhuanYeText"></param>
        /// <param name="ZhuanYeCode"></param>
        /// <param name="OrderNo"></param>
        public void InsertZZZYGX(string ZiZhiText, string ZiZhiCode, string ZhuanYeText, string ZhuanYeCode, int OrderNo)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @"INSERT INTO RG_ZiZhiZhuanYe(OperateDate,ZiZhiText,ZiZhiCode,ZhuanYeText,ZhuanYeCode,NeedRY,OWhere,OrderNo,RowGuid)
VALUES(GETDATE(),@ZiZhiText,@ZiZhiCode,@ZhuanYeText,@ZhuanYeCode,1,'',@OrderNo,NEWID())";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "ZiZhiText", DbType.String, ZiZhiText);
            db.AddInParameter(cmd, "ZiZhiCode", DbType.String, ZiZhiCode);
            db.AddInParameter(cmd, "ZhuanYeText", DbType.String, ZhuanYeText);
            db.AddInParameter(cmd, "ZhuanYeCode", DbType.String, ZhuanYeCode);
            db.AddInParameter(cmd, "OrderNo", DbType.Int32, OrderNo);

            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// 更新资质专业对应关系
        /// </summary>
        /// <param name="RowGuid"></param>
        /// <param name="OrderNo"></param>
        /// <param name="NeedRY"></param>
        public void UpdateZZZYGX(string RowGuid, int OrderNo, string NeedRY)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @"UPDATE RG_ZiZhiZhuanYe SET NeedRY=@NeedRY,OrderNo=@OrderNo WHERE RowGuid=@RowGuid";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "RowGuid", DbType.String, RowGuid);
            db.AddInParameter(cmd, "NeedRY", DbType.Int32, NeedRY);
            db.AddInParameter(cmd, "OrderNo", DbType.String, OrderNo);

            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// 删除资质专业对应关系
        /// </summary>
        /// <param name="RowGuid"></param>
        public void DeleteZZZYGX(string RowGuid)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @"DELETE RG_ZiZhiZhuanYe WHERE RowGuid=@RowGuid";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "RowGuid", DbType.String, RowGuid);

            db.ExecuteNonQuery(cmd);
        }

        public void DeleteAllZZZYGX(string ZiZhiCode)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @"DELETE RG_ZiZhiZhuanYe WHERE ZiZhiCode=@ZiZhiCode";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "ZiZhiCode", DbType.String, ZiZhiCode);

            db.ExecuteNonQuery(cmd);
        }

        public bool IsExistZZGX(string ZiZhiCode)
        {
            string strSql = @"SELECT COUNT(*) FROM RG_ZiZhiZhuanYe WHERE ZiZhiCode='" + ZiZhiCode + "'";
            if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) == "0")
            {
                return false;
            }
            return true;
        }

        public void CopyZZZYToXM(string ZZCode, string XMGuid, string DWGuid)
        {
            string strSql = "SELECT * FROM RG_ZiZhiZhuanYe WHERE ZiZhiCode='" + ZZCode + "' ORDER BY ZhuanYeCode ASC";
            DataView dvZY = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            for (int m = 0; m < dvZY.Count; m++)
            {
                InsertZYForXM(dvZY[m]["ZiZhiText"].ToString(), dvZY[m]["ZiZhiCode"].ToString(), dvZY[m]["ZhuanYeText"].ToString(), dvZY[m]["ZhuanYeCode"].ToString(),
                    dvZY[m]["NeedRY"].ToString(), dvZY[m]["OWhere"].ToString(), XMGuid, DWGuid);
            }
        }
        /// <summary>
        /// 新增项目的所有专业
        /// </summary>
        /// <param name="ZiZhiText"></param>
        /// <param name="ZiZhiCode"></param>
        /// <param name="ZhuanYeText"></param>
        /// <param name="ZhuanYeCode"></param>
        /// <param name="NeedRY"></param>
        /// <param name="OWhere"></param>
        /// <param name="XMGuid"></param>
        /// <param name="DWGuid"></param>
        public void InsertZYForXM(string ZiZhiText, string ZiZhiCode, string ZhuanYeText, string ZhuanYeCode, string NeedRY, string OWhere, string XMGuid, string DWGuid)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @"INSERT INTO RG_XMAndZY(OperateDate,ZiZhiText,ZiZhiCode,ZhuanYeText,ZhuanYeCode,NeedRY,OWhere,XMGuid,DWGuid,RowGuid)
VALUES(GETDATE(),@ZiZhiText,@ZiZhiCode,@ZhuanYeText,@ZhuanYeCode,@NeedRY,@OWhere,@XMGuid,@DWGuid,NEWID())";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "ZiZhiText", DbType.String, ZiZhiText);
            db.AddInParameter(cmd, "ZiZhiCode", DbType.String, ZiZhiCode);
            db.AddInParameter(cmd, "ZhuanYeText", DbType.String, ZhuanYeText);
            db.AddInParameter(cmd, "ZhuanYeCode", DbType.String, ZhuanYeCode);
            db.AddInParameter(cmd, "NeedRY", DbType.String, NeedRY);
            db.AddInParameter(cmd, "OWhere", DbType.String, OWhere);
            db.AddInParameter(cmd, "XMGuid", DbType.String, XMGuid);
            db.AddInParameter(cmd, "DWGuid", DbType.String, DWGuid);

            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 删除某个项目的所有专业
        /// </summary>
        /// <param name="XMGuid"></param>
        public void DeleteAllZYOfXM(object XMGuid)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @"DELETE RG_XMAndZY WHERE XMGuid=@XMGuid";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "XMGuid", DbType.String, XMGuid);

            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// 判断该项目中是否存在某个人
        /// </summary>
        /// <param name="RYGuid"></param>
        /// <param name="XMGuid"></param>
        /// <returns></returns>
        public bool IsExistRYOfXM(string RYGuid, string XMGuid)
        {
            string strSql = @"SELECT COUNT(*) FROM RG_XMAndRY WHERE RYGuid='" + RYGuid + "' and XMGuid='" + XMGuid + "'";
            if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) == "0")
            {
                return false;
            }
            return true;
        }

        public void InsertXMRY(object ZiZhiCode, object ZiZhiText, object ZhuanYeCode, object RYGuid, object RYName, object XMGuid, object DWGuid, object IDNum
, object ZhiCheng, object YinZhangNo, object ZhuanYeSX, object ZhuanYeCS, object ZhuanYeCSCode, object GongLing, object DDRole, object ZhuanYeText)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @"INSERT INTO RG_XMAndRY(RowGuid,ZiZhiCode,ZiZhiText,ZhuanYeCode,RYGuid,RYName,XMGuid,DWGuid,IDNum
,ZhiCheng,YinZhangNo,ZhuanYeSX,ZhuanYeCS,ZhuanYeCSCode,GongLing,DDRole,ZhuanYeText)
VALUES(NEWID(),@ZiZhiCode,@ZiZhiText,@ZhuanYeCode,@RYGuid,@RYName,@XMGuid,@DWGuid,@IDNum
,@ZhiCheng,@YinZhangNo,@ZhuanYeSX,@ZhuanYeCS,@ZhuanYeCSCode,@GongLing,@DDRole,@ZhuanYeText)";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "ZiZhiText", DbType.String, ZiZhiText);
            db.AddInParameter(cmd, "ZiZhiCode", DbType.String, ZiZhiCode);
            db.AddInParameter(cmd, "ZhuanYeText", DbType.String, ZhuanYeText);
            db.AddInParameter(cmd, "ZhuanYeCode", DbType.String, ZhuanYeCode);
            db.AddInParameter(cmd, "RYGuid", DbType.String, RYGuid);
            db.AddInParameter(cmd, "RYName", DbType.String, RYName);
            db.AddInParameter(cmd, "XMGuid", DbType.String, XMGuid);
            db.AddInParameter(cmd, "DWGuid", DbType.String, DWGuid);

            db.AddInParameter(cmd, "IDNum", DbType.String, IDNum);
            db.AddInParameter(cmd, "ZhiCheng", DbType.String, ZhiCheng);
            db.AddInParameter(cmd, "YinZhangNo", DbType.String, YinZhangNo);
            db.AddInParameter(cmd, "ZhuanYeSX", DbType.String, ZhuanYeSX);
            db.AddInParameter(cmd, "ZhuanYeCS", DbType.String, ZhuanYeCS);
            db.AddInParameter(cmd, "ZhuanYeCSCode", DbType.String, ZhuanYeCSCode);
            db.AddInParameter(cmd, "GongLing", DbType.String, GongLing);
            db.AddInParameter(cmd, "DDRole", DbType.String, DDRole);

            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// 删除项目中的某个人
        /// </summary>
        /// <param name="RowGuid"></param>
        public void DeleteRYOfXM(object RowGuid)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @"DELETE RG_XMAndRY WHERE RowGuid=@RowGuid";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "RowGuid", DbType.String, RowGuid);

            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// 删除某个项目的所有人
        /// </summary>
        /// <param name="XMGuid"></param>
        public void DeleteAllRYOfXM(object XMGuid)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @"DELETE RG_XMAndRY WHERE XMGuid=@XMGuid";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "XMGuid", DbType.String, XMGuid);

            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// 更新删除状态
        /// </summary>
        /// <param name="DelStatus"></param>
        /// <param name="TableName"></param>
        /// <param name="othWhere"></param>
        public void DeleteByStatus(string DelStatus, string TableName, string othWhere)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @" UPDATE " + TableName + " SET DelStatus='" + DelStatus + "' WHERE 1=1 " + othWhere;
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            //db.AddInParameter(cmd, "XMGuid", DbType.String, XMGuid);

            db.ExecuteNonQuery(cmd);
        }
        public void DeleteByStatus(string TableName, string othWhere)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @" DELETE " + TableName + "  WHERE 1=1 " + othWhere;
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            //db.AddInParameter(cmd, "XMGuid", DbType.String, XMGuid);

            db.ExecuteNonQuery(cmd);
        }
        public void DeleteRGUser(string othWhere)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @" UPDATE RG_User SET DelFlag='1',DelStatus='1',IsValid='0'  WHERE 1=1 " + othWhere;
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            //db.AddInParameter(cmd, "XMGuid", DbType.String, XMGuid);

            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// 删除某个项目某个专业下的人
        /// </summary>
        /// <param name="ZhuanYeCode"></param>
        /// <param name="XMGuid"></param>
        public void DeleteRYOfXM(object ZhuanYeCode, object XMGuid)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @"DELETE RG_XMAndRY WHERE XMGuid=@XMGuid and ZhuanYeCode=@ZhuanYeCode";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "ZhuanYeCode", DbType.String, ZhuanYeCode);
            db.AddInParameter(cmd, "XMGuid", DbType.String, XMGuid);

            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// 判断要求配置人员的专业是否均已配置人员
        /// </summary>
        /// <param name="XMGuid"></param>
        /// <param name="DWGuid"></param>
        /// <param name="ZiZhiDJCode"></param>
        /// <returns></returns>
        public string ChenkZYRY(object XMGuid, object DWGuid, object ZiZhiDJCode)
        {
            string message = "";
            //先获取项目下的专业
            string strSql = " select * from RG_XMAndZY where 1=1  and XMGuid='" + XMGuid + "' ";
            strSql += " and DWGuid='" + DWGuid + "' and ZiZhiCode='" + ZiZhiDJCode + "' ";
            strSql += " ORDER BY ZhuanYeCode ASC ";
            DataView dvZY = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            for (int m = 0; m < dvZY.Count; m++)
            {
                //然后看看该专业是不是必须配置人员，如果必须配置，那么就看看有没有人
                strSql = "SELECT NeedRY FROM RG_ZiZhiZhuanYe WHERE ZiZhiCode='" + ZiZhiDJCode + "' AND ZhuanYeCode='" + dvZY[m]["ZhuanYeCode"] + "'";
                if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) == "1")
                {
                    //获取该专业下的人员数量，如果没有，则返回提示信息
                    strSql = "SELECT COUNT(*) FROM RG_XMAndRY WHERE XMGuid='" + XMGuid + "' AND ZhuanYeCode='" + dvZY[m]["ZhuanYeCode"] + "'";
                    if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) == "0")//说明没有配置人员
                    {
                        message += dvZY[m]["ZhuanYeText"].ToString() + "；";
                    }
                }

            }
            if (message != "")
            {
                message = message.Substring(0, message.Length - 1);
                message = "以下专业[" + message;
                message += "]没有配置人员";
            }
            return message;
        }
        /// <summary>
        /// 判断是否有项目负责人
        /// </summary>
        /// <param name="XMGuid"></param>
        /// <returns></returns>
        public string CheckXMFuZeRen(object XMGuid)
        {
            string message = "";
            //先获取项目下的专业
            string strSql = " select * from RG_XMAndRY where 1=1  and XMGuid='" + XMGuid + "' and (DDRole='95' or DDRole='94') ";
            DataView dvRY = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            if (dvRY.Count != 1)
            {
                if (dvRY.Count == 0)
                {
                    message = "项目没有设置项目负责人";
                    return message;
                }
                for (int m = 0; m < dvRY.Count; m++)
                {
                    message += dvRY[m]["ZhuanYeCS"];
                    message += "；";
                }
                message += "设置了项目负责人，请调整为只有一个项目负责人";
            }


            return message;
        }
        public string ChenkZYFuZeRen(object XMGuid, object DWGuid, object ZiZhiDJCode)
        {
            string message = "";
            int eAll = 0;
            int allRYCount = 0;
            int ZhuanYeRS = 2;//每个专业下的人数，省外要求至少2人，省外要求至少3人
            string QYZCD = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT RegistAddressCode FROM RG_OUInfo WHERE RowGuid='" + DWGuid + "'");
            if (QYZCD.Substring(0, 2) == "32")//省内
            {
                ZhuanYeRS = 2;
            }
            else
            {
                ZhuanYeRS = 3;
            }

            //先获取项目下的专业
            string strSql = " select * from RG_XMAndZY where 1=1  and XMGuid='" + XMGuid + "' ";
            strSql += " and DWGuid='" + DWGuid + "' and ZiZhiCode='" + ZiZhiDJCode + "' ";
            strSql += " ORDER BY ZhuanYeCode ASC ";
            DataView dvZY = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            for (int m = 0; m < dvZY.Count; m++)
            {
                //获取该专业下是否设置了专业负责人,先看看有没有人
                strSql = "SELECT COUNT(*) FROM RG_XMAndRY WHERE XMGuid='" + XMGuid + "' AND ZhuanYeCode='" + dvZY[m]["ZhuanYeCode"] + "' ";
                if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) != "0")//说明有配置人员，每个专业循环排查
                {
                    //有几个专业要进行合并处理
                    if (IsSameZY(dvZY[m]["ZhuanYeCode"]))
                    {
                        //再看看有没有专业负责人,注意是多个专业合并
                        strSql = "SELECT COUNT(*) FROM RG_XMAndRY WHERE XMGuid='" + XMGuid + "' AND ZhuanYeCode in ('0070','0071','0072','0074','0075','0076','0077','00670001','0067')  and (DDRole='90' or DDRole='94') ";
                        int i = Epoint.MisBizLogic2.DB.ExecuteToInt(strSql);
                        if (i != 1 && i != 0)//说明有多个专业负责人
                        {
                            eAll += 1;
                        }
                        strSql = "SELECT COUNT(*) FROM RG_XMAndRY WHERE XMGuid='" + XMGuid + "' AND ZhuanYeCode in ('0070','0071','0072','0074','0075','0076','0077','00670001','0067')  ";
                        if (Epoint.MisBizLogic2.DB.ExecuteToInt(strSql) < ZhuanYeRS)//说明人数不够
                        {
                            allRYCount += 1;
                        }
                    }
                    else
                    {
                        //再看看有没有专业负责人
                        strSql = "SELECT COUNT(*) FROM RG_XMAndRY WHERE XMGuid='" + XMGuid + "' AND (ZhuanYeCode like '" + dvZY[m]["ZhuanYeCode"].ToString().Substring(0, 4) + "%' or ZhuanYeCode='" + dvZY[m]["ZhuanYeCode"] + "' ) and (DDRole='90' or DDRole='94') ";
                        int i = Epoint.MisBizLogic2.DB.ExecuteToInt(strSql);
                        if (i != 1 && i != 0)//说明有多个专业负责人
                        {
                            eAll += 1;
                        }
                        strSql = "SELECT COUNT(*) FROM RG_XMAndRY WHERE XMGuid='" + XMGuid + "' AND (ZhuanYeCode like '" + dvZY[m]["ZhuanYeCode"].ToString().Substring(0, 4) + "%' or ZhuanYeCode='" + dvZY[m]["ZhuanYeCode"] + "' ) ";
                        if (Epoint.MisBizLogic2.DB.ExecuteToInt(strSql) < ZhuanYeRS)//说明人数不够
                        {
                            allRYCount += 1;
                        }
                    }
                }
            }
            if (eAll != 0)
            {
                message += "有[" + eAll;
                message += "]个专业没有或设置了多个专业负责人";
            }
            if (allRYCount != 0)
            {
                message += "有[" + allRYCount;
                message += "]个专业设置人员人数不满足要求";
            }
            return message;
        }
        public bool IsSameZY(object ZYCode)
        {
            bool Is = false;
            switch(ZYCode.ToString())
            {
                case "0070": //岩土工程勘察
                    Is = true;
                    break;
                case "0071":  //岩土工程设计
                    Is = true;
                    break;
                case "0072":  //水文地质
                    Is = true;
                    break;
                case "0074":  //工程物探
                    Is = true;
                    break;
                case "0075":  //岩土测试检测
                    Is = true;
                    break;
                case "0076":  //岩土监测
                    Is = true;
                    break;
                case "0077":  //室内试
                    Is = true;
                    break;
                case "0067":  //岩土
                    Is = true;
                    break;
                case "00670001":  //岩土注册
                    Is = true;
                    break;
            }
            return Is;
        }
        #endregion

        #region 项目内部信息

        /// <summary>
        /// 判断下在该项目的某个专业下，是否已经存在某个角色的人
        /// 项目负责人、专业负责人要求在从事专业中唯一，例如结构、采矿等
        /// 类似结构一级、结构二级，都算在结构里面
        /// </summary>
        /// <param name="XMGuid"></param>
        /// <param name="ZYCode"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsHaveRolsInXM(object XMGuid, object ZYCode, object role, object RYGuid)
        {
            //首选看看全部正式人员中是否已经有了
            string strSql = "SELECT COUNT(*) FROM RG_XMAndRY WHERE XMGUID='" + XMGuid + "' AND ZhuanYeCode='" + ZYCode.ToString() + "' AND DDROLE='" + role + "' and RYGuid<>'" + RYGuid + "' ";
            //"' AND substring(ZhuanYeCode,1,4)=' " + ZYCode.ToString().Substring(0, 4) 
            if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) != "0")
            {
                return true;
            }
            return false;
        }
        public bool IsHaveRolsInXM(object XMGuid, object role, object RYGuid)
        {
            //首选看看全部正式人员中是否已经有了
            string strSql = "SELECT COUNT(*) FROM RG_XMAndRY WHERE XMGUID='" + XMGuid + "'  AND DDROLE='" + role + "' and RYGuid<>'" + RYGuid + "' ";

            if (Epoint.MisBizLogic2.DB.ExecuteToString(strSql) != "0")
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 企业
        /// <summary>
        /// 判断组织机构代码是否存在，并返回单位信息
        /// </summary>
        /// <param name="CodeCertificate"></param>
        /// <returns></returns>
        public DataView CheckCodeForRowGuid(string FName, string FValue)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT RowGuid, EnterpriseName FROM RG_OUInfo WHERE DelStatus='0' and " + FName + "='" + FValue + "'";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }
        #endregion

        #region 备案
        /// <summary>
        /// 获取备案提示信息
        /// </summary>
        /// <param name="Status">备案状态</param>
        /// <param name="SF">第一步的标记，新增：Add，修改：Edit</param>
        /// <param name="IsSW">是否是省外，省外：1，省内：0</param>
        /// <param name="XMADD">项目地点，主要区分江阴、宜兴</param>
        public string GetTip(object Status, object SF, object IsSW, string XMADD)
        {
            /* 60  编辑中
             * 68  区县审核
             * 69  区县审批
             * 70  初审
             * 80  审核退回
             * 86  审核
             * 87  审批
             * 90  审核通过
             */
            StringBuilder sb = new StringBuilder();
            string _Status = Status.ToString();
            string _SF = SF.ToString();
            string strRed = "<span style='color:red'>{0}</span>";
            string strBla = "<span>{0}</span>"; ;
            string str1 = "第一步：填写项目合同备案信息</br>";
            string str2 = "第二步：配置项目人员，配置完成后下载备案表，相关人员签字并加盖单位公章后将该文件上传至页面下方的[勘察设计合同备案表]中，然后提交审核</br>";
            string strJY = "第三步：江阴主管单位对备案信息进行审核、审批</br>";
            string strYX = "第三步：宜兴主管单位对备案信息进行审核、审批</br>";
            string str3 = "第三步：主管单位对备案信息进行审核";
            string str31 = "第四步：主管单位对备案信息进行审核";

            string str4 = "第四步：审核不通过，根据审核意见进行调整后重复第二步";
            string str5 = "第四步：审核通过";

            string str41 = "第五步：审核不通过，根据审核意见进行调整后重复第二步";
            string str51 = "第五步：审核通过";

            //if (IsSW != "1")
            //{
            //    str5 = "第四步：审核通过";
            //}
            //string 
            #region 编辑中
            if (_Status == "60")//编辑中
            {
                if (_SF == "Add")
                {
                    sb.Append(string.Format(strRed, str1));
                    sb.Append(string.Format(strBla, str2));
                    sb.Append(string.Format(strBla, str3) + "</br>");
                    sb.Append(string.Format(strBla, str5));
                }
                else
                {
                    sb.Append(string.Format(strBla, str1));
                    sb.Append(string.Format(strRed, str2));
                    sb.Append(string.Format(strBla, str3) + "</br>");
                    sb.Append(string.Format(strBla, str5));
                }
            }
            #endregion
            #region 区县审核
            else if (_Status == "69")//区县审核
            {
                sb.Append(string.Format(strBla, str1));
                sb.Append(string.Format(strBla, str2));
                if (XMADD == "320282")//宜兴
                {
                    sb.Append(string.Format(strRed, strYX));
                    sb.Append(string.Format(strBla, str31) + "</br>");
                    sb.Append(string.Format(strBla, str51));
                }
                else if (XMADD == "320281")//江阴
                {
                    sb.Append(string.Format(strRed, strJY));
                    sb.Append(string.Format(strBla, str31) + "</br>");
                    sb.Append(string.Format(strBla, str51));
                }
                else
                {
                    sb.Append(string.Format(strRed, str3) + "</br>");
                    sb.Append(string.Format(strBla, str5));
                }


            }
            #endregion
            #region 区县审批
            else if (_Status == "68")//区县审核
            {
                sb.Append(string.Format(strBla, str1));
                sb.Append(string.Format(strBla, str2));
                if (XMADD == "320282")//宜兴
                {
                    sb.Append(string.Format(strRed, strYX));
                    sb.Append(string.Format(strBla, str31) + "</br>");
                    sb.Append(string.Format(strBla, str51));
                }
                else if (XMADD == "320281")//江阴
                {
                    sb.Append(string.Format(strRed, strJY));
                    sb.Append(string.Format(strBla, str31) + "</br>");
                    sb.Append(string.Format(strBla, str51));
                }
                else
                {
                    sb.Append(string.Format(strRed, str3) + "</br>");
                    sb.Append(string.Format(strBla, str5));
                }


            }
            #endregion
            #region 初审中
            else if (_Status == "70")//待审核
            {
                sb.Append(string.Format(strBla, str1));
                sb.Append(string.Format(strBla, str2));
                if (XMADD == "320282")//宜兴
                {
                    sb.Append(string.Format(strBla, strYX));
                    sb.Append(string.Format(strRed, str31) + "</br>");
                    sb.Append(string.Format(strBla, str51));
                }
                else if (XMADD == "320281")//江阴
                {
                    sb.Append(string.Format(strBla, strJY));
                    sb.Append(string.Format(strRed, str31) + "</br>");
                    sb.Append(string.Format(strBla, str51));
                }
                else
                {
                    sb.Append(string.Format(strRed, str3) + "<span style='color:red'>，正初审中</span>，还需进行审核、审批</br>");
                    sb.Append(string.Format(strBla, str5));
                }
            }
            #endregion
            #region 审核退回
            else if (_Status == "80")//审核退回
            {
                sb.Append(string.Format(strBla, str1));
                sb.Append(string.Format(strBla, str2));
                if (XMADD == "320282")//宜兴
                {
                    sb.Append(string.Format(strBla, strYX));
                    sb.Append(string.Format(strBla, str31));
                    sb.Append(string.Format(strRed, str41));
                }
                else if (XMADD == "320281")//江阴
                {
                    sb.Append(string.Format(strBla, strJY));
                    sb.Append(string.Format(strBla, str31));
                    sb.Append(string.Format(strRed, str41));
                }
                else
                {
                    sb.Append(string.Format(strRed, str4));
                    //sb.Append(string.Format(strBla, str5));
                }

            }
            #endregion
            #region 审核通过
            else if (_Status == "90")//审核通过
            {
                sb.Append(string.Format(strBla, str1));
                sb.Append(string.Format(strBla, str2));
                if (XMADD == "320282")//宜兴
                {
                    sb.Append(string.Format(strBla, strYX));
                    sb.Append(string.Format(strBla, str31) + "</br>");
                    sb.Append(string.Format(strRed, str51));
                }
                else if (XMADD == "320281")//江阴
                {
                    sb.Append(string.Format(strBla, strJY));
                    sb.Append(string.Format(strBla, str31) + "</br>");
                    sb.Append(string.Format(strRed, str51));
                }
                else
                {
                    sb.Append(string.Format(strBla, str3) + "</br>");
                    sb.Append(string.Format(strRed, str5));
                }

            }
            #endregion
            #region 审核中
            else if (_Status == "86")//审核中
            {
                sb.Append(string.Format(strBla, str1));
                sb.Append(string.Format(strBla, str2));

                sb.Append("第三步：主管单位对备案信息进行审核，初审已通过，<span style='color:red'>正审核中</span>，还需进行审批</br>");
                sb.Append(string.Format(strBla, str5));


            }
            #endregion
            #region 审批中
            else if (_Status == "87")//审核中
            {
                sb.Append(string.Format(strBla, str1));
                sb.Append(string.Format(strBla, str2));

                sb.Append("第三步：主管单位对备案信息进行审核，初审、审核已通过<span style='color:red'>，正审批中</span></br>");
                sb.Append(string.Format(strBla, str5));


            }
            #endregion
            return sb.ToString();
        }
            #endregion

    }
}