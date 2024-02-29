namespace ParsingDomGosuslugi
{
    class DataBaseUpdater : IDataBaseUpdater
    {
        //private readonly IDataBaseSaver saver;
        //private readonly IGosUslugiUploader uploader;
        //public DataBaseUpdater(IDataBaseSaver saver, IGosUslugiUploader uploader)
        //{
        //    this.saver = saver;
        //    this.uploader = uploader;
        //}
        //public async void Update()
        //{
        //    var jsonDocuments = await uploader.UploadAsync();
        //    foreach (var jsonDocument in jsonDocuments)
        //    {
        //        var document = new CheckingDocument(null, null, null);
        //        saver.Save(document);
        //    }
        //}
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
