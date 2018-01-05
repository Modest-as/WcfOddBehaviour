using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfService
{
	[ServiceContract]
	public interface IWcfService
	{
		[OperationContract]
		Task DoSomethingAsync();
	}

	[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
	public class WcfServiceImpl : IWcfService
	{
		public async Task DoSomethingAsync()
		{
			await Task.Delay(1000);
		}
	}
}
