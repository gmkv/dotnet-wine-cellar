﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gm18119.Models;
using gm18119.Services;

namespace gm18119.Controllers
{
    // Home controller handles incoming requests for managing cellar inventory
    public class HomeController : Controller
    {
        private IWineData m_wineData;

        // puprose of this ctor is to show asp.net which interfaces/data it needs 
        public HomeController(IWineData wineData)
        {
            m_wineData = wineData;
        }

        public IActionResult Index()
        {
            // Action Index displays all wines on the home page
            
            // var model = new HomeIndexViewModel();
            // model.Wines = m_wineData.GetAll(); 
            
            return View();
        }
    
        // public IActionResult Details(int id)
        // {
        //     var model = m_wineData.Get(id);
        //     if (model == null)
        //     {
        //         // if there is no wine with such id, return back to the index
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(model);
        // }

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

        
        // public IActionResult About()
        // {
        //     ViewData["Message"] = "Your application description page.";

        //     return View();
        // }

        // public IActionResult Contact()
        // {
        //     ViewData["Message"] = "Your contact page.";

        //     return View();
        // }
    }
}