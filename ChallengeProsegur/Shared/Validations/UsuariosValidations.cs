using ChallengeProsegur.Shared.Domain;
using ChallengeProsegur.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Shared.Validations
{
    public static class UsuariosValidations
    {
        static string mensaje = "El {0} no puede ser nulo o vacio";
        public static Tuple<bool, string> validateusuarios(UsuariosDTO usuarioDTO, EnumsHelpers.Operacion operacion)
        {
            bool valid = false;
            StringBuilder Errormessage = new StringBuilder();

            if (usuarioDTO == null)
                return new Tuple<bool, string>(true, "EL USUARIO NO PUEDE SER NULL");

            if (EnumsHelpers.Operacion.Update == operacion)
            {
                if (usuarioDTO.Id > 0)
                    Errormessage.AppendLine(string.Format("PARA ACTUALIZAR UN USUARIO DEBE BRINDAR UN ID", "Id"));
            }


            if (String.IsNullOrEmpty(usuarioDTO.Nombre))
            {
                Errormessage.AppendLine(string.Format(mensaje.ToUpper(), "Usuario"));
                valid = true;
            }

            if (String.IsNullOrEmpty(usuarioDTO.Direccion))
            {
                Errormessage.AppendLine(string.Format(mensaje, "Direccion"));
                valid = true;
            }

            if (String.IsNullOrEmpty(usuarioDTO.InformacionContacto))
            {
                Errormessage.AppendLine(string.Format(mensaje, "InformacionContacto"));
                valid = true;
            }

            return new Tuple<bool, string>(valid, Errormessage.ToString());
        }


    }
}
