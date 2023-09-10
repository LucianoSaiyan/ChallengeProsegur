using ChallengeProsegur.Abtractions;

namespace ChallengeProsegur.Entities.Model
{
    public class Pedido : Entity
    {
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }

        // Relación con Usuario
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; }

        // Relación con ítems del pedido
        public List<ItemPedido> ItemsPedido { get; set; }

        //de estado de pedido se podria hacer una entidad nueva 
        enum EstadoPedido
        {
            En_Proceso,
            En_Cocina,
            Proceso_de_Elaborado,
            Terminado,
            Entregado
        }
    }
}