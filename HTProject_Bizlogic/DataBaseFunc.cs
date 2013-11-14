using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Web.UI.WebControls;

namespace HTProject_Bizlogic
{
    public class DataBaseFunc
    {
        static DataBaseFunc instace = null;
        public static DataBaseFunc Instace { get { if (instace == null) instace = new DataBaseFunc(); return instace; } }

        /// <summary>
        /// 返回所有城市信息
        /// </summary>
        /// <param name="LeftCityCode"></param>
        /// <param name="CityCode"></param>
        /// <returns></returns>
        public DataView GetCity()
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT * FROM RG_City ORDER BY CityCode";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// 返回第二级的城市信息
        /// </summary>
        /// <param name="LeftCityCode"></param>
        /// <param name="CityCode"></param>
        /// <returns></returns>
        public DataView GetCityLevelTwo(string LeftCityCode, string CityCode)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT * FROM RG_City WHERE Right(CityCode, 2)='00' AND Left(CityCode, 2)='" + LeftCityCode + "' AND CityCode<>'" + CityCode + "' ORDER BY ID";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// 返回第三级的城市信息
        /// </summary>
        /// <param name="LeftCityCode"></param>
        /// <param name="CityCode"></param>
        /// <returns></returns>
        public DataView GetCityLevelThree(string LeftCityCode)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT * FROM RG_City WHERE Right(CityCode, 2)<>'00' AND Left(CityCode, 4)='" + LeftCityCode + "' ORDER BY ID";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// 返回所有专业信息
        /// </summary>
        /// <param name="LeftCityCode"></param>
        /// <param name="CityCode"></param>
        /// <returns></returns>
        public DataView GetTree(string MainGuid, string otherWhere)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "select * from Frame_Code_Item where MainGuid='" + MainGuid + "' and LEN(ItemCode)=4 ";
            if (otherWhere != "")
            {
                strSql += otherWhere;
            }
            strSql += " order by OrderNumber desc,Row_ID asc ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// 返回第二级的城市信息
        /// </summary>
        /// <param name="LeftCityCode"></param>
        /// <param name="CityCode"></param>
        /// <returns></returns>
        public DataView GetTreeLevelTwo(string ZYCode,string MainGuid,string otherWhere)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "select * from Frame_Code_Item where MainGuid='" + MainGuid + "' and ItemCode like'" + ZYCode + "%' and LEN(ItemCode)=" + (ZYCode.Length + 4).ToString() + " and ItemCode<>'" + ZYCode + "' ";
            if (otherWhere != "")
            {
                strSql += otherWhere;
            }
            strSql += " order by OrderNumber desc,Row_ID asc ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        
        
        /// <summary>
        /// 获取某个表的某个字段的内容，如果有多条可通过where和order来获取
        /// 李法庭应用，2011-04-01
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="FieldName"></param>
        /// <param name="strWhere">可包含order</param>
        /// <returns></returns>
        public static string GetMaxString(string TableName, string FieldName, string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = string.Format( "SELECT {1} FROM {0} WHERE 1=1 {2} ",TableName,FieldName,strWhere);

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            DataView dv = db.ExecuteDataView(cmd);
            if (dv.Count > 0)
            {
                return dv[0][0].ToString();
            }
            return "";
        }


