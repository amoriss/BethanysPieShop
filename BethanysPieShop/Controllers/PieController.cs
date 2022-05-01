using BethanysPieShop.Models;
using BethanysPieShop.VIewModels;
using BethanysPieShop.VIewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

       
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult Index()
        {
            ViewBag.Message = "Welcome to Bethany's Pie Shop";
            return View();
        }

        //list all pies in application
        //ViewBag used to pass data
        //ViewBag is a dynamic object that we can add data to from the Controller
        public ViewResult List() //ViewResult return type that is built-in to ASP.NET MVC
        {
            //ViewBag.CurrentCategory = "Cheese cakes";
            PiesListViewModel piesListViewModel = new PiesListViewModel();
            piesListViewModel.Pies = _pieRepository.AllPies;

            piesListViewModel.CurrentCategory = "Cheese cakes";
            return View(piesListViewModel);
        }

    }
}
