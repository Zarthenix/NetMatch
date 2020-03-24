using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models;
using NetMatch_PT.Contexts.Interfaces;

namespace NetMatch_PT.ViewModels.Converters
{
    public class TravelCompanyDetailVmConverter : IViewModelConverter<TravelCompany , TravelCompanyDetailVm>
    {
        public TravelCompanyDetailVm ModelToViewModel(TravelCompany tc)
        {
            TravelCompanyDetailVm vm = new TravelCompanyDetailVm(tc.Id)
            {
                FirstName = tc.FirstName,
                LastName = tc.LastName,
                BirthDate = tc.BirthDate
            };
            return vm;
        }

        public TravelCompany ViewModelToModel(TravelCompanyDetailVm vm)
        {
            TravelCompany tc = new TravelCompany(vm.Id)
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                BirthDate = vm.BirthDate
            };
            return tc;
        }

        public List<TravelCompanyDetailVm> ModelsToViewModels(List<TravelCompany> models)
        {
            throw new NotImplementedException();
        }

        public List<TravelCompany> ViewModelsToModels(List<TravelCompanyDetailVm> viewModels)
        {
            throw new NotImplementedException();
        }
    }
}
