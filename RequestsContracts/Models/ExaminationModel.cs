namespace RequestsContracts.Models
{
    public class ExaminationModel
    {
        public ExaminationSubjectModel Subject { get; set; } = new();
        public string ExamObjective { get; set; } = "";
        public bool? HasOffence { get; set; }
        public string ExaminationCompletionStatus { get; set; } = "";
    }
}
