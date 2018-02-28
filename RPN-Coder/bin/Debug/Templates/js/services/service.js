(function (angular) {
    "use strict";

    function factory($resource,$http) {
        var svc = {};

      
        return svc;

    
    }

    angular
        .module("@@common_module@@")
        .factory('@@service_model@@', [
           '$resource', '$q', '$http',
            factory]);
})(angular);
