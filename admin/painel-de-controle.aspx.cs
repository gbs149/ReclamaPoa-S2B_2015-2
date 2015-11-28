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
            int totalComentarios = _db.Comentarios.Count();
            lblTotal.Text = totalReclamacoes.ToString();
            lblTotalComentarios.Text = totalComentarios.ToString();
            lblMediaComentGeral.Text = ((decimal)totalComentarios / totalReclamacoes).ToString();

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



        protected void ddlBairros_SelectedIndexChanged(object sender, EventArgs e)
        {
            valueChange();
        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            valueChange();
        }

        protected void txtDataInicio_TextChanged(object sender, EventArgs e)
        {
            valueChange();
        }

        protected void txtDataFinal_TextChanged(object sender, EventArgs e)
        {
            valueChange();
        }


        private void valueChange()
        {
            ReclamaPoaEntities _db = new ReclamaPoaEntities();

            int totalReclamacoes = _db.Reclamacoes.Count();
            int subTotalRec = 0;
            int subTotalCom = 0;
            int recAbertas = 0;
            int recEncerradas = 0;
            int recResolvidas = 0;
            int categoriaId;
            int bairroId;
            DateTime inicio;
            DateTime fim;
            Decimal porcentagem = 0m;
            Decimal porcentAbertas = 0m;
            Decimal porcentEncerradas = 0m;
            Decimal porcentResolvidas = 0m;
            Decimal mediaComentarios = 0m;



            // filtra por categoria, bairro e periodo
            if (int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
                && int.TryParse(ddlBairros.SelectedValue, out bairroId)
                && (DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                // busca reclamações de acordo com os filtros
                var queryRec = _db.Reclamacoes.Where(r => r.Categoria.CategoriaId == categoriaId
                    && r.Bairro.BairroId == bairroId
                    && (r.Data >= inicio && r.Data <= fim)
                    );
                // busca comentários de acordo com os filtros
                var queryCom = _db.Comentarios.Where(c => c.Reclamacao.Categoria.CategoriaId == categoriaId
                    && c.Reclamacao.Bairro.BairroId == bairroId
                    && (c.Reclamacao.Data >= inicio && c.Reclamacao.Data <= fim)
                    );

                subTotalRec = queryRec.Count();
                subTotalCom = queryCom.Count();

                recAbertas = queryRec.Where(r => r.Situacao == Situacao.Aberta).Count();
                recEncerradas = queryRec.Where(r => r.Situacao == Situacao.Encerrada).Count();
                recResolvidas = queryRec.Where(r => r.Situacao == Situacao.Resolvida).Count();

                // ***** SE FUNCIONAR, APAGAR O BLOCO COMENTADO *****
                //// calcula a porcentagem das reclamações em relação ao total geral
                //if (totalReclamacoes != 0)
                //{ porcentagem = (Decimal) subTotalRec / totalReclamacoes; }

                //// calcula a média de comentários por reclamação
                //if (subTotalRec != 0 )
                //{ mediaComentarios = (Decimal)subTotalCom / subTotalRec; }

                //if (subTotalRec != 0)
                //{ porcentAbertas = (Decimal)recAbertas / subTotalRec; }

                //if (subTotalRec != 0)
                //{ porcentEncerradas = (Decimal)recEncerradas / subTotalRec; }

                //if (subTotalRec != 0)
                //{ porcentResolvidas = (Decimal)recResolvidas / subTotalRec; }

                //lblSubTotal.Text = String.Format("Reclamações: {0} ({1:P} do total)", subTotalRec, porcentagem);
                //lblMediaFiltrada.Text = String.Format("Número médio de comentários por reclamação: {0}", mediaComentarios);
                //lblAbertas.Text = String.Format("Reclamações abertas: {0} ({1:P} do total)", recAbertas, porcentAbertas);
                //lblResolvidas.Text = String.Format("Reclamações resolvidas: {0} ({1:P} do total)", recResolvidas, porcentResolvidas);
                //lblEncerradas.Text = String.Format("Reclamações encerradas: {0} ({1:P} do total)", recEncerradas, porcentEncerradas);
                //UpdatePanel1.Update();
            }
            // filtra somente por categoria
            else if (int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
               && !int.TryParse(ddlBairros.SelectedValue, out bairroId)
               && !(DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                // busca reclamações de acordo com os filtros
                var queryRec = _db.Reclamacoes.Where(r => r.Categoria.CategoriaId == categoriaId);
                // busca comentários de acordo com os filtros
                var queryCom = _db.Comentarios.Where(c => c.Reclamacao.Categoria.CategoriaId == categoriaId);

                subTotalRec = queryRec.Count();
                subTotalCom = queryCom.Count();

                recAbertas = queryRec.Where(r => r.Situacao == Situacao.Aberta).Count();
                recEncerradas = queryRec.Where(r => r.Situacao == Situacao.Encerrada).Count();
                recResolvidas = queryRec.Where(r => r.Situacao == Situacao.Resolvida).Count();
            }
            // filtra somente por bairro
            else if (!int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
               && int.TryParse(ddlBairros.SelectedValue, out bairroId)
               && !(DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                // busca reclamações de acordo com os filtros
                var queryRec = _db.Reclamacoes.Where(r => r.Bairro.BairroId == bairroId);
                // busca comentários de acordo com os filtros
                var queryCom = _db.Comentarios.Where(c => c.Reclamacao.Bairro.BairroId == bairroId);

                subTotalRec = queryRec.Count();
                subTotalCom = queryCom.Count();

                recAbertas = queryRec.Where(r => r.Situacao == Situacao.Aberta).Count();
                recEncerradas = queryRec.Where(r => r.Situacao == Situacao.Encerrada).Count();
                recResolvidas = queryRec.Where(r => r.Situacao == Situacao.Resolvida).Count();
            }
            // filtra somente por período
            else if (!int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
               && !int.TryParse(ddlBairros.SelectedValue, out bairroId)
               && (DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                // busca reclamações de acordo com os filtros
                var queryRec = _db.Reclamacoes.Where(r => r.Data >= inicio && r.Data <= fim);
                // busca comentários de acordo com os filtros
                var queryCom = _db.Comentarios.Where(c => c.Reclamacao.Data >= inicio && c.Reclamacao.Data <= fim);

                subTotalRec = queryRec.Count();
                subTotalCom = queryCom.Count();

                recAbertas = queryRec.Where(r => r.Situacao == Situacao.Aberta).Count();
                recEncerradas = queryRec.Where(r => r.Situacao == Situacao.Encerrada).Count();
                recResolvidas = queryRec.Where(r => r.Situacao == Situacao.Resolvida).Count();
            }
            // filtra por categoria e bairro
            else if (int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
                && int.TryParse(ddlBairros.SelectedValue, out bairroId)
                && !(DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                // busca reclamações de acordo com os filtros
                var queryRec = _db.Reclamacoes.Where(r => r.Categoria.CategoriaId == categoriaId
                    && r.Bairro.BairroId == bairroId);
                // busca comentários de acordo com os filtros
                var queryCom = _db.Comentarios.Where(c => c.Reclamacao.Categoria.CategoriaId == categoriaId
                    && c.Reclamacao.Bairro.BairroId == bairroId);

                subTotalRec = queryRec.Count();
                subTotalCom = queryCom.Count();

                recAbertas = queryRec.Where(r => r.Situacao == Situacao.Aberta).Count();
                recEncerradas = queryRec.Where(r => r.Situacao == Situacao.Encerrada).Count();
                recResolvidas = queryRec.Where(r => r.Situacao == Situacao.Resolvida).Count();
            }
            // filtra por categoria e período
            else if (int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
                && !int.TryParse(ddlBairros.SelectedValue, out bairroId)
                && (DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                // busca reclamações de acordo com os filtros
                var queryRec = _db.Reclamacoes.Where(r => r.Categoria.CategoriaId == categoriaId
                    && (r.Data >= inicio && r.Data <= fim));
                // busca comentários de acordo com os filtros
                var queryCom = _db.Comentarios.Where(c => c.Reclamacao.Categoria.CategoriaId == categoriaId
                    && (c.Reclamacao.Data >= inicio && c.Reclamacao.Data <= fim));

                subTotalRec = queryRec.Count();
                subTotalCom = queryCom.Count();

                recAbertas = queryRec.Where(r => r.Situacao == Situacao.Aberta).Count();
                recEncerradas = queryRec.Where(r => r.Situacao == Situacao.Encerrada).Count();
                recResolvidas = queryRec.Where(r => r.Situacao == Situacao.Resolvida).Count();
            }
            // filtra por bairro e período
            else if (!int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
                && int.TryParse(ddlBairros.SelectedValue, out bairroId)
                && (DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
            {
                // busca reclamações de acordo com os filtros
                var queryRec = _db.Reclamacoes.Where(r => r.Bairro.BairroId == bairroId
                    && (r.Data >= inicio && r.Data <= fim));
                // busca comentários de acordo com os filtros
                var queryCom = _db.Comentarios.Where(c => c.Reclamacao.Bairro.BairroId == bairroId
                    && (c.Reclamacao.Data >= inicio && c.Reclamacao.Data <= fim));

                subTotalRec = queryRec.Count();
                subTotalCom = queryCom.Count();

                recAbertas = queryRec.Where(r => r.Situacao == Situacao.Aberta).Count();
                recEncerradas = queryRec.Where(r => r.Situacao == Situacao.Encerrada).Count();
                recResolvidas = queryRec.Where(r => r.Situacao == Situacao.Resolvida).Count();
            }

            // calcula a média de comentários por reclamação
            if (subTotalRec != 0)
            { mediaComentarios = (Decimal)subTotalCom / subTotalRec; }

            // calcula a porcentagem das reclamações em relação ao total geral
            if (totalReclamacoes != 0)
            { porcentagem = (Decimal)subTotalRec / totalReclamacoes; }

            // calcula a porcentagem de reclamações abertas, resolvidas ou encerradas
            if (subTotalRec != 0)
            { porcentAbertas = (Decimal)recAbertas / subTotalRec; }

            if (subTotalRec != 0)
            { porcentEncerradas = (Decimal)recEncerradas / subTotalRec; }

            if (subTotalRec != 0)
            { porcentResolvidas = (Decimal)recResolvidas / subTotalRec; }

            // atribui os resultados aos labels
            lblSubTotal.Text = String.Format("Reclamações: {0} ({1:P} do total)", subTotalRec, porcentagem);
            lblMediaFiltrada.Text = String.Format("Número médio de comentários por reclamação: {0}", mediaComentarios);
            lblAbertas.Text = String.Format("Reclamações abertas: {0} ({1:P} do total)", recAbertas, porcentAbertas);
            lblResolvidas.Text = String.Format("Reclamações resolvidas: {0} ({1:P} do total)", recResolvidas, porcentResolvidas);
            lblEncerradas.Text = String.Format("Reclamações encerradas: {0} ({1:P} do total)", recEncerradas, porcentEncerradas);
            UpdatePanel1.Update();

        }



        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    ReclamaPoaEntities _db = new ReclamaPoaEntities();

        //    int totalReclamacoes = _db.Reclamacoes.Count();
        //    int subTotalRec;
        //    int subTotalCom;
        //    int categoriaId;
        //    int bairroId;
        //    DateTime inicio;
        //    DateTime fim;
        //    Decimal porcentagem = 0m;
        //    Decimal mediaComentarios;



        //    // filtra por categoria, bairro e periodo
        //    if (int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
        //        && int.TryParse(ddlBairros.SelectedValue, out bairroId)
        //        && (DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
        //    {
        //        // busca o número de reclamações
        //        var query = _db.Reclamacoes.Where(r => r.Categoria.CategoriaId == categoriaId
        //            && r.Bairro.BairroId == bairroId
        //            && (r.Data >= inicio && r.Data <= fim)
        //            ).Count();
        //        // busca o número de comentários
        //        var query2 = _db.Comentarios.Where(c => c.Reclamacao.Categoria.CategoriaId == categoriaId
        //            && c.Reclamacao.Bairro.BairroId == bairroId
        //            && (c.Reclamacao.Data >= inicio && c.Reclamacao.Data <= fim)
        //            ).Count();

        //        subTotalRec = query;
        //        subTotalCom = query2;

        //        porcentagem = (Decimal) subTotalRec * 100 / totalReclamacoes;
        //        mediaComentarios = subTotalCom / subTotalRec;

        //        lblSubTotal.Text = String.Format("Reclamações: {0} ({1:N}% do total)", subTotalRec, porcentagem);
        //        lblMediaFiltrada.Text = String.Format("Número médio de comentários por reclamação: {0}", mediaComentarios);
        //        UpdatePanel1.Update();
        //    }
        //    // filtra somente por categoria
        //    else if (int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
        //       && !int.TryParse(ddlBairros.SelectedValue, out bairroId)
        //       && !(DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
        //    {
        //        var query = _db.Reclamacoes.Where(r => r.Categoria.CategoriaId == categoriaId).Count();
        //        lblSubTotal.Text = query.ToString();
        //        UpdatePanel1.Update();
        //    }
        //    // filtra somente por bairro
        //    else if (!int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
        //       && int.TryParse(ddlBairros.SelectedValue, out bairroId)
        //       && !(DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
        //    {
        //        var query = _db.Reclamacoes.Where(r => r.Bairro.BairroId == bairroId).Count();
        //        lblSubTotal.Text = query.ToString();
        //        UpdatePanel1.Update();
        //    }
        //    // filtra somente por período
        //    else if (!int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
        //       && !int.TryParse(ddlBairros.SelectedValue, out bairroId)
        //       && (DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
        //    {
        //        var query = _db.Reclamacoes.Where(r => r.Data >= inicio && r.Data <= fim).Count();
        //        lblSubTotal.Text = query.ToString();
        //        UpdatePanel1.Update();
        //    }
        //    // filtra por categoria e bairro
        //    else if (int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
        //        && int.TryParse(ddlBairros.SelectedValue, out bairroId)
        //        && !(DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
        //    {
        //        var query = _db.Reclamacoes.Where(r => r.Categoria.CategoriaId == categoriaId
        //            && r.Bairro.BairroId == bairroId).Count();
        //        lblSubTotal.Text = query.ToString();
        //        UpdatePanel1.Update();
        //    }
        //    // filtra por categoria e período
        //    else if (int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
        //        && !int.TryParse(ddlBairros.SelectedValue, out bairroId)
        //        && (DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
        //    {
        //        var query = _db.Reclamacoes.Where(r => r.Categoria.CategoriaId == categoriaId
        //            && r.Data >= inicio && r.Data <= fim).Count();
        //        lblSubTotal.Text = query.ToString();
        //        UpdatePanel1.Update();
        //    }
        //    // filtra por bairro e período
        //    else if (!int.TryParse(ddlCategorias.SelectedValue, out categoriaId)
        //        && int.TryParse(ddlBairros.SelectedValue, out bairroId)
        //        && (DateTime.TryParse(txtDataInicio.Text, out inicio) && DateTime.TryParse(txtDataFinal.Text, out fim)))
        //    {
        //        var query = _db.Reclamacoes.Where(r => r.Bairro.BairroId == bairroId
        //            && r.Data >= inicio && r.Data <= fim).Count();
        //        lblSubTotal.Text = query.ToString();
        //        UpdatePanel1.Update();
        //    }
        //}

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