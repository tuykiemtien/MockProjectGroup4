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
        public IHttpActionResult GetLoginCustomer(AccountDTO account)
        {
            try
            {
                AccountDTO customerLogin = db.Accounts.Where(s => s.Username == account.Username && s.Password == account.Password).Select(c => new AccountDTO()
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

    }
}
