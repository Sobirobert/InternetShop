using Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using WebAPI.Wrappers;

namespace WebAPI.Attributes;

public class ValidateFilterAttribute : ResultFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        base.OnResultExecuting(context);

        if (!context.ModelState.IsValid)
        {
            var entry = context.ModelState.Values.FirstOrDefault();

            context.Result = new BadRequestObjectResult(new Response<bool>
            {
                Succeeded = false,
                Message = "Something wrong. ",
                Errors = entry.Errors.Select(x => x.ErrorMessage)
            });
        }
    }

    public static void Display(object obj)
    {
        Type objType = obj.GetType();
        var propeties = objType.GetProperties();
        foreach ( var prop in propeties )
        {
            var propValue = prop.GetValue(obj);
            var propType = propValue.GetType();

            if ( propType.IsPrimitive || propType == typeof(string)) 
            {
                var displayPropertyAttribute = prop.GetCustomAttribute<DisplayPropertyAttribute>();
                Console.WriteLine($"{prop.Name}: {propValue}");
            }
        }
    }
}