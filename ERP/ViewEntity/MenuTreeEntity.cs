using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewEntity
{
    /// <summary>
    /// 菜单树实体
    /// 用于界面展示
    /// </summary>
    public class MenuTreeEntity
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<MenuTreeEntity> children { get; set; }
    }
}