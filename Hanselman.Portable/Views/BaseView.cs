using Hanselman.Portable.Views;
using Xamarin.Forms;

namespace Hanselman.Portable
{
    public class BaseView : ContentPageBase
    {
        public BaseView()
        {
            SetBinding(Page.TitleProperty, new Binding(BaseViewModel.TitlePropertyName));
            SetBinding(Page.IconProperty, new Binding(BaseViewModel.IconPropertyName));
        }
    }
}

