namespace InfoApi.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string API_KEY_HEADER_NAME = "Authorization";
        private const string API_KEY = "key1";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(API_KEY_HEADER_NAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized access. Missing API Key.");
                return;
            }


            var tokenParts = extractedApiKey.ToString().Split(' ');

            if (tokenParts.Length != 2 || !tokenParts[0].Equals("Bearer") || !tokenParts[1].Equals(API_KEY))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized access. Invalid API Key.");
                return;
            }

            await _next(context);
        }
    }
}
