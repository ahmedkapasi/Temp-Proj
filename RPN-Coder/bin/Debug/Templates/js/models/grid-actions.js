// Actions

(function (angular) {
    "use strict";

    function factory(
        gridActions,
        actionsMenuModel,langTranslate ) {
        var model = gridActions(),
        translate = langTranslate('@@common_module@@.@@lang_module_name@@').translate;
        model.get = function (record) {
            var actionsModel;
            
                actionsModel = {
                    actions: [
                        @@action_details@@
                       
                    ]
                };
                return actionsMenuModel(actionsModel);
        };

        return model;

    }

    angular
       .module("@@common_module@@")
       .factory('@@grid_action_model@@', [
           'rpGridActions',
           'rpActionsMenuModel',
           'appLangTranslate', 
           factory]);

})(angular);