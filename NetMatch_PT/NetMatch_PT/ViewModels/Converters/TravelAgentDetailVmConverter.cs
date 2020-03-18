using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;

namespace NetMatch_PT.ViewModels.Converters
{
    public class TravelAgentDetailVmConverter : IViewModelConverter<TravelAgent, TravelAgentDetailVm>
    {
        public List<TravelAgentDetailVm> ModelsToViewModels(List<TravelAgent> models)
        {
            throw new NotImplementedException();
        }

        public TravelAgentDetailVm ModelToViewModel(TravelAgent ta)
        {
            TravelAgentDetailVm vm = new TravelAgentDetailVm(ta.Id)
            {
                Email = ta.Email,
                Password = ta.Password
            };
            return vm;
        }

        public List<TravelAgent> ViewModelsToModels(List<TravelAgentDetailVm> viewModels)
        {
            throw new NotImplementedException();
        }

        public TravelAgent ViewModelToModel(TravelAgentDetailVm vm)
        {
            TravelAgent ta = new TravelAgent(vm.Id)
            {
                Email = vm.Email,
                Password = vm.Password
            };
            return ta;
        }
    }
}
