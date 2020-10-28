using System;
using System.Collections.Generic;
using System.Text;

namespace Minivilles
{
    public interface Strategy
    {
        public abstract void choisirCarte(Player p1, Player p2);


    }
}
