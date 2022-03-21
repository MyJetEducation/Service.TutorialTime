using System.Runtime.Serialization;
using Service.TutorialTime.Grpc.Models.State;

namespace Service.TutorialTime.Grpc.Models.Task
{
	[DataContract]
	public class TestScoreGrpcResponse
	{
		[DataMember(Order = 1)]
		public bool IsSuccess { get; set; }

		[DataMember(Order = 2)]
		public StateGrpcModel Unit { get; set; }
	}
}
