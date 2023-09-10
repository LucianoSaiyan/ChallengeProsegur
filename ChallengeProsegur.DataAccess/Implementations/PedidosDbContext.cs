using ChallengeProsegur.DataAccess.Abstractions;
using ChallengeProsegur.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.DataAccess.Implementations
{
    public class PedidosDbContext : DbContext<Pedido>, IPedidosDbContext
    {
        public PedidosDbContext(ApiDbContext ctx) : base(ctx)
        {

        }

        public async Task<IList<Pedido>> GetPedidosActivosbyId(int id) 
        {
            IList<Pedido> pedidos = await GetAllAsync();
            List<Pedido> rr = pedidos.Where(p => p.UsuarioId == id).ToList();
            return rr;
        }

        #region Implemented Methods

        public IList<Pedido> GetUsers()
        {
            return GetAll();
            throw new NotImplementedException();
        }

        public Pedido GetUserbyId(int id)
        {
            return GetById(id);
        }

        public Pedido GetUserbyIdWithPedidos(int id)
        {
            return GetUserbyIdWithPedidos(id) ;
            throw new NotImplementedException();
        }

        public IList<Pedido> GetUsersWithPedidos()
        {
            return GetUsersWithPedidos();
            throw new NotImplementedException();
        }


        #endregion


    }
}
