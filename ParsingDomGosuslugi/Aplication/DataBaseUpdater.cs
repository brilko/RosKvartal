namespace ParsingDomGosuslugi
{
    class DataBaseUpdater : IDataBaseUpdater
    {
        private readonly IDataBaseSaver saver;
        private readonly IGosUslugiUploader uploader;
        private readonly IJSONConverter converter;
        public DataBaseUpdater(IJSONConverter converter, IDataBaseSaver saver, IGosUslugiUploader uploader)
        {
            this.converter = converter;
            this.saver = saver;
            this.uploader = uploader;
        }
        public void Update()
        {
            var jsonDocuments = uploader.Upload();
            foreach (var jsonDocument in jsonDocuments)
            {
                var document = converter.Convert(jsonDocument);
                saver.Save(document);
            }
        }
    }
}
