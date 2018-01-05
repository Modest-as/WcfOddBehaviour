using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace WcfService
{
	public class BindingCreator
	{
		public static Binding GetBinding()
		{
			var binding = new NetTcpBinding
			{
				MaxReceivedMessageSize = int.MaxValue,
				SendTimeout = TimeSpan.MaxValue,
				ReaderQuotas = new XmlDictionaryReaderQuotas
				{
					MaxDepth = int.MaxValue,
					MaxStringContentLength = int.MaxValue,
					MaxArrayLength = int.MaxValue,
					MaxBytesPerRead = int.MaxValue,
					MaxNameTableCharCount = int.MaxValue
				},
				ReceiveTimeout = TimeSpan.MaxValue,
				TransferMode = TransferMode.Buffered,
				OpenTimeout = TimeSpan.FromSeconds(15),
				ReliableSession =
				{
					Enabled = true,
					InactivityTimeout = TimeSpan.MaxValue,
					Ordered = false
				}
			};

			return binding;
		}

		public static Uri GetAddress()
		{
			return new Uri("net.tcp://localhost:80/Service");
		}
	}
}
