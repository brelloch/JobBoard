/// <reference path="_references.js" />
/// <reference path="aboutController.js" />

'use strict';

describe('Factory: JobFactory', function () {
    beforeEach(module('app.jobFactory'));

    var factory, httpBackend;

    beforeEach(inject(function ($httpBackend, jobFactory, _$httpBackend_) {
        factory = jobFactory;
        httpBackend = _$httpBackend_;
    }))

    it('Should define methods', function () {
        expect(factory.getJobs).toBeDefined()
        expect(factory.getJob).toBeDefined()
        expect(factory.insertJob).toBeDefined()
        expect(factory.updateJob).toBeDefined()
        expect(factory.deleteJob).toBeDefined()
    });

    it("should get all jobs", function () {
        httpBackend.whenGET("/api/job").respond([{
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
            "Id": "jobs-65",
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
            "Id": "jobs-129",
            "StartedAt": "2015-02-02T18:09:54.6289525Z",
            "EndedAt": null
        }]);
        var promise = factory.getJobs(),
            jobs;

        promise.then(function (custs) {
            jobs = custs;
        });
        httpBackend.flush();
        expect(jobs instanceof Array).toBeTruthy();
    });

    it("should get a job", function () {
        httpBackend.whenGET("/api/job/job-1").respond({
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
            "Id": "jobs-1",
            "StartedAt": "2015-02-02T14:32:28.8592392Z",
            "EndedAt": null
        });
        var promise = factory.getJob('job-1'),
            job;

        promise.then(function (cust) {
            job = cust;
        });
        httpBackend.flush();
        expect(job.FirstName).toBe('David');
    });

    it("should create a job", function () {
        httpBackend.whenPOST("/api/job").respond({
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
            "Id": "jobs-1",
            "StartedAt": "2015-02-02T14:32:28.8592392Z",
            "EndedAt": null
        });
        var newJob = {
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
        var promise = factory.insertJob(newJob),
            job;

        promise.then(function (cust) {
            job = cust;
        });
        httpBackend.flush();
        expect(job.FirstName).toBe('David');
        expect(job.Id).toBe('jobs-1');
    });

    it("should update a job", function () {
        httpBackend.whenPUT("/api/job/jobs-1").respond({
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
            "Id": "jobs-1",
            "StartedAt": "2015-02-02T14:32:28.8592392Z",
            "EndedAt": null
        });
        var currentJob = {
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
            "Id": "jobs-1",
            "StartedAt": "2015-02-02T14:32:28.8592392Z",
            "EndedAt": null
        };
        var promise = factory.updateJob(currentJob),
            job;

        promise.then(function (cust) {
            job = cust;
        });
        httpBackend.flush();
        expect(job.FirstName).toBe('David');
        expect(job.Id).toBe('jobs-1');
    });

    it("should delete a job", function () {
        httpBackend.whenDELETE("/api/job/jobs-1").respond("");
        var currentJob = {
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
            "Id": "jobs-1",
            "StartedAt": "2015-02-02T14:32:28.8592392Z",
            "EndedAt": null
        };
        var promise = factory.deleteJob(currentJob.Id),
            response;

        promise.then(function (resp) {
            response = resp;
        });
        httpBackend.flush();
        expect(response).toBe('');
    });


});
