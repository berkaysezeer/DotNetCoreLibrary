using HangFireApp.Web.Services;

namespace HangFireApp.Web.BackgroundJobs
{
    public class FireAndForgetJob
    {
        public static void EmailSendToUserJob(string userId, string message)
        {
            //tek seferlik işler oluşturmak için kullanılacak metod
            //Hangfire sayesinde job veri tabanına kaydedilir
            Hangfire.BackgroundJob.Enqueue<IEmailSender>(x => x.Sender(userId, message));
        }
    }
}
