var Validation = (function () {
    var regId = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var password = /^\d+$/;

    var isRegId = function (reg) {
        return regId.test(reg);
    };
    var isPassword = function (pass) {
        return password.test(pass);
    };
    var isRequire = function (value) {
        return value == "";
    };
    return {
        isRegId: isRegId,
        isRequire: isRequire,
        isPassword: isPassword,
    };
})();

var required = $('form').find('[data-required]');
var regId = $('form').find('[data-RegId]');
var password = $('form').find('[data-Password]');

$('#submit').on('click', function () {
    required.each(function () {
        if (Validation.isRequire($(this).val())) {
            $(this).siblings('div.errorReq').show();
        }
    });
    regId.each(function () {
        if (!Validation.isRegId($(this).val())) {
            $(this).siblings(div.errorRegId).show();
        }
    });
    password.each(function () {
        if (!Validation.isPassword($(this).val()){
            $(this).siblings(div.errorPassword).show();
        }
    });
});