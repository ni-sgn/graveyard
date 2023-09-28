using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.entities
{
    internal class Graveyard {
        public int id { get; set; }
        public int number_of_graves { get; set; }
        public DateOnly date_of_creation { get; set; }


        public int owner; 
    }
}
