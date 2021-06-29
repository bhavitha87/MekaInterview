$(document).ajaxStart(function () {
    $('#ajaxBusy').show();
});
$(document).ajaxStop(function () {
    $('#ajaxBusy').hide();
});
$(document).ready(function () {
    $("#submit").click(function (e) {
        $.ajax({
            type: "POST",
            url: "/Home/Login",
            contentType: "application/json; charset=utf-8",
            data: '{"userName":"' + $("#UserName").val() + '","password":"' + $("#Password").val() + '"}',
            dataType: "JSON",
            success: function (response) {
                if (response !== undefined && response.result === "-1")
                    $("#error").show();
                else {
                    window.location = (response !== undefined) ? response.url : "";
                }
            },
            error: function (xhr, status, error) {
                $("#error").attr('style').display = "visible";
            }
        });

        return false;
    });
});