using Autofac;
using Microsoft.Extensions.Logging;
using Service.Grpc;
using Service.TutorialTime.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.TutorialTime.Client
{
	public static class AutofacHelper
	{
		public static void RegisterTutorialTimeClient(this ContainerBuilder builder, string grpcServiceUrl, ILogger logger)
		{
			var factory = new TutorialTimeClientFactory(grpcServiceUrl, logger);

			builder.RegisterInstance(factory.GetTutorialTimeService()).As<IGrpcServiceProxy<ITutorialTimeService>>().SingleInstance();
		}
	}
}
