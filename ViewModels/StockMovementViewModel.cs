using Gestion_de_stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.ViewModels
{
    public class StockMovementViewModel
    {
        public StockMovement Newstockmovement { get; set; } = new StockMovement();
        public IEnumerable<Produit> Produits { get; set; } = new List<Produit>();
    }
}
