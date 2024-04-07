
using Microsoft.AspNetCore.Authentication.OAuth;

namespace Backend.Authentication
{

    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public IConfiguration _configuration;
        public ApiKeyAuthMiddleware(RequestDelegate requestDelegate , IConfiguration configuration)
        {
            _requestDelegate = requestDelegate;
            _configuration = configuration;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(AuthContext.ApiKeyHeaderName, out var extractedKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key is missing");
                return;
            }
            var apiKey = _configuration.GetValue<string>(AuthContext.ApiKeySectionName);
            if (!apiKey.Equals(extractedKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }
            await _requestDelegate(context);
        }
    }
}

