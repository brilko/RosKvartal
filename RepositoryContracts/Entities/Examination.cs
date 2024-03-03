using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryContracts.Entities
{
    public class Examination : BaseEntity
    {
        public DateTime Date { get; set; }
        public string OrganizationFullName { get; set; } = "";
        public string OrganizationOgrn { get; set; } = "";
        public string ExamObjective { get; set; } = "";
        public Guid ExaminationResultId { get; set; }
        public ExaminationResult? ExaminationResult { get; set; }
        public Guid ExaminationStatusId { get; set; }
        public ExaminationStatus? ExaminationStatus { get; set; }
    }
}
