$(document).ready(function () {
    $('.gender-select').change(function () {
        genderCheck();
    })
})
$(document).ready(function () {
    $('.prof-username').change(function () {
        usernameExistCheck();
    })
})

function genderCheck() {
	var gen = $('.gender-select').val();
	if (gen == 1) {
	    $('#gender-not-selected-error').text('Gender not selected');
	    $('#gender-not-selected-error').show();
	    return false;
	}
	$('#gender-not-selected-error').hide();
	return true;
}
/*function usernameExistCheck() {
      
    // if () {
   
        $('#username-input-error-label')
            .text('Passwords do not match');
        $('#username-input-error-label').show();
        return false;
   // }
}    */
