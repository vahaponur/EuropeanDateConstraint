using System.Globalization;
using System.Text.RegularExpressions;

namespace Routing
{
    public class EuropeanDateConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            object routeValue;
            if (values.TryGetValue(routeKey, out routeValue))
            {
                var parameterValueString  = Convert.ToString(routeValue,CultureInfo.InvariantCulture); 
               return new Regex(@"^([1-9]|0[1-9]|[12][0-9]|3[01])[-\.]([1-9]|0[1-9]|1[012])[-\.]\d{4}$", RegexOptions.CultureInvariant
                                | RegexOptions.IgnoreCase).IsMatch(parameterValueString);
            }
            return false;
        }
    }
}