using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_de_stock.Models.Repositories
{
    public class CategoryDbRepo : IGestionStockRepo<Categorie>
    {
        AppDBContext db;
        public CategoryDbRepo(AppDBContext _db)
        {
            this.db = _db;
        }

        public void Add(Categorie entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public Categorie Find(int id)
        {
            var category = db.Categories.SingleOrDefault(a => a.Id == id);
            return category;
        }

        public IList<Categorie> List()
        {
            return db.Categories.ToList();
        }

        public void Update(int id,Categorie entity)
        {
            var existingCategory = db.Categories.Find(id);
            if (existingCategory != null)
            {
                db.Entry(existingCategory).CurrentValues.SetValues(entity);
                db.SaveChanges();
            }
        }
    }
}
