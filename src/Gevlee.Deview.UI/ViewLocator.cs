using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Gevlee.Deview.Core.ViewModels;
using ReactiveUI;
using Splat;

namespace Gevlee.Deview.UI
{
    public class ViewLocator : IDataTemplate
    {
        public bool SupportsRecycling => false;

        public IControl Build(object data)
        {
            var dataType = data.GetType();

            var type = GetType().Assembly.DefinedTypes
                .FirstOrDefault(x => 
                    typeof(IViewFor<>)
                    .MakeGenericType(dataType)
                    .IsAssignableFrom(x));

            if (type != null)
            {
                var resolved = Locator.Current.GetService(type);
                return (Control)resolved;
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + dataType.Name };
            }
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}