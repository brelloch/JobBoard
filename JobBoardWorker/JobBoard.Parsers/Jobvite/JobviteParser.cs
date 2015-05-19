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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JobBoard.Models;
namespace JobBoard.Parsers
{
    public static class JobviteParser
    {
        public static async Task<List<Job>> Parse(int start, int limit)
        {
            List<Job> jobs = new List<Job>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://search.jobvite.com/api/jobsearch?limit="+limit+"&start="+start);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var content = (await response.Content.ReadAsStringAsync()).Replace("\r\n", "");
                    var intialJobviteJobs = Newtonsoft.Json.JsonConvert.DeserializeObject<JobviteBase>(content);

                    foreach (var jobviteJob in intialJobviteJobs.results)
                    {
                        var job = new Job();
                        job.CompanyName = jobviteJob.company;
                        job.Location = jobviteJob.formattedLocation;
                        job.Title = jobviteJob.jobtitle;
                        job.Url = "https://search.jobvite.com/web/modules/layout/jobDetail.htm?j=" + jobviteJob.jobId;

                        using (var client2 = new HttpClient())
                        {
                            client2.BaseAddress = new Uri("https://search.jobvite.com/api/jobsearch?action=detail&jobId=" + jobviteJob.jobId);
                            client2.DefaultRequestHeaders.Accept.Clear();
                            client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            HttpResponseMessage response2 = await client2.GetAsync("");
                            if (response.IsSuccessStatusCode)
                            {
                                var content2 = (await response2.Content.ReadAsStringAsync()).Replace("\r\n", "");
                                var detail = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JobviteDetail>>(content2);

                                job.Description = detail[0].jobdesc;
                            }
                        }

                        jobs.Add(job);
                    }
                }
            }

            return jobs;
        }
    }
}
