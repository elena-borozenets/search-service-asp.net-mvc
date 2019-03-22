This project created for searching in internet and local db. 
First input returns first 10 results from faster searhing engine. Second input returns result from database (db).
Result from first input saves in db after each web request.
Database creates every time for application starts. To change this, open RecordContextInitializer, and change "DropCreateDatabaseAlways<RecordDbContext>" on "DropCreateDatabaseIfModelChanges<RecordDbContext>".
This application doesn't work with api, but scrape web search result pages. 
It uses google and bind search engines. Also there is parser for yandex search.
For adding another seach engine follow next steps:
1) add your request url to SearchInWeb action and pass it in parameters GetSearchResultAsync() method;
2) open GetSearchResultAsync() method implementation. Add your own task in such template: Task<HtmlDocument> task = website.LoadFromWebAsync(yourRequest + query);
3) add your task to parameters in Task.WhenAny() method;
4) add your own parser for this search engine.

For successful creating db change connectionString in Web.config file depends on your configuration.