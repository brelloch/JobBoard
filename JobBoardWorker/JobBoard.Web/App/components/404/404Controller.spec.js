/// <reference path="_references.js" />
/// <reference path="404Controller.js" />

'use strict';

describe('Controllers: Error404Ctrl', function () {
    var $scope, ctrl;

    beforeEach(function () {
        module('app.errorController')
    });

    beforeEach(inject(function ($rootScope, $controller) {
        $scope = $rootScope.$new();
        ctrl = $controller('Error404Ctrl', { $scope: $scope });
    }));

    it('should set a page title', function () {
        expect($scope.$root.title).toBe('Error 404: Page Not Found');
    });
});