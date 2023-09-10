using ChallengeProsegur.Abtractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Application.Abstractions
{
    public interface IApplication<T> : ICrud<T>
    {

    }
}
