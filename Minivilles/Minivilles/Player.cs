using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Minivilles
{
    public class Player
    {
        public int valeurDe;
        private List<Card> _CartesEnJeu;
        public List<Card> cartesEnJeu { get { return _CartesEnJeu; } private set { _CartesEnJeu = value; } }
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

        public void AcheterCarte(Card c, Pile p)
        {
            if(argent <= c.cout)
            {
                cartesEnJeu.Add(c);
                argent -= c.cout;
                //A changer
                p.PrendreCarte(c.ID);
            }
        }

        public void TesterCartesJoueur(Player autreJoueur, int sommeDe, bool tourJoueur)
        {
            foreach(Card i in cartesEnJeu)
            {
                if(tourJoueur)
                {
                    if (i.valeurActivation.Contains(sommeDe) && (i.couleur == COULEUR.BLEU || i.couleur == COULEUR.VERT))
                    {
                        UtiliserCarte(autreJoueur, i);
                    }
                }
                else
                {
                    if ( i.valeurActivation.Contains(sommeDe) && (i.couleur == COULEUR.BLEU || i.couleur == COULEUR.ROUGE))
                    {
                        UtiliserCarte(autreJoueur, i);
                    }
                }
            }
        }

        public void UtiliserCarte(Player autreJoueur, Card carte)
        {
            //On appelle la fonction contenue dans le dictionnaire des effets
            Globals.EFFETS[carte.id](this, autreJoueur);
        }
    }
}
