using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NetMatch_PT.Models;
using NetMatch_PT.Models.Enums;

namespace NetMatch_PT.ViewModels
{
    public class SortSearchVm : SearchVm
    {
      //reistype (zomer/winter), land, vertrekmaand 

      public Countries? Country { get; set; }

      public TravelTypes? TravelType { get; set; }

      public Months? Month { get; set; }

    }
}
