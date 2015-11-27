using ReclamaPoa2013.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReclamaPoa2013
{
    public partial class Bairros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReclamaPoaEntities _db = new ReclamaPoaEntities();

            // GridView1.DataSource = _db.Bairros.ToList();
            // GridView1.DataBind();


            //DropDownList1.DataSource = _db.Bairros.ToList();
            //DropDownList1.DataTextField = "Nome";
            //DropDownList1.DataBind();
            
        }
        public IQueryable<ReclamacaoViewModel> GetReclamacoes()
        {
            ReclamaPoaEntities _db = new ReclamaPoaEntities();

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
            return query;
        }
    }
}