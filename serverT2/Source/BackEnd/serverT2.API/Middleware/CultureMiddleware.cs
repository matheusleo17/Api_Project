using System.Globalization;

namespace serverT2.API.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public CultureMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            var supportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
                                               .Select(c => c.Name.ToLower())
                                               .ToHashSet();

            var requestedCulture = context.Request.Headers["Accept-Language"].FirstOrDefault();

            var cultureInfo = new CultureInfo("pt-BR");

            if (!string.IsNullOrEmpty(requestedCulture) &&
                supportedCultures.Contains(requestedCulture.ToLower()))
            {
                cultureInfo = new CultureInfo(requestedCulture);
            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _requestDelegate(context);
        }
    }
}
