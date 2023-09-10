using ChallengeProsegur.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Shared.DTOs
{
    public class ProductoDTO : Entity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TiempoRealizacion { get; set; }
        public decimal PrecioBase { get; set; }

        // Relación con Materiales
        public List<MaterialDTO> Materiales { get; set; }
    }
}
