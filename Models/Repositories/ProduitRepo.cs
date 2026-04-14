using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.Models.Repositories
{
    public class ProduitRepo : IGestionStockRepo<Produit>
    {
        AppDBContext db;
        public ProduitRepo(AppDBContext _db)
        {
            this.db = _db;
        }

        public void Add(Produit entity)
        {
            db.Produits.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var produit = Find(id);
            db.Produits.Remove(produit);
            db.SaveChanges();
        }

        public Produit Find(int id)
        {
            var produit = db.Produits.Include(a => a.Categorie).Include(b => b.Fournisseur).Include(e => e.StockMovements).SingleOrDefault(a => a.Id == id);
            return produit;
        }

        public IList<Produit> List()
        {
            return db.Produits.Include(a => a.Categorie).Include(b=>b.Fournisseur).Include(e=>e.StockMovements).ToList();
        }

        public void Update(int id, Produit entity)
        {
            var existingProduit = db.Produits.Find(id);
            if (existingProduit != null)
            {
                db.Entry(existingProduit).CurrentValues.SetValues(entity);
                db.SaveChanges();
            }
        }
    }
}
