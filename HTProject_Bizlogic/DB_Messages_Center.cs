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
    /// 消息处理类型
    /// </summary>
    public enum MessageType
    {
        阅读,
        办理
    }

    /// <summary>
    /// Messages_Center实体类
    /// 编写日期：2008-8-13
    /// 编写人：崔爱民
    /// <summary>
    [Serializable]
    public class Detail_Messages_Center
    {
        /// <summary>
        /// 消息唯一Guid
        /// </summary>
        private string _MessageItemGuid;

        /// <summary>
        /// 消息自增长字段
        /// </summary>
        private int _Row_ID;

        /// <summary>
        /// 消息标题
        /// </summary>
        private string _Title;

        /// <summary>
        /// 消息类型
        /// 目前区分办理和阅读。如果=阅读，则认为是阅读类型，其他系统都认为是办理类型
        /// </summary>
        private string _MessageType;

        /// <summary>
        /// 消息内容，对于 手机短信，存放的时候手机短信内容
        /// </summary>
        private string _Content;

        /// <summary>
        /// 消息分类。
        /// 待办事宜=4
        /// 手机短信=1
        /// </summary>
        private int _SendMode;

        /// <summary>
        /// 消息产生时间
        /// </summary>
        private DateTime _GenerateDate;

        /// <summary>
        /// 是否是定时消息。
        /// 对于SendMode=1的消息，有些消息需要定时发送。
        /// </summary>
        private int _IsSchedule;

        /// <summary>
        /// 定时发送的消息的消息时间
        /// </summary>
        private DateTime _ScheduleSendDate;

        /// <summary>
        /// 消息正式发送时间
        /// </summary>
        private DateTime _SendDate;

        /// <summary>
        /// 是否已发送
        /// </summary>
        private int _IsSend;

        /// <summary>
        /// 消息目标。如果是手机短信，则为接受号码；如果是邮件，则为邮件地址
        /// </summary>
        private string _MessageTarget;

        /// <summary>
        /// 消息的接收人，对于待办事宜为：待办事宜的处理人
        /// </summary>
        private string _TargetUser;

        /// <summary>
        /// 消息接收人的显示名称
        /// </summary>
        private string _TargetDispName;

        /// <summary>
        /// 消息的发送人
        /// </summary>
        private string _FromUser;

        /// <summary>
        /// 消息的发送人的显示名称
        /// </summary>
        private string _FromDispName;

        /// <summary>
        /// 发送人的手机号码，用于回复。
        /// 对sendmode=1有效
        /// </summary>
        private string _FromMobile;

        /// <summary>
        /// 备注
        /// </summary>
        private string _BeiZhu;

        /// <summary>
        /// 发送结果
        /// 备用字段
        /// </summary>
        private int _SendResult;

        /// <summary>
        /// 待办事宜类型的处理的Url地址
        /// </summary>
        private string _HandleUrl;

        /// <summary>
        /// 消息阅读时间、
        /// 备用字段
        /// </summary>
        private DateTime _ReadDate;

        /// <summary>
        /// 消息的处理时间，对于
        /// 对sendmode=4有效
        /// </summary>
        private DateTime _DoneDate;

        /// <summary>
        /// 备用字段
        /// </summary>
        private string _SourceTable;

        /// <summary>
        /// 备用字段
        /// </summary>
        private string _SourceRecordID;

        /// <summary>
        /// 消息发送人的OuGuid
        /// </summary>
        private string _OuGuid;

        /// <summary>
        /// 消息发送人的BaseOuGuid
        /// </summary>
        private string _BaseOuGuid;

        /// <summary>
        /// 是否是删除的消息
        /// 对sendmode=4有效
        /// </summary>
        private int _IsDel;

        /// <summary>
        /// 是否是不需要处理的消息
        /// 对sendmode=4有效
        /// 
        /// </summary>
        private int _IsNoHandle;

        /// <summary>
        /// 是否是需要显示的消息
        /// 对sendmode=4有效
        /// </summary>
        private int _IsShow;

        /// <summary>
        /// 消息的所属职务的Guid
        /// </summary>
        private string _JobGuid;

        /// <summary>
        /// 消息步骤名称
        /// </summary>
        private string _HandleType;

        /// <summary>
        /// 消息对应业务系统的标识
        /// </summary>
        private string _ClientIdentifier;

        /// <summary>
        /// 备用字段
        /// </summary>
        private string _ClientTag;

        /// <summary>
        /// 对与发文和收文。存放文件的文号
        /// </summary>
        private string _ArchiveNo;

        /// <summary>
        /// 对与发文和收文。存放文件的文号
        /// </summary>
        private string _PartitionTag;


        /// <summary>
        /// 超时时间点
        /// </summary>
        private DateTime _OverTimePoint;


        /// <summary>
        /// 提前预警时间点
        /// </summary>
        private DateTime _EarlyWarningPoint;


        /// <summary>
        /// 默认的类的初始化
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
        /// 消息唯一Guid
        /// </summary>
        public string MessageItemGuid
        {
            set { _MessageItemGuid = value; }
            get { return _MessageItemGuid; }
        }

        /// <summary>
        /// 消息自增长字段
        /// </summary>
        public int Row_ID
        {
            set { _Row_ID = value; }
            get { return _Row_ID; }
        }

        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        /// <summary>
        /// 消息类型
        /// 目前区分办理和阅读。如果=阅读，则认为是阅读类型，其他系统都认为是办理类型
        /// </summary>
        public string MessageType
        {
            set { _MessageType = value; }
            get { return _MessageType; }
        }

        /// <summary>
        /// 消息内容，对于 手机短信，存放的时候手机短信内容
        /// </summary>
        public string Content
        {
            set { _Content = value; }
            get { return _Content; }
        }

        /// <summary>
        ///  消息分类。
        /// 待办事宜=4
        /// 手机短信=1
        /// </summary>
        public int SendMode
        {
            set { _SendMode = value; }
            get { return _SendMode; }
        }

        /// <summary>
        ///  消息产生时间
        /// </summary>
        public DateTime GenerateDate
        {
            set { _GenerateDate = value; }
            get { return _GenerateDate; }
        }

        /// <summary>
        /// 是否是定时消息。
        /// 对于SendMode=1的消息，有些消息需要定时发送。
        /// </summary>
        public int IsSchedule
        {
            set { _IsSchedule = value; }
            get { return _IsSchedule; }
        }

        /// <summary>
        /// 定时发送的消息的消息时间
        /// </summary>
        public DateTime ScheduleSendDate
        {
            set { _ScheduleSendDate = value; }
            get { return _ScheduleSendDate; }
        }

        /// <summary>
        ///  消息正式发送时间
        /// </summary>
        public DateTime SendDate
        {
            set { _SendDate = value; }
            get { return _SendDate; }
        }

        /// <summary>
        ///  是否已发送
        /// </summary>
        public int IsSend
        {
            set { _IsSend = value; }
            get { return _IsSend; }
        }

        /// <summary>
        /// 消息目标。如果是手机短信，则为接受号码；如果是邮件，则为邮件地址
        /// </summary>
        public string MessageTarget
        {
            set { _MessageTarget = value; }
            get { return _MessageTarget; }
        }

        /// <summary>
        /// 消息的接收人，对于待办事宜为：待办事宜的处理人
        /// </summary>
        public string TargetUser
        {
            set { _TargetUser = value; }
            get { return _TargetUser; }
        }

        /// <summary>
        ///  消息接收人的显示名称
        /// </summary>
        public string TargetDispName
        {
            set { _TargetDispName = value; }
            get { return _TargetDispName; }
        }

        /// <summary>
        /// 消息的发送人
        /// </summary>
        public string FromUser
        {
            set { _FromUser = value; }
            get { return _FromUser; }
        }

        /// <summary>
        /// 消息的发送人的显示名称
        /// </summary>
        public string FromDispName
        {
            set { _FromDispName = value; }
            get { return _FromDispName; }
        }

        /// <summary>
        /// 发送人的手机号码，用于回复。
        /// 对sendmode=1有效
        /// </summary>
        public string FromMobile
        {
            set { _FromMobile = value; }
            get { return _FromMobile; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string BeiZhu
        {
            set { _BeiZhu = value; }
            get { return _BeiZhu; }
        }

        /// <summary>
        /// 发送结果
        /// 备用字段
        /// </summary>
        public int SendResult
        {
            set { _SendResult = value; }
            get { return _SendResult; }
        }

        /// <summary>
        /// 待办事宜类型的处理的Url地址
        /// </summary>
        public string HandleUrl
        {
            set { _HandleUrl = value; }
            get { return _HandleUrl; }
        }

        /// <summary>
        /// 消息阅读时间、
        /// 备用字段
        /// </summary>
        public DateTime ReadDate
        {
            set { _ReadDate = value; }
            get { return _ReadDate; }
        }

        /// <summary>
        /// 消息的处理时间，对于
        /// 对sendmode=4有效
        /// </summary>
        public DateTime DoneDate
        {
            set { _DoneDate = value; }
            get { return _DoneDate; }
        }

        /// <summary>
        /// 备用字段
        /// </summary>
        public string SourceTable
        {
            set { _SourceTable = value; }
            get { return _SourceTable; }
        }

        /// <summary>
        /// 备用字段
        /// </summary>
        public string SourceRecordID
        {
            set { _SourceRecordID = value; }
            get { return _SourceRecordID; }
        }

        /// <summary>
        /// 消息发送人的OuGuid
        /// </summary>
        public string OuGuid
        {
            set { _OuGuid = value; }
            get { return _OuGuid; }
        }

        /// <summary>
        /// 消息发送人的BaseOuGuid
        /// </summary>
        public string BaseOuGuid
        {
            set { _BaseOuGuid = value; }
            get { return _BaseOuGuid; }
        }

        /// <summary>
        /// 是否是删除的消息
        /// 对sendmode=4有效
        /// </summary>
        public int IsDel
        {
            set { _IsDel = value; }
            get { return _IsDel; }
        }

        /// <summary>
        /// 是否是不需要处理的消息
        /// 对sendmode=4有效
        /// </summary>
        public int IsNoHandle
        {
            set { _IsNoHandle = value; }
            get { return _IsNoHandle; }
        }

        /// <summary>
        /// 是否是需要显示的消息
        /// 对sendmode=4有效
        /// </summary>
        public int IsShow
        {
            set { _IsShow = value; }
            get { return _IsShow; }
        }

        /// <summary>
        /// 消息的所属职务的Guid
        /// </summary>
        public string JobGuid
        {
            set { _JobGuid = value; }
            get { return _JobGuid; }
        }

        /// <summary>
        /// 消息步骤名称
        /// </summary>
        public string HandleType
        {
            set { _HandleType = value; }
            get { return _HandleType; }
        }

        /// <summary>
        /// 消息对应业务系统的标识
        /// </summary>
        public string ClientIdentifier
        {
            set { _ClientIdentifier = value; }
            get { return _ClientIdentifier; }
        }

        /// <summary>
        /// 备用字段
        /// </summary>
        public string ClientTag
        {
            set { _ClientTag = value; }
            get { return _ClientTag; }
        }

        /// <summary>
        ///  对与发文和收文。存放文件的文号
        /// </summary>
        public string ArchiveNo
        {
            set { _ArchiveNo = value; }
            get { return _ArchiveNo; }
        }

        /// <summary>
        ///  对与发文和收文。存放文件的文号
        /// </summary>
        public string PartitionTag
        {
            set { _PartitionTag = value; }
            get { return _PartitionTag; }
        }

        /// <summary>
        ///  超时时间点
        /// </summary>
        public DateTime OverTimePoint
        {
            set { _OverTimePoint = value; }
            get { return _OverTimePoint; }
        }

        /// <summary>
        ///  提前预警时间点
        /// </summary>
        public DateTime EarlyWarningPoint
        {
            set { _EarlyWarningPoint = value; }
            get { return _EarlyWarningPoint; }
        }

    }//class

    /// <summary>
    /// 对消息中心DB_Messages_Center的一些处理
    /// </summary>
    public class DB_Messages_Center
    {

        /// <summary>
        /// 定义DB_Messages_Center_Histroy
        /// </summary>
        DB_Messages_Center_Histroy MsgHistroy = new DB_Messages_Center_Histroy();




        /// <summary>
        /// 根据消息唯一Guid获取信息
        /// 编写日期：2008-8-13
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid</param>
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
        /// 根据业务标识ClientIdentifier，取得待办事宜明细
        /// 编写日期：2008-7-29
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="ClientIdentifier">业务标识ClientIdentifier</param>
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
        /// 根据MessageItemGuid从转移历史消息表Messages_Center_Histroy中的消息到待办消息表Messages_Center中 ，转移成功后，删除表Messages_Center中的此消息
        /// 编写日期：2008-8-13
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid</param>
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
        /// 根据BeiZhu 和 ClientIdentifier 获取消息列表
        /// 对应sql:SELECT  * FROM Messages_Center WHERE  BeiZhu=@BeiZhu AND ClientIdentifier=@ClientIdentifier
        /// 编写日期：2007-10-17
        /// 编写人：李书喜
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
        /// 取得待办事宜的信息类别
        /// sql语句：SELECT distinct HandleType FROM Messages_Center where HandleType<> null 
        /// 崔爱民
        /// 2007－10－15
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
        /// 添加消息方法(待办事宜类型)
        /// 崔爱民添加，导入数据的使用，其他地方不使用
        /// 如果是发送给用户的，则TargetUser!="",JobGuid="";如果是发送给职位的，则TargetUser="",JobGuid!="";。
        /// 系统判断：如果JobGuid!="",则系统会自动是TargetUser="";
        /// 编写日期：2007-4-23
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid,由业务系统产生Guid</param>
        /// <param name="Title">消息标题</param>
        /// <param name="TargetUser">消息目标用户名UserGuid。（接收用户在系统中的唯一标识），</param>
        /// <param name="TargetDispName">消息目标用户名的显示名称DispName。（接收用户在系统中的唯一标识），</param>
        /// <param name="FromUser">消息来自于,发送用户的UserGuid。如果为空，则为当前用户的UserGuid</param>
        /// <param name="FromDispName">消息发送人的显示名称。如果为空，则为当前用户的显示名称</param>
        /// <param name="CurrentActivityStepName">当前处理步骤名称</param>
        /// <param name="HandleUrl">如果是待办事宜，显示对应的处理URL，指从虚拟目录往后的Url，不包括虚拟目录名称，在插入url的时候，需要把此条记录的MessageItemGuid作为参数附加在url的后面</param>
        /// <param name="OuGuid">用户所在部门的OuGuid,用Session["OUGuid"]。如果为空，则为当前用户的OUGuid</param>
        /// <param name="BaseOuGuid">用户所在独立管理部门的OuGuid,用Session["BaseOUGuid"]。如果为空，则为当前用户的BaseOUGuid </param>
        /// <param name="IsShow">是否在代办事宜中显示，如果＝0，则不显示，否则显示，默认为1</param>
        /// <param name="JobGuid">对应的职位Guid</param>
        /// <param name="HandleType">此待办事宜对应的分类</param>
        /// <param name="ClientIdentifier">业务系统所系统的待办事宜信息</param>
        /// <returns>Boolean</returns>
        public Boolean WaitHandle_Insert(string MessageItemGuid, string Title, string MessageType, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string CurrentActivityStepName, string HandleUrl, string OuGuid, string BaseOuGuid, int IsShow, string JobGuid, string HandleType, string ClientIdentifier)
        {
            return this.WaitHandle_Insert(MessageItemGuid, Title, MessageType, TargetUser, TargetDispName, FromUser, FromDispName, CurrentActivityStepName, HandleUrl, OuGuid, BaseOuGuid, IsShow, JobGuid, HandleType, ClientIdentifier, "");
        }

        /// <summary>
        /// 添加消息方法(待办事宜类型)
        /// 如果是发送给用户的，则TargetUser!="",JobGuid="";如果是发送给职位的，则TargetUser="",JobGuid!="";。
        /// 系统判断：如果JobGuid!="",则系统会自动是TargetUser="";
        /// 编写日期：2007-4-23
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid,由业务系统产生Guid</param>
        /// <param name="Title">消息标题</param>
        /// <param name="TargetUser">消息目标用户名UserGuid。（接收用户在系统中的唯一标识），</param>
        /// <param name="TargetDispName">消息目标用户名的显示名称DispName。（接收用户在系统中的唯一标识），</param>
        /// <param name="FromUser">消息来自于,发送用户的UserGuid。如果为空，则为当前用户的UserGuid</param>
        /// <param name="FromDispName">消息发送人的显示名称。如果为空，则为当前用户的显示名称</param>
        /// <param name="CurrentActivityStepName">当前处理步骤名称</param>
        /// <param name="HandleUrl">如果是待办事宜，显示对应的处理URL，指从虚拟目录往后的Url，不包括虚拟目录名称，在插入url的时候，需要把此条记录的MessageItemGuid作为参数附加在url的后面</param>
        /// <param name="OuGuid">用户所在部门的OuGuid,用Session["OUGuid"]。如果为空，则为当前用户的OUGuid</param>
        /// <param name="BaseOuGuid">用户所在独立管理部门的OuGuid,用Session["BaseOUGuid"]。如果为空，则为当前用户的BaseOUGuid </param>
        /// <param name="IsShow">是否在代办事宜中显示，如果＝0，则不显示，否则显示，默认为1</param>
        /// <param name="JobGuid">对应的职位Guid</param>
        /// <param name="HandleType">此待办事宜对应的分类</param>
        /// <param name="ClientIdentifier">业务系统所系统的待办事宜信息</param>
        /// <returns>Boolean</returns>
        public Boolean WaitHandle_Insert(string MessageItemGuid, string Title, string MessageType, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string CurrentActivityStepName, string HandleUrl, string OuGuid, string BaseOuGuid, int IsShow, string JobGuid, string HandleType, string ClientIdentifier, DateTime GenerateDate)
        {
            return this.WaitHandle_Insert(MessageItemGuid, Title, MessageType, TargetUser, TargetDispName, FromUser, FromDispName, CurrentActivityStepName, HandleUrl, OuGuid, BaseOuGuid, IsShow, JobGuid, HandleType, ClientIdentifier, "", GenerateDate, "");

            #region 屏蔽
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
            //    Title = "无标题";

            //if(MessageType == null || MessageType == "")
            //    MessageType = "办理";

            //if(MessageType != "办理")
            //    MessageType = "阅读";

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
        /// 添加消息方法(待办事宜类型)
        /// 崔爱民添加，导入数据的使用，其他地方不使用
        /// 如果是发送给用户的，则TargetUser!="",JobGuid="";如果是发送给职位的，则TargetUser="",JobGuid!="";。
        /// 系统判断：如果JobGuid!="",则系统会自动是TargetUser="";
        /// 编写日期：2007-4-23
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid,由业务系统产生Guid</param>
        /// <param name="Title">消息标题</param>
        /// <param name="TargetUser">消息目标用户名UserGuid。（接收用户在系统中的唯一标识），</param>
        /// <param name="TargetDispName">消息目标用户名的显示名称DispName。（接收用户在系统中的唯一标识），</param>
        /// <param name="FromUser">消息来自于,发送用户的UserGuid。如果为空，则为当前用户的UserGuid</param>
        /// <param name="FromDispName">消息发送人的显示名称。如果为空，则为当前用户的显示名称</param>
        /// <param name="CurrentActivityStepName">当前处理步骤名称</param>
        /// <param name="HandleUrl">如果是待办事宜，显示对应的处理URL，指从虚拟目录往后的Url，不包括虚拟目录名称，在插入url的时候，需要把此条记录的MessageItemGuid作为参数附加在url的后面</param>
        /// <param name="OuGuid">用户所在部门的OuGuid,用Session["OUGuid"]。如果为空，则为当前用户的OUGuid</param>
        /// <param name="BaseOuGuid">用户所在独立管理部门的OuGuid,用Session["BaseOUGuid"]。如果为空，则为当前用户的BaseOUGuid </param>
        /// <param name="IsShow">是否在代办事宜中显示，如果＝0，则不显示，否则显示，默认为1</param>
        /// <param name="JobGuid">对应的职位Guid</param>
        /// <param name="HandleType">此待办事宜对应的分类</param>
        /// <param name="ClientIdentifier">业务系统所系统的待办事宜信息</param>
        /// <returns>Boolean</returns>
        public Boolean WaitHandle_Insert(string MessageItemGuid, string Title, string MessageType, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string CurrentActivityStepName, string HandleUrl, string OuGuid, string BaseOuGuid, int IsShow, string JobGuid, string HandleType, string ClientIdentifier, string ClientTag)
        {
            DateTime GenerateDate = new DateTime(1, 1, 1);
            return this.WaitHandle_Insert(MessageItemGuid, Title, MessageType, TargetUser, TargetDispName, FromUser, FromDispName, CurrentActivityStepName, HandleUrl, OuGuid, BaseOuGuid, IsShow, JobGuid, HandleType, ClientIdentifier, ClientTag, GenerateDate, "");

            #region 屏蔽
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
            //    Title = "无标题";

            //if(MessageType == null || MessageType == "")
            //    MessageType = "办理";

            //if(MessageType == "阅读")
            //    MessageType = "阅读";
            //else
            //    MessageType = "办理";

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
        /// 添加消息方法(待办事宜类型)
        /// 崔爱民添加，导入数据的使用，其他地方不使用
        /// 如果是发送给用户的，则TargetUser!="",JobGuid="";如果是发送给职位的，则TargetUser="",JobGuid!="";。
        /// 系统判断：如果JobGuid!="",则系统会自动是TargetUser="";
        /// 编写日期：2007-4-23
        /// 编写人：崔爱民
        /// 修改日期：2010-4-16
        /// 修改人：周剑峰
        /// 修改内容：调下面一个重载方法
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid,由业务系统产生Guid</param>
        /// <param name="Title">消息标题</param>
        /// <param name="TargetUser">消息目标用户名UserGuid。（接收用户在系统中的唯一标识），</param>
        /// <param name="TargetDispName">消息目标用户名的显示名称DispName。（接收用户在系统中的唯一标识），</param>
        /// <param name="FromUser">消息来自于,发送用户的UserGuid。如果为空，则为当前用户的UserGuid</param>
        /// <param name="FromDispName">消息发送人的显示名称。如果为空，则为当前用户的显示名称</param>
        /// <param name="CurrentActivityStepName">当前处理步骤名称</param>
        /// <param name="HandleUrl">如果是待办事宜，显示对应的处理URL，指从虚拟目录往后的Url，不包括虚拟目录名称，在插入url的时候，需要把此条记录的MessageItemGuid作为参数附加在url的后面</param>
        /// <param name="OuGuid">用户所在部门的OuGuid,用Session["OUGuid"]。如果为空，则为当前用户的OUGuid</param>
        /// <param name="BaseOuGuid">用户所在独立管理部门的OuGuid,用Session["BaseOUGuid"]。如果为空，则为当前用户的BaseOUGuid </param>
        /// <param name="IsShow">是否在代办事宜中显示，如果＝0，则不显示，否则显示，默认为1</param>
        /// <param name="JobGuid">对应的职位Guid</param>
        /// <param name="HandleType">此待办事宜对应的分类</param>
        /// <param name="ClientIdentifier">业务系统所系统的待办事宜信息</param>
        /// <param name="ClientTag">标识</param>
        /// <param name="GenerateDate">消息产生时间</param>
        /// <param name="PVIGuid">消息对应的流程实例Guid</param>
        /// <returns>Boolean</returns>
        public Boolean WaitHandle_Insert(string MessageItemGuid, string Title, string MessageType, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string CurrentActivityStepName, string HandleUrl, string OuGuid, string BaseOuGuid, int IsShow, string JobGuid, string HandleType, string ClientIdentifier, string ClientTag, DateTime GenerateDate, String PVIGuid)
        {
            return WaitHandle_Insert(MessageItemGuid, Title, MessageType, TargetUser, TargetDispName, FromUser, FromDispName, CurrentActivityStepName, HandleUrl, OuGuid, BaseOuGuid, IsShow, JobGuid, HandleType, ClientIdentifier, ClientTag, GenerateDate, PVIGuid, DateTime.MinValue, DateTime.MinValue);

            #region 屏蔽
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
            //    Title = "无标题";

            //if (MessageType == null || MessageType == "")
            //    MessageType = "办理";

            //if (MessageType == "阅读")
            //    MessageType = "阅读";
            //else
            //    MessageType = "办理";

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
        /// 增加待办的需要办理时间字段overtimepoint　　　　earlywarningpoint　
        /// 编写日期：2010-4-16
        /// 编写人：周剑峰
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid,由业务系统产生Guid</param>
        /// <param name="Title">消息标题</param>
        /// <param name="TargetUser">消息目标用户名UserGuid。（接收用户在系统中的唯一标识），</param>
        /// <param name="TargetDispName">消息目标用户名的显示名称DispName。（接收用户在系统中的唯一标识），</param>
        /// <param name="FromUser">消息来自于,发送用户的UserGuid。如果为空，则为当前用户的UserGuid</param>
        /// <param name="FromDispName">消息发送人的显示名称。如果为空，则为当前用户的显示名称</param>
        /// <param name="CurrentActivityStepName">当前处理步骤名称</param>
        /// <param name="HandleUrl">如果是待办事宜，显示对应的处理URL，指从虚拟目录往后的Url，不包括虚拟目录名称，在插入url的时候，需要把此条记录的MessageItemGuid作为参数附加在url的后面</param>
        /// <param name="OuGuid">用户所在部门的OuGuid,用Session["OUGuid"]。如果为空，则为当前用户的OUGuid</param>
        /// <param name="BaseOuGuid">用户所在独立管理部门的OuGuid,用Session["BaseOUGuid"]。如果为空，则为当前用户的BaseOUGuid </param>
        /// <param name="IsShow">是否在代办事宜中显示，如果＝0，则不显示，否则显示，默认为1</param>
        /// <param name="JobGuid">对应的职位Guid</param>
        /// <param name="HandleType">此待办事宜对应的分类</param>
        /// <param name="ClientIdentifier">业务系统所系统的待办事宜信息</param>
        /// <param name="ClientTag">标识</param>
        /// <param name="GenerateDate">消息产生时间</param>
        /// <param name="PVIGuid">消息对应的流程实例Guid</param>
        /// <param name="Overtimepoint">超期时间</param>
        /// <param name="Earlywarningpoint">提前警告时间</param>
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
                Title = "无标题";

            if (MessageType == null || MessageType == "")
                MessageType = "办理";

            if (MessageType == "阅读")
                MessageType = "阅读";
            else
                MessageType = "办理";

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
        /// 添加消息方法(For导入数据功能，其他地方不使用)
        /// 编写人：崔爱民
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
                Title = "无标题";

            if (MessageType == null || MessageType == "")
                MessageType = "办理";

            if (MessageType != "办理")
                MessageType = "阅读";

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
        /// 删除消息，此删除用在流程中收回，则此消息在待办事宜、已办事宜、已删除事宜中都不可见
        /// sql中操作：根据MessageItemGuid更新IsNoHandle，并转移到历史库中   ；UPDATE Messages_Center SET IsNoHandle=@IsNoHandle WHERE  MessageItemGuid=@MessageItemGuid
        /// 编写日期：2007-9-3
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid</param>
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

            //更新后，转移消息到已处理表中
            MsgHistroy.Move_WaitHandleToHistroy(MessageItemGuid);
        }

        /// <summary>
        /// 更新此消息的状态，让此消息在代办事宜中显示   ,只更新状态，不做其他任何处理
        /// sql中操作：根据MessageItemGuid更新IsShow  ；UPDATE Messages_Center SET IsShow=@IsShow WHERE  MessageItemGuid=@MessageItemGuid
        /// 编写日期：2007-10-8
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid</param>
        /// <param name="IsShow">是否可以显示</param>
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
        /// 更新此消息的ClientIdentifier ； 根据MessageItemGuid只更新ClientIdentifier，不做其他任何处理
        /// sql：UPDATE Messages_Center SET ClientIdentifier=@ClientIdentifier WHERE  MessageItemGuid=@MessageItemGuid
        /// 编写日期：2008-5-24
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid</param>
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
        /// 更改消息的Title  ，同时更新表:Messages_Center和Messages_Center_Histroy
        /// 编写日期：2007-9-5
        /// 编写人：袁勋
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid</param>
        /// <param name="Title">Title</param>
        public void WaitHandle_UpdateTitle(string MessageItemGuid, string Title)
        {
            //为防止消息已被转移到历史表，同时更新Messages_Center_Histroy
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
        /// 更新
        /// UPDATE Messages_Center SET TargetUser=@newTargetUser WHERE  TargetUser=@oldTargetUser  UPDATE Messages_Center_Histroy SET TargetUser=@newTargetUser WHERE  TargetUser=@oldTargetUser
        /// </summary>
        /// <param name="newTargetUser"></param>
        /// <param name="oldTargetUser"></param>
        public void WaitHandle_UpdateTargetUser(string newTargetUser, string oldTargetUser)
        {
            //为防止消息已被转移到历史表，同时更新Messages_Center_Histroy
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
        /// 根据TargetUser取得当前用户所有的未办事宜数量
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="TargetUser">消息所属人</param>
        /// <param name="DateFromTo">开始时间</param>
        /// <param name="DateTo">结束时间</param>
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
        /// 根据MessageItemGuid更新MessageType
        /// sql：UPDATE Messages_Center SET MessageType=@MessageType WHERE  MessageItemGuid=@MessageItemGuid 
        /// 编写日期：2007-9-5
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid</param>
        /// <param name="MessageType">MessageType</param>
        public void WaitHandle_UpdateMessageType(string MessageItemGuid, string MessageType)
        {
            //为防止消息已被转移到历史表，同时更新Messages_Center_Histroy
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
        /// 在处理完成的时候，更新待办事宜的处理状态，表示此消息已经处理,方法中，包括了对已处理待办事宜的过滤，更新成功后，转移到历史表中
        /// 处理时间为系统当前时间
        /// 编写日期：2007-9-3
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息Guid</param>
        /// <param name="DoneDate">DoneDate</param>
        public void WaitHandle_UpdateHandle(string MessageItemGuid, DateTime DoneDate)
        {
            //判断是否已处理
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

                //处理后，转移消息到已处理表中
                MsgHistroy.Move_WaitHandleToHistroy(MessageItemGuid);
            }
        }

        /// <summary>
        /// 在处理完成的时候，更新待办事宜的处理状态，表示此消息已经处理,方法中，包括了对已处理待办事宜的过滤，更新成功后，转移到历史表中
        /// 处理时间为系统当前时间
        /// 编写日期：2007-9-3
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息Guid</param>
        /// <param name="DoneDate">DoneDate</param>
        /// <param name="OperatorGuid">OperatorGuid</param>
        /// <param name="OperatorForDisplayGuid">OperatorForDisplayGuid</param>
        public void WaitHandle_UpdateHandle(string MessageItemGuid, DateTime DoneDate, string OperatorGuid, string OperatorForDisplayGuid)
        {
            //判断是否已处理
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

                //处理后，转移消息到已处理表中
                MsgHistroy.Move_WaitHandleToHistroy(MessageItemGuid);
            }
        }

        /// <summary>
        /// 把已办事项中的记录转移到未办事项中
        /// 编写日期：2008-8-13
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息Guid</param>
        public void WaitHandle_MoveToNoHandle(string MessageItemGuid)
        {
            //判断在已办事项中是否存在
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

                //处理后，转移消息到未处理表中
                Move_WaitHandleFromhistoryToHandle(MessageItemGuid);
            }
        }

        /// <summary>
        /// 用户在待办事宜、已办事宜中删除消息 ，操作成功后，转移到历史表中
        /// sql:   UPDATE Messages_Center SET IsDel=@IsDel WHERE  MessageItemGuid=@MessageItemGuid
        /// 编写日期：2007-9-3
        /// 编写人：崔爱民
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

            //处理后，转移消息到已处理表中
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
                //处理后，转移消息到已处理表中
                MsgHistroy.Move_WaitHandleToHistroy(DV[m]["MessageItemGuid"].ToString());
            }
        }

        /// <summary>
        /// 用户在已办事宜中删除消息
        /// sql操作：UPDATE Messages_Center_Histroy SET IsDel=@IsDel WHERE  MessageItemGuid=@MessageItemGuid
        /// 编写日期：2007-9-3
        /// 编写人：崔爱民
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
        /// 用户在待办事宜、已办事宜中删除消息   ,彻底删除消息
        /// sql:delete from Messages_Center WHERE  MessageItemGuid=@MessageItemGuid  delete from Messages_Center_Histroy WHERE  MessageItemGuid=@MessageItemGuid
        /// 编写日期：2007-9-3
        /// 编写人：崔爱民
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
        /// 根据MessageItemGuid 更新 ArchiveNo
        /// 编写日期：2008-9-9
        /// 编写人：崔爱民
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
        /// 根据MessageItemGuid 更新 NoNeedRemind
        /// 编写日期：2008-9-9
        /// 编写人：崔爱民
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
        /// 取得未处理的待办事宜
        /// 只取办理的，其他的不显示
        /// 崔爱民
        /// 2007－10－13
        /// </summary>
        /// <param name="OwnerUserGuid">用户的UserGuid</param>
        /// <param name="JobList">用户对应的职位列表</param> 
        /// <param name="Rows">需要取得条数</param>
        /// <returns></returns>
        public DataView GetNewsWaitHandleTop_SuzhouJSJ(string OwnerUserGuid, string JobList, int Rows)
        {
            string SuzhouJSJ_ClientIdentifierLst = ApplicationOperate.GetConfigValueByName("SuzhouJSJ_ClientIdentifierLst");

            string str_Sql = "select top " + Rows.ToString() + " Title ,MessageItemGuid,MessageType,FromDispName,GenerateDate,BeiZhu,HandleUrl,OverTimePoint,EarlyWarningPoint from Messages_Center where   SendMode=4 and  DoneDate is null and IsShow = 1 ";
            if (SuzhouJSJ_ClientIdentifierLst != null && SuzhouJSJ_ClientIdentifierLst != "")
                str_Sql += " and ClientIdentifier not in (" + SuzhouJSJ_ClientIdentifierLst + ") ";
            str_Sql += " and ClientTag<>'档案借阅' ";

            if (JobList != "")
                str_Sql += " and ( TargetUser = '" + OwnerUserGuid + "' or  CHARINDEX(JobGuid,'" + JobList + "')<>0 ) ";
            else
                str_Sql += " and ( TargetUser = '" + OwnerUserGuid + "' ) ";

            str_Sql += " order by  Row_ID desc ";

            string str_Oracle = "select  Title ,MessageItemGuid,MessageType,FromDispName,GenerateDate,HandleUrl,BeiZhu from Messages_Center,OverTimePoint,EarlyWarningPoint where   SendMode=4 and  DoneDate is null and IsShow = 1 ";
            if (SuzhouJSJ_ClientIdentifierLst != null && SuzhouJSJ_ClientIdentifierLst != "")
                str_Oracle += " and ClientIdentifier not in (" + SuzhouJSJ_ClientIdentifierLst + ") ";
            str_Oracle += " and ClientTag<>'档案借阅' ";

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
        /// 取得未处理的待办事宜
        /// 只取办理的，其他的不显示
        /// 崔爱民
        /// 2007－10－13
        /// </summary>
        /// <param name="OwnerUserGuid">用户的UserGuid</param>
        /// <param name="JobList">用户对应的职位列表</param> 
        /// <param name="Rows">需要取得条数</param>
        /// <returns>DataView</returns>
        public DataView GetNewsWaitHandleTop(string OwnerUserGuid, string JobList, int Rows)
        {
            bool IfShowRead = false;
            if (ApplicationOperate.WaitHandle_IsShowRead)
                IfShowRead = true;

            return GetNewsWaitHandleTop(OwnerUserGuid, JobList, Rows, "", "", IfShowRead, "");
        }
        /// <summary>
        /// 取得未处理的待办事宜HandleType类别及数量
        /// 周剑峰
        /// 2010－4－13
        /// </summary>
        /// <param name="OwnerUserGuid">用户的UserGuid</param>
        /// <param name="JobList">用户对应的职位列表</param> 
        /// <param name="Rows">需要取得条数</param>
        /// <param name="ClientIdentifier">对应的类型</param>
        /// <returns>DataView</returns>
        public DataView GetNewsWaitHandleTypes(string OwnerUserGuid, string JobList, int Rows, string ClientIdentifier, string ClientTag, Boolean IfShowRead)
        {
            //所以待办事宜
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

            //判断JobList是否为空，如果不为空，说明此人有职位配置
            if (JobList != "")
                str_Sql += " or ( JobGuid in ( SELECT  JobGuid FROM Frame_Job WHERE  BelongUserGuid='" + OwnerUserGuid + "')) ";
            str_Sql += " ) ";

            //if (!IfShowRead)
            //    str_Sql += "and MessageType = '办理' ";
            //else
            //    str_Sql += "and ( MessageType = '办理' or MessageType = '阅读' ) ";

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

            //添加类别
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
            //判断是否还有其它
            foreach (DataRow tmp in allTypes.Table.Rows)
                otherNum += int.Parse(tmp["cnt"].ToString());
            if (otherNum > 0 && dt.Rows.Count > 0)//当没有分类时，也不需要其它这个分类
            {
                DataRow newrow = dt.NewRow();
                newrow["handletype"] = "其它";
                newrow["cnt"] = otherNum;
                dt.Rows.Add(newrow);
            }
            return dt.DefaultView;
        }

        /// <summary>
        /// 根据HandleType取得未处理的待办事宜
        /// 周剑峰
        /// 2010－4－13
        /// </summary>
        /// <param name="OwnerUserGuid">用户的UserGuid</param>
        /// <param name="JobList">用户对应的职位列表</param> 
        /// <param name="Rows">需要取得条数</param>
        /// <param name="ClientIdentifier">对应的类型</param>
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

            //判断JobList是否为空，如果不为空，说明此人有职位配置
            if (JobList != "")
                str_Sql += " or ( JobGuid in ( SELECT  JobGuid FROM Frame_Job WHERE  BelongUserGuid='" + OwnerUserGuid + "')) ";
            str_Sql += " ) ";

            //if (!IfShowRead)
            //    str_Sql += "and MessageType = '办理' ";
            //else
            //    str_Sql += "and ( MessageType = '办理' or MessageType = '阅读' ) ";
            if (HandleType != "其它")
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

        #region 待办事宜类别管理
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
        /// 判断类型是否存在
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public bool IsHandleTypeExixt(string typeName)
        {
            return DB.ExecuteToInt("select count(*) from Frame_WaitHandletypes where handletypeName='" + typeName + "'") > 0;
        }

        /// <summary>
        /// 添加类型
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="orderNum"></param>
        public void AddHanleType(string typeName, int orderNum)
        {
            DB.ExecuteNonQuery("insert into Frame_WaitHandletypes(typeguid,handletypename,ordernumber,adddate) " +
                "values('" + Guid.NewGuid().ToString() + "','" + typeName + "'," + orderNum + ",getdate())");
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="Typeguid"></param>
        public void DelHandleType(string Typeguid)
        {
            DB.ExecuteNonQuery("delete from Frame_WaitHandletypes where typeguid='" + Typeguid + "'");
        }

        /// <summary>
        /// 更新类别
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
        /// 同步类别
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
        /// 取得未处理的待办事宜
        /// 只取办理的，其他的不显示
        /// 崔爱民
        /// 2007－10－13
        /// 
        /// 20080919增加了消息中心的过滤
        /// </summary>
        /// <param name="OwnerUserGuid">用户的UserGuid</param>
        /// <param name="JobList">用户对应的职位列表</param> 
        /// <param name="Rows">需要取得条数</param>
        /// <param name="ClientIdentifier">对应的类型</param>
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


            //判断JobList是否为空，如果不为空，说明此人有职位配置
            if (JobList != "")
                str_Sql += " or ( JobGuid in ( SELECT  JobGuid FROM Frame_Job WHERE  BelongUserGuid='" + OwnerUserGuid + "')) ";
            str_Sql += " ) ";

            if (!IfShowRead)
                str_Sql += "and MessageType = '办理' ";
            else
                str_Sql += "and ( MessageType = '办理' or MessageType = '阅读' ) ";
            //此处要加上类别
            //if (PType == "1")//默认的要显示OA的一些内容
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

            //此处要加上类别
            if (PType == "1")//默认的要显示OA的一些内容，这个是最基础的
            {
                //sb.Append(" (and ProcessGuid='' or ");
                return " and ( ProcessGuid is null or ProcessGuid in (" + sb.ToString() + ") ) ";
            }
            else if (PType == "2")//要显示任务单
            { return " and ( ProcessGuid='rwd' or ProcessGuid in (" + sb.ToString() + ") ) "; }
            else if (PType == "3")//抽查记录、整改、停工
            { return " and ( ProcessGuid in (" + sb.ToString() + ") ) "; }
            else if (PType == "4")//要显示其他写入的待办
            { return " and ( ProcessGuid='qt' or ProcessGuid in (" + sb.ToString() + ") ) "; }
            else
                return " and ( ProcessGuid in (" + sb.ToString() + ") ) ";
        }


        /// <summary>
        /// 取得未处理的待办事宜数量
        /// 崔爱民
        /// </summary>
        /// <param name="OwnerUserGuid">用户的UserGuid</param>
        /// <param name="JobList">用户对应的职位列表</param> 
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
        /// 取得消息中心中的消息列表
        /// </summary>
        /// <param name="TargetUser">信息所有人</param>
        /// <param name="JobList">用户对应的职位列表</param>
        /// <param name="IsDel">信息状态</param>
        /// <param name="DateFromTo">信息开始时间</param>
        /// <param name="DateTo">信息结束时间</param>
        /// <param name="txtTitle">标题</param>
        /// <param name="HandleType">消息类别</param>
        /// <param name="TableName">表名</param>
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
        /// 取得消息中心中的消息列表
        /// </summary>
        /// <param name="TargetUser">信息所有人</param>
        /// <param name="JobList">用户对应的职位列表</param>
        /// <param name="IsDel">信息状态</param>
        /// <param name="DateFromTo">信息开始时间</param>
        /// <param name="DateTo">信息结束时间</param>
        /// <param name="txtTitle">标题</param>
        /// <param name="HandleType">消息类别</param>
        /// <param name="TableName">表名</param>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPageIndex"></param>
        /// <param name="OrderBy"></param>
        /// <param name="TotalNum"></param>
        /// <param name="ShowType">获取代办事宜或已办事宜模型.显示类型。1：不显示代办，只显示本人的代办事宜；2：只显示代办的，不显示本人的代办事宜；3：本人和代办人员的都显示</param>
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
            //判断JobList是否为空，如果不为空，说明此人有职位配置

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
                if (MessageType == "办理")
                    sql += "and  MessageType = '办理' ";
                else
                    sql += "and MessageType = '" + SQLOperate.ReplaceSql(MessageType) + "' ";
            }

            //此处要加上类别
            //if (PType == "1")//默认的要显示OA的一些内容
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
        /// 取得消息中心中的消息列表
        /// </summary>
        /// <param name="TargetUser">信息所有人</param>
        /// <param name="JobList">用户对应的职位列表</param>
        /// <param name="MessageType">消息类型</param>
        /// <returns>DataView</returns>
        public DataView WaitHandle_GetMessageView(string TargetUser, string JobList, string MessageType, string ClientIdentifier, string PType)
        {
            return this.WaitHandle_GetMessageView("*", -1, TargetUser, JobList, MessageType, ClientIdentifier, PType);
        }


        /// <summary>
        /// 取得消息中心中的消息列表
        /// 崔爱民
        /// </summary>
        /// <param name="strCols">返回的表列</param>
        /// <param name="NoNeedRemind">是否需要提醒的消息。-1：所有消息；0：需要提醒的消息；1，不需要提醒的消息</param>
        /// <param name="TargetUser">信息所有人</param>
        /// <param name="JobList">用户对应的职位列表</param>
        /// <param name="MessageType">消息类型</param>
        /// <param name="ClientIdentifier">消息的特殊标示，多个中间用; 分开，如果不包含，前面用!</param>
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

            //判断JobList是否为空，如果不为空，说明此人有职位配置
            if (JobList != "")
                sql += " or ( JobGuid in ( SELECT  JobGuid FROM Frame_Job WHERE  BelongUserGuid='" + TargetUser + "')) ";
            sql += " ) ";

            MessageType = MessageType.Trim(';');
            if (MessageType.IndexOf(";") > 0)
                sql += " and  MessageType in ('" + MessageType.Replace(";", "','") + "') ";
            else
            {
                if (MessageType == "办理" || MessageType == "")
                    sql += " and MessageType = '办理' ";
                else
                    sql += "and MessageType = '" + SQLOperate.ReplaceSql(MessageType) + "' ";
            }

            //此处要加上类别
            if (PType != "")//默认的要显示OA的一些内容
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
        /// 取得消息中心中的消息列表
        /// </summary>
        /// <param name="TargetUser">信息所有人</param>
        /// <param name="JobList">用户对应的职位列表</param>
        /// <param name="MessageType">消息类型</param>
        /// <returns>int</returns>
        public int WaitHandle_GetMessageCount(string TargetUser, string JobList, string MessageType, string ClientIdentifier, string PType)
        {
            return this.WaitHandle_GetMessageView(TargetUser, JobList, MessageType, ClientIdentifier, PType).Count;
        }

        /// <summary>
        /// 取得消息中心中的消息列表
        /// </summary>
        /// <param name="TargetUser">信息所有人</param>
        /// <param name="JobList">用户对应的职位列表</param>
        /// <param name="MessageType">消息类型</param>
        /// <returns>int</returns>
        public int WaitHandle_GetMessageCount(string TargetUser, string JobList, string MessageType, string PType)
        {
            return WaitHandle_GetMessageCount(TargetUser, JobList, MessageType, "", PType);
        }

        /// <summary>
        /// 添加消息方法(手机短信类型)
        /// 编写日期：2007-9-3
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid</param>
        /// <param name="Content">消息内容，如果是手机短信，存储短信内容</param>
        /// <param name="GenerateDate">消息产生时间</param>
        /// <param name="IsSchedule">是否定时发送。0：否，立即发送；1：是，定时发送</param>
        /// <param name="ScheduleSendDate">计划发送时间。对于立即发送的消息，此字段没有意义</param>
        /// <param name="MessageTarget">消息目标。如果是手机短信，则为接受号码；如果是邮件，则为邮件地址</param>
        /// <param name="TargetUser">消息目标用户名。（接收用户在系统中的唯一标识），如果外部用户，则=’’</param>
        /// <param name="TargetDispName">消息目标用户名的显示名称。（接收用户在系统中的唯一标识），如果外部用户，则=’’</param>
        /// <param name="FromUser">消息来自于,发送用户的UserGuid。如果为空，则为当前用户的UserGuid</param>
        /// <param name="FromDispName">消息发送人的显示名称。如果为空，则为当前用户的显示名称</param>
        /// <param name="FromMobile">消息来源手机号码，用于回复</param>
        /// <param name="OuGuid">用户所在部门的OuGuid,用Session["OUGuid"]。如果为空，则为当前用户的OUGuid</param>
        /// <param name="BaseOuGuid">用户所在独立管理部门的OuGuid,用Session["BaseOUGuid"]。如果为空，则为当前用户的BaseOUGuid</param>
        public void SMS_Insert(string MessageItemGuid, string Content, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string OuGuid, string BaseOuGuid)
        {
            this.SMS_Insert(MessageItemGuid, "", Content, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, OuGuid, BaseOuGuid, false);
        }

        public void SMS_Insert(string MessageItemGuid, string Content, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string OuGuid, string BaseOuGuid, Boolean NotAddUserInfo)
        {
            this.SMS_Insert(MessageItemGuid, "", Content, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, OuGuid, BaseOuGuid, NotAddUserInfo);
        }
        /// <summary>
        /// 添加消息方法 通过这个接口添加的短信 不在短信数量限制中
        /// 编写日期：2007-9-3
        /// 编写人：吴建
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid</param>
        /// <param name="Content">消息内容，如果是手机短信，存储短信内容</param>
        /// <param name="GenerateDate">消息产生时间</param>
        /// <param name="IsSchedule">是否定时发送。0：否，立即发送；1：是，定时发送</param>
        /// <param name="ScheduleSendDate">计划发送时间。对于立即发送的消息，此字段没有意义</param>
        /// <param name="MessageTarget">消息目标。如果是手机短信，则为接受号码；如果是邮件，则为邮件地址</param>
        /// <param name="TargetUser">消息目标用户名。（接收用户在系统中的唯一标识），如果外部用户，则=’’</param>
        /// <param name="TargetDispName">消息目标用户名的显示名称。（接收用户在系统中的唯一标识），如果外部用户，则=’’</param>
        /// <param name="FromUser">消息来自于,发送用户的UserGuid。如果为空，则为当前用户的UserGuid</param>
        /// <param name="FromDispName">消息发送人的显示名称。如果为空，则为当前用户的显示名称</param>
        /// <param name="FromMobile">消息来源手机号码，用于回复</param>
        /// <param name="OuGuid">用户所在部门的OuGuid,用Session["OUGuid"]。如果为空，则为当前用户的OUGuid</param>
        /// <param name="BaseOuGuid">用户所在独立管理部门的OuGuid,用Session["BaseOUGuid"]。如果为空，则为当前用户的BaseOUGuid</param>
        public void SMS_InsertNoLimit(string MessageItemGuid, string Content, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string OuGuid, string BaseOuGuid)
        {
            this.SMS_Insert(MessageItemGuid, "nolimit", Content, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, OuGuid, BaseOuGuid, false);
        }

        /// <summary>
        /// 添加消息方法 通过这个接口添加的短信 不在短信数量限制中
        /// 编写日期：2007-9-3
        /// 编写人：吴建
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid</param>
        /// <param name="Content">消息内容，如果是手机短信，存储短信内容</param>
        /// <param name="GenerateDate">消息产生时间</param>
        /// <param name="IsSchedule">是否定时发送。0：否，立即发送；1：是，定时发送</param>
        /// <param name="ScheduleSendDate">计划发送时间。对于立即发送的消息，此字段没有意义</param>
        /// <param name="MessageTarget">消息目标。如果是手机短信，则为接受号码；如果是邮件，则为邮件地址</param>
        /// <param name="TargetUser">消息目标用户名。（接收用户在系统中的唯一标识），如果外部用户，则=’’</param>
        /// <param name="TargetDispName">消息目标用户名的显示名称。（接收用户在系统中的唯一标识），如果外部用户，则=’’</param>
        /// <param name="FromUser">消息来自于,发送用户的UserGuid。如果为空，则为当前用户的UserGuid</param>
        /// <param name="FromDispName">消息发送人的显示名称。如果为空，则为当前用户的显示名称</param>
        /// <param name="FromMobile">消息来源手机号码，用于回复</param>
        /// <param name="OuGuid">用户所在部门的OuGuid,用Session["OUGuid"]。如果为空，则为当前用户的OUGuid</param>
        /// <param name="BaseOuGuid">用户所在独立管理部门的OuGuid,用Session["BaseOUGuid"]。如果为空，则为当前用户的BaseOUGuid</param>
        public void SMS_InsertNoLimit(string MessageItemGuid, string Content, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string OuGuid, string BaseOuGuid, Boolean NotAddUserInfo)
        {
            this.SMS_Insert(MessageItemGuid, "nolimit", Content, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, OuGuid, BaseOuGuid, NotAddUserInfo);
        }

        /// <summary>
        /// 增加MessageType项 用于区分是那个模块发出的短信
        /// </summary>
        public void SMS_InsertHasType(string MessageItemGuid, string MessageType, string Content, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string OuGuid, string BaseOuGuid, Boolean NotAddUserInfo)
        {
            this.SMS_Insert(MessageItemGuid, MessageType, Content, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, OuGuid, BaseOuGuid, NotAddUserInfo);
        }


        /// <summary>
        /// 添加消息方法(手机短信类型)
        /// 编写日期：2007-9-3
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid</param>
        /// <param name="Content">消息内容，如果是手机短信，存储短信内容</param>
        /// <param name="GenerateDate">消息产生时间</param>
        /// <param name="IsSchedule">是否定时发送。0：否，立即发送；1：是，定时发送</param>
        /// <param name="ScheduleSendDate">计划发送时间。对于立即发送的消息，此字段没有意义</param>
        /// <param name="MessageTarget">消息目标。如果是手机短信，则为接受号码；如果是邮件，则为邮件地址</param>
        /// <param name="TargetUser">消息目标用户名。（接收用户在系统中的唯一标识），如果外部用户，则=’’</param>
        /// <param name="TargetDispName">消息目标用户名的显示名称。（接收用户在系统中的唯一标识），如果外部用户，则=’’</param>
        /// <param name="FromUser">消息来自于,发送用户的UserGuid。如果为空，则为当前用户的UserGuid</param>
        /// <param name="FromDispName">消息发送人的显示名称。如果为空，则为当前用户的显示名称</param>
        /// <param name="FromMobile">消息来源手机号码，用于回复</param>
        /// <param name="OuGuid">用户所在部门的OuGuid,用Session["OUGuid"]。如果为空，则为当前用户的OUGuid</param>
        /// <param name="BaseOuGuid">用户所在独立管理部门的OuGuid,用Session["BaseOUGuid"]。如果为空，则为当前用户的BaseOUGuid</param>
        /// <param name="NotAddUserInfo">在发送短信的时候，是否不需要在短信内容后面加上用户信息，如果不需要=true，否则=false</param>
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
            //取得短信的长度
            int SmsLength = 0;

            try
            {
                string strSmsLength = ApplicationOperate.GetConfigValueByName("SmsLength");
                if (strSmsLength != "")
                    SmsLength = Convert.ToInt32(ApplicationOperate.GetConfigValueByName("SmsLength"));//取得短信的长度
                else
                    SmsLength = 0;
            }
            catch { SmsLength = 0; }

            if (SmsLength != 0 && NotAddUserInfo)//在发送短信中，不需要添加后缀，则内容长度自动添加16个字符
                SmsLength += 16;

            String BeiZhu = "";//如果不需要跟上用户信息，则BeiZhu=1
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
        /// 手机短信发送的具体方法,插入到数据库中的方法
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
        /// 添加消息方法，通用方法
        /// 编写日期：2007-4-23
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid</param>
        /// <param name="Title">消息标题</param>
        /// <param name="MessageType">消息内容，暂时不用，现在=''</param>
        /// <param name="Content">消息内容，如果是手机短信，存储短信内容</param>
        /// <param name="SendMode">发送模式：1：手机短信；2：email；3：语音；4：待办事宜；5：即时消息</param>
        /// <param name="GenerateDate">消息产生时间</param>
        /// <param name="IsSchedule">是否定时发送。0：否，立即发送；1：是，定时发送</param>
        /// <param name="ScheduleSendDate">计划发送时间。对于立即发送的消息，此字段没有意义</param>
        /// <param name="MessageTarget">消息目标。如果是手机短信，则为接受号码；如果是邮件，则为邮件地址</param>
        /// <param name="TargetUser">消息目标用户名。（接收用户在系统中的唯一标识），如果外部用户，则=’’</param>
        /// <param name="TargetDispName">消息目标用户名的显示名称。（接收用户在系统中的唯一标识），如果外部用户，则=’’</param>
        /// <param name="FromUser">消息来自于</param>
        /// <param name="FromDispName">消息发送人的显示名称</param>
        /// <param name="FromMobile">消息来源手机号码，用于回复</param>
        /// <param name="HandleUrl">如果是待办事宜，显示对应的处理URL，指从虚拟目录往后的Url，不包括虚拟目录名称，在插入url的时候，需要把此条记录的MessageItemGuid作为参数附加在url的后面</param>
        /// <param name="BeiZhu">备注</param>
        /// <param name="OuGuid">用户所在部门的OuGuid,用Session["OUGuid"]</param>
        /// <param name="BaseOuGuid">用户所在独立管理部门的OuGuid,用Session["BaseOUGuid"] </param>
        /// <returns>Boolean</returns>
        public Boolean Insert(string MessageItemGuid, string Title, string MessageType, string Content, int SendMode, DateTime GenerateDate, int IsSchedule, DateTime ScheduleSendDate, string MessageTarget, string TargetUser, string TargetDispName, string FromUser, string FromDispName, string FromMobile, string HandleUrl, string BeiZhu, string OuGuid, string BaseOuGuid)
        {
            return Insert(MessageItemGuid, Title, MessageType, Content, SendMode, GenerateDate, IsSchedule, ScheduleSendDate, MessageTarget, TargetUser, TargetDispName, FromUser, FromDispName, FromMobile, HandleUrl, BeiZhu, OuGuid, BaseOuGuid, "");
        }

        /// <summary>
        /// 添加消息方法，通用方法
        /// 编写日期：2007-4-23
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="MessageItemGuid">消息唯一Guid</param>
        /// <param name="Title">消息标题</param>
        /// <param name="MessageType">消息内容，暂时不用，现在=''</param>
        /// <param name="Content">消息内容，如果是手机短信，存储短信内容</param>
        /// <param name="SendMode">发送模式：1：手机短信；2：email；3：语音；4：待办事宜；5：即时消息</param>
        /// <param name="GenerateDate">消息产生时间</param>
        /// <param name="IsSchedule">是否定时发送。0：否，立即发送；1：是，定时发送</param>
        /// <param name="ScheduleSendDate">计划发送时间。对于立即发送的消息，此字段没有意义</param>
        /// <param name="MessageTarget">消息目标。如果是手机短信，则为接受号码；如果是邮件，则为邮件地址</param>
        /// <param name="TargetUser">消息目标用户名。（接收用户在系统中的唯一标识），如果外部用户，则=’’</param>
        /// <param name="TargetDispName">消息目标用户名的显示名称。（接收用户在系统中的唯一标识），如果外部用户，则=’’</param>
        /// <param name="FromUser">消息来自于</param>
        /// <param name="FromDispName">消息发送人的显示名称</param>
        /// <param name="FromMobile">消息来源手机号码，用于回复</param>
        /// <param name="HandleUrl">如果是待办事宜，显示对应的处理URL，指从虚拟目录往后的Url，不包括虚拟目录名称，在插入url的时候，需要把此条记录的MessageItemGuid作为参数附加在url的后面</param>
        /// <param name="BeiZhu">备注</param>
        /// <param name="OuGuid">用户所在部门的OuGuid,用Session["OUGuid"]</param>
        /// <param name="BaseOuGuid">用户所在独立管理部门的OuGuid,用Session["BaseOUGuid"] </param>
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
        /// 取得第一个需要发送的手机短信
        /// 崔爱民
        /// </summary>
        /// <returns>DataView</returns>
        public DataView GetTopOneWaitHandleSms(string strSql)
        {
            Database db = DatabaseFactory.CreateDatabase(DatabaseOperate.GetConnectionStringName("Messages_ConnectionString"));
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            return db.ExecuteDataView(cmd);
        }

        /// <summary>
        /// 短信发送成功后，更新发送状态并转移到已发送表中
        /// 处理时间为系统当前时间
        /// 编写日期：2007-12-12
        /// 编写人：崔爱民
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

            //处理后，转移消息到已处理表中
            MsgHistroy.Move_WaitHandleToHistroy(MessageItemGuid);
        }

        /// <summary>
        /// 取得发送短信的sql语句，sql、oralce自适应
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
        ///// 手机短信检索
        ///// 编写日期：2007-9-3
        ///// 编写人：崔爱民
        /// </summary>
        /// <param name="FromValue">开始时间</param>
        /// <param name="ToValue">结束时间</param>
        /// <param name="Content">内容</param>
        /// <param name="UserGuid">发送用户UserGuid</param>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPageIndex"></param>
        /// <param name="isSend">是否发送状态.0:未发送；1：已发送；9：所有</param>
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
        /// 手机短信检索
        /// 编写日期：2007-9-3
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="FromValue">开始时间</param>
        /// <param name="ToValue">结束时间</param>
        /// <param name="Content">内容</param>
        /// <param name="UserGuid">发送用户UserGuid</param>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPageIndex"></param>
        /// <param name="isSend">是否发送状态.0:未发送；1：已发送；9：所有</param>
        /// <param name="TotalNum">TotalNum</param>
        /// <returns>DataView</returns>
        public DataView GetSmsDatePageView(string FromValue, string ToValue, string Content, string UserGuid, int PageSize, int CurrentPageIndex, int isSend, Boolean isShowAll, out int TotalNum)
        {
            TotalNum = 0;
            return GetSmsDatePageView(FromValue, ToValue, Content, UserGuid, "", "", PageSize, CurrentPageIndex, isSend, isShowAll, out  TotalNum);
        }

        /// <summary>
        /// 手机短信检索
        /// 编写日期：2007-9-3
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="FromValue">开始时间</param>
        /// <param name="ToValue">结束时间</param>
        /// <param name="Content">内容</param>
        /// <param name="UserGuid">发送用户UserGuid</param>
        /// <param name="PageSize"></param>
        /// <param name="CurrentPageIndex"></param>
        /// <param name="isSend">是否发送状态.0:未发送；1：已发送；9：所有</param>
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
            if (isSend == 0)//未发送
                TableName = "Messages_Center";
            else if (isSend == 1)//已发送
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
        /// 编写日期：2008-1-29
        /// 编写人：秦洁霜
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
        /// 修改HandleUrl
        /// 编写日期：2008-1-30
        /// 编写人：秦洁霜
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
        /// 修改HandleUrl
        /// 编写日期：2008-1-30
        /// 编写人：秦洁霜
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
        /// 更新Content字段
        /// 编写日期：2010-1-12
        /// 编写人：吴建
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
        /// 删除还没有发送的短信
        /// 编写日期：2008-2-14
        /// 编写人：吴建
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
        /// 根据用户和ClientIdentifier来确定唯一记录
        /// 编写日期：2008-5-7
        /// 编写人：秦洁霜
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
        /// 省质检项目专用，获得分类信息的审批人列表
        /// </summary>
        /// <param name="ClientIdentifier">ClientIdentifier</param>
        /// <returns></returns>
        public DataView Select_ShenPiRen(string ClientIdentifier)
        {
            //获得第一步提交审核的时间
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
        /// 根据ClientIdentifier取得待办事宜，ClientIdentifier就是ApplyGuid
        /// 编写日期：2009-1-12
        /// 编写人：肖明星
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

                //去掉or
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

                //去掉or
                if (strSql.EndsWith("or "))
                    strSql = strSql.Substring(0, strSql.Length - 3);
                strSql += ")";
            }
            //LogOperate.WriteLog_ToFileName("XgcTest.txt", strSql);
            return strSql;
        }

        /// <summary>
        /// TODO:下一个版本移到框架中。
        /// 编写日期：2008-8-15
        /// 编写人：吴建
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


    #region 工作流中用到的和邮件有关的3个类，为了不引用Epoint.DBMail.Bizlogic，放到了这里。

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
            //这里补充判断表是否存在的方法。 
            Is_ExistDBMailTable = true;
        }


        /// <summary>
        /// 添加邮件收发记录
        /// 编写日期：2007-5-15
        /// 编写人：蔡金义
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
            //这里补充判断表是否存在的方法。 
            Is_ExistDBMailTable = true;
        }

        /// <summary>
        /// 添加邮件正文内容
        /// 编写日期：2007-9-5
        /// 编写人：崔爱民
        /// </summary>
        /// <param name="OutMailGuid">邮件唯一Guid</param>
        /// <param name="MailContent">邮件内容</param>
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
            //这里补充判断表是否存在的方法。 
            Is_ExistDBMailTable = true;
        }


        /// <summary>
        /// 插入签收记录信息
        /// 编写日期：2007-5-16
        /// 编写人：蔡金义
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
