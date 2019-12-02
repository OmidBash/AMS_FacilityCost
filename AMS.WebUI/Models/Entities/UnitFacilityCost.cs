using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AMS.WebUI.Models
{
    public partial class UnitFacilityCost
    {
        #region Properties
        public Guid Id { get; set; }

        [DisplayName("آیا متقاضی هزینه/درآمد آست؟")]
        public bool IsApplicant { get; set; }

        [DisplayName("زمان استفاده")]
        public string UsagePeriod { get; set; }

        [DisplayName("سهم")]
        [Range(0, 100, ErrorMessage = "درصد را درست وارد نمایید")]
        public int Share { get; set; }

        [DisplayName("مالک می پردازد/دریافت میکند؟")]
        public bool OwnerPays { get; set; }

        #region Relations

        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }
        public Guid FacilityCostId { get; set; }
        public FacilityCost FacilityCost { get; set; }
        #endregion

        #endregion

    }
}
