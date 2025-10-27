using _15_Filter_Operation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace _15_Filter_Operation.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result=new ViewResult()
            {
                ViewName= "Error",
                ViewData=new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState)
                {
                    Model=new ErrorViewModel
                    {
                        //HttpContext üzerinden TraceIdentifier ile istek kimliği alınır.
                        RequestId=context.HttpContext.TraceIdentifier,
                        ErrorMessage=context.Exception.Message
                        //Ve View tarafında hatayı bize gösterebiliriz.
                    }
                }
            };
            context.ExceptionHandled= true;
        }

    }
}
