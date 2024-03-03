namespace ParsingDomGosuslugi.MapperProfiles
{
    internal class ExaminationResultsTranslator
    {
        public static string BoolToRusSentense(bool? examinationResult)
        {
            if (!examinationResult.HasValue)
                return "-";
            return examinationResult.Value ?
                "Нарушения выявлены (в том числе факты невыполнения предписаний)" :
                "Нарушений не выявлено";
        }
    }
}
