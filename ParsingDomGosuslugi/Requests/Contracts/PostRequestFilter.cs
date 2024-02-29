namespace ParsingDomGosuslugi.Requests.Contracts
{
    internal class PostRequestFilter
    {
        public PostRequestFilter(DateTime examStartFrom)
        {
            this.examStartFrom = examStartFrom.ToUniversalTime().ToString();
        }

        public string? numberOrUriNumber { get; set; } = null;
        public List<string> typeList { get; set; } = new();
        public string examStartFrom { get; set; } = "";
        public string? examStartTo { get; set; } = null;
        public List<string> formList { get; set; } = new();
        public List<string> hasOffences { get; set; } = new();
        public string? isAssigned { get; set; } = null;
        public List<string> oversightActivitiesRefList { get; set; } = new();
        public List<string> preceptsMade { get; set; } = new();
        public List<string> statusList { get; set; } = new();
    }
}
