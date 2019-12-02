using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AMS.WebUI.Models
{
    public partial class Unit
    {
        #region Propesties
        public Guid Id { get; set; }
        [DisplayName("واحد")]
        public string Name { get; set; }

        #region Relations
        public ICollection<UnitFacilityCost> UnitFacilityCosts { get; set; }
        #endregion

        #endregion

    }
}
