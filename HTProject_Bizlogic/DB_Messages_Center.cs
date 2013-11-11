using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using System.Data.OracleClient;
using System.Collections.ObjectModel;
using Epoint.Frame.Common;
using Epoint.Frame.Bizlogic;
using Epoint.Messages.Bizlogic;

namespace HTProject_Bizlogic
{
    /// <summary>
    /// ��Ϣ��������
    /// </summary>
    public enum MessageType
    {
        �Ķ�,
        ����
    }

    /// <summary>
    /// Messages_Centerʵ����
    /// ��д���ڣ�2008-8-13
    /// ��д�ˣ��ް���
    /// <summary>
    [Serializable]
    public class Detail_Messages_Center
    {
        /// <summary>
        /// ��ϢΨһGuid
        /// </summary>
        private string _MessageItemGuid;

        /// <summary>
        /// ��Ϣ�������ֶ�
        /// </summary>
        private int _Row_ID;

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        private string _Title;

        /// <summary>
        /// ��Ϣ����
        /// Ŀǰ���ְ�����Ķ������=�Ķ�������Ϊ���Ķ����ͣ�����ϵͳ����Ϊ�ǰ�������
        /// </summary>
        private string _MessageType;

        /// <summary>
        /// ��Ϣ���ݣ����� �ֻ����ţ���ŵ�ʱ���ֻ���������
        /// </summary>
        private string _Content;

        /// <summary>
        /// ��Ϣ���ࡣ
        /// ��������=4
        /// �ֻ�����=1
        /// </summary>
        private int _SendMode;

        /// <summary>
        /// ��Ϣ����ʱ��
        /// </summary>
        private DateTime _GenerateDate;

        /// <summary>
        /// �Ƿ��Ƕ�ʱ��Ϣ��
        /// ����SendMode=1����Ϣ����Щ��Ϣ��Ҫ��ʱ���͡�
        /// </summary>
        private int _IsSchedule;

        /// <summary>
        /// ��ʱ���͵���Ϣ����Ϣʱ��
        /// </summary>
        private DateTime _ScheduleSendDate;

        /// <summary>
        /// ��Ϣ��ʽ����ʱ��
        /// </summary>
        private DateTime _SendDate;

        /// <summary>
        /// �Ƿ��ѷ���
        /// </summary>
        private int _IsSend;

        /// <summary>
        /// ��ϢĿ�ꡣ������ֻ����ţ���Ϊ���ܺ��룻������ʼ�����Ϊ�ʼ���ַ
        /// </summary>
        private string _MessageTarget;

        /// <summary>
        /// ��Ϣ�Ľ����ˣ����ڴ�������Ϊ���������˵Ĵ�����
        /// </summary>
        private string _TargetUser;

        /// <summary>
        /// ��Ϣ�����˵���ʾ����
        /// </summary>
        private string _TargetDispName;

        /// <summary>
        /// ��Ϣ�ķ�����
        /// </summary>
        private string _FromUser;

        /// <summary>
        /// ��Ϣ�ķ����˵���ʾ����
        /// </summary>
        private string _FromDispName;

        /// <summary>
        /// �����˵��ֻ����룬���ڻظ���
        /// ��sendmode=1��Ч
        /// </summary>
        private string _FromMobile;

        /// <summary>
        /// ��ע
        /// </summary>
        private string _BeiZhu;

        /// <summary>
        /// ���ͽ��
        /// �����ֶ�
        /// </summary>
        private int _SendResult;

        /// <summary>
        /// �����������͵Ĵ����Url��ַ
        /// </summary>
        private string _HandleUrl;

        /// <summary>
        /// ��Ϣ�Ķ�ʱ�䡢
        /// �����ֶ�
        /// </summary>
        private DateTime _ReadDate;

        /// <summary>
        /// ��Ϣ�Ĵ���ʱ�䣬����
        /// ��sendmode=4��Ч
        /// </summary>
        private DateTime _DoneDate;

        /// <summary>
        /// �����ֶ�
        /// </summary>
        private string _SourceTable;

        /// <summary>
        /// �����ֶ�
        /// </summary>
        private string _SourceRecordID;

        /// <summary>
        /// ��Ϣ�����˵�OuGuid
        /// </summary>
        private string _OuGuid;

        /// <summary>
        /// ��Ϣ�����˵�BaseOuGuid
        /// </summary>
        private string _BaseOuGuid;

        /// <summary>
        /// �Ƿ���ɾ������Ϣ
        /// ��sendmode=4��Ч
        /// </summary>
        private int _IsDel;

        /// <summary>
        /// �Ƿ��ǲ���Ҫ�������Ϣ
        /// ��sendmode=4��Ч
        /// 
        /// </summary>
        private int _IsNoHandle;

        /// <summary>
        /// �Ƿ�����Ҫ��ʾ����Ϣ
        /// ��sendmode=4��Ч
        /// </summary>
        private int _IsShow;

        /// <summary>
        /// ��Ϣ������ְ���Guid
        /// </summary>
        private string _JobGuid;

        /// <summary>
        /// ��Ϣ��������
        /// </summary>
        private string _HandleType;

        /// <summary>
        /// ��Ϣ��Ӧҵ��ϵͳ�ı�ʶ
        /// </summary>
        private string _ClientIdentifier;

        /// <summary>
        /// �����ֶ�
        /// </summary>
        private string _ClientTag;

        /// <summary>
        /// ���뷢�ĺ����ġ�����ļ����ĺ�
        /// </summary>
        private string _ArchiveNo;

        /// <summary>
        /// ���뷢�ĺ����ġ�����ļ����ĺ�
        /// </summary>
        private string _PartitionTag;


        /// <summary>
        /// ��ʱʱ���
        /// </summary>
        private DateTime _OverTimePoint;


        /// <summary>
        /// ��ǰԤ��ʱ���
        /// </summary>
        private DateTime _EarlyWarningPoint;


        /// <summary>
        /// Ĭ�ϵ���ĳ�ʼ��
        /// </summary>
        public Detail_Messages_Center()
        {
            _MessageItemGuid = "";
            _ClientTag = "";
            _IsShow = 0;
            _ClientIdentifier = "";
            _HandleType = "";
            _JobGuid = "";
            _IsNoHandle = 0;
            _IsDel = 0;
            _ArchiveNo = "";
            _PartitionTag = "";
        }


        /// <summary>
        /// ��ϢΨһGuid
        /// </summary>
        public string MessageItemGuid
        {
            set { _MessageItemGuid = value; }
            get { return _MessageItemGuid; }
        }

        /// <summary>
        /// ��Ϣ�������ֶ�
        /// </summary>
        public int Row_ID
        {
            set { _Row_ID = value; }
            get { return _Row_ID; }
        }

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        /// <summary>
        /// ��Ϣ����
        /// Ŀǰ���ְ�����Ķ������=�Ķ�������Ϊ���Ķ����ͣ�����ϵͳ����Ϊ�ǰ�������
        /// </summary>
        public string MessageType
        {
            set { _MessageType = value; }
            get { return _MessageType; }
        }

        /// <summary>
        /// ��Ϣ���ݣ����� �ֻ����ţ���ŵ�ʱ���ֻ���������
        /// </summary>
        public string Content
        {
            set { _Content = value; }
            get { return _Content; }
        }

        /// <summary>
        ///  ��Ϣ���ࡣ
        /// ��������=4
        /// �ֻ�����=1
        /// </summary>
        public int SendMode
        {
            set { _SendMode = value; }
            get { return _SendMode; }
        }

        /// <summary>
        ///  ��Ϣ����ʱ��
        /// </summary>
        public DateTime GenerateDate
        {
            set { _GenerateDate = value; }
            get { return _GenerateDate; }
        }

        /// <summary>
        /// �Ƿ��Ƕ�ʱ��Ϣ��
        /// ����SendMode=1����Ϣ����Щ��Ϣ��Ҫ��ʱ���͡�
        /// </summary>
        public int IsSchedule
        {
            set { _IsSchedule = value; }
            get { return _IsSchedule; }
        }

        /// <summary>
        /// ��ʱ���͵���Ϣ����Ϣʱ��
        /// </summary>
        public DateTime ScheduleSendDate
        {
            set { _ScheduleSendDate = value; }
            get { return _ScheduleSendDate; }
        }

        /// <summary>
        ///  ��Ϣ��ʽ����ʱ��
        /// </summary>
        public DateTime SendDate
        {
            set { _SendDate = value; }
            get { return _SendDate; }
        }

        /// <summary>
        ///  �Ƿ��ѷ���
        /// </summary>
        public int IsSend
        {
            set { _IsSend = value; }
            get { return _IsSend; }
        }

        /// <summary>
        /// ��ϢĿ�ꡣ������ֻ����ţ���Ϊ���ܺ��룻������ʼ�����Ϊ�ʼ���ַ
        /// </summary>
        public string MessageTarget
        {
            set { _MessageTarget = value; }
            get { return _MessageTarget; }
        }

        /// <summary>
        /// ��Ϣ�Ľ����ˣ����ڴ�������Ϊ���������˵Ĵ�����
        /// </summary>
        public string TargetUser
        {
            set { _TargetUser = value; }
            get { return _TargetUser; }
        }

        /// <summary>
        ///  ��Ϣ�����˵���ʾ����
        /// </summary>
        public string TargetDispName
        {
            set { _TargetDispName = value; }
            get { return _TargetDispName; }
        }

        /// <summary>
        /// ��Ϣ�ķ�����
        /// </summary>
        public string FromUser
        {
            set { _FromUser = value; }
            get { return _FromUser; }
        }

        /// <summary>
        /// ��Ϣ�ķ����˵���ʾ����
        /// </summary>
        public string FromDispName
        {
            set { _FromDispName = value; }
            get { return _FromDispName; }
        }

        /// <summary>
        /// �����˵��ֻ����룬���ڻظ���
        /// ��sendmode=1��Ч
        /// </summary>
        public string FromMobile
        {
            set { _FromMobile = value; }
            get { return _FromMobile; }
        }

        /// <summary>
        /// ��ע
        /// </summary>
        public string BeiZhu
        {
            set { _BeiZhu = value; }
            get { return _BeiZhu; }
        }

        /// <summary>
        /// ���ͽ��
        /// �����ֶ�
        /// </summary>
        public int SendResult
        {
            set { _SendResult = value; }
            get { return _SendResult; }
        }

        /// <summary>
        /// �����������͵Ĵ����Url��ַ
        /// </summary>
        public string HandleUrl
        {
            set { _HandleUrl = value; }
            get { return _HandleUrl; }
        }

        /// <summary>
        /// ��Ϣ�Ķ�ʱ�䡢
        /// �����ֶ�
        /// </summary>
        public DateTime ReadDate
        {
            set { _ReadDate = value; }
            get { return _ReadDate; }
        }

        /// <summary>
        /// ��Ϣ�Ĵ���ʱ�䣬����
        /// ��sendmode=4��Ч
        /// </summary>
        public DateTime DoneDate
        {
            set { _DoneDate = value; }
            get { return _DoneDate; }
        }

        /// <summary>
        /// �����ֶ�
        /// </summary>
        public string SourceTable
        {
            set { _SourceTable = value; }
            get { return _SourceTable; }
        }

        /// <summary>
        /// �����ֶ�
        /// </summary>
        public string SourceRecordID
        {
            set { _SourceRecordID = value; }
            get { return _SourceRecordID; }
        }

        /// <summary>
        /// ��Ϣ�����˵�OuGuid
        /// </summary>
        public string OuGuid
        {
            set { _OuGuid = value; }
            get { return _OuGuid; }
        }

        /// <summary>
        /// ��Ϣ�����˵�BaseOuGuid
        /// </summary>
        public string BaseOuGuid
        {
            set { _BaseOuGuid = value; }
            get { return _BaseOuGuid; }
        }

        /// <summary>
        /// �Ƿ���ɾ������Ϣ
        /// ��sendmode=4��Ч
        /// </summary>
        public int IsDel
        {
            set { _IsDel = value; }
            get { return _IsDel; }
        }

        /// <summary>
        /// �Ƿ��ǲ���Ҫ�������Ϣ
        /// ��sendmode=4��Ч
        /// </summary>
        public int IsNoHandle
        {
            set { _IsNoHandle = value; }
            get { return _IsNoHandle; }
        }

        /// <summary>
        /// �Ƿ�����Ҫ��ʾ����Ϣ
        /// ��sendmode=4��Ч
        /// </summary>
        public int IsShow
        {
            set { _IsShow = value; }
            get { return _IsShow; }
        }

        /// <summary>
        /// ��Ϣ������ְ���Guid
        /// </summary>
        public string JobGuid
        {
            set { _JobGuid = value; }
            get { return _JobGuid; }
        }

        /// <summary>
        /// ��Ϣ��������
        /// </summary>
        public string HandleType
        {
            set { _HandleType = value; }
            get { return _HandleType; }
        }

        /// <summary>
        /// ��Ϣ��Ӧҵ��ϵͳ�ı�ʶ
        /// </summary>
        public string ClientIdentifier
        {
            set { _ClientIdentifier = value; }
            get { return _ClientIdentifier; }
        }

        /// <summary>
        /// �����ֶ�
        /// </summary>
        public string ClientTag
        {
            set { _ClientTag = value; }
            get { return _ClientTag; }
        }

        /// <summary>
        ///  ���뷢�ĺ����ġ�����ļ����ĺ�
        /// </summary>
        public string ArchiveNo
        {
            set { _ArchiveNo = value; }
            get { return _ArchiveNo; }
        }

        /// <summary>
        ///  ���뷢�ĺ����ġ�����ļ����ĺ�
        /// </summary>
        public string PartitionTag
        {
            set { _PartitionTag = value; }
            get { return _PartitionTag; }
        }

        /// <summary>
        ///  ��ʱʱ���
        /// </summary>
        public DateTime OverTimePoint
        {
            set { _OverTimePoint = value; }
            get { return _OverTimePoint; }
        }

        /// <summary>
        ///  ��ǰԤ��ʱ���
        /// </summary>
        public DateTime EarlyWarningPoint
        {
            set { _EarlyWarningPoint = value; }
            get { return _EarlyWarningPoint; }
        }

    }//class

    /// <summary>
    /// ����Ϣ����DB_Messages_Center��һЩ����
    /// </summary>
    public class DB_Messages_Center
    {

        /// <summary>
        /// ����DB_Messages_Center_Histroy
        /// </summary>
        DB_Messages_Center_Histroy MsgHistroy = new DB_Messages_Center_Histroy();




