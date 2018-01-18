using System.Linq;
using QDICodeChallenge.Models;
using System.Collections.Generic;

namespace QDICodeChallenge.Data
{
    public class ContactRepository : GenericRepository<Contact>
    {
        public ContactRepository(DataContext dbContext) :base(dbContext) { }

        public override Contact GetById(int id)
        {
            Contact entity = base.GetById(id);
            DbContext.Entry(entity).Reference("zipcode").Load();
            return entity;
        }

        public Contact GetByName(string firstname, string lastname)
        {
            return GetAll().FirstOrDefault(t => t.firstname == firstname && t.lastname == lastname);
        }

    }
}
