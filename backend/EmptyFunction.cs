using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace wedding_backend
{
    public static class EmptyFunction
    {
        [FunctionName("EmptyFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "empty")] [FromForm] HttpRequest req)
        {
            return new NoContentResult();
        }
    }
}
