

/* When the user clicks on the button,
toggle between hiding and showing the dropdown content */
/*function myFunction()
{
	$('#myDropdown').show();
	return false;
}


	// Close the dropdown menu if the user clicks outside of it
	window.onclick = function (event) {
		if (!event.target.matches('.dropbtn')) {

			var dropdowns = document.getElementsByClassName("dropdown-content");
			var i;
			for (i = 0; i < dropdowns.length; i++) {
				var openDropdown = dropdowns[i];
				$(openDropdown).hide();
			}
		}
	}  */

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
