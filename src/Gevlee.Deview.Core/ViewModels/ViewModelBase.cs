using ReactiveUI;

namespace Gevlee.Deview.Core.ViewModels
{
    public class ViewModelBase : ReactiveObject, IViewModel, IActivatableViewModel
    {
        public virtual ViewModelActivator Activator { get; protected set; } = new ViewModelActivator();
    }
}
