define(["app"], function (app) {

    app.register.controller("PrizeSentController", function ($scope, $N, $http) {

        $scope.data = {};
        $scope.result = [];

        $scope.insert = function () {
            $http.post("/GiftsMgt/InsertGiftsGrantRecord", $scope.data).success(function (res) {
                $N.info("添加成功");
            });
        };
        $scope.delete = function () { };
        $scope.update = function () { };
        $scope.select = function () {
            var filter = {
                PageIndex: $scope.pager.index,
                PageSize: $scope.pager.size
            };
            angular.extend(filter, $scope.data);
            $http.post("/GiftsMgt/QueryGiftsGrantRecord", filter).success(function (res) {
                $scope.result = res.ResultList;
                $scope.pager.setTotal(res.TotalCount);
            });
        };
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