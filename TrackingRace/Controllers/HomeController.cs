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
            ViewBag.Title = "Upcoming Races";

            using (var context = new Context())
            {
                var raceList = new RaceListViewModel
                {
                    Races = context.Races.Select(p => new RaceViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Profit = p.Profit,
                        Address = p.Address,
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
    }
}