﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//     Website: http://ITdos.com/Dos/ORM/Index.html
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Dos.ORM;
using ERP.Infrastructure.Data;

namespace ERP.Domain.Entity
{
    public partial class Map_MenuChain
    {

    }

    /// <summary>
    /// 实体类Map_MenuChain。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_Map_MenuChain")]
    [Serializable]
    [DataContract]
    public partial class Map_MenuChain : IEntityValue
    {
        #region Model
        private int _Id;
        private string _MenuNo;
        private string _ChainOrgId;

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
        [Field("MenuNo")]
        [DataMember]
        public string MenuNo
        {
            get { return _MenuNo; }
            set
            {
                this.OnPropertyValueChange("MenuNo");
                this._MenuNo = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("ChainOrgId")]
        [DataMember]
        public string ChainOrgId
        {
            get { return _ChainOrgId; }
            set
            {
                this.OnPropertyValueChange("ChainOrgId");
                this._ChainOrgId = value;
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
				_.MenuNo,
				_.ChainOrgId,
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._Id,
				this._MenuNo,
				this._ChainOrgId,
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
            public readonly static Field All = new Field("*", "Map_MenuChain");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Id = new Field("Id", "Map_MenuChain", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field MenuNo = new Field("MenuNo", "Map_MenuChain", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ChainOrgId = new Field("ChainOrgId", "Map_MenuChain", "");
        }
        #endregion
    }
}