var Validation = (function () {
    var regId = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var password = /^\d+$/;

    var isRegId = function (reg) {
        return regId.test(reg);
    };
    var password = function (pass) {
        return password.test(pass);
    };
    var isRequire = function (value) {
        return value == "";
    };
    return {
        isRegId: isRegId,
        isRequire: isRequire,
    };
})();

var regId = $('form').find('[data-RegId]');
var password = $('form').find('[data-Password]');
 