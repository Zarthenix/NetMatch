using NetMatch_PT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.ViewModels.Converters
{
    public class TravelDetailVmConverter
    {
        public TravelDetailVm ConvertToViewModel(Travel tr)
        {
            return new TravelDetailVm()
            {
                Id = tr.Id,
                ReisagentID = tr.ReisagentID,
                CustomerID = tr.CustomerID,
                AccomodationID = tr.AccomodationID,
                Price = tr.Price,
                Discount = tr.Discount,
                DepartureDate = tr.DepartureDate,
                Transport = tr.Transport
            };
        }
    }
}
