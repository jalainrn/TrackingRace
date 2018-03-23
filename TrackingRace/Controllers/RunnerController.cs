using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackingRace.ViewModels;
using TrackingRaceLibrary.Data;

namespace TrackingRace.Controllers
{
    public class RunnerController : Controller
    {
        // GET: Runner
        public ActionResult Index()
        {
            ViewBag.Title = "Work With Races";

            using (var context = new Context())
            {
                var runnerList = new RunnerListViewModel
                {
                    Runners = context.Runners.Select(p => new RunnerViewModel
                    {
                        Id = p.Id,
                        FName = p.FName,
                        LName = p.LName,
                        SizeId = p.SizeId,
                        GenderId = p.GenderId,
                        DOB = p.DOB,
                        Email = p.Email,
                        Phone = p.Phone,
                        WaiverAgreement = p.WaiverAgreement,
                        
                    }).ToList()
                };
                runnerList.TotalRuners = runnerList.Runners.Count;

                return View(runnerList);
            }
        }
    }
}