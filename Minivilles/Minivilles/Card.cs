using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Minivilles
{
    public class Card
    {
        public int cout;
        public COULEUR couleur;
        public string nom;
        public string descriptionEffet;
        public List<int> valeurActivation;
        public CARD_ID ID;
        public CardBox cb;

        public Card(int cout, COULEUR couleur, string nom, string descriptionEffet, List<int> valeurActivation, CARD_ID id,CardBox cb)
        {
            this.cout = cout;
            this.couleur = couleur;
            this.nom = nom;
            this.descriptionEffet = descriptionEffet;
            this.valeurActivation = valeurActivation;
            ID = id;
            this.cb = cb;
        }
        public Card(Card c)
        {
            this.cout = c.cout;
            this.couleur = c.couleur;
            this.nom = c.nom;
            this.descriptionEffet = c.descriptionEffet;
            this.valeurActivation = new List<int>(c.valeurActivation);
            ID = c.ID;
            this.cb = new CardBox();
            this.cb.ImageLocation = c.cb.ImageLocation;
            this.cb.Size = new Size(140, 100);
        }
    }
}
