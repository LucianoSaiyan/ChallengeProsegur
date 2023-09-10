using ChallengeProsegur.Abtractions;
using ChallengeProsegur.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.DataAccess.Abstractions
{
    public interface IUsuariosDbContext : IDbContext<Usuarios>
    {        
        Task<Usuarios> GetUserbyIdWithPedidos(int id);
        Task<bool> FindUser(int id);
    }
}
