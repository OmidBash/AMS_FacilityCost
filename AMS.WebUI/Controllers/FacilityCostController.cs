using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace AMS.WebUI.Controllers
{
    public class FacilityCostController : Controller
    {
        private IFacilityCostRepository facilityCostRepository;

        public FacilityCostController(IFacilityCostRepository facilityCostRepo)
        {
            facilityCostRepository = facilityCostRepo;
        }

        public ViewResult Index(QueryOptions options = null) =>
            View(facilityCostRepository.GetFilteredFacilityCosts(options));

        [HttpPost]
        public IActionResult Create([FromForm] FacilityCost facilityCost)
        {
            if (ModelState.IsValid)
            {
                facilityCostRepository.AddFacilityCost(facilityCost);
            }
            else
            {
                ViewBag.CreatedFacilityCost = facilityCost;
            }
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(Guid? id)
        {
            FacilityCost facilityCost;

            if(id.HasValue && (facilityCost = facilityCostRepository.GetFacilityCost(id.Value))!=null)
            {
                return View(facilityCost);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Update([FromForm] FacilityCost facilityCost)
        {
            if (facilityCost.UnitFacilityCosts.Sum(ufc => ufc.Share) != 100)
            {
                ModelState.AddModelError("", "مجموع سهم واحد ها صد در صد نمی شود");
            }

            if (ModelState.IsValid)
            {
                facilityCostRepository.UpdateFacilityCost(facilityCost);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(facilityCost);
            }
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            facilityCostRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}