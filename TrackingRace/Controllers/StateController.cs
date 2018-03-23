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
    public class StateController : Controller
    {
        private Context _context = null;

        public StateController()
        {
            _context = new Context();
        }

        // GET: State
        public ActionResult Index()
        {
            using (var context = new Context())
            {
                var stateList = new StateListViewModel
                {
                    //Convert each State to a StateViewModel
                    States = context.States.Select(p => new StateViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Acronym = p.Acronym
                    }).ToList()
                };
                stateList.TotalStates = stateList.States.Count;
                ViewBag.Title = "Work With States";
                return View(stateList);
            }
        }

        //Detail
        public ActionResult Detail(int id)
        {
            using (var context = new Context())
            {
                var state = context.States.SingleOrDefault(p => p.Id == id);
                if (state != null)
                {
                    var stateViewModel = new StateViewModel
                    {
                        Id = state.Id,
                        Name = state.Name,
                        Acronym = state.Acronym
                    };
                    ViewBag.Title = "Detail " + stateViewModel.Name;
                    return View(stateViewModel);
                }
            }
            return new HttpNotFoundResult();
        }

        //Add
        public ActionResult Add()
        {
            ViewBag.Title = "Add State";
            var stateViewModel = new StateViewModel();

            return View("AddEdit", stateViewModel);
        }

        [HttpPost]
        public ActionResult Add(StateViewModel stateViewModel)
        {
            //ValdateState(stateViewModel);

            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    var state = new State
                    {
                        Name = stateViewModel.Name,
                        Acronym = stateViewModel.Acronym
                    };

                    context.States.Add(state);
                    context.SaveChanges();
                }

                TempData["Message"] = "Your state was successfully added!";
                return RedirectToAction("Index");
            }

            return View(stateViewModel);
        }

        //Edit
        public ActionResult Edit(int id)
        {
            using (var context = new Context())
            {
                var state = context.States.SingleOrDefault(p => p.Id == id);
                if (state != null)
                {
                    var stateViewModel = new StateViewModel
                    {
                        Id = state.Id,
                        Name = state.Name,
                        Acronym = state.Acronym
                    };
                    return View("AddEdit", stateViewModel);
                }
            }
            return new HttpNotFoundResult();
        }

        [HttpPost]
        public ActionResult Edit(StateViewModel stateViewModel)
        {
            //ValdateState(stateViewModel);

            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    var state = context.States.SingleOrDefault(p => p.Id == stateViewModel.Id);

                    if(state != null)
                    {
                        state.Name = stateViewModel.Name;
                        state.Acronym = stateViewModel.Acronym;

                        TempData["Message"] = "Your state was successfully updated!";
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    };
                } 
            }
            return View(stateViewModel);
        }


        //Delete
        [HttpPost]
        public ActionResult Delete(StateViewModel stateViewModel)
        {
            using (var context = new Context())
            {
                var state = context.States.SingleOrDefault(p => p.Id == stateViewModel.Id);
                if (state != null)
                {
                    TempData["Message"] = state.Name + " state was successfully deleted!";
                    context.States.Remove(state);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return new HttpNotFoundResult();
        }
        

        //private void ValdateState(StateViewModel stateViewModel)
        //{
        //    if (ModelState.IsValidField("Name"))
        //    {
        //        ModelState.AddModelError("Name", "The Name field cannot be empty");
        //    }

        //    if (ModelState.IsValidField("Acronym"))
        //    {
        //        ModelState.AddModelError("Acronym", "The Acronym field cannot be empty");
        //    }
        //}





        //private bool _disposed = false;

        //protected override void Dispose(bool disposing)
        //{
        //    if (_disposed)
        //        return;

        //    if (disposing)
        //    {
        //        _context.Dispose();
        //    }

        //    _disposed = true;

        //    base.Dispose(disposing);
        //}
    }
}