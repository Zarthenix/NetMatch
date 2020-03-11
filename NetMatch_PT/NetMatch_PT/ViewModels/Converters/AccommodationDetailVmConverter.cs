using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models;

namespace NetMatch_PT.ViewModels.Converters
{
    public class AccommodationDetailVmConverter
    {
        public AccommodationDetailVm ConvertToViewModel(Accommodation ac)
        {
            return new AccommodationDetailVm()
            {
                Id = ac.Id,
                Title = ac.Title,
                Description = ac.Description,
                Date = ac.Date,
                Price = ac.Price,
                Image = Convert.ToBase64String(ac.Image)
            };
        }
    }
}
