using ChallengeProsegur.Abtractions;

namespace ChallengeProsegur.Entities.Model
{
    public class Usuarios : Entity
    {
        public string Nombre { get; set; }
        public string InformacionContacto { get; set; }
        public string Direccion { get; set; }

        // Relación con pedidos
        public List<Pedido> Pedidos { get; set; }
    }
}