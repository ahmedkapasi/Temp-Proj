//  Configure App Language Keys for assign-groups

(function (angular) {
    "use strict";

    function config(appLangKeys) {
        var keys = [
            @@lang_keys@@
    	];

        appLangKeys.app('@@common_module@@.@@lang_module_name@@').set(keys);
    }

    angular
        .module("@@common_module@@")
        .config(['appLangKeysProvider', config]);
})(angular);
