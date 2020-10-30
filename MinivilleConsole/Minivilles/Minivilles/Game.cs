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
                new Player(new HardIAStrategy(), new List<Card>(Globals.cartesDeBase ))
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


                //Tour joueur 1

                Console.WriteLine("TOUR DU JOUEUR");
                Console.WriteLine("Valeur du dé : {0}\n", Des[0].Lancer());

                Console.WriteLine("Activations des cartes de l'adversaire");
                Joueurs[1].TesterCartesJoueur(Joueurs[0], Des[0].Face, false);
                Console.WriteLine("Activations des cartes du joueur");
                Joueurs[0].TesterCartesJoueur(Joueurs[1], Des[0].Face, true);

                Console.WriteLine("Vous avez {0} pièces", Joueurs[0].argent);
                Console.WriteLine("Votre adversaire a {0} pièces\n", Joueurs[1].argent);
                Joueurs[0].strategy.ChoisirCarte(Joueurs[0], Joueurs[1], CartesDisponibles);


                // On vérifie si le Joueur 1 a déjà gagné avant le tour du Joueur 2
                if (Joueurs[0].argent >= 20)
                    break;
                Console.Clear();

                //Tour joueur 2
                Console.WriteLine("TOUR DE L'ADVERSAIRE");
                Console.WriteLine("Valeur du dé : {0}\n", Des[0].Lancer());

                Console.WriteLine("Activations des cartes du joueur");
                Joueurs[0].TesterCartesJoueur(Joueurs[1], Des[0].Face, false);
                Console.WriteLine("Activations des cartes de l'adversaire");
                Joueurs[1].TesterCartesJoueur(Joueurs[0], Des[0].Face, true);

                Console.WriteLine("\nVous avez {0} pièces", Joueurs[0].argent);
                Console.WriteLine("Votre adversaire a {0} pièces\n", Joueurs[1].argent);
                Joueurs[1].strategy.ChoisirCarte(Joueurs[1], Joueurs[0], CartesDisponibles);

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
    }
}
