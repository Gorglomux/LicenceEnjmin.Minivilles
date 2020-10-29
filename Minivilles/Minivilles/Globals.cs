﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Minivilles
{
    // Définition des variables globales et des énumérations
    public enum CARD_ID {CHAMP_BLE, FERME, BOULANGERIE, CAFE, SUPERETTE, FORET, RESTAURANT/*, STADE*/};
    public enum COULEUR {BLEU, ROUGE, VERT };

    
    public static class Globals
    {

        
        public static Dictionary<CARD_ID, Action<Player, Player>> EFFETS { get; set; } = new Dictionary<CARD_ID, Action<Player, Player>>()
        {
            { CARD_ID.CHAMP_BLE, (p1, p2) => { p1.argent++; } },
            { CARD_ID.FERME, (p1, p2) => { p1.argent++; } },
            { CARD_ID.BOULANGERIE, (p1, p2) => { p1.argent += 2; } },
            { CARD_ID.CAFE, (p1, p2) => { 
                if(p2.argent > 0)
                {
                    p1.argent ++; p2.argent--;

                }
            } },
            { CARD_ID.SUPERETTE, (p1, p2) => { p1.argent +=3;} },
            { CARD_ID.FORET, (p1, p2) => { p1.argent ++;} },
            { CARD_ID.RESTAURANT, (p1, p2) => {
                if(p2.argent > 2)
                {
                    p1.argent += 2; p2.argent -= 2;
                }else if (p2.argent > 0)
                {
                    p1.argent += p2.argent; p2.argent = 0;
                }
            } },
            //{ CARD_ID.STADE, (p1, p2) => { p1.argent += 4; } },

        };

        public static Dictionary<CARD_ID, Card> CardInfo = new Dictionary<CARD_ID, Card>()
        {
            { CARD_ID.CHAMP_BLE, new Card(1,COULEUR.BLEU,"Champs de blé","Recevez 1 pièce",new List<int>(){1},CARD_ID.CHAMP_BLE,LoadCbTemplate(@"Images\Champs.png") )},
            { CARD_ID.FERME, new Card(2,COULEUR.BLEU,"Ferme","Recevez 1 pièce",new List<int>(){1},CARD_ID.FERME,LoadCbTemplate(@"Images\Ferme.png"))},
            { CARD_ID.BOULANGERIE, new Card(1,COULEUR.VERT,"Boulangerie","Recevez 2 pièces",new List<int>(){2,3},CARD_ID.BOULANGERIE,LoadCbTemplate(@"Images\Boulangerie.png"))},
            { CARD_ID.CAFE, new Card(2,COULEUR.ROUGE,"Café","Recevez 1 pièces du joueur qui a lancé le dé",new List<int>(){3},CARD_ID.CAFE,LoadCbTemplate(@"Images\Cafe.png"))},
            { CARD_ID.SUPERETTE, new Card(2,COULEUR.VERT,"Superette","Recevez 3 pièces",new List<int>(){4},CARD_ID.SUPERETTE,LoadCbTemplate(@"Images\Superette.png"))},
            { CARD_ID.FORET, new Card(3,COULEUR.BLEU,"Forêt","Recevez 1 pièce",new List<int>(){5},CARD_ID.FORET,LoadCbTemplate(@"Images\Foret.png"))},
            { CARD_ID.RESTAURANT, new Card(4,COULEUR.ROUGE,"Restaurant","Recevez 2 pièces du joueur qui a lancé le dé",new List<int>(){5},CARD_ID.RESTAURANT,LoadCbTemplate(@"Images\Restaurant.png"))},
            //{ CARD_ID.STADE, new Card(6,COULEUR.BLEU,"Stade","Recevez 4 pièce",new List<int>(){6},CARD_ID.STADE,loadPbTemplate("Images/champs.jpg"))}
        };


        public static List<Card> cartesDeBase = new List<Card>()
        {
            new Card(CardInfo[CARD_ID.CHAMP_BLE]),
            new Card(CardInfo[CARD_ID.BOULANGERIE])
        };

        public static CardBox LoadCbTemplate(string image_location)
        {
            CardBox cb = new CardBox();
            try
            {
                cb.ImageLocation = image_location;
            }catch( Exception e)
            {
                Debug.Write(e.Message);
                return null;
            }
            //cb.SizeMode = PictureBoxSizeMode.StretchImage;
            cb.Size = new Size(120, 100);
            return cb;
        }
    }
}
