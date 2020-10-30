using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace Minivilles
{
    public class Player
    {
        public int valeurDe;
        public Pile cartesEnJeu { get; set; }
        public int argent;
        public Strategy strategy;

        public Player(Strategy uneStrat, List<Card> carteDeBase)
        {
            argent = 3;
            strategy = uneStrat;
            cartesEnJeu = new Pile();
            foreach(var i in carteDeBase)
            {
                cartesEnJeu.ajouterCarte(i.ID, 1);
            }
        }

        public void AcheterCarte(Card c, Pile p)
        {

            
            if (argent >= c.cout)
            {
                cartesEnJeu.ajouterCarte(c.ID,1);
                argent -= c.cout;
                p.PrendreCarte(c.ID);
            }
        }

        public void TesterCartesJoueur(Player autreJoueur, int sommeDe, bool tourJoueur)
        {
            foreach(CARD_ID id in cartesEnJeu._cartes.Keys)
            {
                Card i = Globals.CardInfo[id];
                if (tourJoueur)
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
            Globals.EFFETS[carte.ID](this, autreJoueur);
        }
    }
}
