using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult ReturnCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer {Name = "Cindy Foster", Id = 2},
                new Customer {Name = "Mike Foster", Id = 1}
            };
            var viewModel = new CustomerViewModel
            {
                Customers = customers
            }
            ;

            //if (DateTime.Now.Millisecond % 2 == 0)
                return View(viewModel);
            //else
            //  return Content("There are no customers at this time.");
        }

        //http://localhost:50152/customers/info/1/Cindy
        [Route("customers/index/{id}/{name}")] //magic strings! method name doesn't matter, url correctness is determined by what is in this attribute.
        public ActionResult Info(int? id, string sortBy)
        {
            if (!id.HasValue)
                id = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "DefaultSort";
            if (id == 3)
                return HttpNotFound("This customer does not exist.");
            return Content(String.Format("id={0}&sortBy={1}", id, sortBy));
        }
    }
}