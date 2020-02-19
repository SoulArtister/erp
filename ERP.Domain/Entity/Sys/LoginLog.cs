using System;
using System.Runtime.Serialization;
using Dos.ORM;
using ERP.Infrastructure.Data;

namespace ERP.Domain.Entity
{
    /// <summary>
    /// 实体类Sys_LoginLog。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_LoginLog")]
    [Serializable]
    [DataContract]
    public partial class LoginLog : IEntityValue
    {
        #region Model
        private int _Id;
        private string _AccountNo;
        private DateTime? _OccureTime;
        private string _SessionId;
        private string _UserHostAddress;
        private string _UserHostName;
        private long? _IntTimeStamp;

        /// <summary>
        /// 
        /// </summary>
        [Field("Id")]
        [DataMember]
        public int Id
        {
            get { return _Id; }
            set
            {
                this.OnPropertyValueChange("Id");
                this._Id = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("AccountNo")]
        [DataMember]
        public string AccountNo
        {
            get { return _AccountNo; }
            set
            {
                this.OnPropertyValueChange("AccountNo");
                this._AccountNo = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("OccureTime")]
        [DataMember]
        public DateTime? OccureTime
        {
            get { return _OccureTime; }
            set
            {
                this.OnPropertyValueChange("OccureTime");
                this._OccureTime = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("SessionId")]
        [DataMember]
        public string SessionId
        {
            get { return _SessionId; }
            set
            {
                this.OnPropertyValueChange("SessionId");
                this._SessionId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("UserHostAddress")]
        [DataMember]
        public string UserHostAddress
        {
            get { return _UserHostAddress; }
            set
            {
                this.OnPropertyValueChange("UserHostAddress");
                this._UserHostAddress = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("UserHostName")]
        [DataMember]
        public string UserHostName
        {
            get { return _UserHostName; }
            set
            {
                this.OnPropertyValueChange("UserHostName");
                this._UserHostName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("IntTimeStamp")]
        [DataMember]
        public long? IntTimeStamp
        {
            get { return _IntTimeStamp; }
            set
            {
                this.OnPropertyValueChange("IntTimeStamp");
                this._IntTimeStamp = value;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
				_.Id,
			};
        }
        /// <summary>
        /// 获取实体中的标识列
        /// </summary>
        public override Field GetIdentityField()
        {
            return _.Id;
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
				_.Id,
				_.AccountNo,
				_.OccureTime,
				_.SessionId,
				_.UserHostAddress,
				_.UserHostName,
				_.IntTimeStamp,
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._Id,
				this._AccountNo,
				this._OccureTime,
				this._SessionId,
				this._UserHostAddress,
				this._UserHostName,
				this._IntTimeStamp,
			};
        }
        /// <summary>
        /// 是否是v1.10.5.6及以上版本实体。
        /// </summary>
        /// <returns></returns>
        public override bool V1_10_5_6_Plus()
        {
            return true;
        }
        #endregion

        #region _Field
        /// <summary>
        /// 字段信息
        /// </summary>
        public class _
        {
            /// <summary>
            /// * 
            /// </summary>
            public readonly static Field All = new Field("*", "Sys_LoginLog");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Id = new Field("Id", "Sys_LoginLog", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field AccountNo = new Field("AccountNo", "Sys_LoginLog", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OccureTime = new Field("OccureTime", "Sys_LoginLog", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field SessionId = new Field("SessionId", "Sys_LoginLog", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field UserHostAddress = new Field("UserHostAddress", "Sys_LoginLog", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field UserHostName = new Field("UserHostName", "Sys_LoginLog", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field IntTimeStamp = new Field("IntTimeStamp", "Sys_LoginLog", "");
        }
        #endregion
    }
}