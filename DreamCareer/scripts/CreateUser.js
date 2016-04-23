
$(document).ready(function()
{
    $('.password-input').change(function () {
        validate_password();
    })

    $('.email-input').change(function () {
        validate_email();
    })


    function validate_password() {

        var password_inputs = $('.password-input');
        var password1 = $(password_inputs[0]).val()
        var password2 = $(password_inputs[1]).val()

        if (password1 !== password2) {
            $('#password-input-error-label')
                .text('Passwords do not match');
            $('#password-input-error-label').show();
            return;
        }
        else {
            $('#password-input-error-label').hide();
        }
    }

    function validate_email() {
        var emails = $('.email-input');
        var email1 = $(emails[0]).val();
        var email2 = $(emails[1]).val();

        if (email1 !== email2) {
            $('#email-input-error-label')
                .text('Emails do not match');
            $('#email-input-error-label').show();
            return;
        }
        else {
            $('#email-input-error-label').hide();
        }
    }
})
