using Gestion_de_stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.ViewModels
{
    public class CategorieViewModel
    {
        public Categorie NewCategorie { get; set; } = new Categorie();
        public IEnumerable<Categorie> Categories { get; set; } = new List<Categorie>();
    }
}
