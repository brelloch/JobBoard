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
    public static class TheResumatorJobParser
    {
        public static async Task<string> Parse(string url)
        {
            List<Job> jobs = new List<Job>();
            Job job = new Job();

            HttpClient http = new HttpClient();
            var response = await http.GetByteArrayAsync(url);
            String source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
            source = WebUtility.HtmlDecode(source);
            HtmlDocument result = new HtmlDocument();
            result.LoadHtml(source);

            var description = result.DocumentNode.Descendants().Where(x => x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("description")).FirstOrDefault().InnerText.Trim();

            return description;
        }
    }
}
