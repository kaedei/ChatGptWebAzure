using Azure;
using Azure.AI.OpenAI;
using ChatGptWebAzure.Models;

namespace ChatGptWebAzure.Services;

public class AzureChatGptService
{
    private readonly string _deploymentName; //The deployment name. e.g. My-GPT-Model
    private readonly OpenAIClient _openAiClient;

    public AzureChatGptService(IConfiguration configuration)
    {
        var endPoint = configuration["AzureOpenAI:Endpoint"];
        var key = configuration["AzureOpenAI:Key"];
        _deploymentName = configuration["AzureOpenAI:DeploymentName"];

        _openAiClient = new OpenAIClient(new Uri(endPoint), new AzureKeyCredential(key));
    }

    public async Task<string> GetChatCompletions(ChatCompletionsRequest request)
    {
        var options = new ChatCompletionsOptions()
        {
            MaxTokens = request.max_tokens?? 1200,
            ChoicesPerPrompt = 1,
            Temperature = request.temperature ?? 0.7F,
        };
        foreach (var msg in request.prompt)
        {
            options.Messages.Add(new ChatMessage(msg.role == "user" ? ChatRole.User : ChatRole.Assistant, msg.content));
        }

        var response = await _openAiClient.GetChatCompletionsAsync(_deploymentName, options);
        var choice = response.Value.Choices[0];
        if (choice.FinishReason == "content_filter")
        {
            return "system identifies harmful content";
        }

        return choice.Message.Content ?? string.Empty;
    }
}