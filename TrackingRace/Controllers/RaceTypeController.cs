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
    public class RaceTypeController : Controller
    {
        // GET: States
        public ActionResult Index()
        {
            using (var context = new Context())
            {
                var raceTypeList = new RaceTypeListViewModel
                {
                    //Convert each RaceType to a RaceTypeViewModel
                    RaceTypes = context.RaceTypes.Select(p => new RaceTypeViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        DistanceKm = p.DistanceKm
                    }).ToList()
                };
                raceTypeList.TotalRaceTypes = raceTypeList.RaceTypes.Count;
                ViewBag.Title = "Work With Race Types";
                return View(raceTypeList);
            }
        }
        
        //Detail
        public ActionResult Detail(int id)
        {
            using (var context = new Context())
            {
                var raceType = context.RaceTypes.SingleOrDefault(p => p.Id == id);
                if(raceType != null)
                {
                    var raceTypeViewModel = new RaceTypeViewModel
                    {
                        Id = raceType.Id,
                        Name = raceType.Name,
                        DistanceKm = raceType.DistanceKm
                    };
                    ViewBag.Title = "Detail " + raceTypeViewModel.Name;
                    return View(raceTypeViewModel);
                };
            }
            return new HttpNotFoundResult();
        }

        //Add
        public ActionResult Add()
        {
            ViewBag.Title = "Add Race Type";
            var raceTypeViewModel = new RaceTypeViewModel();

            return View("AddEdit", raceTypeViewModel);
        }

        [HttpPost]
        public ActionResult Add(RaceTypeViewModel raceTypeViewModel)
        {
            //ValdateState(stateViewModel);

            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    var raceType = new RaceType
                    {
                        Name = raceTypeViewModel.Name,
                        DistanceKm = raceTypeViewModel.DistanceKm
                    };

                    context.RaceTypes.Add(raceType);
                    context.SaveChanges();
                }

                TempData["Message"] = "Your state was successfully added!";
                return RedirectToAction("Index");
            }

            return View(raceTypeViewModel);
        }
        

        //Edit
        public ActionResult Edit(int id)
        {
            using (var context = new Context())
            {
                var raceType = context.RaceTypes.SingleOrDefault(p => p.Id == id);
                if (raceType != null)
                {
                    var raceTypeViewModel = new RaceTypeViewModel
                    {
                        Id = raceType.Id,
                        Name = raceType.Name,
                        DistanceKm = raceType.DistanceKm
                    };
                    return View("AddEdit", raceTypeViewModel);
                }
            }
            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult Edit(RaceTypeViewModel raceTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    var raceType = context.RaceTypes.SingleOrDefault(p => p.Id == raceTypeViewModel.Id);

                    if (raceType != null)
                    {
                        raceType.Name = raceTypeViewModel.Name;
                        raceType.DistanceKm = raceTypeViewModel.DistanceKm;

                        TempData["Message"] = "Your state was successfully updated!";
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    };
                }
            }
            return View(raceTypeViewModel);
        }




        //Delete
        [HttpPost]
        public ActionResult Delete(RaceTypeViewModel raceTypeViewModel)
        {
            using (var context = new Context())
            {
                var raceType = context.RaceTypes.SingleOrDefault(p => p.Id == raceTypeViewModel.Id);
                if (raceType != null)
                {
                    TempData["Message"] = raceType.Name + " state was successfully deleted!";
                    context.RaceTypes.Remove(raceType);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return new HttpNotFoundResult();
        }





    }
}