using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QDICodeChallenge.Models;
using System.Data.Entity.Infrastructure;

namespace QDICodeChallenge.Web.Controllers
{
    public class ZipCodeAPIController : ApiControllerBase
    {
        // GET: api/ZipCode
        [HttpGet]
        public IEnumerable<ZipCode> Get()
        {
            return Uow.ZipCodes.GetAll().ToList();
        }

        // GET: api/ZipCode/5
        [HttpGet]
        public ZipCode Get(string id)
        {
            ZipCode entity = Uow.ZipCodes.GetById(id);
            if (entity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return entity;
        }

        // POST: api/ZipCode
        [HttpPost]
        public HttpResponseMessage Post(ZipCode entity)
        {
            HttpResponseMessage httpResponseMessage =
                Request.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                if (ModelState.IsValid)
                {
                    Uow.ZipCodes.Add(entity);
                    Uow.Commit();

                    httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, entity);
                    httpResponseMessage.Headers.Location =
                        new Uri(Url.Link("DefaultAPI", new { id = entity.zipcodeid }));
                }
                else
                {
                    httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            return httpResponseMessage;
        }

        // PUT: api/ZipCode/5
        [HttpPut]
        public HttpResponseMessage Put(string id, ZipCode entity)
        {
            HttpResponseMessage httpResponseMessage =
                Request.CreateResponse(HttpStatusCode.BadRequest);

            if (!ModelState.IsValid)
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id == entity.zipcodeid)
            {
                ZipCode existingEntity = Uow.ZipCodes.GetById(id);
                Uow.ZipCodes.Detach(existingEntity);
                Uow.ZipCodes.Update(entity);

                try
                {
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

        // DELETE: api/ZipCode/5
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            HttpResponseMessage httpResponseMessage =
                Request.CreateResponse(HttpStatusCode.BadRequest);

            ZipCode entity = Uow.ZipCodes.GetById(id);

            if (entity == null)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            Uow.ZipCodes.Delete(entity);

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
