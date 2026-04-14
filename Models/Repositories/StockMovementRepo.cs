using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_stock.Models.Repositories
{
    public class StockMovementRepo : IGestionStockRepo<StockMovement>
    {
        AppDBContext db;
        public StockMovementRepo(AppDBContext _db) { this.db = _db; }

        public void Add(StockMovement entity)
        {
            var produit = db.Produits.Find(entity.ProduitId); 

            if (produit != null)
            {
                if (entity.TypeMouvement == "Sortie") 
                {
                    produit.QuantiteStock -= entity.Quantite;
                }
                else if (entity.TypeMouvement == "Entrée") 
                {
                    produit.QuantiteStock += entity.Quantite; 
                }
                db.Entry(produit).State = EntityState.Modified; 
            }

            db.StockMovements.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var stockmove = Find(id);
            db.StockMovements.Remove(stockmove);
            db.SaveChanges();
        }

        public StockMovement Find(int id)
        {
            var stockmove = db.StockMovements.Include(a => a.Produit).SingleOrDefault(e => e.Id == id);
            return stockmove;
        }

        public IList<StockMovement> List()
        {
            return db.StockMovements.Include(a => a.Produit).ToList();
        }

        public void Update(int id, StockMovement entity)
        {
            db.StockMovements.Update(entity);
            db.SaveChanges();
        }
    }
}
