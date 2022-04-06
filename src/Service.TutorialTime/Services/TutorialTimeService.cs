using System;
using System.Threading.Tasks;
using Service.TutorialTime.Grpc;
using Service.TutorialTime.Grpc.Models.State;
using Service.TutorialTime.Mappers;
using Service.TutorialTime.Models;
using Service.UserReward.Grpc;
using Service.UserReward.Grpc.Models;

namespace Service.TutorialTime.Services
{
	public partial class TutorialTimeService : ITutorialTimeService
	{
		private readonly ITaskProgressService _taskProgressService;
		private readonly IUserRewardService _userRewardService;

		public TutorialTimeService(ITaskProgressService taskProgressService, IUserRewardService userRewardService)
		{
			_taskProgressService = taskProgressService;
			_userRewardService = userRewardService;
		}

		public async ValueTask<FinishStateGrpcResponse> GetFinishStateAsync(GetFinishStateGrpcRequest request)
		{
			string userId = request.UserId;
			int? unit = request.Unit;

			TaskTypeProgressInfo typeProgressInfo = await _taskProgressService.GetTotalProgressAsync(userId, unit);

			UserAchievementsGrpcResponse achievements = await _userRewardService.GetUserNewAchievementsAsync(new GetUserAchievementsGrpcRequest
			{
				UserId = userId,
				Unit = unit
			});

			return typeProgressInfo.ToGrpcModel(achievements?.Items);
		}
	}
}