        /// <summary>
        /// ������ϢΨһGuid��ȡ��Ϣ
        /// ��д���ڣ�2008-8-13
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid</param>
        public Detail_Messages_Center GetDetail(string MessageItemGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT * FROM Messages_Center WHERE  MessageItemGuid=@MessageItemGuid " :
                "SELECT * FROM Messages_Center WHERE  MessageItemGuid=:MessageItemGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            Detail_Messages_Center myDetail = new Detail_Messages_Center();
            using (IDataReader myReader = db.ExecuteReader(cmd))
            {
                if (myReader.Read())
                {
                    if (!Convert.IsDBNull(myReader["MessageItemGuid"]))
                    {
                        myDetail.MessageItemGuid = Convert.ToString(myReader["MessageItemGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["Row_ID"]))
                    {
                        myDetail.Row_ID = Convert.ToInt32(myReader["Row_ID"]);
                    }
                    if (!Convert.IsDBNull(myReader["Title"]))
                    {
                        myDetail.Title = Convert.ToString(myReader["Title"]);
                    }
                    if (!Convert.IsDBNull(myReader["MessageType"]))
                    {
                        myDetail.MessageType = Convert.ToString(myReader["MessageType"]);
                    }
                    if (!Convert.IsDBNull(myReader["Content"]))
                    {
                        myDetail.Content = Convert.ToString(myReader["Content"]);
                    }
                    if (!Convert.IsDBNull(myReader["SendMode"]))
                    {
                        myDetail.SendMode = Convert.ToInt32(myReader["SendMode"]);
                    }
                    if (!Convert.IsDBNull(myReader["GenerateDate"]))
                    {
                        myDetail.GenerateDate = Convert.ToDateTime(myReader["GenerateDate"]);
                    }
                    if (!Convert.IsDBNull(myReader["IsSchedule"]))
                    {
                        myDetail.IsSchedule = Convert.ToInt32(myReader["IsSchedule"]);
                    }
                    if (!Convert.IsDBNull(myReader["ScheduleSendDate"]))
                    {
                        myDetail.ScheduleSendDate = Convert.ToDateTime(myReader["ScheduleSendDate"]);
                    }
                    if (!Convert.IsDBNull(myReader["SendDate"]))
                    {
                        myDetail.SendDate = Convert.ToDateTime(myReader["SendDate"]);
                    }
                    if (!Convert.IsDBNull(myReader["IsSend"]))
                    {
                        myDetail.IsSend = Convert.ToInt32(myReader["IsSend"]);
                    }
                    if (!Convert.IsDBNull(myReader["MessageTarget"]))
                    {
                        myDetail.MessageTarget = Convert.ToString(myReader["MessageTarget"]);
                    }
                    if (!Convert.IsDBNull(myReader["TargetUser"]))
                    {
                        myDetail.TargetUser = Convert.ToString(myReader["TargetUser"]);
                    }
                    if (!Convert.IsDBNull(myReader["TargetDispName"]))
                    {
                        myDetail.TargetDispName = Convert.ToString(myReader["TargetDispName"]);
                    }
                    if (!Convert.IsDBNull(myReader["FromUser"]))
                    {
                        myDetail.FromUser = Convert.ToString(myReader["FromUser"]);
                    }
                    if (!Convert.IsDBNull(myReader["FromDispName"]))
                    {
                        myDetail.FromDispName = Convert.ToString(myReader["FromDispName"]);
                    }
                    if (!Convert.IsDBNull(myReader["FromMobile"]))
                    {
                        myDetail.FromMobile = Convert.ToString(myReader["FromMobile"]);
                    }
                    if (!Convert.IsDBNull(myReader["BeiZhu"]))
                    {
                        myDetail.BeiZhu = Convert.ToString(myReader["BeiZhu"]);
                    }
                    if (!Convert.IsDBNull(myReader["SendResult"]))
                    {
                        myDetail.SendResult = Convert.ToInt32(myReader["SendResult"]);
                    }
                    if (!Convert.IsDBNull(myReader["HandleUrl"]))
                    {
                        myDetail.HandleUrl = Convert.ToString(myReader["HandleUrl"]);
                    }
                    if (!Convert.IsDBNull(myReader["ReadDate"]))
                    {
                        myDetail.ReadDate = Convert.ToDateTime(myReader["ReadDate"]);
                    }
                    if (!Convert.IsDBNull(myReader["DoneDate"]))
                    {
                        myDetail.DoneDate = Convert.ToDateTime(myReader["DoneDate"]);
                    }
                    if (!Convert.IsDBNull(myReader["SourceTable"]))
                    {
                        myDetail.SourceTable = Convert.ToString(myReader["SourceTable"]);
                    }
                    if (!Convert.IsDBNull(myReader["SourceRecordID"]))
                    {
                        myDetail.SourceRecordID = Convert.ToString(myReader["SourceRecordID"]);
                    }
                    if (!Convert.IsDBNull(myReader["OuGuid"]))
                    {
                        myDetail.OuGuid = Convert.ToString(myReader["OuGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["BaseOuGuid"]))
                    {
                        myDetail.BaseOuGuid = Convert.ToString(myReader["BaseOuGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["IsDel"]))
                    {
                        myDetail.IsDel = Convert.ToInt32(myReader["IsDel"]);
                    }
                    if (!Convert.IsDBNull(myReader["IsNoHandle"]))
                    {
                        myDetail.IsNoHandle = Convert.ToInt32(myReader["IsNoHandle"]);
                    }
                    if (!Convert.IsDBNull(myReader["IsShow"]))
                    {
                        myDetail.IsShow = Convert.ToInt32(myReader["IsShow"]);
                    }
                    if (!Convert.IsDBNull(myReader["JobGuid"]))
                    {
                        myDetail.JobGuid = Convert.ToString(myReader["JobGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["HandleType"]))
                    {
                        myDetail.HandleType = Convert.ToString(myReader["HandleType"]);
                    }
                    if (!Convert.IsDBNull(myReader["ClientIdentifier"]))
                    {
                        myDetail.ClientIdentifier = Convert.ToString(myReader["ClientIdentifier"]);
                    }
                    if (!Convert.IsDBNull(myReader["ClientTag"]))
                    {
                        myDetail.ClientTag = Convert.ToString(myReader["ClientTag"]);
                    }
                    if (!Convert.IsDBNull(myReader["ArchiveNo"]))
                    {
                        myDetail.ArchiveNo = Convert.ToString(myReader["ArchiveNo"]);
                    }
                    if (!Convert.IsDBNull(myReader["PartitionTag"]))
                    {
                        myDetail.PartitionTag = Convert.ToString(myReader["PartitionTag"]);
                    }
                    if (!Convert.IsDBNull(myReader["OverTimePoint"]))
                    {
                        myDetail.OverTimePoint = Convert.ToDateTime(myReader["OverTimePoint"]);
                    }
                    if (!Convert.IsDBNull(myReader["EarlyWarningPoint"]))
                    {
                        myDetail.EarlyWarningPoint = Convert.ToDateTime(myReader["EarlyWarningPoint"]);
                    }
                }
            }

            return myDetail;
        }

        /// <summary>
        /// ����ҵ���ʶClientIdentifier��ȡ�ô���������ϸ
        /// ��д���ڣ�2008-7-29
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="ClientIdentifier">ҵ���ʶClientIdentifier</param>
        public Detail_Messages_Center GetDetail_ClientIdentifier(string ClientIdentifier)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT * FROM Messages_Center WHERE  ClientIdentifier=@ClientIdentifier " :
                "SELECT * FROM Messages_Center WHERE  ClientIdentifier=:ClientIdentifier ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "ClientIdentifier", DbType.String, ClientIdentifier);
            Detail_Messages_Center myDetail = new Detail_Messages_Center();
            using (IDataReader myReader = db.ExecuteReader(cmd))
            {
                if (myReader.Read())
                {
                    if (!Convert.IsDBNull(myReader["MessageItemGuid"]))
                    {
                        myDetail.MessageItemGuid = Convert.ToString(myReader["MessageItemGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["Row_ID"]))
                    {
                        myDetail.Row_ID = Convert.ToInt32(myReader["Row_ID"]);
                    }
                    if (!Convert.IsDBNull(myReader["Title"]))
                    {
                        myDetail.Title = Convert.ToString(myReader["Title"]);
                    }
                    if (!Convert.IsDBNull(myReader["MessageType"]))
                    {
                        myDetail.MessageType = Convert.ToString(myReader["MessageType"]);
                    }
                    if (!Convert.IsDBNull(myReader["Content"]))
                    {
                        myDetail.Content = Convert.ToString(myReader["Content"]);
                    }
                    if (!Convert.IsDBNull(myReader["SendMode"]))
                    {
                        myDetail.SendMode = Convert.ToInt32(myReader["SendMode"]);
                    }
                    if (!Convert.IsDBNull(myReader["GenerateDate"]))
                    {
                        myDetail.GenerateDate = Convert.ToDateTime(myReader["GenerateDate"]);
                    }
                    if (!Convert.IsDBNull(myReader["IsSchedule"]))
                    {
                        myDetail.IsSchedule = Convert.ToInt32(myReader["IsSchedule"]);
                    }
                    if (!Convert.IsDBNull(myReader["ScheduleSendDate"]))
                    {
                        myDetail.ScheduleSendDate = Convert.ToDateTime(myReader["ScheduleSendDate"]);
                    }
                    if (!Convert.IsDBNull(myReader["SendDate"]))
                    {
                        myDetail.SendDate = Convert.ToDateTime(myReader["SendDate"]);
                    }
                    if (!Convert.IsDBNull(myReader["IsSend"]))
                    {
                        myDetail.IsSend = Convert.ToInt32(myReader["IsSend"]);
                    }
                    if (!Convert.IsDBNull(myReader["MessageTarget"]))
                    {
                        myDetail.MessageTarget = Convert.ToString(myReader["MessageTarget"]);
                    }
                    if (!Convert.IsDBNull(myReader["TargetUser"]))
                    {
                        myDetail.TargetUser = Convert.ToString(myReader["TargetUser"]);
                    }
                    if (!Convert.IsDBNull(myReader["TargetDispName"]))
                    {
                        myDetail.TargetDispName = Convert.ToString(myReader["TargetDispName"]);
                    }
                    if (!Convert.IsDBNull(myReader["FromUser"]))
                    {
                        myDetail.FromUser = Convert.ToString(myReader["FromUser"]);
                    }
                    if (!Convert.IsDBNull(myReader["FromDispName"]))
                    {
                        myDetail.FromDispName = Convert.ToString(myReader["FromDispName"]);
                    }
                    if (!Convert.IsDBNull(myReader["FromMobile"]))
                    {
                        myDetail.FromMobile = Convert.ToString(myReader["FromMobile"]);
                    }
                    if (!Convert.IsDBNull(myReader["BeiZhu"]))
                    {
                        myDetail.BeiZhu = Convert.ToString(myReader["BeiZhu"]);
                    }
                    if (!Convert.IsDBNull(myReader["SendResult"]))
                    {
                        myDetail.SendResult = Convert.ToInt32(myReader["SendResult"]);
                    }
                    if (!Convert.IsDBNull(myReader["HandleUrl"]))
                    {
                        myDetail.HandleUrl = Convert.ToString(myReader["HandleUrl"]);
                    }
                    if (!Convert.IsDBNull(myReader["ReadDate"]))
                    {
                        myDetail.ReadDate = Convert.ToDateTime(myReader["ReadDate"]);
                    }
                    if (!Convert.IsDBNull(myReader["DoneDate"]))
                    {
                        myDetail.DoneDate = Convert.ToDateTime(myReader["DoneDate"]);
                    }
                    if (!Convert.IsDBNull(myReader["SourceTable"]))
                    {
                        myDetail.SourceTable = Convert.ToString(myReader["SourceTable"]);
                    }
                    if (!Convert.IsDBNull(myReader["SourceRecordID"]))
                    {
                        myDetail.SourceRecordID = Convert.ToString(myReader["SourceRecordID"]);
                    }
                    if (!Convert.IsDBNull(myReader["OuGuid"]))
                    {
                        myDetail.OuGuid = Convert.ToString(myReader["OuGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["BaseOuGuid"]))
                    {
                        myDetail.BaseOuGuid = Convert.ToString(myReader["BaseOuGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["IsDel"]))
                    {
                        myDetail.IsDel = Convert.ToInt32(myReader["IsDel"]);
                    }
                    if (!Convert.IsDBNull(myReader["IsNoHandle"]))
                    {
                        myDetail.IsNoHandle = Convert.ToInt32(myReader["IsNoHandle"]);
                    }
                    if (!Convert.IsDBNull(myReader["IsShow"]))
                    {
                        myDetail.IsShow = Convert.ToInt32(myReader["IsShow"]);
                    }
                    if (!Convert.IsDBNull(myReader["JobGuid"]))
                    {
                        myDetail.JobGuid = Convert.ToString(myReader["JobGuid"]);
                    }
                    if (!Convert.IsDBNull(myReader["HandleType"]))
                    {
                        myDetail.HandleType = Convert.ToString(myReader["HandleType"]);
                    }
                    if (!Convert.IsDBNull(myReader["ClientIdentifier"]))
                    {
                        myDetail.ClientIdentifier = Convert.ToString(myReader["ClientIdentifier"]);
                    }
                    if (!Convert.IsDBNull(myReader["ClientTag"]))
                    {
                        myDetail.ClientTag = Convert.ToString(myReader["ClientTag"]);
                    }
                    if (!Convert.IsDBNull(myReader["ArchiveNo"]))
                    {
                        myDetail.ArchiveNo = Convert.ToString(myReader["ArchiveNo"]);
                    }
                    if (!Convert.IsDBNull(myReader["PartitionTag"]))
                    {
                        myDetail.PartitionTag = Convert.ToString(myReader["PartitionTag"]);
                    }
                    if (!Convert.IsDBNull(myReader["OverTimePoint"]))
                    {
                        myDetail.OverTimePoint = Convert.ToDateTime(myReader["OverTimePoint"]);
                    }
                    if (!Convert.IsDBNull(myReader["EarlyWarningPoint"]))
                    {
                        myDetail.EarlyWarningPoint = Convert.ToDateTime(myReader["EarlyWarningPoint"]);
                    }
                }
            }

            return myDetail;
        }


        /// <summary>
        /// ����MessageItemGuid��ת����ʷ��Ϣ��Messages_Center_Histroy�е���Ϣ��������Ϣ��Messages_Center�� ��ת�Ƴɹ���ɾ����Messages_Center�еĴ���Ϣ
        /// ��д���ڣ�2008-8-13
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid</param>
        public void Move_WaitHandleFromhistoryToHandle(string MessageItemGuid)
        {
            string sql = " INSERT INTO Messages_Center ";
            sql += " ( MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,SendDate,IsSend, ";
            sql += " MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,BeiZhu,SendResult,HandleUrl,ReadDate,DoneDate, ";
            sql += " SourceTable,SourceRecordID, OuGuid,BaseOuGuid,IsDel,IsNoHandle,IsShow,JobGuid,ClientTag,ArchiveNo,OperatorGuid,OperatorForDisplayGuid,PVIGuid,ClientIdentifier,rdoType,PartitionTag,OverTimePoint,EarlyWarningPoint)  ";
            sql += " select MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,SendDate,IsSend, ";
            sql += " MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,BeiZhu,SendResult,HandleUrl,ReadDate,DoneDate, ";
            sql += " SourceTable,SourceRecordID, OuGuid,BaseOuGuid,IsDel,IsNoHandle,IsShow,JobGuid,ClientTag,ArchiveNo,OperatorGuid,OperatorForDisplayGuid,PVIGuid,ClientIdentifier,rdoType,PartitionTag,OverTimePoint,EarlyWarningPoint ";
            sql += " from Messages_Center_Histroy where MessageItemGuid= @MessageItemGuid ";
            sql += "  ";


            string oracle = " begin  INSERT INTO Messages_Center ";
            oracle += " ( MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,SendDate,IsSend, ";
            oracle += " MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,BeiZhu,SendResult,HandleUrl,ReadDate,DoneDate, ";
            oracle += " SourceTable,SourceRecordID, OuGuid,BaseOuGuid,IsDel,IsNoHandle,IsShow,JobGuid,Row_ID,                            ClientTag,ArchiveNo,OperatorGuid,OperatorForDisplayGuid,PVIGuid,ClientIdentifier,rdoType,PartitionTag,OverTimePoint,EarlyWarningPoint )  ";
            oracle += " select MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,SendDate,IsSend, ";
            oracle += " MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,BeiZhu,SendResult,HandleUrl,ReadDate,DoneDate, ";
            oracle += " SourceTable,SourceRecordID, OuGuid,BaseOuGuid,IsDel,IsNoHandle,IsShow,JobGuid,SQ_MESSAGES_CENTER_HISTROY.nextval,ClientTag,ArchiveNo,OperatorGuid,OperatorForDisplayGuid,PVIGuid,ClientIdentifier,rdoType,PartitionTag,OverTimePoint,EarlyWarningPoint ";
            oracle += " from Messages_Center_Histroy where MessageItemGuid= :MessageItemGuid ;";
            oracle += " ";
            oracle += " end; ";

            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                sql :
                oracle
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);

            new DB_Messages_Center_Histroy().DeleteByMessageItemGuid(MessageItemGuid);
        }


        /// <summary>
        /// ����BeiZhu �� ClientIdentifier ��ȡ��Ϣ�б�
        /// ��Ӧsql:SELECT  * FROM Messages_Center WHERE  BeiZhu=@BeiZhu AND ClientIdentifier=@ClientIdentifier
        /// ��д���ڣ�2007-10-17
        /// ��д�ˣ�����ϲ
        /// </summary>
        /// <param name="BeiZhu">BeiZhu</param>
        /// <param name="ClientIdentifier">ClientIdentifier</param>
        /// <returns>DataView</returns>
        public DataView Select(string BeiZhu, string ClientIdentifier)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT  * FROM Messages_Center WHERE  BeiZhu=@BeiZhu AND ClientIdentifier=@ClientIdentifier " :
                "SELECT  * FROM Messages_Center WHERE  BeiZhu=:BeiZhu AND ClientIdentifier=:ClientIdentifier ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "BeiZhu", DbType.String, BeiZhu);
            db.AddInParameter(cmd, "ClientIdentifier", DbType.String, ClientIdentifier);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// ȡ�ô������˵���Ϣ���
        /// sql��䣺SELECT distinct HandleType FROM Messages_Center where HandleType<> null 
        /// �ް���
        /// 2007��10��15
        /// </summary>
        /// <returns>DataView</returns>
        public DataView GetWaitHandleType()
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Frame_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT distinct HandleType FROM Messages_Center where HandleType<> null  " :
                "SELECT distinct HandleType FROM Messages_Center where HandleType<> null  ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// �����Ϣ����(������������)
        /// �ް�����ӣ��������ݵ�ʹ�ã������ط���ʹ��
        /// ����Ƿ��͸��û��ģ���TargetUser!="",JobGuid="";����Ƿ��͸�ְλ�ģ���TargetUser="",JobGuid!="";��
        /// ϵͳ�жϣ����JobGuid!="",��ϵͳ���Զ���TargetUser="";
        /// ��д���ڣ�2007-4-23
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid,��ҵ��ϵͳ����Guid</param>
        /// <param name="Title">��Ϣ����</param>
        /// <param name="TargetUser">��ϢĿ���û���UserGuid���������û���ϵͳ�е�Ψһ��ʶ����</param>
        /// <param name="TargetDispName">��ϢĿ���û�������ʾ����DispName���������û���ϵͳ�е�Ψһ��ʶ����</param>
        /// <param name="FromUser">��Ϣ������,�����û���UserGuid�����Ϊ�գ���Ϊ��ǰ�û���UserGuid</param>
        /// <param name="FromDispName">��Ϣ�����˵���ʾ���ơ����Ϊ�գ���Ϊ��ǰ�û�����ʾ����</param>
        /// <param name="CurrentActivityStepName">��ǰ����������</param>
        /// <param name="HandleUrl">����Ǵ������ˣ���ʾ��Ӧ�Ĵ���URL��ָ������Ŀ¼�����Url������������Ŀ¼���ƣ��ڲ���url��ʱ����Ҫ�Ѵ�����¼��MessageItemGuid��Ϊ����������url�ĺ���</param>
        /// <param name="OuGuid">�û����ڲ��ŵ�OuGuid,��Session["OUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���OUGuid</param>
        /// <param name="BaseOuGuid">�û����ڶ��������ŵ�OuGuid,��Session["BaseOUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���BaseOUGuid </param>
        /// <param name="IsShow">�Ƿ��ڴ�����������ʾ�������0������ʾ��������ʾ��Ĭ��Ϊ1</param>
        /// <param name="JobGuid">��Ӧ��ְλGuid</param>
        /// <param name="HandleType">�˴������˶�Ӧ�ķ���</param>
        /// <param name="ClientIdentifier">ҵ��ϵͳ��ϵͳ�Ĵ���������Ϣ</param>
        /// <returns>Boolean</returns>
        public Boolean WaitHandle_Insert(string MessageItemGuid, string Title, string MessageType, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string CurrentActivityStepName, string HandleUrl, string OuGuid, string BaseOuGuid, int IsShow, string JobGuid, string HandleType, string ClientIdentifier)
        {
            return this.WaitHandle_Insert(MessageItemGuid, Title, MessageType, TargetUser, TargetDispName, FromUser, FromDispName, CurrentActivityStepName, HandleUrl, OuGuid, BaseOuGuid, IsShow, JobGuid, HandleType, ClientIdentifier, "");
        }

        /// <summary>
        /// �����Ϣ����(������������)
        /// ����Ƿ��͸��û��ģ���TargetUser!="",JobGuid="";����Ƿ��͸�ְλ�ģ���TargetUser="",JobGuid!="";��
        /// ϵͳ�жϣ����JobGuid!="",��ϵͳ���Զ���TargetUser="";
        /// ��д���ڣ�2007-4-23
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid,��ҵ��ϵͳ����Guid</param>
        /// <param name="Title">��Ϣ����</param>
        /// <param name="TargetUser">��ϢĿ���û���UserGuid���������û���ϵͳ�е�Ψһ��ʶ����</param>
        /// <param name="TargetDispName">��ϢĿ���û�������ʾ����DispName���������û���ϵͳ�е�Ψһ��ʶ����</param>
        /// <param name="FromUser">��Ϣ������,�����û���UserGuid�����Ϊ�գ���Ϊ��ǰ�û���UserGuid</param>
        /// <param name="FromDispName">��Ϣ�����˵���ʾ���ơ����Ϊ�գ���Ϊ��ǰ�û�����ʾ����</param>
        /// <param name="CurrentActivityStepName">��ǰ����������</param>
        /// <param name="HandleUrl">����Ǵ������ˣ���ʾ��Ӧ�Ĵ���URL��ָ������Ŀ¼�����Url������������Ŀ¼���ƣ��ڲ���url��ʱ����Ҫ�Ѵ�����¼��MessageItemGuid��Ϊ����������url�ĺ���</param>
        /// <param name="OuGuid">�û����ڲ��ŵ�OuGuid,��Session["OUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���OUGuid</param>
        /// <param name="BaseOuGuid">�û����ڶ��������ŵ�OuGuid,��Session["BaseOUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���BaseOUGuid </param>
        /// <param name="IsShow">�Ƿ��ڴ�����������ʾ�������0������ʾ��������ʾ��Ĭ��Ϊ1</param>
        /// <param name="JobGuid">��Ӧ��ְλGuid</param>
        /// <param name="HandleType">�˴������˶�Ӧ�ķ���</param>
        /// <param name="ClientIdentifier">ҵ��ϵͳ��ϵͳ�Ĵ���������Ϣ</param>
        /// <returns>Boolean</returns>
        public Boolean WaitHandle_Insert(string MessageItemGuid, string Title, string MessageType, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string CurrentActivityStepName, string HandleUrl, string OuGuid, string BaseOuGuid, int IsShow, string JobGuid, string HandleType, string ClientIdentifier, DateTime GenerateDate)
        {
            return this.WaitHandle_Insert(MessageItemGuid, Title, MessageType, TargetUser, TargetDispName, FromUser, FromDispName, CurrentActivityStepName, HandleUrl, OuGuid, BaseOuGuid, IsShow, JobGuid, HandleType, ClientIdentifier, "", GenerateDate, "");

            #region ����
            //if (FromUser == null || FromUser == "")
            //{
            //    try
            //    {
            //        FromUser = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["UserGuid"]);
            //    }
            //    catch
            //    {
            //        FromUser = "";
            //    }
            //}
            //if(FromDispName == null || FromDispName == "")
            //{
            //    try
            //    {
            //        FromDispName = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["DisplayName"]);
            //    }
            //    catch
            //    {
            //        FromDispName = "";
            //    }
            //}

            //if(OuGuid == null || OuGuid == "")
            //{
            //    try
            //    {
            //        OuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["OUGuid"]);
            //    }
            //    catch
            //    {
            //        OuGuid = "";
            //    }
            //}

            //if(BaseOuGuid == null || BaseOuGuid == "")
            //{
            //    try
            //    {
            //        BaseOuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["BaseOUGuid"]);
            //    }
            //    catch
            //    {
            //        BaseOuGuid = "";
            //    }
            //}

            //if(Title == null || Title == "")
            //    Title = "�ޱ���";

            //if(MessageType == null || MessageType == "")
            //    MessageType = "����";

            //if(MessageType != "����")
            //    MessageType = "�Ķ�";

            //if(JobGuid != "")
            //    TargetUser = "";

            //Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            //string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
            //    "INSERT INTO Messages_Center(MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,HandleUrl,BeiZhu,OuGuid,BaseOuGuid,IsShow,JobGuid,HandleType,ClientIdentifier,IsDel,IsNoHandle) VALUES(@MessageItemGuid,@Title,@MessageType,@Content,@SendMode,@GenerateDate,@IsSchedule,@ScheduleSendDate,@MessageTarget,@TargetUser,@TargetDispName,@FromUser,@FromDispName,@FromMobile,@HandleUrl,@BeiZhu,@OuGuid,@BaseOuGuid,@IsShow,@JobGuid,@HandleType,@ClientIdentifier,0,0) " :
            //    "INSERT INTO Messages_Center(Row_ID,MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,HandleUrl,BeiZhu,OuGuid,BaseOuGuid,IsShow,JobGuid,HandleType,ClientIdentifier,IsDel,IsNoHandle) VALUES(sq_Messages_Center.nextval,:MessageItemGuid,:Title,:MessageType,:Content,:SendMode,:GenerateDate,:IsSchedule,:ScheduleSendDate,:MessageTarget,:TargetUser,:TargetDispName,:FromUser,:FromDispName,:FromMobile,:HandleUrl,:BeiZhu,:OuGuid,:BaseOuGuid,:IsShow,:JobGuid,:HandleType,:ClientIdentifier,0,0)"
            //);
            //DbCommand cmd = db.GetSqlStringCommand(strSql);

            //db.AddInParameter(cmd,"MessageItemGuid",DbType.String,MessageItemGuid);
            //db.AddInParameter(cmd,"Title",DbType.String,Title);
            //db.AddInParameter(cmd,"MessageType",DbType.String,MessageType);
            //db.AddInParameter(cmd,"Content",DbType.String,"");
            //db.AddInParameter(cmd,"SendMode",DbType.Int32,4);
            //db.AddInParameter(cmd,"GenerateDate",DbType.DateTime,GenerateDate);
            //db.AddInParameter(cmd,"IsSchedule",DbType.Int32,0);
            //db.AddInParameter(cmd,"ScheduleSendDate",DbType.DateTime,DBNull.Value);
            //db.AddInParameter(cmd,"MessageTarget",DbType.String,"");
            //db.AddInParameter(cmd,"TargetUser",DbType.String,TargetUser);
            //db.AddInParameter(cmd,"TargetDispName",DbType.String,TargetDispName);
            //db.AddInParameter(cmd,"FromUser",DbType.String,FromUser);
            //db.AddInParameter(cmd,"FromDispName",DbType.String,FromDispName);
            //db.AddInParameter(cmd,"FromMobile",DbType.String,"");
            //db.AddInParameter(cmd,"HandleUrl",DbType.String,HandleUrl);
            //db.AddInParameter(cmd,"BeiZhu",DbType.String,CurrentActivityStepName);
            //db.AddInParameter(cmd,"OuGuid",DbType.String,OuGuid);
            //db.AddInParameter(cmd,"BaseOuGuid",DbType.String,BaseOuGuid);
            //db.AddInParameter(cmd,"IsShow",DbType.Int32,IsShow);
            //db.AddInParameter(cmd,"JobGuid",DbType.String,JobGuid);
            //db.AddInParameter(cmd,"HandleType",DbType.String,HandleType);
            //db.AddInParameter(cmd,"ClientIdentifier",DbType.String,ClientIdentifier);
            //db.ExecuteNonQuery(cmd);
            //return true;
            #endregion
        }

        /// <summary>
        /// �����Ϣ����(������������)
        /// �ް�����ӣ��������ݵ�ʹ�ã������ط���ʹ��
        /// ����Ƿ��͸��û��ģ���TargetUser!="",JobGuid="";����Ƿ��͸�ְλ�ģ���TargetUser="",JobGuid!="";��
        /// ϵͳ�жϣ����JobGuid!="",��ϵͳ���Զ���TargetUser="";
        /// ��д���ڣ�2007-4-23
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid,��ҵ��ϵͳ����Guid</param>
        /// <param name="Title">��Ϣ����</param>
        /// <param name="TargetUser">��ϢĿ���û���UserGuid���������û���ϵͳ�е�Ψһ��ʶ����</param>
        /// <param name="TargetDispName">��ϢĿ���û�������ʾ����DispName���������û���ϵͳ�е�Ψһ��ʶ����</param>
        /// <param name="FromUser">��Ϣ������,�����û���UserGuid�����Ϊ�գ���Ϊ��ǰ�û���UserGuid</param>
        /// <param name="FromDispName">��Ϣ�����˵���ʾ���ơ����Ϊ�գ���Ϊ��ǰ�û�����ʾ����</param>
        /// <param name="CurrentActivityStepName">��ǰ����������</param>
        /// <param name="HandleUrl">����Ǵ������ˣ���ʾ��Ӧ�Ĵ���URL��ָ������Ŀ¼�����Url������������Ŀ¼���ƣ��ڲ���url��ʱ����Ҫ�Ѵ�����¼��MessageItemGuid��Ϊ����������url�ĺ���</param>
        /// <param name="OuGuid">�û����ڲ��ŵ�OuGuid,��Session["OUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���OUGuid</param>
        /// <param name="BaseOuGuid">�û����ڶ��������ŵ�OuGuid,��Session["BaseOUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���BaseOUGuid </param>
        /// <param name="IsShow">�Ƿ��ڴ�����������ʾ�������0������ʾ��������ʾ��Ĭ��Ϊ1</param>
        /// <param name="JobGuid">��Ӧ��ְλGuid</param>
        /// <param name="HandleType">�˴������˶�Ӧ�ķ���</param>
        /// <param name="ClientIdentifier">ҵ��ϵͳ��ϵͳ�Ĵ���������Ϣ</param>
        /// <returns>Boolean</returns>
        public Boolean WaitHandle_Insert(string MessageItemGuid, string Title, string MessageType, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string CurrentActivityStepName, string HandleUrl, string OuGuid, string BaseOuGuid, int IsShow, string JobGuid, string HandleType, string ClientIdentifier, string ClientTag)
        {
            DateTime GenerateDate = new DateTime(1, 1, 1);
            return this.WaitHandle_Insert(MessageItemGuid, Title, MessageType, TargetUser, TargetDispName, FromUser, FromDispName, CurrentActivityStepName, HandleUrl, OuGuid, BaseOuGuid, IsShow, JobGuid, HandleType, ClientIdentifier, ClientTag, GenerateDate, "");

            #region ����
            //if (FromUser == null || FromUser == "")
            //{
            //    try
            //    {
            //        FromUser = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["UserGuid"]);
            //    }
            //    catch
            //    {
            //        FromUser = "";
            //    }
            //}
            //if(FromDispName == null || FromDispName == "")
            //{
            //    try
            //    {
            //        FromDispName = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["DisplayName"]);
            //    }
            //    catch
            //    {
            //        FromDispName = "";
            //    }
            //}

            //if(OuGuid == null || OuGuid == "")
            //{
            //    try
            //    {
            //        OuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["OUGuid"]);
            //    }
            //    catch
            //    {
            //        OuGuid = "";
            //    }
            //}

            //if(BaseOuGuid == null || BaseOuGuid == "")
            //{
            //    try
            //    {
            //        BaseOuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["BaseOUGuid"]);
            //    }
            //    catch
            //    {
            //        BaseOuGuid = "";
            //    }
            //}

            //if(Title == null || Title == "")
            //    Title = "�ޱ���";

            //if(MessageType == null || MessageType == "")
            //    MessageType = "����";

            //if(MessageType == "�Ķ�")
            //    MessageType = "�Ķ�";
            //else
            //    MessageType = "����";

            //if(JobGuid != "")
            //    TargetUser = "";

            //Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            //string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
            //    "INSERT INTO Messages_Center(MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,HandleUrl,BeiZhu,OuGuid,BaseOuGuid,IsShow,JobGuid,HandleType,ClientIdentifier,ClientTag,IsDel,IsNoHandle) VALUES(@MessageItemGuid,@Title,@MessageType,@Content,@SendMode,@GenerateDate,@IsSchedule,@ScheduleSendDate,@MessageTarget,@TargetUser,@TargetDispName,@FromUser,@FromDispName,@FromMobile,@HandleUrl,@BeiZhu,@OuGuid,@BaseOuGuid,@IsShow,@JobGuid,@HandleType,@ClientIdentifier,@ClientTag,0,0) " :
            //    "INSERT INTO Messages_Center(Row_ID,MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,HandleUrl,BeiZhu,OuGuid,BaseOuGuid,IsShow,JobGuid,HandleType,ClientIdentifier,ClientTag,IsDel,IsNoHandle) VALUES(sq_Messages_Center.nextval,:MessageItemGuid,:Title,:MessageType,:Content,:SendMode,:GenerateDate,:IsSchedule,:ScheduleSendDate,:MessageTarget,:TargetUser,:TargetDispName,:FromUser,:FromDispName,:FromMobile,:HandleUrl,:BeiZhu,:OuGuid,:BaseOuGuid,:IsShow,:JobGuid,:HandleType,:ClientIdentifier,:ClientTag,0,0)"
            //);
            //DbCommand cmd = db.GetSqlStringCommand(strSql);

            //db.AddInParameter(cmd,"MessageItemGuid",DbType.String,MessageItemGuid);
            //db.AddInParameter(cmd,"Title",DbType.String,Title);
            //db.AddInParameter(cmd,"MessageType",DbType.String,MessageType);
            //db.AddInParameter(cmd,"Content",DbType.String,"");
            //db.AddInParameter(cmd,"SendMode",DbType.Int32,4);
            //db.AddInParameter(cmd,"GenerateDate",DbType.DateTime,DateTime.Now);
            //db.AddInParameter(cmd,"IsSchedule",DbType.Int32,0);
            //db.AddInParameter(cmd,"ScheduleSendDate",DbType.DateTime,DBNull.Value);
            //db.AddInParameter(cmd,"MessageTarget",DbType.String,"");
            //db.AddInParameter(cmd,"TargetUser",DbType.String,TargetUser);
            //db.AddInParameter(cmd,"TargetDispName",DbType.String,TargetDispName);
            //db.AddInParameter(cmd,"FromUser",DbType.String,FromUser);
            //db.AddInParameter(cmd,"FromDispName",DbType.String,FromDispName);
            //db.AddInParameter(cmd,"FromMobile",DbType.String,"");
            //db.AddInParameter(cmd,"HandleUrl",DbType.String,HandleUrl);
            //db.AddInParameter(cmd,"BeiZhu",DbType.String,CurrentActivityStepName);
            //db.AddInParameter(cmd,"OuGuid",DbType.String,OuGuid);
            //db.AddInParameter(cmd,"BaseOuGuid",DbType.String,BaseOuGuid);
            //db.AddInParameter(cmd,"IsShow",DbType.Int32,IsShow);
            //db.AddInParameter(cmd,"JobGuid",DbType.String,JobGuid);
            //db.AddInParameter(cmd,"HandleType",DbType.String,HandleType);
            //db.AddInParameter(cmd,"ClientIdentifier",DbType.String,ClientIdentifier);
            //db.AddInParameter(cmd,"ClientTag",DbType.String,ClientTag);
            //db.ExecuteNonQuery(cmd);
            //return true;
            #endregion
        }

        /// <summary>
        /// �����Ϣ����(������������)
        /// �ް�����ӣ��������ݵ�ʹ�ã������ط���ʹ��
        /// ����Ƿ��͸��û��ģ���TargetUser!="",JobGuid="";����Ƿ��͸�ְλ�ģ���TargetUser="",JobGuid!="";��
        /// ϵͳ�жϣ����JobGuid!="",��ϵͳ���Զ���TargetUser="";
        /// ��д���ڣ�2007-4-23
        /// ��д�ˣ��ް���
        /// �޸����ڣ�2010-4-16
        /// �޸��ˣ��ܽ���
        /// �޸����ݣ�������һ�����ط���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid,��ҵ��ϵͳ����Guid</param>
        /// <param name="Title">��Ϣ����</param>
        /// <param name="TargetUser">��ϢĿ���û���UserGuid���������û���ϵͳ�е�Ψһ��ʶ����</param>
        /// <param name="TargetDispName">��ϢĿ���û�������ʾ����DispName���������û���ϵͳ�е�Ψһ��ʶ����</param>
        /// <param name="FromUser">��Ϣ������,�����û���UserGuid�����Ϊ�գ���Ϊ��ǰ�û���UserGuid</param>
        /// <param name="FromDispName">��Ϣ�����˵���ʾ���ơ����Ϊ�գ���Ϊ��ǰ�û�����ʾ����</param>
        /// <param name="CurrentActivityStepName">��ǰ����������</param>
        /// <param name="HandleUrl">����Ǵ������ˣ���ʾ��Ӧ�Ĵ���URL��ָ������Ŀ¼�����Url������������Ŀ¼���ƣ��ڲ���url��ʱ����Ҫ�Ѵ�����¼��MessageItemGuid��Ϊ����������url�ĺ���</param>
        /// <param name="OuGuid">�û����ڲ��ŵ�OuGuid,��Session["OUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���OUGuid</param>
        /// <param name="BaseOuGuid">�û����ڶ��������ŵ�OuGuid,��Session["BaseOUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���BaseOUGuid </param>
        /// <param name="IsShow">�Ƿ��ڴ�����������ʾ�������0������ʾ��������ʾ��Ĭ��Ϊ1</param>
        /// <param name="JobGuid">��Ӧ��ְλGuid</param>
        /// <param name="HandleType">�˴������˶�Ӧ�ķ���</param>
        /// <param name="ClientIdentifier">ҵ��ϵͳ��ϵͳ�Ĵ���������Ϣ</param>
        /// <param name="ClientTag">��ʶ</param>
        /// <param name="GenerateDate">��Ϣ����ʱ��</param>
        /// <param name="PVIGuid">��Ϣ��Ӧ������ʵ��Guid</param>
        /// <returns>Boolean</returns>
        public Boolean WaitHandle_Insert(string MessageItemGuid, string Title, string MessageType, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string CurrentActivityStepName, string HandleUrl, string OuGuid, string BaseOuGuid, int IsShow, string JobGuid, string HandleType, string ClientIdentifier, string ClientTag, DateTime GenerateDate, String PVIGuid)
        {
            return WaitHandle_Insert(MessageItemGuid, Title, MessageType, TargetUser, TargetDispName, FromUser, FromDispName, CurrentActivityStepName, HandleUrl, OuGuid, BaseOuGuid, IsShow, JobGuid, HandleType, ClientIdentifier, ClientTag, GenerateDate, PVIGuid, DateTime.MinValue, DateTime.MinValue);

            #region ����
            //if (FromUser == null || FromUser == "")
            //{
            //    try
            //    {
            //        FromUser = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["UserGuid"]);
            //    }
            //    catch
            //    {
            //        FromUser = "";
            //    }
            //}
            //if (FromDispName == null || FromDispName == "")
            //{
            //    try
            //    {
            //        FromDispName = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["DisplayName"]);
            //    }
            //    catch
            //    {
            //        FromDispName = "";
            //    }
            //}

            //if (OuGuid == null || OuGuid == "")
            //{
            //    try
            //    {
            //        OuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["OUGuid"]);
            //    }
            //    catch
            //    {
            //        OuGuid = "";
            //    }
            //}

            //if (BaseOuGuid == null || BaseOuGuid == "")
            //{
            //    try
            //    {
            //        BaseOuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["BaseOUGuid"]);
            //    }
            //    catch
            //    {
            //        BaseOuGuid = "";
            //    }
            //}

            //if (Title == null || Title == "")
            //    Title = "�ޱ���";

            //if (MessageType == null || MessageType == "")
            //    MessageType = "����";

            //if (MessageType == "�Ķ�")
            //    MessageType = "�Ķ�";
            //else
            //    MessageType = "����";

            //if (JobGuid != "")
            //    TargetUser = "";// DateTime GenerateDate, String PVIGuid    GenerateDate,PVIGuid

            //String PartitionTag = "";
            //if (TargetUser.Length > 0)
            //    PartitionTag = TargetUser.Substring(0, 1);

            //Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            //string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
            //    "INSERT INTO Messages_Center(MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,HandleUrl,BeiZhu,OuGuid,BaseOuGuid,IsShow,JobGuid,HandleType,ClientIdentifier,ClientTag,IsDel,IsNoHandle, PVIGuid,PartitionTag) VALUES(@MessageItemGuid,@Title,@MessageType,@Content,@SendMode,@GenerateDate,@IsSchedule,@ScheduleSendDate,@MessageTarget,@TargetUser,@TargetDispName,@FromUser,@FromDispName,@FromMobile,@HandleUrl,@BeiZhu,@OuGuid,@BaseOuGuid,@IsShow,@JobGuid,@HandleType,@ClientIdentifier,@ClientTag,0,0,@PVIGuid,@PartitionTag) " :
            //    "INSERT INTO Messages_Center(Row_ID,MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,HandleUrl,BeiZhu,OuGuid,BaseOuGuid,IsShow,JobGuid,HandleType,ClientIdentifier,ClientTag,IsDel,IsNoHandle, PVIGuid,PartitionTag) VALUES(sq_Messages_Center.nextval,:MessageItemGuid,:Title,:MessageType,:Content,:SendMode,:GenerateDate,:IsSchedule,:ScheduleSendDate,:MessageTarget,:TargetUser,:TargetDispName,:FromUser,:FromDispName,:FromMobile,:HandleUrl,:BeiZhu,:OuGuid,:BaseOuGuid,:IsShow,:JobGuid,:HandleType,:ClientIdentifier,:ClientTag,0,0,:PVIGuid,:PartitionTag)"
            //);
            //DbCommand cmd = db.GetSqlStringCommand(strSql);

            //db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            //db.AddInParameter(cmd, "Title", DbType.String, Title);
            //db.AddInParameter(cmd, "MessageType", DbType.String, MessageType);
            //db.AddInParameter(cmd, "Content", DbType.String, "");
            //db.AddInParameter(cmd, "SendMode", DbType.Int32, 4);
            //if(GenerateDate==new DateTime(1,1,1))
            //    db.AddInParameter(cmd, "GenerateDate", DbType.DateTime, DateTime.Now);
            //else
            //    db.AddInParameter(cmd, "GenerateDate", DbType.DateTime, GenerateDate);

            //db.AddInParameter(cmd, "IsSchedule", DbType.Int32, 0);
            //db.AddInParameter(cmd, "ScheduleSendDate", DbType.DateTime, DBNull.Value);
            //db.AddInParameter(cmd, "MessageTarget", DbType.String, "");
            //db.AddInParameter(cmd, "TargetUser", DbType.String, TargetUser);
            //db.AddInParameter(cmd, "TargetDispName", DbType.String, TargetDispName);
            //db.AddInParameter(cmd, "FromUser", DbType.String, FromUser);
            //db.AddInParameter(cmd, "FromDispName", DbType.String, FromDispName);
            //db.AddInParameter(cmd, "FromMobile", DbType.String, "");
            //db.AddInParameter(cmd, "HandleUrl", DbType.String, HandleUrl);
            //db.AddInParameter(cmd, "BeiZhu", DbType.String, CurrentActivityStepName);
            //db.AddInParameter(cmd, "OuGuid", DbType.String, OuGuid);
            //db.AddInParameter(cmd, "BaseOuGuid", DbType.String, BaseOuGuid);
            //db.AddInParameter(cmd, "IsShow", DbType.Int32, IsShow);
            //db.AddInParameter(cmd, "JobGuid", DbType.String, JobGuid);
            //db.AddInParameter(cmd, "HandleType", DbType.String, HandleType);
            //db.AddInParameter(cmd, "ClientIdentifier", DbType.String, ClientIdentifier);
            //db.AddInParameter(cmd, "ClientTag", DbType.String, ClientTag);

            //db.AddInParameter(cmd, "PVIGuid", DbType.String, PVIGuid);
            //db.AddInParameter(cmd, "PartitionTag", DbType.String, PartitionTag);
            //db.ExecuteNonQuery(cmd);
            //return true;
            #endregion
        }

        /// <summary>
        /// ���Ӵ������Ҫ����ʱ���ֶ�overtimepoint��������earlywarningpoint��
        /// ��д���ڣ�2010-4-16
        /// ��д�ˣ��ܽ���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid,��ҵ��ϵͳ����Guid</param>
        /// <param name="Title">��Ϣ����</param>
        /// <param name="TargetUser">��ϢĿ���û���UserGuid���������û���ϵͳ�е�Ψһ��ʶ����</param>
        /// <param name="TargetDispName">��ϢĿ���û�������ʾ����DispName���������û���ϵͳ�е�Ψһ��ʶ����</param>
        /// <param name="FromUser">��Ϣ������,�����û���UserGuid�����Ϊ�գ���Ϊ��ǰ�û���UserGuid</param>
        /// <param name="FromDispName">��Ϣ�����˵���ʾ���ơ����Ϊ�գ���Ϊ��ǰ�û�����ʾ����</param>
        /// <param name="CurrentActivityStepName">��ǰ����������</param>
        /// <param name="HandleUrl">����Ǵ������ˣ���ʾ��Ӧ�Ĵ���URL��ָ������Ŀ¼�����Url������������Ŀ¼���ƣ��ڲ���url��ʱ����Ҫ�Ѵ�����¼��MessageItemGuid��Ϊ����������url�ĺ���</param>
        /// <param name="OuGuid">�û����ڲ��ŵ�OuGuid,��Session["OUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���OUGuid</param>
        /// <param name="BaseOuGuid">�û����ڶ��������ŵ�OuGuid,��Session["BaseOUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���BaseOUGuid </param>
        /// <param name="IsShow">�Ƿ��ڴ�����������ʾ�������0������ʾ��������ʾ��Ĭ��Ϊ1</param>
        /// <param name="JobGuid">��Ӧ��ְλGuid</param>
        /// <param name="HandleType">�˴������˶�Ӧ�ķ���</param>
        /// <param name="ClientIdentifier">ҵ��ϵͳ��ϵͳ�Ĵ���������Ϣ</param>
        /// <param name="ClientTag">��ʶ</param>
        /// <param name="GenerateDate">��Ϣ����ʱ��</param>
        /// <param name="PVIGuid">��Ϣ��Ӧ������ʵ��Guid</param>
        /// <param name="Overtimepoint">����ʱ��</param>
        /// <param name="Earlywarningpoint">��ǰ����ʱ��</param>
        /// <returns>Boolean</returns>
        public Boolean WaitHandle_Insert(string MessageItemGuid, string Title, string MessageType, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string CurrentActivityStepName, string HandleUrl, string OuGuid, string BaseOuGuid, int IsShow, string JobGuid, string HandleType, string ClientIdentifier, string ClientTag, DateTime GenerateDate, String PVIGuid, DateTime Overtimepoint, DateTime Earlywarningpoint)
        {
            if (FromUser == null || FromUser == "")
            {
                try
                {
                    FromUser = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["UserGuid"]);
                }
                catch
                {
                    FromUser = "";
                }
            }
            if (FromDispName == null || FromDispName == "")
            {
                try
                {
                    FromDispName = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["DisplayName"]);
                }
                catch
                {
                    FromDispName = "";
                }
            }

            if (OuGuid == null || OuGuid == "")
            {
                try
                {
                    OuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["OUGuid"]);
                }
                catch
                {
                    OuGuid = "";
                }
            }

            if (BaseOuGuid == null || BaseOuGuid == "")
            {
                try
                {
                    BaseOuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["BaseOUGuid"]);
                }
                catch
                {
                    BaseOuGuid = "";
                }
            }

            if (Title == null || Title == "")
                Title = "�ޱ���";

            if (MessageType == null || MessageType == "")
                MessageType = "����";

            if (MessageType == "�Ķ�")
                MessageType = "�Ķ�";
            else
                MessageType = "����";

            if (JobGuid != "")
                TargetUser = "";// DateTime GenerateDate, String PVIGuid    GenerateDate,PVIGuid

            String PartitionTag = "";
            if (TargetUser.Length > 0)
                PartitionTag = TargetUser.Substring(0, 1);

            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "INSERT INTO Messages_Center(MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,HandleUrl,BeiZhu,OuGuid,BaseOuGuid,IsShow,JobGuid,HandleType,ClientIdentifier,ClientTag,IsDel,IsNoHandle, PVIGuid,PartitionTag,overtimepoint,earlywarningpoint) VALUES(@MessageItemGuid,@Title,@MessageType,@Content,@SendMode,@GenerateDate,@IsSchedule,@ScheduleSendDate,@MessageTarget,@TargetUser,@TargetDispName,@FromUser,@FromDispName,@FromMobile,@HandleUrl,@BeiZhu,@OuGuid,@BaseOuGuid,@IsShow,@JobGuid,@HandleType,@ClientIdentifier,@ClientTag,0,0,@PVIGuid,@PartitionTag,@overtimepoint,@earlywarningpoint) " :
                "INSERT INTO Messages_Center(Row_ID,MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,HandleUrl,BeiZhu,OuGuid,BaseOuGuid,IsShow,JobGuid,HandleType,ClientIdentifier,ClientTag,IsDel,IsNoHandle, PVIGuid,PartitionTag,overtimepoint,earlywarningpoint) VALUES(sq_Messages_Center.nextval,:MessageItemGuid,:Title,:MessageType,:Content,:SendMode,:GenerateDate,:IsSchedule,:ScheduleSendDate,:MessageTarget,:TargetUser,:TargetDispName,:FromUser,:FromDispName,:FromMobile,:HandleUrl,:BeiZhu,:OuGuid,:BaseOuGuid,:IsShow,:JobGuid,:HandleType,:ClientIdentifier,:ClientTag,0,0,:PVIGuid,:PartitionTag,:overtimepoint,:earlywarningpoint)"
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.AddInParameter(cmd, "Title", DbType.String, Title);
            db.AddInParameter(cmd, "MessageType", DbType.String, MessageType);
            db.AddInParameter(cmd, "Content", DbType.String, "");
            db.AddInParameter(cmd, "SendMode", DbType.Int32, 4);
            if (GenerateDate == new DateTime(1, 1, 1))
                db.AddInParameter(cmd, "GenerateDate", DbType.DateTime, DateTime.Now);
            else
                db.AddInParameter(cmd, "GenerateDate", DbType.DateTime, GenerateDate);

            db.AddInParameter(cmd, "IsSchedule", DbType.Int32, 0);
            db.AddInParameter(cmd, "ScheduleSendDate", DbType.DateTime, DBNull.Value);
            db.AddInParameter(cmd, "MessageTarget", DbType.String, "");
            db.AddInParameter(cmd, "TargetUser", DbType.String, TargetUser);
            db.AddInParameter(cmd, "TargetDispName", DbType.String, TargetDispName);
            db.AddInParameter(cmd, "FromUser", DbType.String, FromUser);
            db.AddInParameter(cmd, "FromDispName", DbType.String, FromDispName);
            db.AddInParameter(cmd, "FromMobile", DbType.String, "");
            db.AddInParameter(cmd, "HandleUrl", DbType.String, HandleUrl);
            db.AddInParameter(cmd, "BeiZhu", DbType.String, CurrentActivityStepName);
            db.AddInParameter(cmd, "OuGuid", DbType.String, OuGuid);
            db.AddInParameter(cmd, "BaseOuGuid", DbType.String, BaseOuGuid);
            db.AddInParameter(cmd, "IsShow", DbType.Int32, IsShow);
            db.AddInParameter(cmd, "JobGuid", DbType.String, JobGuid);
            db.AddInParameter(cmd, "HandleType", DbType.String, HandleType);
            db.AddInParameter(cmd, "ClientIdentifier", DbType.String, ClientIdentifier);
            db.AddInParameter(cmd, "ClientTag", DbType.String, ClientTag);

            db.AddInParameter(cmd, "PVIGuid", DbType.String, PVIGuid);
            db.AddInParameter(cmd, "PartitionTag", DbType.String, PartitionTag);

            if (Overtimepoint == DateTime.MinValue)
                db.AddInParameter(cmd, "overtimepoint", DbType.DateTime, DBNull.Value);
            else
                db.AddInParameter(cmd, "overtimepoint", DbType.DateTime, Overtimepoint);

            if (Earlywarningpoint == DateTime.MinValue)
                db.AddInParameter(cmd, "earlywarningpoint", DbType.DateTime, DBNull.Value);
            else
                db.AddInParameter(cmd, "earlywarningpoint", DbType.DateTime, Earlywarningpoint);
            db.ExecuteNonQuery(cmd);
            return true;
        }


        /// <summary>
        /// �����Ϣ����(For�������ݹ��ܣ������ط���ʹ��)
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid"></param>
        /// <param name="Title"></param>
        /// <param name="MessageType"></param>
        /// <param name="TargetUser"></param>
        /// <param name="TargetDispName"></param>
        /// <param name="FromUser"></param>
        /// <param name="FromDispName"></param>
        /// <param name="CurrentActivityStepName"></param>
        /// <param name="HandleUrl"></param>
        /// <param name="OuGuid"></param>
        /// <param name="BaseOuGuid"></param>
        /// <param name="IsShow"></param>
        /// <param name="JobGuid"></param>
        /// <param name="HandleType"></param>
        /// <param name="ClientIdentifier"></param>
        /// <param name="GenerateDate"></param>
        /// <param name="DoneDate"></param>
        /// <param name="IsDel"></param>
        /// <returns></returns>
        public Boolean WaitHandle_Insert_ForImport(string MessageItemGuid, string Title, string MessageType, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string CurrentActivityStepName, string HandleUrl, string OuGuid, string BaseOuGuid, int IsShow, string JobGuid, string HandleType, string ClientIdentifier, DateTime GenerateDate, DateTime DoneDate, int IsDel)
        {
            if (FromUser == null || FromUser == "")
            {
                try
                {
                    FromUser = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["UserGuid"]);
                }
                catch { FromUser = ""; }
            }
            if (FromDispName == null || FromDispName == "")
            {
                try
                {
                    FromDispName = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["DisplayName"]);
                }
                catch { FromDispName = ""; }
            }

            if (OuGuid == null || OuGuid == "")
            {
                try
                {
                    OuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["OUGuid"]);
                }
                catch { OuGuid = ""; }
            }

            if (BaseOuGuid == null || BaseOuGuid == "")
            {
                try
                {
                    BaseOuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["BaseOUGuid"]);
                }
                catch { BaseOuGuid = ""; }
            }

            if (Title == null || Title == "")
                Title = "�ޱ���";

            if (MessageType == null || MessageType == "")
                MessageType = "����";

            if (MessageType != "����")
                MessageType = "�Ķ�";

            if (JobGuid != "")
                TargetUser = "";

            String PartitionTag = "";
            if (TargetUser.Length > 0)
                PartitionTag = TargetUser.Substring(0, 1);

            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "INSERT INTO Messages_Center(MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,HandleUrl,BeiZhu,OuGuid,BaseOuGuid,IsShow,JobGuid,HandleType,ClientIdentifier,IsNoHandle,DoneDate,IsDel,PartitionTag) VALUES(@MessageItemGuid,@Title,@MessageType,@Content,@SendMode,@GenerateDate,@IsSchedule,@ScheduleSendDate,@MessageTarget,@TargetUser,@TargetDispName,@FromUser,@FromDispName,@FromMobile,@HandleUrl,@BeiZhu,@OuGuid,@BaseOuGuid,@IsShow,@JobGuid,@HandleType,@ClientIdentifier,0,@DoneDate,@IsDel,@PartitionTag) " :
                "INSERT INTO Messages_Center(Row_ID,MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,HandleUrl,BeiZhu,OuGuid,BaseOuGuid,IsShow,JobGuid,HandleType,ClientIdentifier,IsNoHandle,DoneDate,IsDel,PartitionTag) VALUES(sq_Messages_Center.nextval,:MessageItemGuid,:Title,:MessageType,:Content,:SendMode,:GenerateDate,:IsSchedule,:ScheduleSendDate,:MessageTarget,:TargetUser,:TargetDispName,:FromUser,:FromDispName,:FromMobile,:HandleUrl,:BeiZhu,:OuGuid,:BaseOuGuid,:IsShow,:JobGuid,:HandleType,:ClientIdentifier,0,:DoneDate,:IsDel,:PartitionTag)"
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.AddInParameter(cmd, "Title", DbType.String, Title);
            db.AddInParameter(cmd, "MessageType", DbType.String, MessageType);
            db.AddInParameter(cmd, "Content", DbType.String, "");
            db.AddInParameter(cmd, "SendMode", DbType.Int32, 4);
            db.AddInParameter(cmd, "GenerateDate", DbType.DateTime, GenerateDate);
            db.AddInParameter(cmd, "IsSchedule", DbType.Int32, 0);

            if (DoneDate == new DateTime(1, 1, 1))
                db.AddInParameter(cmd, "DoneDate", DbType.DateTime, DBNull.Value);
            else
                db.AddInParameter(cmd, "DoneDate", DbType.DateTime, DoneDate);

            db.AddInParameter(cmd, "IsDel", DbType.Int32, IsDel);

            db.AddInParameter(cmd, "ScheduleSendDate", DbType.DateTime, DBNull.Value);
            db.AddInParameter(cmd, "MessageTarget", DbType.String, "");
            db.AddInParameter(cmd, "TargetUser", DbType.String, TargetUser);
            db.AddInParameter(cmd, "TargetDispName", DbType.String, TargetDispName);
            db.AddInParameter(cmd, "FromUser", DbType.String, FromUser);
            db.AddInParameter(cmd, "FromDispName", DbType.String, FromDispName);
            db.AddInParameter(cmd, "FromMobile", DbType.String, "");
            db.AddInParameter(cmd, "HandleUrl", DbType.String, HandleUrl);
            db.AddInParameter(cmd, "BeiZhu", DbType.String, CurrentActivityStepName);
            db.AddInParameter(cmd, "OuGuid", DbType.String, OuGuid);
            db.AddInParameter(cmd, "BaseOuGuid", DbType.String, BaseOuGuid);
            db.AddInParameter(cmd, "IsShow", DbType.Int32, IsShow);
            db.AddInParameter(cmd, "JobGuid", DbType.String, JobGuid);
            db.AddInParameter(cmd, "HandleType", DbType.String, HandleType);
            db.AddInParameter(cmd, "ClientIdentifier", DbType.String, ClientIdentifier);
            db.AddInParameter(cmd, "PartitionTag", DbType.String, PartitionTag);
            db.ExecuteNonQuery(cmd);
            return true;
        }

        /// <summary>
        /// ɾ����Ϣ����ɾ�������������ջأ������Ϣ�ڴ������ˡ��Ѱ����ˡ���ɾ�������ж����ɼ�
        /// sql�в���������MessageItemGuid����IsNoHandle����ת�Ƶ���ʷ����   ��UPDATE Messages_Center SET IsNoHandle=@IsNoHandle WHERE  MessageItemGuid=@MessageItemGuid
        /// ��д���ڣ�2007-9-3
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid</param>
        public void WaitHandle_UpdateNoHandle(string MessageItemGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET IsNoHandle=@IsNoHandle WHERE  MessageItemGuid=@MessageItemGuid " :
                "UPDATE Messages_Center SET IsNoHandle=:IsNoHandle WHERE  MessageItemGuid=:MessageItemGuid "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "IsNoHandle", DbType.Int32, 1);
            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);

            //���º�ת����Ϣ���Ѵ������
            MsgHistroy.Move_WaitHandleToHistroy(MessageItemGuid);
        }

        /// <summary>
        /// ���´���Ϣ��״̬���ô���Ϣ�ڴ�����������ʾ   ,ֻ����״̬�����������κδ���
        /// sql�в���������MessageItemGuid����IsShow  ��UPDATE Messages_Center SET IsShow=@IsShow WHERE  MessageItemGuid=@MessageItemGuid
        /// ��д���ڣ�2007-10-8
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid</param>
        /// <param name="IsShow">�Ƿ������ʾ</param>
        public void WaitHandle_UpdateShow(string MessageItemGuid, Boolean IsShow)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET IsShow=@IsShow WHERE  MessageItemGuid=@MessageItemGuid " :
                "UPDATE Messages_Center SET IsShow=:IsShow WHERE  MessageItemGuid=:MessageItemGuid "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "IsShow", DbType.Int32, IsShow ? 1 : 0);
            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// ���´���Ϣ��ClientIdentifier �� ����MessageItemGuidֻ����ClientIdentifier�����������κδ���
        /// sql��UPDATE Messages_Center SET ClientIdentifier=@ClientIdentifier WHERE  MessageItemGuid=@MessageItemGuid
        /// ��д���ڣ�2008-5-24
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid</param>
        /// <param name="ClientIdentifier">ClientIdentifier</param>
        public void WaitHandle_UpdateClientIdentifier(string MessageItemGuid, String ClientIdentifier)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET ClientIdentifier=@ClientIdentifier WHERE  MessageItemGuid=@MessageItemGuid " :
                "UPDATE Messages_Center SET ClientIdentifier=:ClientIdentifier WHERE  MessageItemGuid=:MessageItemGuid "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "ClientIdentifier", DbType.String, ClientIdentifier);
            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// ������Ϣ��Title  ��ͬʱ���±�:Messages_Center��Messages_Center_Histroy
        /// ��д���ڣ�2007-9-5
        /// ��д�ˣ�Ԭѫ
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid</param>
        /// <param name="Title">Title</param>
        public void WaitHandle_UpdateTitle(string MessageItemGuid, string Title)
        {
            //Ϊ��ֹ��Ϣ�ѱ�ת�Ƶ���ʷ��ͬʱ����Messages_Center_Histroy
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET Title=@Title WHERE  MessageItemGuid=@MessageItemGuid  UPDATE Messages_Center_Histroy SET Title=@Title WHERE  MessageItemGuid=@MessageItemGuid " :
                "begin UPDATE Messages_Center SET Title=:Title WHERE  MessageItemGuid=:MessageItemGuid ;  UPDATE Messages_Center_Histroy SET Title=:Title WHERE  MessageItemGuid=:MessageItemGuid ;end; "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "Title", DbType.String, Title);
            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// ����
        /// UPDATE Messages_Center SET TargetUser=@newTargetUser WHERE  TargetUser=@oldTargetUser  UPDATE Messages_Center_Histroy SET TargetUser=@newTargetUser WHERE  TargetUser=@oldTargetUser
        /// </summary>
        /// <param name="newTargetUser"></param>
        /// <param name="oldTargetUser"></param>
        public void WaitHandle_UpdateTargetUser(string newTargetUser, string oldTargetUser)
        {
            //Ϊ��ֹ��Ϣ�ѱ�ת�Ƶ���ʷ��ͬʱ����Messages_Center_Histroy
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET TargetUser=@newTargetUser WHERE  TargetUser=@oldTargetUser  UPDATE Messages_Center_Histroy SET TargetUser=@newTargetUser WHERE  TargetUser=@oldTargetUser " :
                "begin UPDATE Messages_Center SET TargetUser=:newTargetUser WHERE  TargetUser=:oldTargetUser ;  UPDATE Messages_Center_Histroy SET TargetUser=:newTargetUser WHERE  TargetUser=:oldTargetUser ;end; "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "newTargetUser", DbType.String, newTargetUser);
            db.AddInParameter(cmd, "oldTargetUser", DbType.String, oldTargetUser);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// ����TargetUserȡ�õ�ǰ�û����е�δ����������
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="TargetUser">��Ϣ������</param>
        /// <param name="DateFromTo">��ʼʱ��</param>
        /// <param name="DateTo">����ʱ��</param>
        public long WaitHandle_SelectUserNoHandleCount(string TargetUser, String DateFromTo, String DateTo)
        {
            Boolean IsOracle = DatabaseOperate.IsOracle("Messages_ConnectionString");
            String sql = "";
            if (DateFromTo != "")
            {
                if (IsOracle)
                    sql += " and GenerateDate >= TO_DATE('" + DateFromTo + "','YYYY-MM-DD HH24:MI:SS') ";
                else
                    sql += " and GenerateDate >= '" + DateFromTo + "' ";
            }

            if (DateTo != "")
            {
                if (IsOracle)
                    sql += " and GenerateDate <= TO_DATE('" + DateTo + " 23:59:59','YYYY-MM-DD HH24:MI:SS') ";
                else
                    sql += " and GenerateDate <= '" + DateTo + " 23:59:59' ";
            }

            String PartitionTag = "";
            if (TargetUser.Length > 0)
                PartitionTag = TargetUser.Substring(0, 1);
            //and PartitionTag='" + PartitionTag + "' 

            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "select count(*) from Messages_Center where SendMode=4 and IsShow = 1 and IsDel= 0 and IsNoHandle=0 and DoneDate is null and TargetUser=@TargetUser " + sql :
                "select count(*) from Messages_Center where SendMode=4 and IsShow = 1 and IsDel= 0 and IsNoHandle=0 and DoneDate is null and TargetUser=:TargetUser " + sql
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "TargetUser", DbType.String, TargetUser);

            return Convert.ToInt64(db.ExecuteScalar(cmd));
        }

        /// <summary>
        /// ����MessageItemGuid����MessageType
        /// sql��UPDATE Messages_Center SET MessageType=@MessageType WHERE  MessageItemGuid=@MessageItemGuid 
        /// ��д���ڣ�2007-9-5
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid</param>
        /// <param name="MessageType">MessageType</param>
        public void WaitHandle_UpdateMessageType(string MessageItemGuid, string MessageType)
        {
            //Ϊ��ֹ��Ϣ�ѱ�ת�Ƶ���ʷ��ͬʱ����Messages_Center_Histroy
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET MessageType=@MessageType WHERE  MessageItemGuid=@MessageItemGuid   " :
                "UPDATE Messages_Center SET MessageType=:MessageType WHERE  MessageItemGuid=:MessageItemGuid  "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "MessageType", DbType.String, MessageType);
            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// �ڴ�����ɵ�ʱ�򣬸��´������˵Ĵ���״̬����ʾ����Ϣ�Ѿ�����,�����У������˶��Ѵ���������˵Ĺ��ˣ����³ɹ���ת�Ƶ���ʷ����
        /// ����ʱ��Ϊϵͳ��ǰʱ��
        /// ��д���ڣ�2007-9-3
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢGuid</param>
        /// <param name="DoneDate">DoneDate</param>
        public void WaitHandle_UpdateHandle(string MessageItemGuid, DateTime DoneDate)
        {
            //�ж��Ƿ��Ѵ���
            string strTempMessageItemGuid = GetDetail(MessageItemGuid).MessageItemGuid;
            if (strTempMessageItemGuid == null || strTempMessageItemGuid == "")
            {
            }
            else
            {
                Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
                string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                    "UPDATE Messages_Center SET DoneDate=@DoneDate WHERE  MessageItemGuid=@MessageItemGuid " :
                    "UPDATE Messages_Center SET DoneDate=:DoneDate WHERE  MessageItemGuid=:MessageItemGuid "
                );
                DbCommand cmd = db.GetSqlStringCommand(strSql);
                db.AddInParameter(cmd, "DoneDate", DbType.DateTime, DoneDate);
                db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
                db.ExecuteNonQuery(cmd);

                //�����ת����Ϣ���Ѵ������
                MsgHistroy.Move_WaitHandleToHistroy(MessageItemGuid);
            }
        }

        /// <summary>
        /// �ڴ�����ɵ�ʱ�򣬸��´������˵Ĵ���״̬����ʾ����Ϣ�Ѿ�����,�����У������˶��Ѵ���������˵Ĺ��ˣ����³ɹ���ת�Ƶ���ʷ����
        /// ����ʱ��Ϊϵͳ��ǰʱ��
        /// ��д���ڣ�2007-9-3
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢGuid</param>
        /// <param name="DoneDate">DoneDate</param>
        /// <param name="OperatorGuid">OperatorGuid</param>
        /// <param name="OperatorForDisplayGuid">OperatorForDisplayGuid</param>
        public void WaitHandle_UpdateHandle(string MessageItemGuid, DateTime DoneDate, string OperatorGuid, string OperatorForDisplayGuid)
        {
            //�ж��Ƿ��Ѵ���
            string strTempMessageItemGuid = GetDetail(MessageItemGuid).MessageItemGuid;
            if (strTempMessageItemGuid == null || strTempMessageItemGuid == "")
            {
            }
            else
            {
                Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
                string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                    "UPDATE Messages_Center SET DoneDate=@DoneDate,OperatorGuid=@OperatorGuid,OperatorForDisplayGuid=@OperatorForDisplayGuid  WHERE  MessageItemGuid=@MessageItemGuid " :
                    "UPDATE Messages_Center SET DoneDate=:DoneDate,OperatorGuid=:OperatorGuid,OperatorForDisplayGuid=:OperatorForDisplayGuid  WHERE  MessageItemGuid=:MessageItemGuid "
                );
                DbCommand cmd = db.GetSqlStringCommand(strSql);
                db.AddInParameter(cmd, "DoneDate", DbType.DateTime, DoneDate);
                db.AddInParameter(cmd, "OperatorGuid", DbType.String, OperatorGuid);
                db.AddInParameter(cmd, "OperatorForDisplayGuid", DbType.String, OperatorForDisplayGuid);

                db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
                db.ExecuteNonQuery(cmd);

                //�����ת����Ϣ���Ѵ������
                MsgHistroy.Move_WaitHandleToHistroy(MessageItemGuid);
            }
        }

        /// <summary>
        /// ���Ѱ������еļ�¼ת�Ƶ�δ��������
        /// ��д���ڣ�2008-8-13
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢGuid</param>
        public void WaitHandle_MoveToNoHandle(string MessageItemGuid)
        {
            //�ж����Ѱ��������Ƿ����
            string strTempMessageItemGuid = MsgHistroy.GetDetail(MessageItemGuid).MessageItemGuid;
            if (strTempMessageItemGuid == null || strTempMessageItemGuid == "")
            {
            }
            else
            {
                Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
                string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                    "UPDATE Messages_Center_Histroy SET DoneDate = null WHERE  MessageItemGuid=@MessageItemGuid " :
                    "UPDATE Messages_Center_Histroy SET DoneDate = null WHERE  MessageItemGuid=:MessageItemGuid "
                );
                DbCommand cmd = db.GetSqlStringCommand(strSql);
                db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
                db.ExecuteNonQuery(cmd);

                //�����ת����Ϣ��δ�������
                Move_WaitHandleFromhistoryToHandle(MessageItemGuid);
            }
        }

        /// <summary>
        /// �û��ڴ������ˡ��Ѱ�������ɾ����Ϣ �������ɹ���ת�Ƶ���ʷ����
        /// sql:   UPDATE Messages_Center SET IsDel=@IsDel WHERE  MessageItemGuid=@MessageItemGuid
        /// ��д���ڣ�2007-9-3
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">MessageItemGuid</param>
        public void WaitHandle_Delete(string MessageItemGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET IsDel=@IsDel WHERE  MessageItemGuid=@MessageItemGuid " :
                "UPDATE Messages_Center SET IsDel=:IsDel WHERE  MessageItemGuid=:MessageItemGuid "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "IsDel", DbType.Int32, 1);
            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);

            //�����ת����Ϣ���Ѵ������
            MsgHistroy.Move_WaitHandleToHistroy(MessageItemGuid);
        }

        public void DeleteWH(string PType, string PGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "DELETE Messages_Center WHERE  PTYPE=@PTYPE and PGuid=@PGuid " :
                "DELETE Messages_Center WHERE  PTYPE=:PTYPE and PGuid=:PGuid "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "IsDel", DbType.Int32, 1);
            db.AddInParameter(cmd, "PTYPE", DbType.String, PType);
            db.AddInParameter(cmd, "PGuid", DbType.String, PGuid);
            db.ExecuteNonQuery(cmd);

        }

