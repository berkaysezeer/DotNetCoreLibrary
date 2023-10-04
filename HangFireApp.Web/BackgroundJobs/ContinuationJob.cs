using System.Diagnostics;

namespace HangFireApp.Web.BackgroundJobs
{
    //Belli bir jobdan sonra çalışacak olan job için Continuation kullanıyoruz
    public class ContinuationJob
    {
        public static void WriteWatermarkStatusJob(string id, string fileName)
        {
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine($"Watermark eklendi ({fileName})"));
        }
    }
}
