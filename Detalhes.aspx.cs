using System;
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

        protected void btnComentario_Click(object sender, EventArgs e)
        {
            ReclamaPoaEntities _db = new ReclamaPoaEntities();
            Comentario comentario = new Comentario();

            String filtro = (string)Request.QueryString["id"];
            int id;
            if (Int32.TryParse(filtro, out id))
            {
                //fazer query para pegar a reclamação
                comentario.Texto = txtComentario.Text;
                Reclamacao r = new Reclamacao();
                comentario.Reclamacao = r;
                comentario.Reclamacao.ReclamacaoId = id;
                comentario.Usuario = Context.User.Identity.Name;
            }
            _db.Comentarios.Add(comentario);
            _db.SaveChanges();

            Response.Redirect("Detalhes.aspx?id=" + id);
        }
    }
}