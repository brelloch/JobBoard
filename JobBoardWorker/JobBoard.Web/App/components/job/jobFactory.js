'use strict';

angular.module('app.jobFactory', [])
    .factory('jobFactory', ['$http', '$q', function ($http, $q) {

        var urlBase = '/api/jobs';
        var jobFactory = {};

        jobFactory.getJobs = function () {
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

        jobFactory.getJob = function (id) {
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

        jobFactory.insertJob = function (cust) {
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

        jobFactory.updateJob = function (cust) {
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

        jobFactory.deleteJob = function (id) {
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

        return jobFactory;
    }]);