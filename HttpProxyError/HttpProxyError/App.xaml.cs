using System;
using Business.DataPortalProxy;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]

namespace HttpProxyError {
	public partial class App : Application {
		public App() {
			InitializeComponent();

			Csla.ApplicationContext.DataPortalProxyFactory = typeof(FailoverPortalProxyFactory).AssemblyQualifiedName;
			Csla.ApplicationContext.User = new Csla.Security.UnauthenticatedPrincipal();

			MainPage = new MainPage();
		}

		protected override void OnStart() {
			// Handle when your app starts
		}

		protected override void OnSleep() {
			// Handle when your app sleeps
		}

		protected override void OnResume() {
			// Handle when your app resumes
		}
	}
}
