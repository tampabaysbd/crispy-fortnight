using System.Linq;
using QDICodeChallenge.Models;
using System.Collections.Generic;

namespace QDICodeChallenge.Data
{
    public class ZipCodeRepository : GenericRepository<ZipCode>
    {
        public ZipCodeRepository(DataContext dbContext) :base(dbContext) { }

        public ZipCode GetById(string id)
        {
            return GetAll().FirstOrDefault(t => t.zipcodeid == id);
        }
    }
}
