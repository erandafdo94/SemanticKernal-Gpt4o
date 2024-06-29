using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;

namespace semantickernal.controller.test
{

    [Route("test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("ask-question")]
        public async Task<IActionResult> AskQuestion(string question, Kernel kernal)
        {
            string answer = await kernal.InvokePromptAsync<string>(question);
            return Ok(answer);
        }
    }
}