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
		private static readonly EducationStructureUnit Unit4 = TutorialHelper.StructureTutorial.Units[4];

		public async ValueTask<TestScoreGrpcResponse> Unit4TextAsync(TaskTextGrpcRequest request) =>
			await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit4, Unit4.Tasks[1], request.IsRetry, request.Duration);

		public async ValueTask<TestScoreGrpcResponse> Unit4TestAsync(TaskTestGrpcRequest request)
		{
			ITaskTestAnswer[] answers = request.Answers;

			int progress = CheckAnswer(20, answers, 1, 1)
				+ CheckAnswer(20, answers, 2, 1)
				+ CheckAnswer(20, answers, 3, 1)
				+ CheckAnswer(20, answers, 4, 2)
				+ CheckAnswer(20, answers, 5, 1);

			return await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit4, Unit4.Tasks[2], request.IsRetry, request.Duration, progress);
		}

		public async ValueTask<TestScoreGrpcResponse> Unit4VideoAsync(TaskVideoGrpcRequest request) =>
			await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit4, Unit4.Tasks[3], request.IsRetry, request.Duration);

		public async ValueTask<TestScoreGrpcResponse> Unit4CaseAsync(TaskCaseGrpcRequest request) =>
			await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit4, Unit4.Tasks[4], request.IsRetry, request.Duration, CountProgress(request.Value == 1));

		public async ValueTask<TestScoreGrpcResponse> Unit4TrueFalseAsync(TaskTrueFalseGrpcRequest request)
		{
			ITaskTrueFalseAnswer[] answers = request.Answers;

			int progress = CheckAnswer(20, answers, 1, true)
				+ CheckAnswer(20, answers, 2, true)
				+ CheckAnswer(20, answers, 3, true)
				+ CheckAnswer(20, answers, 4, false)
				+ CheckAnswer(20, answers, 5, true);

			return await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit4, Unit4.Tasks[5], request.IsRetry, request.Duration, progress);
		}

		public async ValueTask<TestScoreGrpcResponse> Unit4GameAsync(TaskGameGrpcRequest request) =>
			await _taskProgressService.SetTaskProgressAsync(request.UserId, Unit4, Unit4.Tasks[6], request.IsRetry, request.Duration);
	}
}
