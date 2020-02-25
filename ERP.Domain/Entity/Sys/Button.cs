using System;
using System.Runtime.Serialization;
using Dos.ORM;
using ERP.Infrastructure.Data;

namespace ERP.Domain.Entity
{
    /// <summary>
    /// 实体类Sys_Button。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_Button")]
    [Serializable]
    [DataContract]
    public partial class Button : IEntityValue
    {
        #region Model
        private int _Id = 0;
        private string _ButtonName;
        private string _ClassName = "";
        private string _FuncName;
        private string _FunContent;
        private int? _MenuId;
        private bool? _Stopping;
        public string StopValue { get { return _Stopping == true ? "是" : "否"; } }

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
        [Field("ButtonName")]
        [DataMember]
        public string ButtonName
        {
            get { return _ButtonName; }
            set
            {
                this.OnPropertyValueChange("ButtonName");
                this._ButtonName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("ClassName")]
        [DataMember]
        public string ClassName
        {
            get { return _ClassName; }
            set
            {
                this.OnPropertyValueChange("ClassName");
                this._ClassName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("FuncName")]
        [DataMember]
        public string FuncName
        {
            get { return _FuncName; }
            set
            {
                this.OnPropertyValueChange("FuncName");
                this._FuncName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("FunContent")]
        [DataMember]
        public string FunContent
        {
            get { return _FunContent; }
            set
            {
                this.OnPropertyValueChange("FunContent");
                this._FunContent = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("MenuId")]
        [DataMember]
        public int? MenuId
        {
            get { return _MenuId; }
            set
            {
                this.OnPropertyValueChange("MenuId");
                this._MenuId = value;
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
				_.ButtonName,
				_.ClassName,
				_.FuncName,
				_.FunContent,
				_.MenuId,
				_.Stopping,
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._Id,
				this._ButtonName,
				this._ClassName,
				this._FuncName,
				this._FunContent,
				this._MenuId,
				this._Stopping,
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
            public readonly static Field All = new Field("*", "Sys_Button");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Id = new Field("Id", "Sys_Button", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ButtonName = new Field("ButtonName", "Sys_Button", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ClassName = new Field("ClassName", "Sys_Button", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field FuncName = new Field("FuncName", "Sys_Button", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field FunContent = new Field("FunContent", "Sys_Button", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field MenuId = new Field("MenuId", "Sys_Button", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Stopping = new Field("Stopping", "Sys_Button", "");
        }
        #endregion
    }
}