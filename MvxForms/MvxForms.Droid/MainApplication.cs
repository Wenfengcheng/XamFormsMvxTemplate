// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using MvvmCross;
using MvvmCross.Logging;
using System;
using System.Threading.Tasks;

namespace MvxForms.Droid
{
    //You can specify additional application information in this attribute
#if DEBUG
    [Application(Debuggable = true)]
#else
    [Application(Debuggable = false)]
#endif
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            RegisterActivityLifecycleCallbacks(this);
            //A great place to initialize Xamarin.Insights and Dependency Services!

            AndroidEnvironment.UnhandledExceptionRaiser += HandleUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        }

        private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs args)
        {
            var mvxLogProvider = Mvx.IoCProvider.Resolve<IMvxLogProvider>();
            var mvxLog = mvxLogProvider.GetLogFor(GetType());
            mvxLog.TraceException(args.Exception.Message, args.Exception);
        }

        private void HandleUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var mvxLogProvider = Mvx.IoCProvider.Resolve<IMvxLogProvider>();
            var mvxLog = mvxLogProvider.GetLogFor(GetType());
            var exception = args.ExceptionObject as Exception;
            mvxLog.TraceException(args.ToString(), exception);
        }

        private void HandleUnhandledException(object sender, RaiseThrowableEventArgs args)
        {
            var mvxLogProvider = Mvx.IoCProvider.Resolve<IMvxLogProvider>();
            var mvxLog = mvxLogProvider.GetLogFor(GetType());
            mvxLog.TraceException(args.Exception.Message, args.Exception);
        }

        public override void OnLowMemory()
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);

            base.OnLowMemory();
        }

        public override void OnTrimMemory([GeneratedEnum] TrimMemory level)
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);

            base.OnTrimMemory(level);
        }

        public override void OnTerminate()
        {
            base.OnTerminate();

            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {

        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {

        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {

        }

        public void OnActivityStarted(Activity activity)
        {

        }

        public void OnActivityStopped(Activity activity)
        {

        }
    }
}