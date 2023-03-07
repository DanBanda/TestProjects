using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaMicroservicios.BE
{
    public class Movimiento
    {
        [Key]
        public int IdMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public int NumCuenta { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public bool Estado { get; set; }
        public string DescMovimiento { get; set; }
        public decimal SaldoFinal { get; set; }
    }
}