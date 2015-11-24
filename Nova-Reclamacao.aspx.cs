using ReclamaPoa2013.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReclamaPoa2013
{
    public partial class Nova_Reclamacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReclamaPoaEntities _db = new ReclamaPoaEntities();


                var bairros = from b in _db.Bairros
                              orderby b.Nome
                              select b;

                ddlBairros.DataSource = bairros.ToList();
                ddlBairros.DataTextField = "Nome";
                ddlBairros.DataValueField = "BairroId";
                ddlBairros.DataBind();


                var categorias = from c in _db.Categorias
                                 select c;

                rblCategorias.DataSource = categorias.ToList();
                rblCategorias.DataTextField = "Nome";
                rblCategorias.DataValueField = "CategoriaId";
                rblCategorias.DataBind();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ReclamaPoaEntities _db = new ReclamaPoaEntities();

            Reclamacao reclamacao = new Reclamacao();

            reclamacao.Titulo = txtNomeRec.Text;
            reclamacao.Descricao = txtDescRec.Text;

            int idBairro;
            if (Int32.TryParse(ddlBairros.SelectedValue, out idBairro))
            {
                Bairro bairro = (from b in _db.Bairros
                                 where b.BairroId == idBairro
                                 select b).First();

                reclamacao.Bairro = bairro;
            }

            int idCategoria;
            if (Int32.TryParse(rblCategorias.SelectedValue, out idCategoria))
            {
                Categoria categoria = (from c in _db.Categorias
                                       where c.CategoriaId == idCategoria
                                       select c).First();

                reclamacao.Categoria = categoria;
            }

            reclamacao.Data = DateTime.Now.Date;
            reclamacao.Endereco = txtEndereco.Text;
            reclamacao.Situacao = Situacao.Aberta;
            reclamacao.UrlImagem = txtUrlImagem.Text;
            reclamacao.Usuario = Context.User.Identity.Name;


            _db.Reclamacoes.Add(reclamacao);
            _db.SaveChanges();

            Response.Redirect("Nova-Reclamacao.aspx");
        }
    }
}