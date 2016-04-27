
$(document).ready(function () {
    $('.asp-username-input').change(function () {
        $('.asp-username-input-error-label').html("");
    });
});


function validate_password() {

    var password_inputs = $('.password-input');
//    var password1 = $(password_inputs[0]).val()
//    var password2 = $(password_inputs[1]).val()

    if (password_inputs.length < 1){
        $('#password-input-error-label')
            .text('Please enter a password');
        $('#password-input-error-label').show();
        return false;
    }

    $('#password-input-error-label').hide();
    return true;
}


function validate() {
    alert("CALLED");
    if (!validate_password()) {
        alert("Please fix the problem with " +
            "your password before you submit");
        return false;
    }

    return true;
}
