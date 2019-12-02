using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using SportsStore.Models;

namespace AMS.WebUI.Models
{
    class FacilityCostRepository : IFacilityCostRepository
    {
        private ApplicationDbContext context;

        public FacilityCostRepository(ApplicationDbContext ctx) => context = ctx;

        public FacilityCost GetFacilityCost(Guid id) =>
            context.FacilityCosts
                .Include(fc => fc.UnitFacilityCosts)
                .ThenInclude(ufc => ufc.Unit)
                .First(fc => fc.Id == id);

        public PagedList<FacilityCost> GetFilteredFacilityCosts(QueryOptions options)
        {
            return new PagedList<FacilityCost>(context.FacilityCosts, options);
        }

        public FacilityCost AddFacilityCost(FacilityCost facilityCost)
        {
            facilityCost.UnitFacilityCosts = new List<UnitFacilityCost>();
            var units = context.Set<Unit>();
            int unitShared = 100 / units.Count();
            foreach (Unit unit in units)
            {
                facilityCost.UnitFacilityCosts.Add(new UnitFacilityCost
                {
                    IsApplicant = facilityCost.KindOfUsage == KindOfUsage.Always,
                    UsagePeriod =
                        $"شروع: {System.DateTime.Today.ToLocalTime().ToShortDateString()}" +
                        $", پابان: {System.DateTime.Today.AddDays(1).ToLocalTime().ToShortDateString()}",
                    OwnerPays = true,
                    UnitId = unit.Id,
                    Share = unitShared,
                    FacilityCostId = facilityCost.Id
                });
            }

            context.FacilityCosts.Add(facilityCost);
            context.SaveChanges();
            return facilityCost;
        }

        public FacilityCost UpdateFacilityCost(FacilityCost facilityCost)
        {
            //IEnumerable<UnitFacilityCost> unitFacilityCosts =
            //    context.Set<UnitFacilityCost>().Where(ufc => ufc.FacilityCostId == facilityCost.Id).ToArray();
            //if (unitFacilityCosts.Any())
            //{
            //    foreach (UnitFacilityCost reqUFC in facilityCost.UnitFacilityCosts)
            //    {
            //        var selected = unitFacilityCosts
            //            .FirstOrDefault(ufc => ufc.Id == reqUFC.Id);

            //        if (selected != null)
            //        {
            //            selected.Share = reqUFC.Share;
            //            selected.IsApplicant = reqUFC.IsApplicant;
            //            selected.OwnerPays = reqUFC.OwnerPays;
            //            selected.UsagePeriod = reqUFC.UsagePeriod;
            //        }
            //    }
            //}

            FacilityCost orgFacilityCost = GetFacilityCost(facilityCost.Id);
            foreach (UnitFacilityCost newUFS in facilityCost.UnitFacilityCosts)
            {
                var selected = orgFacilityCost.UnitFacilityCosts
                    .FirstOrDefault(ufc => ufc.Id == newUFS.Id);

                if (selected != null)
                {
                    selected.Share = newUFS.Share;
                    selected.IsApplicant = newUFS.IsApplicant;
                    selected.OwnerPays = newUFS.OwnerPays;
                    selected.UsagePeriod = newUFS.UsagePeriod;
                }
            }
            context.SaveChanges();
            return facilityCost;
        }

        public void Delete(Guid id)
        {
            context.FacilityCosts.Remove(new FacilityCost { Id = id });
            context.SaveChanges();
        }
    }
}
