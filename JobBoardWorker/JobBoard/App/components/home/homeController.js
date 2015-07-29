'use strict';

angular.module('app.homeController', [])

    // Path: /
    .controller('HomeCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'JobBoard Customer Management';
    }]);