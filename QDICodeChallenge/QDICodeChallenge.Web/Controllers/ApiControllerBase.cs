using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using QDICodeChallenge.Data;

namespace QDICodeChallenge.Web.Controllers
{
    public class ApiControllerBase : ApiController
    {
        public readonly ContactUow Uow;

        public ApiControllerBase()
        {
            Uow = new ContactUow();
        }

        protected override void Dispose(bool disposing)
        {
            Uow.Dispose();
            base.Dispose(disposing);
        }
    }
}