using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ErrorHandlingApp.Web.Filters
{
    public class CustomHandleExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public string ErrorPage { get; set; }

        //hataları yakalayıp custom oluşturulan sayfalara action bazında yönlendirme yapmak için
        public override void OnException(ExceptionContext context)
        {
            var result = new ViewResult()
            {
                ViewName = ErrorPage
            };

            //bunu yazmazsa Error1 sayfasına data gönderemeyiz
            result.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState);
            result.ViewData.Add("Exception", context.Exception);
            result.ViewData.Add("Url", context.HttpContext.Request.Path);
            context.Result = result;

        }
    }
}
