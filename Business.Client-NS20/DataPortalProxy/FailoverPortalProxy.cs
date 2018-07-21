using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csla.DataPortalClient;
using Csla.Server;

namespace Business.DataPortalProxy {
	public sealed class FailoverPortalProxy : IDataPortalProxy {
		private readonly IReadOnlyList<IDataPortalProxy> proxies;

		public FailoverPortalProxy(IEnumerable<IDataPortalProxy> proxies) {
			this.proxies = proxies?.ToList() ?? throw new ArgumentNullException(nameof(proxies));
			if (!this.proxies.Any()) { throw new ArgumentException("need at least one proxy", nameof(proxies)); }
		}

		public async Task<DataPortalResult> Create(Type objectType, object criteria, DataPortalContext context, bool isSync) {
			DataPortalResult result = null;

			for (var i = 0; i < proxies.Count; i += 1) {
				try {
					result = await proxies[i].Create(objectType, criteria, context, isSync);
					break;
				}
				catch { }
			}

			return result ?? throw new Exception("All proxies failed");
		}

		public async Task<DataPortalResult> Fetch(Type objectType, object criteria, DataPortalContext context, bool isSync) {
			DataPortalResult result = null;

			for (var i = 0; i < proxies.Count; i += 1) {
				try {
					result = await proxies[i].Fetch(objectType, criteria, context, isSync);
					break;
				}
				catch (Exception ex) when (ex.Message ==
					"This instance has already started one or more requests. Properties can only be modified before sending the first request."
				) {
					System.Diagnostics.Debugger.Break();
				}
				catch { }
			}

			return result ?? throw new Exception("All proxies failed");
		}

		public async Task<DataPortalResult> Update(object obj, DataPortalContext context, bool isSync) {
			DataPortalResult result = null;

			for (var i = 0; i < proxies.Count; i += 1) {
				try {
					result = await proxies[i].Update(obj, context, isSync);
					break;
				}
				catch { }
			}

			return result ?? throw new Exception("All proxies failed");
		}

		public async Task<DataPortalResult> Delete(Type objectType, object criteria, DataPortalContext context, bool isSync) {
			DataPortalResult result = null;

			for (var i = 0; i < proxies.Count; i += 1) {
				try {
					result = await proxies[i].Delete(objectType, criteria, context, isSync);
					break;
				}
				catch { }
			}

			return result ?? throw new Exception("All proxies failed");
		}

		public bool IsServerRemote { get; } = true;
	}
}