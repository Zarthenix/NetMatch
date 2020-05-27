using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NetMatch_PT.Models;
using NetMatch_PT.Models.Enums;

namespace NetMatch_PT.ViewModels
{
    public class SearchVm
    {
    #nullable enable
        public string? Search { get; set; }

        [Display(Name="Land")]
      public Countries? Country { get; set; }
        [Display(Name = "Reistype")]
        public TravelTypes? TravelType { get; set; }
        [Display(Name = "Maand")]
        public Months? Month { get; set; }

    }
}
