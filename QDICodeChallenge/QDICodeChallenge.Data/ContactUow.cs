using System;
using QDICodeChallenge.Contract;
using QDICodeChallenge.Models;

namespace QDICodeChallenge.Data
{
    public class ContactUow : IDisposable
    {
        private readonly DataContext dbContext = null;
        private ContactRepository _contacts = null;
        private ZipCodeRepository _zipCodes = null;

        public ContactUow()
        {
            dbContext = new DataContext();
        }

        // repositories
        public ContactRepository Contacts { get { return _contacts ?? new ContactRepository(dbContext); } }
        public ZipCodeRepository ZipCodes { get { return _zipCodes ?? new ZipCodeRepository(dbContext); } }
        
        public void Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            dbContext.SaveChanges();
        }
        
        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                }
            }
        }
        #endregion
    }
}