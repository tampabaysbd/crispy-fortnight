using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QDICodeChallenge.Web.ViewModels;
using QDICodeChallenge.Models;
using System.Data.Entity;

namespace QDICodeChallenge.Web.Controllers
{
    public class ContactController : ControllerBase
    {
        public ActionResult Index()
        {
            var query = Uow.Contacts.GetAll().Include("zipcode").OrderBy(t => t.lastname).ThenBy(t => t.firstname);
            ContactsListViewModel vm = new ContactsListViewModel();
            vm.Contacts = query.ToList();
            return View("Index", vm);
        }

        public ActionResult Add()
        {
            ViewBag.Title = "Add Contact";
            ContactViewModel vm = new ContactViewModel();
            vm.IsAdd = true;
            return View("AddEdit", vm);
        }

        public ActionResult Edit(int id)
        {
            ActionResult result = View("NotFound");
            ViewBag.Title = "Edit Contact";
            Contact entity = Uow.Contacts.GetById(id);

            if (entity != null)
            {
                ContactViewModel vm = new ContactViewModel(entity);
                vm.IsAdd = false;
                result = View("AddEdit", vm);
            }
            return result;
        }

        public ActionResult Validation()
        {
            ViewBag.Title = "Validation Test";
            return View();
        }
    }

    
}