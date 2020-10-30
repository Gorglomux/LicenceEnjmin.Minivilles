using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Minivilles
{
    public class PlayerStrategy : Strategy
    {
        public void ChoisirCarte(Player p1, Player p2, Pile p)
        {
            Console.WriteLine("Les cartes de votre adversaire : ");
            foreach (var c in p2.cartesEnJeu._cartes)
            {
                if (c.Value != 0)
                {
                    Console.WriteLine("{0} | couleur : {1} | nombre : {2}", c.Key, Globals.CardInfo[c.Key].couleur, c.Value);
                }
            }

            Console.WriteLine("\nVos cartes : ");
            foreach(var c in p1.cartesEnJeu._cartes)
            {
                if(c.Value != 0)
                {
                    Console.WriteLine("{0} | couleur : {1} | nombre : {2}", c.Key, Globals.CardInfo[c.Key].couleur, c.Value);
                }              
            }
            
            Console.WriteLine("\nVoulez-vous acheter une carte ?\n Oui : o  Non : n");
            string ouput = Console.ReadLine();
            if(ouput == "o")
            {
                if (p1.argent == 0 || p1.argent > 12)
                {
                    Console.WriteLine("Désolé, vous n'avez plus d'argent !\n");
                    return;
                }
                //Liste de cartes que le joueur peut acheter
                List<Card> canBuy = new List<Card>();
                foreach (CARD_ID c in p._cartes.Keys)
                {
                    //Si il reste un exemplaire de la carte
                    if (p._cartes[c] > 0 && p1.argent >= Globals.CardInfo[c].cout)
                    {
                        canBuy.Add(new Card(Globals.CardInfo[c]));
                    }
                }

                Console.WriteLine("Vous pouvez acheter :");
                for(int i = 0; i < canBuy.Count; i++)
                {
                    Console.WriteLine("{0} : {1} couleur : {2} Cout : {3}", i, canBuy[i].nom, canBuy[i].couleur,canBuy[i].cout);
                }
                Console.WriteLine("\nAnnuler : a");
                string res = Console.ReadLine();
                if(res == "a")
                {
                    return;
                }
                else
                {
                    p1.AcheterCarte(canBuy[Int16.Parse(res)], p);
                }
            }else if(ouput == "n")
            {
                //Il ne se passe rien
            }

            Console.WriteLine("\n-----Fin de votre tour-----\n");
        }
    }
}
