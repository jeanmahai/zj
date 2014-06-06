define(["app"], function (app) {

    app.register.controller("PrizeController", function ($scope, $N, $http, $routeParams) {

        $scope.data = {};
        $scope.result = [];

        $scope.insert = function () {
            $http.post("/GiftsMgt/InsertGifts", $scope.data).success(function (res) {
                $N.info("添加成功!");
            });
        };
        $scope.delete = function () {
            if(confirm("是否确认删除?")) {
                var arr = [];
                angular.forEach($scope.result, function (item) {
                    if (item.Checked) arr.push(item.SysNo);
                });
                $http.post("/GiftsMgt/DeleteGift",arr).success(function () {
                    $N.info("删除成功");
                    $scope.select();
                });
            }
        };
        $scope.update = function () {
            $http.post("/GiftsMgt/UpdateGiftsStatus", $scope.data).success(function (res) {
                $N.info("修改成功!");
            });
        };
        $scope.select = function () {
            var filter = {
                PageIndex: $scope.pager.index,
                PageSize: $scope.pager.size
            };
            angular.extend(filter, $scope.data);
            $http.post("/GiftsMgt/QueryGifts", filter).success(function (res) {
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
        $scope.status = [];
        $http.post("/GiftsMgt/GetCommonStatusList").success(function (res) {
            $scope.status = res;
        });

        var sysNo = parseInt($routeParams["action"]);
        if (!isNaN(sysNo)) {
            $http.post("/GiftsMgt/QueryGifts", {
                PageIndex: 1,
                PageSize: 1,
                SysNo: sysNo
            }).success(function (res) {
                $scope.data = res.ResultList[0];
            });
        }
    });

    return app;

});