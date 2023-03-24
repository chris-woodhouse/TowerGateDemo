using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tower_Gate.Models;
using Tower_Gate.Services;

namespace Tower_Gate.Controllers
{
    public class HomeController : Controller
    {
        readonly ICustomerOperations CustomerOps;
        public HomeController(ICustomerOperations _customers)
        {
            CustomerOps = _customers;
        }

        // GET: HomeController
        List<Customer> CustomerInfo;
        public ActionResult Index()
        {
            CustomerInfo = CustomerOps.GetAllCustomers();
            return View(CustomerInfo);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try {

                if (ModelState.IsValid)
                {
                    var NewCustomer = new Customer();


                    NewCustomer.Id = 0;
                    NewCustomer.Name = collection["Name"].ToString();
                    NewCustomer.PostCode = collection["PostCode"].ToString();
                    NewCustomer.Age = int.Parse(collection["Age"]);
                    NewCustomer.Height = double.Parse(collection["Height"]);
                    CustomerOps.CreateCustomer(NewCustomer);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                };


            }
            catch
            {
 
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var CustomerById = CustomerOps.GetCustomerById(id).FirstOrDefault();
            return View(CustomerById);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {

            try
            {
                var EditCustomer = new Customer();
                EditCustomer.Id = id;
                EditCustomer.Name = collection["Name"].ToString();
                EditCustomer.PostCode = collection["PostCode"].ToString();
                EditCustomer.Age = int.Parse(collection["Age"]);
                EditCustomer.Height = double.Parse(collection["Height"]);

                CustomerOps.UpdateCustomerDetails(EditCustomer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
