using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp2;

namespace TestApp2.ViewsModels.Panier
{
    public class PanierModel
    {
        public int Panier_Id { get; set; }
        public decimal PrixTotal { get; set; }
        public List<PanierProduitDTO> PanierProduits { get; set; }
    }
}