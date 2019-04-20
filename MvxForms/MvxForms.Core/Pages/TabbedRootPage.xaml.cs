// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using System;

namespace MvxForms.Core.Pages
{
    [MvxMasterDetailPagePresentation(NoHistory = true)]
    public partial class TabbedRootPage : MvxTabbedPage
    {
        public TabbedRootPage()
        {
            InitializeComponent();
        }
    }
}