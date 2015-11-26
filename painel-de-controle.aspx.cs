using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReclamaPoa2013.Models;

namespace ReclamaPoa2013
{
    public partial class painel_de_controle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReclamaPoaEntities _db = new ReclamaPoaEntities();
            int cont = _db.Reclamacoes.Count();
            lblTotal.Text = cont.ToString();

            if (!IsPostBack)
            {
                //ReclamaPoaEntities _db = new ReclamaPoaEntities();

                ddlBairros.DataSource = _db.Bairros.ToList();
                ddlBairros.DataTextField = "Nome";
                ddlBairros.DataValueField = "BairroId";
                ddlBairros.DataBind();

                ddlBairros.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlBairros.SelectedIndex = 0;

                ddlCategorias.DataSource = _db.Categorias.ToList();
                ddlCategorias.DataTextField = "Nome";
                ddlCategorias.DataValueField = "CategoriaId";
                ddlCategorias.DataBind();

                ddlCategorias.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCategorias.SelectedIndex = 0;
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReclamaPoaEntities _db = new ReclamaPoaEntities();

            int bairroId = int.Parse(ddlBairros.SelectedValue);
            int categoriaId = int.Parse(ddlCategorias.SelectedValue);
            DateTime inicio = calInicio.SelectedDate;
            DateTime fim = calFim.SelectedDate;


            var query = _db.Reclamacoes.Where(r => r.Bairro.BairroId == bairroId 
                && r.Categoria.CategoriaId == categoriaId
                && r.Data >= inicio && r.Data <= fim).Count();

            lblSubTotal.Text = query.ToString();
        }

        //public IQueryable<Categoria> getCategorias()
        //{
        //    ReclamaPoaEntities _db = new ReclamaPoaEntities();
        //    IQueryable<Categoria> query = _db.Categorias;
        //    return query;
        //}

        //public IQueryable<Bairro> getBairros()
        //{
        //    ReclamaPoaEntities _db = new ReclamaPoaEntities();
        //    IQueryable<Bairro> query = _db.Bairros;
        //    return query;
        //}


    }
}