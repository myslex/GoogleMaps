/// <reference path="../scope/imapscope.ts" />
/// <reference path="../scope/favorite.ts" />
module App.Controllers {
    "use strict";
    export class MapController {
        static $inject = ["$scope"];

        constructor(private $scope: Scope.IMapScope) {
            if (this.$scope.favorite === null || this.$scope.favorite === undefined) {
                this.$scope.favorite = new Scope.Favorite();
            }
        }
        public clear(): void {
            this.$scope.favorite.address = "";
            this.$scope.favorite.latitude = null;
            this.$scope.favorite.longitude = null;
        }
    }
}