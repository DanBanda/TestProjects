using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaMicroservicios.BE
{
    public class Cuenta
    {
        [Key]
        public int NumCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public string Cliente { get; set; }
    }
}