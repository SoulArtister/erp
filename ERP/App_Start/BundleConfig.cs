using System.Web;
using System.Web.Optimization;

namespace ERP
{
    /// <summary>
    /// 起始加载绑定的css和js
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// 注册css和js
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            //把layerjs添加到bundles/layer
            ScriptBundle scriptBundle = new ScriptBundle("~/bundles/layer");
            scriptBundle.Include("~/Content/themes/jquery2.1.1.min.js");
            scriptBundle.Include("~/Content/layui-v2.5.6/layui/layui.js");
            bundles.Add(scriptBundle);

            //把layerui css添加到
            StyleBundle styleBundle = new System.Web.Optimization.StyleBundle("~/Content/layerui");
            styleBundle.Include("~/Content/layui-v2.5.6/layui/css/layui.css");
            styleBundle.Include("~/Content/main.css");
            bundles.Add(styleBundle);

            bundles.Add(new StyleBundle("~/Content/css"));
        }
    }
}