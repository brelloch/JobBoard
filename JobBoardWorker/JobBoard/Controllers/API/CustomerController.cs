using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobBoard.Models;
using JobBoard.Contracts;
using Raven.Client;
using System.Threading.Tasks;
using JobBoard.Helpers;

namespace JobBoard.Controllers
{
    public class CustomerController : JobBoardApiController
    {
        protected ICustomerService _CustomerService;

        public CustomerController(ICustomerService customerService)
        {
            _CustomerService = customerService;
        }

        // GET: api/Customer
        /// <summary>
        /// Get all active customers in the database
        /// </summary>
        public async Task<List<Customer>> Get()
        {
            using (var ravenSession = DocumentStore.OpenAsyncSession())
            {
                var result = await _CustomerService.GetCustomers(ravenSession);
                if (result.Errors.Count > 0) {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                
                return result.Value;
            }
        }

        // GET: api/Customer/customer-5
        /// <summary>
        /// Gets the specified customer.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        public async Task<Customer> Get(string id)
        {
            using (var ravenSession = DocumentStore.OpenAsyncSession())
            {
                var result = await _CustomerService.GetCustomer(ravenSession, id);
                if (result.Errors.Count > 0)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                return result.Value;
            }
        }

        // POST: api/Customer
        /// <summary>
        /// Create the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public async Task<Customer> Post([FromBody]Customer customer)
        {
            //if (!ModelState.IsValid)
            if (String.IsNullOrEmpty(customer.FirstName) ||
                String.IsNullOrEmpty(customer.LastName) ||
                String.IsNullOrEmpty(customer.Address1) ||
                String.IsNullOrEmpty(customer.Zip))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            using (var ravenSession = DocumentStore.OpenAsyncSession())
            {
                var result = await _CustomerService.CreateCustomer(ravenSession, customer);
                if (result.Errors.Count > 0)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                return result.Value;
            }
        }

        // PUT: api/Customer/customer-5
        /// <summary>
        /// Update the specified customer.
        /// </summary>
        /// <param name="id">The customer id.</param>
        /// <param name="customer">The customer.</param>
        public async Task<Customer> Put(string id, [FromBody]Customer customer)
        {
            //if (!ModelState.IsValid)
            if (String.IsNullOrEmpty(customer.FirstName) ||
                            String.IsNullOrEmpty(customer.LastName) ||
                            String.IsNullOrEmpty(customer.Address1) ||
                            String.IsNullOrEmpty(customer.Zip))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            using (var ravenSession = DocumentStore.OpenAsyncSession())
            {
                var result = await _CustomerService.UpdateCustomer(ravenSession, id, customer);
                if (result.Errors.Count > 0)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                return result.Value;
            }
        }

        // DELETE: api/Customer/customer-5
        /// <summary>
        /// Deletes the specified customer.
        /// </summary>
        /// <param name="id">The customer id.</param>
        public async Task Delete(string id)
        {
            using (var ravenSession = DocumentStore.OpenAsyncSession())
            {
                var result = await _CustomerService.DeleteCustomer(ravenSession, id);
                if (result.Errors.Count > 0)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                return;
            }
        }
    }
}
