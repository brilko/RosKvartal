namespace ParsingDomGosuslugi.MapperProfiles
{
    internal class ExaminationCompletionStatusTranslator
    {
        public readonly static IReadOnlyDictionary<string, string> EngToRus =
            new Dictionary<string, string>()
        {
            { "INFO",  "Назначена"},
            { "ACTIVITY", "Назначена" },
            { "RESULT", "Завершена" }
        };
    }
}
