using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMicroservicios.BE
{
    public class ResultadoCliente
    {
        public string EstatusTX { get; set; }
        public string MessageTX { get; set; }
        public Cliente Cliente { get; set; }
    }
}