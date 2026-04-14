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
    public class StockMovementController : Controller
    {
        private readonly IGestionStockRepo<StockMovement> stockRepo;
        private readonly IGestionStockRepo<Produit> produitRepo;
        public StockMovementController(IGestionStockRepo<StockMovement> stockRepo, IGestionStockRepo<Produit> produitRepo)
        {
            this.stockRepo = stockRepo;
            this.produitRepo = produitRepo;
        }
        // GET: StockMovementController
        public ActionResult Index()
        {
            var stockMovements = stockRepo.List();
            return View(stockMovements);
        }

        // GET: StockMovementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StockMovementController/Create
        public ActionResult Create()
        {
            return View(getallProduit());
        }

        // POST: StockMovementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockMovementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var produit = produitRepo.Find(model.Newstockmovement.ProduitId);
                if(model.Newstockmovement.TypeMouvement == "Sortie" && produit.QuantiteStock<model.Newstockmovement.Quantite)
                {
                    ViewBag.errorQuantite = $"Quantite of the Sortie Movement not enough";
                    return View("Create", getallProduit());
                }
                stockRepo.Add(model.Newstockmovement);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: StockMovementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StockMovementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StockMovementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StockMovementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public StockMovementViewModel getallProduit()
        {
            var model = new StockMovementViewModel
            {
                Newstockmovement = new StockMovement { DateMouvement = DateTime.Now },
                Produits = produitRepo.List()
            };
            return model;
        }
    }
}
