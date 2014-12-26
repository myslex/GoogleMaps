/// <reference path="favorite.ts" />
module App.Scope {
    "use strict";
    export interface IMapScope extends ng.IScope {
        addFavorite: Function;
        deleteFavorite: Function;
    }
}