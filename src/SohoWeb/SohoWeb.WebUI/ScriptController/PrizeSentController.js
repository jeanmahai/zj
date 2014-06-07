var prizeSentScope;

define(["app"], function (app) {

    app.register.controller("PrizeSentController", function ($scope, $N, $http) {

        prizeSentScope = $scope;

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

        $scope.prizeFilter = {};
        $scope.prizeResult = [];
        $scope.prizeStatus = [];
        $scope.selectPrize = function () {
            var filter = {
                PageIndex: $scope.prizePager.index,
                PageSize: $scope.prizePager.size
            };
            angular.extend(filter, $scope.prizeFilter);
            $http.post("/GiftsMgt/QueryGifts", filter).success(function (res) {
                $scope.prizeResult = res.ResultList;
                $scope.prizePager.setTotal(res.TotalCount);
            });
        };
        $scope.prizePager = new N.Pager(1, 10, function () {
            $scope.selectPrize();
        });
        $http.post("/GiftsMgt/GetCommonStatusList").success(function (res) {
            $scope.prizeStatus = res;
        });
        $scope.selectedPrize = {};
        $scope.hasSelected = function () {
            var selected = false;
            angular.forEach($scope.prizeResult, function (value) {
                if (value.Checked) {
                    selected = true;
                    $scope.selectedPrize = value;
                }
            });
            return selected;
        };
        $scope.bindPrize = function () {
            $scope.data.GiftSysNo = $scope.selectedPrize.SysNo;
            $scope.data.GiftName = $scope.selectedPrize.GiftName;
            $scope.$apply();
        };

    });

    return app;

});