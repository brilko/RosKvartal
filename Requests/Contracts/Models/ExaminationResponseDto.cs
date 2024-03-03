namespace ParsingDomGosuslugi.Requests.Contracts.Models
{
    internal class ExaminationResponseDto
    {
        public long Total { get; set; }
        public List<ExaminationDto> Items { get; set; } = new();
    }
}
