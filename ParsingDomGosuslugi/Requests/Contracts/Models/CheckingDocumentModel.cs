namespace ParsingDomGosuslugi.Requests.Contracts.Models
{
    internal class CheckingDocumentModel
    {
        public ExaminationSubjectModel Subject { get; set; } = new();
        public string ExamObjective { get; set; } = "";
        public bool? HasOffence { get; set; }
        public string ExaminationCompletionStatus { get; set; } = "";
    }
}
