namespace RequestsContracts.Models
{
    public class ExaminationsResponseModel
    {
        public long Total { get; set; }
        public List<ExaminationModel> Items { get; set; } = new();
    }
}
