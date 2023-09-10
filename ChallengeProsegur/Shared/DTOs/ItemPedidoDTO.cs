using ChallengeProsegur.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Shared.DTOs
{
    public class ItemPedidoDTO : Entity
    {
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int TiempoRealizacion { get; set; }
        public decimal Precio { get; set; }
        public decimal Impuestos { get; set; }

        // Relación con Pedido
        public int PedidoId { get; set; }
        public PedidoDTO Pedido { get; set; }

        // Relación con Producto
        public int ProductoId { get; set; }
        public ProductoDTO Producto { get; set; }
    }

}
