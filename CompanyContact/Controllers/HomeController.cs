﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompanyContact.Models;
using CompanyContact.Data;

namespace CompanyContact.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context ;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();


        }

        public  IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            List<object> mymodel = new List<object>();
            mymodel.Add(_context.companies.ToList());
            mymodel.Add(_context.ContactPerson.ToList());
            return View( mymodel);





        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
