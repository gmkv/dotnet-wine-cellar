using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gm18119.Models;
using gm18119.Services;


namespace gm18119.Controllers
{
    // Orders controller handles incoming purchases
    public class OrdersController : Controller
    {
        private IOrderData m_orderData;
        private IWineData m_wineData;

        // puprose of this ctor is to show asp.net which interfaces/data it needs 
        public OrdersController(IOrderData orderData, IWineData wineData)
        {
            m_orderData = orderData;
            m_wineData = wineData;
        }

        // Action Index displays all orders on the home page
        public IActionResult Index()
        {
            return View(m_orderData.GetAllOrders());
        }   
    
        public IActionResult Details(int id)
        {
            var model = m_orderData.GetOrder(id);
            if (model == null)
            {
                // if there is no order with such id, return back to the index
                return RedirectToAction(nameof(Index));
            }

            // convert wine ids from string back to int
            var idList = model.OrderedWineIds.Split(',').Select(int.Parse).ToList();
            
            var wineList = new List<Wine>();
            
            foreach(var i in idList) {
                var w = m_wineData.Get(i);

                wineList.Add(w);
            }
                
            var viewmodel = new OrderDetailsViewModel();
            viewmodel.PurchasedWines = wineList;
            viewmodel.Order = model;
            return View(viewmodel);
        }

        // [HttpGet]
        // public IActionResult Create()
        // {
        //     return View();
        // }

        // [HttpPost]
        // // public IActionResult Create(WineEditViewModel model)
        // // {
        // //     if (!ModelState.IsValid)
        // //     {
        // //         return View();
        // //     }
            
        // //     var wine = new Wine();
        // //     wine.BottlesRemaining = model.BottlesRemaining;

        // //     wine = m_wineData.Add(wine);
        // //     // redirect to the view so that the user won't resubmit a POST request once the view loads for them
        // //     return RedirectToAction(nameof(Details), new { id = wine.Id });
        // //     // this is why RedirectToAction is used, rather than just returning a View
        // // }

        // [HttpGet]
        // public IActionResult Edit(int id)
        // {
        //     var wine = m_wineData.Get(id);
        //     if (wine == null)
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }

        //     // var toBeEdited = new WineEditViewModel();
        //     // toBeEdited.Name = wine.Name;
        //     // toBeEdited.BottlesRemaining = wine.BottlesRemaining;

        //     // return a view with the wine so the form's fields would be populated with data
        //     return View(wine);
        // }

        // [HttpPost]
        // public IActionResult Edit(Wine model)
        // {
        //     // if (!ModelState.IsValid)
        //     // {
        //     //     return View();
        //     // }
        //     var wine = new Wine();
        //     // wine.Name = model.Name;
        //     wine.BottlesRemaining = model.BottlesRemaining;
            
        //     int oldId = model.Id;
            
        //     wine = m_wineData.Edit(oldId, wine);
            
        //     // get the newly created wine.Id and redirect to details section
        //     return RedirectToAction(nameof(Details), new { id = wine.Id });
        // }

        // public IActionResult Delete(int id)
        // {
        //     var wine = m_wineData.Get(id);
        //     if (wine == null)
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }

        //     m_wineData.Delete(wine.Id);
        //     // redirect to the view so that the user won't resubmit a POST request once the view loads for them
        //     return RedirectToAction(nameof(Index));
        //     // this is why RedirectToAction is used, rather than just returning a View
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
