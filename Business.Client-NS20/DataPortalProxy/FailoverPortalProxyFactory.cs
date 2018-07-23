using System;
using Csla.DataPortalClient;

namespace Business.DataPortalProxy {
	public sealed class FailoverPortalProxyFactory : IDataPortalProxyFactory {
		public IDataPortalProxy Create(Type objectType) =>
			new FailoverPortalProxy(new[] { 
				//new IncreasedTimeoutHttpProxy(new Uri("http://localhost:62077/api/notthere")),
				new IncreasedTimeoutHttpProxy(new Uri("http://localhost:62077/api/DataPortal"))
		});

		public void ResetProxyType() { }
	}
}