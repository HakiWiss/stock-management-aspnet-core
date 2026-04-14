using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal PrixAchat { get; set; }
        public decimal PrixVente { get; set; }
        public int QuantiteStock { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; } = null!;
        public int FournisseurId { get; set; }
        public Fournisseur Fournisseur { get; set; } = null!;
        public List<StockMovement> StockMovements { get; set; } = new();
    }
}
