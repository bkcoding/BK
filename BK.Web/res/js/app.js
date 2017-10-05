
layui.define(['layer', 'laypage', 'laytpl', 'element', 'form', 'layedit', 'util', 'flow', 'code'], function (exports) {
    var $ = layui.jquery
        , laypage = layui.laypage
        , laytpl = layui.laytpl
        , layer = layui.layer
        , form = layui.form
        , flow = layui.flow
        , util = layui.util
        , device = layui.device();
    //阻止IE7以下访问
    if (device.ie && device.ie < 8) {
        layer.alert('Layui最低支持ie8，您当前使用的是古老的 IE' + device.ie + '，你丫的肯定不是程序猿！');
    }
    //固定Bar
    util.fixbar();
    var latestPostsTpl;
    $.get("/TempLate/latestPosts", function (tpl) {
        latestPostsTpl = tpl;
        if ($("#latestPosts").length > 0) {
            flow.load({
                elem: '#latestPosts',
                done: function (page, next) {
                    var lis = [];
                    $.get("/Posts/lastest", { index: page, count:5 }, function (data) {
                        var result = laytpl(latestPostsTpl).render(data.list);
                        lis.push(result);
                        next(lis.join(''), page < data.pages); 
                    });
                }
            })
        }
    })


    exports('app', {});
}); 