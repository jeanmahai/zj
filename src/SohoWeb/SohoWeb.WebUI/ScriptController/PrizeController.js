define(["app"], function (app) {

    app.register.controller("PrizeController", function ($scope) {

        $scope.data = {};
        $scope.result = [];

        $scope.insert = function () { };
        $scope.delete = function () { };
        $scope.update = function () { };
        $scope.select = function () { };
        $scope.save = function () {
            if ($scope.data.SysNo > 0) {
                $scope.update();
            }
            else {
                $scope.insert();
            }
        };

        $scope.pager = new N.Pager(1, 10, function () {
            $scope.select();
        });
    });

    return app;

});