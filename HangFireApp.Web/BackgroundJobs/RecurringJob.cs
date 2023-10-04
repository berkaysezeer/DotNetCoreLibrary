using Hangfire;
using System.Diagnostics;

namespace HangFireApp.Web.BackgroundJobs
{
    public class RecurringJob
    {
        public static void ReportingJob()
        {
            //cron: 5 birimli zaman ayarıdır https://en.wikipedia.org/wiki/Cron
            //http://www.cronmaker.com
            //https://crontab.cronhub.io
            //Hangfire.RecurringJob.AddOrUpdate("reportjob1", () => EmailReport(), Cron.Minutely());
            Hangfire.RecurringJob.AddOrUpdate("reportjob1", () => EmailReport(), "*/3 * * * *");
        }

        public static void EmailReport()
        {
            Debug.WriteLine("Rapor", "email olarak gönderildi");
        }
    }
}
