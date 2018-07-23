using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HttpProxyError {
	public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
		}

		protected override async void OnAppearing() {
			base.OnAppearing();

			var obj = await Business.BusinessObject.GetAsync();
			ResultLabel.Text = obj.SomeValue;

			// Repeat call to demonstrate bug
			obj = await Business.BusinessObject.GetAsync();
			ResultLabel.Text = obj.SomeValue;

		}
	}
}