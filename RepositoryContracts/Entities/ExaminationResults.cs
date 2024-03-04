namespace RepositoryContracts.Entities
{
    public static class ExaminationResults
    {
        public static readonly ExaminationResult ExaminationNotEnded = new()
        {
            Deleted = false,
            Id = Guid.Parse("01027409-f735-4a97-b815-c8017b5ed810"),
            Name = "-",
        };
        public static readonly ExaminationResult HasOffence = new()
        {
            Deleted = false,
            Id = Guid.Parse("f60c4ff8-e488-402c-b0d8-5d6f6c2dd874"),
            Name = "Нарушения выявлены (в том числе факты невыполнения предписаний)",
        };
        public static readonly ExaminationResult NotOffence = new()
        {
            Deleted = false,
            Id = Guid.Parse("1f091554-2085-4b73-a91e-92ed963aaf51"),
            Name = "Нарушений не выявлено"
        };
        public static readonly IReadOnlyList<ExaminationResult> Variables = new List<ExaminationResult>()
        {
            ExaminationNotEnded,
            HasOffence,
            NotOffence
        };
        public static ExaminationResult FindByName(string name) 
        {
            return Variables
                .Where(res => res.Name == name)
                .FirstOrDefault()
                ?? throw new NotImplementedException();
        }
        public static ExaminationResult FindById(Guid id) 
        {
            return Variables
                .Where (res => res.Id == id)
                .FirstOrDefault()
                ?? throw new NotImplementedException();
        }
    }
}
