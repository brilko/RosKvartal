using RepositoryContracts.Entities;

namespace Mappers.MappingUtils
{
    public static class ExaminationCompletionStatusTranslator
    {
        public readonly static IReadOnlyDictionary<string, string> EngToRus =
            new Dictionary<string, string>()
        {
            { "INFO",  ExaminationStatuses.InfoOrActivity.Name},
            { "ACTIVITY", ExaminationStatuses.InfoOrActivity.Name },
            { "RESULT", ExaminationStatuses.Result.Name }
        };
    }
}
