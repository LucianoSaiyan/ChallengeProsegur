using ChallengeProsegur.Entities.Model;
using ChallengeProsegur.Shared.DTOs;

namespace ChallengeProsegur.Shared.Domain
{
    #region Usuario

    public class UsuariosDTO : Entity
    {
        public UsuariosDTO()
        {
            Pedidos = new List<PedidoDTO>();
        }

        public string Nombre { get; set; }
        public string InformacionContacto { get; set; }
        public string Direccion { get; set; }

        // Relación con pedidos
        public List<PedidoDTO> Pedidos { get; set; }

        

    }

    #endregion

}
