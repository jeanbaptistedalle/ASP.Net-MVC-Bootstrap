using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TestApp2.ViewsModels.Produit
{
    public class BuyModalModel
    {
        public ProduitDTO Produit { get; set; }

        public int Produit_Id { get; set; }

        public SelectList QuantitesDisponibles { get; set; }

        [Display(Name="Quantité")]
        public int Quantite { get; set; }
    }
}