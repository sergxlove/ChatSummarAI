using ChatSummarAI.Core.Requests;

namespace ChatSummarAI.Core.Abstractions
{
    public interface IJwtProviderService
    {
        string? GenerateToken(JwtRequest request);
    }
}