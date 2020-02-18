using System.Web;
using System.Web.Optimization;

namespace ERPApi
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
            scriptBundle.Include("~/Content/themes/jquery-1.9.1.js");
            scriptBundle.Include("~/Content/layui-v2.4.5/layui/layui.js");
            scriptBundle.Include("~/Content/layui-v2.4.5/layui/layui.js");
            bundles.Add(scriptBundle);

            //把layerui css添加到
            StyleBundle styleBundle = new System.Web.Optimization.StyleBundle("~/Content/layerui");
            styleBundle.Include("~/Content/layui-v2.4.5/layui/css/layui.css");
            styleBundle.Include("~/Content/main.css");
            bundles.Add(styleBundle);



            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/css"));//.Include("~/Content/site.css")

            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //            "~/Content/themes/base/jquery.ui.core.css",
            //            "~/Content/themes/base/jquery.ui.resizable.css",
            //            "~/Content/themes/base/jquery.ui.selectable.css",
            //            "~/Content/themes/base/jquery.ui.accordion.css",
            //            "~/Content/themes/base/jquery.ui.autocomplete.css",
            //            "~/Content/themes/base/jquery.ui.button.css",
            //            "~/Content/themes/base/jquery.ui.dialog.css",
            //            "~/Content/themes/base/jquery.ui.slider.css",
            //            "~/Content/themes/base/jquery.ui.tabs.css",
            //            "~/Content/themes/base/jquery.ui.datepicker.css",
            //            "~/Content/themes/base/jquery.ui.progressbar.css",
            //            "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}