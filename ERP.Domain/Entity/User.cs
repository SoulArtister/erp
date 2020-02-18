using System;
using System.Runtime.Serialization;
using Dos.ORM;
using ERP.Infrastructure.Data;
using ERP.Infrastructure.Common;
using Finance.Domain.IRepository;

namespace ERP.Domain.Entity
{
    /// <summary>
    /// 实体类Users。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("G_Users")]
    [Serializable]
    [DataContract]
    public partial class User : IEntityValue
    {
        #region Model
        private int _Id;
        private string _Account;
        private string _Password;
        private string _EmployeeNo;
        private string _UserName;
        private string _QQ;
        private string _Email;
        private DateTime? _Birthday;
        private DateTime? _CreateTime;
        private DateTime? _ChangePassTime;
        private string _ActiveIp;
        private DateTime? _LastLoginTime;
        private int? _OrgId;
        private int? _DepId;
        private DateTime _LastTimeStamp;

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
        [Field("Account")]
        [DataMember]
        public string Account
        {
            get { return _Account; }
            set
            {
                this.OnPropertyValueChange("Account");
                this._Account = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Password")]
        [DataMember]
        public string Password
        {
            get { return _Password; }
            set
            {
                this.OnPropertyValueChange("Password");
                this._Password = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("EmployeeNo")]
        [DataMember]
        public string EmployeeNo
        {
            get { return _EmployeeNo; }
            set
            {
                this.OnPropertyValueChange("EmployeeNo");
                this._EmployeeNo = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("UserName")]
        [DataMember]
        public string UserName
        {
            get { return _UserName; }
            set
            {
                this.OnPropertyValueChange("UserName");
                this._UserName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("QQ")]
        [DataMember]
        public string QQ
        {
            get { return _QQ; }
            set
            {
                this.OnPropertyValueChange("QQ");
                this._QQ = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Email")]
        [DataMember]
        public string Email
        {
            get { return _Email; }
            set
            {
                this.OnPropertyValueChange("Email");
                this._Email = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Birthday")]
        [DataMember]
        public DateTime? Birthday
        {
            get { return _Birthday; }
            set
            {
                this.OnPropertyValueChange("Birthday");
                this._Birthday = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("CreateTime")]
        [DataMember]
        public DateTime? CreateTime
        {
            get { return _CreateTime; }
            set
            {
                this.OnPropertyValueChange("CreateTime");
                this._CreateTime = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("ChangePassTime")]
        [DataMember]
        public DateTime? ChangePassTime
        {
            get { return _ChangePassTime; }
            set
            {
                this.OnPropertyValueChange("ChangePassTime");
                this._ChangePassTime = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("ActiveIp")]
        [DataMember]
        public string ActiveIp
        {
            get { return _ActiveIp; }
            set
            {
                this.OnPropertyValueChange("ActiveIp");
                this._ActiveIp = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("LastLoginTime")]
        [DataMember]
        public DateTime? LastLoginTime
        {
            get { return _LastLoginTime; }
            set
            {
                this.OnPropertyValueChange("LastLoginTime");
                this._LastLoginTime = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("OrgId")]
        [DataMember]
        public int? OrgId
        {
            get { return _OrgId; }
            set
            {
                this.OnPropertyValueChange("OrgId");
                this._OrgId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("DepId")]
        [DataMember]
        public int? DepId
        {
            get { return _DepId; }
            set
            {
                this.OnPropertyValueChange("DepId");
                this._DepId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("LastTimeStamp")]
        [DataMember]
        public DateTime LastTimeStamp
        {
            get { return _LastTimeStamp; }
            set
            {
                this.OnPropertyValueChange("LastTimeStamp");
                this._LastTimeStamp = value;
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
				_.Account,
				_.Password,
				_.EmployeeNo,
				_.UserName,
				_.QQ,
				_.Email,
				_.Birthday,
				_.CreateTime,
				_.ChangePassTime,
				_.ActiveIp,
				_.LastLoginTime,
				_.OrgId,
				_.DepId,
				_.LastTimeStamp,
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._Id,
				this._Account,
				this._Password,
				this._EmployeeNo,
				this._UserName,
				this._QQ,
				this._Email,
				this._Birthday,
				this._CreateTime,
				this._ChangePassTime,
				this._ActiveIp,
				this._LastLoginTime,
				this._OrgId,
				this._DepId,
				this._LastTimeStamp,
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
            public readonly static Field All = new Field("*", "Users");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Id = new Field("Id", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Account = new Field("Account", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Password = new Field("Password", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field EmployeeNo = new Field("EmployeeNo", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field UserName = new Field("UserName", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field QQ = new Field("QQ", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Email = new Field("Email", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Birthday = new Field("Birthday", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field CreateTime = new Field("CreateTime", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ChangePassTime = new Field("ChangePassTime", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ActiveIp = new Field("ActiveIp", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LastLoginTime = new Field("LastLoginTime", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OrgId = new Field("OrgId", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DepId = new Field("DepId", "Users", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LastTimeStamp = new Field("LastTimeStamp", "Users", "");
        }
        #endregion
    }
}