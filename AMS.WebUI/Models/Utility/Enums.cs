using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMS.WebUI.Models
{
    public enum KindOfUsage
    {
        [Display(Name = "همیشه")]
        Always,
        [Display(Name = "ماهانه")]
        Monthly,
        [Display(Name = "هفتگی")]
        Weekly
    }

    public enum CalculationType
    {
        [Display(Name = "درصد")]
        Percent,
        [Display(Name = "افراد")]
        People,
        [Display(Name = "مساحت")]
        Area
    }

    public enum CostIncomeType
    {
        [Display(Name = "بله")]
        Increase,
        [Display(Name = "خیر")]
        Decrease
    }
}
