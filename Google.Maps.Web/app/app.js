var App;
(function (App) {
    "use strict";
    var AppBuilder = (function () {
        function AppBuilder(name) {
            this.app = angular.module(name, [
                "ngAnimate",
                "ngRoute",
                "ngSanitize",
                "ngResource"
            ]);

            this.app.controller("mapController", [
                "$scope", function ($scope) {
                    return new App.Controllers.MapController($scope);
                }
            ]);

            this.app.config([
                "$routeProvider",
                function ($routeProvider) {
                    $routeProvider.when("/map", {
                        controller: "mapController",
                        controllerAs: "myController",
                        templateUrl: "app/views/favoriteView.html"
                    }).otherwise({
                        redirectTo: "/map"
                    });
                }
            ]);

            this.app.run([
                "$route", function ($route) {
                    // Include $route to kick start the router.
                }
            ]);
        }
        AppBuilder.prototype.start = function () {
            var _this = this;
            $(document).ready(function () {
                console.log("booting " + _this.app.name);
                angular.bootstrap(document, [_this.app.name]);
            });
        };
        return AppBuilder;
    })();
    App.AppBuilder = AppBuilder;
})(App || (App = {}));
var App;
(function (App) {
    (function (Scope) {
        "use strict";
        var Favorite = (function () {
            function Favorite() {
            }
            return Favorite;
        })();
        Scope.Favorite = Favorite;
    })(App.Scope || (App.Scope = {}));
    var Scope = App.Scope;
})(App || (App = {}));
var App;
(function (App) {
    /// <reference path="favorite.ts" />
    (function (Scope) {
        "use strict";
    })(App.Scope || (App.Scope = {}));
    var Scope = App.Scope;
})(App || (App = {}));
var App;
(function (App) {
    /// <reference path="../scope/imapscope.ts" />
    /// <reference path="../scope/favorite.ts" />
    (function (Controllers) {
        "use strict";
        var MapController = (function () {
            function MapController($scope) {
                this.$scope = $scope;
                if (this.$scope.favorite === null || this.$scope.favorite === undefined) {
                    this.$scope.favorite = new App.Scope.Favorite();
                }
            }
            MapController.prototype.clear = function () {
                this.$scope.favorite.address = "";
                this.$scope.favorite.latitude = null;
                this.$scope.favorite.longitude = null;
            };
            MapController.$inject = ["$scope"];
            return MapController;
        })();
        Controllers.MapController = MapController;
    })(App.Controllers || (App.Controllers = {}));
    var Controllers = App.Controllers;
})(App || (App = {}));
/// <reference path="appbuilder.ts" />
new App.AppBuilder('maps').start();
//# sourceMappingURL=app.js.map
