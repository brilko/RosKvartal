namespace ConfigurationParameters
{
    public class ExaminationsUriConfigParams
    {
        public string ExaminationsUri { get; set; } = "";// = "https://dom.gosuslugi.ru/inspection/api/rest/services/examinations/public/search?page=$pageNumberParameterName$&itemsPerPage=$pageSizeParameterName$";
        public string ExaminationsUriParameterPageNumber { get; set; } = "";// = "$pageNumberParameterName$";
        public string ExaminationsUriParametersPageSize { get; set; } = "";// = "$pageSizeParameterName$";
    }
}
