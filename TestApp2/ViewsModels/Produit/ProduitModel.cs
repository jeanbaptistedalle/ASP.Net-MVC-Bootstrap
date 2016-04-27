using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApp2.ViewsModels.Produit
{
    public class ProduitModel
    {
        public int produit_Id { get; set; }
        public ProduitDTO produit { get; set; }
        public int quantiteSelectionnee { get; set; }
        public SelectList quantitesDisponibles { get; set; }
    }
}