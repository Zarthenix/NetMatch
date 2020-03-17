using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Contexts.Interfaces
{
    public interface IViewModelConverter<TModel, TViewModel>
    {
        TViewModel ModelToViewModel(TModel model);
        TModel ViewModelToModel(TViewModel viewModel);

        List<TViewModel> ModelsToViewModels(List<TModel> models);
        List<TModel> ViewModelsToModels(List<TViewModel> viewModels);
    }
}
