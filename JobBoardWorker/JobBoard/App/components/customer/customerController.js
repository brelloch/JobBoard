'use strict';

angular.module('app.customerController', ['ngTable'])

    // Path: /customer
    .controller('CustomerCtrl', ['$scope', '$location', '$window', '$filter', 'customerFactory', 'customerCreateService', 'ngTableParams', function ($scope, $location, $window, $filter, customerFactory, customerCreateService, ngTableParams) {
        $scope.$root.title = 'JobBoard | Customers';

        $scope.customers;
        $scope.orders;
        $scope.loaded = false;

        getCustomers();

        function getCustomers() {
            var promise = customerFactory.getCustomers();
            promise.then(function (custs) {
                $scope.customers = custs;
                $scope.loaded = true;
               
                $scope.tableParams = new ngTableParams({
                    page: 1,            // show first page
                    count: 10,          // count per page
                    sorting: {
                        FirstName: 'asc'     // initial sorting
                    }
                }, {
                    total: $scope.customers.length, // length of data
                    getData: function ($defer, params) {
                        // use build-in angular filter
                        var orderedData = params.sorting() ?
                                            $filter('orderBy')($scope.customers, params.orderBy()) :
                                            $scope.customers;
               
                        $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                    }
                });
            }, function (reason) {
                alert('Failed: ' + reason);
            }, function (update) {
                alert('Got notification: ' + update);
            });
        }

        $scope.deleteCustomer = function (id) {
            var promise = customerFactory.deleteCustomer(id);
            promise.then(function (custs) {
                for (var i = 0; i < $scope.customers.length; i++) {
                    var cust = $scope.customers[i];
                    if (cust.Id === id) {
                        $scope.customers.splice(i, 1);
                        $scope.tableParams.reload();
                        break;
                    }
                }
            }, function (reason) {
                alert('Failed: ' + reason);
            }, function (update) {
                alert('Got notification: ' + update);
            });
        };

        $scope.goToCreateModify = function (cust) {
            customerCreateService.setCustomer(cust);
            $location.path('/createcustomer');
        };
    }]);