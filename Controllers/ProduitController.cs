using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestion_de_stock.Models;
using Gestion_de_stock.Models.Repositories;
using Gestion_de_stock.ViewModels;

namespace Gestion_de_stock.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IGestionStockRepo<Produit> produitRepo;
        private readonly IGestionStockRepo<Fournisseur> fournisseurRepo;
        private readonly IGestionStockRepo<Categorie> categoryRepo;

        public ProduitController(IGestionStockRepo<Produit> produitRepo, IGestionStockRepo<Fournisseur> fournisseurRepo, IGestionStockRepo<Categorie> categoryRepo)
        {
            this.produitRepo = produitRepo;
            this.fournisseurRepo = fournisseurRepo;
            this.categoryRepo = categoryRepo;
        }
        // GET: ProduitController
        public ActionResult Index()
        {
            var produits = produitRepo.List();
            return View(produits);
        }
        // GET: ProduitController/Create
        public ActionResult Create()
        {  
            return View(getallCatego_fourni());
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category_ForniViewModel produit)
        {
            if (ModelState.IsValid)
            {
                
                bool exists = produitRepo.List()
                 .Any(f => f.Nom == produit.NewProduit.Nom);
                if (exists)
                {
                    ViewBag.errorProduitName = $"The Produit {produit.NewProduit.Nom} already exists.";
                    return View("Create", getallCatego_fourni());
                }
                else
                {
                    produitRepo.Add(produit.NewProduit);
                }
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            var category_fornisseur = new Category_ForniViewModel
            {
                NewProduit = produitRepo.Find(id),
                Categories = categoryRepo.List(),
                Fournisseurs = fournisseurRepo.List()
            };
            return View(category_fornisseur);
        }

        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category_ForniViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool exists = produitRepo.List()
                .Any(f => f.Nom == model.NewProduit.Nom && f.Id != model.NewProduit.Id);
                if (exists)
                {
                    ViewBag.errorProduitName = $"The Fournisseur {model.NewProduit.Nom} already exists.";
                    var category_fornisseur = new Category_ForniViewModel
                    {
                        NewProduit = produitRepo.Find(model.NewProduit.Id),
                        Categories = categoryRepo.List(),
                        Fournisseurs = fournisseurRepo.List()
                    };
                    return View("Edit", category_fornisseur);
                }
                else
                {
                    produitRepo.Update(model.NewProduit.Id, model.NewProduit);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            produitRepo.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {

            return View(produitRepo.Find(id));
        }

        public Category_ForniViewModel getallCatego_fourni()
        {
            var category_fornisseur = new Category_ForniViewModel
            {
                NewProduit = null,
                Categories = categoryRepo.List(),
                Fournisseurs = fournisseurRepo.List()
            };
            return category_fornisseur;
        }
    }
}
