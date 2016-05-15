

function zipcodeIsValid(zipcode) {
    return /[0-9]{5}/.test(zipcode);
}


function validateSalary(salary) {
    return /[0-9]*\.[0-9][0-9]/.test(salary) || /\$[0-9]*/.test(salary);
}