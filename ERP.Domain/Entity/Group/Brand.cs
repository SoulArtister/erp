
using System;
using System.Runtime.Serialization;
using Dos.ORM;
using ERP.Infrastructure.Data;

namespace ERP.Domain.Entity
{
    /// <summary>
    /// 实体类Brand。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("G_Brand")]
    [Serializable]
    [DataContract]
    public partial class Brand : IEntityValue
    {
        #region Model
        private int _Id;
        private string _BrandNo;
        private string _BrandName;
        private string _Spell;
        private string _Comment = "";
        private bool? _Using;
        public string UsingValue { get { return _Using == true ? "是" : "否"; } }

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
        [Field("BrandNo")]
        [DataMember]
        public string BrandNo
        {
            get { return _BrandNo; }
            set
            {
                this.OnPropertyValueChange("BrandNo");
                this._BrandNo = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("BrandName")]
        [DataMember]
        public string BrandName
        {
            get { return _BrandName; }
            set
            {
                this.OnPropertyValueChange("BrandName");
                this._BrandName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Spell")]
        [DataMember]
        public string Spell
        {
            get { return _Spell; }
            set
            {
                this.OnPropertyValueChange("Spell");
                this._Spell = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Comment")]
        [DataMember]
        public string Comment
        {
            get { return _Comment; }
            set
            {
                this.OnPropertyValueChange("Comment");
                this._Comment = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Using")]
        [DataMember]
        public bool? Using
        {
            get { return _Using; }
            set
            {
                this.OnPropertyValueChange("Using");
                this._Using = value;
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
				_.BrandNo,
				_.BrandName,
				_.Spell,
				_.Comment,
				_.Using,
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._Id,
				this._BrandNo,
				this._BrandName,
				this._Spell,
				this._Comment,
				this._Using,
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
            public readonly static Field All = new Field("*", "G_Brand");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Id = new Field("Id", "G_Brand", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field BrandNo = new Field("BrandNo", "G_Brand", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field BrandName = new Field("BrandName", "G_Brand", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Spell = new Field("Spell", "G_Brand", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Comment = new Field("Comment", "G_Brand", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Using = new Field("Using", "G_Brand", "");
        }
        #endregion
    }
}