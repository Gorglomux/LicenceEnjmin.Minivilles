using System;
using System.Collections.Generic;
using System.Text;

namespace Minivilles
{
    public class Card
    {
        public int cout;
        public COULEUR couleur;
        public string nom;
        public string descriptionEffet;
        public List<int> valeurActivation;
        public EFFET effet;
    }
}
