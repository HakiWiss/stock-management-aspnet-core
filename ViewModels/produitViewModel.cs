using Gestion_de_stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.ViewModels
{
    public class produitViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal PrixAchat { get; set; }
        public decimal PrixVente { get; set; }
        public int QuantiteStock { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; } 
        public int FournisseurId { get; set; }
        public Fournisseur Fournisseur { get; set; } 
        public List<StockMovement> StockMovements { get; set; } = new();
    }
}
