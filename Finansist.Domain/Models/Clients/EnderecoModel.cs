using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finansist.Domain.Models.Clients
{
    public class EnderecoModel
    {
        public String CEP { get;  set; } = null!;

        public String? Logradouro { get;  set; }

        public String? Bairro { get;  set; }

        public String? Complemento { get;  set; }

        public String? Localidade { get;  set; }

        public String? UF { get;  set; }

        public int? Numero { get;  set; }
    }
}