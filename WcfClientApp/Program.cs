using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using WcfService;

namespace WcfClientApp
{
	public class Program
	{
		public static void Main()
		{
			var channelFactory = new ChannelFactory<IWcfService>(BindingCreator.GetBinding());

			var channel = channelFactory.CreateChannel(new EndpointAddress(BindingCreator.GetAddress().AbsoluteUri + "/Test"));

			// ReSharper disable once SuspiciousTypeConversion.Global
			using ((IDisposable) channel)
			{
				while (true)
				{
					var task1 = Task.Run(async () => await DoStuffAsync(channel));
					var task2 = Task.Run(async () => await DoStuffAsync(channel));
					var task3 = Task.Run(async () => await DoStuffAsync(channel));
					var task4 = Task.Run(async () => await DoStuffAsync(channel));
					var task5 = Task.Run(async () => await DoStuffAsync(channel));

					Task.WaitAll(task1, task2, task3, task4, task5);
				}
			}

			// ReSharper disable once FunctionNeverReturns
		}

		public static async Task DoStuffAsync(IWcfService channel)
		{
			Console.WriteLine($"Start with thread: {Thread.CurrentThread.ManagedThreadId}");

			await channel.DoSomethingAsync();

			Console.WriteLine($"After WCF execution: {Thread.CurrentThread.ManagedThreadId}");

			Thread.Sleep(1000);
		}
	}
}
