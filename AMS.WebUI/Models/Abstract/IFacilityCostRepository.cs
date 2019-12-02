using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Models;

namespace AMS.WebUI.Models
{
    public interface IFacilityCostRepository
    {
        FacilityCost GetFacilityCost(Guid id);
        PagedList<FacilityCost> GetFilteredFacilityCosts(QueryOptions options);
        FacilityCost AddFacilityCost(FacilityCost facilityCost);
        FacilityCost UpdateFacilityCost(FacilityCost facilityCost);
        void Delete(Guid id);
    }
}
