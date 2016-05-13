

function toggleProfile() {
    $('.Edit_Click').val($('.NameLabel').html());
    $('.Edit_Click').toggle();
    $('.NameLabel').toggle();
    $('.ProfileCancelUpdate').toggle();
    $('.ProfileSubmitUpdate').toggle();
    $('.ProfileExpandUpdate').toggle();
}

