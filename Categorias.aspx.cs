using ReclamaPoa2013.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReclamaPoa2013
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Categoria> getCategorias()
        {
            ReclamaPoaEntities _db = new ReclamaPoaEntities();
            IQueryable<Categoria> query = _db.Categorias;
            return query;
        }
    }
}