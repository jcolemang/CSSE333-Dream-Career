
$(document).ready(function () {

    /*
    if ( $('.CompanyDescription').html() === "" )
        $('#company-description-row').hide();

    if ($('.CompanyStreet').html() === "")
        $('#company-street-row').hide();

    if ($('.CompanyCity').html() === "")
        $('#company-city-row').hide();
        */
})

function toggleCompanyName() {
    $('.UpdateCompanyName').val($('.CompanyName').html());
    $('.UpdateCompanyName').toggle();
    $('.CompanyName').toggle();
    $('#company-name-expand-update').toggle();
    $('.CompanyNameSubmitUpdate').toggle();
    $('#company-name-cancel-update').toggle();
}


function toggleCompanySize() {
    $('.UpdateCompanySize').val($('.CompanySize').html());
    $('.UpdateCompanySize').toggle();
    $('.CompanySize').toggle();
    $('#company-size-expand-update').toggle();
    $('.CompanySizeSubmitUpdate').toggle();
    $('#company-size-cancel-update').toggle();
}


function toggleCompanyDescription() {
    $('.UpdateCompanyDescription').val($('.CompanyDescription').html());
    $('.UpdateCompanyDescription').toggle();
    $('.CompanyDescription').toggle();
    $('#company-description-expand-update').toggle();
    $('.CompanyDescriptionSubmitUpdate').toggle();
    $('#company-description-cancel-update').toggle();
}


function toggleCompanyStreet() {
    $('.UpdateCompanyStreet').val($('.CompanyStreet').html());
    $('.UpdateCompanyStreet').toggle();
    $('.CompanyStreet').toggle();
    $('#company-street-expand-update').toggle();
    $('.CompanyStreetSubmitUpdate').toggle();
    $('#company-street-cancel-update').toggle();
}


function toggleCompanyCity() {
    $('.UpdateCompanyCity').val($('.CompanyCity').html());
    $('.UpdateCompanyCity').toggle();
    $('.CompanyCity').toggle();
    $('#company-city-expand-update').toggle();
    $('.CompanyCitySubmitUpdate').toggle();
    $('#company-city-cancel-update').toggle();
}


function toggleCompanyState() {
    $('.UpdateCompanyState').val($('.CompanyState').html());
    $('.UpdateCompanyState').toggle();
    $('.CompanyState').toggle();
    $('#company-state-expand-update').toggle();
    $('.CompanyStateSubmitUpdate').toggle();
    $('#company-state-cancel-update').toggle();
}


function toggleCompanyZipcode() {
    $('.UpdateCompanyZipcode').val($('.CompanyZipcode').html());
    $('.UpdateCompanyZipcode').toggle();
    $('.CompanyZipcode').toggle();
    $('#company-zipcode-expand-update').toggle();
    $('.CompanyZipcodeSubmitUpdate').toggle();
    $('#company-zipcode-cancel-update').toggle();
}