        public void WaitHandle_Delete(string PType,string PGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET IsDel=@IsDel WHERE  PTYPE=@PTYPE and PGuid=@PGuid " :
                "UPDATE Messages_Center SET IsDel=:IsDel WHERE  PTYPE=:PTYPE and PGuid=:PGuid "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "IsDel", DbType.Int32, 1);
            db.AddInParameter(cmd, "PTYPE", DbType.String, PType);
            db.AddInParameter(cmd, "PGuid", DbType.String, PGuid);
            db.ExecuteNonQuery(cmd);

            strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT MessageItemGuid FROM Messages_Center WHERE  PTYPE=@PTYPE and PGuid=@PGuid " :
                "SELECT MessageItemGuid FROM Messages_Center WHERE  PTYPE=@PTYPE and PGuid=@PGuid "
            );
            Database db2 = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            DbCommand cmd2 = db2.GetSqlStringCommand(strSql);

            db2.AddInParameter(cmd2, "PTYPE", DbType.String, PType);
            db2.AddInParameter(cmd2, "PGuid", DbType.String, PGuid);
            DataView DV = db2.ExecuteDataView(cmd2);
            for (int m = 0; m < DV.Count; m++)
            {
                //�����ת����Ϣ���Ѵ������
                MsgHistroy.Move_WaitHandleToHistroy(DV[m]["MessageItemGuid"].ToString());
            }
        }

        /// <summary>
        /// �û����Ѱ�������ɾ����Ϣ
        /// sql������UPDATE Messages_Center_Histroy SET IsDel=@IsDel WHERE  MessageItemGuid=@MessageItemGuid
        /// ��д���ڣ�2007-9-3
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">MessageItemGuid</param>
        public void WaitHandle_Delete_Histroy(string MessageItemGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center_Histroy SET IsDel=@IsDel WHERE  MessageItemGuid=@MessageItemGuid " :
                "UPDATE Messages_Center_Histroy SET IsDel=:IsDel WHERE  MessageItemGuid=:MessageItemGuid "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "IsDel", DbType.Int32, 1);
            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// �û��ڴ������ˡ��Ѱ�������ɾ����Ϣ   ,����ɾ����Ϣ
        /// sql:delete from Messages_Center WHERE  MessageItemGuid=@MessageItemGuid  delete from Messages_Center_Histroy WHERE  MessageItemGuid=@MessageItemGuid
        /// ��д���ڣ�2007-9-3
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">MessageItemGuid</param>
        public void WaitHandle_DeleteForEver(string MessageItemGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "delete from Messages_Center WHERE  MessageItemGuid=@MessageItemGuid  delete from Messages_Center_Histroy WHERE  MessageItemGuid=@MessageItemGuid" :
                "begin delete from Messages_Center WHERE  MessageItemGuid=:MessageItemGuid ; delete from Messages_Center_Histroy WHERE  MessageItemGuid=:MessageItemGuid;end; "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// ����MessageItemGuid ���� ArchiveNo
        /// ��д���ڣ�2008-9-9
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">MessageItemGuid</param>
        /// <param name="ArchiveNo">ArchiveNo</param>
        public void WaitHandle_Update_ArchiveNo(string MessageItemGuid, string ArchiveNo)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET ArchiveNo=@ArchiveNo WHERE  MessageItemGuid=@MessageItemGuid " :
                "UPDATE Messages_Center SET ArchiveNo=:ArchiveNo WHERE  MessageItemGuid=:MessageItemGuid "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "ArchiveNo", DbType.String, ArchiveNo);
            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// ����MessageItemGuid ���� NoNeedRemind
        /// ��д���ڣ�2008-9-9
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">MessageItemGuid</param>
        /// <param name="NoNeedRemind">NoNeedRemind</param>
        public void WaitHandle_Update_NoNeedRemind(int NoNeedRemind, string MessageItemGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET NoNeedRemind=@NoNeedRemind WHERE  MessageItemGuid=@MessageItemGuid " :
                "UPDATE Messages_Center SET NoNeedRemind=:NoNeedRemind WHERE  MessageItemGuid=:MessageItemGuid "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "NoNeedRemind", DbType.Int32, NoNeedRemind);
            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// ȡ��δ����Ĵ�������
        /// ֻȡ����ģ������Ĳ���ʾ
        /// �ް���
        /// 2007��10��13
        /// </summary>
        /// <param name="OwnerUserGuid">�û���UserGuid</param>
        /// <param name="JobList">�û���Ӧ��ְλ�б�</param> 
        /// <param name="Rows">��Ҫȡ������</param>
        /// <returns></returns>
        public DataView GetNewsWaitHandleTop_SuzhouJSJ(string OwnerUserGuid, string JobList, int Rows)
        {
            string SuzhouJSJ_ClientIdentifierLst = ApplicationOperate.GetConfigValueByName("SuzhouJSJ_ClientIdentifierLst");

            string str_Sql = "select top " + Rows.ToString() + " Title ,MessageItemGuid,MessageType,FromDispName,GenerateDate,BeiZhu,HandleUrl,OverTimePoint,EarlyWarningPoint from Messages_Center where   SendMode=4 and  DoneDate is null and IsShow = 1 ";
            if (SuzhouJSJ_ClientIdentifierLst != null && SuzhouJSJ_ClientIdentifierLst != "")
                str_Sql += " and ClientIdentifier not in (" + SuzhouJSJ_ClientIdentifierLst + ") ";
            str_Sql += " and ClientTag<>'��������' ";

            if (JobList != "")
                str_Sql += " and ( TargetUser = '" + OwnerUserGuid + "' or  CHARINDEX(JobGuid,'" + JobList + "')<>0 ) ";
            else
                str_Sql += " and ( TargetUser = '" + OwnerUserGuid + "' ) ";

            str_Sql += " order by  Row_ID desc ";

            string str_Oracle = "select  Title ,MessageItemGuid,MessageType,FromDispName,GenerateDate,HandleUrl,BeiZhu from Messages_Center,OverTimePoint,EarlyWarningPoint where   SendMode=4 and  DoneDate is null and IsShow = 1 ";
            if (SuzhouJSJ_ClientIdentifierLst != null && SuzhouJSJ_ClientIdentifierLst != "")
                str_Oracle += " and ClientIdentifier not in (" + SuzhouJSJ_ClientIdentifierLst + ") ";
            str_Oracle += " and ClientTag<>'��������' ";

            if (JobList != "")
                str_Oracle += " and ( TargetUser = '" + OwnerUserGuid + "' or  INSTR('" + JobList + "',JobGuid,1,1)>0 )";
            else
                str_Oracle += " and ( TargetUser = '" + OwnerUserGuid + "' ) ";
            str_Oracle += " order by  Row_ID desc ";


            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                str_Sql :
                SQLOperate.Generate_Top_Select_Oracle(str_Oracle, Rows)
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// ȡ��δ����Ĵ�������
        /// ֻȡ����ģ������Ĳ���ʾ
        /// �ް���
        /// 2007��10��13
        /// </summary>
        /// <param name="OwnerUserGuid">�û���UserGuid</param>
        /// <param name="JobList">�û���Ӧ��ְλ�б�</param> 
        /// <param name="Rows">��Ҫȡ������</param>
        /// <returns>DataView</returns>
        public DataView GetNewsWaitHandleTop(string OwnerUserGuid, string JobList, int Rows)
        {
            bool IfShowRead = false;
            if (ApplicationOperate.WaitHandle_IsShowRead)
                IfShowRead = true;

            return GetNewsWaitHandleTop(OwnerUserGuid, JobList, Rows, "", "", IfShowRead, "");
        }
        /// <summary>
        /// ȡ��δ����Ĵ�������HandleType�������
        /// �ܽ���
        /// 2010��4��13
        /// </summary>
        /// <param name="OwnerUserGuid">�û���UserGuid</param>
        /// <param name="JobList">�û���Ӧ��ְλ�б�</param> 
        /// <param name="Rows">��Ҫȡ������</param>
        /// <param name="ClientIdentifier">��Ӧ������</param>
        /// <returns>DataView</returns>
        public DataView GetNewsWaitHandleTypes(string OwnerUserGuid, string JobList, int Rows, string ClientIdentifier, string ClientTag, Boolean IfShowRead)
        {
            //���Դ�������
            Boolean IsOracle = DatabaseOperate.IsOracle("Messages_ConnectionString");
            string CanShowInType = " CanShowInWaitHandle ";

            string str_Sql = "";
            str_Sql = "select handletype,count(*) cnt";

            str_Sql += " from Messages_Center where SendMode=4 and  DoneDate is null and IsShow = 1 and IsDel= 0  and IsNoHandle=0 ";

            if (ClientIdentifier != "!" && ClientIdentifier != "")
            {
                ClientIdentifier = ClientIdentifier.TrimEnd(';');
                ClientIdentifier = SQLOperate.ReplaceSql(ClientIdentifier);
                if (ClientIdentifier.StartsWith("!"))
                {
                    ClientIdentifier = ClientIdentifier.Substring(1);
                    if (ClientIdentifier.IndexOf(";") > 0)
                        str_Sql += " and ClientIdentifier not in ('" + ClientIdentifier.Replace(";", "','") + "')  ";
                    else
                        str_Sql += " and ClientIdentifier <> '" + ClientIdentifier + "' ";
                }
                else
                {
                    if (ClientIdentifier.IndexOf(";") > 0)
                        str_Sql += " and ClientIdentifier  in ('" + ClientIdentifier.Replace(";", "','") + "')  ";
                    else
                        str_Sql += " and ClientIdentifier = '" + ClientIdentifier + "' ";
                }
            }
            if (ClientTag != null && ClientTag != "")
                str_Sql += " and ClientTag='" + SQLOperate.ReplaceSql(ClientTag) + "' ";

            str_Sql += " and ( ";
            str_Sql += " ( " + this.GetSQLForCommissionSet(OwnerUserGuid, CanShowInType) + " ) ";
            //if (new Epoint.Frame.Bizlogic.Commission.DB_Frame_CommissionSet().SelectCommissionByUserGuid(OwnerUserGuid).Count > 0)
            //{
            //    string nowTime = Epoint.Frame.Bizlogic.common.GetCurrentDate();
            //    string strWhere = "";
            //    if (IsOracle)
            //        strWhere += " and (CommissionFromDate is null or CommissionFromDate <=TO_DATE('" + nowTime + " 23:59:59','YYYY-MM-DD HH24:MI:SS')) and (CommissionToDate is null or  CommissionToDate>=TO_DATE('" + nowTime + "','YYYY-MM-DD HH24:MI:SS'))";
            //    else
            //        strWhere += " and (CommissionFromDate is null or CommissionFromDate <='" + nowTime + " 23:59:59') and (CommissionToDate is null or  CommissionToDate>='" + nowTime + "')";

            //    str_Sql += " ( TargetUser = '" + OwnerUserGuid + "' ) or ( TargetUser in ( SELECT  LeadUserGuid FROM Frame_CommissionSet WHERE  CommissionUserGuid='" + OwnerUserGuid + "' and " + CanShowInType + " = 1 " + strWhere + " ) )  ";
            //}
            //else
            //    str_Sql += " ( TargetUser = '" + OwnerUserGuid + "' ) ";

            //�ж�JobList�Ƿ�Ϊ�գ������Ϊ�գ�˵��������ְλ����
            if (JobList != "")
                str_Sql += " or ( JobGuid in ( SELECT  JobGuid FROM Frame_Job WHERE  BelongUserGuid='" + OwnerUserGuid + "')) ";
            str_Sql += " ) ";

            //if (!IfShowRead)
            //    str_Sql += "and MessageType = '����' ";
            //else
            //    str_Sql += "and ( MessageType = '����' or MessageType = '�Ķ�' ) ";

            str_Sql += " group by handletype";

            if (IsOracle)
                str_Sql = SQLOperate.Generate_Top_Select_Oracle(str_Sql, Rows);

            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));

            DbCommand cmd = db.GetSqlStringCommand(str_Sql);
            DataView allTypes = db.ExecuteDataView(cmd);


            DataTable dt = new DataTable();
            dt.Columns.Add("handletype");
            dt.Columns.Add("cnt");

            int otherNum = 0;

            //������
            foreach (DataRowView drv in this.SelectHandleTypes(OwnerUserGuid, false))
            {
                DataRow dr = null;
                foreach (DataRow tmp in allTypes.Table.Rows)
                {
                    if (tmp["handletype"].ToString() == drv["handletypeName"].ToString())
                    {
                        dr = tmp;
                        break;
                    }
                }
                if (dr == null)
                    continue;

                DataRow newrow = dt.NewRow();
                newrow["handletype"] = drv["handletypeName"];
                newrow["cnt"] = dr["cnt"];
                dt.Rows.Add(newrow);
                allTypes.Table.Rows.Remove(dr);
            }
            //�ж��Ƿ�������
            foreach (DataRow tmp in allTypes.Table.Rows)
                otherNum += int.Parse(tmp["cnt"].ToString());
            if (otherNum > 0 && dt.Rows.Count > 0)//��û�з���ʱ��Ҳ����Ҫ�����������
            {
                DataRow newrow = dt.NewRow();
                newrow["handletype"] = "����";
                newrow["cnt"] = otherNum;
                dt.Rows.Add(newrow);
            }
            return dt.DefaultView;
        }

        /// <summary>
        /// ����HandleTypeȡ��δ����Ĵ�������
        /// �ܽ���
        /// 2010��4��13
        /// </summary>
        /// <param name="OwnerUserGuid">�û���UserGuid</param>
        /// <param name="JobList">�û���Ӧ��ְλ�б�</param> 
        /// <param name="Rows">��Ҫȡ������</param>
        /// <param name="ClientIdentifier">��Ӧ������</param>
        /// <returns>DataView</returns>
        public DataView GetNewsWaitByHandleType(string HandleType, string OwnerUserGuid, string JobList, int Rows, string ClientIdentifier, string ClientTag, Boolean IfShowRead)
        {
            Boolean IsOracle = DatabaseOperate.IsOracle("Messages_ConnectionString");
            string CanShowInType = " CanShowInWaitHandle ";
            if (Rows <= 0)
                Rows = 8;

            string str_Sql = "";
            if (IsOracle)
                str_Sql = "select                             ";
            else
                str_Sql = "select top " + Rows.ToString() + " ";

            str_Sql += " Title ,MessageItemGuid,MessageType,FromDispName,GenerateDate,BeiZhu,HandleUrl,OverTimePoint,EarlyWarningPoint from Messages_Center where SendMode=4 and  DoneDate is null and IsShow = 1 and IsDel= 0  and IsNoHandle=0 ";

            if (ClientIdentifier != "!" && ClientIdentifier != "")
            {
                ClientIdentifier = ClientIdentifier.TrimEnd(';');
                ClientIdentifier = SQLOperate.ReplaceSql(ClientIdentifier);
                if (ClientIdentifier.StartsWith("!"))
                {
                    ClientIdentifier = ClientIdentifier.Substring(1);
                    if (ClientIdentifier.IndexOf(";") > 0)
                        str_Sql += " and ClientIdentifier not in ('" + ClientIdentifier.Replace(";", "','") + "')  ";
                    else
                        str_Sql += " and ClientIdentifier <> '" + ClientIdentifier + "' ";
                }
                else
                {
                    if (ClientIdentifier.IndexOf(";") > 0)
                        str_Sql += " and ClientIdentifier  in ('" + ClientIdentifier.Replace(";", "','") + "')  ";
                    else
                        str_Sql += " and ClientIdentifier = '" + ClientIdentifier + "' ";
                }
            }
            if (ClientTag != null && ClientTag != "")
                str_Sql += " and ClientTag='" + SQLOperate.ReplaceSql(ClientTag) + "' ";

            str_Sql += " and ( ";
            str_Sql += " ( " + this.GetSQLForCommissionSet(OwnerUserGuid, CanShowInType) + " ) ";
            //if (new Epoint.Frame.Bizlogic.Commission.DB_Frame_CommissionSet().SelectCommissionByUserGuid(OwnerUserGuid).Count > 0)
            //{
            //    string nowTime = Epoint.Frame.Bizlogic.common.GetCurrentDate();
            //    string strWhere = "";
            //    if (IsOracle)
            //        strWhere += " and (CommissionFromDate is null or CommissionFromDate <=TO_DATE('" + nowTime + " 23:59:59','YYYY-MM-DD HH24:MI:SS')) and (CommissionToDate is null or  CommissionToDate>=TO_DATE('" + nowTime + "','YYYY-MM-DD HH24:MI:SS'))";
            //    else
            //        strWhere += " and (CommissionFromDate is null or CommissionFromDate <='" + nowTime + " 23:59:59') and (CommissionToDate is null or  CommissionToDate>='" + nowTime + "')";

            //    str_Sql += " ( TargetUser = '" + OwnerUserGuid + "' ) or ( TargetUser in ( SELECT  LeadUserGuid FROM Frame_CommissionSet WHERE  CommissionUserGuid='" + OwnerUserGuid + "' and " + CanShowInType + " = 1 " + strWhere + " ) )  ";
            //}
            //else
            //    str_Sql += " ( TargetUser = '" + OwnerUserGuid + "' ) ";

            //�ж�JobList�Ƿ�Ϊ�գ������Ϊ�գ�˵��������ְλ����
            if (JobList != "")
                str_Sql += " or ( JobGuid in ( SELECT  JobGuid FROM Frame_Job WHERE  BelongUserGuid='" + OwnerUserGuid + "')) ";
            str_Sql += " ) ";

            //if (!IfShowRead)
            //    str_Sql += "and MessageType = '����' ";
            //else
            //    str_Sql += "and ( MessageType = '����' or MessageType = '�Ķ�' ) ";
            if (HandleType != "����")
                str_Sql += " and HandleType='" + HandleType + "'";
            else
                str_Sql += " and HandleType not in (select handletypename from Frame_WaitHandletypesUser where userguid='" + OwnerUserGuid + "' and isshow='1')";

            str_Sql += " order by Row_ID desc ";

            if (IsOracle)
                str_Sql = SQLOperate.Generate_Top_Select_Oracle(str_Sql, Rows);

            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));

            DbCommand cmd = db.GetSqlStringCommand(str_Sql);
            return db.ExecuteDataView(cmd);
        }

        #region ��������������
        public DataView SelectHandleTypes()
        {
            return DB.ExecuteDataView("select * from Frame_WaitHandletypes order by ordernumber desc");
        }

        public DataView SelectHandleTypes(string UserGuid, bool IsAll)
        {
            if (IsAll)
                return DB.ExecuteDataView("select * from Frame_WaitHandletypesUser where UserGuid='" + UserGuid + "' order by ordernumber desc");
            else
                return DB.ExecuteDataView("select * from Frame_WaitHandletypesUser where UserGuid='" + UserGuid + "' and isshow='1' order by ordernumber desc");
        }

        /// <summary>
        /// �ж������Ƿ����
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public bool IsHandleTypeExixt(string typeName)
        {
            return DB.ExecuteToInt("select count(*) from Frame_WaitHandletypes where handletypeName='" + typeName + "'") > 0;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="orderNum"></param>
        public void AddHanleType(string typeName, int orderNum)
        {
            DB.ExecuteNonQuery("insert into Frame_WaitHandletypes(typeguid,handletypename,ordernumber,adddate) " +
                "values('" + Guid.NewGuid().ToString() + "','" + typeName + "'," + orderNum + ",getdate())");
        }

        /// <summary>
        /// ɾ�����
        /// </summary>
        /// <param name="Typeguid"></param>
        public void DelHandleType(string Typeguid)
        {
            DB.ExecuteNonQuery("delete from Frame_WaitHandletypes where typeguid='" + Typeguid + "'");
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="orderNum"></param>
        public void UpdateHandleType(string typeName, int orderNum, string TypeGuid)
        {
            DB.ExecuteNonQuery("update Frame_WaitHandletypes set handletypename='" + typeName + "'," +
                "ordernumber='" + orderNum + "' where typeguid='" + TypeGuid + "'");
        }

        public void UpdateHandleType(int orderNum, string isShow, string TypeGuid)
        {
            DB.ExecuteNonQuery("update Frame_WaitHandletypesUser set isshow='" + isShow + "'," +
                "ordernumber='" + orderNum + "' where typeguid='" + TypeGuid + "'");
        }

        /// <summary>
        /// ͬ�����
        /// </summary>
        public void SyncHandleType()
        {
            string sql = "insert into Frame_WaitHandletypesUser " +
                " select lower(newid()) guid, handletypename,typeguid,Frame_WaitHandleTypes.ordernumber,1 isshow,frame_user.userguid " +
                "  from Frame_WaitHandletypes,frame_user " +
                "where not exists(select * from Frame_WaitHandleTypesUser where userguid=frame_user.userguid and parentguid=Frame_WaitHandleTypes.typeguid)";
            DB.ExecuteNonQuery(sql);

            sql = "select * from Frame_WaitHandletypesUser where parentguid not in (select typeguid from Frame_WaitHandletypes)";
            DB.ExecuteNonQuery(sql);
        }
        #endregion

        /// <summary>
        /// ȡ��δ����Ĵ�������
        /// ֻȡ����ģ������Ĳ���ʾ
        /// �ް���
        /// 2007��10��13
        /// 
        /// 20080919��������Ϣ���ĵĹ���
        /// </summary>
        /// <param name="OwnerUserGuid">�û���UserGuid</param>
        /// <param name="JobList">�û���Ӧ��ְλ�б�</param> 
        /// <param name="Rows">��Ҫȡ������</param>
        /// <param name="ClientIdentifier">��Ӧ������</param>
        /// <returns>DataView</returns>
        public DataView GetNewsWaitHandleTop(string OwnerUserGuid, string JobList, int Rows, string ClientIdentifier, string ClientTag, Boolean IfShowRead, string PType)
        {
            Boolean IsOracle = DatabaseOperate.IsOracle("Messages_ConnectionString");
            string CanShowInType = " CanShowInWaitHandle ";
            if (Rows <= 0)
                Rows = 8;

            string str_Sql = "";
            if (IsOracle)
                str_Sql = "select                             ";
            else
                str_Sql = "select top " + Rows.ToString() + " ";

            str_Sql += " Title ,MessageItemGuid,MessageType,FromUser,FromDispName,GenerateDate,BeiZhu,HandleUrl,OverTimePoint,EarlyWarningPoint, ArchiveNo from Messages_Center where SendMode=4 and  DoneDate is null and IsShow = 1 and IsDel= 0  and IsNoHandle=0 ";

            if (ClientIdentifier != "!" && ClientIdentifier != "")
            {
                ClientIdentifier = ClientIdentifier.TrimEnd(';');
                ClientIdentifier = SQLOperate.ReplaceSql(ClientIdentifier);
                if (ClientIdentifier.StartsWith("!"))
                {
                    ClientIdentifier = ClientIdentifier.Substring(1);
                    if (ClientIdentifier.IndexOf(";") > 0)
                        str_Sql += " and ClientIdentifier not in ('" + ClientIdentifier.Replace(";", "','") + "')  ";
                    else
                        str_Sql += " and ClientIdentifier <> '" + ClientIdentifier + "' ";
                }
                else
                {
                    if (ClientIdentifier.IndexOf(";") > 0)
                        str_Sql += " and ClientIdentifier  in ('" + ClientIdentifier.Replace(";", "','") + "')  ";
                    else
                        str_Sql += " and ClientIdentifier = '" + ClientIdentifier + "' ";
                }
            }
            if (ClientTag != null && ClientTag != "")
                str_Sql += " and ClientTag='" + SQLOperate.ReplaceSql(ClientTag) + "' ";

            str_Sql += " and ( ";

            str_Sql += " ( " + this.GetSQLForCommissionSet(OwnerUserGuid, CanShowInType) + " ) ";


            //�ж�JobList�Ƿ�Ϊ�գ������Ϊ�գ�˵��������ְλ����
            if (JobList != "")
                str_Sql += " or ( JobGuid in ( SELECT  JobGuid FROM Frame_Job WHERE  BelongUserGuid='" + OwnerUserGuid + "')) ";
            str_Sql += " ) ";

            if (!IfShowRead)
                str_Sql += "and MessageType = '����' ";
            else
                str_Sql += "and ( MessageType = '����' or MessageType = '�Ķ�' ) ";
            //�˴�Ҫ�������
            //if (PType == "1")//Ĭ�ϵ�Ҫ��ʾOA��һЩ����
            //{
            //    //sb.Append(" (and ProcessGuid='' or ");
            //    str_Sql += " and ( ProcessGuid='' or ProcessGuid in (" + GetProcessGuidByType(PType) + ") ) ";
            //}
            //else
            //{ str_Sql += " and ( ProcessGuid='qt' or ProcessGuid in (" + GetProcessGuidByType(PType) + ") ) "; }
            str_Sql += GetProcessGuidByType(PType);
            
            str_Sql += " order by Row_ID desc ";

            if (IsOracle)
                str_Sql = SQLOperate.Generate_Top_Select_Oracle(str_Sql, Rows);

            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));

            DbCommand cmd = db.GetSqlStringCommand(str_Sql);
            return db.ExecuteDataView(cmd);
        }
        private string GetProcessGuidByType(string PType)
        {
            StringBuilder sb = new StringBuilder();

            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = "select ProcessList from ZLJD_ProcessType where Row_ID='" + PType + "'";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            DataView dv = db.ExecuteDataView(cmd);
            if (dv.Count > 0)
            {
                string[] str = dv[0][0].ToString().Split(',');
                for (int m = 0; m < str.Length; m++)
                {
                    //if (str[m].ToString() != "")
                    //{
                        sb.Append("'" + str[m] + "'");
                        if (m != str.Length - 1)
                        {
                            sb.Append(",");
                        }
                    //}
                }
            }
            else
            {
                sb.Append("''");
            }

            //return sb.ToString();

            //�˴�Ҫ�������
            if (PType == "1")//Ĭ�ϵ�Ҫ��ʾOA��һЩ���ݣ�������������
            {
                //sb.Append(" (and ProcessGuid='' or ");
                return " and ( ProcessGuid is null or ProcessGuid in (" + sb.ToString() + ") ) ";
            }
            else if (PType == "2")//Ҫ��ʾ����
            { return " and ( ProcessGuid='rwd' or ProcessGuid in (" + sb.ToString() + ") ) "; }
            else if (PType == "3")//����¼�����ġ�ͣ��
            { return " and ( ProcessGuid in (" + sb.ToString() + ") ) "; }
            else if (PType == "4")//Ҫ��ʾ����д��Ĵ���
            { return " and ( ProcessGuid='qt' or ProcessGuid in (" + sb.ToString() + ") ) "; }
            else
                return " and ( ProcessGuid in (" + sb.ToString() + ") ) ";
        }


        /// <summary>
        /// ȡ��δ����Ĵ�����������
        /// �ް���
        /// </summary>
        /// <param name="OwnerUserGuid">�û���UserGuid</param>
        /// <param name="JobList">�û���Ӧ��ְλ�б�</param> 
        /// <returns>int</returns>
        public int GetNoHandleMessageCount(string OwnerUserGuid, string JobList)
        {
            string str_Sql = "select count(*) from Messages_Center where   SendMode=4 and  DoneDate is null and IsShow = 1 ";

            if (JobList != "")
                str_Sql += " and ( TargetUser = '" + OwnerUserGuid + "' or  CHARINDEX(JobGuid,'" + JobList + "')<>0 ) ";
            else
                str_Sql += " and ( TargetUser = '" + OwnerUserGuid + "' ) ";

            string str_Oracle = "select  count(*)  from Messages_Center where   SendMode=4 and  DoneDate is null and IsShow = 1 ";
            if (JobList != "")
                str_Oracle += " and ( TargetUser = '" + OwnerUserGuid + "' or  INSTR('" + JobList + "',JobGuid,1,1)>0 )";
            else
                str_Oracle += " and ( TargetUser = '" + OwnerUserGuid + "' ) ";

            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                str_Sql :
                str_Oracle
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return Convert.ToInt32(db.ExecuteScalar(cmd));
        }

        /// <summary>
        /// ȡ����Ϣ�����е���Ϣ�б�
        /// </summary>
        /// <param name="TargetUser">��Ϣ������</param>
        /// <param name="JobList">�û���Ӧ��ְλ�б�</param>
        /// <param name="IsDel">��Ϣ״̬</param>
        /// <param name="DateFromTo">��Ϣ��ʼʱ��</param>
        /// <param name="DateTo">��Ϣ����ʱ��</param>
        /// <param name="txtTitle">����</param>
        /// <param name="HandleType">��Ϣ���</param>
        /// <param name="TableName">����</param>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPageIndex"></param>
        /// <param name="OrderBy"></param>
        /// <param name="TotalNum"></param>
        /// <returns></returns>
        public DataView WaitHandle_PageView(string TargetUser, string JobList, int IsDel, string DateFromTo, string DateTo, string txtTitle, string MessageType, string HandleType, string TableName, string CurrentStepName, string ClientIdentifier, int PageSize, int CurrentPageIndex, string OrderBy, out int TotalNum)
        {
            return WaitHandle_PageView(TargetUser, JobList, IsDel, DateFromTo, DateTo, txtTitle, MessageType, HandleType, TableName, CurrentStepName, ClientIdentifier, PageSize, CurrentPageIndex, OrderBy, "", 3, out TotalNum, "");
        }

        /// <summary>
        /// ȡ����Ϣ�����е���Ϣ�б�
        /// </summary>
        /// <param name="TargetUser">��Ϣ������</param>
        /// <param name="JobList">�û���Ӧ��ְλ�б�</param>
        /// <param name="IsDel">��Ϣ״̬</param>
        /// <param name="DateFromTo">��Ϣ��ʼʱ��</param>
        /// <param name="DateTo">��Ϣ����ʱ��</param>
        /// <param name="txtTitle">����</param>
        /// <param name="HandleType">��Ϣ���</param>
        /// <param name="TableName">����</param>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPageIndex"></param>
        /// <param name="OrderBy"></param>
        /// <param name="TotalNum"></param>
        /// <param name="ShowType">��ȡ�������˻��Ѱ�����ģ��.��ʾ���͡�1������ʾ���죬ֻ��ʾ���˵Ĵ������ˣ�2��ֻ��ʾ����ģ�����ʾ���˵Ĵ������ˣ�3�����˺ʹ�����Ա�Ķ���ʾ</param>
        /// <returns></returns>
        public DataView WaitHandle_PageView(string TargetUser, string JobList, int IsDel, string DateFromTo, string DateTo, string txtTitle, string MessageType, string HandleType, string TableName, string CurrentStepName, string ClientIdentifier, int PageSize, int CurrentPageIndex, string OrderBy, string ArchiveNo, int ShowType, out int TotalNum, string PType)
        {
            if (TargetUser == "")
                TargetUser = "nouserGuid";

            Boolean IsOracle = DatabaseOperate.IsOracle("Messages_ConnectionString");

            string sql = " where  SendMode=4 and IsShow = 1 and IsDel= " + IsDel + "  ";
            if (IsDel == 0)
            {
                if (TableName.ToLower() == "Messages_Center".ToLower())
                    sql += " and IsNoHandle=0 and DoneDate is null ";
                else if (IsDel == 0)
                    sql += " and DoneDate is not null ";
            }
            //�ж�JobList�Ƿ�Ϊ�գ������Ϊ�գ�˵��������ְλ����

            string CanShowInType = "";
            if (TableName.ToLower() == "Messages_Center".ToLower())
                CanShowInType = " CanShowInWaitHandle ";
            else
                CanShowInType = " CanShowInWaitHandleDone ";

            String PartitionTag = "";
            if (TargetUser.Length > 0)
                PartitionTag = TargetUser.Substring(0, 1);
            //PartitionTag='" + PartitionTag + "'  and 
            sql += " and ( ";
            if (ShowType == 1)
                sql += " ( TargetUser = '" + TargetUser + "' )  ";
            else if (ShowType == 2)
            {

                sql += " ( " + this.GetSQLForCommissionSet(TargetUser, CanShowInType, false) + " ) ";
            }
            else if (ShowType == 3)
            {
                sql += " ( " + this.GetSQLForCommissionSet(TargetUser, CanShowInType) + " ) ";

            }
            else
                sql += " ( 1=2 )  ";

            if (JobList != "")
                sql += " or ( JobGuid in ( SELECT  JobGuid FROM Frame_Job WHERE  BelongUserGuid='" + TargetUser + "')) ";

            sql += " ) ";

            if (DateFromTo != "")
            {
                if (IsOracle)
                    sql += " and GenerateDate >= TO_DATE('" + DateFromTo + "','YYYY-MM-DD HH24:MI:SS') ";
                else
                    sql += " and GenerateDate >= '" + DateFromTo + "' ";
            }

            if (DateTo != "")
            {
                if (IsOracle)
                    sql += " and GenerateDate <= TO_DATE('" + DateTo + " 23:59:59','YYYY-MM-DD HH24:MI:SS') ";
                else
                    sql += " and GenerateDate <= '" + DateTo + " 23:59:59' ";
            }

            if (txtTitle != "")
                sql += "and Title like '%" + SQLOperate.ReplaceSql(txtTitle) + "%'";

            if (HandleType != "")
                sql += "and HandleType = '" + SQLOperate.ReplaceSql(HandleType) + "'";

            if (CurrentStepName != "")
                sql += "and BeiZhu = '" + SQLOperate.ReplaceSql(CurrentStepName) + "'";

            if (ClientIdentifier != "!" && ClientIdentifier != "")
            {
                ClientIdentifier = ClientIdentifier.TrimEnd(';');
                ClientIdentifier = SQLOperate.ReplaceSql(ClientIdentifier);
                if (ClientIdentifier.StartsWith("!"))
                {
                    ClientIdentifier = ClientIdentifier.Substring(1);
                    if (ClientIdentifier.IndexOf(":") > 0)
                        sql += " and ClientIdentifier not in ('" + ClientIdentifier.Replace(":", "','") + "')  ";
                    else
                        sql += " and ClientIdentifier <> '" + ClientIdentifier + "' ";
                }
                else
                {
                    if (ClientIdentifier.IndexOf(":") > 0)
                        sql += " and ClientIdentifier  in ('" + ClientIdentifier.Replace(":", "','") + "')  ";
                    else
                        sql += " and ClientIdentifier = '" + ClientIdentifier + "' ";
                }
            }

            if (ArchiveNo != "")
                sql += "and ArchiveNo like '%" + SQLOperate.ReplaceSql(ArchiveNo) + "%'";

            if (MessageType != "")
            {
                if (MessageType == "����")
                    sql += "and  MessageType = '����' ";
                else
                    sql += "and MessageType = '" + SQLOperate.ReplaceSql(MessageType) + "' ";
            }

            //�˴�Ҫ�������
            //if (PType == "1")//Ĭ�ϵ�Ҫ��ʾOA��һЩ����
            //{
            //    //sb.Append(" (and ProcessGuid='' or ");
                sql += " and ( PTYPE='" + PType + "') ";
            //}
            //else
            //{ sql += " and ( ProcessGuid='qt' or ProcessGuid in (" + GetProcessGuidByType(PType) + ") ) "; }
            //if (PType != "4")
            //{
            //    sql += GetProcessGuidByType(PType);
            //}
            if (OrderBy == "")
                OrderBy = " order by GenerateDate desc  ";

            DBOperate DBOper = new DBOperate();
            DBOper.ConnectionStringName = DatabaseOperate.GetConnectionStringName("Messages_ConnectionString");
            DataView dv = DBOper.GetData_Page(
                " * ",
                 PageSize,
                 CurrentPageIndex,
                TableName,
                "Row_ID",
                sql,
               OrderBy,
                out TotalNum
                ).DefaultView;

            return dv;
        }

        /// <summary>
        /// ȡ����Ϣ�����е���Ϣ�б�
        /// </summary>
        /// <param name="TargetUser">��Ϣ������</param>
        /// <param name="JobList">�û���Ӧ��ְλ�б�</param>
        /// <param name="MessageType">��Ϣ����</param>
        /// <returns>DataView</returns>
        public DataView WaitHandle_GetMessageView(string TargetUser, string JobList, string MessageType, string ClientIdentifier, string PType)
        {
            return this.WaitHandle_GetMessageView("*", -1, TargetUser, JobList, MessageType, ClientIdentifier, PType);
        }


        /// <summary>
        /// ȡ����Ϣ�����е���Ϣ�б�
        /// �ް���
        /// </summary>
        /// <param name="strCols">���صı���</param>
        /// <param name="NoNeedRemind">�Ƿ���Ҫ���ѵ���Ϣ��-1��������Ϣ��0����Ҫ���ѵ���Ϣ��1������Ҫ���ѵ���Ϣ</param>
        /// <param name="TargetUser">��Ϣ������</param>
        /// <param name="JobList">�û���Ӧ��ְλ�б�</param>
        /// <param name="MessageType">��Ϣ����</param>
        /// <param name="ClientIdentifier">��Ϣ�������ʾ������м���; �ֿ��������������ǰ����!</param>
        /// <returns>DataView</returns>
        public DataView WaitHandle_GetMessageView(string strCols, int NoNeedRemind, string TargetUser, string JobList, string MessageType, string ClientIdentifier, string PType)
        {
            if (TargetUser == "")
                TargetUser = "nouserGuid";

            Boolean IsOracle = DatabaseOperate.IsOracle("Messages_ConnectionString");
            if (strCols.Trim() == "")
                strCols = "*";
            string sql = " select " + strCols + " from Messages_Center  where  SendMode=4  and  DoneDate is null and IsShow = 1 and IsDel= 0  and IsNoHandle=0 ";

            if (NoNeedRemind != -1)
                sql += " and NoNeedRemind =" + NoNeedRemind;

            if (ClientIdentifier != "!" && ClientIdentifier != "")
            {
                ClientIdentifier = ClientIdentifier.TrimEnd(';');
                ClientIdentifier = SQLOperate.ReplaceSql(ClientIdentifier);
                if (ClientIdentifier.StartsWith("!"))
                {
                    ClientIdentifier = ClientIdentifier.Substring(1);
                    if (ClientIdentifier.IndexOf(";") > 0)
                        sql += " and ClientIdentifier not in ('" + ClientIdentifier.Replace(";", "','") + "')  ";
                    else
                        sql += " and ClientIdentifier <> '" + ClientIdentifier + "' ";
                }
                else
                {
                    if (ClientIdentifier.IndexOf(";") > 0)
                        sql += " and ClientIdentifier  in ('" + ClientIdentifier.Replace(";", "','") + "')  ";
                    else
                        sql += " and ClientIdentifier = '" + ClientIdentifier + "' ";
                }
            }
            String PartitionTag = "";
            if (TargetUser.Length > 0)
                PartitionTag = TargetUser.Substring(0, 1);
            //PartitionTag='" + PartitionTag + "'  and  
            string CanShowInType = " CanShowInWaitHandle ";
            sql += " and ( ";
            sql += " ( " + this.GetSQLForCommissionSet(TargetUser, CanShowInType) + " ) ";

            //if (new Epoint.Frame.Bizlogic.Commission.DB_Frame_CommissionSet().SelectCommissionByUserGuid(TargetUser).Count > 0)
            //{
            //    string nowTime = Epoint.Frame.Bizlogic.common.GetCurrentDate();
            //    string strWhere = "";
            //    if (IsOracle)
            //        strWhere += " and (CommissionFromDate is null or CommissionFromDate <=TO_DATE('" + nowTime + " 23:59:59','YYYY-MM-DD HH24:MI:SS')) and (CommissionToDate is null or  CommissionToDate>=TO_DATE('" + nowTime + "','YYYY-MM-DD HH24:MI:SS'))";
            //    else
            //        strWhere += " and (CommissionFromDate is null or CommissionFromDate <='" + nowTime + " 23:59:59') and (CommissionToDate is null or  CommissionToDate>='" + nowTime + "')";

            //    sql += " ( TargetUser = '" + TargetUser + "' ) or ( TargetUser in ( SELECT  LeadUserGuid FROM Frame_CommissionSet WHERE  CommissionUserGuid='" + TargetUser + "' and " + CanShowInType + " = 1 " + strWhere + " ) )  ";
            //}
            //else
            //    sql += " (  TargetUser = '" + TargetUser + "' ) ";

            //�ж�JobList�Ƿ�Ϊ�գ������Ϊ�գ�˵��������ְλ����
            if (JobList != "")
                sql += " or ( JobGuid in ( SELECT  JobGuid FROM Frame_Job WHERE  BelongUserGuid='" + TargetUser + "')) ";
            sql += " ) ";

            MessageType = MessageType.Trim(';');
            if (MessageType.IndexOf(";") > 0)
                sql += " and  MessageType in ('" + MessageType.Replace(";", "','") + "') ";
            else
            {
                if (MessageType == "����" || MessageType == "")
                    sql += " and MessageType = '����' ";
                else
                    sql += "and MessageType = '" + SQLOperate.ReplaceSql(MessageType) + "' ";
            }

            //�˴�Ҫ�������
            if (PType != "")//Ĭ�ϵ�Ҫ��ʾOA��һЩ����
            {
                //sb.Append(" (and ProcessGuid='' or ");
                sql += " and ( PType='" + PType+ "') ";
            }
            //else
            //{ sql += " and ( ProcessGuid='qt' or ProcessGuid in (" + GetProcessGuidByType(PType) + ") ) "; }
            //sql += GetProcessGuidByType(PType);

            sql += " order by Row_ID desc ";


            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            DbCommand cmd = db.GetSqlStringCommand(sql);
            return db.ExecuteDataView(cmd);
        }


        /// <summary>
        /// ȡ����Ϣ�����е���Ϣ�б�
        /// </summary>
        /// <param name="TargetUser">��Ϣ������</param>
        /// <param name="JobList">�û���Ӧ��ְλ�б�</param>
        /// <param name="MessageType">��Ϣ����</param>
        /// <returns>int</returns>
        public int WaitHandle_GetMessageCount(string TargetUser, string JobList, string MessageType, string ClientIdentifier, string PType)
        {
            return this.WaitHandle_GetMessageView(TargetUser, JobList, MessageType, ClientIdentifier, PType).Count;
        }

        /// <summary>
        /// ȡ����Ϣ�����е���Ϣ�б�
        /// </summary>
        /// <param name="TargetUser">��Ϣ������</param>
        /// <param name="JobList">�û���Ӧ��ְλ�б�</param>
        /// <param name="MessageType">��Ϣ����</param>
        /// <returns>int</returns>
        public int WaitHandle_GetMessageCount(string TargetUser, string JobList, string MessageType, string PType)
        {
            return WaitHandle_GetMessageCount(TargetUser, JobList, MessageType, "", PType);
        }

        /// <summary>
        /// �����Ϣ����(�ֻ���������)
        /// ��д���ڣ�2007-9-3
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid</param>
        /// <param name="Content">��Ϣ���ݣ�������ֻ����ţ��洢��������</param>
        /// <param name="GenerateDate">��Ϣ����ʱ��</param>
        /// <param name="IsSchedule">�Ƿ�ʱ���͡�0�����������ͣ�1���ǣ���ʱ����</param>
        /// <param name="ScheduleSendDate">�ƻ�����ʱ�䡣�����������͵���Ϣ�����ֶ�û������</param>
        /// <param name="MessageTarget">��ϢĿ�ꡣ������ֻ����ţ���Ϊ���ܺ��룻������ʼ�����Ϊ�ʼ���ַ</param>
        /// <param name="TargetUser">��ϢĿ���û������������û���ϵͳ�е�Ψһ��ʶ��������ⲿ�û�����=����</param>
        /// <param name="TargetDispName">��ϢĿ���û�������ʾ���ơ��������û���ϵͳ�е�Ψһ��ʶ��������ⲿ�û�����=����</param>
        /// <param name="FromUser">��Ϣ������,�����û���UserGuid�����Ϊ�գ���Ϊ��ǰ�û���UserGuid</param>
        /// <param name="FromDispName">��Ϣ�����˵���ʾ���ơ����Ϊ�գ���Ϊ��ǰ�û�����ʾ����</param>
        /// <param name="FromMobile">��Ϣ��Դ�ֻ����룬���ڻظ�</param>
        /// <param name="OuGuid">�û����ڲ��ŵ�OuGuid,��Session["OUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���OUGuid</param>
        /// <param name="BaseOuGuid">�û����ڶ��������ŵ�OuGuid,��Session["BaseOUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���BaseOUGuid</param>
        public void SMS_Insert(string MessageItemGuid, string Content, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string OuGuid, string BaseOuGuid)
        {
            this.SMS_Insert(MessageItemGuid, "", Content, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, OuGuid, BaseOuGuid, false);
        }

        public void SMS_Insert(string MessageItemGuid, string Content, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string OuGuid, string BaseOuGuid, Boolean NotAddUserInfo)
        {
            this.SMS_Insert(MessageItemGuid, "", Content, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, OuGuid, BaseOuGuid, NotAddUserInfo);
        }
        /// <summary>
        /// �����Ϣ���� ͨ������ӿ���ӵĶ��� ���ڶ�������������
        /// ��д���ڣ�2007-9-3
        /// ��д�ˣ��⽨
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid</param>
        /// <param name="Content">��Ϣ���ݣ�������ֻ����ţ��洢��������</param>
        /// <param name="GenerateDate">��Ϣ����ʱ��</param>
        /// <param name="IsSchedule">�Ƿ�ʱ���͡�0�����������ͣ�1���ǣ���ʱ����</param>
        /// <param name="ScheduleSendDate">�ƻ�����ʱ�䡣�����������͵���Ϣ�����ֶ�û������</param>
        /// <param name="MessageTarget">��ϢĿ�ꡣ������ֻ����ţ���Ϊ���ܺ��룻������ʼ�����Ϊ�ʼ���ַ</param>
        /// <param name="TargetUser">��ϢĿ���û������������û���ϵͳ�е�Ψһ��ʶ��������ⲿ�û�����=����</param>
        /// <param name="TargetDispName">��ϢĿ���û�������ʾ���ơ��������û���ϵͳ�е�Ψһ��ʶ��������ⲿ�û�����=����</param>
        /// <param name="FromUser">��Ϣ������,�����û���UserGuid�����Ϊ�գ���Ϊ��ǰ�û���UserGuid</param>
        /// <param name="FromDispName">��Ϣ�����˵���ʾ���ơ����Ϊ�գ���Ϊ��ǰ�û�����ʾ����</param>
        /// <param name="FromMobile">��Ϣ��Դ�ֻ����룬���ڻظ�</param>
        /// <param name="OuGuid">�û����ڲ��ŵ�OuGuid,��Session["OUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���OUGuid</param>
        /// <param name="BaseOuGuid">�û����ڶ��������ŵ�OuGuid,��Session["BaseOUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���BaseOUGuid</param>
        public void SMS_InsertNoLimit(string MessageItemGuid, string Content, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string OuGuid, string BaseOuGuid)
        {
            this.SMS_Insert(MessageItemGuid, "nolimit", Content, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, OuGuid, BaseOuGuid, false);
        }

        /// <summary>
        /// �����Ϣ���� ͨ������ӿ���ӵĶ��� ���ڶ�������������
        /// ��д���ڣ�2007-9-3
        /// ��д�ˣ��⽨
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid</param>
        /// <param name="Content">��Ϣ���ݣ�������ֻ����ţ��洢��������</param>
        /// <param name="GenerateDate">��Ϣ����ʱ��</param>
        /// <param name="IsSchedule">�Ƿ�ʱ���͡�0�����������ͣ�1���ǣ���ʱ����</param>
        /// <param name="ScheduleSendDate">�ƻ�����ʱ�䡣�����������͵���Ϣ�����ֶ�û������</param>
        /// <param name="MessageTarget">��ϢĿ�ꡣ������ֻ����ţ���Ϊ���ܺ��룻������ʼ�����Ϊ�ʼ���ַ</param>
        /// <param name="TargetUser">��ϢĿ���û������������û���ϵͳ�е�Ψһ��ʶ��������ⲿ�û�����=����</param>
        /// <param name="TargetDispName">��ϢĿ���û�������ʾ���ơ��������û���ϵͳ�е�Ψһ��ʶ��������ⲿ�û�����=����</param>
        /// <param name="FromUser">��Ϣ������,�����û���UserGuid�����Ϊ�գ���Ϊ��ǰ�û���UserGuid</param>
        /// <param name="FromDispName">��Ϣ�����˵���ʾ���ơ����Ϊ�գ���Ϊ��ǰ�û�����ʾ����</param>
        /// <param name="FromMobile">��Ϣ��Դ�ֻ����룬���ڻظ�</param>
        /// <param name="OuGuid">�û����ڲ��ŵ�OuGuid,��Session["OUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���OUGuid</param>
        /// <param name="BaseOuGuid">�û����ڶ��������ŵ�OuGuid,��Session["BaseOUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���BaseOUGuid</param>
        public void SMS_InsertNoLimit(string MessageItemGuid, string Content, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string OuGuid, string BaseOuGuid, Boolean NotAddUserInfo)
        {
            this.SMS_Insert(MessageItemGuid, "nolimit", Content, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, OuGuid, BaseOuGuid, NotAddUserInfo);
        }

        /// <summary>
        /// ����MessageType�� �����������Ǹ�ģ�鷢���Ķ���
        /// </summary>
        public void SMS_InsertHasType(string MessageItemGuid, string MessageType, string Content, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string OuGuid, string BaseOuGuid, Boolean NotAddUserInfo)
        {
            this.SMS_Insert(MessageItemGuid, MessageType, Content, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, OuGuid, BaseOuGuid, NotAddUserInfo);
        }


        /// <summary>
        /// �����Ϣ����(�ֻ���������)
        /// ��д���ڣ�2007-9-3
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid</param>
        /// <param name="Content">��Ϣ���ݣ�������ֻ����ţ��洢��������</param>
        /// <param name="GenerateDate">��Ϣ����ʱ��</param>
        /// <param name="IsSchedule">�Ƿ�ʱ���͡�0�����������ͣ�1���ǣ���ʱ����</param>
        /// <param name="ScheduleSendDate">�ƻ�����ʱ�䡣�����������͵���Ϣ�����ֶ�û������</param>
        /// <param name="MessageTarget">��ϢĿ�ꡣ������ֻ����ţ���Ϊ���ܺ��룻������ʼ�����Ϊ�ʼ���ַ</param>
        /// <param name="TargetUser">��ϢĿ���û������������û���ϵͳ�е�Ψһ��ʶ��������ⲿ�û�����=����</param>
        /// <param name="TargetDispName">��ϢĿ���û�������ʾ���ơ��������û���ϵͳ�е�Ψһ��ʶ��������ⲿ�û�����=����</param>
        /// <param name="FromUser">��Ϣ������,�����û���UserGuid�����Ϊ�գ���Ϊ��ǰ�û���UserGuid</param>
        /// <param name="FromDispName">��Ϣ�����˵���ʾ���ơ����Ϊ�գ���Ϊ��ǰ�û�����ʾ����</param>
        /// <param name="FromMobile">��Ϣ��Դ�ֻ����룬���ڻظ�</param>
        /// <param name="OuGuid">�û����ڲ��ŵ�OuGuid,��Session["OUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���OUGuid</param>
        /// <param name="BaseOuGuid">�û����ڶ��������ŵ�OuGuid,��Session["BaseOUGuid"]�����Ϊ�գ���Ϊ��ǰ�û���BaseOUGuid</param>
        /// <param name="NotAddUserInfo">�ڷ��Ͷ��ŵ�ʱ���Ƿ���Ҫ�ڶ������ݺ�������û���Ϣ���������Ҫ=true������=false</param>
        private void SMS_Insert(string MessageItemGuid, string MessageType, string Content, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string OuGuid, string BaseOuGuid, Boolean NotAddUserInfo)
        {
            if (FromUser == null || FromUser == "")
            {
                try
                {
                    FromUser = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["UserGuid"]);
                }
                catch { }
            }

            if (FromDispName == null || FromDispName == "")
            {
                try
                {
                    FromDispName = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["DisplayName"]);
                }
                catch { }
            }

            if (OuGuid == null || OuGuid == "")
            {
                try
                {
                    OuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["OUGuid"]);
                }
                catch { }
            }

            if (BaseOuGuid == null || BaseOuGuid == "")
            {
                try
                {
                    BaseOuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["BaseOUGuid"]);
                }
                catch { }
            }
            //ȡ�ö��ŵĳ���
            int SmsLength = 0;

            try
            {
                string strSmsLength = ApplicationOperate.GetConfigValueByName("SmsLength");
                if (strSmsLength != "")
                    SmsLength = Convert.ToInt32(ApplicationOperate.GetConfigValueByName("SmsLength"));//ȡ�ö��ŵĳ���
                else
                    SmsLength = 0;
            }
            catch { SmsLength = 0; }

            if (SmsLength != 0 && NotAddUserInfo)//�ڷ��Ͷ����У�����Ҫ��Ӻ�׺�������ݳ����Զ����16���ַ�
                SmsLength += 16;

            String BeiZhu = "";//�������Ҫ�����û���Ϣ����BeiZhu=1
            if (NotAddUserInfo)
                BeiZhu = "1";
            if (SmsLength == 0 || Content.Length < SmsLength)
                Sms_AddInDB(MessageItemGuid, MessageType, Content, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, OuGuid, BaseOuGuid, BeiZhu);
            else
            {
                string strSms = "";
                while (Content.Length > 0)
                {
                    if (Content.Length > SmsLength)
                    {
                        strSms = Content.Substring(0, SmsLength);
                        Sms_AddInDB(Guid.NewGuid().ToString(), MessageType, strSms, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, OuGuid, BaseOuGuid, BeiZhu);
                        Content = Content.Substring(SmsLength);
                    }
                    else
                    {
                        Sms_AddInDB(Guid.NewGuid().ToString(), MessageType, Content, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, OuGuid, BaseOuGuid, BeiZhu);
                        Content = "";
                    }
                }
            }
        }

        /// <summary>
        /// �ֻ����ŷ��͵ľ��巽��,���뵽���ݿ��еķ���
        /// </summary>
        /// <param name="MessageItemGuid"></param>
        /// <param name="Content"></param>
        /// <param name="GenerateDate"></param>
        /// <param name="IsSchedule"></param>
        /// <param name="ScheduleSendDate"></param>
        /// <param name="MessageTarget"></param>
        /// <param name="TargetUser"></param>
        /// <param name="TargetDispName"></param>
        /// <param name="FromUser"></param>
        /// <param name="FromDispName"></param>
        /// <param name="FromMobile"></param>
        /// <param name="OuGuid"></param>
        /// <param name="BaseOuGuid"></param>
        /// <returns></returns>
        private Boolean Sms_AddInDB(string MessageItemGuid, string MessageType, string Content, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string OuGuid, string BaseOuGuid, String BeiZhu)
        {
            String PartitionTag = "";
            if (TargetUser.Length > 0)
                PartitionTag = TargetUser.Substring(0, 1);

            Boolean IsOracle = DatabaseOperate.IsOracle("Messages_ConnectionString");
            if (IsOracle)
            {
                OracleConnection myConn = new OracleConnection(DatabaseOperate.GetConnectionString("Messages_ConnectionString"));
                string strSql = "INSERT INTO Messages_Center(Row_ID,MessageItemGuid,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,OuGuid,BaseOuGuid,BeiZhu,PartitionTag) VALUES(sq_Messages_Center.nextval,:MessageItemGuid,:MessageType,:Content,:SendMode,:GenerateDate,:IsSchedule,:ScheduleSendDate,:MessageTarget,:TargetUser,:TargetDispName,:FromUser,:FromDispName,:FromMobile,:OuGuid,:BaseOuGuid,:BeiZhu,:PartitionTag)";
                OracleCommand myCommand = new OracleCommand(strSql, myConn);
                myCommand.Parameters.Add(new OracleParameter("MessageItemGuid", OracleType.NVarChar)).Value = MessageItemGuid;
                myCommand.Parameters.Add(new OracleParameter("MessageType", OracleType.NVarChar)).Value = MessageType;
                myCommand.Parameters.Add(new OracleParameter("Content", OracleType.NClob)).Value = DatabaseOperate.HandleNClobParameter(Content);
                myCommand.Parameters.Add(new OracleParameter("SendMode", OracleType.Int32)).Value = 1;
                myCommand.Parameters.Add(new OracleParameter("GenerateDate", OracleType.DateTime)).Value = GenerateDate;
                myCommand.Parameters.Add(new OracleParameter("IsSchedule", OracleType.Int32)).Value = IsSchedule;
                myCommand.Parameters.Add(new OracleParameter("ScheduleSendDate", OracleType.DateTime)).Value = ScheduleSendDate;
                myCommand.Parameters.Add(new OracleParameter("MessageTarget", OracleType.NVarChar)).Value = MessageTarget;
                myCommand.Parameters.Add(new OracleParameter("TargetUser", OracleType.NVarChar)).Value = TargetUser;
                myCommand.Parameters.Add(new OracleParameter("TargetDispName", OracleType.NVarChar)).Value = TargetDispName;
                myCommand.Parameters.Add(new OracleParameter("FromUser", OracleType.NVarChar)).Value = FromUser;
                myCommand.Parameters.Add(new OracleParameter("FromDispName", OracleType.NVarChar)).Value = FromDispName;
                myCommand.Parameters.Add(new OracleParameter("FromMobile", OracleType.NVarChar)).Value = FromMobile;
                myCommand.Parameters.Add(new OracleParameter("OuGuid", OracleType.NVarChar)).Value = OuGuid;
                myCommand.Parameters.Add(new OracleParameter("BaseOuGuid", OracleType.NVarChar)).Value = BaseOuGuid;
                myCommand.Parameters.Add(new OracleParameter("BeiZhu", OracleType.NVarChar)).Value = BeiZhu;
                myCommand.Parameters.Add(new OracleParameter("PartitionTag", OracleType.NVarChar)).Value = PartitionTag;
                myConn.Open();
                myCommand.ExecuteNonQuery();
                myConn.Close();
            }
            else
            {
                Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
                string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                    "INSERT INTO Messages_Center(MessageItemGuid,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,OuGuid,BaseOuGuid,BeiZhu,PartitionTag) VALUES(@MessageItemGuid,@MessageType,@Content,@SendMode,@GenerateDate,@IsSchedule,@ScheduleSendDate,@MessageTarget,@TargetUser,@TargetDispName,@FromUser,@FromDispName,@FromMobile,@OuGuid,@BaseOuGuid,@BeiZhu,@PartitionTag) " :
                    "INSERT INTO Messages_Center(Row_ID,MessageItemGuid,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,OuGuid,BaseOuGuid,BeiZhu,PartitionTag) VALUES(sq_Messages_Center.nextval,:MessageItemGuid,:MessageType,:Content,:SendMode,:GenerateDate,:IsSchedule,:ScheduleSendDate,:MessageTarget,:TargetUser,:TargetDispName,:FromUser,:FromDispName,:FromMobile,:OuGuid,:BaseOuGuid,:BeiZhu,:PartitionTag)"
                 );
                DbCommand cmd = db.GetSqlStringCommand(strSql);

                db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
                db.AddInParameter(cmd, "MessageType", DbType.String, MessageType);
                db.AddInParameter(cmd, "Content", DbType.String, Content);
                db.AddInParameter(cmd, "SendMode", DbType.Int32, 1);
                db.AddInParameter(cmd, "GenerateDate", DbType.DateTime, GenerateDate);
                db.AddInParameter(cmd, "IsSchedule", DbType.Int32, IsSchedule);
                db.AddInParameter(cmd, "ScheduleSendDate", DbType.DateTime, ScheduleSendDate);
                db.AddInParameter(cmd, "MessageTarget", DbType.String, MessageTarget);
                db.AddInParameter(cmd, "TargetUser", DbType.String, TargetUser);
                db.AddInParameter(cmd, "TargetDispName", DbType.String, TargetDispName);
                db.AddInParameter(cmd, "FromUser", DbType.String, FromUser);
                db.AddInParameter(cmd, "FromDispName", DbType.String, FromDispName);
                db.AddInParameter(cmd, "FromMobile", DbType.String, FromMobile);
                db.AddInParameter(cmd, "OuGuid", DbType.String, OuGuid);
                db.AddInParameter(cmd, "BaseOuGuid", DbType.String, BaseOuGuid);
                db.AddInParameter(cmd, "BeiZhu", DbType.String, BeiZhu);
                db.AddInParameter(cmd, "PartitionTag", DbType.String, PartitionTag);
                db.ExecuteNonQuery(cmd);
            }
            return true;
        }

        /// <summary>
        /// �����Ϣ������ͨ�÷���
        /// ��д���ڣ�2007-4-23
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid</param>
        /// <param name="Title">��Ϣ����</param>
        /// <param name="MessageType">��Ϣ���ݣ���ʱ���ã�����=''</param>
        /// <param name="Content">��Ϣ���ݣ�������ֻ����ţ��洢��������</param>
        /// <param name="SendMode">����ģʽ��1���ֻ����ţ�2��email��3��������4���������ˣ�5����ʱ��Ϣ</param>
        /// <param name="GenerateDate">��Ϣ����ʱ��</param>
        /// <param name="IsSchedule">�Ƿ�ʱ���͡�0�����������ͣ�1���ǣ���ʱ����</param>
        /// <param name="ScheduleSendDate">�ƻ�����ʱ�䡣�����������͵���Ϣ�����ֶ�û������</param>
        /// <param name="MessageTarget">��ϢĿ�ꡣ������ֻ����ţ���Ϊ���ܺ��룻������ʼ�����Ϊ�ʼ���ַ</param>
        /// <param name="TargetUser">��ϢĿ���û������������û���ϵͳ�е�Ψһ��ʶ��������ⲿ�û�����=����</param>
        /// <param name="TargetDispName">��ϢĿ���û�������ʾ���ơ��������û���ϵͳ�е�Ψһ��ʶ��������ⲿ�û�����=����</param>
        /// <param name="FromUser">��Ϣ������</param>
        /// <param name="FromDispName">��Ϣ�����˵���ʾ����</param>
        /// <param name="FromMobile">��Ϣ��Դ�ֻ����룬���ڻظ�</param>
        /// <param name="HandleUrl">����Ǵ������ˣ���ʾ��Ӧ�Ĵ���URL��ָ������Ŀ¼�����Url������������Ŀ¼���ƣ��ڲ���url��ʱ����Ҫ�Ѵ�����¼��MessageItemGuid��Ϊ����������url�ĺ���</param>
        /// <param name="BeiZhu">��ע</param>
        /// <param name="OuGuid">�û����ڲ��ŵ�OuGuid,��Session["OUGuid"]</param>
        /// <param name="BaseOuGuid">�û����ڶ��������ŵ�OuGuid,��Session["BaseOUGuid"] </param>
        /// <returns>Boolean</returns>
        public Boolean Insert(string MessageItemGuid, string Title, string MessageType, string Content, int SendMode, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string HandleUrl, string BeiZhu, string OuGuid, string BaseOuGuid)
        {
            return Insert(MessageItemGuid, Title, MessageType, Content, SendMode, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, HandleUrl, BeiZhu, OuGuid, BaseOuGuid, "");
        }

        /// <summary>
        /// �����Ϣ������ͨ�÷���
        /// ��д���ڣ�2007-4-23
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">��ϢΨһGuid</param>
        /// <param name="Title">��Ϣ����</param>
        /// <param name="MessageType">��Ϣ���ݣ���ʱ���ã�����=''</param>
        /// <param name="Content">��Ϣ���ݣ�������ֻ����ţ��洢��������</param>
        /// <param name="SendMode">����ģʽ��1���ֻ����ţ�2��email��3��������4���������ˣ�5����ʱ��Ϣ</param>
        /// <param name="GenerateDate">��Ϣ����ʱ��</param>
        /// <param name="IsSchedule">�Ƿ�ʱ���͡�0�����������ͣ�1���ǣ���ʱ����</param>
        /// <param name="ScheduleSendDate">�ƻ�����ʱ�䡣�����������͵���Ϣ�����ֶ�û������</param>
        /// <param name="MessageTarget">��ϢĿ�ꡣ������ֻ����ţ���Ϊ���ܺ��룻������ʼ�����Ϊ�ʼ���ַ</param>
        /// <param name="TargetUser">��ϢĿ���û������������û���ϵͳ�е�Ψһ��ʶ��������ⲿ�û�����=����</param>
        /// <param name="TargetDispName">��ϢĿ���û�������ʾ���ơ��������û���ϵͳ�е�Ψһ��ʶ��������ⲿ�û�����=����</param>
        /// <param name="FromUser">��Ϣ������</param>
        /// <param name="FromDispName">��Ϣ�����˵���ʾ����</param>
        /// <param name="FromMobile">��Ϣ��Դ�ֻ����룬���ڻظ�</param>
        /// <param name="HandleUrl">����Ǵ������ˣ���ʾ��Ӧ�Ĵ���URL��ָ������Ŀ¼�����Url������������Ŀ¼���ƣ��ڲ���url��ʱ����Ҫ�Ѵ�����¼��MessageItemGuid��Ϊ����������url�ĺ���</param>
        /// <param name="BeiZhu">��ע</param>
        /// <param name="OuGuid">�û����ڲ��ŵ�OuGuid,��Session["OUGuid"]</param>
        /// <param name="BaseOuGuid">�û����ڶ��������ŵ�OuGuid,��Session["BaseOUGuid"] </param>
        /// <returns>Boolean</returns>
        public Boolean Insert(string MessageItemGuid, string Title, string MessageType, string Content, int SendMode, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string HandleUrl, string BeiZhu, string OuGuid, string BaseOuGuid, string ArchiveNo)
        {
            if (FromUser == null || FromUser == "")
                FromUser = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["UserGuid"]);

            if (FromDispName == null || FromDispName == "")
                FromDispName = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["DisplayName"]);

            if (OuGuid == null || OuGuid == "")
                OuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["OUGuid"]);

            if (BaseOuGuid == null || BaseOuGuid == "")
                BaseOuGuid = StringOperate.ConvertToString(System.Web.HttpContext.Current.Session["BaseOUGuid"]);
            Boolean IsOracle = DatabaseOperate.IsOracle("Messages_ConnectionString");

            String PartitionTag = "";
            if (TargetUser.Length > 0)
                PartitionTag = TargetUser.Substring(0, 1);

            if (IsOracle)
            {
                OracleConnection myConn = new OracleConnection(DatabaseOperate.GetConnectionString("Messages_ConnectionString"));
                string strSql = "INSERT INTO Messages_Center(Row_ID,MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,HandleUrl,BeiZhu,OuGuid,BaseOuGuid,PartitionTag,ArchiveNo) VALUES(sq_Messages_Center.nextval,:MessageItemGuid,:Title,:MessageType,:Content,:SendMode,:GenerateDate,:IsSchedule,:ScheduleSendDate,:MessageTarget,:TargetUser,:TargetDispName,:FromUser,:FromDispName,:FromMobile,:HandleUrl,:BeiZhu,:OuGuid,:BaseOuGuid,:PartitionTag, :ArchiveNo)";
                OracleCommand myCommand = new OracleCommand(strSql, myConn);
                myCommand.Parameters.Add(new OracleParameter("MessageItemGuid", OracleType.NVarChar)).Value = MessageItemGuid;
                myCommand.Parameters.Add(new OracleParameter("Title", OracleType.NVarChar)).Value = Title;
                myCommand.Parameters.Add(new OracleParameter("MessageType", OracleType.NVarChar)).Value = MessageType;
                myCommand.Parameters.Add(new OracleParameter("Content", OracleType.NClob)).Value = DatabaseOperate.HandleNClobParameter(Content);
                myCommand.Parameters.Add(new OracleParameter("SendMode", OracleType.Int32)).Value = 1;
                myCommand.Parameters.Add(new OracleParameter("GenerateDate", OracleType.DateTime)).Value = GenerateDate;
                myCommand.Parameters.Add(new OracleParameter("IsSchedule", OracleType.Int32)).Value = IsSchedule;
                myCommand.Parameters.Add(new OracleParameter("ScheduleSendDate", OracleType.DateTime)).Value = ScheduleSendDate;
                myCommand.Parameters.Add(new OracleParameter("MessageTarget", OracleType.NVarChar)).Value = MessageTarget;
                myCommand.Parameters.Add(new OracleParameter("TargetUser", OracleType.NVarChar)).Value = TargetUser;
                myCommand.Parameters.Add(new OracleParameter("TargetDispName", OracleType.NVarChar)).Value = TargetDispName;
                myCommand.Parameters.Add(new OracleParameter("FromUser", OracleType.NVarChar)).Value = FromUser;
                myCommand.Parameters.Add(new OracleParameter("FromDispName", OracleType.NVarChar)).Value = FromDispName;
                myCommand.Parameters.Add(new OracleParameter("FromMobile", OracleType.NVarChar)).Value = FromMobile;
                myCommand.Parameters.Add(new OracleParameter("HandleUrl", OracleType.NVarChar)).Value = HandleUrl;
                myCommand.Parameters.Add(new OracleParameter("BeiZhu", OracleType.NVarChar)).Value = BeiZhu;
                myCommand.Parameters.Add(new OracleParameter("OuGuid", OracleType.NVarChar)).Value = OuGuid;
                myCommand.Parameters.Add(new OracleParameter("BaseOuGuid", OracleType.NVarChar)).Value = BaseOuGuid;
                myCommand.Parameters.Add(new OracleParameter("PartitionTag", OracleType.NVarChar)).Value = PartitionTag;
                myCommand.Parameters.Add(new OracleParameter("ArchiveNo", OracleType.NVarChar)).Value = ArchiveNo;

                myConn.Open();
                myCommand.ExecuteNonQuery();
                myConn.Close();
            }
            else
            {
                Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
                string strSql = "INSERT INTO Messages_Center(MessageItemGuid,Title,MessageType,Content,SendMode,GenerateDate,IsSchedule,ScheduleSendDate,MessageTarget,TargetUser,TargetDispName,FromUser,FromDispName,FromMobile,HandleUrl,BeiZhu,OuGuid,BaseOuGuid,PartitionTag,ArchiveNo) VALUES(@MessageItemGuid,@Title,@MessageType,@Content,@SendMode,@GenerateDate,@IsSchedule,@ScheduleSendDate,@MessageTarget,@TargetUser,@TargetDispName,@FromUser,@FromDispName,@FromMobile,@HandleUrl,@BeiZhu,@OuGuid,@BaseOuGuid,@PartitionTag,@ArchiveNo) ";
                DbCommand cmd = db.GetSqlStringCommand(strSql);

                db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
                db.AddInParameter(cmd, "Title", DbType.String, Title);
                db.AddInParameter(cmd, "MessageType", DbType.String, MessageType);
                db.AddInParameter(cmd, "Content", DbType.String, Content);
                db.AddInParameter(cmd, "SendMode", DbType.Int32, SendMode);
                db.AddInParameter(cmd, "GenerateDate", DbType.DateTime, GenerateDate);
                db.AddInParameter(cmd, "IsSchedule", DbType.Int32, IsSchedule);
                db.AddInParameter(cmd, "ScheduleSendDate", DbType.DateTime, ScheduleSendDate);
                db.AddInParameter(cmd, "MessageTarget", DbType.String, MessageTarget);
                db.AddInParameter(cmd, "TargetUser", DbType.String, TargetUser);
                db.AddInParameter(cmd, "TargetDispName", DbType.String, TargetDispName);
                db.AddInParameter(cmd, "FromUser", DbType.String, FromUser);
                db.AddInParameter(cmd, "FromDispName", DbType.String, FromDispName);
                db.AddInParameter(cmd, "FromMobile", DbType.String, FromMobile);
                db.AddInParameter(cmd, "HandleUrl", DbType.String, HandleUrl);
                db.AddInParameter(cmd, "BeiZhu", DbType.String, BeiZhu);
                db.AddInParameter(cmd, "OuGuid", DbType.String, OuGuid);
                db.AddInParameter(cmd, "BaseOuGuid", DbType.String, BaseOuGuid);
                db.AddInParameter(cmd, "PartitionTag", DbType.String, PartitionTag);
                db.AddInParameter(cmd, "ArchiveNo", DbType.String, ArchiveNo);
                db.ExecuteNonQuery(cmd);
            }
            return true;
        }

        /// <summary>
        /// ȡ�õ�һ����Ҫ���͵��ֻ�����
        /// �ް���
        /// </summary>
        /// <returns>DataView</returns>
        public DataView GetTopOneWaitHandleSms(string strSql)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// ���ŷ��ͳɹ��󣬸��·���״̬��ת�Ƶ��ѷ��ͱ���
        /// ����ʱ��Ϊϵͳ��ǰʱ��
        /// ��д���ڣ�2007-12-12
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="MessageItemGuid">MessageItemGuid</param>
        /// <param name="SendDate">SendDate</param>
        /// <param name="IsSend">IsSend</param>
        public void SMS_UpdateHandle(string MessageItemGuid, DateTime SendDate, int IsSend)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET SendDate=@SendDate,IsSend=@IsSend WHERE  MessageItemGuid=@MessageItemGuid " :
                "UPDATE Messages_Center SET SendDate=:SendDate,IsSend=:IsSend WHERE  MessageItemGuid=:MessageItemGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "SendDate", DbType.DateTime, SendDate);
            db.AddInParameter(cmd, "IsSend", DbType.Int32, IsSend);

            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);

            //�����ת����Ϣ���Ѵ������
            MsgHistroy.Move_WaitHandleToHistroy(MessageItemGuid);
        }

        /// <summary>
        /// ȡ�÷��Ͷ��ŵ�sql��䣬sql��oralce����Ӧ
        /// </summary>
        /// <param name="SendSmsTypeLst">SendSmsTypeLst</param>
        /// <returns>string</returns>
        public string GetSendSMSSql(string SendSmsTypeLst)
        {
            Boolean IsOracle = DatabaseOperate.IsOracle("Messages_ConnectionString");
            String strSql = "";
            if (IsOracle)
            {
                #region IsOracle
                strSql = " SELECT  *  FROM Messages_Center WHERE SendMode=1 and ((IsSchedule=1 and ScheduleSendDate< sysdate ) or ( IsSchedule=0) )   ";
                if (SendSmsTypeLst != null && SendSmsTypeLst != "" && SendSmsTypeLst != "!")
                {
                    String isNot = "";
                    if (SendSmsTypeLst.StartsWith("!"))
                    {
                        isNot = " not ";
                        SendSmsTypeLst = SendSmsTypeLst.Substring(1);
                    }

                    String[] arrMo = SendSmsTypeLst.Split(';');
                    String strWhere = "";
                    for (int i = 0; i < arrMo.Length; i++)
                    {
                        if (arrMo[i].Trim() != "")
                        {
                            if (isNot == "")
                                strWhere += " MessageTarget   like '" + arrMo[i].Trim() + "%'   or";
                            else
                                strWhere += " MessageTarget  " + isNot + " like '" + arrMo[i].Trim() + "%'   and";
                        }
                    }
                    if (strWhere != "")
                        strWhere = strWhere.Substring(0, strWhere.Length - 3);
                    if (strWhere != "")
                        strSql = strSql + " and (" + strWhere + ") ";
                }
                strSql += " order by Row_ID  ";

                strSql = SQLOperate.Generate_Top_Select_Oracle(strSql, 1);
                #endregion
            }
            else
            {
                #region Sql
                strSql = " SELECT top 1 *  FROM Messages_Center WHERE SendMode=1  and ((IsSchedule=1 and ScheduleSendDate<getdate()) or ( IsSchedule=0) )   ";
                if (SendSmsTypeLst != null && SendSmsTypeLst != "" && SendSmsTypeLst != "!")
                {
                    String isNot = "";
                    if (SendSmsTypeLst.StartsWith("!"))
                    {
                        isNot = " not ";
                        SendSmsTypeLst = SendSmsTypeLst.Substring(1);
                    }

                    String[] arrMo = SendSmsTypeLst.Split(';');
                    String strWhere = "";
                    for (int i = 0; i < arrMo.Length; i++)
                    {
                        if (arrMo[i].Trim() != "")
                        {
                            if (isNot == "")
                                strWhere += " MessageTarget   like '" + arrMo[i].Trim() + "%'   or";
                            else
                                strWhere += " MessageTarget  " + isNot + " like '" + arrMo[i].Trim() + "%'   and";
                        }
                    }
                    if (strWhere != "")
                        strWhere = strWhere.Substring(0, strWhere.Length - 3);
                    if (strWhere != "")
                        strSql = strSql + " and (" + strWhere + ") ";
                }
                strSql += " order by Row_ID  ";
                #endregion
            }
            return strSql;
        }

        /// <summary>
        ///// �ֻ����ż���
        ///// ��д���ڣ�2007-9-3
        ///// ��д�ˣ��ް���
        /// </summary>
        /// <param name="FromValue">��ʼʱ��</param>
        /// <param name="ToValue">����ʱ��</param>
        /// <param name="Content">����</param>
        /// <param name="UserGuid">�����û�UserGuid</param>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPageIndex"></param>
        /// <param name="isSend">�Ƿ���״̬.0:δ���ͣ�1���ѷ��ͣ�9������</param>
        /// <param name="TotalNum">TotalNum</param>
        /// <returns>DataView</returns>
        public DataView GetReceiveSmsView(string FromValue, string ToValue, string Content, string UserGuid, int PageSize, int CurrentPageIndex, out int TotalNum)
        {
            Boolean IsOracle = DatabaseOperate.IsOracle("Messages_ConnectionString");

            String PartitionTag = "";
            if (UserGuid.Length > 0)
                PartitionTag = UserGuid.Substring(0, 1);
            //PartitionTag='" + PartitionTag + "' and 
            string strWhere = "  where SendMode=1 and TargetUser = '" + UserGuid + "'  ";


            if (Content != "")
                strWhere += " and Content like '%" + SQLOperate.ReplaceSql(Content) + "%'";

            if (FromValue != "")
            {
                if (IsOracle)
                    strWhere += " and ScheduleSendDate >= TO_DATE('" + FromValue + "','YYYY-MM-DD HH24:MI:SS') ";
                else
                    strWhere += " and ScheduleSendDate >= '" + FromValue + "' ";
            }

            if (ToValue != "")
            {
                if (IsOracle)
                    strWhere += " and ScheduleSendDate <= TO_DATE('" + ToValue + " 23:59:59','YYYY-MM-DD HH24:MI:SS') ";
                else
                    strWhere += " and ScheduleSendDate <= '" + ToValue + " 23:59:59' ";
            }

            string TableName = "";
            string OrderStr = " order by  Row_ID desc  ";
            string UnitField = "Row_ID";

            TableName = "Messages_Center_Histroy";


            DBOperate DBOper = new DBOperate();
            DBOper.ConnectionStringName = DatabaseOperate.GetConnectionStringName("Messages_ConnectionString");
            return DBOper.GetData_Page(
                " * ",
                 PageSize,
                 CurrentPageIndex,
                TableName,
                UnitField,
                strWhere,
                OrderStr,
                out TotalNum
                ).DefaultView;
        }

        /// <summary>
        /// �ֻ����ż���
        /// ��д���ڣ�2007-9-3
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="FromValue">��ʼʱ��</param>
        /// <param name="ToValue">����ʱ��</param>
        /// <param name="Content">����</param>
        /// <param name="UserGuid">�����û�UserGuid</param>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPageIndex"></param>
        /// <param name="isSend">�Ƿ���״̬.0:δ���ͣ�1���ѷ��ͣ�9������</param>
        /// <param name="TotalNum">TotalNum</param>
        /// <returns>DataView</returns>
        public DataView GetSmsDatePageView(string FromValue, string ToValue, string Content, string UserGuid, int PageSize, int CurrentPageIndex, int isSend, Boolean isShowAll, out int TotalNum)
        {
            TotalNum = 0;
            return GetSmsDatePageView(FromValue, ToValue, Content, UserGuid, "", "", PageSize, CurrentPageIndex, isSend, isShowAll, out  TotalNum);
        }

        /// <summary>
        /// �ֻ����ż���
        /// ��д���ڣ�2007-9-3
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="FromValue">��ʼʱ��</param>
        /// <param name="ToValue">����ʱ��</param>
        /// <param name="Content">����</param>
        /// <param name="UserGuid">�����û�UserGuid</param>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPageIndex"></param>
        /// <param name="isSend">�Ƿ���״̬.0:δ���ͣ�1���ѷ��ͣ�9������</param>
        /// <param name="TotalNum">TotalNum</param>
        /// <returns>DataView</returns>
        public DataView GetSmsDatePageView(string FromValue, string ToValue, string Content, string UserGuid, String SendUserName, String ReceiveMobile, int PageSize, int CurrentPageIndex, int isSend, Boolean isShowAll, out int TotalNum)
        {
            Boolean IsOracle = DatabaseOperate.IsOracle("Messages_ConnectionString");
            string strWhere = " where  SendMode=1 ";

            if (IsOracle)
                strWhere += " and nvl(IsDel,0)=0  ";
            else
                strWhere += " and ISNULL(IsDel,0)=0  ";

            if (!isShowAll)
                strWhere += "  and FromUser = '" + UserGuid + "'  ";

            if (Content != "")
                strWhere += " and Content like '%" + SQLOperate.ReplaceSql(Content) + "%'";

            if (SendUserName != "")
                strWhere += " and FromDispName like '%" + SQLOperate.ReplaceSql(SendUserName) + "%'";

            if (ReceiveMobile != "")
                strWhere += " and MessageTarget like '%" + SQLOperate.ReplaceSql(ReceiveMobile) + "%'";

            if (FromValue != "")
            {
                if (IsOracle)
                    strWhere += " and ScheduleSendDate >= TO_DATE('" + FromValue + "','YYYY-MM-DD HH24:MI:SS') ";
                else
                    strWhere += " and ScheduleSendDate >= '" + FromValue + "' ";
            }

            if (ToValue != "")
            {
                if (IsOracle)
                    strWhere += " and ScheduleSendDate <= TO_DATE('" + ToValue + " 23:59:59','YYYY-MM-DD HH24:MI:SS') ";
                else
                    strWhere += " and ScheduleSendDate <= '" + ToValue + " 23:59:59' ";
            }

            string TableName = "";
            string OrderStr = " order by  Row_ID desc  ";
            string UnitField = "Row_ID";
            if (isSend == 0)//δ����
                TableName = "Messages_Center";
            else if (isSend == 1)//�ѷ���
                TableName = "Messages_Center_Histroy";
            //else
            //{
            //    OrderStr = " order by  GenerateDate desc,Row_ID desc,MessageItemGuid  ";
            //    TableName = "V_Messages_AllMSG";
            //    //UnitField = "MessageItemGuid";
            //}

            DBOperate DBOper = new DBOperate();
            DBOper.ConnectionStringName = DatabaseOperate.GetConnectionStringName("Messages_ConnectionString");
            return DBOper.GetData_Page(
                " * ",
                 PageSize,
                 CurrentPageIndex,
                TableName,
                UnitField,
                strWhere,
                OrderStr,
                out TotalNum
                ).DefaultView;
        }

        /// 
        /// ��д���ڣ�2008-1-29
        /// ��д�ˣ��ؽ�˪
        /// </summary>
        /// <param name="ClientIdentifier">ClientIdentifier</param>
        public void Delete_ClientIdentifier(string ClientIdentifier)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "DELETE FROM Messages_Center WHERE   ClientIdentifier=@ClientIdentifier " :
                "DELETE FROM Messages_Center WHERE   ClientIdentifier=:ClientIdentifier ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "ClientIdentifier", DbType.String, ClientIdentifier);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// �޸�HandleUrl
        /// ��д���ڣ�2008-1-30
        /// ��д�ˣ��ؽ�˪
        /// </summary>
        /// <param name="MessageItemGuid">MessageItemGuid</param>
        /// <param name="HandleUrl">HandleUrl</param>
        public void Update_task(string MessageItemGuid, string HandleUrl)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET HandleUrl=@HandleUrl WHERE  MessageItemGuid=@MessageItemGuid " :
                "UPDATE Messages_Center SET HandleUrl=:HandleUrl WHERE  MessageItemGuid=:MessageItemGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "HandleUrl", DbType.String, HandleUrl);

            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// �޸�HandleUrl
        /// ��д���ڣ�2008-1-30
        /// ��д�ˣ��ؽ�˪
        /// </summary>
        /// <param name="MessageItemGuid">MessageItemGuid</param>
        /// <param name="HandleUrl">HandleUrl</param>
        public void Update_MessageType(string MessageItemGuid, string MessageType)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET MessageType=@MessageType WHERE  MessageItemGuid=@MessageItemGuid " :
                "UPDATE Messages_Center SET MessageType=:MessageType WHERE  MessageItemGuid=:MessageItemGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "MessageType", DbType.String, MessageType);

            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// ����Content�ֶ�
        /// ��д���ڣ�2010-1-12
        /// ��д�ˣ��⽨
        /// </summary>
        /// <param name="MessageItemGuid">MessageItemGuid</param>
        /// <param name="Content">Content</param>
        public void Update_MessageContent(string MessageItemGuid, string Content)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "UPDATE Messages_Center SET Content=@Content WHERE  MessageItemGuid=@MessageItemGuid " :
                "UPDATE Messages_Center SET Content=:Content WHERE  MessageItemGuid=:MessageItemGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "Content", DbType.String, Content);

            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// DeleteByMessageItemGuid
        /// 
        /// DELETE FROM Messages_Center WHERE MessageItemGuid=@MessageItemGuid
        /// </summary>
        /// <param name="MessageItemGuid">MessageItemGuid</param>
        public void DeleteByMessageItemGuid(string MessageItemGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "DELETE FROM Messages_Center WHERE MessageItemGuid=@MessageItemGuid " :
                "DELETE FROM Messages_Center WHERE MessageItemGuid=:MessageItemGuid ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// ɾ����û�з��͵Ķ���
        /// ��д���ڣ�2008-2-14
        /// ��д�ˣ��⽨
        /// 
        /// DELETE FROM Messages_Center WHERE MessageItemGuid=@MessageItemGuid and SendMode=@SendMode
        /// </summary>
        /// <param name="MessageItemGuid">MessageItemGuid</param>
        /// <param name="SendMode">SendMode</param>
        public void Delete_NonSendSms(string MessageItemGuid, int SendMode)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "DELETE FROM Messages_Center WHERE MessageItemGuid=@MessageItemGuid and SendMode=@SendMode" :
                "DELETE FROM Messages_Center WHERE MessageItemGuid=:MessageItemGuid and SendMode=:SendMode";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "MessageItemGuid", DbType.String, MessageItemGuid);
            db.AddInParameter(cmd, "SendMode", DbType.Int32, SendMode);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// �����û���ClientIdentifier��ȷ��Ψһ��¼
        /// ��д���ڣ�2008-5-7
        /// ��д�ˣ��ؽ�˪
        /// 
        /// SELECT  MessageItemGuid FROM Messages_Center WHERE  TargetUser=@TargetUser AND ClientIdentifier=@ClientIdentifier
        /// </summary>
        /// <param name="TargetUser">TargetUser</param>
        /// <param name="ClientIdentifier">ClientIdentifier</param>
        public DataView Select_examMessgeGuid(string TargetUser, string ClientIdentifier)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT  MessageItemGuid FROM Messages_Center WHERE  TargetUser=@TargetUser AND ClientIdentifier=@ClientIdentifier " :
                "SELECT  MessageItemGuid FROM Messages_Center WHERE  TargetUser=:TargetUser AND ClientIdentifier=:ClientIdentifier ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "TargetUser", DbType.String, TargetUser);
            db.AddInParameter(cmd, "ClientIdentifier", DbType.String, ClientIdentifier);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// ʡ�ʼ���Ŀר�ã���÷�����Ϣ���������б�
        /// </summary>
        /// <param name="ClientIdentifier">ClientIdentifier</param>
        /// <returns></returns>
        public DataView Select_ShenPiRen(string ClientIdentifier)
        {
            //��õ�һ���ύ��˵�ʱ��
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT  GenerateDate FROM Messages_Center_Histroy WHERE  ClientIdentifier=@ClientIdentifier Order By GenerateDate asc" :
                "SELECT GenerateDate FROM Messages_Center_Histroy WHERE  ClientIdentifier=:ClientIdentifier Order By GenerateDate asc";
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "ClientIdentifier", DbType.String, ClientIdentifier);
            DateTime GenerateDate = Convert.ToDateTime(db.ExecuteDataView(cmd)[0]["GenerateDate"]);

            strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT  targetuser,targetdispname FROM Messages_Center_Histroy WHERE  GenerateDate=@GenerateDate " :
                "SELECT targetuser,targetdispname FROM Messages_Center_Histroy WHERE  GenerateDate=:GenerateDate ";
            cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "GenerateDate", DbType.DateTime, GenerateDate);
            return db.ExecuteDataView(cmd);
        }
        /// <summary>
        /// ����ClientIdentifierȡ�ô������ˣ�ClientIdentifier����ApplyGuid
        /// ��д���ڣ�2009-1-12
        /// ��д�ˣ�Ф����
        /// </summary>
        /// <param name="ClientIdentifier"></param>
        public DataView SelectWaithandleByClientIdentifier(string ClientIdentifier)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT * FROM Messages_Center WHERE  ClientIdentifier=@ClientIdentifier " :
                "SELECT * FROM Messages_Center WHERE  ClientIdentifier=:ClientIdentifier ";
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "ClientIdentifier", DbType.String, ClientIdentifier);
            return db.ExecuteDataView(cmd);
        }

        private string GetSQLForCommissionSet(string OwnerUserGuid, string CanShowInType)
        {
            return GetSQLForCommissionSet(OwnerUserGuid, CanShowInType, true);

        }

        private string GetSQLForCommissionSet(string OwnerUserGuid, string CanShowInType, bool bBelongSelf)
        {
            Boolean IsOracle = DatabaseOperate.IsOracle("Frame_ConnectionString");
            DataView dv = SelectCommissionByUserGuid(OwnerUserGuid, CanShowInType);
            string strSql = "";
            if (bBelongSelf)
            {
                if (dv.Count == 0)
                    return " TargetUser = '" + OwnerUserGuid + "'";

                strSql = "(TargetUser = '" + OwnerUserGuid + "' or ";
                for (int i = 0; i < dv.Count; i++)
                {
                    if (IsOracle)
                        strSql += "(TargetUser='" + dv[i]["LeadUserGuid"] + "' and generatedate>=TO_DATE('" + Convert.ToDateTime(dv[i]["commissionFromDate"]).ToString("yyyy-MM-dd") + "','YYYY-MM-DD HH24:MI:SS')) or ";
                    else
                        strSql += "(TargetUser='" + dv[i]["LeadUserGuid"] + "' and generatedate>='" + dv[i]["commissionFromDate"] + "') or ";
                }

                //ȥ��or
                if (strSql.EndsWith("or "))
                    strSql = strSql.Substring(0, strSql.Length - 3);
                strSql += ")";
            }
            else
            {
                if (dv.Count == 0)
                    return " 1 = 2";
                strSql = "(";
                for (int i = 0; i < dv.Count; i++)
                    if (IsOracle)
                        strSql += "(TargetUser='" + dv[i]["LeadUserGuid"] + "' and generatedate>=TO_DATE('" + Convert.ToDateTime(dv[i]["commissionFromDate"]).ToString("yyyy-MM-dd") + "','YYYY-MM-DD HH24:MI:SS')) or ";
                    else
                        strSql += "(TargetUser='" + dv[i]["LeadUserGuid"] + "' and generatedate>='" + dv[i]["commissionFromDate"] + "') or ";

                //ȥ��or
                if (strSql.EndsWith("or "))
                    strSql = strSql.Substring(0, strSql.Length - 3);
                strSql += ")";
            }
            //LogOperate.WriteLog_ToFileName("XgcTest.txt", strSql);
            return strSql;
        }

        /// <summary>
        /// TODO:��һ���汾�Ƶ�����С�
        /// ��д���ڣ�2008-8-15
        /// ��д�ˣ��⽨
        /// </summary>
        private DataView SelectCommissionByUserGuid(string CommissionUserGuid, string CanShowInType)
        {
            Boolean IsOracle = DatabaseOperate.IsOracle("Frame_ConnectionString");
            string nowTime = DateTimeOperate.GetCurrentDate();
            string strWhere = "";
            if (IsOracle)
                strWhere += " and (CommissionFromDate is null or CommissionFromDate <=TO_DATE('" + nowTime + " 23:59:59','YYYY-MM-DD HH24:MI:SS')) and (CommissionToDate is null or  CommissionToDate>=TO_DATE('" + nowTime + "','YYYY-MM-DD HH24:MI:SS'))";
            else
                strWhere += " and (CommissionFromDate is null or CommissionFromDate <='" + nowTime + " 23:59:59') and (CommissionToDate is null or  CommissionToDate>='" + nowTime + "')";

            strWhere += " And " + CanShowInType + " = 1 ";

            Database db = DatabaseFactory.CreateDatabase("Frame_ConnectionString");
            string strSql = (db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT  LeadUserGuid,commissionFromDate FROM Frame_CommissionSet WHERE  CommissionUserGuid=@CommissionUserGuid " + strWhere :
                "SELECT  LeadUserGuid,commissionFromDate FROM Frame_CommissionSet WHERE  CommissionUserGuid=:CommissionUserGuid " + strWhere;
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "CommissionUserGuid", DbType.String, CommissionUserGuid);
            return db.ExecuteDataView(cmd);
        }
    }


    #region ���������õ��ĺ��ʼ��йص�3���࣬Ϊ�˲�����Epoint.DBMail.Bizlogic���ŵ������

    /// <summary>
    /// 
    /// </summary>
    public class DB_DBMail_AllMails
    {
        private bool Is_ExistDBMailTable = true;

        /// <summary>
        /// 
        /// </summary>
        public DB_DBMail_AllMails()
        {
            //���ﲹ���жϱ��Ƿ���ڵķ����� 
            Is_ExistDBMailTable = true;
        }


        /// <summary>
        /// ����ʼ��շ���¼
        /// ��д���ڣ�2007-5-15
        /// ��д�ˣ��̽���
        /// </summary>
        /// <param name="MailGuid"></param>
        /// <param name="FromUserGuid"></param>
        /// <param name="FromDispName"></param>
        /// <param name="ToUserGuidList"></param>
        /// <param name="ToUserDispNameList"></param>
        /// <param name="Subject"></param>
        /// <param name="MailContent"></param>
        /// <param name="OwnerUserGuid"></param>
        /// <param name="SendTime"></param>
        /// <param name="mailTypeName"></param>
        /// <param name="mailTypeId"></param>
        /// <param name="deleteFlag"></param>
        /// <param name="HasAttach"></param>
        /// <param name="Importance"></param>
        /// <param name="BoxTypeGuid"></param>
        /// <param name="OutMailGuid"></param>
        public void Insert(string MailGuid, string FromUserGuid, string FromDispName, string ToUserGuidList, string ToUserDispNameList, string SecretUserGuidList, string SecretUserDispNameList, string ChaoSongUserGuidList, string ChaoSongUserDispNameList, string Subject, string MailContent, string OwnerUserGuid, DateTime SendTime, string mailTypeName, string mailTypeId, int deleteFlag, int HasAttach, int Importance, string BoxTypeGuid, string OutMailGuid, int NeedTaskMonitor)
        {
            if (Is_ExistDBMailTable == false)
                return;

            if (DatabaseOperate.IsOracle("DBMail_ConnectionString"))
            {
                OracleConnection myConn = new OracleConnection(DatabaseOperate.GetConnectionString("DBMail_ConnectionString"));

                string strSql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TaskMailFeedBack]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)  INSERT INTO DBMail_AllMails(Row_ID,MailGuid,FromUserGuid,FromDispName,ToUserGuidList,ToUserDispNameList,SecretUserGuidList,SecretUserDispNameList,ChaoSongUserGuidList,ChaoSongUserDispNameList,Subject,MailContent,OwnerUserGuid,SendTime,mailTypeName,mailTypeId,deleteFlag,HasAttach,Importance,BoxTypeGuid,OutMailGuid,NeedTaskMonitor) VALUES(SQ_DBMAIL_ALLMAILS.nextval,:MailGuid,:FromUserGuid,:FromDispName,:ToUserGuidList,:ToUserDispNameList,:SecretUserGuidList,:SecretUserDispNameList,:ChaoSongUserGuidList,:ChaoSongUserDispNameList,:Subject,:MailContent,:OwnerUserGuid,:SendTime,:mailTypeName,:mailTypeId,:deleteFlag,:HasAttach,:Importance,:BoxTypeGuid,:OutMailGuid,:NeedTaskMonitor) ";
                OracleCommand myCommand = new OracleCommand(strSql, myConn);

                myCommand.Parameters.Add(new OracleParameter("MailGuid", OracleType.NVarChar)).Value = MailGuid;
                myCommand.Parameters.Add(new OracleParameter("FromUserGuid", OracleType.NVarChar)).Value = FromUserGuid;
                myCommand.Parameters.Add(new OracleParameter("FromDispName", OracleType.NVarChar)).Value = FromDispName;
                myCommand.Parameters.Add(new OracleParameter("ToUserGuidList", OracleType.NClob)).Value = DatabaseOperate.HandleNClobParameter(ToUserGuidList);
                myCommand.Parameters.Add(new OracleParameter("ToUserDispNameList", OracleType.NClob)).Value = DatabaseOperate.HandleNClobParameter(ToUserDispNameList);

                myCommand.Parameters.Add(new OracleParameter("SecretUserGuidList", OracleType.NClob)).Value = DatabaseOperate.HandleNClobParameter(SecretUserGuidList);
                myCommand.Parameters.Add(new OracleParameter("SecretUserDispNameList", OracleType.NClob)).Value = DatabaseOperate.HandleNClobParameter(SecretUserDispNameList);

                myCommand.Parameters.Add(new OracleParameter("ChaoSongUserGuidList", OracleType.NClob)).Value = DatabaseOperate.HandleNClobParameter(ChaoSongUserGuidList);
                myCommand.Parameters.Add(new OracleParameter("ChaoSongUserDispNameList", OracleType.NClob)).Value = DatabaseOperate.HandleNClobParameter(ChaoSongUserDispNameList);


                myCommand.Parameters.Add(new OracleParameter("Subject", OracleType.NVarChar)).Value = Subject;
                myCommand.Parameters.Add(new OracleParameter("MailContent", OracleType.NClob)).Value = DatabaseOperate.HandleNClobParameter(MailContent);
                myCommand.Parameters.Add(new OracleParameter("OwnerUserGuid", OracleType.NVarChar)).Value = OwnerUserGuid;
                myCommand.Parameters.Add(new OracleParameter("SendTime", OracleType.DateTime)).Value = SendTime;
                myCommand.Parameters.Add(new OracleParameter("mailTypeName", OracleType.NVarChar)).Value = mailTypeName;
                myCommand.Parameters.Add(new OracleParameter("mailTypeId", OracleType.NVarChar)).Value = mailTypeId;
                myCommand.Parameters.Add(new OracleParameter("deleteFlag", OracleType.Int32)).Value = deleteFlag;
                myCommand.Parameters.Add(new OracleParameter("HasAttach", OracleType.Int32)).Value = HasAttach;
                myCommand.Parameters.Add(new OracleParameter("Importance", OracleType.Int32)).Value = Importance;
                myCommand.Parameters.Add(new OracleParameter("BoxTypeGuid", OracleType.NVarChar)).Value = BoxTypeGuid;
                myCommand.Parameters.Add(new OracleParameter("OutMailGuid", OracleType.NVarChar)).Value = OutMailGuid;
                myCommand.Parameters.Add(new OracleParameter("NeedTaskMonitor", OracleType.Int32)).Value = NeedTaskMonitor;
                myConn.Open();
                myCommand.ExecuteNonQuery();
                myConn.Close();
            }
            else
            {
                Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("DBMail_ConnectionString"));
                string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                    "INSERT INTO DBMail_AllMails(MailGuid,FromUserGuid,FromDispName,ToUserGuidList,ToUserDispNameList,SecretUserGuidList,SecretUserDispNameList,ChaoSongUserGuidList,ChaoSongUserDispNameList,Subject,MailContent,OwnerUserGuid,SendTime,mailTypeName,mailTypeId,deleteFlag,HasAttach,Importance,BoxTypeGuid,OutMailGuid,NeedTaskMonitor) VALUES(@MailGuid,@FromUserGuid,@FromDispName,@ToUserGuidList,@ToUserDispNameList,@SecretUserGuidList,@SecretUserDispNameList,@ChaoSongUserGuidList,@ChaoSongUserDispNameList,@Subject,@MailContent,@OwnerUserGuid,@SendTime,@mailTypeName,@mailTypeId,@deleteFlag,@HasAttach,@Importance,@BoxTypeGuid,@OutMailGuid,@NeedTaskMonitor) " :
                    ""
                );
                DbCommand cmd = db.GetSqlStringCommand(strSql);

                db.AddInParameter(cmd, "MailGuid", DbType.String, MailGuid);
                db.AddInParameter(cmd, "FromUserGuid", DbType.String, FromUserGuid);
                db.AddInParameter(cmd, "FromDispName", DbType.String, FromDispName);
                db.AddInParameter(cmd, "ToUserGuidList", DbType.String, ToUserGuidList);
                db.AddInParameter(cmd, "ToUserDispNameList", DbType.String, ToUserDispNameList);

                db.AddInParameter(cmd, "SecretUserGuidList", DbType.String, SecretUserGuidList);
                db.AddInParameter(cmd, "SecretUserDispNameList", DbType.String, SecretUserDispNameList);

                db.AddInParameter(cmd, "ChaoSongUserGuidList", DbType.String, ChaoSongUserGuidList);
                db.AddInParameter(cmd, "ChaoSongUserDispNameList", DbType.String, ChaoSongUserDispNameList);

                db.AddInParameter(cmd, "Subject", DbType.String, Subject);
                db.AddInParameter(cmd, "MailContent", DbType.String, "");
                db.AddInParameter(cmd, "OwnerUserGuid", DbType.String, OwnerUserGuid);
                db.AddInParameter(cmd, "SendTime", DbType.DateTime, SendTime);
                db.AddInParameter(cmd, "mailTypeName", DbType.String, mailTypeName);
                db.AddInParameter(cmd, "mailTypeId", DbType.String, mailTypeId);
                db.AddInParameter(cmd, "deleteFlag", DbType.Int32, deleteFlag);
                db.AddInParameter(cmd, "HasAttach", DbType.Int32, HasAttach);
                db.AddInParameter(cmd, "Importance", DbType.Int32, Importance);
                db.AddInParameter(cmd, "BoxTypeGuid", DbType.String, BoxTypeGuid);
                db.AddInParameter(cmd, "OutMailGuid", DbType.String, OutMailGuid);
                db.AddInParameter(cmd, "NeedTaskMonitor", DbType.Int32, NeedTaskMonitor);
                db.ExecuteNonQuery(cmd);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DB_DBMail_MailContent
    {
        private bool Is_ExistDBMailTable = true;

        /// <summary>
        /// 
        /// </summary>
        public DB_DBMail_MailContent()
        {
            //���ﲹ���жϱ��Ƿ���ڵķ����� 
            Is_ExistDBMailTable = true;
        }

        /// <summary>
        /// ����ʼ���������
        /// ��д���ڣ�2007-9-5
        /// ��д�ˣ��ް���
        /// </summary>
        /// <param name="OutMailGuid">�ʼ�ΨһGuid</param>
        /// <param name="MailContent">�ʼ�����</param>
        public void AddMailContent(string OutMailGuid, string MailContent)
        {
            if (Is_ExistDBMailTable == false)
                return;

            Boolean IsOracle = DatabaseOperate.IsOracle("DBMail_ConnectionString");
            if (!CheckOutMailGuidIsExist(OutMailGuid))
            {
                if (IsOracle)
                {
                    OracleConnection myConn = new OracleConnection(DatabaseOperate.GetConnectionString("DBMail_ConnectionString"));
                    string strSql = "INSERT INTO DBMail_MailContent(OutMailGuid,MailContent) VALUES(:OutMailGuid,:MailContent) ";
                    OracleCommand myCommand = new OracleCommand(strSql, myConn);
                    myCommand.Parameters.Add(new OracleParameter("OutMailGuid", OracleType.NVarChar)).Value = OutMailGuid;
                    myCommand.Parameters.Add(new OracleParameter("MailContent", OracleType.NClob)).Value = DatabaseOperate.HandleNClobParameter(MailContent);
                    myConn.Open();
                    myCommand.ExecuteNonQuery();
                    myConn.Close();
                }
                else
                {
                    Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("DBMail_ConnectionString"));
                    string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                        "INSERT INTO DBMail_MailContent(OutMailGuid,MailContent) VALUES(@OutMailGuid,@MailContent) " :
                        "INSERT INTO DBMail_MailContent(OutMailGuid,MailContent) VALUES(:OutMailGuid,:MailContent)"
                    );
                    DbCommand cmd = db.GetSqlStringCommand(strSql);

                    db.AddInParameter(cmd, "OutMailGuid", DbType.String, OutMailGuid);
                    db.AddInParameter(cmd, "MailContent", DbType.String, MailContent);
                    db.ExecuteNonQuery(cmd);
                }
            }
            else
            {
                if (IsOracle)
                {
                    OracleConnection myConn = new OracleConnection(DatabaseOperate.GetConnectionString("DBMail_ConnectionString"));
                    string strSql = "UPDATE DBMail_MailContent SET MailContent=:MailContent WHERE  OutMailGuid=:OutMailGuid";
                    OracleCommand myCommand = new OracleCommand(strSql, myConn);

                    myCommand.Parameters.Add(new OracleParameter("OutMailGuid", OracleType.NVarChar)).Value = OutMailGuid;
                    myCommand.Parameters.Add(new OracleParameter("MailContent", OracleType.NClob)).Value = DatabaseOperate.HandleNClobParameter(MailContent);

                    myConn.Open();
                    myCommand.ExecuteNonQuery();
                    myConn.Close();
                }
                else
                {

                    Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("DBMail_ConnectionString"));
                    string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                        "UPDATE DBMail_MailContent SET MailContent=@MailContent WHERE  OutMailGuid=@OutMailGuid " :
                        "UPDATE DBMail_MailContent SET MailContent=:MailContent WHERE  OutMailGuid=:OutMailGuid "
                    );
                    DbCommand cmd = db.GetSqlStringCommand(strSql);
                    db.AddInParameter(cmd, "MailContent", DbType.String, MailContent);
                    db.AddInParameter(cmd, "OutMailGuid", DbType.String, OutMailGuid);
                    db.ExecuteNonQuery(cmd);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OutMailGuid"></param>
        /// <returns></returns>
        public Boolean CheckOutMailGuidIsExist(string OutMailGuid)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("DBMail_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "SELECT count(*) FROM DBMail_MailContent WHERE  OutMailGuid=@OutMailGuid " :
                "SELECT count(*) FROM DBMail_MailContent WHERE  OutMailGuid=:OutMailGuid "
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "OutMailGuid", DbType.String, OutMailGuid);

            Object ob = db.ExecuteScalar(cmd);
            if (Epoint.Frame.Common.NumericOperate.ConvertToInt(ob) > 0)
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DB_DBMail_MailSign
    {
        private bool Is_ExistDBMailTable = true;

        /// <summary>
        /// 
        /// </summary>
        public DB_DBMail_MailSign()
        {
            //���ﲹ���жϱ��Ƿ���ڵķ����� 
            Is_ExistDBMailTable = true;
        }


        /// <summary>
        /// ����ǩ�ռ�¼��Ϣ
        /// ��д���ڣ�2007-5-16
        /// ��д�ˣ��̽���
        /// </summary>
        /// <param name="OutMailGuid"></param>
        /// <param name="SignUserGuid"></param>
        /// <param name="SignUserDispName"></param>
        public void Insert(string OutMailGuid, string SignUserGuid, string SignUserDispName)
        {
            if (Is_ExistDBMailTable == false)
                return;


            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("DBMail_ConnectionString"));
            string strSql = ((db.DbProviderFactory.ToString() != "System.Data.OracleClient.OracleClientFactory") ?
                "INSERT INTO DBMail_MailSign(OutMailGuid,SignUserGuid,SignUserDispName) VALUES(@OutMailGuid,@SignUserGuid,@SignUserDispName) " :
                "INSERT INTO DBMail_MailSign(Row_ID,OutMailGuid,SignUserGuid,SignUserDispName) VALUES(SQ_DBMAIL_MAILSIGN.Nextval,:OutMailGuid,:SignUserGuid,:SignUserDispName)"
            );
            DbCommand cmd = db.GetSqlStringCommand(strSql);

            db.AddInParameter(cmd, "OutMailGuid", DbType.String, OutMailGuid);
            db.AddInParameter(cmd, "SignUserGuid", DbType.String, SignUserGuid);
            db.AddInParameter(cmd, "SignUserDispName", DbType.String, SignUserDispName);
            db.ExecuteNonQuery(cmd);
        }
    }

    #endregion
}
