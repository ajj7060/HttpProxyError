using System;
using Csla.DataPortalClient;

namespace Business.DataPortalProxy {
	public sealed class IncreasedTimeoutHttpProxy : HttpProxy {
		public IncreasedTimeoutHttpProxy(Uri dataPortalUri) {
			DataPortalUrl = dataPortalUri?.ToString() ?? throw new ArgumentNullException(nameof(dataPortalUri));
			Timeout = Convert.ToInt32(TimeSpan.FromMinutes(1).TotalMilliseconds);
		}
	}
}
