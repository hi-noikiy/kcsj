using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Epoint.Frame.Common;

namespace HTProject_Bizlogic
{
    /// <summary>
    /// 会员数据操作
    /// </summary>
    public class DB_RG_User
    {
        /// <summary>
        /// 删除会员及其关联的所有信息
        /// </summary>
        /// <param name="UserGuid">会员Guid</param>
        public void DeleteAllUserInfo(string UserGuid)
        {
            string strNewLine = Environment.NewLine;
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            StringBuilder sb = new StringBuilder();

            sb.Append(" DELETE FROM RG_Application_Right WHERE AllowGuid='" + UserGuid + "' " + strNewLine);
            sb.Append(" DELETE FROM RG_Module_Right WHERE AllowGuid='" + UserGuid + "' " + strNewLine);
            sb.Append(" DELETE FROM RG_ShortcutMenu_Right WHERE AllowGuid='" + UserGuid + "' " + strNewLine);
            sb.Append(" DELETE FROM RG_User_Role WHERE RGUserGUID='" + UserGuid + "' " + strNewLine);
            sb.Append(" DELETE FROM RG_WebInfoCateRight WHERE AllowGuid='" + UserGuid + "' " + strNewLine);

            sb.Append(" DELETE FROM RG_User WHERE RowGuid='" + UserGuid + "' " + strNewLine);
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.ExecuteNonQuery(cmd);
        }


