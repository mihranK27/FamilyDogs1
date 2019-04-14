using FamilyDogs.Domain;
using FamilyDogs.Models.Request;
using FamilyDogs.Models.Response;
using FamilyDogs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FamilyDogs.Controllers.Api
{
    [RoutePrefix("api/familydogs")]
    public class DogsApiController : ApiController
    {
        DogService ds = new DogService();

        //Create
        [Route(), HttpPost]
        public HttpResponseMessage Create(DogsCreateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = ds.Create(model);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        //Update
        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(DogsUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            SuccessResponse response = new SuccessResponse();
            ds.Update(model);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        //GetAll
        [Route(), HttpGet]
        public HttpResponseMessage Index()
        {
            ItemsResponse<Dog> response = new ItemsResponse<Dog>();
            response.Items = ds.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        //GetById
        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            ItemResponse<Dog> response = new ItemResponse<Dog>();
            response.Item = ds.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        //Delete
        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            SuccessResponse response = new SuccessResponse();
            ds.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}