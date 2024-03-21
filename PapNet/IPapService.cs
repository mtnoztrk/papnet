using System.Threading.Tasks;
using PapNet.Models;

namespace PapNet;

public interface IPapService
{
    Task<T> SendRequestAsync<T>(PapRequest request) where T : PapResponse;
    Task TrackAsync(PapParamRequest request);
}
