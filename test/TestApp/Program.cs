using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Service.Grpc;
using Service.TutorialTime.Client;
using Service.TutorialTime.Grpc;
using GrpcClientFactory = ProtoBuf.Grpc.Client.GrpcClientFactory;

namespace TestApp
{
	public class Program
	{
		private static async Task Main(string[] args)
		{
			GrpcClientFactory.AllowUnencryptedHttp2 = true;
			ILogger<Program> logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<Program>();

			Console.Write("Press enter to start");
			Console.ReadLine();

			var factory = new TutorialTimeClientFactory("http://localhost:5001", logger);
			IGrpcServiceProxy<ITutorialTimeService> serviceProxy = factory.GetTutorialTimeService();
			ITutorialTimeService client = serviceProxy.Service;

			//var resp = await  client.SayHelloAsync(new HelloGrpcRequest(){Name = "Alex"});
			//Console.WriteLine(resp?.Message);

			Console.WriteLine("End");
			Console.ReadLine();
		}
	}
}