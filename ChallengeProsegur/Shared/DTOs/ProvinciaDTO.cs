using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeProsegur.Shared.Domain
{

    public class ProvinciaDTO  : Entity
    {
        public string Nombre { get; set; }
        public decimal ImpuestoAplicable { get; set; }
    }

}
