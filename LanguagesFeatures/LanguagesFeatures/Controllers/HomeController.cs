﻿using LanguagesFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LanguagesFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //List<string> results = new List<string>();

            //foreach (var product in Product.GetProducts())
            //{
            //    string name = product?.Name ?? "<No Name>";
            //    decimal? price = product?.Price ?? 0;
            //    string relatedName = product?.Related?.Name ?? "<No Name>";
            //    string productCategory = product?.Category ?? "<No Name>";
            //    results.Add($"Name: {name}, Price: {price}, Related: {relatedName} Category:{productCategory}"));
            //}
            //return View(results);
            //Dictionary<string, Product> products = new Dictionary<string, Product>
            //{
            //    ["Kayak"] = new Product { Name = "kayak", Price = 275M},
            //    ["Lifejacket"] = new Product { Name = "LifeJacket", Price = 48.95M} 
            //};
            //object[] data = new object[] { 27M, 29.95M, "apple", "orange", 100, 10 };

            //decimal total = 0;

            //for (int i = 0; i < data.Length; i++)
            //{
            //    switch (data[i])
            //    {
            //        case decimal decimalValue:
            //            total += decimalValue;
            //            break;
            //        case int intValue when intValue > 50:
            //            total += intValue;
            //            break;
            //    }
            //}

            var cart = new ShopingCart { Products = Product.GetProducts() };
            var cartTotal = cart.TotalPrice();
            return View("Index", new string[] {$"Total: {cartTotal:C2}"});
        }
    }
}
