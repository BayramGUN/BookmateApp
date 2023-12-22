/* using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookmateApp.Mvc.Filters;


public class NotImplementedAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        string message = $"Gönderdiğiniz isteğe {context.ActionDescriptor.DisplayName}"
         + $"istek alanından {context.Exception.Message} hatası dönüyor";
        
        context.Result = new BadRequestObjectResult( new { errorMessage = message });
    }
} */