namespace ParsingDomGosuslugi
{
    internal class CheckingDocument
    {
        public string _Guid { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }
        public CheckingDocument(string? guid, string? number, string? date) {
            _Guid = guid ?? "";
            Number = number ?? "0";
            Date = date ?? "";
        }
    }
}
