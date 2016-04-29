using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp2.Models;

namespace TestApp2.DAL
{
    public class DAL_PanierProduit : _DAL
    {
        public void AjouterProduit(int Panier_Id, int produit_Id, int quantiteSelectionnee)
        {
            using (var context = base.GetContext())
            {
                PanierProduit panierProduit = context.PanierProduit.FirstOrDefault(x => x.Panier_Id == Panier_Id && x.Produit_Id == produit_Id);
                if (panierProduit == null)
                {
                    panierProduit = new PanierProduit()
                    {
                        Panier_Id = Panier_Id,
                        Produit_Id = produit_Id,
                        Quantite = 0,
                    };
                    context.PanierProduit.Add(panierProduit);
                }
                panierProduit.Quantite += quantiteSelectionnee;
                context.SaveChanges();
            }
        }

        public void ViderPanier(string User_Id)
        {
            using (var context = base.GetContext())
            {
                Panier panier = context.Panier.FirstOrDefault(x => x.User_Id == User_Id);
                if (panier != null)
                {
                    context.PanierProduit.RemoveRange(panier.PanierProduit);
                    context.SaveChanges();
                }
            }
        }

        public void SupprimerPanierProduit(int panierProduit_Id)
        {
            using (var context = base.GetContext())
            {
                PanierProduit p = context.PanierProduit.FirstOrDefault(x => x.PanierProduit_Id == panierProduit_Id);
                if (p != null)
                {
                    context.PanierProduit.Remove(p);
                    context.SaveChanges();
                }
            }
        }

        public PanierProduitDTO AddQtePanierProduit(int panierProduit_Id, int qte)
        {
            using (var context = base.GetContext())
            {
                PanierProduit p = context.PanierProduit.FirstOrDefault(x => x.PanierProduit_Id == panierProduit_Id);
                if (p != null)
                {
                    p.Quantite += qte;
                    bool suppr = false;
                    if (p.Quantite <= 0)
                    {
                        context.PanierProduit.Remove(p);
                        suppr = true;
                    }
                    context.SaveChanges();
                    if (!suppr)
                    {
                        return p.ToDTO();
                    }
                }
                return null;
            }
        }

        public void Supprimer(List<int> PanierProduit_Ids)
        {
            using (var context = base.GetContext())
            {
                foreach (int PanierProduit_Id in PanierProduit_Ids)
                {
                    PanierProduit panierProduit = context.PanierProduit.FirstOrDefault(x => x.PanierProduit_Id == PanierProduit_Id);
                    if (panierProduit != null)
                    {
                        context.PanierProduit.Remove(panierProduit);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}