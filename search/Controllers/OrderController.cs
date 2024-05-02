using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using search.Models;
using search.Service;
using System;
using System.Collections.Generic;
using System.Net;

namespace search.Controllers
{
    public class OrderController : Controller
    {
      
        public IActionResult Index()
        {
            try
            {
                var service = new OrderService();
                List<string> folios = service.GetPartnum();
                ViewBag.Folios = folios;
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        public IActionResult ShowDetails(string selectedFolio)
        {
            try
            {
                Console.WriteLine("Selected Folio Show: " + selectedFolio);
                var service = new OrderService();
                List<OrderHedModel> details = service.GetDetailsOrder(selectedFolio);
                return View(details);
            }
            catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel { RequestId = ex.Message };
                return View("Error", errorViewModel);
            }
        }
    }
}
