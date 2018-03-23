using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackingRace.ViewModels;
using TrackingRaceLibrary.Data;
using TrackingRaceLibrary.Models;

namespace TrackingRace.Controllers
{
    public class SizeController : Controller
    {
        // GET: size
        public ActionResult Index()
        {
            using (var context = new Context())
            {
                var sizeList = new SizeListViewModel
                {
                    //Convert each size to a SizeViewModel
                    Sizes = context.Sizes.Select(p => new SizeViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Acronym = p.Acronym
                    }).ToList()
                };
                sizeList.TotalSizes = sizeList.Sizes.Count;
                ViewBag.Title = "Work With Sizes";
                return View(sizeList);
            }
        }

        //Detail
        public ActionResult Detail(int id)
        {
            using (var context = new Context())
            {
                var size = context.Sizes.SingleOrDefault(p => p.Id == id);
                if (size != null)
                {
                    var SizeViewModel = new SizeViewModel
                    {
                        Id = size.Id,
                        Name = size.Name,
                        Acronym = size.Acronym
                    };
                    ViewBag.Title = "Detail " + SizeViewModel.Name;
                    return View(SizeViewModel);
                }
            }
            return new HttpNotFoundResult();
        }

        //Add
        public ActionResult Add()
        {
            ViewBag.Title = "Add size";
            var SizeViewModel = new SizeViewModel();

            return View("AddEdit", SizeViewModel);
        }

        [HttpPost]
        public ActionResult Add(SizeViewModel SizeViewModel)
        {
            //Valdatesize(SizeViewModel);

            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    var size = new Size
                    {
                        Name = SizeViewModel.Name,
                        Acronym = SizeViewModel.Acronym
                    };

                    context.Sizes.Add(size);
                    context.SaveChanges();
                }

                TempData["Message"] = "Your size was successfully added!";
                return RedirectToAction("Index");
            }

            return View(SizeViewModel);
        }

        //Edit
        public ActionResult Edit(int id)
        {
            using (var context = new Context())
            {
                var size = context.Sizes.SingleOrDefault(p => p.Id == id);
                if (size != null)
                {
                    var SizeViewModel = new SizeViewModel
                    {
                        Id = size.Id,
                        Name = size.Name,
                        Acronym = size.Acronym
                    };
                    return View("AddEdit", SizeViewModel);
                }
            }
            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult Edit(SizeViewModel SizeViewModel)
        {
            //Valdatesize(SizeViewModel);

            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    var size = context.Sizes.SingleOrDefault(p => p.Id == SizeViewModel.Id);

                    if (size != null)
                    {
                        size.Name = SizeViewModel.Name;
                        size.Acronym = SizeViewModel.Acronym;

                        TempData["Message"] = "Your size was successfully updated!";
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    };
                }
            }
            return View(SizeViewModel);
        }


        //Delete
        [HttpPost]
        public ActionResult Delete(SizeViewModel SizeViewModel)
        {
            using (var context = new Context())
            {
                var size = context.Sizes.SingleOrDefault(p => p.Id == SizeViewModel.Id);
                if (size != null)
                {
                    TempData["Message"] = size.Name + " size was successfully deleted!";
                    context.Sizes.Remove(size);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return new HttpNotFoundResult();
        }
    }
}