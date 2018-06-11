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

        // puprose of this ctor is to show asp.net which dependencies it needs injected
        public OrdersController(IOrderData orderData, IWineData wineData)
        {
            m_orderData = orderData;
            m_wineData = wineData;
        }

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

        // Action Process changes the status of an order.
        public IActionResult Process(OrderDetailsViewModel model)
        {
            var order = model.Order;
            order = m_orderData.UpdateStatus(order.Id, order.Status);
            if (order == null) {
                return RedirectToAction(nameof(Index));    
            }
            return RedirectToAction(nameof(Details), new { id = order.Id });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order model)
        {
            Order order = m_orderData.Add(model);
            // redirect to the view so that the user won't resubmit a POST request once the view loads for them
            return RedirectToAction(nameof(Details), new { id = order.Id });
            // this is why RedirectToAction is used, rather than just returning a View
        }
    }
}
