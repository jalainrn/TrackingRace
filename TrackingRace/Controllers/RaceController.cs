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
    public class RaceController : Controller
    {
        private Context _context = null;

        public RaceController()
        {
            _context = new Context();
        }

        private bool _disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;

            base.Dispose(disposing);
        }

        // GET: States
        public ActionResult Index()
        {
            ViewBag.Title = "Work With Races";

            using (var context = new Context())
            {
                var raceList = new RaceListViewModel
                {
                    Races = context.Races.Select(p => new RaceViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Profit = p.Profit,
                        City = p.City,
                        Date = p.Date,
                        StateId = p.StateId,
                        StateName = p.State.Name,
                        StateAcronym = p.State.Acronym,
                        RaceTypeName = p.RaceType.Name,
                        RaceTypeId = p.RaceTypeId
                    }).ToList()
                };
                raceList.TotalRaces = raceList.Races.Count;

                return View(raceList);
            }
            
        }

        //Detail
        public ActionResult Detail(int id)
        {
            //ViewBag.Title = "Detail";
            using (var context = new Context())
            {
                //var restaurant = lunchContext.Restaurants.SingleOrDefault(p => p.RestaurantId == id);
                var race = context.Races.Include("State").Include("RaceType").SingleOrDefault(p => p.Id == id);
                if (race != null)
                {
                    var raceViewModel = new RaceViewModel
                    {
                        Id = race.Id,
                        Name = race.Name,
                        Profit = race.Profit,
                        Address = race.Address,
                        City = race.City,
                        DateString = race.Date.ToShortDateString(),
                        StateId = race.StateId,
                        RaceTypeId = race.RaceTypeId,
                        StateName = race.State.Name,
                        RaceTypeName = race.RaceType.Name,
                        ZipCode = race.ZipCode
                    };

                    ViewBag.Title = "Detail: " + raceViewModel.Name;
                    return View(raceViewModel);
                }
            }
            return new HttpNotFoundResult();
        }

        //Add
        public ActionResult Add()
        {
            ViewBag.Title = "Add Race";
            var raceViewModel = new RaceViewModel();

            ViewBag.SelectRaceType = new SelectList(
                _context.RaceTypes, "Id", "Name");

            ViewBag.SelectState = new SelectList(
                _context.States, "Id", "Name");

            raceViewModel.Date = DateTime.Today;

            return View("AddEdit", raceViewModel);
        }
        
        [HttpPost]
        public ActionResult Add(RaceViewModel raceViewModel)
        {

            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    var race = new Race
                    {
                        Name = raceViewModel.Name,
                        Date = raceViewModel.Date,
                        RaceTypeId = raceViewModel.RaceTypeId,
                        Address = raceViewModel.Address,
                        City = raceViewModel.City,
                        StateId = raceViewModel.StateId,
                        ZipCode = raceViewModel.ZipCode,
                        Profit = raceViewModel.Profit
                    };

                    context.Races.Add(race);
                    context.SaveChanges();
                }

                TempData["Message"] = "Your race was successfully added!";
                return RedirectToAction("Index");
            }

            ViewBag.SelectRaceType = new SelectList(
                _context.RaceTypes, "Id", "Name");

            ViewBag.SelectState = new SelectList(
                _context.States, "Id", "Name");

            return View("AddEdit", raceViewModel);
        }

        public ActionResult Edit(int id)
        {
            using (var context = new Context())
            {
                var race = context.Races.SingleOrDefault(p => p.Id == id);
                if (race != null)
                {
                    var raceViewModel = new RaceViewModel
                    {
                        Id = race.Id,
                        Name = race.Name,
                        Date = race.Date,
                        RaceTypeId = race.RaceTypeId,
                        Address = race.Address,
                        City = race.City,
                        StateId = race.StateId,
                        ZipCode = race.ZipCode,
                        Profit = race.Profit
                    };

                    ViewBag.SelectRaceType = new SelectList(
                        _context.RaceTypes, "Id", "Name");

                    ViewBag.SelectState = new SelectList(
                        _context.States, "Id", "Name");

                    return View("AddEdit", raceViewModel);
                }
            }
            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult Edit(RaceViewModel raceViewModel)
        {
            //ValdateState(stateViewModel);

            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    var race = context.Races.SingleOrDefault(p => p.Id == raceViewModel.Id);

                    if (race != null)
                    {
                        race.Name = raceViewModel.Name;
                        race.Date = raceViewModel.Date;
                        race.RaceTypeId = raceViewModel.RaceTypeId;
                        race.Address = raceViewModel.Address;
                        race.City = raceViewModel.City;
                        race.StateId = raceViewModel.StateId;
                        race.ZipCode = raceViewModel.ZipCode;
                        race.Profit = raceViewModel.Profit;

                        TempData["Message"] = "This race was successfully updated!";
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    };
                }
            }
            return View(raceViewModel);
        }

        //Delete
        [HttpPost]
        public ActionResult Delete(RaceViewModel raceViewModel)
        {
            using (var context = new Context())
            {
                var race = context.Races.SingleOrDefault(p => p.Id == raceViewModel.Id);
                if (race != null)
                {
                    TempData["Message"] = race.Name + " race was successfully deleted!";
                    context.Races.Remove(race);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return new HttpNotFoundResult();
        }
    }
}