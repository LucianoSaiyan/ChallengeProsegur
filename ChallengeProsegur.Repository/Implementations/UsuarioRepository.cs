using ChallengeProsegur.Abtractions;
using ChallengeProsegur.DataAccess.Abstractions;
using ChallengeProsegur.Entities.Model;
using ChallengeProsegur.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Repository.Implementations
{
    
    public class UsuarioRepository : Repository<Usuarios>, IUsuarioRepository
    {
        IUsuariosDbContext _ctx;

        public UsuarioRepository(IUsuariosDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<Usuarios> GetUserbyIdWithPedidos(int id)
                => await _ctx.GetUserbyIdWithPedidos(id);
        

        public async Task<bool> FindUser(int id)
                => await _ctx.FindUser(id);
            //return await _ctx.GetUserbyIdWithPedidos(id);
        

    }
}
