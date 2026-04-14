using Gestion_de_stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.ViewModels
{
    public class Category_ForniViewModel
    {
        public Produit NewProduit { get; set; } = new Produit();
        public IEnumerable<Fournisseur> Fournisseurs { get; set; } = new List<Fournisseur>();
        public IEnumerable<Categorie> Categories { get; set; } = new List<Categorie>();
    }
}
