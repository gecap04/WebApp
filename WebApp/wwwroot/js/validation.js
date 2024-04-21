const lengthValidator = (value, minLength = 2) => {
    if (value.length >= minLength)
        return true

    return false
}

const compareValidator = (value, compareValue) => {
    if (value === compareValue)
        return true

    return false
}

const checkedValidator = (element) => {
    if (element.checked)
        return true

    return false
}


const formErrorHandler = (e, validationResult) => {

}

