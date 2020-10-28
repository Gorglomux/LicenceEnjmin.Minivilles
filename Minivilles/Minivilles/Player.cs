using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Minivilles
{
    class Player
    {
        public int valeurDe;
        private List<Card> _CartesEnJeu;
        public List<Card> cartesEnJeu { get { return _CartesEnJeu; } set { _CartesEnJeu = value; } }
        public int argent;
        public Strategy strategy;

        public Player(Strategy uneStrat, List<Card> carteDeBase)
        {
            argent = 3;
            strategy = uneStrat;
            foreach(var i in carteDeBase)
            {
                cartesEnJeu.Add(i);
            }
        }

        public void AcheterCarte(Card c)
        {
            cartesEnJeu.Add(c);
            argent -= c.cout;
        }

        public void TesterCartesJoueur(Player autreJoueur, int sommeDe, bool tourJoueur)
        {
            foreach(var i in cartesEnJeu)
            {
                if(tourJoueur)
                {
                    if (sommeDe == i.valeurActivation && (i.couleur == COULEUR.BLEU || i.couleur == COULEUR.VERT))
                    {
                        UtiliserCarte(autreJoueur, i);
                    }
                }
                else
                {
                    if (sommeDe == i.valeurActivation && (i.couleur == COULEUR.BLEU || i.couleur == COULEUR.ROUGE))
                    {
                        UtiliserCarte(autreJoueur, i);
                    }
                }
            }
        }

        public void UtiliserCarte(Player autreJoueur, Card carte)
        {
            carte.Effet(autreJoueur);
        }
    }
}
