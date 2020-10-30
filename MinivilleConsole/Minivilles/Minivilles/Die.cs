using System;
using System.Collections.Generic;
using System.Text;

namespace Minivilles
{
    public class Die
    {
        public int Face;
        public Random rdn;

        public Die()
        {
            rdn = new Random();
        }
        public int Lancer()
        {
            Face = rdn.Next(1, 7);
            return Face;
        }
    }
}
