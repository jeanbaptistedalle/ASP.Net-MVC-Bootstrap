//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestApp2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PanierProduit
    {
        public int PanierProduit_Id { get; set; }
        public int Panier_Id { get; set; }
        public int Produit_Id { get; set; }
        public int Quantite { get; set; }
    
        public virtual Panier Panier { get; set; }
        public virtual Produit Produit { get; set; }
    }
}