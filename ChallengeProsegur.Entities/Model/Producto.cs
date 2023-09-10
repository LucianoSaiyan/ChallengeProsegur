using ChallengeProsegur.Abtractions;

namespace ChallengeProsegur.Entities.Model
{
    public class Producto : Entity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TiempoRealizacion { get; set; }
        public decimal PrecioBase { get; set; }

        // Relación con Materiales
        public List<Material> Materiales { get; set; }
    }
}