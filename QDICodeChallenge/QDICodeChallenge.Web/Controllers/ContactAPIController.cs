using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QDICodeChallenge.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace QDICodeChallenge.Web.Controllers
{
    public class ContactAPIController : ApiControllerBase
    {
        // GET: api/Contact
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return Uow.Contacts.GetAll().ToList();
        }

        // GET: api/Contact/5
        [HttpGet]
        public Contact Get(int id)
        {
            Contact entity = Uow.Contacts.GetById(id);
            if (entity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return entity;
        }

        // GET: api/Contact/Name
        [HttpGet]
        public Contact Get(string firstname, string lastname)
        {
            Contact entity = Uow.Contacts.GetByName(firstname, lastname);
            if (entity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return entity;
        }
        
        // POST: api/Contact
        [HttpPost]
        public HttpResponseMessage Post(Contact entity)
        {
            HttpResponseMessage httpResponseMessage =
                Request.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                var zipcode = Uow.ZipCodes.GetById(entity.zipcodeid);
                if (zipcode != null)
                {
                    entity.zipcode = null;
                }
                else
                {
                    entity.zipcode.updatedby = "website";
                    entity.zipcode.updated = DateTime.Now;
                }

                if (ModelState.IsValid)
                {
                    Uow.Contacts.Add(entity);
                    Uow.Commit();

                    httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, entity);
                    httpResponseMessage.Headers.Location =
                        new Uri(Url.Link("DefaultAPI", new { id = entity.id }));
                }
                else
                {
                    httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (DbEntityValidationException ex)
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

                foreach (var eve in ex.EntityValidationErrors)
                    Console.WriteLine(eve.ToString());
            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            return httpResponseMessage;
        }

        // PUT: api/Contact/5
        [HttpPut]
        public HttpResponseMessage Put(int id, Contact entity)
        {
            HttpResponseMessage httpResponseMessage = 
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
            
            if (!ModelState.IsValid)
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id == entity.id)
            {
                try
                {
                    Contact existingEntity = Uow.Contacts.GetById(id);
                    Uow.Contacts.Detach(existingEntity);
                    entity.zipcode.updatedby = "website";
                    entity.zipcode.updated = DateTime.Now;

                    var zipcode = Uow.ZipCodes.GetById(entity.zipcodeid);
                    if (zipcode == null)
                    {
                        Uow.ZipCodes.Add(entity.zipcode);
                    }
                    Uow.Contacts.Update(entity);

                    Uow.Commit();
                    httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK,
                        "{success: 'true', verb: 'PUT'}");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }
                catch (Exception ex)
                {
                    httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
            return httpResponseMessage;
        }

        // DELETE: api/HomesAPI/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage httpResponseMessage =
                Request.CreateResponse(HttpStatusCode.BadRequest);

            Contact entity = Uow.Contacts.GetById(id);

            if (entity == null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            Uow.Contacts.Delete(entity);

            try
            {
                Uow.Commit();
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            return httpResponseMessage;
        }
    }
}
