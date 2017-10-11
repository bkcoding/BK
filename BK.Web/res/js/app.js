
layui.define(['layer', 'laypage', 'laytpl', 'element','util', 'flow'], function (exports) {
    var $ = layui.jquery
        , laypage = layui.laypage
        , laytpl = layui.laytpl
        , layer = layui.layer
        , flow = layui.flow
        , util = layui.util
        , device = layui.device();
    //阻止IE7以下访问
    if (device.ie && device.ie < 8) {
        layer.alert('Layui最低支持ie8，您当前使用的是古老的 IE' + device.ie + '，你丫的肯定不是程序猿！');
    }
    //固定Bar
    util.fixbar();
    var json;
    json += "[";
    $(".excerpt").each(function (i) {
        json += "{";
        json += '"title":"' + $(this).find("h2 a").text() + '","pic":"' + $(this).find(".focus img").attr("src") + '",';
        json += '"createTime":"' + $(this).find("time").text() + '","excerpt":"' + $(this).find(".note").text() + '"';
        json += '}';
        if (i < ($(".excerpt").length - 1)) {
            json += ',';
        }
    });
    json += "]";
    console.log(json);
    //时钟
    var clock = $('#clock'),
		alarm = clock.find('.alarm'),
		ampm = clock.find('.ampm');
    var alarm_counter = -1;

    var digit_to_name = 'zero one two three four five six seven eight nine'.split(' ');

    var digits = {};
    var positions = [
		'h1', 'h2', ':', 'm1', 'm2', ':', 's1', 's2'
    ];
    var digit_holder = clock.find('.digits');
    $.each(positions, function () {

        if (this == ':') {
            digit_holder.append('<div class="dots">');
        }
        else {

            var pos = $('<div>');

            for (var i = 1; i < 8; i++) {
                pos.append('<span class="d' + i + '">');
            }

            // Set the digits as key:value pairs in the digits object
            digits[this] = pos;

            // Add the digit elements to the page
            digit_holder.append(pos);
        }

    });

    // Add the weekday names

    var weekday_names = 'MON TUE WED THU FRI SAT SUN'.split(' '),
		weekday_holder = clock.find('.weekdays');

    $.each(weekday_names, function () {
        weekday_holder.append('<span>' + this + '</span>');
    });

    var weekdays = clock.find('.weekdays span');

    (function update_time() {

        // Use moment.js to output the current time as a string
        // hh is for the hours in 12-hour format,
        // mm - minutes, ss-seconds (all with leading zeroes),
        // d is for day of week and A is for AM/PM

        var now = moment().format("hhmmssdA");

        digits.h1.attr('class', digit_to_name[now[0]]);
        digits.h2.attr('class', digit_to_name[now[1]]);
        digits.m1.attr('class', digit_to_name[now[2]]);
        digits.m2.attr('class', digit_to_name[now[3]]);
        digits.s1.attr('class', digit_to_name[now[4]]);
        digits.s2.attr('class', digit_to_name[now[5]]);

        // The library returns Sunday as the first day of the week.
        // Stupid, I know. Lets shift all the days one position down, 
        // and make Sunday last

        var dow = now[6];
        dow--;

        // Sunday!
        if (dow < 0) {
            // Make it last
            dow = 6;
        }

        // Mark the active day of the week
        weekdays.removeClass('active').eq(dow).addClass('active');

        // Set the am/pm text:
        ampm.text(now[7] + now[8]);


        // Is there an alarm set?

        if (alarm_counter > 0) {

            // Decrement the counter with one second
            alarm_counter--;

            // Activate the alarm icon
            alarm.addClass('active');
        }
        else if (alarm_counter == 0) {

            time_is_up.fadeIn();

            // Play the alarm sound. This will fail
            // in browsers which don't support HTML5 audio

            try {
                $('#alarm-ring')[0].play();
            }
            catch (e) { }

            alarm_counter--;
            alarm.removeClass('active');
        }
        else {
            // The alarm has been cleared
            alarm.removeClass('active');
        }

        // Schedule this function to be run again in 1 sec
        setTimeout(update_time, 1000);

    })();

    exports('app', {});
}); 