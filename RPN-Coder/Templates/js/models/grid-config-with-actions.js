(function (angular) {
    "use strict";

    function factory(gridConfig, actions, langTranslate) {

        var model = gridConfig(), translate;
        translate = langTranslate("@@lang_module_name@@").translate;
        model.get = function () {
            var cols = [];
            cols = [
				@@column_details@@
            ];
            return cols;
        };

        model.getHeaders = function () {
            var headers = [];
            headers = [
			 @@column_headers@@
			];
            return [headers];
        };

        model.getFilters = function () {
            var filters = [
                @@column_filters@@

            ];

            return filters;
        };

        return model;

    }

    angular
        .module("@@common_module@@")
        .factory("@@grid_config_model@@", [
			"rpGridConfig",
            "@@grid_action_model@@",
            "appLangTranslate",
            factory
        ]);
})(angular);
wwef