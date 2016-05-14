

function toggleProfile() {
    $('.Edit_Click').val($('.NameText').html());
    $('.Edit_Click').toggle();
    $('.NameText').toggle();
    $('#profile-name-expand-update').toggle();
    $('.ProfileSubmitUpdate').toggle();
    $('#profile-name-cancel-update').toggle();
}

function toggleGender() {
    $('.UpdateGenfer').val($('.GenderText').html());
    $('.UpdateGender').toggle();
    $('.GenderText').toggle();
    $('#profile-gender-expand-update').toggle();
    $('.GenderSubmitUpdate').toggle();
    $('#profile-gender-cancel-update').toggle();
}

function toggleMajor() {
    $('.UpdateMajor').val($('.MajorText').html());
    $('.UpdateMajor').toggle();
    $('.MajorText').toggle();
    $('#profile-major-expand-update').toggle();
    $('.MajorSubmitUpdate').toggle();
    $('#profile-major-cancel-update').toggle();
}

function toggleExperience() {
    $('.UpdateExperience').val($('.ExperienceText').html());
    $('.UpdateExperience').toggle();
    $('.ExperienceText').toggle();
    $('#profile-experience-expand-update').toggle();
    $('.ExperienceSubmitUpdate').toggle();
    $('#profile-experience-cancel-update').toggle();
}

function toggleStreet() {
    $('.UpdateStreet').val($('.StreetText').html());
    $('.UpdateStreet').toggle();
    $('.StreetText').toggle();
    $('#profile-street-expand-update').toggle();
    $('.StreetSubmitUpdate').toggle();
    $('#profile-street-cancel-update').toggle();
}

function toggleCity() {
    $('.UpdateCity').val($('.CityText').html());
    $('.UpdateCity').toggle();
    $('.CityText').toggle();
    $('#profile-city-expand-update').toggle();
    $('.CitySubmitUpdate').toggle();
    $('#profile-city-cancel-update').toggle();
}

function toggleState() {
    $('.UpdateState').val($('.StateText').html());
    $('.UpdateState').toggle();
    $('.StateText').toggle();
    $('#profile-state-expand-update').toggle();
    $('.StateSubmitUpdate').toggle();
    $('#profile-state-cancel-update').toggle();
}

function toggleZipcode() {
    $('.UpdateZipcode').val($('.ZipcodeText').html());
    $('.UpdateZipcode').toggle();
    $('.ZipcodeText').toggle();
    $('#profile-zipcode-expand-update').toggle();
    $('.ZipcodeSubmitUpdate').toggle();
    $('#profile-zipcode-cancel-update').toggle();
}