﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMicroservicios.BE
{
    public class ResultadoMovimiento
    {
        public string EstatusTX { get; set; }
        public string MessageTX { get; set; }
        public Movimiento Movimiento { get; set; }
    }
}