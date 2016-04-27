
$(document).ready(function () {
    $('.password-input').change(function () {
        validate_password();
    });

    $('.email-input').change(function () {
        $('.asp-email-input-error-label').html("");
        validate_email();
    });

    $('.asp-username-input').change(function () {
        $('.asp-username-input-error-label').html("");
    });
});


function validate_password() {

    var password_inputs = $('.password-input');
    var password1 = $(password_inputs[0]).val()
    var password2 = $(password_inputs[1]).val()

    if (password1 !== password2) {
        $('#password-input-error-label')
            .text('Passwords do not match');
        $('#password-input-error-label').show();
        return false;
    }
    else if (password1.length < 1){
        $('#password-input-error-label')
            .text('Please enter a password');
        $('#password-input-error-label').show();
        return false;
    }

    $('#password-input-error-label').hide();
    return true;
}


function validate_email() {
    var emails = $('.email-input');
    var email1 = $(emails[0]).val();
    var email2 = $(emails[1]).val();

    if (email1 !== email2) {
        $('#email-input-error-label')
            .text('Emails do not match');
        $('#email-input-error-label').show();
        return false;
    }
    else if (!is_an_email(email1)) {
        $('#email-input-error-label')
            .text('That doesn\'t look like an email...');
        $('#email-input-error-label').show();
        return false;
    }
    else {
        $('#email-input-error-label').hide();
        return true;
    }
}


function is_an_email(email) {
    return /[a-z][a-z\.\-_]*@[a-z][a-z\.\-_]*(\.com|\.net|\.edu)/.test(email.toLowerCase());
}


function validate() {
    alert("CALLED");
    if (!validate_email()) {
        alert("Please fix the problem with " +
            "your email before you submit");
        return false;
    }

    if (!validate_password()) {
        alert("Please fix the problem with " +
            "your password before you submit");
        return false;
    }

    return true;
}
