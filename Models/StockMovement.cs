using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.Models
{
    public class StockMovement
    {
        public int Id { get; set; }
        public int ProduitId { get; set; }
        public Produit Produit { get; set; } = null!;
        public string TypeMouvement { get; set; } = "Entrée"; // "Entrée" or "Sortie"
        public int Quantite { get; set; }
        public DateTime DateMouvement { get; set; } = DateTime.Now; //"Vente client " or "Réapprovisionnement " or "Produit abîmé "
        public string? Motif { get; set; }
    }
}
