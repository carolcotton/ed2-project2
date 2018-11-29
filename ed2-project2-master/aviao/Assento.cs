using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aviao
{
    class Assento
    {
        private bool ocupado;

        public bool Ocupado
        {
            get { return ocupado; }
            set { ocupado = value; }
        }

        public Assento()
        {
           ocupado = false;
        }
    }
}
