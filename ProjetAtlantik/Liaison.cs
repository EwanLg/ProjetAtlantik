using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAtlantik
{
    internal class Liaison
    {
        public int noPort_Depart;
        public int noPort_Arrivee;
        public int noSecteur;
        public int noLiaison;

        public Liaison(int noPort_Depart, int noPort_Arrivee, int noSecteur, int noLiaison)
        {
            this.noPort_Depart = noPort_Depart;
            this.noPort_Arrivee = noPort_Arrivee;
            this.noSecteur = noSecteur;
            this.noLiaison = noLiaison;
        }
        public int GetNoPort_Depart()
        {
            return noPort_Depart;
        }
        public int GetNoPort_Arrivee()
        {
            return noPort_Arrivee;
        }
        public int GetNoSecteur()
        {
            return noSecteur;
        }
        public int GetNoLiaison()
        {
            return noLiaison;
        }
        public override string ToString()
        {
            return noLiaison.ToString();
        }
    }
}
