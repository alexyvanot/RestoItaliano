using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoItaliano.src.enumerations;

namespace RestoItaliano.src.interfaces
{
    public interface IMeal
    {
        public string GetName();
        public string GetDescription();
        public Nutriscore GetNutriscore();
    }
}