        /// <summary>
        /// 使用分页技术绑定DataGrid
        /// </summary>
        /// <param name="CommandText">待执行的SQL语句</param>
        /// <param name="Pager">分页控件</param>
        /// <param name="dg_ToPager">待分页的DataGrid</param>
        public void Get_RecordSet_Pager(string CommandText, Wuqi.Webdiyer.AspNetPager Pager, DataGrid dg_ToPager, string strCon_Name)
        {
            DataSet ds = new DataSet();

            Database db = DatabaseFactory.CreateDatabase(strCon_Name);
            DbCommand cmd = db.GetStoredProcCommand("sp_PageView");

            db.AddInParameter(cmd, "@sql", DbType.String, CommandText);
            db.AddInParameter(cmd, "@PageCurrent", DbType.Int32, Pager.CurrentPageIndex);
            db.AddInParameter(cmd, "@PageSize", DbType.Int32, Pager.PageSize);
            ds = db.ExecuteDataSet(cmd);

            dg_ToPager.DataSource = ds.Tables[2].DefaultView;
            dg_ToPager.DataBind();

            Pager.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0]["RecordCount"]);
            Pager.CustomInfoText = "记录总数：<font color=\"blue\"><b>" + Pager.RecordCount.ToString() + "</b></font>";
            Pager.CustomInfoText += "总页数：<font color=\"blue\"><b>" + Pager.PageCount.ToString() + "</b></font>";
            Pager.CustomInfoText += "当前页：<font color=\"red\"><b>" + Pager.CurrentPageIndex.ToString() + "</b></font>";
        }

        /// <summary>
        /// 删除流程实例数据，包括待办事宜
        /// </summary>
        /// <param name="ProcessVersionInstanceGuid"></param>
        public void DeleteProcessVersionInstance(string ProcessVersionInstanceGuid)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            DbCommand cmd = db.GetStoredProcCommand("DeleteProcessVersionInstance");
            db.AddInParameter(cmd, "ProcessVersionInstanceGuid", DbType.String, ProcessVersionInstanceGuid);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 根据PVIGuid和步骤名称，获取某一步最后通过日期
        /// 李法庭，2011-04-26
        /// </summary>
        /// <param name="PVIGuid"></param>
        /// <param name="stepName"></param>
        /// <returns></returns>
        public string GetPassDateByPVIGuid(object PVIGuid, object stepName)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @"SELECT EndDate FROM Workflow_WorkItem WHERE ProcessVersionInstanceGuid=@PVIGuid
                    AND ActivityName=@stepName AND Enddate IS NOT NULL ORDER BY ROW_ID DESC";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "PVIGuid", DbType.String, PVIGuid);
            db.AddInParameter(cmd, "stepName", DbType.String, stepName);
            DataView dv = db.ExecuteDataView(cmd);
            if(dv.Count>0)
            {
                return DateTime.Parse( dv[0][0].ToString()).ToString("yyyy-MM-dd");
            }
            return "";
        }

        public DataView GetUserByRoleAndOU(string OUGuid, string RoleName)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @"SELECT * FROM frame_user 
WHERE OUGuid=@OUGuid
AND UserGuid IN 
(SELECT UserGuid FROM Frame_UserRoleRelation WHERE RoleGuid=
(SELECT RoleGuid FROM frame_role WHERE rolename=@RoleName))";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "OUGuid", DbType.String, OUGuid);
            db.AddInParameter(cmd, "RoleName", DbType.String, RoleName);
            DataView dv = db.ExecuteDataView(cmd);
            return dv;
        }
        public DataView GetUserByRoleName(string RoleName)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = @"SELECT * FROM frame_user 
WHERE UserGuid IN 
(SELECT UserGuid FROM Frame_UserRoleRelation WHERE RoleGuid=
(SELECT RoleGuid FROM frame_role WHERE rolename=@RoleName))";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "RoleName", DbType.String, RoleName);
            DataView dv = db.ExecuteDataView(cmd);
            return dv;
        }

        public DataTable GetData_Page(string RoleName, int PageSize, int CurrPage, string TableName, string UniqueField, string Where, string OrderBy, out int TotalNum)
        {
            DBOperate DBDrop = new Microsoft.Practices.EnterpriseLibrary.Data.DBOperate();

            DBDrop.ConnectionStringName = "Frame_ConnectionString";

            DataTable myDt;


            myDt = DBDrop.GetData_Page(
                RoleName,
                PageSize,
                CurrPage,
                TableName,
                UniqueField,
                Where,
                OrderBy,
                out TotalNum
                );

            return myDt;
        }
    }
}
