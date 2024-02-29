namespace ParsingDomGosuslugi
{
    internal class ExaminationsUriConfigParams
    {
        //public ExaminationsUriConfigParams(ExaminationsUriConfigParams uriConfiguration) 
        //{
        //    ExaminationsUri = uriConfiguration.ExaminationsUri;
        //    ExaminationsUriParameterPageNumber = uriConfiguration.ExaminationsUriParameterPageNumber;
        //    ExaminationsUriParametersPageSize = uriConfiguration.ExaminationsUriParametersPageSize;
        //}

        public string ExaminationsUri { get; set; } = "https://dom.gosuslugi.ru/inspection/api/rest/services/examinations/public/search?page=$pageNumberParameterName$&itemsPerPage=$pageSizeParameterName$";
        public string ExaminationsUriParameterPageNumber { get; set; } = "$pageNumberParameterName$";
        public string ExaminationsUriParametersPageSize { get; set; } = "$pageSizeParameterName$";
    }
}
