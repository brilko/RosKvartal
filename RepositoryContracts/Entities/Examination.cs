namespace RepositoryContracts.Entities
{
    public class Examination : BaseEntity
    {
        private string organizationFullName = "";
        private string organizationOgrn = "";

        public DateTime Start { get; set; }
        public string OrganizationFullName 
        { 
            get => organizationFullName; 
            set => organizationFullName = value ?? ""; 
        }
        public string OrganizationOgrn 
        { 
            get => organizationOgrn; 
            set => organizationOgrn = value ?? ""; 
        } 
        public string ExamObjective { get; set; } = "";
        public Guid ExaminationResultId { get; set; }
        public ExaminationResult? ExaminationResult { get; set; }
        public Guid ExaminationStatusId { get; set; }
        public ExaminationStatus? ExaminationStatus { get; set; }
    }
}
