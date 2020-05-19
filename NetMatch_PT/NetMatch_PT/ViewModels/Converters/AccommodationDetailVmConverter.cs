using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;

namespace NetMatch_PT.ViewModels.Converters
{
    public class AccommodationDetailVmConverter : IViewModelConverter<Accommodation, AccommodationDetailVm>
    {
        public AccommodationDetailVm ModelToViewModel(Accommodation model)
        {
            return new AccommodationDetailVm()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Image = Convert.ToBase64String(model.Image),
                Traveltype = model.Traveltype,
                Country = model.Country,
                DatePrices = model.DatePrices
            };
        }

        public Accommodation ViewModelToModel(AccommodationDetailVm viewModel)
        {
            return null;
        }

        public List<AccommodationDetailVm> ModelsToViewModels(List<Accommodation> models)
        {
            List<AccommodationDetailVm> result = new List<AccommodationDetailVm>();

            foreach(Accommodation a in models)
            {
                result.Add(ModelToViewModel(a));
            }
            return result;
        }

        public List<Accommodation> ViewModelsToModels(List<AccommodationDetailVm> viewModels)
        {
            return null;
        }
    }
}
