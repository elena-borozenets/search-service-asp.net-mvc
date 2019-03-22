using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HtmlAgilityPack;
using SearchService.Facade.IFacades;
using SearchService.Models;

namespace SearchService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecordFacade _recordFacade;
        private string query = "cat";

        public HomeController(IRecordFacade recordFacade)
        {
            _recordFacade = recordFacade;
        }

        public ActionResult Index()
        {
            var res = _recordFacade.GetAll();
            return View(res);
        }

        public ActionResult SearchInWeb(string searchString)
        {
            string googleUrl = "https://www.google.com/search?q=";

            string bingUrl = "https://www.bing.com/search?q=";

            string yandexUrl = "https://www.yandex.com/search/?text=" + query;
            var list = GetSearchResultAsync(query, googleUrl, bingUrl).Result;
            //var list = GetGoogleSearchResult(query, googleUrl, bingUrl);
            var guid = _recordFacade.SaveRecords(list);
            var result = _recordFacade.GetRecordByRequestNumber(guid);

            return View("Index", result);
        }

        public ActionResult SearchInDb(string searchString)
        {
            var records = _recordFacade.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                records = records.Where(s => s.Title!=null && s.Title.Contains(searchString) 
                                             || s.Snippet!=null && s.Snippet.Contains(searchString));
            }

            return View("Index",records);
        }

        public async Task<List<Record>> GetSearchResultAsync(string query, params string[] requests)
        {
            HtmlWeb website = new HtmlWeb();
            website.AutoDetectEncoding = true;
            website.OverrideEncoding = Encoding.UTF8;
            Task<HtmlDocument> task1 = website.LoadFromWebAsync(requests[0] + query);
            Task<HtmlDocument> task2 = website.LoadFromWebAsync(requests[1] + query);
            var d = await Task.WhenAny(task1, task2).ConfigureAwait(false);
            HtmlDocument doc = d.Result;

            List<Record> result=null;
            if (task1.Id == d.Id) result = ParseGoogleSearchResult(doc);
            else
            if (task2.Id == d.Id) result = ParseBingSearchResult(doc);
            return result;
        }

        public List<Record> GetGoogleSearchResult(string query, params string[] requests)
        {
            HtmlWeb website = new HtmlWeb();
            website.AutoDetectEncoding = true;
            website.OverrideEncoding = Encoding.UTF8;
            var doc = website.Load(requests[0] + query);
            //var doc2 = website.Load(requests[1] + query);
            //HtmlDocument doc = d.Result;

            List<Record> result = null;
            result = ParseGoogleSearchResult(doc);
            // result = ParseBingSearchResult(doc);
            return result;
        }



        public List<Record> ParseGoogleSearchResult(HtmlDocument doc)
        {
            var selectNodes = doc.DocumentNode.SelectNodes("//div[@class='g']");

            List<Record> recordList = new List<Record>();
            for (int i = 0; i < selectNodes.Count && i < 10; i++)
            //foreach (var node in selectNodes)
            {

                var title = selectNodes[i].Descendants("h3").ElementAt(0).InnerText;
                var link = (selectNodes[i].Descendants("a")?.ElementAt(0)?.Attributes)
                    ?.FirstOrDefault(e => e.Name.Contains("href"))?.Value.Trim("/url?q=".ToCharArray());
                var snpLng = selectNodes[i].Descendants("span");
                var snippet = (snpLng.Count() > 1) ? snpLng.ElementAt(1).InnerText : "";


                recordList.Add(new Record()
                {
                    Title = title,
                    Link = link,
                    Snippet = snippet
                });
            }
            return recordList;
        }

        public List<Record> ParseBingSearchResult(HtmlDocument doc)
        {
            var selectNodes = doc.DocumentNode.SelectNodes("//li[@class='b_algo']");

            List<Record> recordList = new List<Record>();
            for (int i = 0; i < selectNodes.Count && i < 10; i++)
            //foreach (var node in selectNodes)
            {

                var title = selectNodes[i].Descendants("h2").ElementAt(0).InnerText;
                var link = (selectNodes[i].Descendants("a")?.ElementAt(0)?.Attributes)
                    ?.FirstOrDefault(e => e.Name.Contains("href"))?.Value;
                var snpLng = selectNodes[i].Descendants("p");
                var snippet = (snpLng.Count() >= 1) ? snpLng.ElementAt(0).InnerText : "";


                recordList.Add(new Record()
                {
                    Title = title,
                    Link = link,
                    Snippet = snippet
                });
            }
            return recordList;
        }

        public List<Record> ParseYandexSearchResult(HtmlDocument doc)
        {
            var selectNodes = doc.DocumentNode.SelectNodes("//li[@class='serp-item']");

            List<Record> recordList = new List<Record>();
            for (int i = 0; i < selectNodes.Count && i < 10; i++)
            {
                var title = selectNodes[i].Descendants("h2").ElementAt(0).InnerText;
                var link = (selectNodes[i].Descendants("a")?.ElementAt(0)?.Attributes)
                    ?.FirstOrDefault(e => e.Name.Contains("href"))?.Value;
                var snpLng = selectNodes[i].Descendants("div").Where(el =>
                    el.Attributes.Contains("text-container typo typo_text_m typo_line_m organic__text"));
                var snippet = (snpLng.Count() >= 1) ? snpLng.ElementAt(0).InnerText : "";


                recordList.Add(new Record()
                {
                    Title = title,
                    Link = link,
                    Snippet = snippet
                });
            }
            return recordList;
        }

    }
}