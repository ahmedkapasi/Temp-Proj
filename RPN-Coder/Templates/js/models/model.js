(function (angular) {
    "use strict";

    function factory(gridModel, gridConfig, gridPaginationModel) {
        var model = {}, grid;
        var gridPagination, gridPaginationConfig = {
            currentPage: 0,
            pagesPerGroup: 5,
            recordsPerPage: 20,
            currentPageGroup: 0
        };

        model.init = function () {
            grid = model.grid = gridModel();
            grid.setConfig(gridConfig).setEmptyMsg('No results were found');
            model.gridPagination = gridPagination = gridPaginationModel();
            gridPagination
                      .setGrid(grid)
                      .trackSelection(gridConfig.getTrackSelectionConfig());
            gridPagination
                           .setConfig(gridPaginationConfig);
            return model;
        };

        
        model.setGridData = function (response) {
            gridPagination.setData(response.data.records).goToPage({
                number: 0
            });
            
            model.setBusyIndicator(false);
        };

        
        model.destroy = function () {
            grid.destroy();
            gridPagination.destroy();
            model = undefined;
        };

        return model.init();

    }

    angular
        .module("@@common_module@@")
        .factory("@@model_name@@", [
          'rpGridModel',
          '@@grid_config@@',
          'rpGridPaginationModel',
          factory
        ]);
})(angular);
