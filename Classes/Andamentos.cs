using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBA_API_CORE.Classes
{
    public class Andamentos
    {
        //Fase e complemento de fase -- AF e AG
        public string TipoAndamento { get; set; }
        public string DtAndamento { get; set; }
        //WDG Coleta AH
        public string TextoAndamento { get; set; }
        public string Cobravel { get; set; }
        //Coluna -- AE
        public string DtCadastro { get; set; }
        public string UserCadastro { get; set; }
    }
}
