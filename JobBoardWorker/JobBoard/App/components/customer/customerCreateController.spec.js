'use strict';

describe('Controllers: CreateCustomerCtrl', function () {
    var $scope, ctrl, mockCustomerFactory, mockCustomerCreateService, mockGetCustomersResponse, queryDeferred;

    beforeEach(module('app.customerCreateController'));

    beforeEach(inject(function ($rootScope, $controller, $q) {
        mockGetCustomersResponse = [{
            "FirstName": "David",
            "LastName": "Brelloch",
            "Address1": "350 Jenny Lind Lane",
            "Address2": "",
            "Zip": "30022",
            "City": "Alpharetta",
            "State": "Georgia",
            "Phone": "4044212632",
            "Latitude": 34.032379,
            "Longitude": -84.2474189,
            "Id": "customers-65",
            "StartedAt": "2015-02-02T14:32:28.8592392Z",
            "EndedAt": null
        },
        {
            "FirstName": "Payal",
            "LastName": "Desai",
            "Address1": "1074 Peachtree Walk NE",
            "Address2": "B315",
            "Zip": "30309",
            "City": "Atlanta",
            "State": "Georgia",
            "Phone": "4044212633",
            "Latitude": 33.78393,
            "Longitude": -84.385843,
            "Id": "customers-129",
            "StartedAt": "2015-02-02T18:09:54.6289525Z",
            "EndedAt": null
        }];

        mockCustomerFactory = {
            getCustomers: function () {
                queryDeferred = $q.defer();
                return { $promise: queryDeferred.promise };
            },
            getCustomer: function () {
                queryDeferred = $q.defer();
                return { $promise: queryDeferred.promise };
            },
            insertCustomer: function () {
                queryDeferred = $q.defer();
                return { $promise: queryDeferred.promise };
            },
            updateCustomer: function () {
                queryDeferred = $q.defer();
                return { $promise: queryDeferred.promise };
            },
            deleteCustomer: function () {
                queryDeferred = $q.defer();
                return { $promise: queryDeferred.promise };
            }
        };
        mockCustomerCreateService = {
            setCustomer: function (customer) {
            },
            getCustomer: function () {
                var customer = {
                    "FirstName": "Jason",
                    "LastName": "Brelloch",
                    "Address1": "1074 Peachtree Walk NE",
                    "Address2": "",
                    "Zip": "30309",
                    "City": "Atlanta",
                    "State": "Georgia",
                    "Phone": "4044212632",
                    "Latitude": 34.032379,
                    "Longitude": -84.2474189,
                    "Id": "customers-1",
                    "StartedAt": "2015-02-02T14:32:28.8592392Z",
                    "EndedAt": null
                };
                return customer;
            }
        };

        $scope = $rootScope.$new();

        ctrl = $controller('CreateCustomerCtrl', {
            $scope: $scope, 'customerFactory': mockCustomerFactory, 'customerCreateService': mockCustomerCreateService
        });
    }));

    it('should set a page title', function () {
        expect($scope.$root.title).toBe('JobBoard | New Customer');
    });

    it('should have a customer set', function () {
        expect($scope.customer.Id).toBe('customers-1');
    });
});
