using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.FacadePattern.PrescribeRules
{
    internal class Attractive : PrescribeBase
    {
        public Attractive() { }
        public override Prescription GetPrescribe(string id, string symptions) 
        {
            return new Prescription
            {

            };
        }
    }
}
