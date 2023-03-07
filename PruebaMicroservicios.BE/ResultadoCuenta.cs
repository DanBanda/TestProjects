using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMicroservicios.BE
{
    public class ResultadoCuenta
    {
        public string EstatusTX { get; set; }
        public string MessageTX { get; set; }
        public Cuenta Cuenta { get; set; }
    }
}