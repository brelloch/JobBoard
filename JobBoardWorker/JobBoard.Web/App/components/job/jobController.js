'use strict';

angular.module('app.jobController', ['ngTable'])

    // Path: /job
    .controller('JobCtrl', ['$scope', '$location', '$window', '$filter', 'jobFactory', 'ngTableParams', function ($scope, $location, $window, $filter, jobFactory, ngTableParams) {
        $scope.$root.title = 'JobBoard | Jobs';

        $scope.jobs;
        $scope.orders;
        $scope.loaded = false;

        getJobs();

        function getJobs() {
            var promise = jobFactory.getJobs();
            promise.then(function (custs) {
                $scope.jobs = custs;
                $scope.loaded = true;
               
                $scope.tableParams = new ngTableParams({
                    page: 1,            // show first page
                    count: 10,          // count per page
                    sorting: {
                        FirstName: 'asc'     // initial sorting
                    }
                }, {
                    total: $scope.jobs.length, // length of data
                    getData: function ($defer, params) {
                        // use build-in angular filter
                        var orderedData = params.sorting() ?
                                            $filter('orderBy')($scope.jobs, params.orderBy()) :
                                            $scope.jobs;
               
                        $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                    }
                });
            }, function (reason) {
                alert('Failed: ' + reason);
            }, function (update) {
                alert('Got notification: ' + update);
            });
        }
    }]);