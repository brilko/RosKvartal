namespace ServicesContracts.DTOs
{
    public class ExaminationDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string OrganizationFullName { get; set; } = "";
        public string OrganizationOgrn { get; set; } = "";
        public string ExamObjective { get; set; } = "";
        public string ExaminationResult { get; set; } = "";
        public string ExaminationStatus { get; set; } = "";
    }
}
