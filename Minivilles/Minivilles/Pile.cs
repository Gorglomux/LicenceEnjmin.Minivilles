using System;
using System.Collections.Generic;
using System.Text;

namespace Minivilles
{
    public class Pile
    {

        private Dictionary<CARD_ID, int> cartes;
        public Dictionary<CARD_ID, int> _cartes
        {
            get
            {
                return cartes;
            }
            set
            {
                cartes = value;
            }
        }

        public void PrendreCarte(CARD_ID ID)
        {
            cartes[ID] -= 1;
        }
        public Pile()
        {
            cartes = new Dictionary<CARD_ID, int>();
        }
        public void ajouterCarte(CARD_ID ID, int amount)
        {
            cartes[ID] = amount;
        }
    }
}
