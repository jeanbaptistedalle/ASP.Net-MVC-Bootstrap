using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp2.Models;

namespace TestApp2
{
    public static class DTOHelper
    {
        public static ProduitDTO ToDTO(this Produit that)
        {
            ProduitDTO dto = new ProduitDTO()
            {
                Produit_Id = that.Produit_Id,
                Libelle = that.Libelle,
                Prix = that.Prix,
                Description = that.Description,
                Image = that.Image,
                Fruit = that.Fruit,
            };
            return dto;
        }

        public static PanierDTO ToDTO(this Panier that)
        {
            PanierDTO dto = new PanierDTO()
            {
                Panier_Id = that.Panier_Id,
                PanierProduits = that.PanierProduit.ToListDTO(),
            };
            dto.PrixTotal = dto.PanierProduits.Sum(x => x.PrixTotal);
            return dto;
        }

        public static PanierProduitDTO ToDTO(this PanierProduit that)
        {
            PanierProduitDTO dto = new PanierProduitDTO()
            {
                PanierProduit_Id = that.PanierProduit_Id,
                Produit_Id = that.Produit_Id,
                Libelle = that.Produit.Libelle,
                Prix = that.Produit.Prix,
                Quantite = that.Quantite,
                PrixTotal = that.Produit.Prix * that.Quantite,
            };
            return dto;
        }

        public static List<ProduitDTO> ToListDTO(this ICollection<Produit> thats)
        {
            List<ProduitDTO> dtos = new List<ProduitDTO>();
            foreach (Produit that in thats)
            {
                dtos.Add(that.ToDTO());
            }
            return dtos;
        }

        public static List<PanierProduitDTO> ToListDTO(this ICollection<PanierProduit> thats)
        {
            List<PanierProduitDTO> dtos = new List<PanierProduitDTO>();
            foreach (PanierProduit that in thats)
            {
                dtos.Add(that.ToDTO());
            }
            return dtos;
        }
    }
}