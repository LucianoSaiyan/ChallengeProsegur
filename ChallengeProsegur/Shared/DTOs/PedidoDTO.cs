using ChallengeProsegur.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Shared.DTOs
{
    public class PedidoDTO : Entity
    {
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }

        // Relación con Usuario
        //public int UsuarioId { get; set; }

        //public Usuarios Usuario { get; set; }

        // Relación con ítems del pedido
        //public List<ItemPedido> ItemsPedido { get; set; }
    }


}
