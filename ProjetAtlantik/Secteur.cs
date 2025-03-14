using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAtlantik
{
    internal class Secteur
    {
        public string nouvNom;

        public Secteur(string nom)
        {
            nouvNom = nom;
        }
        public override string ToString()
        {
            return nouvNom;
        }
    }
}
