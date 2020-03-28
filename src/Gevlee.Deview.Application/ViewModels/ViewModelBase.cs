using ReactiveUI;

namespace Gevlee.Deview.Application.ViewModels
{
    public class ViewModelBase : ReactiveObject, IViewModel, IActivatableViewModel
    {
        public virtual ViewModelActivator Activator { get; protected set; } = new ViewModelActivator();
    }
}
