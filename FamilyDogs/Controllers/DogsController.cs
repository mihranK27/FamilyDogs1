using FamilyDogs.Models.Request;
using FamilyDogs.Services;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace FamilyDogs.Controllers
{
    [RoutePrefix("dogs")]
    public class DogsController : Controller
    {

        DogService ds = new DogService();


        [Route("home")]
        public ActionResult Index()
        {
            return View();
        }


        [Route("dogsindex"), HttpGet]
        public ActionResult DogsIndex()
        {
            var dogs = ds.GetAll();
            return View(dogs);
        }


        [Route("add"), HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [Route("add"), HttpPost]
        public ActionResult Create(DogsCreateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                string extension = Path.GetExtension(model.ImageUpload.FileName);
                fileName = fileName + extension;
                model.Image = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                model.ImageUpload.SaveAs(fileName);               
            }
            
            if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            {
                model.Image = "~/Image/image-not-found.png";
            }


            DogService ds = new DogService();
            ds.Create(model);
            return RedirectToAction("DogsIndex");
        }


        [Route("{id:int}/edit"), HttpGet]
        public ActionResult Edit(int id)
        {
            var dog = ds.GetById(id);

            if (dog == null)
                return HttpNotFound();

            DogsUpdateRequest model = new DogsUpdateRequest();

            model.Id = dog.Id;
            model.Name = dog.Name;
            model.Breed = dog.Breed;
            model.Color = dog.Color;
            model.Size = dog.Size;
            model.LivingArea = dog.LivingArea;
            model.LifeExpectancy = dog.LifeExpectancy;
            model.ShedScore = dog.ShedScore;
            model.AgressiveScore = dog.AgressiveScore;
            model.ExerciseScore = dog.ExerciseScore;
            model.Image = dog.Image;

            return View(model);
        }


        [Route("{id:int}/edit"), HttpPost]
        public ActionResult Edit(DogsUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                string extension = Path.GetExtension(model.ImageUpload.FileName);
                fileName = fileName + extension;
                model.Image = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                model.ImageUpload.SaveAs(fileName);
            }

            if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            {
                model.Image = "~/Image/image-not-found.png";
            }

            DogService ds = new DogService();
            ds.Update(model);
            return RedirectToAction("DogsIndex");
        }




        [Route("Delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            DogService ds = new DogService();
            ds.Delete(id);
            return RedirectToAction("DogsIndex");
        }

    }
}