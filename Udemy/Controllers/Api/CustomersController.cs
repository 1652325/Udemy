﻿ using AutoMapper;
using System;
using System.Collections.Generic;
 using System.Data.Entity;
 using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Udemy.DTOs;
using Udemy.Models;

namespace Udemy.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers.Include(c => c.MembershipType).ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto CustomerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(CustomerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            CustomerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/"+ customer.Id), CustomerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
