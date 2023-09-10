using ChallengeProsegur.Shared.Abtractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Shared.Domain
{

    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
