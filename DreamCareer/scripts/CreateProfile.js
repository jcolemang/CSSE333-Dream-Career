$(document).ready(function () {
    $('.gender-select').change(function () {
        genderCheck();
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
