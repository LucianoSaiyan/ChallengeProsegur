using ChallengeProsegur.Entities.Model;
using ChallengeProsegur.Shared.Domain;
using ChallengeProsegur.Shared.DTOs;
using ChallengeProsegur.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Shared.Mappers
{
    public static class UsuariosMapper
    {

        public static List<UsuariosDTO> MapListUsuarioToUsuarioDTO(List<Usuarios> listUsuarios)
        {
            List<UsuariosDTO> listdto = new List<UsuariosDTO>();
            foreach (Usuarios usuarios in listUsuarios)
            {
                UsuariosDTO _usuariosDTO = new UsuariosDTO()
                {
                    Id = usuarios.Id,
                    Direccion = usuarios.Direccion,
                    InformacionContacto = usuarios.InformacionContacto,
                    Nombre = usuarios.Nombre,
                    Pedidos = MethodsHelpersShared.MapListDTO<Pedido, PedidoDTO>(usuarios.Pedidos)
                };
                listdto.Add(_usuariosDTO);
            }
            return listdto;
        }

        public static List<Usuarios> MapListUsuarioDTOToUsuario(List<UsuariosDTO> listUsuarios)
        {
            List<Usuarios> listdto = new List<Usuarios>();
            foreach (UsuariosDTO usuarios in listUsuarios)
            {
                Usuarios _usuariosDTO = new Usuarios()
                {
                    Id = usuarios.Id,
                    Direccion = usuarios.Direccion,
                    InformacionContacto = usuarios.InformacionContacto,
                    Nombre = usuarios.Nombre,
                    Pedidos = MethodsHelpersShared.MapListDTO<PedidoDTO, Pedido>(usuarios.Pedidos)
                };
                listdto.Add(_usuariosDTO);
            }
            return listdto;
        }

        public static Usuarios MapUsuarioDTOToUsuario(UsuariosDTO Usuario)
        {
            Usuarios _usuariosDTO = new Usuarios()
            {
                Id = Usuario.Id,
                Direccion = Usuario.Direccion,
                InformacionContacto = Usuario.InformacionContacto,
                Nombre = Usuario.Nombre,
                Pedidos = MethodsHelpersShared.MapListDTO<PedidoDTO, Pedido>(Usuario.Pedidos)
            };
            return _usuariosDTO;
        }

        public static UsuariosDTO MapToUsuarioUsuarioDTO(Usuarios Usuario)
        {
            UsuariosDTO _usuariosDTO = new UsuariosDTO()
            {
                Id = Usuario.Id,
                Direccion = Usuario.Direccion,
                InformacionContacto = Usuario.InformacionContacto,
                Nombre = Usuario.Nombre,
                Pedidos = MethodsHelpersShared.MapListDTO<Pedido,PedidoDTO> (Usuario.Pedidos)
            };
            return _usuariosDTO;
        }

    }
}
