using System;
using System.Collections.Generic;
using System.Text;

namespace Minivilles
{
    public class IAStrategy : Strategy
    {
        public void ChoisirCarte(Player p1, Player p2, Pile p)
        {
            if (p1.argent == 0 || p1.argent > 12)
            {
                return;
            }
            Random rnd = new Random();

            //Liste de cartes que l'IA peut acheter
            List<Card> canBuy = new List<Card>();
            foreach (CARD_ID c in p._cartes.Keys)
            {
                //S'il reste un exemplaire de la carte
                if (p._cartes[c] > 0 && p1.argent >= Globals.CardInfo[c].cout)
                {
                    canBuy.Add(new Card(Globals.CardInfo[c]));
                }
            }

            //Choisit aléatoirement une carte parmi la liste de cartes

            int index = rnd.Next(0, canBuy.Count);
            if (canBuy.Count > 0)
            {
                p1.AcheterCarte(canBuy[index], p);
                Console.WriteLine("Votre adversaire a acheté {0}\n", canBuy[index].nom);
            }

        }
    }
}
