using System.Threading.Tasks;
using Service.Education.Contracts;
using Service.Education.Contracts.Task;
using Service.Education.Structure;
using Service.TutorialTime.Helper;
using static Service.Education.Helpers.AnswerHelper;

namespace Service.TutorialTime.Services
{
	public partial class TutorialTimeService
	{
		private static readonly EducationStructureUnit Unit3 = TutorialHelper.StructureTutorial.Units[3];

		public async ValueTask<TestScoreGrpcResponse> Unit3TextAsync(TaskTextGrpcRequest request) =>
			await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit3, Unit3.Tasks[1], request.IsRetry, request.Duration);

		public async ValueTask<TestScoreGrpcResponse> Unit3TestAsync(TaskTestGrpcRequest request)
		{
			ITaskTestAnswer[] answers = request.Answers;

			int progress = CheckAnswer(20, answers, 1, 3)
				+ CheckAnswer(20, answers, 2, 3)
				+ CheckAnswer(20, answers, 3, 1)
				+ CheckAnswer(20, answers, 4, 2)
				+ CheckAnswer(20, answers, 5, 1, 3);

			return await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit3, Unit3.Tasks[2], request.IsRetry, request.Duration, progress);
		}

		public async ValueTask<TestScoreGrpcResponse> Unit3VideoAsync(TaskVideoGrpcRequest request) =>
			await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit3, Unit3.Tasks[3], request.IsRetry, request.Duration);

		public async ValueTask<TestScoreGrpcResponse> Unit3CaseAsync(TaskCaseGrpcRequest request) =>
			await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit3, Unit3.Tasks[4], request.IsRetry, request.Duration, CountProgress(request.Value == 1));

		public async ValueTask<TestScoreGrpcResponse> Unit3TrueFalseAsync(TaskTrueFalseGrpcRequest request)
		{
			ITaskTrueFalseAnswer[] answers = request.Answers;

			int progress = CheckAnswer(20, answers, 1, true)
				+ CheckAnswer(20, answers, 2, false)
				+ CheckAnswer(20, answers, 3, true)
				+ CheckAnswer(20, answers, 4, false)
				+ CheckAnswer(20, answers, 5, true);

			return await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit3, Unit3.Tasks[5], request.IsRetry, request.Duration, progress);
		}

		public async ValueTask<TestScoreGrpcResponse> Unit3GameAsync(TaskGameGrpcRequest request) =>
			await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit3, Unit3.Tasks[6], request.IsRetry, request.Duration);
	}
}
