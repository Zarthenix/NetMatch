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
            TravelOptions to = new TravelOptions(vm.AccommodationId, vm.SelectDate, vm.Children, vm.Rooms);
            to.TravelPartners = to.Adults + to.Children;
            return to;
        }

        public TravelOptionsVm ModelTViewoModel(TravelOptions to)
        {
            return new TravelOptionsVm(to.AccommodationId, to.Children, to.Rooms, to.Date);
        }
    }
}
