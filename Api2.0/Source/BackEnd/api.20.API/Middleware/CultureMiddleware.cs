using System.Globalization;

namespace api._20.API.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public CultureMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task Invoke (HttpContext context)
        {
            var supportedLan = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var requestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureInfo = new CultureInfo("pt-BR");

            if(string.IsNullOrEmpty(requestCulture) == false && supportedLan.Any(c=>c.Name.Equals(requestCulture)))
            {
                var cultureinfo = new CultureInfo(requestCulture);
            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _requestDelegate(context);
        }
    }
}
