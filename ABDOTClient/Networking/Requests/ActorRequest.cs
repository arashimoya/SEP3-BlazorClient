using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Data
{
    public class ActorService : IActorService
    {
        public Task<bool> CreateActor(Actor actor)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditActor(Actor actor)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteActor(Actor actor)
        {
            throw new System.NotImplementedException();
        }

        public Task<Actor> GetActor(int Actorid)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Actor>> GetAllActors()
        {
            throw new System.NotImplementedException();
        }
    }
}