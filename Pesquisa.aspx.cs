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
    public partial class Pesquisa : System.Web.UI.Page
    {
        IQueryable<ReclamacaoViewModel> query = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReclamaPoaEntities _db = new ReclamaPoaEntities();
                ddlcategoria.DataSource = _db.Categorias.ToList();
                ddlbairro.DataSource = _db.Bairros.ToList();
                ddlcategoria.DataTextField = "Nome";
                ddlcategoria.DataValueField = "CategoriaId";
                ddlbairro.DataTextField = "Nome";
                ddlbairro.DataValueField = "BairroId";
                ddlcategoria.DataBind();
                ddlbairro.DataBind();
            }

        }

        public IQueryable<ReclamacaoViewModel> GetReclamacoes()
        {
            string filtro = ddlbairro.SelectedItem.ToString();
            string filtro2 = ddlcategoria.SelectedItem.ToString();
            DateTime inicio = calInicio.SelectedDate;
            DateTime fim = calFim.SelectedDate;

            ReclamaPoaEntities _db = new ReclamaPoaEntities();

            query = from r in _db.Reclamacoes
                    where r.Categoria.Nome == filtro2 && r.Bairro.Nome == filtro && r.Data >= inicio && r.Data <= fim 
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
            lvpesquisas.DataBind();
            return query;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetReclamacoes();
        }


    }
}