using Activity2.Models;
using Activity2.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {   //https://localhost:44368/products

            /**** NOTES add view / partial view / open view from url ****             

            add view: Right click between the method brakets opens dialog with option: 'Add View...'

            partial view: Then I check 'Create as partial view', since my view is ment to work in the main layout

            open view from url: To access from the url, we can use https://localhost:44368/Products (it assumes you want the index) or https://localhost:44368/Products/Index

             */

            /*
            HardCodedSampleDataRepository hardCodedSampleDataRepository = new HardCodedSampleDataRepository();

            return View(hardCodedSampleDataRepository.GetAllProducts());
            */
            ProductsDAO products = new ProductsDAO();

            return View(products.GetAllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {   //https://localhost:44368/products/searchresults?searchterm=wine
            ProductsDAO products = new ProductsDAO();

            List<ProductModel> productList = products.SearchProducts(searchTerm);

            return View("index", productList);
        }
        public IActionResult ShowDetails(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }
        public IActionResult Edit(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View("ShowEdit",foundProduct);
        }
        public IActionResult ProcessEdit(ProductModel product) 
        {
            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return View("Index", products.GetAllProducts());
        }
        public IActionResult Delete(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(id);
            products.Delete(product);
            return View("Index", products.GetAllProducts());
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        public IActionResult InputForm(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Insert(product);
            return View("Index", products.GetAllProducts());
        }
        public IActionResult SearchForm()
        {
            return View();
        }
        public IActionResult Message()
        {
            /**** NOTES open page from url****             

            If you use the url https://localhost:44368/products/message you get a page'

             */
            return View("message");
        }

        public string MessageString() 
        {
            /**** NOTES open page from url****             

            If you use the url https://localhost:44368/products/messagestring you get a 'page' that shows the string

             */
            return "This is an important message about a blue product.";
        }

        public IActionResult Wellcome(string name, int secretNumber = 13)
        {
            /**** NOTES viewbag ****
             
            VIEWBAG
            To send something along with the view 

            https://localhost:44368/products/wellcome?name=Mercedes&secretNumber=102

             */

            ViewBag.Name = name;
            ViewBag.Secret = secretNumber;

            return View();
        }

        public string WellcomeString(string name, int secretNumber = 13) 
        {
            /**** NOTES open page with url + parameters****
             
            PARAMETERS IN ROUTE

             https://localhost:44368/products/WellcomeString -> returns the message: Hello  the secret number for today is 13

            https://localhost:44368/products/WellcomeString?name=Mercedes&secretnumber=99 -> returns: Hello Mercedes the secret number for today is 99

             */
            return "Hello " + name + " the secret number for today is " + secretNumber; 
        }
    }
}
