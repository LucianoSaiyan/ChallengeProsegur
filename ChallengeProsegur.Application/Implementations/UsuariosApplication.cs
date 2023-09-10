using ChallengeProsegur.Abtractions;
using ChallengeProsegur.Application.Abstractions;
using ChallengeProsegur.Entities.Model;
using ChallengeProsegur.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Application.Implementations
{
    public class UsuariosApplication : Application<Usuarios>, IUsuariosApplication
    {
        IUsuarioRepository _usuarioRepository;
        //esta inyeccion se encuentra en el "contenedor"

        public UsuariosApplication(IUsuarioRepository usuarioRepository)
                            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<Usuarios> GetUserbyIdWithPedidos(int id)
        {
            return _usuarioRepository.GetUserbyIdWithPedidos(id);
        }

        #region Methods Repository

        #region Delete

        public int Delete(int id)
        {
            return _usuarioRepository.Delete(id);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _usuarioRepository.DeleteAsync(id);
        }

        #endregion

        #region GetAll

        public IList<Usuarios> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public async Task<IList<Usuarios>> GetAllAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        #endregion

        #region GetById

        public Usuarios GetById(int id)
            => _usuarioRepository.GetById(id);
        
        public async Task<Usuarios> GetByIdAsync(int id)
            => await _usuarioRepository.GetByIdAsync(id);
        
        #endregion

        public async Task<bool> FindUser(int id)
            => await _usuarioRepository.FindUser(id);

        #endregion
    }
}
