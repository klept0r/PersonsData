define(function (require) {
    var ko = require("knockout");
    var validation = require("validation");
    var address = require("components/address");
    var $ = require("jquery");
    var jqmask = require("jquerymask");
    var toastr = require("toastr");
    var _ = require("underscore");

    var setToastr = function() {
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "2000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    }

    var callWebApiServer = function (controllerName, observable, inputData) {
        var tet = inputData;
        $.ajax({
            url: "http://localhost:18955/api/" + controllerName,
            type: "POST",
            dataType: 'json',
            data: { '': inputData },
            success: function(returnData) {
                toastr["success"]("Poprawne odpytanie serwera WebAPI");
                observable(returnData);
            },
            error: function(jqXHR, textStatus, err) {
                toastr["error"]('Blad w odpytaniu serwera WebAPI. ' + err);
            }
        });
    }

    var ctor = function () {
        setToastr();
        this.formName = 'Dodaj nowe dane osobowe:';
        this.validationMessage = "Pole wymagane!";
        this.correspondenceAddressVisible = ko.observable(false);
        this.locationData = ko.observable();
        callWebApiServer("location/GetLocations", this.locationData, []);

        this.name = ko.observable().extend({ required: { message: this.validationMessage }});
        this.surname = ko.observable().extend({ required: { message: this.validationMessage } });
        this.yearOfBirth = ko.observable().extend({ required: { message: this.validationMessage } });

        this.residenceAddress = ko.observableArray();
        this.correspondenceAddress = ko.observableArray();

        this.correspondenceAddressValidator = ko.observable();
        this.residenceAddressValidator = ko.observable();
        this.correspondenceAddressViewValidator = ko.observable();
        this.residenceAddressViewValidator = ko.observable();
    };
  

    ctor.prototype.compositionComplete = function () {
        $('[id="postCodeMask"]').mask("99-999", { placeholder: "xx-xxx" });
        $("#datePickerMask").datepicker().mask("99/99/9999", { placeholder: "dd/mm/yyyy" });
    }

    ctor.prototype.SubmitForm = function () {
        var errors = ko.validation.group(this, { deep: false });
      
        this.residenceAddressValidator().showAllMessages();
        errors.showAllMessages();
        if (this.correspondenceAddressVisible()) {
            this.correspondenceAddressValidator().showAllMessages();
            if (this.isValid() && this.correspondenceAddressViewValidator() && this.residenceAddressViewValidator()) {
                var person = [{ Name: this.name(), Surname: this.surname(), YearOfBirth: this.yearOfBirth(), ResidenceAddress: { Street: this.residenceAddress()[0].Street, Number: this.residenceAddress()[0].Number, PostCode: this.residenceAddress()[0].PostCode, CityId: this.residenceAddress()[0].CityId }, CorrespondenceAddress: { Street: this.correspondenceAddress()[0].Street, Number: this.correspondenceAddress()[0].Number, PostCode: this.correspondenceAddress()[0].PostCode, CityId: this.correspondenceAddress()[0].CityId } }];
                callWebApiServer("person/SetNewPerson", ko.observable(), person);
            }
        } else {
            if (this.isValid() && this.correspondenceAddressViewValidator()) {
                var person = [{ Name: this.name(), Surname: this.surname(), YearOfBirth: this.yearOfBirth(), ResidenceAddress: { Street: this.residenceAddress()[0].Street, Number: this.residenceAddress()[0].Number, PostCode: this.residenceAddress()[0].PostCode, CityId: this.residenceAddress()[0].CityId } }];
                callWebApiServer("person/SetNewPerson", ko.observable(), person);
            }
        }
    };

    return ctor;
});