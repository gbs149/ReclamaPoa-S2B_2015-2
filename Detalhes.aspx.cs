﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReclamaPoa2013.Models;

namespace ReclamaPoa2013
{
    public partial class Detalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //WebControl situ = (WebControl)FindControl("spanSitu");
            //situ.Attributes["Class"] = "label label-warning";

        }



        public ReclamacaoViewModel getReclamacao()
        {
            String filtro = (string)Request.QueryString["id"];

            if (filtro != null)
            {
                ReclamaPoaEntities _db = new ReclamaPoaEntities();

                int id;
                if (Int32.TryParse(filtro, out id))
                {
                    var query = from reclamacao in _db.Reclamacoes
                                where reclamacao.ReclamacaoId == id
                                select new ReclamacaoViewModel()
                                {
                                    Titulo = reclamacao.Titulo,
                                    Descricao = reclamacao.Descricao,
                                    Data = reclamacao.Data,
                                    Endereco = reclamacao.Endereco,
                                    Situacao = reclamacao.Situacao.ToString(),
                                    Bairro = reclamacao.Bairro.Nome,
                                    Categoria = reclamacao.Categoria.Nome,
                                    UrlImagem = reclamacao.UrlImagem,
                                    Usuario = reclamacao.Usuario
                                };
                    if (query.Count() > 0) return query.First();
                }
            }
            return new ReclamacaoViewModel();
        }


        /// <summary>
        /// Recupera os comentarios da reclamacao
        /// </summary>
        /// <returns></returns>
        public IQueryable<ComentarioViewModel> getComentarios()
        {
            int id = Int32.Parse(Request.QueryString["id"]);
            ReclamaPoaEntities _db = new ReclamaPoaEntities();
            
            IQueryable<ComentarioViewModel> cvmData = from c in _db.Comentarios
                                                      where c.Reclamacao.ReclamacaoId == id
                                                      select new ComentarioViewModel
                                                      {
                                                          ComentarioId = c.ComentarioId,
                                                          Texto = c.Texto,
                                                          Usuario = c.Usuario,
                                                          ReclamacaoId = c.Reclamacao.ReclamacaoId
                                                      };
            return cvmData;
        }



        protected void btnComentario_Click(object sender, EventArgs e)
        {
            ReclamaPoaEntities _db = new ReclamaPoaEntities();
            Comentario comentario = new Comentario();
            TextBox textoComentario = (TextBox)LoginView1.FindControl("txtComentario");

            String filtro = (string)Request.QueryString["id"];
            int id;
            if (Int32.TryParse(filtro, out id))
            {
                // query para pegar a reclamação
                var query = _db.Reclamacoes.Where(r => r.ReclamacaoId == id);
                Reclamacao r1 = query.First();

                comentario.Texto = textoComentario.Text;
                comentario.Reclamacao = r1;
                comentario.Usuario = Context.User.Identity.Name;
            }
            _db.Comentarios.Add(comentario);
            _db.SaveChanges();

            Response.Redirect("Detalhes.aspx?id=" + id);
        }
    }
}