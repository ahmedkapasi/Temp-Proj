(function (angular) {
    "use strict";

    function @@controller_name@@($scope,langTranslate, model, gridConfig, svc) {
        var vm = this, translate;
        vm.translate = langTranslate('@@common_module@@.@@lang_module_name@@').translate;
        vm.init = function () {
            vm.model = model;
            gridConfig.setSrc(vm);
            vm.destWatch = $scope.$on("$destroy", vm.destroy);
            return vm;
        };

        vm.destroy = function ()
        {
            model.grid.destroy();
            model = undefined;
            vm.destWatch();
        };
        return vm.init();
    }

    angular
        .module("@@common_module@@")
        .controller("@@controller_name@@", [
           '$scope',           
           'appLangTranslate',
            '@@model_name@@',            
            '@@grid_config_model@@',
            '@@service_model@@',
            @@controller_name@@
        ]);
})(angular);