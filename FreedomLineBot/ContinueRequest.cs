using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;

namespace FreedomLineBot
{
    public static class ContinueRequest
    {
        [FunctionName("ContinueRequest")]
        public static async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            string id = req.Query["ID"];
            var db = new Database();
            try
            {
                var check = await db.MemberCheck(id);
                if (!check.already)
                {
                    return new OkObjectResult("�p����]���m�F���܂����B");
                }
                else
                {
                    return new OkObjectResult("���łɊ�]���������Ă��܂��B");
                }
            }
            catch (System.Exception e)
            {
                return new BadRequestObjectResult(e.ToString());
            }
        }
    }
}
