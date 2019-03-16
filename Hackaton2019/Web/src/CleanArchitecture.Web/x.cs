using Hangfire.Dashboard;

namespace CleanArchitecture.Web
{
    public class CustomAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}
