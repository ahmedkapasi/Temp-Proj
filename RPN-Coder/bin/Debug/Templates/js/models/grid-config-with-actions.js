(function (angular) {
    "use strict";

    function factory(gridConfig, actions, langTranslate) {

        var model = gridConfig(), translate;
        translate = langTranslate("@@common_module@@.@@lang_module_name@@").translate;
        model.get = function () {
            var cols = [];
            cols = [
                {
                    key: 'action',
                    type: 'actionsMenu',
                    getActions: actions.get
                },
				@@column_details@@
            ];
            return cols;
        };

        model.getHeaders = function () {
            var headers = [];
            headers = [
                {
                    key: 'action',
                    text: 'Actions',
                },    
			    @@column_headers@@
			];
            return [headers];
        };

        model.getFilters = function () {
            var filters = [
                {
                    key: 'action',
                },
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