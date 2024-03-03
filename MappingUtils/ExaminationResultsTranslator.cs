using RepositoryContracts.Entities;

namespace Mappers.MappingUtils
{
    public static class ExaminationResultsTranslator
    {
        public static string BoolToRusSentense(bool? examinationResult)
        {
            if (!examinationResult.HasValue)
                return ExaminationResults.ExaminationNotEnded.Name;
            return examinationResult.Value ?
                ExaminationResults.HasOffence.Name :
                ExaminationResults.NotOffence.Name;
        }
    }
}
