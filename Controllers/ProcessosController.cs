using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBA_API_CORE.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EBA_API_CORE.Controllers
{
   
    public class ProcessosController : ControllerBase
    {
        [AcceptVerbs("GET")]
        [Route("GeraJsonProcesso/{parametros}")]
        public string GeraJsonProcesso(string parametros)
         {
            string retorno = string.Empty;
            
            Andamentos andamentos = new Andamentos();
            Documentos documentos = new Documentos();
            Partes partes = new Partes();
            Prazos prazos = new Prazos();

            if (parametros != string.Empty)
            {
                string[] pRecebidos = parametros.Split('|');

                /*
                 * ${Processo} ok
                 * ${OrgaoJulgador} ok
                 * ${Autuacao} ok dt Cadastro
                 * ${Cliente} ok : réu?
                 * ${Area} --
                 * ${Assunto}
                 * ${Polopassivo}|${TipoOutraParte}|${PoloAtivo}|${PAcpfCnpj}|${PAEndereco}|${ValorCausa}|${AndamentosProcesso}|${DataAudiencia}|${HoraAudiencia}|${TipoAudiencia}|${ValorComplementar01}|${PAAdvogado}|${Magistrado}|${Link}|${oab}|${ufoab}
                 * 
                 * 
                 */



                API max = new API();
                max.AdvogadoResponsavel = "";
                max.AdvogadoResponsavelEstado = "";



                andamentos.Cobravel = "";
                andamentos.DtAndamento = "";
                andamentos.DtCadastro = "";
                andamentos.TextoAndamento = "";
                andamentos.TipoAndamento = "";
                andamentos.UserCadastro = "";

                max.Andamentos = new List<Andamentos>();

                max.Andamentos.Add(andamentos);
                max.Citacao = "";
                max.CNPJCliente = "";
                max.CNPJCorrespondente = "";
                max.Comarca = pRecebidos[1].Trim().Length > 0 ? pRecebidos[1].Trim() : "";
                max.Competencia = pRecebidos[1].Trim().Length > 0 ? pRecebidos[1].Trim() : "";
                max.ControleCliente = "";
                max.Correspondente = "";


                documentos.AccessKeyID = "";
                documentos.BucketName = "";
                documentos.DtCadastro = "";
                documentos.HostFTP = "";
                documentos.NomeArquivo = "";
                documentos.NomeArquivoWeb = "";
                documentos.Pasta = "";
                documentos.PastaFTP = "";
                documentos.Region = "";
                documentos.SecretAccessKeyID = "";
                documentos.SenhaFTP = "";
                documentos.TipoDocumento = "";
                documentos.UserCadastro = "";
                documentos.UsuarioFTP = "";

                max.Documentos = new List<Documentos>();
                max.Documentos.Add(documentos);

                max.DtCadastro = DateTime.Now.ToShortDateString().Trim();
                max.DtCitacao = "";
                max.DtDistribuicao = pRecebidos[2].Trim().Length > 0 ? pRecebidos[2].Trim() : "";
                max.DtTerceirizacao = "";
                max.MotivoEstrategico = "";
                max.NomeCliente = "";
                max.Nucleo = "";
                max.NumProcesso = (pRecebidos[0].Trim().Length > 0 ? pRecebidos[0].Trim() : "");
                max.NumProcessoCNJ = (pRecebidos[0].Trim().Length > 0 ? pRecebidos[0].Trim() : "");
                max.NumProcessoNovo = (pRecebidos[0].Trim().Length > 0 ? pRecebidos[0].Trim() : "");
                max.OABAdvogadoResponsavel = "";
                max.Observacao = "";



                partes.AdvParteContraria = "";
                partes.Bairro = "";
                partes.CEP = "";
                partes.Cidade = "";
                partes.Cliente = "";
                partes.Complemento = "";
                partes.DocParte = "";
                partes.DtNascimento = "";
                partes.Email = "";
                partes.Endereco = "";
                partes.Filiacao = "";
                partes.NomeParte = "";
                partes.NumEndereco = "";
                partes.OABAdvParteContraria = "";
                partes.Telefone = "";
                partes.TipoParte = "";
                partes.UFCidade = "";
                partes.UFOABAdvParteContraria = "";

                max.Partes = new List<Partes>();
                max.Partes.Add(partes);


                prazos.DescPrazo = "";
                prazos.DtCadastro = "";
                prazos.DtPrazo = "";
                prazos.DtPublicacao = "";
                prazos.HoraAudiencia = "";
                prazos.LocalAudiencia = "";
                prazos.Peremptorio = "";
                prazos.TipoAudiencia = "";
                prazos.TipoPrazo = "";
                prazos.UserCadastro = "";

                max.Prazos = new List<Prazos>();
                max.Prazos.Add(prazos);

                max.ProcEletronico = "";
                max.ProcEstrategico = "";
                max.Segmento = "";
                max.TipoAcao = "";
                max.UFComarca = "";
                max.UserCadastro = "";
                max.ValorCausa = "";
                max.Vara = "";


                retorno = JsonConvert.SerializeObject(max);
            }


            return retorno;
        }
    }
}
