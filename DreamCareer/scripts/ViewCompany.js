

function toggleCompanyName() {
    $('.UpdateCompanyName').val($('.CompanyName').html());
    $('.UpdateCompanyName').toggle();
    $('.CompanyName').toggle();
    $('.CompanyNameExpandUpdate').toggle();
    $('.CompanyNameSubmitUpdate').toggle();
    $('.CompanyNameCancelUpdate').toggle();
}

