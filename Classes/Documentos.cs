using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBA_API_CORE.Classes
{
    public class Documentos
    {
        public string Pasta { get; set; }
        public string TipoDocumento { get; set; }
        public string NomeArquivo { get; set; }
        public string NomeArquivoWeb { get; set; }
        public string DtCadastro { get; set; }
        public string UserCadastro { get; set; }
        public string AccessKeyID { get; set; }
        public string SecretAccessKeyID { get; set; }
        public string Region { get; set; }
        public string BucketName { get; set; }
        public string HostFTP { get; set; }
        public string UsuarioFTP { get; set; }
        public string SenhaFTP { get; set; }
        public string PastaFTP { get; set; }
    }
}
