'use strict';

describe('Service: CustomerCreateService', function () {
    beforeEach(module('app.customerCreateService'));

    var service;

    beforeEach(inject(function (customerCreateService) {
        service = customerCreateService;
    }))

    it('Should set and get the customer', function () {
        var customer = {
            "FirstName": "David",
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

        service.setCustomer(customer);
        var customer2 = service.getCustomer();

        expect(customer.Id).toBe(customer2.Id);
    });
});
