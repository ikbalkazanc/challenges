namespace Coredet.Common.Controller
{
    public class CoredetCustomController : Microsoft.AspNetCore.Mvc.Controller
    {
        public bool IsAuthenticated
        {
            get
            {
                
                return this.HttpContext.User != null &&
                       this.HttpContext.User.Identity != null &&
                       this.HttpContext.User.Identity.IsAuthenticated;
            }
        }
        
    }
}