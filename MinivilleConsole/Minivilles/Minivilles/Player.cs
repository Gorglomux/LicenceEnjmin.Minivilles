﻿using System;
using System.Collections.Generic;
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
            foreach (var i in carteDeBase)
            {
                cartesEnJeu.ajouterCarte(i.ID, 1);
            }
        }

        public void AcheterCarte(Card c, Pile p)
        {
            if (argent >= c.cout)
            {
                cartesEnJeu.ajouterCarte(c.ID, 1);
                argent -= c.cout;
                p.PrendreCarte(c.ID);
            }
        }

        public void TesterCartesJoueur(Player autreJoueur, int sommeDe, bool tourJoueur)
        {
            foreach (CARD_ID id in cartesEnJeu._cartes.Keys)
            {
                Card c = Globals.CardInfo[id];
                if (tourJoueur)
                {

                    if (c.valeurActivation.Contains(sommeDe) && (c.couleur == COULEUR.BLEU || c.couleur == COULEUR.VERT))
                    {
                        for(int i=0; i< cartesEnJeu._cartes[id]; i++)
                        {

                            UtiliserCarte(autreJoueur, c);
                        }
                    }
                }
                else
                {
                    if (c.valeurActivation.Contains(sommeDe) && (c.couleur == COULEUR.BLEU || c.couleur == COULEUR.ROUGE))
                    {
                        for (int i = 0; i < cartesEnJeu._cartes[id]; i++)
                        {
                            UtiliserCarte(autreJoueur, c);

                        }
                    }
                }
            }
        }

        public void UtiliserCarte(Player autreJoueur, Card carte)
        {
            //On appelle la fonction contenue dans le dictionnaire des effets
            Console.WriteLine("La carte {0} s'active", carte.nom);
            Globals.EFFETS[carte.ID](this, autreJoueur);
        }
    }
}
