using ChallengeProsegur.Abtractions;
using ChallengeProsegur.DataAccess.Abstractions;
using ChallengeProsegur.DataAccess.Implementations;
using ChallengeProsegur.Entities.Model;
using ChallengeProsegur.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Repository.Implementations
{

    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        IPedidosDbContext _ctx;

        public PedidoRepository(IPedidosDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public Task<IList<Pedido>> GetPedidosActivosbyId(int id)
        {
            return _ctx.GetPedidosActivosbyId(id);
        }
    }
}
