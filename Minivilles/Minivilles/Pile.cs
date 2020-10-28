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

    }
}
