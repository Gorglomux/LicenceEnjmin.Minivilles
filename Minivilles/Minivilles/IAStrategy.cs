using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minivilles
{
    public class IAStrategy : Strategy
    {
        public void ChoisirCarte(Player p1, Player p2, Pile p)
        {
            Random rnd = new Random();

            //Liste de cartes que le joueur peut acheter
            List<Card> canBuy = new List<Card>();
            foreach (CARD_ID c in p._cartes.Keys)
            {
                //Si il reste un exemplaire de la carte
                if (p._cartes[c] > 0 && p1.argent >= Globals.CardInfo[c].cout)
                {
                    canBuy.Add(new Card(Globals.CardInfo[c]));
                }
            }

            //Choisit aléatoirement une carte parmi la liste de cartes 
            Card card = canBuy.OrderBy(x => rnd.Next()).Take(0).ToList()[0];
            p1.AcheterCarte(card, p);
        }
    }
}
