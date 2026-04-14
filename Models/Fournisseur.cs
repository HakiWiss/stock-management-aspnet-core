using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.Models
{
    public class Fournisseur
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; } = string.Empty;
        [Required]
        public string? Telephone { get; set; }
        public string? Adresse { get; set; }
        public List<Produit> Produits { get; set; } = new();
    }
}
