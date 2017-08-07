// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using MvvmCross.Uwp.Views;
using MvxForms.Core.ViewModels;

namespace MvxForms.UWP.Views
{
    public sealed partial class NativePage : MvxWindowsPage
    {
        public NativePage()
        {
            this.InitializeComponent();
        }

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ((NativeViewModel)ViewModel).BackCommand.Execute();
        }
    }
}