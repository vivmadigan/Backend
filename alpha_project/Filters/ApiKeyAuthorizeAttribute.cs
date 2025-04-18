using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace alpha_project.Filters
{
    // This is something i needed some help with to put into place

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ApiKeyAuthorizeAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "x-api-key";

        public async Task OnActionExecutionAsync(ActionExecutingContext ctx,
            ActionExecutionDelegate next)
        {
            // pull the key you stored in configuration / env‑vars
            var cfgKey = ctx.HttpContext.RequestServices
                .GetRequiredService<IConfiguration>()
                .GetValue<string>("ApiKey");

            // header missing → 401
            if (!ctx.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName,
                    out var suppliedKey))
            {
                ctx.Result = new UnauthorizedResult();
                return;
            }

            // header present but wrong → 403
            if (!string.Equals(cfgKey, suppliedKey, StringComparison.Ordinal))
            {
                ctx.Result = new ForbidResult();
                return;
            }

            // all good → continue down the pipeline
            await next();
        }
    }

}

