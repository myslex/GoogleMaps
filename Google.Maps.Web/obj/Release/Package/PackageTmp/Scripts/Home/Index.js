
'use strict';

var app = angular.module('mapsApp', []);

app.controller('mapsCtrl', ['$scope', '$http',
    function ($scope, $http) {
        $scope.app = {};

        $scope.app.loadFavorites = function () {
            $http.get('/api/favorites').success(function (data) {
                $scope.app.favorites = data;

            }).error(function () {
                $scope.app.error = 'an unexpected error occurred';
            });
        };

        $scope.app.loadFavorites();

        $scope.app.addFavorite = function (address, lat, lng) {

            var favorite = {
                Address: address,
                Latitude: lat,
                Longitude: lng
            };

            console.log(favorite);

            $http.post('/api/favorites/', favorite).success(function (data, status, headers) {
                $scope.app.loadFavorites();
            });
        };

        $scope.app.removeFavorite = function (id) {
            angular.forEach($scope.app.favorites, function (favorite) {
                if (favorite.Id == id) {
                    console.log('found matching favorite: attempting to remove..');

                    $http.delete('/api/favorites/' + favorite.Id).success(function (data, status, headers) {
                        $scope.app.loadFavorites();
                    });

                    return;
                }
            });
        };

        $scope.app.loadMap = function () {
            var mapLocation = new google.maps.LatLng(-34.397, 150.644);

            var mapOptions = {
                zoom: 14,
                center: mapLocation
            };

            var mapMarker = new google.maps.Marker({
                position: mapLocation,
                map: $scope.app.map,
                title: "Initial map location"
            });

            $scope.app.map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

            mapMarker.setMap($scope.app.map);
        }

        $scope.app.loadMap();

        $scope.app.showMap = function (address, lat, lng) {

            var mapLocation = new google.maps.LatLng(lat, lng);

            var mapOptions = {
                zoom: 14,
                center: mapLocation
            };

            var mapMarker = new google.maps.Marker({
                position: mapLocation,
                map: $scope.app.map,
                title: address
            });

            $scope.app.map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

            mapMarker.setMap($scope.app.map);
        };

        $scope.app.search = function () {
            $http({ method: 'GET', url: '/api/maps/js-address'.replace("js-address", encodeURIComponent($scope.app.term)) }).
              success(function (data, status, headers, config) {
                  $scope.app.results = data;
              })
        }
    }
]);