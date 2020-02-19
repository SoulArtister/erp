using System;
using System.Runtime.Serialization;
using Dos.ORM;
using ERP.Infrastructure.Data;
using ERP.Domain.IRepository;
using ERP.Infrastructure.Common;

namespace ERP.Domain.Entity
{
    /// <summary>
    /// 实体类Menu。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_Menu")]
    [Serializable]
    [DataContract]
    public partial class Menu : IEntityValue
    {
        #region Model
        private int _Id;
        private string _MemuNo;
        private string _MenuName;
        private string _UrlRoute;
        private string _IniParam;
        private int? _Sno;
        private string _Icon;
        private bool? _Hiding;
        private bool? _Stopping;
        private int? _TopMenuId;
        private int? _ParentId;
        private bool? _HaveBtn;

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
        [Field("MemuNo")]
        [DataMember]
        public string MemuNo
        {
            get { return _MemuNo; }
            set
            {
                this.OnPropertyValueChange("MemuNo");
                this._MemuNo = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("MenuName")]
        [DataMember]
        public string MenuName
        {
            get { return _MenuName; }
            set
            {
                this.OnPropertyValueChange("MenuName");
                this._MenuName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("UrlRoute")]
        [DataMember]
        public string UrlRoute
        {
            get { return _UrlRoute; }
            set
            {
                this.OnPropertyValueChange("UrlRoute");
                this._UrlRoute = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("IniParam")]
        [DataMember]
        public string IniParam
        {
            get { return _IniParam; }
            set
            {
                this.OnPropertyValueChange("IniParam");
                this._IniParam = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Sno")]
        [DataMember]
        public int? Sno
        {
            get { return _Sno; }
            set
            {
                this.OnPropertyValueChange("Sno");
                this._Sno = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Icon")]
        [DataMember]
        public string Icon
        {
            get { return _Icon; }
            set
            {
                this.OnPropertyValueChange("Icon");
                this._Icon = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Hiding")]
        [DataMember]
        public bool? Hiding
        {
            get { return _Hiding; }
            set
            {
                this.OnPropertyValueChange("Hiding");
                this._Hiding = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Stopping")]
        [DataMember]
        public bool? Stopping
        {
            get { return _Stopping; }
            set
            {
                this.OnPropertyValueChange("Stopping");
                this._Stopping = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("TopMenuId")]
        [DataMember]
        public int? TopMenuId
        {
            get { return _TopMenuId; }
            set
            {
                this.OnPropertyValueChange("TopMenuId");
                this._TopMenuId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("ParentId")]
        [DataMember]
        public int? ParentId
        {
            get { return _ParentId; }
            set
            {
                this.OnPropertyValueChange("ParentId");
                this._ParentId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("HaveBtn")]
        [DataMember]
        public bool? HaveBtn
        {
            get { return _HaveBtn; }
            set
            {
                this.OnPropertyValueChange("HaveBtn");
                this._HaveBtn = value;
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
				_.MemuNo,
				_.MenuName,
				_.UrlRoute,
				_.IniParam,
				_.Sno,
				_.Icon,
				_.Hiding,
				_.Stopping,
				_.TopMenuId,
				_.ParentId,
				_.HaveBtn,
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._Id,
				this._MemuNo,
				this._MenuName,
				this._UrlRoute,
				this._IniParam,
				this._Sno,
				this._Icon,
				this._Hiding,
				this._Stopping,
				this._TopMenuId,
				this._ParentId,
				this._HaveBtn,
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
            public readonly static Field All = new Field("*", "Sys_Menu");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Id = new Field("Id", "Sys_Menu", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field MemuNo = new Field("MemuNo", "Sys_Menu", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field MenuName = new Field("MenuName", "Sys_Menu", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field UrlRoute = new Field("UrlRoute", "Sys_Menu", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field IniParam = new Field("IniParam", "Sys_Menu", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Sno = new Field("Sno", "Sys_Menu", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Icon = new Field("Icon", "Sys_Menu", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Hiding = new Field("Hiding", "Sys_Menu", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Stopping = new Field("Stopping", "Sys_Menu", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field TopMenuId = new Field("TopMenuId", "Sys_Menu", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ParentId = new Field("ParentId", "Sys_Menu", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field HaveBtn = new Field("HaveBtn", "Sys_Menu", "");
        }
        #endregion
    }
}