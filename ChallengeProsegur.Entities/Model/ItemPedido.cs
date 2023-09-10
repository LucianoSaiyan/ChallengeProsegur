using ChallengeProsegur.Abtractions;

namespace ChallengeProsegur.Entities.Model
{
    public class ItemPedido : Entity
    {
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int TiempoRealizacion { get; set; }
        public decimal Precio { get; set; }
        public decimal Impuestos { get; set; }

        // Relación con Pedido
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        // Relación con Producto
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}