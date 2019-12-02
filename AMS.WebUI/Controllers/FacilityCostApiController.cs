using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.WebUI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WebUI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FacilityCostApiController : Controller
    {
        private IFacilityCostRepository facilityCostRepository;

        public FacilityCostApiController(IFacilityCostRepository facilityCostRepo)
        {
            facilityCostRepository = facilityCostRepo;
        }

        [Route("~/api/GetFilteredFacilityCost")]
        [HttpGet]
        public PagedList<FacilityCost> Get([FromBody] QueryOptions options) => facilityCostRepository.GetFilteredFacilityCosts(options);

        [Route("~/api/GetFacilityCost/{id}")]
        [HttpGet]
        public FacilityCost Get(Guid id) => facilityCostRepository.GetFacilityCost(id);

        [Route("~/api/AddFacilityCost")]
        [HttpPost]
        public FacilityCost Post([FromBody] FacilityCost fc) =>
            facilityCostRepository.AddFacilityCost(new FacilityCost
            {
                Title = fc.Title,
                Description = fc.Description,
                KindOfUsage = fc.KindOfUsage,
                CalculationType = fc.CalculationType,
                CostIncomeType = fc.CostIncomeType,
                EmptyUnitShare = fc.EmptyUnitShare
            });

        [Route("~/api/UpdateFacilityCost")]
        [HttpPut]
        public FacilityCost Put([FromBody] FacilityCost fc) => facilityCostRepository.UpdateFacilityCost(fc);

        [HttpPatch("{id}")]
        public StatusCodeResult Patch(Guid id, [FromBody] JsonPatchDocument<FacilityCost> patch)
        {
            FacilityCost res = Get(id);
            if (res != null)
            {
                patch.ApplyTo(res);
                return Ok();
            }

            return NotFound();
        }

        [Route("~/api/DeleteFacilityCost/{id}")]
        [HttpDelete]
        public void Delete(Guid id) => facilityCostRepository.Delete(id);
    }
}