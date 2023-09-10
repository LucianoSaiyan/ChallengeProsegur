using ChallengeProsegur.Application.Abstractions;
using ChallengeProsegur.Entities.Model;
using ChallengeProsegur.Shared;
using ChallengeProsegur.Shared.Domain;
using ChallengeProsegur.Shared.DTOs;
using ChallengeProsegur.Shared.Helpers;
using ChallengeProsegur.Shared.Mappers;
using ChallengeProsegur.Shared.Validations;
using Microsoft.AspNetCore.Authorization;
//using ChallengeProsegur.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations.Rules;

namespace ChallengeProsegur.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        #region Variables and Properties
        private readonly ILogger<WeatherForecastController> _logger;
        IApplication<Usuarios> _users;
        IApplication<Pedido> _pedido;
        private readonly IUsuariosApplication _usuariosapp;
        private readonly IPedidoApplication _pedidosapp;
        #endregion

        #region Constructor

        public UsuariosController(IApplication<Usuarios> users
                                    , IApplication<Pedido> pedido
                                    , IUsuariosApplication usuariosapp,
                                        IPedidoApplication pedidosapp)
        {
            _users = users;
            _pedido = pedido;
            _usuariosapp = usuariosapp;
            _pedidosapp = pedidosapp;
        }


        #endregion

        #region Methods Http

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseService<List<UsuariosDTO>> responseService = new ResponseService<List<UsuariosDTO>>();
            try
            {
                #region Call Data

                //Get de Usuarios
                IList<Usuarios> listUsuarios = await _users.GetAllAsync();
                //se obtiene el id del usuario aunque hay que recorrer el de todos los usuarios
                //tambien puede hacerse un join y obtener los pedidos juntos
                foreach (var user in listUsuarios)
                {
                    //Pedidos de Usuario
                    IList<Pedido> pedido = await _pedidosapp.GetPedidosActivosbyId(user.Id);
                }

                #endregion

                #region Mappers
                List<UsuariosDTO> listdto = new List<UsuariosDTO>();
#if false
                //METODO DE MAPEO GENERICO, FALTO PULIRLO UN POCO
                 listdto = MethodsHelpersShared.MapListDTO<Usuarios, UsuariosDTO>((List<Usuarios>)listUsuarios); 
                listdto 
                    //= MethodsHelpersShared.MapListDTO<Usuarios, UsuariosDTO>((List<Usuarios>)listUsuarios); 
                //Dictionary<object, object> UsuariosDTODictionary = Methods.GetPropertiesandValues<UsuariosDTO>(jsonconvert);
#else   
                //pasar de entidad a dto
                listdto = UsuariosMapper.MapListUsuarioToUsuarioDTO((List<Usuarios>)listUsuarios);
#endif
                #endregion

                #region Response
                responseService.Data = listdto;
                responseService.Message = $"CANTIDAD DE REGISTROS {listdto.Count}";
                responseService.HttpResponseMessage.StatusCode = responseService.Data != null
                                                            ? System.Net.HttpStatusCode.OK
                                                            : System.Net.HttpStatusCode.NotFound;

                if (responseService.Data != null)
                    return Ok(responseService);
                else
                    return NotFound(responseService);
                #endregion
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return StatusCode(500, responseService);
            }

        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) return NotFound();

            ResponseService<Usuarios> responseService = new ResponseService<Usuarios>();
            try
            {
                //invocacion de Get by id de Users
                responseService.Data = await _users.GetByIdAsync(id);
                responseService.Message = "";
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.OK;
                if (responseService.Data != null)
                {
                    responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return Ok(responseService);
                }
                else
                {
                    responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    return NotFound(responseService);
                }
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return StatusCode(500, responseService);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UsuariosDTO usuarioDTO)
        {

            ResponseService<UsuariosDTO> responseService = new ResponseService<UsuariosDTO>();

            #region Validaciones
            var validateuser = UsuariosValidations.validateusuarios(usuarioDTO, EnumsHelpers.Operacion.Insert);
            //validaciones
            if (validateuser.Item1)
            {
                responseService.Data = usuarioDTO;
                responseService.Message = validateuser.Item2;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(responseService);
            }

            #endregion

            try
            {
                #region Mapper 

                Usuarios entity = UsuariosMapper.MapUsuarioDTOToUsuario(usuarioDTO);
                //MAPPER GENERICO QUE HAY QUE TERMINAR DE AJUSTAR
                //Usuarios entity = MethodsHelpersShared.Map<UsuariosDTO, Usuarios>(usuarioDTO);

                #endregion

                //INGRESA EL USUARIO  
                Tuple<int, Usuarios> entityret = await _users.SaveAsync(entity);

                UsuariosDTO entitydto = MethodsHelpersShared.Map<Usuarios, UsuariosDTO>(entityret.Item2);

                responseService.Data = entitydto;
                responseService.Message = $"SE INGRESARON {entityret.Item1} REGISTROS";
                if (entityret.Item1 > 0)
                {
                    responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.OK;
                    return Ok(responseService);
                }
                else
                {
                    responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return NotFound(responseService);
                }
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return StatusCode(500, responseService);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UsuariosDTO usuarioDTO)
        {

            ResponseService<UsuariosDTO> responseService = new ResponseService<UsuariosDTO>();
            #region Validaciones
            Tuple<bool, string> validateuser = UsuariosValidations.validateusuarios(usuarioDTO, EnumsHelpers.Operacion.Update);
            //validaciones
            if (validateuser.Item1)
            {
                responseService.Data = usuarioDTO;
                responseService.Message = validateuser.Item2;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(responseService);
            }
            #endregion

            try
            {
                #region Validate if User Exist

                var searchUserToUpdate = await _usuariosapp.FindUser(usuarioDTO.Id);

                if (!searchUserToUpdate)
                {
                    responseService.Data = usuarioDTO;
                    responseService.Message = "EL USUARIO QUE INTENTA ACTUALIZAR NO EXISTE";
                    responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return BadRequest(responseService);
                }

                #endregion

                #region Mapper 

                Usuarios entity = UsuariosMapper.MapUsuarioDTOToUsuario(usuarioDTO);

                #endregion

                //ACTUALIZAR EL USUARIO  
                int entityret = await _users.UpdateAsync(entity);
                //Tuple<int, Usuarios> entityret = await _users.UpdateReturnResultAsync(entity);
                UsuariosDTO entitydto = MethodsHelpersShared.Map<Usuarios, UsuariosDTO>(entity);
                //UsuariosDTO entitydto = MethodsHelpersShared.Map<Usuarios, UsuariosDTO>(entityret.Item2);

                responseService.Data = entitydto;
                responseService.Message = $"SE MODIFICARON {entityret} REGISTROS";
                if (entityret > 0)
                {
                    responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.OK;
                    return Ok(responseService);
                }
                else
                {
                    responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return NotFound(responseService);
                }
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return StatusCode(500, responseService);
            }
        }

        //[Authorize("DeletePolicy")]
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {

            ResponseService<int?> responseService = new ResponseService<int?>();

            try
            {
                #region Validate if User Exist

                var searchUserToUpdate = await _usuariosapp.FindUser(id);

                if (!searchUserToUpdate)
                {
                    responseService.Data = null;
                    responseService.Message = "EL USUARIO QUE INTENTA ELIMINAR NO EXISTE";
                    responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return BadRequest(responseService);
                }

                #endregion


                //ELIMINAR EL USUARIO  
                int entityret = await _users.DeleteAsync(id);
                //UsuariosDTO entitydto = MethodsHelpersShared.Map<Usuarios, UsuariosDTO>(entityret.Item2);

                responseService.Data = entityret;
                responseService.Message = $"SE MODIFICARON {entityret} REGISTROS";
                if (entityret > 0)
                {
                    responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.OK;
                    return Ok(responseService);
                }
                else
                {
                    responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return NotFound(responseService);
                }
            }
            catch (Exception ex)
            {
                responseService.Message = ex.Message;
                responseService.HttpResponseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return StatusCode(500, responseService);
            }
        }


        #endregion


    }
}