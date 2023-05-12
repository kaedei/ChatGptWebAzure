namespace ChatGptWebAzure.Models;

public class Message
{
    public string role { get; set; }
    public string content { get; set; }

    public override string ToString()
    {
        return $"[{role}] {content}";
    }
}

public class ChatCompletionsRequest
{
    public List<Message> prompt { get; set; }
    public float? temperature { get; set; }
    public int? max_tokens { get; set; }
}
