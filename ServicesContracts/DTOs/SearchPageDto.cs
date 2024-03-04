namespace ServicesContracts.DTOs
{
    public class SearchPageDto
    {
        protected SearchPageDto() { }
        public SearchPageDto(int number, int size)
            {
                if (number <= 0 || size <= 0)
                    throw new ArgumentOutOfRangeException();
                Number = number;
                Size = size;
            }

        public int Number { get; set; }
        public int Size { get; set; }
    }
}
