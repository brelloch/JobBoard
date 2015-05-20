using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using JobBoard.Models;
using JobBoard.Parsers;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JobBoardConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new JobBoardContext())
            {
                List<Job> alljobs = new List<Job>();

                ///////////// Resumator
                var companies = from b in db.Companies
                            orderby b.Name
                            select b;

                Parallel.ForEach(companies, item =>
                {
                    if (item.Type == JobBoardType.TheResumator)
                    {
                        try
                        {
                            var task = TheResumatorBoardParser.Parse(item.Name, item.Url);
                            task.Wait();
                            var jobs = task.Result;
                            alljobs.AddRange(jobs);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    Console.WriteLine(item.CompanyId);
                });

                foreach (var job in alljobs) {
                    db.Jobs.Add(job);
                }
                db.SaveChanges();

                ///////////////// Jobvite
                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri("https://search.jobvite.com/api/jobsearch?limit=" + 1 + "&start=" + 0);
                //    client.DefaultRequestHeaders.Accept.Clear();
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //
                //    var responseTask = client.GetAsync("");
                //    responseTask.Wait();
                //    HttpResponseMessage response = responseTask.Result;
                //
                //    if (response.IsSuccessStatusCode)
                //    {
                //        var contentTask = response.Content.ReadAsStringAsync();
                //        contentTask.Wait();
                //        var content = contentTask.Result.Replace("\r\n", "");
                //        var totalJobs = int.Parse(Newtonsoft.Json.JsonConvert.DeserializeObject<JobviteBase>(content).totalResults);
                //        totalJobs = 10;
                //        //int pageSize = 100;
                //        int pageSize = 10;
                //
                //        for (int i = 0; (i-1 * pageSize) < totalJobs; i++)
                //        {
                //            var task = JobviteParser.Parse(i*pageSize, pageSize);
                //            task.Wait();
                //            var jobs = task.Result;
                //
                //            foreach (var job in jobs)
                //            {
                //                db.Jobs.Add(job);
                //            }
                //            db.SaveChanges();
                //
                //        }
                //    }
                //}

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
