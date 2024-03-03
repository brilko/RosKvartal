namespace RequestsContracts.Models
{
    public class ExaminationSubjectModel
    {
        public OrganizationInfoEnriched OrganizationInfoEnriched { get; set; } = new();
    }

    public class OrganizationInfoEnriched
    {
        public RegistryOrganizationCommonDetailWithNsi RegistryOrganizationCommonDetailWithNsi
        { get; set; } = new();
    }

    public class RegistryOrganizationCommonDetailWithNsi
    {
        public string FullName { get; set; } = "";
        public string Ogrn { get; set; } = "";
    }
}
