namespace RequestsContracts.Models
{
    public class ExaminationModel
    {
        public string Guid { get; set; } = "";
        public string Date { get; set; } = "";
        public ExaminationSubjectModel Subject { get; set; } = new();
        public string ExamObjective { get; set; } = "";
        public bool? HasOffence { get; set; }
        public string ExaminationCompletionStatus { get; set; } = "";
    }
}
