using System.Drawing;

namespace HangFireApp.Web.Services
{
    public class WatermarkAdder : IWatermarkAdder
    {
        public void AddWatermark(string filename, string watermark)
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
