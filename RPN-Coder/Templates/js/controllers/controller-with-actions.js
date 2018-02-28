(function (angular) {
    "use strict";

    function @@controller_name@@($scope, langTranslate,,model, gridConfig, gridActions, svc) {
        var vm = this, model, translate;
        vm.translate = langTranslate('@@module_name@@').translate;

        vm.init = function () {
            model = vm.model = model;
            model.init();
            gridConfig.setSrc(vm);
            gridActions.setSrc(vm);
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
            '@@grid_action_model@@',
            '@@service_model@@',
            @@controller_name@@
        ]);
})(angular);