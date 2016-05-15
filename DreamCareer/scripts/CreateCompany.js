
$(document).ready(function () {
    $('.CompanyName').change(function () {
        validateCompanyName()
    });
    $('.CompanySize').change(function () {
        validateCompanySize()
    });
    $('.ZipcodeTextBox').change(function () {
        validateZipcode();
    });
})


function validateCompanyName() {
    var nameInput = $('.CompanyName').val();
    $('.CompanyNameErrorLabel').html('');
    if (/^\s*$/.test(nameInput))
    {
        $('#name-input-error-label').html('Your company needs a name!');
        return false;
    }

    $('#name-input-error-label').html('');
    return true;
}


function validateCompanySize() {
    var sizeInput = $('.CompanySize').val();
    if (sizeInput === '' || sizeInput === null)
    {
        $('#company-size-error-label').html("Please enter a size.");
        return false;
    }
    if (/^\s*0+\s*$/.test(sizeInput))
    {
        $('#company-size-error-label').html("A company with no one in" +
            " it isn't much of a company...");
        return false;
    }
    if (/^\s+$/.test(sizeInput))
    {
        $('#company-size-error-label').html("I love whitespace too, but come on.");
        return false;
    }
    if (!/^\s*[0-9]+\s*/.test(sizeInput))
    {
        $('#company-size-error-label').html("That isn't a valid number.");
        return false;
    }

    $('#company-size-error-label').html('');
    return true;

}

function validateZipcode() {

    // Because it is optional
    if ($('.ZipcodeTextBox').val() === "")
        return true;

    if (!zipcodeIsValid($('.ZipcodeTextBox').val())) {
        $('#zipcode-error-label').html('Not a valid zipcode');
        return false;
    }

    $('#zipcode-error-label').html('');
    return true;
}


function validateCompany() {
    var isValid = true;
    isValid = isValid && validateCompanyName();
    isValid = isValid && validateCompanySize();
    isValid = isValid && validateZipcode();
    return isValid;
}
