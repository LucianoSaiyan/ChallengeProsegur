using ChallengeProsegur.Abtractions;
using ChallengeProsegur.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.DataAccess.Abstractions
{
    public interface IPedidosDbContext : IDbContext<Pedido>
    {
        Task<IList<Pedido>> GetPedidosActivosbyId(int id);
    }
}
