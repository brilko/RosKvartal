namespace RequestsContracts.Models
{
    public class ExaminationsResponseModel
    {
        public long Total { get; set; }
        public List<ExaminationRequestModel> Items { get; set; } = new();
    }
}
