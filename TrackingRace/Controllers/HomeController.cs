using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackingRace.ViewModels;
using TrackingRaceLibrary.Data;

namespace TrackingRace.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Work With Races";

            using (var context = new Context())
            {
                var raceList = new RaceListViewModel
                {
                    Races = context.Races.Include("State").Include("RaceType").Select(p => new RaceViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Profit = p.Profit,
                        City = p.City,
                        StateId = p.StateId,// = new StateViewModel
                        //{
                        //    Id = p.StateId,
                        //    Name = p.State.Name,
                        //    Acronym = p.State.Acronym
                        //},
                        RaceTypeId = p.RaceTypeId,//new RaceTypeViewModel
                        //{
                        //    Id = p.RaceType.Id,
                        //    Name = p.RaceType.Name,
                        //    DistanceKm = p.RaceType.DistanceKm
                        //}
                    }).ToList()
                };
                raceList.TotalRaces = raceList.Races.Count;

                return View(raceList);
            }
        }
    }
}