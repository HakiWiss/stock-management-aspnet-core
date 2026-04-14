using Gestion_de_stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.ViewModels
{
    public class HomeViewModel
    {
        public List<ProduitState> TopSellingProducts { get; set; } = new();
        public List<ProduitState> TopPurchasedProducts { get; set; } = new();
        public List<Produit> LowStockProducts { get; set; } = new();
        public int TotalProducts { get; set; } = new();
        public int LowStockCount { get; set; } = new();
        public decimal TotalSales { get; set; } = new();
        public decimal TotalPurchare { get; set; } = new();
    }
}
