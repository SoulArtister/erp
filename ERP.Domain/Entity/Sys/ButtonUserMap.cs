using System;
using System.Runtime.Serialization;
using Dos.ORM;
using ERP.Infrastructure.Data;

namespace ERP.Domain.Entity
{
    /// <summary>
    /// 实体类Sys_ButtonUserMap。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("Sys_ButtonUserMap")]
    [Serializable]
    [DataContract]
    public partial class ButtonUserMap : IEntityValue
    {
        #region Model
        private int _Id;
        private int? _ButtonId;
        private int? _UserId;

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
        [Field("ButtonId")]
        [DataMember]
        public int? ButtonId
        {
            get { return _ButtonId; }
            set
            {
                this.OnPropertyValueChange("ButtonId");
                this._ButtonId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("UserId")]
        [DataMember]
        public int? UserId
        {
            get { return _UserId; }
            set
            {
                this.OnPropertyValueChange("UserId");
                this._UserId = value;
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
				_.ButtonId,
				_.UserId,
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._Id,
				this._ButtonId,
				this._UserId,
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
            public readonly static Field All = new Field("*", "Sys_ButtonUserMap");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Id = new Field("Id", "Sys_ButtonUserMap", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ButtonId = new Field("ButtonId", "Sys_ButtonUserMap", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field UserId = new Field("UserId", "Sys_ButtonUserMap", "");
        }
        #endregion
    }
}