        /// <summary>
        /// 更新会员的审核状态
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <param name="UserStatus"></param>
        /// <param name="IsValid"></param>
        public void UpdateRGUserStatus(string UserGuid, string UserStatus, string IsValid)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "UPDATE RG_User SET IsValid='" + IsValid + "', UserStatus='" + UserStatus + "' WHERE RowGuid='" + UserGuid + "'";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 获取单位的单位类型
        /// </summary>
        /// <param name="OUInfoGuid"></param>
        /// <returns></returns>
        public DataView GetDWTypeByOUInfoGuid(string OUInfoGuid)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT OuType FROM RG_OuType_Relate WHERE RelatedGuid='" + OUInfoGuid + "' AND RelatedType='Ou'";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// 获取会员的单位类型
        /// </summary>
        /// <param name="RGUserGuid"></param>
        /// <returns></returns>
        public DataView GetDWTypeByRGUserGuid(string RGUserGuid)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT OuType FROM RG_OuType_Relate WHERE RelatedGuid='" + RGUserGuid + "' AND RelatedType='User'";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// 获取所有还没有设置会员的单位
        /// </summary>
        /// <returns></returns>
        public DataView GetAllDWWithOutUser()
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT EnterpriseName, RowGuid FROM RG_OUInfo WHERE NOT EXISTS(SELECT 1 FROM RG_User WHERE RG_User.DanWeiGuid=RG_OUInfo.RowGuid)";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// 检测用户名是否已存在
        /// </summary>
        /// <param name="LoginID"></param>
        /// <returns></returns>
        public bool CheckUserExist(string LoginID)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT RowGuid FROM RG_User WHERE LoginID='" + LoginID + "'";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            DataView dv = db.ExecuteDataView(cmd);
            if (dv.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检测用户名是否已存在
        /// 修改会员时，有可能修改登录名，这时候需要验证
        /// 修改的登录名是不是已经存在，但是又和当前记录不一样，
        /// 所以需要用RowGuid判断
        /// </summary>
        /// <param name="LoginID">登录名</param>
        /// <param name="RGUserGuid"></param>
        /// <returns></returns>
        public bool CheckUserExist(string LoginID, string RGUserGuid)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT RowGuid FROM RG_User WHERE LoginID='" + LoginID + "' AND RowGuid<>'" + RGUserGuid + "'";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            DataView dv = db.ExecuteDataView(cmd);
            if (dv.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检测单位是否已存在会员
        /// </summary>
        /// <param name="OUInfoGuid"></param>
        /// <returns></returns>
        public DataView CheckDWHasUser(string OUInfoGuid)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT RowGuid, DispName, LoginID FROM RG_User WHERE DanWeiGuid='" + OUInfoGuid + "'";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// 检测是否已经存在指定的单位类别
        /// </summary>
        /// <param name="RGUserGuid"></param>
        /// <param name="OuType"></param>
        /// <returns></returns>
        public bool CheckUserTypeExist(string RGUserGuid, string OuType)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT RowGuid FROM RG_OuType_Relate WHERE RelatedGuid='" + RGUserGuid + "' AND OuType='" + OuType + "' AND RelatedType='User'";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            DataView dv = db.ExecuteDataView(cmd);
            if (dv.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除指定的单位类别（会员选定的）
        /// </summary>
        /// <param name="RGUserGuid"></param>
        /// <param name="OuType"></param>
        public void DeleteUserType(string RGUserGuid, string OuType)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "DELETE FROM RG_OuType_Relate WHERE RelatedGuid='" + RGUserGuid + "' AND OuType='" + OuType + "' AND RelatedType='User'";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 根据rowguid获取单位的所有帐号
        /// 编写日期：2010/11/24
        /// 编写人：mxr
        /// </summary>
        /// <param name="RowGuid"></param>
        public DataView GetAllUserByDWGuid(string DanWeiGuid)
        {
            Database db = DatabaseFactory.CreateDatabase("Frame_ConnectionString");
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT RowGuid, DispName, LoginID,DispName+'['+LoginID+']' as ShowMC,UserType FROM RG_User WHERE DanWeiGuid=@DanWeiGuid " :
                "SELECT RowGuid, DispName, LoginID,DispName+'['+LoginID+']' as ShowMC,UserType FROM RG_User WHERE DanWeiGuid=:DanWeiGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "DanWeiGuid", DbType.String, DanWeiGuid);
            return db.ExecuteDataView(cmd);
        }

        public Detail_RG_User GetDetail(string RowGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT * FROM RG_User WHERE  RowGuid=@RowGuid " :
                "SELECT * FROM RG_User WHERE  RowGuid=:RowGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "RowGuid", DbType.String, RowGuid);
            Detail_RG_User myDetail = new Detail_RG_User();
            using (IDataReader myReader = db.ExecuteReader(cmd))
            {
                if (myReader.Read())
                {
                    if (!Convert.IsDBNull(myReader["RowGuid"]))
                    {
                        myDetail.RowGuid = Convert.ToString(myReader["RowGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["DispName"]))
                    {
                        myDetail.DispName = Convert.ToString(myReader["DispName"]);
                    }
                    if (!Convert.IsDBNull(myReader["LoginID"]))
                    {
                        myDetail.LoginID = Convert.ToString(myReader["LoginID"]);
                    }
                    if (!Convert.IsDBNull(myReader["Mobile"]))
                    {
                        myDetail.Mobile = Convert.ToString(myReader["Mobile"]);
                    }
                    if (!Convert.IsDBNull(myReader["Sex"]))
                    {
                        myDetail.Sex = Convert.ToString(myReader["Sex"]);
                    }
                    if (!Convert.IsDBNull(myReader["OfficeTel"]))
                    {
                        myDetail.OfficeTel = Convert.ToString(myReader["OfficeTel"]);
                    }                    
                    if (!Convert.IsDBNull(myReader["DWGuid"]))
                    {
                        myDetail.DWGuid = Convert.ToString(myReader["DWGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["DWName"]))
                    {
                        myDetail.DWName = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT EnterpriseName FROM RG_OUInfo WHERE RowGuid='" + myReader["DWGuid"] + "'");
                    }
                }
            }

            return myDetail;
        }

        public Detail_RG_User GetDetail2(string LoginID)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT * FROM RG_User WHERE  LoginID=@LoginID " :
                "SELECT * FROM RG_User WHERE  LoginID=:LoginID ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "LoginID", DbType.String, LoginID);
            Detail_RG_User myDetail = new Detail_RG_User();
            using (IDataReader myReader = db.ExecuteReader(cmd))
            {
                if (myReader.Read())
                {
                    if (!Convert.IsDBNull(myReader["RowGuid"]))
                    {
                        myDetail.RowGuid = Convert.ToString(myReader["RowGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["DispName"]))
                    {
                        myDetail.DispName = Convert.ToString(myReader["DispName"]);
                    }
                    if (!Convert.IsDBNull(myReader["LoginID"]))
                    {
                        myDetail.LoginID = Convert.ToString(myReader["LoginID"]);
                    }
                    if (!Convert.IsDBNull(myReader["Mobile"]))
                    {
                        myDetail.Mobile = Convert.ToString(myReader["Mobile"]);
                    }
                    if (!Convert.IsDBNull(myReader["Sex"]))
                    {
                        myDetail.Sex = Convert.ToString(myReader["Sex"]);
                    }
                    if (!Convert.IsDBNull(myReader["OfficeTel"]))
                    {
                        myDetail.OfficeTel = Convert.ToString(myReader["OfficeTel"]);
                    }
                    if (!Convert.IsDBNull(myReader["DWGuid"]))
                    {
                        myDetail.DWGuid = Convert.ToString(myReader["DWGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["DWName"]))
                    {
                        myDetail.DWName = Epoint.MisBizLogic2.DB.ExecuteToString("SELECT EnterpriseName FROM RG_OUInfo WHERE RowGuid='" + myReader["DWGuid"] + "'");
                    }
                }
            }

            return myDetail;
        }
    }

    public class Detail_RG_User
    {
        /// <summary>
        /// 唯一Guid
        /// </summary>
        private string _RowGuid;
        public string RowGuid
        {
            get { return _RowGuid; }
            set { _RowGuid = value; }
        }

        private string _DispName;
        public string DispName
        {
            get { return _DispName; }
            set { _DispName = value; }
        }

        private string _LoginID;
        public string LoginID
        {
            get { return _LoginID; }
            set { _LoginID = value; }
        }

        private string _Mobile;
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }

        private string _Sex;
        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        private string _OfficeTel;
        public string OfficeTel
        {
            get { return _OfficeTel; }
            set { _OfficeTel = value; }
        }

        private string _DWGuid;
        public string DWGuid
        {
            get { return _DWGuid; }
            set { _DWGuid = value; }
        }

        private string _DWName;
        public string DWName
        {
            get { return _DWName; }
            set { _DWName = value; }
        }
    }
}
