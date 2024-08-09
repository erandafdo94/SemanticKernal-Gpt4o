using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
using System;
using System.Threading.Tasks;

namespace semantickernal.controller.test
{
    [Route("test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("ask-question")]
        public async Task<IActionResult> AskQuestion(string topic, Kernel kernal)
        {

            // Fun initial transformation or validation
            if (string.IsNullOrWhiteSpace(topic))
            {
                return BadRequest("Topic cannot be empty or whitespace!");
            }

            // Create a prompt template for the joke
            string promptTemplate = $"Tell me a joke about {topic}";

            // Invoking gpt4o 
            string joke = await kernal.InvokePromptAsync<string>(promptTemplate);

            // Add a humorous twist to the response
            string humorousResponse = $"Here's a joke about {topic}: {joke}";

            return Ok(humorousResponse);
        }
    }
}
