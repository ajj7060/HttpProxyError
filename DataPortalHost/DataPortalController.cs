using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataPortalHost {
	public sealed class DataPortalController : Csla.Server.Hosts.HttpPortalController {
		public override Task<HttpResponseMessage> PostAsync(string operation) {
			Console.WriteLine($"{operation}");
			return base.PostAsync(operation);
		}
	}
}