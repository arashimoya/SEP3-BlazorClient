using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests {
    public class PlayRequest : IPlayRequest
    {
        private IList<Play> Plays;

        public PlayRequest()
        {
            Plays = new List<Play>();
        }
        public async Task<bool> CreatePlay(Play play) {
            Plays.Add(play);
            return true;
        }

        public async Task<bool> EditPlay(Play play)
        {
            Play toUpdate = Plays.FirstOrDefault(p => p.Id == play.Id);
            if (toUpdate == null) return false;
            toUpdate.Date = play.Date;
            toUpdate.Hall = play.Hall;
            toUpdate.Movie = play.Movie;
            toUpdate.Tickets = play.Tickets;
            toUpdate.TimeInMinutes = play.Movie.LengthInMinutes;
            return true;
        }

        public async Task<bool> DeletePlay(Play play)
        {
            Play toRemove = Plays.FirstOrDefault(p => p.Id == play.Id);
            if (toRemove == null) return false;
            Plays.Remove(toRemove);
            return true;
        }

        public async Task<Play> Get(int id)
        {
            return Plays.FirstOrDefault(p => p.Id == id);
        }

        public async Task<IList<Play>> GetAllPlays()
        {
            return Plays;
        }
    }
}