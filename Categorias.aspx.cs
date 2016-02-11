using ReclamaPoa2013.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReclamaPoa2013
{
    public partial class Categorias : System.Web.UI.Page
    {
        IQueryable<ReclamacaoViewModel> query = null;
        protected void Page_Load(object sender, EventArgs e)
        {        
            if (!IsPostBack)
            {
                ReclamaPoaEntities _db = new ReclamaPoaEntities();
                ddl.DataSource = _db.Categorias.ToList();
                ddl.DataTextField = "Nome";
                ddl.DataValueField = "CategoriaId";
                ddl.DataBind();
            }            
        }
        public IQueryable<ReclamacaoViewModel> GetReclamacoes()
        {
            string filtro = ddl.SelectedItem.ToString();
            DateTime inicio = calInicio.SelectedDate;
            DateTime fim = calFim.SelectedDate;

            ReclamaPoaEntities _db = new ReclamaPoaEntities();

            query = from r in _db.Reclamacoes
                    where filtro == r.Categoria.Nome && r.Data >= inicio && r.Data <= fim
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
            Lvcategorias.DataBind();
            return query;
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetReclamacoes();
        }       
    }
}