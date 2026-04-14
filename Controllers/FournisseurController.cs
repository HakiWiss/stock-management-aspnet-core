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
    public class FournisseurController : Controller
    {
        private readonly IGestionStockRepo<Fournisseur> fournisseurRepo;
        public FournisseurController(IGestionStockRepo<Fournisseur> fournisseurRepo)
        {
            this.fournisseurRepo = fournisseurRepo;
        }
        // GET: FournisseurController
        public ActionResult Index()
        {

            return View(FournisseurModel());
        }

        // POST: FournisseurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FournisseurViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (Fournisseur item in fournisseurRepo.List())
                {
                    if (item.Nom == model.NewFournisseur.Nom)
                    {
                        ViewBag.errorCategoryName = "there" + model.NewFournisseur.Nom + " Fournisseur Already exist";

                        return View("Index", FournisseurModel());
                    }
                }
                fournisseurRepo.Add(model.NewFournisseur);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fournisseur fournisseur)
        {
            if (ModelState.IsValid)
            {
                 bool exists = fournisseurRepo.List()
                 .Any(f => f.Nom == fournisseur.Nom && f.Id != fournisseur.Id);
                 if (exists)
                 {
                 ViewBag.errorFourniName = $"The Fournisseur {fournisseur.Nom} already exists.";
                 return View("Index", FournisseurModel());
                }
                else
                {
                    fournisseurRepo.Update(fournisseur.Id, fournisseur);
                }
            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Delete(int id)
        {
            fournisseurRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public FournisseurViewModel FournisseurModel()
        {
            var model = new FournisseurViewModel
            {
                NewFournisseur = new Fournisseur(),
                Fournisseurs = fournisseurRepo.List()
            };
            return model;
        }
    }
}
