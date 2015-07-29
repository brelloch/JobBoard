'use strict';

angular.module('app.customerCreateController', ['app.directives'])

    // Path: /createcustomer
    .controller('CreateCustomerCtrl', ['$scope', '$location', '$window', 'customerFactory', 'customerCreateService', function ($scope, $location, $window, customerFactory, customerCreateService) {
        $scope.$root.title = 'JobBoard | New Customer';

        $scope.customer = customerCreateService.getCustomer();

        $scope.createCustomer = function (cust) {
            var promise;

            if (cust.Id) {
                promise = customerFactory.updateCustomer(cust);
            } else {
                promise = customerFactory.insertCustomer(cust);
            }

            promise.then(function (custs) {
                $location.path('/customer')
            }, function (reason) {
                alert('Failed: ' + reason);
            }, function (update) {
                alert('Got notification: ' + update);
            });
        };
    }]);