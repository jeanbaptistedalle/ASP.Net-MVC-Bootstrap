using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2
{
    [Serializable]
    public class PanierProduitDTO
    {
        public bool selectionne { get; set; }
        public int PanierProduit_Id { get; set; }
        public int Produit_Id { get; set; }
        public string Libelle { get; set; }
        public decimal Prix { get; set; }
        public int Quantite { get; set; }
        public decimal PrixTotal { get; set; }

        public PanierProduitDTO()
        {
            selectionne = false;
        }
    }
}