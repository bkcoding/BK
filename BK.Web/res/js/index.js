﻿layui.define('flow', function (exports) {
    var $ = layui.jquery
        , flow = layui.flow;
    flow.load({
        elem: '#more', //指定列表容器
        done: function (page, next) {
            //以jQuery的Ajax请求为例，请求下一页数据（注意：page是从2开始返回）
            var mfc = $(".content").attr("id");
            $.get('/Posts/GetPosts', { c: mfc, page: page, size: 5 }, function (res) {
                $(".content").append(res);
                next('', Trim(res, "g") != '');
            });
        }
    });

    exports('index', {});
});
function Trim(str, is_global) {

    var result;

    result = str.replace(/(^\s+)|(\s+$)/g, "");

    if (is_global.toLowerCase() == "g") {

        result = result.replace(/\s/g, "");

    }

    return result;
}
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return "";
}