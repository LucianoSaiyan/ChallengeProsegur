
using ChallengeProsegur.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Shared.DTOs
{

    public class MaterialDTO : Entity
    {
        public string Nombre { get; set; }
        public int CantidadDisponible { get; set; }

        // Relación con Producto
        public int ProductoId { get; set; }
        public ProductoDTO Producto { get; set; }
    }

}
