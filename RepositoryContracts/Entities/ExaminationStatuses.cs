namespace RepositoryContracts.Entities
{
    public static class ExaminationStatuses
    {
        public static readonly ExaminationStatus InfoOrActivity = new()
        {
            Deleted = false,
            Id = Guid.Parse("cc72cede-e89b-4f6f-9de2-702e1455684d"),
            Name = "Назначена"
        };
        public static readonly ExaminationStatus Result = new()
        {
            Deleted = false,
            Id = Guid.Parse("af659670-a35d-44a3-b86d-8ac0dd14bb2e"),
            Name = "Завершена"
        };
        public static readonly IReadOnlyList<ExaminationStatus> Variables = new List<ExaminationStatus>()
        {
            InfoOrActivity,
            Result
        };
    }
}
