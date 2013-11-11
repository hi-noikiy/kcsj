using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HTProject_Bizlogic.AttachManage
{
    /// <summary>
    /// 扫描件管理类
    /// </summary>
    public class DB_Frame_Attach
    {
        /// <summary>
        /// 获取扫描件信息
        /// CliengGuid用于关联单位，人员等的标识
        /// CliengTag用来存储附件的类型编码
        /// 例如编码值00101，前3位可以表示附件类别，如单位、人员等类别
        /// 后2位则用于表示扫描件的具体类型，如组织机构代码证、营业执照等
        /// CliengCategory表示附件类别的编码，如上面例子的001即为附件类别的编码
        /// </summary>
        /// <param name="CliengGuid"></param>
        /// <param name="CliengTag">附件类型的具体编码值</param>
        /// <param name="CliengCategory">附件类别</param>
        /// <returns></returns>
        public DataView GetAttachFileInfo(string CliengGuid, string CliengTag, string CliengCategory)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT AttachGuid,AttachFileName,ContentType,AttachLength,Attach_ConnectionStringName,CliengTag,CliengGuid FROM Frame_AttachInfo WHERE CliengGuid='" + CliengGuid + "'";
            
            if (CliengTag != "")
            {
                strSql += " AND CliengTag='" + CliengTag + "'";
            }
            //某一类别的扫描件
            if (CliengCategory != "")
            {
                strSql += " AND CliengTag LIKE '" + CliengCategory + "%'";
            }

            //排序
            strSql += " ORDER BY CliengTag";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// 获取扫描件的数量
        /// </summary>
        /// <param name="CliengGuid"></param>
        /// <param name="CliengTag"></param>
        /// <param name="CliengCategory"></param>
        /// <returns></returns>
        public int GetAttachFileAmount(string CliengGuid, string CliengTag, string CliengCategory)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT Count(AttachGuid) FROM Frame_AttachInfo WHERE CliengGuid='" + CliengGuid + "'";
            if (CliengTag != "")
            {
                strSql += " AND CliengTag='" + CliengTag + "'";
            }
            if (CliengCategory != "")
            {
                strSql += " AND CliengTag LIKE '" + CliengCategory + "%'";
            }

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return Convert.ToInt32(db.ExecuteScalar(cmd));
        }

        /// <summary>
        /// 删除附件信息及其内容
        /// </summary>
        /// <param name="AttachGuid"></param>
        public void DeleteAttachFile(string AttachGuid)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            //查找附件外库的连接字符串
            string strSql = "SELECT Attach_ConnectionStringName FROM Frame_AttachInfo WHERE AttachGuid='" + AttachGuid + "'";
            string Attach_ConnectionString = "";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            DataView dv = db.ExecuteDataView(cmd);
            if (dv.Count > 0 && dv[0]["Attach_ConnectionStringName"].ToString() != "")
            {
                Attach_ConnectionString = GetAttach_ConnectionString(dv[0]["Attach_ConnectionStringName"].ToString());
            }

            string strDelSql = "DELETE FROM Frame_AttachInfo WHERE AttachGuid='" + AttachGuid + "' ";
            if (Attach_ConnectionString == "")
            {
                strDelSql += " DELETE FROM Frame_AttachStorage WHERE AttachGuid='" + AttachGuid + "' ";
            }

            cmd = db.GetSqlStringCommand(strDelSql);
            db.ExecuteNonQuery(cmd);

            //删除附件库中的附件
            if (Attach_ConnectionString != "")
            {
                db = DatabaseFactory.CreateDatabase(Attach_ConnectionString);
                strDelSql = " DELETE FROM Frame_AttachStorage WHERE AttachGuid='" + AttachGuid + "' ";

                cmd = db.GetSqlStringCommand(strDelSql);
                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 上传附件信息
        /// </summary>
        /// <param name="AttachGuid"></param>
        /// <param name="AttachFileName"></param>
        /// <param name="ContentType"></param>
        /// <param name="AttachLength"></param>
        /// <param name="CliengTag"></param>
        /// <param name="CliengGuid"></param>
        /// <param name="UploadUserGuid"></param>
        /// <param name="UploadUserDisplayName"></param>
        /// <param name="UploadDateTime"></param>
        public void InsertAttachInfo(string AttachGuid, string AttachFileName, string ContentType, int AttachLength, string Attach_ConnectionStringName,
            string CliengTag, string CliengGuid, string UploadUserGuid, string UploadUserDisplayName, DateTime UploadDateTime)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Frame_AttachInfo(");
            //字段
            sb.Append("AttachGuid");
            sb.Append(",AttachFileName");
            sb.Append(",ContentType");
            sb.Append(",AttachLength");
            sb.Append(",Attach_ConnectionStringName");
            sb.Append(",CliengTag");
            sb.Append(",CliengGuid");
            sb.Append(",UploadUserGuid");
            sb.Append(",UploadUserDisplayName");
            sb.Append(",UploadDateTime");
            sb.Append(",AttachStorageGuid");
            sb.Append(",PartitionTag");
            sb.Append(")VALUES(");
            //数据
            sb.Append("@AttachGuid");
            sb.Append(",@AttachFileName");
            sb.Append(",@ContentType");
            sb.Append(",@AttachLength");
            sb.Append(",@Attach_ConnectionStringName");
            sb.Append(",@CliengTag");
            sb.Append(",@CliengGuid");
            sb.Append(",@UploadUserGuid");
            sb.Append(",@UploadUserDisplayName");
            sb.Append(",@UploadDateTime");
            sb.Append(",@AttachStorageGuid");
            sb.Append(",@PartitionTag");
            sb.Append(")");

            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());
            db.AddInParameter(cmd, "AttachGuid", DbType.String, AttachGuid);
            db.AddInParameter(cmd, "AttachFileName", DbType.String, AttachFileName);
            db.AddInParameter(cmd, "ContentType", DbType.String, ContentType);
            db.AddInParameter(cmd, "AttachLength", DbType.Int32, AttachLength);
            db.AddInParameter(cmd, "Attach_ConnectionStringName", DbType.String, Attach_ConnectionStringName);
            db.AddInParameter(cmd, "CliengTag", DbType.String, CliengTag);
            db.AddInParameter(cmd, "CliengGuid", DbType.String, CliengGuid);
            db.AddInParameter(cmd, "UploadUserGuid", DbType.String, UploadUserGuid);
            db.AddInParameter(cmd, "UploadUserDisplayName", DbType.String, UploadUserDisplayName);
            db.AddInParameter(cmd, "UploadDateTime", DbType.DateTime, UploadDateTime);
            db.AddInParameter(cmd, "AttachStorageGuid", DbType.String, AttachGuid);
            db.AddInParameter(cmd, "PartitionTag", DbType.String, "0");

            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 上传附件内容
        /// </summary>
        /// <param name="AttachGuid"></param>
        /// <param name="AttachFileName"></param>
        /// <param name="ContentType"></param>
        /// <param name="Content"></param>
        /// <param name="DocumentType"></param>
        /// <param name="CliengTag"></param>
        /// <param name="CliengGuid"></param>
        /// <param name="Attach_ConnectionString">附件库连接字符串</param>
        public void InsertAttachStroage(string AttachGuid, string AttachFileName, string ContentType, byte[] Content
            , string DocumentType, string CliengTag, string CliengGuid, string Attach_ConnectionString)
        {
            Database db = null;
            if (Attach_ConnectionString == null || Attach_ConnectionString == "")
            {
                //与附件信息同一个库
                db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            }
            else
            {
                db = DatabaseFactory.CreateDatabase(Attach_ConnectionString);
            }
             
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Frame_AttachStorage(");
            //字段
            sb.Append("AttachGuid");
            sb.Append(",AttachFileName");
            sb.Append(",ContentType");
            sb.Append(",Content");
            sb.Append(",DocumentType");
            sb.Append(",CliengTag");
            sb.Append(",CliengGuid");
            sb.Append(")VALUES(");
            //数据
            sb.Append("@AttachGuid");
            sb.Append(",@AttachFileName");
            sb.Append(",@ContentType");
            sb.Append(",@Content");
            sb.Append(",@DocumentType");
            sb.Append(",@CliengTag");
            sb.Append(",@CliengGuid");
            sb.Append(")");

            SqlCommand cmd = (SqlCommand)db.GetSqlStringCommand(sb.ToString());
            cmd.Parameters.Add(new SqlParameter("AttachGuid", SqlDbType.NVarChar, 50)).Value = AttachGuid;
            cmd.Parameters.Add(new SqlParameter("AttachFileName", SqlDbType.NVarChar, 100)).Value = AttachFileName;
            cmd.Parameters.Add(new SqlParameter("ContentType", SqlDbType.NVarChar, 200)).Value = ContentType;
            cmd.Parameters.Add(new SqlParameter("Content", SqlDbType.Image, 0)).Value = Content;
            cmd.Parameters.Add(new SqlParameter("DocumentType", SqlDbType.NVarChar, 50)).Value = DocumentType;
            cmd.Parameters.Add(new SqlParameter("CliengTag", SqlDbType.NVarChar, 200)).Value = CliengTag;
            cmd.Parameters.Add(new SqlParameter("CliengGuid", SqlDbType.NVarChar, 100)).Value = CliengGuid;

            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 如果图片翻转，可以将翻转后的图片保存到数据库中
        /// </summary>
        /// <param name="AttachGuid"></param>
        /// <param name="Content"></param>
        public void UpdateAttachContent(string AttachGuid, byte[] Content, string Attach_ConnectionString)
        {
            Database db = null;
            if (Attach_ConnectionString == null || Attach_ConnectionString == "")
            {
                db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            }
            else
            { 
                DatabaseFactory.CreateDatabase(Attach_ConnectionString);
            }

            string strSql = "UPDATE Frame_AttachStorage SET Content=@Content WHERE AttachGuid='" + AttachGuid + "'";

            SqlCommand cmd = (SqlCommand)db.GetSqlStringCommand(strSql);
            cmd.Parameters.Add(new SqlParameter("Content", SqlDbType.Image, 0)).Value = Content;
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 获取附件数据库的连接名
        /// </summary>
        /// <returns></returns>
        public string GetAttach_ConnectionStringName()
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT Attach_ConnectionStringName FROM Frame_AttachConfig WHERE IsNowUse=1";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            DataView dv = db.ExecuteDataView(cmd);
            if (dv.Count > 0)
            {
                return dv[0]["Attach_ConnectionStringName"].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取附件数据库的连接字符串
        /// </summary>
        /// <param name="Attach_ConnectionStringName"></param>
        /// <returns></returns>
        public string GetAttach_ConnectionString(string Attach_ConnectionStringName)
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "SELECT Attach_ConnectionString FROM Frame_AttachConfig WHERE IsNowUse=1 AND Attach_ConnectionStringName='" + Attach_ConnectionStringName + "'";

            DbCommand cmd = db.GetSqlStringCommand(strSql);
            DataView dv = db.ExecuteDataView(cmd);
            if (dv.Count > 0)
            {
                return dv[0]["Attach_ConnectionString"].ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
