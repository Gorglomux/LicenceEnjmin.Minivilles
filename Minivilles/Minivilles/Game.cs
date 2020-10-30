using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Minivilles
{
    public class Game
    {
        public List<Die> Des;
        public Pile CartesDisponibles;
        public List<Player> Joueurs;
        public Queue<Action> instructionQueue;
        public Game()
        {
            //Création des dés
            Des = new List<Die>();
            Des.Add(new Die());
            Des.Add(new Die());

            instructionQueue = new Queue<Action>();
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
            for(int i=0; i<Joueurs.Count; i++)
            {
                foreach (Card c in Globals.cartesDeBase)
                {
                    CartesDisponibles.PrendreCarte(c.ID);
                }
            }
        }


        public void JouerPartie()
        {
            // On donne la victoire au Joueur 1 de base
            int gagnant = 1;
            while (Joueurs[0].argent < 20 && Joueurs[1].argent < 20)
            {

                //Si la queue d'instruction est remplie on attend
                while (instructionQueue.Count > 0)
                {

                }


                Tour(Joueurs[0], Joueurs[1]);
                // On vérifie si le Joueur 1 a déjà gagné avant le tour du Joueur 2
                if (Joueurs[0].argent >= 20)
                    break;
                Tour(Joueurs[1], Joueurs[0]);
            }
            // On vérifie s'il y a égalité
            if (Joueurs[0].argent >= 20 && Joueurs[1].argent >= 20)
            {
                Debug.WriteLine("Egalité !");
                gagnant = 0;
            }               
            // On vérifie si le Joueur 2 a gagné
            else if (Joueurs[1].argent >= 20)
            {
                Debug.WriteLine("Le joueur 2 gagne !");
                gagnant = 2;
            }
            else
            {
                Debug.WriteLine("Le joueur 1 gagne!");
            }

        }


        // Fonction qui permet le déroulement d'un tour
        public void Tour(Player p1, Player p2)
        {
            //Ajoute un élément dans la queue d'instructions 
            instructionQueue.Enqueue(() => { Des[0].Lancer(); });
            instructionQueue.Enqueue(() => { p2.TesterCartesJoueur(p1, Des[0].Face, false); });
            instructionQueue.Enqueue(() => { p1.TesterCartesJoueur(p2, Des[0].Face, true); });
            instructionQueue.Enqueue(() => { p1.strategy.ChoisirCarte(p1, p2, CartesDisponibles); });
           
        }

        public void update()
        {
            //Enlève un élément de la queue d'instructions 
            if (instructionQueue.Count == 0)
            {
                return;
            }
            Action a = instructionQueue.Dequeue();
            //Execute l'action
            ThreadStart threadDelegate = new ThreadStart(a);
            Thread t = new Thread(threadDelegate);
            t.Start();
            Debug.WriteLine("Instruction done");
        }
    }
}
