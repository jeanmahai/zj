/**
 * Created by Jeanma on 14-5-5.
 */
(function () {

    //config
    window["appConfig"] = {

        //定义是否在http的时候显示loading
        showLoading: true,
        serviceBaseUrl: "",
        login: "Login/Index",
        loadingDelay: 500,
        //这个值可以缺省
        loadingDom: document.getElementById("divLoading"),

        //定义需要依赖的js文件
        angularModualJS: ["angularAMD"
            , "angular-route"
            //, "ng-grid"
            , "angular-cookies"
            , "angular-date"],

        //定义需要依赖的angular modual
        angularModualNames: ["ngRoute"//
            // , "ngGrid"
            , "ngCookies"
            , "NProvider"
            , "ui.date"],
        index: "/home",
        viewBasePath: "views/",

        parentController: function ($scope, $cookies) {
            $scope._UserName = "";
            if ($cookies && $cookies["soho.web.username"]) {
                $scope._UserName = $cookies["soho.web.username"].replace(/\"/gi, "");
                $("#spanUserName").show();
            }

            $scope.resetForm = function(form) {
                if(form && form.reset) {
                    form.reset();
                }
                else {
                    angular.element("form:first")[0].reset();
                }
            };
        }
    };
    //url route
    window["appRouteUrl"] = [{
        routeUrl: "/email/:action",
        templateUrl: function ($routeParams) {
            var action = $routeParams["action"];
            if (new RegExp("send", "i").test(action)) {
                return "../HtmlViews/email_send.html";
            }
            else if (new RegExp("[0-9]+", "i").test(action)) {
                return "../HtmlViews/prizesent_maintain.html";
            }
            else {
                return "../HtmlViews/email.html";
            }
        },
        controller: "EmailController"
    },{
        routeUrl: "/prizesent/:action",
        templateUrl: function ($routeParams) {
            var action = $routeParams["action"];
            if (new RegExp("insert", "i").test(action)) {
                return "../HtmlViews/prizesent_maintain.html";
            }
            else if (new RegExp("[0-9]+", "i").test(action)) {
                return "../HtmlViews/prizesent_maintain.html";
            }
            else {
                return "../HtmlViews/prizesent.html";
            }
        },
        controller: "PrizeSentController"
    },{
        routeUrl: "/prize/:action",
        templateUrl: function ($routeParams) {
            var action = $routeParams["action"];
            if (new RegExp("insert", "i").test(action)) {
                return "../HtmlViews/prize_maintain.html";
            }
            else if (new RegExp("[0-9]+", "i").test(action)) {
                return "../HtmlViews/prize_maintain.html";
            }
            else {
                return "../HtmlViews/prize.html";
            }
        },
        controller: "PrizeController"
    }, {
        routeUrl: "/log",
        templateUrl: "../HtmlViews/log.html",
        controller: "LogController"
    }, {
        routeUrl: "/role/allot/fun/:RoleSysNo",
        templateUrl: "../HtmlViews/role_allot_fun.html",
        controller: "RoleController"
    }, {
        routeUrl: "/user/allot/:name/:SysNo",
        templateUrl: function ($routeParams) {
            return "../HtmlViews/allot_" + $routeParams["name"] + ".html";
        },
        controller: "ControlPanelController"
    }, {
        routeUrl: "/role/:SysNo",
        templateUrl: "../HtmlViews/role_update.html",
        controller: "RoleController"
    }, {
        routeUrl: "/role_insert",
        templateUrl: "../HtmlViews/role_insert.html",
        controller: "RoleController"
    }, {
        routeUrl: "/role",
        templateUrl: "../HtmlViews/role.html",
        controller: "RoleController"
    }, {
        routeUrl: "/funs/:SysNo",
        templateUrl: "../HtmlViews/funs_update.html",
        controller: "FunsController"
    }, {
        routeUrl: "/funs_insert",
        templateUrl: "../HtmlViews/funs_insert.html",
        controller: "FunsController"
    }, {
        routeUrl: "/funs",
        templateUrl: "../HtmlViews/funs.html",
        controller: "FunsController"
    }, {
        routeUrl: "/user",
        templateUrl: "../HtmlViews/user.html",
        controller: "ControlPanelController"
    }, {
        routeUrl: "/user/add",
        templateUrl: "../HtmlViews/user_add.html",
        controller: "ControlPanelController"
    }, {
        routeUrl: "/user/modifyPsw",
        templateUrl: "../HtmlViews/user_modify_password.html",
        controller: "ControlPanelController"
    }, {
        routeUrl: "/user/:sysNo",
        templateUrl: "../HtmlViews/user_edit.html",
        controller: "ControlPanelController"

    }, {
        routeUrl: "/home",
        templateUrl: "../HtmlViews/home.html",
        controller: "homeController"
    }, {
        routeUrl: "/customer",
        templateUrl: "../HtmlViews/customer.html",
        controller: "CustomerController"
    }, {
        routeUrl: "/customer/add",
        templateUrl: "../HtmlViews/customer_add.html",
        controller: "CustomerController"
    }, {
        redirectTo: "/home"
    }];

    function getShortDateString() {
        var date = new Date();
        //cache 1 hour
        //return date.getFullYear()+date.getMonth()+date.getDate()+date.getHours();

        //no cache
        return Math.random();
    }

    function loadCss(url) {
        var link = document.createElement("link");
        link.type = "text/css";
        link.rel = "stylesheet";
        link.href = url;
        document.getElementsByTagName("head")[0].appendChild(link);
    }

    require.config({
        baseUrl: "../../ScriptController",
        paths: {
            'angular': '../res/lib/angular.min',
            'angular-route': '../res/lib/angular-route.min',
            'angularAMD': '../res/lib/angularAMD.min',
            'angular-cookies': '../res/lib/angular-cookies.min',
            'jquery-ui': "../res/lib/jquery-ui",
            "angular-date": "../res/lib/date",
            'jquery': '../res/lib/jquery.min',

            "htmleditor": "../res/lib/nicEdit",

            'app': "../res/app"
            , "page_init": "../res/scripts/page_init"
        },

        // Add angular modules that does not support AMD out of the box, put it in a shim
        shim: {
            'angular': {
                deps: ["jquery"],
                init: function () {
                    loadCss("../../res/main.css");
                }
            },
            'angularAMD': ['angular'],
            'angular-route': ['angular'],
            "angular-cookies": ["angular"],
            "jquery-ui": ["jquery"],
            "angular-date": {
                deps: ["angular", "jquery-ui"],
                init: function (a, b, c) {
                    loadCss("res/lib/pepper-grinder/jquery-ui.min.css");
                }
            },
            'app': {
                deps: ["angular", "page_init"],
                init: function () {

                }
            }
            , "page_init": ["jquery"]
        }

        // kick start application
        , deps: ['app']
        //set javascript no cache
        , urlArgs: "_=" + getShortDateString()
    });
})();
