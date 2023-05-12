using ChatGptWebAzure.Models;
using ChatGptWebAzure.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatGptWebAzure.Controllers;

[Route("v1/chat")]
public class ChatController
{
    private readonly AzureChatGptService _chatGptService;

    public ChatController(AzureChatGptService chatGptService)
    {
        _chatGptService = chatGptService;
    }

    [HttpPost]
    [Route("completions")]
    public async Task<IActionResult> GetCompletions([FromBody] ChatCompletionsRequest request)
    {
        if ((request?.prompt?.Count ?? 0) <= 0)
        {
            return GenerateResponse("Hello, I'm a chatbot. What can I do for you?");
        }

        var gptResponse = await _chatGptService.GetChatCompletions(request!);
        return GenerateResponse(gptResponse);
    }

    private static IActionResult GenerateResponse(string content)
    {
        return new JsonResult(new
        {
            choices = new[]
            {
                new
                {
                    index = 0,
                    finish_reason = "stop",
                    message = new
                    {
                        role = "assistant",
                        content = content
                    }
                }
            }
        });
    }
}