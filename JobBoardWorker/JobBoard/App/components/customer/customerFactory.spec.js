/// <reference path="_references.js" />
/// <reference path="aboutController.js" />

'use strict';

describe('Factory: CustomerFactory', function () {
    beforeEach(module('app.customerFactory'));

    var factory, httpBackend;

    beforeEach(inject(function ($httpBackend, customerFactory, _$httpBackend_) {
        factory = customerFactory;
        httpBackend = _$httpBackend_;
    }))

    it('Should define methods', function () {
        expect(factory.getCustomers).toBeDefined()
        expect(factory.getCustomer).toBeDefined()
        expect(factory.insertCustomer).toBeDefined()
        expect(factory.updateCustomer).toBeDefined()
        expect(factory.deleteCustomer).toBeDefined()
    });

    it("should get all customers", function () {
        httpBackend.whenGET("/api/customer").respond([{
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
        }]);
        var promise = factory.getCustomers(),
            customers;

        promise.then(function (custs) {
            customers = custs;
        });
        httpBackend.flush();
        expect(customers instanceof Array).toBeTruthy();
    });

    it("should get a customer", function () {
        httpBackend.whenGET("/api/customer/customer-1").respond({
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
            "Id": "customers-1",
            "StartedAt": "2015-02-02T14:32:28.8592392Z",
            "EndedAt": null
        });
        var promise = factory.getCustomer('customer-1'),
            customer;

        promise.then(function (cust) {
            customer = cust;
        });
        httpBackend.flush();
        expect(customer.FirstName).toBe('David');
    });

    it("should create a customer", function () {
        httpBackend.whenPOST("/api/customer").respond({
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
            "Id": "customers-1",
            "StartedAt": "2015-02-02T14:32:28.8592392Z",
            "EndedAt": null
        });
        var newCustomer = {
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
            "StartedAt": "2015-02-02T14:32:28.8592392Z",
            "EndedAt": null
        };
        var promise = factory.insertCustomer(newCustomer),
            customer;

        promise.then(function (cust) {
            customer = cust;
        });
        httpBackend.flush();
        expect(customer.FirstName).toBe('David');
        expect(customer.Id).toBe('customers-1');
    });

    it("should update a customer", function () {
        httpBackend.whenPUT("/api/customer/customers-1").respond({
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
            "Id": "customers-1",
            "StartedAt": "2015-02-02T14:32:28.8592392Z",
            "EndedAt": null
        });
        var currentCustomer = {
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
        var promise = factory.updateCustomer(currentCustomer),
            customer;

        promise.then(function (cust) {
            customer = cust;
        });
        httpBackend.flush();
        expect(customer.FirstName).toBe('David');
        expect(customer.Id).toBe('customers-1');
    });

    it("should delete a customer", function () {
        httpBackend.whenDELETE("/api/customer/customers-1").respond("");
        var currentCustomer = {
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
        var promise = factory.deleteCustomer(currentCustomer.Id),
            response;

        promise.then(function (resp) {
            response = resp;
        });
        httpBackend.flush();
        expect(response).toBe('');
    });


});
