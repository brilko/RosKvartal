namespace ParsingDomGosuslugi.Requests.Contracts.Models
{
    internal class ExaminationsResponseModel
    {
        public long Total { get; set; }
        public List<CheckingDocumentModel> Items { get; set; } = new();
    }
}
