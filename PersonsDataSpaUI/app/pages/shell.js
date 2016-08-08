define(['plugins/router', 'durandal/app', 'jquery', 'jqueryui','toastr'], function (router, app, $, jqui, toastr) {
    return {
        router: router,
        activate: function () {
            router.map([
                { route: '', title: 'Dodawanie osob', moduleId: 'pages/welcome', nav: true },
                { route: 'addPerson', title: 'Dodawanie osob', moduleId: 'pages/personForm', nav: true }
            ]).buildNavigationModel();
            
            return router.activate();
        },
        compositionComplete: function () {
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
            };
            toastr["success"]("Strona zaladowana poprawnie");
        },
        goToTop : function() {
            $('body,html').animate({ scrollTop: 0 }, 500);
        }
    };
});