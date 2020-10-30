using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Minivilles
{
    public class PlayerStrategy : Strategy
    {
        public void ChoisirCarte(Player p1, Player p2, Pile p)
        {

            Debug.WriteLine("Début Joueur");
            //A Faire selon l'interface 
            Globals.gameTimer.Stop();
            while(Globals.card_chosen == CARD_ID.NULL)
            {

            }
            Card c = Globals.CardInfo[Globals.card_chosen];

            Globals.card_chosen = CARD_ID.NULL;
            if (p1.argent >= c.cout)
            {
                p1.AcheterCarte(c, p);

            }
            else
            {
                Debug.WriteLine("Choisissez une autre carte...");
                ChoisirCarte(p1, p2, p);
            }

        }

    }
}
