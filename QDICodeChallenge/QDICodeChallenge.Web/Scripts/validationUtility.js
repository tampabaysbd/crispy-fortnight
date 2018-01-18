var ValidationUtility = function () {

    var validationElements = $('[data-role="validate"]'), elementCount = 0;
    validationElements.popover({ placement: 'top' });

    validationElements.on('invalid', function () {
        if (elementCount === 0) {
            $('#' + this.id).popover('show');
            $('#' + this.id).focus();
            elementCount++;
        }
    });

    validationElements.on('blur', function () {
        $('#' + this.id).popover('hide');
    });

    var validate = function (formSelector) {
        elementCount = 0;

        if (formSelector.indexOf('#') === -1) {
            formSelector = '#' + formSelector;
        }
        // checkValidity native HTML5 validation api
        return $(formSelector)[0].checkValidity();
    }

    return {
        validate: validate
    };
}

