using GamesStore_bll.Services.Abstraction;
using GamesStore_dal.Entities;
using GamesStore_dal.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using GamesStore_dal;

namespace GamesStore_bll.Services.Implementation
{
    public class CartService : ICartService
    {
        private readonly IGenericRepository<Cart> repoCart;
        private readonly IGenericRepository<Order> repoOrder;
        private readonly IGenericRepository<Game> repoGame;
        private readonly IGenericRepository<CustomUser> repoUser;
        private ApplicationContext context = new ApplicationContext();
        public CartService(IGenericRepository<Cart> _repoCart, IGenericRepository<Order> _repoOrder, IGenericRepository<Game> _repoGame, IGenericRepository<CustomUser> _repoUser)
        {
            repoCart = _repoCart;
            repoOrder = _repoOrder;
            repoGame = _repoGame;
            repoUser = _repoUser;
        }

        public int CountProducts(string idUser)
        {
            return repoCart.GetAll().Count();
        }

        public void AddToCart(int idGame, string idUser)
        {
            var user = repoUser.GetAll().FirstOrDefault(x => x.Id == idUser);
            var game = repoGame.GetAll().FirstOrDefault(x => x.Id == idGame);
            if (user.Cart == null)
            {
                user.Cart = new Cart();
            }
            user.Cart.Games.Add(game);
            context.SaveChanges();
        }

        public void EmptyCart()
        {
            throw new NotImplementedException();
        }

        public ICollection<Game> GetAll()
        {
            throw new NotImplementedException();
            //return repoGame.GetAll().Where();
        }

        public void MakeOrder()
        {
            throw new NotImplementedException();
        }

        public void Remove(int idGame, string idUser)
        {
            var user = repoUser.GetAll().FirstOrDefault(x => x.Id == idUser);
            var game = repoGame.GetAll().FirstOrDefault(x => x.Id == idGame);
            user.Cart.Games.Remove(game);
            context.SaveChanges();
        }
    }
}
