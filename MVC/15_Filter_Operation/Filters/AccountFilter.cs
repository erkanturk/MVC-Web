using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace _15_Filter_Operation.Filters
{
    public class AccountFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Action executed");//Action tamamlandıktan sonra çalışır.
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Action executing");//Action sırasında çalışır.
        }
    }
}
