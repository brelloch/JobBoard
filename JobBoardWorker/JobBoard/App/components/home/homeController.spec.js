/// <reference path="_references.js" />
/// <reference path="homeController.js" />

'use strict';

describe('Controllers: HomeCtrl', function () {
    var $scope, ctrl;

    beforeEach(module('app.homeController'));

    beforeEach(inject(function ($rootScope, $controller) {
        $scope = $rootScope.$new();
        ctrl = $controller('HomeCtrl', { $scope: $scope });
    }));

    it('should set a page title', function () {
        expect($scope.$root.title).toBe('JobBoard Customer Management');
    });
});
