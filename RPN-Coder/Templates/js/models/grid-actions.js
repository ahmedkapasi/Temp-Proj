// Actions

(function (angular) {
    "use strict";

    function factory(
        gridActions,
        actionsMenuModel ) {
        var model = gridActions();

       

        model.get = function (record) {
            var actionsModel;
            
                actionsModel = {
                    actions: [
                        //add actions here
                       
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
           factory]);

})(angular);