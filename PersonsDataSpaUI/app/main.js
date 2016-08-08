requirejs.config({
    paths: {
        'text': '../lib/require/text',
        'durandal':'../lib/durandal/js',
        'plugins' : '../lib/durandal/js/plugins',
        'transitions' : '../lib/durandal/js/transitions',
        'knockout': '../lib/knockout/knockout-3.1.0',
        'bootstrap': '../lib/bootstrap/js/bootstrap',
        'jquery': '../lib/jquery/jquery-1.9.1',
        'jqueryui': '../lib/jquery/jquery-ui.min',
        'jquerymask': '../lib/jquery/jquery.maskedinput.min',
        'validation': '../lib/knockout/knockout.validation',
        'toastr': '../lib/toastr',
        'underscore': '../lib/underscore-min'
    },
    shim: {
        'bootstrap': {
            deps: ['jquery'],
            exports: 'jQuery'
       }
    }
});

define(['durandal/system', 'durandal/app', 'durandal/viewLocator', 'knockout', 'jquery', 'toastr'], function (system, app, viewLocator, ko, $, toastr) {
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = 'Maciej Stellmach - zadanie rekrutacyjne';

    app.configurePlugins({
        router:true,
        dialog: true
    });
    

    var delay = function (ctx) {
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

        $.ajax({
            url: "http://localhost:18955/api/Default/Default",
            type: "POST",
            dataType: 'json',
            success: function () {
                if (!ctx.WebApiReady()) {
                    toastr["success"]("Poprawna inicjacja serwera WebAPI");
                    ctx.WebApiReady(true);
                    viewLocator.useConvention();
                    app.setRoot('pages/shell', 'entrance');
                }
            },
            error: function (jqXHR, textStatus, err) {
                toastr["error"]('Blad przy inicjacji WebAPI. ' + err);
            }
        });
        
        if (!ctx.WebApiReady()) {
            setTimeout(function () { delay(ctx); }, 2000);
        }
    }

    app.start()
        .then(function () {
            this.WebApiReady = ko.observable(false);
            delay(this);
        });
});