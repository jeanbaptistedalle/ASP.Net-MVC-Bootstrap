using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2
{
    [Serializable]
    public class ProduitDTO
    {
        public int Produit_Id { get; set; }
        public string Libelle { get; set; }
        public decimal Prix { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}