using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prodProject
{
    public class Pieza
    {
        public int id;
        public string descripcion { get; set; }
        public string claveComp { get; set; }
        public string inicioCadena { get; set; }
        public string finCadena { get; set; }
        public int pasos { get; set; }
        public int puntoReescaneo { get; set; }
        public Pieza() 
        {
            
        }
    }
}
