using System.Globalization;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace MyRecipeBook.Api.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;
        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureInfo = supportedLanguages.Any(n => n.Name.Equals(requestedCulture)).ToString();

            if (!string.IsNullOrWhiteSpace(requestedCulture) && supportedLanguages.Any(n => n.Name.Equals(requestedCulture)))
            {
                cultureInfo = requestedCulture.ToString();
            }

            CultureInfo.CurrentCulture = new CultureInfo(requestedCulture);

            CultureInfo.CurrentUICulture = new CultureInfo(requestedCulture);

            await _next(context);

        }
    }
}
