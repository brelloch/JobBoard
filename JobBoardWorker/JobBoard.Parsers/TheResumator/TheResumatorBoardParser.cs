using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBoard.Models;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net;
using System.Linq;

namespace JobBoard.Parsers
{
    public static class TheResumatorBoardParser
    {
        //public TheResumatorBoardParser(string url)
        //{
        //    this.Url = url;
        //}
        //
        //public string Url { get; private set; }
        //
        public static async Task<List<Job>> Parse(int companyId, string url)
        {
            List<Job> jobs = new List<Job>();
            Job job = new Job() { CompanyId = companyId };

            HttpClient http = new HttpClient();
            var response = await http.GetByteArrayAsync(url);
            String source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
            source = WebUtility.HtmlDecode(source);
            HtmlDocument result = new HtmlDocument();
            result.LoadHtml(source);

            var jobLis = result.DocumentNode.Descendants().Where(x => x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("list-group-item")).ToList();

            foreach (var jobli in jobLis)
            {
                if (jobli.Name == "li")
                {
                    job = new Job() { CompanyId = companyId };
                }
                else if (jobli.Name == "h4")
                {
                    job.Title = jobli.Descendants().Where(x => x.Name == "a").FirstOrDefault().InnerText.Trim();
                    job.Url = jobli.Descendants().Where(x => x.Name == "a").Select(x => x.Attributes["href"]).FirstOrDefault().Value;
                }
                else if (jobli.Name == "ul")
                {
                    job.Location = jobli.Descendants().Where(x => x.Name == "li").FirstOrDefault().InnerText.Trim();
                    job.Description = await TheResumatorJobParser.Parse(job.Url);
                    jobs.Add(job);
                }
            }

            return jobs;
        }
    }
}
