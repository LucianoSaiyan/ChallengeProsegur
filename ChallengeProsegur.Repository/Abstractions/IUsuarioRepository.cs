using ChallengeProsegur.Abtractions;
using ChallengeProsegur.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Repository.Abstractions
{
    public interface IUsuarioRepository : IRepository<Usuarios>
    {
         
        Task<Usuarios> GetUserbyIdWithPedidos(int id);
        Task<bool> FindUser(int id);
    }
}
