using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.Models
{
    public class ProduitState
    {
        public string NomProduit { get; set; } = string.Empty;
        public string NomCategorie { get; set; } = string.Empty;
        public int Quantite { get; set; }
        public decimal TotalVente { get; set; } // PrixVente * Quantity Sold
    }
}
