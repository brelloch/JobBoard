using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using JobBoard.Models;
using JobBoard.Parsers;

namespace JobBoardConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new JobBoardContext())
            {
                //// Create and save a new Blog 
                //Console.Write("Enter a name for a new Blog: ");
                //var name = Console.ReadLine();
                //
                //var company = new Company { Name = name };
                //db.Companies.Add(company);
                //db.SaveChanges();

                List<Job> alljobs = new List<Job>();

                //// Display all Blogs from the database 
                //var query = from b in db.Companies
                //            orderby b.Name
                //            select b;
                //
                //Console.WriteLine("All blogs in the database:");
                //foreach (var item in query)
                //{
                //    if (item.Type == JobBoardType.TheResumator)
                //    {
                //        var task = TheResumatorBoardParser.Parse(item.CompanyId, item.Url);
                //        task.Wait();
                //        var jobs = task.Result;
                //        alljobs.AddRange(jobs);
                //    }
                //    Console.WriteLine(item.Name);
                //}

                foreach (var job in alljobs) {
                    db.Jobs.Add(job);
                }
                db.SaveChanges();

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
