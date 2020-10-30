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

        public Game()
        {
            //Création des dés
            Des = new List<Die>();
            Des.Add(new Die());
            Des.Add(new Die());


            Joueurs = new List<Player>()
            {
                new Player(new PlayerStrategy(), new List<Card>(Globals.cartesDeBase )),
                new Player(new IAStrategy(), new List<Card>(Globals.cartesDeBase ))
            };

            //Initialisation de la pile de cartes
            CartesDisponibles = new Pile();

            foreach (CARD_ID id in Globals.CardInfo.Keys)
            {
                CartesDisponibles.ajouterCarte(id, 6);
            }

            //On enleve les cartes de bases selon le nombre de joueurs a la pile
            for (int i = 0; i < Joueurs.Count; i++)
            {
                foreach (Card c in Globals.cartesDeBase)
                {
                    CartesDisponibles.PrendreCarte(c.ID);
                }
            }
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
                Console.WriteLine("Egalité !");
                gagnant = 0;
            }
            // On vérifie si le Joueur 2 a gagné
            else if (Joueurs[1].argent >= 20)
            {
                Console.WriteLine("Le joueur 2 gagne !");
                gagnant = 2;
            }
            else
            {
                Console.WriteLine("Le joueur 1 gagne!");
            }
            return gagnant;

        }


        // Fonction qui permet le déroulement d'un tour
        public void Tour(Player p1, Player p2)
        {
            Console.WriteLine("Valeur du dé : {0}\n", Des[0].Lancer());
            p2.TesterCartesJoueur(p1, Des[0].Face, false);
            p1.TesterCartesJoueur(p2, Des[0].Face, true);
            Console.WriteLine("Vous avez {0} pièces", p1.argent);
            Console.WriteLine("Votre adversaire a {0} pièces\n", p2.argent);
            p1.strategy.ChoisirCarte(p1, p2, CartesDisponibles);
        }
    }
}
