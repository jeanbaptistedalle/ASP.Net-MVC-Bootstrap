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
            ProduitDTO dto = new ProduitDTO();
            dto.Produit_Id = that.Produit_Id;
            dto.Libelle = that.Libelle;
            dto.Prix = that.Prix;
            dto.Description = that.Description;
            dto.Image = that.Image;
            return dto;
        }

        public static List<ProduitDTO> ToListDTO(this List<Produit> thats)
        {
            List<ProduitDTO> dtos = new List<ProduitDTO>();
            foreach (Produit that in thats)
            {
                dtos.Add(that.ToDTO());
            }
            return dtos;
        }
    }
}