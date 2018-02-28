//  English Resource Bundle for assign-groups

(function (angular) {
    "use strict";

    function config(appLangBundle) {
        var bundle = appLangBundle.lang('en-us').app('@@common_module@@.@@lang_module_name@@');

        bundle.set({         
            @@lang_resources@@
        });
    }

    angular
        .module("@@common_module")
        .config(['appLangBundleProvider', config]);
})(angular);
