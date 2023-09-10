using ChallengeProsegur.DataAccess.Abstractions;
using ChallengeProsegur.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.DataAccess.Implementations
{
    public class UsuariosDbContext : DbContext<Usuarios>, IUsuariosDbContext
    {
        protected ApiDbContext _ctx;
        public UsuariosDbContext(ApiDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        #region Implemented Methods

        public async Task<Usuarios> GetUserbyIdWithPedidos(int id)
        {
            var rr = GetById(id).Pedidos;            
            return await GetByIdAsync(id);
        }
        public async Task<bool> FindUser(int id)
        {
            bool result = false;
            Usuarios entity = _ctx.Usuarios.Find(id);
            //evalua distinto de null para liberar la entidad del context
            if (entity != null)
            {
                _ctx.Entry(result).State = EntityState.Detached;
                 result = true;
            }
            return result;
        }

        #endregion

    }
}
