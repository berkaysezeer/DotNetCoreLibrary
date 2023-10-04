namespace HangFireApp.Web.Services
{
    public interface IWatermarkAdder
    {
        void AddWatermark(string filename, string watermark);
    }
}
