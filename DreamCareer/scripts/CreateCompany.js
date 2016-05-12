
$(document).ready(function () {
    $('.CompanyName').change(function () {
        validateCompanyName()
    });
    $('.CompanySize').change(function () {
        validateCompanySize()
    });
})


function validateCompanyName() {
    var nameInput = $('.CompanyName').val();
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
    if (/\s*0+\s*/.test(sizeInput))
    {
        $('#company-size-error-label').html("A company with no one in" +
            " it isn't must of a company...");
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


function validateCompany() {
    if (!validateCompanyName())
        return false;
    if (!validateCompanySize())
        return false;
    return true;
}
