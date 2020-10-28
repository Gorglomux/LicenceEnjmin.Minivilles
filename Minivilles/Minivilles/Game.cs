using System;
using System.Collections.Generic;
using System.Text;

namespace Minivilles
{
    public class Game
    {
        public List<Die> Des;
        public Pile CartesDisponibles;
        public List<Player> Joueurs;

        public Game(List<Die> des, Pile cartes, List<Player> joueurs)
        {
            Des = des;
            CartesDisponibles = cartes;
            Joueurs = joueurs;
        }


        public int JouerPartie()
        {
            // On donne la victoire au Joueur 1 de base
            int gagnant = 1;
            while (Joueurs[0].argent < 20 && Joueurs[1].argent < 20)
            {
                Tour(Joueurs[0], Joueurs[1]);
                // On vérifie si le Joueur 1 a déjà gagné avant le tour du Joueur 2
                if (Joueurs[0].argent >= 20)
                    break;
                Tour(Joueurs[1], Joueurs[0]);
            }
            // On vérifie s'il y a égalité
            if (Joueurs[0].argent >= 20 && Joueurs[1].argent >= 20)
            {
                gagnant = 0;
            }               
            // On vérifie si le Joueur 2 a gagné
            else if (Joueurs[1].argent >= 20)
            {
                gagnant = 2;
            }
            return gagnant;
        }


        // Fonction qui permet le déroulement d'un tour
        public void Tour(Player p1, Player p2)
        {
            Des[0].Lancer();
            p2.TesterCartesJoueur(p1, Des[0].Face, false);
            p1.TesterCartesJoueur(p2, Des[0].Face, true);
            p1.strategy.ChoisirCarte();
        }
    }
}
