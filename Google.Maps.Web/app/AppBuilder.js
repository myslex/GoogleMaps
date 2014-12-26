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
//# sourceMappingURL=AppBuilder.js.map
