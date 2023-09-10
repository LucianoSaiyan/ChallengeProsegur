using ChallengeProsegur.Entities.Model;
using ChallengeProsegur.Shared;
using ChallengeProsegur.Shared.Domain;
using ChallengeProsegur.Shared.Helpers;
using ChallengeProsegur.Shared.Mappers;
using ChallengeProsegur.Shared.Validations;
using ChallengeProsegurClient.Helpers;
using System.Collections.Generic;
using System.Reflection;

namespace ChallengeProsegur.Test
{
    [TestClass]
    public class Usuario_UnitTest
    {
        string pathresponse = @"Files\Usuarios\ResponseGetUsuarios.json";
        string RequestGetUsuariosDTO = @"Files\Usuarios\RequestGet{0}.json";
        string RequestAddOKUsuariosDTO = @"Files\Usuarios\RequestAddOK{0}.json";
        string RequestAddErrorUsuariosDTO = @"Files\Usuarios\RequestAddError{0}.json";
        string RequestUpdateOKUsuariosDTO = @"Files\Usuarios\RequestUpdateOK{0}.json";
        string RequestUpdateErrorUsuariosDTO = @"Files\Usuarios\RequestUpdateError{0}.json";
        const string ResponseGetUsuariosDTO = @"Files\Usuarios\ResponseGet{0}.json";
        public void Initialize()
        {

        }

        #region Validations Add

        [TestMethod]
        public void Validations_OK_Usuarios_Add_Method_Test()
        {
            string Mock_RequestAddUsuarios = File.ReadAllText(string.Format(RequestAddOKUsuariosDTO, nameof(UsuariosDTO)));
            UsuariosDTO Mock_ResponseGetUsuarios_Deserialized = Methods.genericDeserializerObject<UsuariosDTO>(Mock_RequestAddUsuarios);

            #region Validaciones
            Tuple<bool, string> validateuser = UsuariosValidations.
                            validateusuarios(Mock_ResponseGetUsuarios_Deserialized, EnumsHelpers.Operacion.Insert);

            Assert.AreEqual(false, validateuser.Item1);
            #endregion
        }

        [TestMethod]
        public void Validations_Error_Usuarios_Add_Method_Test()
        {
            string Mock_RequestAddUsuarios = File.ReadAllText(string.Format(RequestAddErrorUsuariosDTO, nameof(UsuariosDTO)));
            UsuariosDTO Mock_ResponseGetUsuarios_Deserialized = Methods.genericDeserializerObject<UsuariosDTO>(Mock_RequestAddUsuarios);

            #region Validaciones
            Tuple<bool, string> validateuser = UsuariosValidations.
                            validateusuarios(Mock_ResponseGetUsuarios_Deserialized, EnumsHelpers.Operacion.Insert);

            Assert.AreEqual(true, validateuser.Item1);
            #endregion
        }

        #endregion

        [TestMethod]
        public void Validations_Ok_Usuarios_Update_Method_Test()
        {
            string Mock_ResponseGetUsuarios = File.ReadAllText(string.Format(RequestUpdateOKUsuariosDTO, nameof(UsuariosDTO)));
            UsuariosDTO Mock_ResponseGetUsuarios_Deserialized = Methods.genericDeserializerObject<UsuariosDTO>(Mock_ResponseGetUsuarios);

            #region Validaciones
            Tuple<bool, string> validateuser = UsuariosValidations.
                            validateusuarios(Mock_ResponseGetUsuarios_Deserialized, EnumsHelpers.Operacion.Update);

            Assert.AreEqual(false, validateuser.Item1);
            #endregion
        }

        [TestMethod]
        public void Validations_Usuarios_Null_Method_Test()
        {
            
            #region Validaciones
            Tuple<bool, string> validateuser = UsuariosValidations.
                            validateusuarios(null, EnumsHelpers.Operacion.Update);

            Assert.AreEqual(true, validateuser.Item1);
            #endregion
        }

        [TestMethod]
        public void Validations_Error_Usuarios_Update_Method_Test()
        {
            string Mock_ResponseGetUsuarios = File.ReadAllText(string.Format(RequestUpdateErrorUsuariosDTO, nameof(UsuariosDTO)));
            UsuariosDTO Mock_ResponseGetUsuarios_Deserialized = Methods.genericDeserializerObject<UsuariosDTO>(Mock_ResponseGetUsuarios);

            #region Validaciones
            Tuple<bool, string> validateuser = UsuariosValidations.
                            validateusuarios(Mock_ResponseGetUsuarios_Deserialized, EnumsHelpers.Operacion.Update);

            Assert.AreEqual(true, validateuser.Item1);
            #endregion
        }

        [TestMethod]
        public void ResponseGetUsuariosMethod_Test()
        {
            string Mock_ResponseGetUsuarios = File.ReadAllText(pathresponse);
            UsuariosDTO[] Mock_ResponseGetUsuarios_Deserialized = Methods.genericDeserializerObject<ResponseService<List<UsuariosDTO>>>(Mock_ResponseGetUsuarios).Data.ToArray();
            Assert.IsNotNull(Mock_ResponseGetUsuarios_Deserialized);

        }

        [TestMethod]
        public void ResponseGetUsuarios_MapperToDTO_Method_Test()
        {
            //string file = File.ReadAllText(string.Format(ResponseGetUsuariosDTO, nameof(UsuariosDTO)));
            //string Mock_ResponseGetUsuarios = File.ReadAllText(file);

            List<UsuariosDTO> MapperToDTO
                   = MethodsHelpersShared.MapListDTO<Usuarios, UsuariosDTO>(listUsuarios_Mock(10));

            Assert.IsNotNull(MapperToDTO);
        }

        List<Usuarios> listUsuarios_Mock(int cantidad)
        {
            List<Usuarios> listUsuarios = new List<Usuarios>();
            for (int i = 0; i < cantidad; i++)
            {
                Usuarios usuarios = new Usuarios
                {
                    Id = i,
                    Nombre = $"Nombre {i}",
                    Direccion = $"Direccion {i}",
                    InformacionContacto = $"InformacionContacto {i}",
                    Pedidos = List_Pedidos_Mock(3)
                };
                listUsuarios.Add(usuarios);
            }
            return listUsuarios;
        }

        List<Pedido> List_Pedidos_Mock(int cantidad)
        {
            List<Pedido> listpedido = new List<Pedido>();
            for (int i = 0; i < cantidad; i++)
            {
                Pedido pedido = new Pedido()
                {
                    Id = i,
                    Estado = "En Proceso",
                    FechaCreacion = DateTime.Now
                };
                listpedido.Add(pedido);
            }
            return listpedido;
            //return new List<Pedido> { 
            //new Pedido() 
            //    { Id = 1 , Estado = "En Proceso" } }; 
        }




    }
}