using InwinkLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InwinkLibrary
{
    public interface IInwinkClient
    {
        Task<List<Session>> GetSessions();
        Task<Session> GetSessionById(int id);
        Task<List<Speaker>> GetSpeakers();
        Task<Speaker> GetSpeakerById(int id);
    }
}
