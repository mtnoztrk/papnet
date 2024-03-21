using System.Linq;

namespace PapNet.Models;

public record SessionResponse : PapResponse
{
    public string Username { get; set; }
    public string SessionId { get; set; }

    public SessionResponse(PapGenericResponse response) : base(response)
    {
        Username = response.Fields.First(c => c.First() == "username")[1]!;
        SessionId = response.Fields.First(c => c.First() == "S")[1]!;
    }
}
