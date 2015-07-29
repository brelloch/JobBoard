'use strict';

angular.module('app.customerFactory', [])
    .factory('customerFactory', ['$http', '$q', function ($http, $q) {

        var urlBase = '/api/customer';
        var customerFactory = {};

        customerFactory.getCustomers = function () {
            var deferred = $q.defer();

            $http.get(urlBase)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function () {
                    deferred.reject('Error');
                });

            return deferred.promise;
        };

        customerFactory.getCustomer = function (id) {
            var deferred = $q.defer();

            $http.get(urlBase + '/' + id)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function () {
                    deferred.reject('Error');
                });

            return deferred.promise;
        };

        customerFactory.insertCustomer = function (cust) {
            var deferred = $q.defer();

            $http.post(urlBase, cust)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function () {
                    deferred.reject('Error');
                });

            return deferred.promise;
        };

        customerFactory.updateCustomer = function (cust) {
            var deferred = $q.defer();

            $http.put(urlBase + '/' + cust.Id, cust)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function () {
                    deferred.reject('Error');
                });

            return deferred.promise;

        };

        customerFactory.deleteCustomer = function (id) {
            var deferred = $q.defer();

            $http.delete(urlBase + '/' + id)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function () {
                    deferred.reject('Error');
                });

            return deferred.promise;

        };

        return customerFactory;
    }]);