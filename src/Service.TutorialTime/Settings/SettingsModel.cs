using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.TutorialTime.Settings
{
	public class SettingsModel
	{
		[YamlProperty("TutorialTime.SeqServiceUrl")]
		public string SeqServiceUrl { get; set; }

		[YamlProperty("TutorialTime.ZipkinUrl")]
		public string ZipkinUrl { get; set; }

		[YamlProperty("TutorialTime.ElkLogs")]
		public LogElkSettings ElkLogs { get; set; }

		[YamlProperty("TutorialTime.EducationProgressServiceUrl")]
		public string EducationProgressServiceUrl { get; set; }

		[YamlProperty("TutorialTime.EducationRetryServiceUrl")]
		public string EducationRetryServiceUrl { get; set; }

		[YamlProperty("TutorialTime.UserRewardServiceUrl")]
		public string UserRewardServiceUrl { get; set; }

		[YamlProperty("TutorialTime.UserProgressServiceUrl")]
		public string UserProgressServiceUrl { get; set; }
	}
}