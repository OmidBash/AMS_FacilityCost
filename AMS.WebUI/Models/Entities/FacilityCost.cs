using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;


namespace AMS.WebUI.Models
{
    public partial class FacilityCost
    {
        #region Properties

        public Guid Id { get; set; }

        [Required(ErrorMessage = "لطفا عنوان را وارد نمایید")]
        [DisplayName("عنوان")]
        public string Title { get; set; }

        [DisplayName("نحوه استفاده")]
        [EnumDataType(typeof(KindOfUsage))]
        public KindOfUsage KindOfUsage { get; set; }

        [DisplayName("نحوه محاسبه")]
        [EnumDataType(typeof(CalculationType))]
        public CalculationType CalculationType { get; set; }

        [Required(ErrorMessage = "لطفا درصد واحدهای خالی را وارد نمایید")]
        [DisplayName("سهم واحدهای خالی")]
        [Range(0, 100, ErrorMessage = "درصد وارد نمایید")]
        public decimal EmptyUnitShare { get; set; }

        [DisplayName("آیا در آمد است؟")]
        [EnumDataType(typeof(CostIncomeType))]
        public CostIncomeType CostIncomeType { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }

        #region Relations

        public ICollection<UnitFacilityCost> UnitFacilityCosts { get; set; }

        #endregion

        #endregion
    }
}
