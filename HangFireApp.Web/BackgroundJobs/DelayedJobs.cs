using HangFireApp.Web.Services;
using System.Drawing;

namespace HangFireApp.Web.BackgroundJobs
{
    public class DelayedJobs
    {
        public static string WatermarkAdderJob(string filename, string watermark)
        {
            return Hangfire.BackgroundJob.Schedule<IWatermarkAdder>(x => x.AddWatermark(filename, watermark), TimeSpan.FromSeconds(30));
        }

        public static string AddWatermarkJob(string filename, string watermark)
        {
            return Hangfire.BackgroundJob.Schedule(() => ApplyWatermark(filename, watermark), TimeSpan.FromSeconds(30));
        }

        public static void ApplyWatermark(string filename, string watermark)
        {
            //dosya yolu oluşturur
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", filename);

            //resmi aldık
            using (var bitmap = Bitmap.FromFile(path))
            {
                //resmin boyutunda çerçeve oluşturduk
                using (Bitmap tempBitmap = new Bitmap(bitmap.Width, bitmap.Height))
                {
                    //çerçeve içine watermark için ayarları yaptık
                    using (Graphics grp = Graphics.FromImage(tempBitmap))
                    {
                        grp.DrawImage(bitmap, 0, 0);
                        var font = new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold);
                        var color = Color.FromArgb(255, 0, 0);
                        var brush = new SolidBrush(color);
                        var point = new Point(20, bitmap.Height - 50);

                        grp.DrawString(watermark, font, brush, point);

                        //bitmap'i tempBitmap'e aktardık ve onun üzerinden işlemleri yaptık
                        tempBitmap.Save(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/watermarks", filename));
                    }

                }

            }
        }
    }
}

