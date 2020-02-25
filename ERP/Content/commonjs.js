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

function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}
