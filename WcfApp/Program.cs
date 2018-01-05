using System;
using System.ServiceModel;
using WcfService;

namespace WcfApp
{
	public class Program
	{
		public static void Main()
		{
			var selfHost = new ServiceHost(typeof(WcfServiceImpl), BindingCreator.GetAddress());

			try
			{
				selfHost.AddServiceEndpoint(typeof(IWcfService), BindingCreator.GetBinding(), "Test");

				selfHost.Open();

				Console.WriteLine("The service is ready.");
				Console.WriteLine("Press <ENTER> to terminate service.");
				Console.WriteLine();
				Console.ReadLine();

				selfHost.Close();
			}
			catch (CommunicationException ce)
			{
				Console.WriteLine("An exception occurred: {0}", ce.Message);
				selfHost.Abort();
			}
		}
	}
}
