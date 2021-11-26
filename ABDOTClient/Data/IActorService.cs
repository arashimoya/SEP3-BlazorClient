using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public interface IActorService
    {
        Task<bool> CreateActor(Actor actor);

        Task<bool> EditActor(Actor actor);

        Task<bool> DeleteActor(Actor actor);

        Task<Actor> GetActor(int Actorid);

        Task<List<Actor>> GetAllActors();
    }
}