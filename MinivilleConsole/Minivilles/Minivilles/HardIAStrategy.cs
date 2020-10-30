using System;
using System.Collections.Generic;
using System.Text;

namespace Minivilles
{
    public class HardIAStrategy : Strategy
    {
        public void ChoisirCarte(Player p1, Player p2, Pile p)
        {
            if (p1.argent == 0)
            {
                return;
            }

            bool restaut = true;
            bool superette = true;
            bool cafe = true;
            bool mine = true;
            bool verger = true;
            bool bleu = false;
            bool rouge = false;
            bool vert = false;
            Random rnd = new Random();

            //Liste de cartes que le joueur peut acheter
            List<Card> canBuy = new List<Card>();
            foreach (CARD_ID c in p._cartes.Keys)
            {
                //S'il reste un exemplaire de la carte
                if (p._cartes[c] > 0 && p1.argent >= Globals.CardInfo[c].cout)
                {
                    canBuy.Add(new Card(Globals.CardInfo[c]));
                    /*Vérifier si restaurant, superette et café sont encore achetables. S'ils ne sont pas achetables, le bool reste true pour faire
                     *comme s'il l'avait déjà et donc passer l'achat  
                     */
                    if (c == CARD_ID.RESTAURANT)
                    {
                        restaut = false;
                    }
                    if (c == CARD_ID.SUPERETTE)
                    {
                        superette = false;
                    }
                    if (c == CARD_ID.CAFE)
                    {
                        cafe = false;
                    }

                    //On vérifie s'il reste des cartes bleus, rouges et vertes
                    if (Globals.CardInfo[c].couleur == COULEUR.BLEU)
                    {
                        bleu = true;
                    }
                    if (Globals.CardInfo[c].couleur == COULEUR.ROUGE)
                    {
                        rouge = true;
                    }
                    if (Globals.CardInfo[c].couleur == COULEUR.VERT)
                    {
                        vert = true;
                    }
                }
            }



            //Acheter en priorité restaurant, superette, café
            foreach (CARD_ID c in p1.cartesEnJeu._cartes.Keys)
            {
                if (c == CARD_ID.RESTAURANT)
                {
                    restaut = true;
                }
                if (c == CARD_ID.SUPERETTE)
                {
                    superette = true;
                }
                if (c == CARD_ID.CAFE)
                {
                    cafe = true;
                }
            }

            foreach (Card c in canBuy)
            {
                if (!restaut && c.ID == CARD_ID.RESTAURANT)
                {
                    p1.AcheterCarte(c, p);
                    return;
                }

                if (!superette && c.ID == CARD_ID.SUPERETTE)
                {
                    p1.AcheterCarte(c, p);
                    return;
                }

                if (!cafe && c.ID == CARD_ID.CAFE)
                {
                    p1.AcheterCarte(c, p);
                    return;
                }
            }

            /* Si l'execution arrive ici, l'IA a soit dans sa main au moins un Restaurant, une Superette et un Café ou alors 
             * il ne pouvait pas les acheter. S'il ne peut pas les acheter, il passe son tour.
             */
            if (restaut && superette && cafe && mine && verger)
            {
                int index = 0;
                //Acheter en priorité des bleus
                if (bleu)
                {
                    while (true)
                    {
                        index = rnd.Next(0, canBuy.Count);
                        if (canBuy[index].couleur == COULEUR.BLEU)
                        {
                            p1.AcheterCarte(canBuy[index], p);
                            return;
                        }
                    }
                }
                //S'il ne peut pas acheter de bleu, il achete une rouge
                if (rouge)
                {
                    while (true)
                    {
                        index = rnd.Next(0, canBuy.Count);
                        if (canBuy[index].couleur == COULEUR.ROUGE)
                        {
                            p1.AcheterCarte(canBuy[index], p);
                            return;
                        }
                    }
                }
                //S'il ne peut pas acheter de rouge, il achete une verte
                if (vert)
                {
                    while (true)
                    {
                        index = rnd.Next(0, canBuy.Count);
                        if (canBuy[index].couleur == COULEUR.VERT)
                        {
                            p1.AcheterCarte(canBuy[index], p);
                            return;
                        }
                    }
                }
            }
        }
    }
}
