using ParsingDomGosuslugi;

new DataBaseUpdater(
        new JSONConverter(),
        new DataBaseSaver(),
        new GosUslugiUploader()
    ).Update();
