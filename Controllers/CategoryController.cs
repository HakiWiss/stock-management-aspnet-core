using Gestion_de_stock.Models;
using Gestion_de_stock.Models.Repositories;
using Gestion_de_stock.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGestionStockRepo<Categorie> categoryRepo;
        public CategoryController(IGestionStockRepo<Categorie> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(CategorieModel());
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategorieViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach(Categorie item in categoryRepo.List())
                {
                    if (item.Nom == model.NewCategorie.Nom)
                    {
                        ViewBag.errorCategoryName =  model.NewCategorie.Nom + " Category Already exist";
                        
                        return View("Index", CategorieModel());
                    }
                }
                categoryRepo.Add(model.NewCategorie);
            }
            return RedirectToAction(nameof(Index));
            // Reload the list if form validation fails
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                foreach (Categorie item in categoryRepo.List())
                {
                    if (item.Nom == categorie.Nom)
                    {
                        ViewBag.errorCategoryName = categorie.Nom + " Category Already exist";

                        return View("Index", CategorieModel());
                    }
                }
                categoryRepo.Update(categorie.Id,categorie);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            categoryRepo.Delete(id);
            return RedirectToAction("Index");
        }
        

        public CategorieViewModel CategorieModel()
        {
            var model = new CategorieViewModel
            {
                NewCategorie = new Categorie(),
                Categories = categoryRepo.List()
            };
            return model;
        }
    }
}
