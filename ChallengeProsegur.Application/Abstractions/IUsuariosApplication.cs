using ChallengeProsegur.Abtractions;
using ChallengeProsegur.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Application.Abstractions
{
    public interface IUsuariosApplication : IApplication<Usuarios>
    {
        Task<Usuarios> GetUserbyIdWithPedidos(int id);
        Task<bool> FindUser(int id);
    }
}
