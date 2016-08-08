define(function (require) {
    var ko = require("knockout");
    var $ = require("jquery");
    var jqmask = require("jquerymask");

    var getCounties = function (data) {
        return _(data).chain().map(function (item) {
            return {
                text: item.CountyName,
                value: item.CountyId
            };
        }, this).uniq(function (item, key, a) {
            return item.text;
        }).compact().value();
    }

    var getDistricts = function () {
        var id = this.selectedCounty();
        if (!id) {
            return[];
        }
        var data = this.locations();
        
        return _(data).chain().where({ CountyId: id }).map(function (item) {
            return {
                text: item.DistrictName,
                value: item.DistrictId
            };
        }, this).uniq(function (item, key, a) {
            return item.text;
        }).compact().value();
    }

    var getCities = function () {
        var countyId = this.selectedCounty();
        var districtId = this.selectedDistrict();
        if (!countyId && !districtId) {
            return [];
        }
        var data = this.locations();
        
        return _(data).chain().where({ CountyId: countyId, DistrictId: districtId }).map(function (item) {
            return {
                text: item.CityName,
                value: item.CityId
            };
        }, this).uniq(function (item, key, a) {
            return item.text;
        }).compact().value();
    }
    
    var setValidation = function () {
        var riseStreet = this.street();
        var risenumber = this.number();
        var risepostCode = this.postCode();
        var riseselectedCounty = this.selectedCounty();
        var riseselectedDistrict = this.selectedDistrict();
        var riseselectedCity = this.selectedCity();
        this.parentValidator(ko.validation.group(this, { deep: false }));
        this.paremtViewValidator(this.isValid());
        this.addressArray([{ Street: riseStreet, Number: risenumber, PostCode: risepostCode, CityId: riseselectedCity }]);
    }

    var getLocations = function () {
        var raiseLocations = this.locations();
        this.counties(getCounties(this.locations()));
    } 

    var ctor = function () {
        this.validationMessage = "Pole wymagane!";
        this.locations = ko.observable();
        this.counties = ko.observableArray();
        this.street = ko.observable().extend({ required: {message: this.validationMessage }});
        this.number = ko.observable().extend({ required: { message: this.validationMessage } });
        this.postCode = ko.observable().extend({ required: { message: this.validationMessage } });

        this.selectedCounty = ko.observable().extend({ required: { message: this.validationMessage } });
        this.selectedDistrict = ko.observable().extend({ required: { message: this.validationMessage } });
        this.selectedCity = ko.observable().extend({ required: { message: this.validationMessage } });

        this.districts = ko.computed(getDistricts, this);
        this.cities = ko.computed(getCities, this);
       
    };

    ctor.prototype.activate = function (settings) {
        this.parentValidator = settings.validator;
        this.paremtViewValidator = settings.viewValidator;
        this.locations = settings.locationData;
        this.addressArray = settings.addressArray;

        this.validatorMethod = ko.computed(setValidation, this);
        this.locationsComputed = ko.computed(getLocations, this);
    };

    ctor.prototype.detached = function () {
        if (this.districts) {
            this.districts.dispose();
        }
        if (this.cities) {
            this.cities.dispose();
        }
        if (this.validatorMethod) {
            this.validatorMethod.dispose();
        }
    };

    return ctor;
});