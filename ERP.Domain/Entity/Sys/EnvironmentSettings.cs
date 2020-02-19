using System;
using System.Runtime.Serialization;
using Dos.ORM;
using ERP.Infrastructure.Data;

namespace ERP.Domain.Entity
{
    /// <summary>
    /// 实体类EnvironmentSettings。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_EnvironmentSettings")]
    [Serializable]
    [DataContract]
    public partial class EnvironmentSettings : IEntityValue
    {
        #region Model
        private string _ParamCode;
        private string _ParamName;
        private string _ParamDataType;
        private string _ParamValue;
        private string _Description;

        /// <summary>
        /// 
        /// </summary>
        [Field("ParamCode")]
        [DataMember]
        public string ParamCode
        {
            get { return _ParamCode; }
            set
            {
                this.OnPropertyValueChange("ParamCode");
                this._ParamCode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("ParamName")]
        [DataMember]
        public string ParamName
        {
            get { return _ParamName; }
            set
            {
                this.OnPropertyValueChange("ParamName");
                this._ParamName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("ParamDataType")]
        [DataMember]
        public string ParamDataType
        {
            get { return _ParamDataType; }
            set
            {
                this.OnPropertyValueChange("ParamDataType");
                this._ParamDataType = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("ParamValue")]
        [DataMember]
        public string ParamValue
        {
            get { return _ParamValue; }
            set
            {
                this.OnPropertyValueChange("ParamValue");
                this._ParamValue = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Description")]
        [DataMember]
        public string Description
        {
            get { return _Description; }
            set
            {
                this.OnPropertyValueChange("Description");
                this._Description = value;
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
			};
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
				_.ParamCode,
				_.ParamName,
				_.ParamDataType,
				_.ParamValue,
				_.Description,
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ParamCode,
				this._ParamName,
				this._ParamDataType,
				this._ParamValue,
				this._Description,
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
            public readonly static Field All = new Field("*", "Sys_EnvironmentSettings");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ParamCode = new Field("ParamCode", "Sys_EnvironmentSettings", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ParamName = new Field("ParamName", "Sys_EnvironmentSettings", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ParamDataType = new Field("ParamDataType", "Sys_EnvironmentSettings", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ParamValue = new Field("ParamValue", "Sys_EnvironmentSettings", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Description = new Field("Description", "Sys_EnvironmentSettings", "");
        }
        #endregion
    }
}