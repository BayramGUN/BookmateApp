/* using BookmateApp.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookmateApp.Mvc.Filters;

public class IsExistFilter : IAsyncActionFilter
{
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;
    private readonly IGenreService _genreService;

    public IsExistFilter(
        IBookService bookService,
        IAuthorService authorService,
        IGenreService genreService)
    {
        _bookService = bookService;
        _authorService = authorService;
        _genreService = genreService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var idParameterCheck = context.ActionArguments.ContainsKey("id");
        if(!idParameterCheck)
            context.Result = new BadRequestObjectResult(
                new 
                { 
                    message = $"{context.ActionDescriptor.DisplayName} action'ı, id parametresi içermelidir"
                });
        else
        {
            var id = (Guid)context.ActionArguments["id"];
            if(await _bookService.IsBookExist(id))
            {
                
            }

        }
        if(!context.ActionArguments.ContainsKey("id"))
            return Task.FromResult(false);
        
        if(context.ActionArguments.TryGetValue("id", ))
            return Task.FromResult(false);
         
        throw new NotImplementedException();
    }
} */