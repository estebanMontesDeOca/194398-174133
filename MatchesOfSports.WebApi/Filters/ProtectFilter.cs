using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MatchesOfSports.WebApi.Filters
{
    public class ProtectFilter : Attribute, IActionFilter
    {
        private readonly string role;
    
        public ProtectFilter(string role)
        {
            this.role = role;
        }   

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // OBTENEMOS EL TOKEN DEL HEADER
            string token = context.HttpContext.Request.Headers["Authorization"];
            // SI EL TOKEN ES NULL CORTAMOS LA PIPELINE Y RETORNAMOS UN RESULTADO
            if (token == null)
            {
                context.Result = new ContentResult()
                {
                    Content = "Token is required",
                };
            }
        } 
        public void OnActionExecuted(ActionExecutedContext context) {}
    }
}