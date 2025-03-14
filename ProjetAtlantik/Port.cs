using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAtlantik
{
    internal class Port
    {
        public string nom;
        public int noPort;

        public Port(string nom, int noPort)
        {
            this.nom = nom;
            this.noPort = noPort;
        }
        public string GetNom()
        {
            return nom;
        }
        public int GetNoPort()
        {
            return noPort;
        }
        public override string ToString()
        {
            return nom;
        }
    }
}
