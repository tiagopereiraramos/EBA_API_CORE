using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBA_API_CORE.Classes
{
    public class API
    {
        //Siglas R - não vem pela WDG
        public string AdvogadoResponsavel { get; set; }
        //Não tem 
        public string OABAdvogadoResponsavel { get; set; }
        public string AdvogadoResponsavelEstado { get; set; }
        //Wdg Não coleta - H pós  campo sim ou não 
        public string Citacao { get; set; }
        //Wdg Não coleta - H pós -- Observação --SQL do MAX
        public string CNPJCliente { get; set; }
        public string CNPJCorrespondente { get; set; }
        //WDG Coleta --De: Para dentro do MAX coluna D
        public string Comarca { get; set; }
        //WDG Coleta Coluna D
        public string Competencia { get; set; }
        //Campo MAX
        public string ControleCliente { get; set; }
        //Campo MAX
        public string Correspondente { get; set; }
        //WDG Coleta Coluna G
        public string DtDistribuicao { get; set; }
        //WDG Datetime NOW - Data do dia 
        public string DtCadastro { get; set; }
        //WDG não preenche H
        public string DtCitacao { get; set; }
        //Campo MAX
        public string DtTerceirizacao { get; set; }
        //Campo MAX - 
        public string MotivoEstrategico { get; set; }
        //WDG Coleta - Pós Cadastro -- T
        public string NomeCliente { get; set; }
        //WDG Não preenche CX - Pós Cadastro
        public string Nucleo { get; set; }
        //WDG Não coleta -- C
        public string NumProcesso { get; set; }
        //WDG Não coleta -- C
        public string NumProcessoCNJ { get; set; }
        //WDG Não coleta -- C
        public string NumProcessoNovo { get; set; }
        //WDG não coleta Q
        public string Observacao { get; set; }
        //WDG coleta BT 
        public string ProcEletronico { get; set; }
        //Não usa
        public string ProcEstrategico { get; set; }
        //Campo complementar pós cadastro 
        public string Segmento { get; set; }
        //WDG Não coleta E 
        public string TipoAcao { get; set; }
        //WDG D
        public string UFComarca { get; set; }
        //Sigla EBe - B
        public string UserCadastro { get; set; }
        //WDG Coleta AD
        public string ValorCausa { get; set; }
        //Coluna D - 
        public string Vara { get; set; }

        public List<Partes> Partes { get; set; }
        public List<Andamentos> Andamentos { get; set; }

        public List<Prazos> Prazos { get; set; }
        public List<Documentos> Documentos { get; set; }
    }
}
