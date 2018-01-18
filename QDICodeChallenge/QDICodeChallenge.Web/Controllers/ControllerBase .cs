using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QDICodeChallenge.Data;

namespace QDICodeChallenge.Web.Controllers
{
    public class ControllerBase : Controller
    {
        public readonly ContactUow Uow;

        public ControllerBase()
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