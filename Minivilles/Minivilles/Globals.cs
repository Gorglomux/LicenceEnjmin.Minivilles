using System;
using System.Collections.Generic;
using System.Text;

namespace Minivilles
{
    // Définition des variables globales et des énumérations
    public enum CARD_ID {CHAMP_BLE, FERME, BOULANGERIE, CAFE, SUPERETTE, FORET, RESTAURANT, STADE};
    public enum COULEUR {BLEU, ROUGE, VERT };
    public static class Globals
    {
        public static Dictionary<CARD_ID, Action<string, string>> EFFETS = new Dictionary<CARD_ID, Action<string, string>>()
        {
            { CARD_ID.CHAMP_BLE, (p1, p2) => { p1.argent++; } },
            { CARD_ID.FERME, (p1, p2) => { p1.argent++; } },
            { CARD_ID.BOULANGERIE, (p1, p2) => { p1.argent += 2; } },
            { CARD_ID.CAFE, (p1, p2) => { p1.argent ++; p2.argent--; } },
            { CARD_ID.SUPERETTE, (p1, p2) => { p1.argent +=3;} },
            { CARD_ID.FORET, (p1, p2) => { p1.argent ++;} },
            { CARD_ID.RESTAURANT, (p1, p2) => { p1.argent += 2; p2.argent -= 2; } },
            { CARD_ID.STADE, (p1, p2) => { p1.argent += 4; } },


        };

        

    }
}
