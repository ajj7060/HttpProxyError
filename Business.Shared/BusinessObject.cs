using System;
using System.Threading.Tasks;
using Csla;

namespace Business {
	[Serializable]
	public sealed class BusinessObject : ReadOnlyBase<BusinessObject> {
		public static readonly PropertyInfo<string> SomeValueProperty = RegisterProperty<string>(x => x.SomeValue);

		public string SomeValue {
			get => GetProperty(SomeValueProperty);
			private set => LoadProperty(SomeValueProperty, value);
		}

		public static Task<BusinessObject> GetAsync() => DataPortal.FetchAsync<BusinessObject>();

		#if SERVER_CODE

		private void DataPortal_Fetch() => SomeValue = "From the server";

		#endif
	}
}