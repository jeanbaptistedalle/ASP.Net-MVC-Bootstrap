using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2
{
    [Serializable]
    public class PanierDTO
    {
        public int Panier_Id { get; set; }
        public decimal PrixTotal { get; set; }
        public List<PanierProduitDTO> PanierProduits { get; set; }
    }
}