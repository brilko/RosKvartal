namespace ServicesContracts.DTOs
{
    public class ExaminationResponseDto
    {
        public long Total { get; set; }
        public List<ExaminationDto> Items { get; set; } = new();
    }
}
