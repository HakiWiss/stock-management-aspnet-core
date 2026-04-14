using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.Models.Repositories
{
    public class FournisseurRepo : IGestionStockRepo<Fournisseur>
    {
        AppDBContext db;
        public FournisseurRepo(AppDBContext _db)
        {
            this.db = _db;
        }
        public void Add(Fournisseur entity)
        {
            db.Fournisseurs.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var fournisseur = Find(id);
            db.Fournisseurs.Remove(fournisseur);
            db.SaveChanges();
        }

        public Fournisseur Find(int id)
        {
            var fournissuer = db.Fournisseurs.SingleOrDefault(a => a.Id == id);
            return fournissuer;
        }

        public IList<Fournisseur> List()
        {
            return db.Fournisseurs.ToList();
        }

        public void Update(int id, Fournisseur entity)
        {
            var existingFournisseur= db.Fournisseurs.Find(id);
            if (existingFournisseur != null)
            {
                db.Entry(existingFournisseur).CurrentValues.SetValues(entity);
                db.SaveChanges();
            }
        }
    }
}
