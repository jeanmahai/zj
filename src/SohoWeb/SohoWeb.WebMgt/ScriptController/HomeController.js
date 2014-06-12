/**
 * Created by Jeanma on 14-5-5.
 */
define(["app"], function (app) {
    app.register.controller("homeController", function ($scope, $http) {
        $scope.home = function () {
            alert("home");
        };

        $scope.logs = [];
        $scope.getLogs = function () {
            var filter = {
                PageIndex: 0,
                PageSize: 6
            };
            $http.post("/ControlPanel/QueryLogs", filter).success(function (res) {
                $scope.logs = res.ResultList;
            });
        };
        $scope.getLogs();
    });

    return app;
});