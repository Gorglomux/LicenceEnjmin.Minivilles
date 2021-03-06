﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

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


        public Card(int cout, COULEUR couleur, string nom, string descriptionEffet, List<int> valeurActivation, CARD_ID id)
        {
            this.cout = cout;
            this.couleur = couleur;
            this.nom = nom;
            this.descriptionEffet = descriptionEffet;
            this.valeurActivation = valeurActivation;
            ID = id;
        }
        public Card(Card c)
        {
            this.cout = c.cout;
            this.couleur = c.couleur;
            this.nom = c.nom;
            this.descriptionEffet = c.descriptionEffet;
            this.valeurActivation = new List<int>(c.valeurActivation);
            ID = c.ID;
        }

        public  string AfficheValeur()
        {
            string tostring = "";
            foreach (int val in valeurActivation)
            {
                tostring += String.Format("{0},", val);
            }
            return tostring;
        }
    }
}
