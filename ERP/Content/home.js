//储存切换的tab菜单
var tabmenus = [];
var iframeid = "0";
//把主页加上
tabmenus.push('0');
//添加和删除tabul和tabmenus数组
function gotoPage(id, url, menuname) {
    // 如果数组中不存在
    if ($.inArray(id, tabmenus) == -1 && url.length > 0 && url != " ") {
        if (tabmenus.length + 1 <= 10) {
            addTab(id, url, menuname)
        } else {
            //超过10个先删除
            let rid = tabmenus[0];
            tabmenus.splice($.inArray(rid, tabmenus), 1);
            deletePage(rid);
            //再添加
            addTab(id, url, menuname)
        }
    } else {
        showPage(id);
        return;
    };
}

//抽离的公共方法，用于添加tabul和tabmenus数组
function addTab(id, url, menuname) {
    var item = '<li onclick="selectTab(this)" lay-id="' + id + '" lay-attr="' + url + '" class="layui-this"><span>' + menuname +
        '</span><i onclick="removeTab(this,' + id + ')" class="layui-icon layui-unselect layui-tab-close">ဆ</i></li>';
    $(item).click(function () { alert("s"); selectTab(this, id, url, menuname) });
    $("#LAY_app_tabsheader li").removeClass("layui-this");
    $("#LAY_app_tabsheader").append(item);
    tabmenus.push(id);

    $("#LAY_app_body div").removeClass("layui-show");
    $("#LAY_app_body div").hide();
    var framitem = "<div id='ifmdiv" + id + "' class='layadmin-tabsbody-item layui-show'><iframe src='" + url + "' frameborder='0' class='layadmin-iframe'></iframe></div>";
    $("#LAY_app_body").append(framitem);

    //记录当前显示的iframe id
    iframeid = id.toString();
}

//选中tab
function selectTab(obj) {
    var id = $(obj).attr("lay-id");
    showPage(id);
}

//从tab栏中移除
function removeTab(obj, id) {
    event.stopPropagation(); //防止触发父级div的onclick事件
    $(obj).parent().remove();
    id = id.toString();
    tabmenus.splice($.inArray(id, tabmenus), 1);
    deletePage(id);
}

// 删除示已有iframe
function deletePage(id) {
    var div = $("div[id='ifmdiv" + id + "']");
    div.remove();
    //删除完之后显示最后一个
    var lastId = tabmenus[tabmenus.length - 1];

    $("#LAY_app_tabsheader li").removeClass("layui-this");
    $("#LAY_app_tabsheader").find("li[lay-id='" + lastId + "']").addClass("layui-this");
    showPage(lastId)
}

// 显示已有iframe
function showPage(id) {
    $("#LAY_app_body div").removeClass("layui-show");
    $("#LAY_app_body div").hide();
    $("div[id='ifmdiv" + id + "']").show();
    $("div[id='ifmdiv" + id + "']").addClass("layui-show")
    //选中点击菜单
    $("#LAY-system-side-menu li").removeClass("layui-this");
    $("#LAY-system-side-menu dd").removeClass("layui-this");
    if ($("#menu" + id).find("dl").length == 0)
        $("#menu" + id).addClass("layui-this");

    //记录当前显示的iframe id
    iframeid = id.toString();
}

//刷新
function refreshIframe() {
    var iframe = $('#ifmdiv' + iframeid + ' iframe');
    $(iframe).attr('src', $(iframe).attr('src'));
}

//检查登录互斥
function checkLoginMutex() {
    $.post("/Home/CheckLoginMutex", {}, function (ret) {
        if (ret.Code == 0) {
            if (ret.Data == "1") {
                alert(ret.Msg);
                window.location.href = "../../Login/Index";
            }
        }
    })
}
