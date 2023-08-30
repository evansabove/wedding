using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace wedding_backend
{
    public class EmptyFunction
    {
        [FunctionName("EmptyFunction")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "empty")][FromForm] HttpRequest req)
        {
            return new NoContentResult();
        }
    }
}
