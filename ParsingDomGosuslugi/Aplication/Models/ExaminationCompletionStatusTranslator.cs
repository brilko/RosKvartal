namespace ParsingDomGosuslugi.Aplication.Models
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
