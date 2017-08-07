// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Core;
using MvvmCross.Forms.Uwp;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvxForms.Core.ViewModels;
using MvxForms.UWP.Views;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using XamlControls = Windows.UI.Xaml.Controls;
using MvvmCross.Uwp.Views;
using MvvmCross.Forms.Uwp.Presenters;
using Xamarin.Forms;

namespace MvxForms.UWP
{
    public class Setup : MvxFormsWindowsSetup
    {
        private readonly LaunchActivatedEventArgs _launchActivatedEventArgs;

        public Setup(XamlControls.Frame rootFrame, LaunchActivatedEventArgs e) : base(rootFrame, e)
        {
            _launchActivatedEventArgs = e;
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.RegisterSingleton<Core.Services.ILocalizeService>(new Services.LocalizeService());
            Mvx.RegisterSingleton<ISettings>(CrossSettings.Current);
        }

        protected override MvxFormsApplication CreateFormsApplication()
        {
            return new Core.FormsApp();
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.MvxApp();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new Core.DebugTrace();
        }

        protected override void InitializeViewLookup()
        {
            //base.InitializeViewLookup();

            var viewModelViewLookup = new Dictionary<Type, Type>()
            {
            { typeof(NativeViewModel), typeof(NativePage) },
            };

            var container = Mvx.Resolve<IMvxViewsContainer>();
            container.AddAll(viewModelViewLookup);
        }

        protected override IMvxWindowsViewPresenter CreateViewPresenter(IMvxWindowsFrame rootFrame)
        {
            Forms.Init(_launchActivatedEventArgs);

            var presenter = new MvxHybridFormsUwpPagePresenter(rootFrame, CreateFormsApplication());

            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);

            return presenter;
        }
    }

    public class MvxHybridFormsUwpPagePresenter : MvxFormsUwpPagePresenter
    {
        private readonly IMvxWindowsFrame _rootFrame;

        public MvxHybridFormsUwpPagePresenter(IMvxWindowsFrame rootFrame, MvxFormsApplication formsApplication) : base(rootFrame, formsApplication)
        {
            _rootFrame = rootFrame;
        }

        public override void ChangePresentation(MvxPresentationHint hint)
        {
            base.ChangePresentation(hint);
        }

        protected override void CustomPlatformInitialization(NavigationPage mainPage)
        {
            base.CustomPlatformInitialization(mainPage);
        }

        protected virtual string GetRequestText(MvxViewModelRequest request)
        {
            var requestTranslator = Mvx.Resolve<IMvxWindowsViewModelRequestTranslator>();
            string requestText = string.Empty;
            if (request is MvxViewModelInstanceRequest)
            {
                requestText = requestTranslator.GetRequestTextWithKeyFor(((MvxViewModelInstanceRequest)request).ViewModelInstance);
            }
            else
            {
                requestText = requestTranslator.GetRequestTextFor(request);
            }

            return requestText;
        }


        public override void Show(MvxViewModelRequest request)
        {
            if (request.ViewModelType.ToString() == "MvxForms.Core.ViewModels.NativeViewModel")
            {
                try
                {
                    var requestText = GetRequestText(request);
                    var viewsContainer = Mvx.Resolve<IMvxViewsContainer>();
                    var viewType = viewsContainer.GetViewType(request.ViewModelType);

                    _rootFrame.Navigate(viewType, requestText); //Frame won't allow serialization of it's nav-state if it gets a non-simple type as a nav param
                }
                catch (Exception exception)
                {
                    MvxTrace.Trace("Error seen during navigation request to {0} - error {1}", request.ViewModelType.Name,
                                   exception.ToString());
                }
            }
            else
                base.Show(request);
        }

        public override void Close(IMvxViewModel toClose)
        {
            if (toClose.ToString() == "MvxForms.Core.ViewModels.NativeViewModel")
            {
                var currentView = _rootFrame.Content as IMvxView;
                if (currentView == null)
                {
                    Mvx.Warning("Ignoring close for viewmodel - rootframe has no current page");
                    return;
                }

                if (currentView.ViewModel != toClose)
                {
                    Mvx.Warning("Ignoring close for viewmodel - rootframe's current page is not the view for the requested viewmodel");
                    return;
                }

                if (!_rootFrame.CanGoBack)
                {
                    Mvx.Warning("Ignoring close for viewmodel - rootframe refuses to go back");
                    return;
                }

                _rootFrame.GoBack();
            }
            else
                base.Close(toClose);
        }
    }
}