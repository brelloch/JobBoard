using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Customsearch;
using Google.Apis.Services;

namespace SearchTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = "AIzaSyBYCdftWAN-sk-vkc6hhmrHcTl4yaHRhPQ";
            string cx = "011210479108868451169:4uy7jqr3igk";
            string query = "site:*.theresumator.com";


            var svc = new Google.Apis.Customsearch.v1.CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
            var listRequest = svc.Cse.List(query);
            int page = 0;
            List<string> urls = new List<string>();

            string startDate = DateTime.UtcNow.AddDays(-90).ToString("yyyyMMdd");
            //string startDate = (DateTime.UtcNow.Year.ToString() + sMonth + sday);
            string endDate = DateTime.UtcNow.AddDays(-60).ToString("yyyyMMdd");
            listRequest.DateRestrict = "w10";

            try
            {
                while (page < 10)
                {
                    listRequest.Num = 10;
                    listRequest.Start = page * listRequest.Num;

                    if (listRequest.Start == 0)
                        listRequest.Start = 1;

                    listRequest.Cx = cx;
                    var search = listRequest.Execute();

                    foreach (var result in search.Items)
                    {
                        urls.Add(result.Link);
                        Console.WriteLine("Title: {0}", result.Title);
                        Console.WriteLine("Link: {0}", result.Link);
                    }
                    page++;
                }
            }
            catch (Exception ex)
            {
                var test = ex.Message;
            }

            System.IO.File.WriteAllLines(@"C:\urlsa.txt", urls.Distinct().ToArray());

            Console.WriteLine("done");
        }
    }
}
