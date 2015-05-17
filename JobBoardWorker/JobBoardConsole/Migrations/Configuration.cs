namespace JobBoardConsole.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using JobBoard.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<JobBoardContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(JobBoardContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            //https://www.google.com/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=inurl:theresumator.com/apply/&start=80&filter=0
            context.Companies.AddOrUpdate(
                new Company { Name = "Action Against Hunger", Url = "http://actionagainsthunger.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Adcap Network Systems", Url = "http://adcap.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Adorama", Url = "http://adorama.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "AdWerx", Url = "http://adwerx.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Aramco", Url = "http://aramcoservices.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "articulate", Url = "http://articulate.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Atlantic Media", Url = "http://atlanticmedia.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Autodata Solutions", Url = "http://autodata.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Bauer Xcel Media", Url = "http://bauerxcel.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "BetterCloud", Url = "http://bettercloud.theresumator.com/", Type = JobBoardType.TheResumator },
                new Company { Name = "BREAKFAST", Url = "http://breakfast.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Breather", Url = "http://breather.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Christian Living Communities", Url = "http://christianlivingcommunities.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "DoSomething.org", Url = "http://dosomething.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Echelon Insights", Url = "http://echeloninsights.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "eddi", Url = "http://eddi.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "eHealth Systems Africa", Url = "http://ehealthafrica.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Elegant Themes", Url = "http://elegantthemes.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "GovHR USA", Url = "http://govhrusa.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Grassroots Campaigns", Url = "http://grassrootscampaigns.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Gravity4", Url = "http://gravity4.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "HotelQuickly", Url = "http://hotelquickly.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Innovative Systems", Url = "http://innovativesystems.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Intridea", Url = "http://intridea.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "iQmetrix", Url = "http://iqmetrix.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "littleBits", Url = "http://littlebits.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Livestream", Url = "http://livestream.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Marketade", Url = "http://marketade.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Matthews International", Url = "http://matthews.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Metabiota", Url = "http://metabiota.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "MG2", Url = "http://mg2.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "MLB Advanced Media", Url = "http://mlb.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Motion Global", Url = "http://motionglobal.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Moz", Url = "http://moz.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "mySociety", Url = "http://mysocietyltd.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "NewsBeat Social", Url = "http://newsbeatsocial.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Nonprofit Finance Fund", Url = "http://nonprofitfinancefund.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "NovaCopy", Url = "http://novacopy.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Olo", Url = "http://olo.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Open Knowledge", Url = "http://openknowledge.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Paragon Systems", Url = "http://parasys.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "PayJunction", Url = "http://payjunction.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Red Nova Labs", Url = "http://rednovalabs.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Robots and Rockets", Url = "http://robotsandrockets.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Seed Scientific", Url = "http://seedscientific.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Simple", Url = "http://banksimple.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "South Mountain Creamery", Url = "http://smcmgt.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Sphero", Url = "http://orbotix.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "Splash Damage", Url = "http://splashdamagejobs.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "TechSoup Global", Url = "http://techsoup.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "The Annie E. Casey Foundation", Url = "http://aecfexpandingthebench.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "The Healthy Back Institute", Url = "http://healthybackinstitute.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Think Brownstone", Url = "http://tbi.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "TrustHCS", Url = "http://jobsattrusthcs.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "UpOut", Url = "http://upout.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "Vendini", Url = "http://vendini.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "When I Work", Url = "http://wheniwork.theresumator.com/apply", Type = JobBoardType.TheResumator },
                new Company { Name = "World Wide Web Hosting", Url = "http://wwwh.theresumator.com/apply/", Type = JobBoardType.TheResumator },
                new Company { Name = "XPO", Url = "http://uxassembly.theresumator.com/apply", Type = JobBoardType.TheResumator }
            );
            
        }
    }
}
