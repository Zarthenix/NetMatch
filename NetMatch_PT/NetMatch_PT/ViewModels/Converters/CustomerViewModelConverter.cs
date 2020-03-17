using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;

namespace NetMatch_PT.ViewModels.Converters
{
    public class CustomerViewModelConverter : IViewModelConverter<Customer, CustomerDetailVm>
    {
        public List<CustomerDetailVm> ModelsToViewModels(List<Customer> models)
        {
            throw new NotImplementedException();
        }

        public CustomerDetailVm ModelToViewModel(Customer c)
        {
            CustomerDetailVm vm = new CustomerDetailVm(c.Id)
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address,
                Woonplaats = c.Woonplaats,
                Postcode = c.Postcode,
                Email = c.Email,
                Geboortedatum = c.Geboortedatum,
                Telefoonnummer = c.Telefoonnummer

            };
            return vm;
        }

        public List<Customer> ViewModelsToModels(List<CustomerDetailVm> viewModels)
        {
            throw new NotImplementedException();
        }

        public Customer ViewModelToModel(CustomerDetailVm vm)
        {
            Customer c = new Customer(vm.Id)
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Address = vm.Address,
                Woonplaats = vm.Woonplaats,
                Postcode = vm.Postcode,
                Email = vm.Email,
                Geboortedatum = vm.Geboortedatum,
                Telefoonnummer = vm.Telefoonnummer
            };
            return c;
        }
    }
}
