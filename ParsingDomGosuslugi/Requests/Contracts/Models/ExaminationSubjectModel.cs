namespace ParsingDomGosuslugi.Requests.Contracts.Models
{
    internal class ExaminationSubjectModel
    {
        public OrganizationInfoEnriched OrganizationInfoEnriched { get; set; } = new();
    }

    internal class OrganizationInfoEnriched
    {
        public RegistryOrganizationCommonDetailWithNsi RegistryOrganizationCommonDetailWithNsi
        { get; set; } = new();
    }

    internal class RegistryOrganizationCommonDetailWithNsi
    {
        public string FullName { get; set; } = "";
        public string Ogrn { get; set; } = "";
    }
}
