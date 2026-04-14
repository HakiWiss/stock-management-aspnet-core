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
    public class HomeController : Controller
    {
        private readonly IGestionStockRepo<Produit> produitRepo;
        private readonly IGestionStockRepo<StockMovement> stockMovementRepo;

        public HomeController(IGestionStockRepo<Produit> produitRepo, IGestionStockRepo<StockMovement> stockMovementRepo)
        {
            this.produitRepo = produitRepo;
            this.stockMovementRepo = stockMovementRepo;
        }
        // GET: HomeController
        public ActionResult Index()
        {
            // Top 5 Best-Selling Products (Sortie)
            var topSellingProducts = stockMovementRepo.List()
                .Where(m => m.TypeMouvement == "Sortie")
                .GroupBy(m => m.ProduitId)
                .Select(g =>
                {
                    var produit = produitRepo.Find(g.Key);
                    return new ProduitState
                    {
                        NomProduit = produit.Nom,
                        NomCategorie = produit.Categorie.Nom,
                        Quantite = g.Sum(m => m.Quantite),
                        TotalVente = produit.PrixVente * g.Sum(m => m.Quantite)
                    };
                })
                .OrderByDescending(g => g.Quantite)
                .Take(5) //top 5
                .ToList();

            // Top 5 Most Purchased Products (Entrée)
            var topPurchasedProducts = stockMovementRepo.List()
                .Where(m => m.TypeMouvement == "Entrée")
                .GroupBy(m => m.ProduitId)
                .Select(g =>
                {
                    var produit = produitRepo.Find(g.Key);
                    return new ProduitState
                    {
                        NomProduit = produit.Nom,
                        NomCategorie = produit.Categorie.Nom,
                        Quantite = g.Sum(m => m.Quantite),
                        TotalVente = produit.PrixAchat * g.Sum(m => m.Quantite) // Total purchase amount
            };
                })
                .OrderByDescending(g => g.Quantite)
                .Take(5)
                .ToList();

            // Products Low on Stock (Threshold < 10)
            var lowStockProducts = produitRepo.List()
                .Where(p => p.QuantiteStock < 10)
                .OrderBy(p => p.QuantiteStock)
                .ToList();

            int totalProducts = produitRepo.List().Count();
            int lowStockCount = lowStockProducts.Count();
            decimal totalSales = stockMovementRepo.List()
                .Where(m => m.TypeMouvement == "Sortie")
                .Sum(m => m.Quantite * produitRepo.Find(m.ProduitId).PrixVente);
            decimal TotalPurchare = stockMovementRepo.List()
                .Where(m => m.TypeMouvement == "Entrée")
                .Sum(m => m.Quantite * produitRepo.Find(m.ProduitId).PrixVente);


            var homeViewModel = new HomeViewModel
            {
                TopSellingProducts = topSellingProducts,
                TopPurchasedProducts = topPurchasedProducts,
                LowStockProducts = lowStockProducts,
                TotalProducts = totalProducts,
                LowStockCount = lowStockCount,
                TotalSales = totalSales,
                TotalPurchare = TotalPurchare
            };

            return View(homeViewModel);
        }
        public ActionResult Contact()
        {
            return View();
        }

    }
}
