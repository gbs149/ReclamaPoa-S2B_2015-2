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
            int totalReclamacoes = _db.Reclamacoes.Count();
            lblTotal.Text = totalReclamacoes.ToString();

            if (!IsPostBack)
            {
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

            int totalReclamacoes = _db.Reclamacoes.Count();
            int categoriaId;
            int bairroId;
            DateTime inicio;
            DateTime fim;

            // filtra por categoria, bairro e periodo
            if (int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
                && int.TryParse(ddlBairros.SelectedValue, out bairroId)
                && (DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                var query = _db.Reclamacoes.Where(r => r.Categoria.CategoriaId == categoriaId
                    && r.Bairro.BairroId == bairroId
                    && (r.Data >= inicio && r.Data <= fim)
                    ).Count();
                lblSubTotal.Text = query.ToString();
                UpdatePanel1.Update();
            }
            // filtra somente por categoria
            else if (int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
               && !int.TryParse(ddlBairros.SelectedValue, out bairroId)
               && !(DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                var query = _db.Reclamacoes.Where(r => r.Categoria.CategoriaId == categoriaId).Count();
                lblSubTotal.Text = query.ToString();
                UpdatePanel1.Update();
            }
            // filtra somente por bairro
            else if (!int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
               && int.TryParse(ddlBairros.SelectedValue, out bairroId)
               && !(DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                var query = _db.Reclamacoes.Where(r => r.Bairro.BairroId == bairroId).Count();
                lblSubTotal.Text = query.ToString();
                UpdatePanel1.Update();
            }
            // filtra somente por período
            else if (!int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
               && !int.TryParse(ddlBairros.SelectedValue, out bairroId)
               && (DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                var query = _db.Reclamacoes.Where(r => r.Data >= inicio && r.Data <= fim).Count();
                lblSubTotal.Text = query.ToString();
                UpdatePanel1.Update();
            }
            // filtra por categoria e bairro
            else if (int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
                && int.TryParse(ddlBairros.SelectedValue, out bairroId)
                && !(DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                var query = _db.Reclamacoes.Where(r => r.Categoria.CategoriaId == categoriaId
                    && r.Bairro.BairroId == bairroId).Count();
                lblSubTotal.Text = query.ToString();
                UpdatePanel1.Update();
            }
            // filtra por categoria e período
            else if (int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
                && !int.TryParse(ddlBairros.SelectedValue, out bairroId)
                && (DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                var query = _db.Reclamacoes.Where(r => r.Categoria.CategoriaId == categoriaId
                    && r.Data >= inicio && r.Data <= fim).Count();
                lblSubTotal.Text = query.ToString();
                UpdatePanel1.Update();
            }
            // filtra por bairro e período
            else if (!int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
                && int.TryParse(ddlBairros.SelectedValue, out bairroId)
                && (DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                var query = _db.Reclamacoes.Where(r => r.Bairro.BairroId == bairroId
                    && r.Data >= inicio && r.Data <= fim).Count();
                lblSubTotal.Text = query.ToString();
                UpdatePanel1.Update();
            }
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