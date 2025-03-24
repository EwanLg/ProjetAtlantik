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
        private int noPort_Depart;
        private int noPort_Arrivee;
        private int noSecteur;
        private int noLiaison;

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
