using Gestion_de_stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.ViewModels
{
    public class FournisseurViewModel
    {
        public Fournisseur NewFournisseur { get; set; } = new Fournisseur();
        public IEnumerable<Fournisseur> Fournisseurs { get; set; } = new List<Fournisseur>();
    }
}
