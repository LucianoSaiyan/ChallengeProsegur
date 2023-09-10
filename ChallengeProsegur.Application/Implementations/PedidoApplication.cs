using ChallengeProsegur.Abtractions;
using ChallengeProsegur.Application.Abstractions;
using ChallengeProsegur.Entities.Model;
using ChallengeProsegur.Repository.Abstractions;
using ChallengeProsegur.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Application.Implementations
{
    public class PedidoApplication : Application<Pedido> , IPedidoApplication
    {
        
        IPedidoRepository _pedidoRepository;

        public PedidoApplication(IPedidoRepository pedidoRepository)
                : base(pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public  async Task<IList<Pedido>> GetPedidosActivosbyId(int Id)
        {
            return await _pedidoRepository.GetPedidosActivosbyId(Id);
        }


    }
}
