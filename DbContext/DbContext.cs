using EntityBase;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DbContext
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbSet<Procude> ProductBase { get; set; }
    }
    public class ProcudeDAL
    {

        public static int Add(Procude pr)
        {
            DbContext db = new DbContext();
            db.ProductBase.Add(pr);
            return db.SaveChanges();
        }
        public static List<Procude> ToLost()
        {
            try
            {
                DbContext db = new DbContext();
                return db.ProductBase.ToList();
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
