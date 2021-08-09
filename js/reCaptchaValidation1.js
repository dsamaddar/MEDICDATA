var onloadCallback = function () {
    grecaptcha.render('dvCaptcha', {
        'sitekey': '6LcmSEgaAAAAAFOrg5yqDLg5zFVGDFepkNH-phjw',
        'callback': function (response) {
            $.ajax({
                type: "POST",
                url: "Contact.aspx/VerifyCaptcha",
                data: "{response: '" + response + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var captchaResponse = jQuery.parseJSON(r.d);
                    if (captchaResponse.success) {
                        $("[id*=txtCaptcha]").val("6LfSg5YUAAAAALRc8OZ7gGpylmDxKZTCFdMK-9-x");
                        $("[id*=rfvCaptcha]").hide();
                    } else {
                        $("[id*=txtCaptcha]").val("");
                        $("[id*=rfvCaptcha]").show();
                        var error = captchaResponse["error-codes"][0];
                        $("[id*=rfvCaptcha]").html("RECaptcha error. " + error);

                    }
                }
            });
        }
    });
};