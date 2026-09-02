(function (factory) {
    if (typeof define === 'function' && define.amd) {
        define(['jquery'], factory);
    } else if (typeof exports === 'object') {
        factory(require('jquery'));
    } else {
        factory(jQuery);
    }
}(function ($) {

    function extend() {
        var options = {};
        for (var i = 0; i < arguments.length; i++) {
            var obj = arguments[i];

            for (var key in obj) {
                if (Object.prototype.hasOwnProperty.call(obj, key)) {
                    options[key] = obj[key];
                }
            }
        }
        return options;
    }

    $.cookie = function (key, value, attributes) {

        // خواندن Cookie
        if (arguments.length === 1) {
            var cookies = document.cookie ? document.cookie.split('; ') : [];

            for (var i = 0; i < cookies.length; i++) {
                var parts = cookies[i].split('=');
                var name = decodeURIComponent(parts.shift());
                var cookieValue = parts.join('=');

                if (name === key) {
                    return decodeURIComponent(cookieValue);
                }
            }

            return undefined;
        }

        // تنظیم Cookie
        attributes = extend({}, attributes);

        if (typeof attributes.expires === 'number') {
            var days = attributes.expires;
            var date = new Date();

            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));

            attributes.expires = date;
        }

        if (attributes.expires instanceof Date) {
            attributes.expires = attributes.expires.toUTCString();
        }

        var cookie = encodeURIComponent(key) + '=' + encodeURIComponent(value);

        for (var attributeName in attributes) {
            if (!Object.prototype.hasOwnProperty.call(attributes, attributeName)) {
                continue;
            }

            var attributeValue = attributes[attributeName];

            if (attributeValue === false) {
                continue;
            }

            cookie += '; ' + attributeName;

            if (attributeValue !== true) {
                cookie += '=' + attributeValue;
            }
        }

        document.cookie = cookie;
    };

}));