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
    public class RunnerController : Controller
    {
        private Context _context = null;

        public RunnerController()
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
        
        //Start the Sign-Up proccess
        public ActionResult Signup(int? raceId)
        {

            ViewBag.Title = "Signup Runner";
            var runnerViewModel = new RunnerViewModel();
            runnerViewModel.DOB = DateTime.Now.Date;
            if (raceId != null)
            {
                runnerViewModel.RaceId = raceId.Value;
                ViewBag.Race = _context.Races.SingleOrDefault(r => r.Id == raceId);
            }
            else
            {
                ViewBag.SelectRace = new SelectList(_context.Races, "Id", "Name");
            }

            ViewBag.SelectGender = new SelectList(_context.Gender, "Id", "Name");

            ViewBag.SelectSize = new SelectList(_context.Sizes, "Id", "Name");

            return View("SignupEdit", runnerViewModel);
        }
        
        //Validate Runner info before submit payment
        [HttpPost]
        public ActionResult Signup(RunnerViewModel runnerViewModel)
        {
            if (ModelState.IsValid)
            {
                var race = _context.Races.SingleOrDefault(r => r.Id == runnerViewModel.RaceId);
                ViewBag.RaceName = race.Name;
                return View("CheckOut", runnerViewModel);
            }
            ViewBag.SelectRace = new SelectList(_context.Races, "Id", "Name");
            ViewBag.SelectGender = new SelectList(_context.Gender, "Id", "Name");
            ViewBag.SelectSize = new SelectList(_context.Sizes, "Id", "Name");
            return View("SignupEdit", runnerViewModel);
        }

        
        public ActionResult ReviewInfo(RunnerViewModel runnerViewModel)
        {
            ViewBag.SelectRace = new SelectList(_context.Races, "Id", "Name");
            ViewBag.SelectGender = new SelectList(_context.Gender, "Id", "Name");
            ViewBag.SelectSize = new SelectList(_context.Sizes, "Id", "Name");
            return View("SignupEdit", runnerViewModel);
        }


        [HttpPost]
        public ActionResult SheckOut(RunnerViewModel runnerViewModel)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    var runner = new Runner
                    {
                        FName = runnerViewModel.FName,
                        LName = runnerViewModel.LName,
                        SizeId = runnerViewModel.SizeId,
                        GenderId = runnerViewModel.GenderId,
                        DOB = runnerViewModel.DOB,
                        Email = runnerViewModel.Email,
                        Phone = runnerViewModel.Phone,
                        WaiverAgreement = runnerViewModel.WaiverAgreement,

                    };

                    context.Runners.Add(runner);
                    context.SaveChanges();

                    var raceRunner = new RaceRunner
                    {
                        RaceId = runnerViewModel.RaceId,
                        RunnerId = runner.Id
                    };

                    context.RaceRunners.Add(raceRunner);
                    context.SaveChanges();

                    TempData["Message"] = runner.FName + " " + runner.LName + " was successfully registered!";
                };

                return RedirectToAction("Index", "Home");
            }
            ViewBag.SelectRace = new SelectList(_context.Races, "Id", "Name");
            ViewBag.SelectGender = new SelectList(_context.Gender, "Id", "Name");
            ViewBag.SelectSize = new SelectList(_context.Sizes, "Id", "Name");
            return View("SignupEdit", runnerViewModel);
        }
    }
}