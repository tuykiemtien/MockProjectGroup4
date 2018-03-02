using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAO.Models;
using DTO;

namespace DAO.Controllers
{
    public class CustomerController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();

        //login customer
        public IHttpActionResult GetLoginCustomer(string username, string password)
        {
            try
            {
                AccountDTO customerLogin = db.Accounts.Where(s => s.Username == username && s.Password == password).Select(c => new AccountDTO()
                {
                    CustomerId = c.CustomerId,
                    Customer = db.Customers.Where(a => a.CustomerID == c.CustomerId).Select(b => new CustomerDTO()
                    {
                        Address = b.Address,
                        City = b.City,
                        CustomerID = b.CustomerID,
                        CompanyName = b.CompanyName,
                        ContactName = b.ContactName,
                        ContactTitle = b.ContactTitle
                    }).FirstOrDefault(),
                    Username = c.Username
                }).FirstOrDefault();
                if (customerLogin != null)
                {
                    return Ok(customerLogin);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
           
        }
        
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<AccountDTO> customerLogin = db.Accounts.Select(c => new AccountDTO()
            {
                CustomerId = c.CustomerId,
                Customer = db.Customers.Where(a => a.CustomerID == c.CustomerId).Select(b => new CustomerDTO()
                {
                    Address = b.Address,
                    City = b.City,
                    CustomerID = b.CustomerID,
                    CompanyName = b.CompanyName,
                    ContactName = b.ContactName,
                    ContactTitle = b.ContactTitle
                }).FirstOrDefault(),
                Username = c.Username
            }).ToList();
            if (customerLogin != null)
            {
                return Ok(customerLogin);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
