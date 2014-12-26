module App {
    "use strict";
    export class AppBuilder {


        app: ng.IModule;

        constructor(name: string) {
            this.app = angular.module(name, [
            // Angular modules 
                "ngAnimate",
                "ngRoute",
                "ngSanitize",
                "ngResource"
            ]);

            this.app.controller("mapController", [
                "$scope", ($scope: Scope.IMapScope) => new App.Controllers.MapController($scope)
            ]);

            this.app.config([
                "$routeProvider",
                ($routeProvider: ng.route.IRouteProvider) => {
                    $routeProvider
                        .when("/map",
                        {
                            controller: "mapController",
                            controllerAs: "myController",
                            templateUrl: "app/views/favoriteView.html"
                        })
                        .otherwise({
                            redirectTo: "/map"
                        });
                }
            ]);

            this.app.run([
                "$route", $route => {
                    // Include $route to kick start the router.
                }
            ]);
        }

        public start() {
            $(document).ready(() => {
                console.log("booting " + this.app.name);
                angular.bootstrap(document, [this.app.name]);
            });
        }
    }

}