using GamesStore_dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore_bll.Services.Abstraction
{
    public interface ICartService
    {
        void AddToCart(int idGame, string idUser);
        void Remove(int idGame, string idUser);
        ICollection<Game> GetAll();
        void EmptyCart();
        int CountProducts(string idUser);
        void MakeOrder();
    }
}
