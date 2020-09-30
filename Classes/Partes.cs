using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBA_API_CORE.Classes
{
    public class Partes
    {
        //WDG Coleta -- Y
        public string NomeParte { get; set; }
        //WDG Coleta -- AB
        public string DocParte { get; set; }
        //Não coleta --Z
        public string DtNascimento { get; set; }
        //Não Coleta --AA
        public string Filiacao { get; set; }
        //-- AC
        public string Endereco { get; set; }
        public string NumEndereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UFCidade { get; set; }
        public string CEP { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        //Coluna X WDG Coleta
        public string TipoParte { get; set; }
        //Perguntar MAX
        public string Cliente { get; set; }
        //WDG Coleta Nome - CQ
        public string AdvParteContraria { get; set; }
        //WDG Coleta -- CR
        public string OABAdvParteContraria { get; set; }
        //WDG Coleta -- Cs
        public string UFOABAdvParteContraria { get; set; }
    }
}
