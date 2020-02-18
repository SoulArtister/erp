//读取cookie
function getCookie(name) {
    var cookies = document.cookie.split(";");
    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i];
        var cookieStr = cookie.split("=");
        if (cookieStr && cookieStr[0].trim() == name) {
            return decodeURI(decodeURI(cookieStr[1]));
        }
    }
}

//jQuery扩展方法
(function ($) {
    //获得url传参
    $.getUrlParam = function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
});