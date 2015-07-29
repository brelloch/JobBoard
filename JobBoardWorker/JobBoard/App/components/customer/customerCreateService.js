'use strict';

angular.module('app.customerCreateService', [])

    .service('customerCreateService', function () {
        var customer = {};

        var setCustomer = function (newObj) {
            customer = newObj;
        }

        var getCustomer = function () {
            return customer;
        }

        return {
            setCustomer: setCustomer,
            getCustomer: getCustomer
        };

    });
