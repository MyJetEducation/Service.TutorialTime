using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Service.Grpc;
using Service.TutorialTime.Grpc;

namespace Service.TutorialTime.Client
{
	[UsedImplicitly]
	public class TutorialTimeClientFactory : GrpcClientFactory
	{
		public TutorialTimeClientFactory(string grpcServiceUrl, ILogger logger) : base(grpcServiceUrl, logger)
		{
		}

		public IGrpcServiceProxy<ITutorialTimeService> GetTutorialTimeService() => CreateGrpcService<ITutorialTimeService>();
	}
}