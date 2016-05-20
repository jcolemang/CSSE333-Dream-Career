$(document).ready(function () {
    $('.gender-select').change(function () {
        genderCheck();
    })
    $('.name-input').change(function () {
        nameCheck();
    })
})


function checkAll() {
    if (!nameCheck())
        return false;
    if (!genderCheck())
        return false;
    return true;
}


function nameCheck() {
    var name = $('.name-input').val();

    if (!/[\-a-zA-Z ]+/.test(name))
    {
        $('#name-error-label').text('I don\'t believe you.');
        $('#name-error-label').show();
        return false;
    }

    $('#name-error-label').hide();
    return true;
}


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
