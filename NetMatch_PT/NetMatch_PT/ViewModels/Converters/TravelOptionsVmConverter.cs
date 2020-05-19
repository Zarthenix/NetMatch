using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.ViewModels.Converters
{
    public class TravelOptionsVmConverter
    {
        public TravelOptions ViewModelToModel(TravelOptionsVm vm)
        {
            return new TravelOptions(vm.AccommodationId, vm.Date, vm.Adults, vm.Children, vm.Rooms);
        }

        public TravelOptionsVm ModelTViewoModel(TravelOptions to)
        {
            return new TravelOptionsVm()
            {
                AccommodationId = to.AccommodationId,
                Rooms = to.Rooms,
                TravelPartners = to.TravelPartners,
                Date = to.Date,
                Children = to.Children,
                Adults = to.Adults
            };
        }
    }
}
