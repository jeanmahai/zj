define(["app"],function (app) {
    app.register.controller("EmailController", function ($scope, $http, $N) {
        $scope.filter = {};
        $scope.emailes = [];
        $scope.status = [];
        $scope.selectedEmail = { };
        $scope.query = function () {
            angular.extend($scope.filter, {
                PageSize: $scope.pager.size,
                PageIndex: $scope.pager.index
            });
            $http.post("/InfoMgt/QueryMail", $scope.filter).success(function (res) {
                
            });
        };
        $scope.pager = new N.Pager(1,10,function () {
            $scope.query();
        });

        $scope.onSelect = function(sysNo) {
            for(var i=0;i<$scope.emailes.length;i++) {
                if($scope.emailes[i].SysNo==sysNo) {
                    $scope.selectedEmail = $scope.emailes[i];
                    break;
                }
            }
        };

        $http.post("/InfoMgt/GetCommonStatusList").success(function (res) {
            $scope.status = res;
        });
    });
    return app;
});