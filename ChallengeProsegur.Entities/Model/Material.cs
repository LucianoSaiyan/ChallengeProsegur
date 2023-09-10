using ChallengeProsegur.Abtractions;

namespace ChallengeProsegur.Entities.Model
{
    public class Material : Entity
    {
        public string Nombre { get; set; }
        public int CantidadDisponible { get; set; }

        // Relación con Producto
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}