using ReclamaPoa2013.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReclamaPoa2013
{
    public partial class Reclamacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<ReclamacaoViewModel> GetReclamacoes()
        {
            ReclamaPoaEntities _db = new ReclamaPoaEntities();

            String aberta = "label label-warning";
            String resolvida = "label label-success";
            String encerrada = "label label-default";

            IQueryable<ReclamacaoViewModel> query = from r in _db.Reclamacoes
                                                    select new ReclamacaoViewModel
                                                    {
                                                        ReclamacaoId = r.ReclamacaoId,
                                                        Titulo = r.Titulo,
                                                        Descricao = r.Descricao,
                                                        Data = r.Data,
                                                        Endereco = r.Endereco,
                                                        Situacao = r.Situacao.ToString(),
                                                        Bairro = r.Bairro.Nome,
                                                        Categoria = r.Categoria.Nome,
                                                        UrlImagem = r.UrlImagem
                                                    };

            foreach (ReclamacaoViewModel r in query)
            {
                if (r.Situacao == "Encerrada")
                {
                    r.SituacaoClass = encerrada;
                }
                else if (r.Situacao == "Resolvida")
                {
                    r.SituacaoClass = resolvida;
                }
                else
                {
                    r.SituacaoClass = aberta;
                }
            }




            return query;
        }
    }
}