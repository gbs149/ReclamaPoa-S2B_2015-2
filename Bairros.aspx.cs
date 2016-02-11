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

        IQueryable<ReclamacaoViewModel> query = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ReclamaPoaEntities _db = new ReclamaPoaEntities();
                DropDownList1.DataSource = _db.Bairros.ToList();
                DropDownList1.DataTextField = "Nome";
                DropDownList1.DataValueField = "BairroId";
                DropDownList1.DataBind();
            }
        }

        public IQueryable<ReclamacaoViewModel> GetReclamacoes()
        {

            // int filtro = int.Parse(DropDownList1.SelectedValue);
            string filtro = DropDownList1.SelectedItem.ToString();
            DateTime inicio = calInicio.SelectedDate;
            DateTime fim = calFim.SelectedDate;
            ReclamaPoaEntities _db = new ReclamaPoaEntities();

            query = from r in _db.Reclamacoes
                    where filtro == r.Bairro.Nome && r.Data >= inicio && r.Data <= fim
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


            lvbairros.DataBind();
            return query;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetReclamacoes();
        }
    }
}