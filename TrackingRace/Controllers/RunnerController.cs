﻿using System;
using System.Collections.Generic;
using System.Configuration;
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
            ViewBag.Title = "Work With Runners";

            using (var context = new Context())
            {
                var runnerList = new RunnerListViewModel
                {
                    Runners = context.Runners.Select(p => new RunnerViewModel
                    {
                        Id = p.Id,
                        FName = p.FName,
                        LName = p.LName,
                        Size = p.Size,
                        Gender = p.Gender,
                        DOB = p.DOB,
                        Email = p.Email,
                        Phone = p.Phone,
                        WaiverAgreement = p.WaiverAgreement


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
                //Adding Race to RunnerViewModel
                runnerViewModel.RaceId = raceId.Value;
                var race = _context.Races.SingleOrDefault(r => r.Id == raceId);
                runnerViewModel.RaceName = race.Name;
                ViewBag.Race = race;
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
                runnerViewModel.Gender = _context.Gender.SingleOrDefault(g => g.Id == runnerViewModel.GenderId);
                runnerViewModel.Size = _context.Sizes.SingleOrDefault(s => s.Id == runnerViewModel.SizeId);
                ViewBag.RaceName = race.Name;
                return View("CheckOut", runnerViewModel);
            }
            return View("SignupEdit", runnerViewModel);
        }

        
        public ActionResult ReviewInfo(RunnerViewModel runnerViewModel)
        {
            ViewBag.SelectRace = new SelectList(_context.Races, "Id", "Name");
            ViewBag.SelectGender = new SelectList(_context.Gender, "Id", "Name");
            ViewBag.SelectSize = new SelectList(_context.Sizes, "Id", "Name");
            return View("SignupEdit", runnerViewModel);
        }

        //Saving User
        [HttpPost]
        public ActionResult SheckOut(RunnerViewModel runnerViewModel)
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
    }
}