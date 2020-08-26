using GameesStore_client.Filter;
using GamesStore_dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore_bll.Services.Abstraction
{
    public interface IGameService
    {
        ICollection<Game> GetAllGames();
        ICollection<Game> FilterGames(List<GameFilter> filters);
        ICollection<string> GetAllGenres();
        ICollection<string> GetAllDevelopers();
        void AddGame(Game game);
        void UpdateGame(Game model);
        void Delete(int id);
    }
}
