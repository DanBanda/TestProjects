using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaMicroservicios.BE
{
    public class Cliente : Persona
    {
        [Key]
        public int IdCliente { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }
    }
}