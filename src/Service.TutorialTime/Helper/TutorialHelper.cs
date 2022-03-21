using Service.Education.Structure;

namespace Service.TutorialTime.Helper
{
	public static class TutorialHelper
	{
		public static readonly EducationTutorial Tutorial = EducationTutorial.TimeManagement;

		public static readonly EducationStructureTutorial StructureTutorial = EducationStructure.Tutorials[Tutorial];
	}
}