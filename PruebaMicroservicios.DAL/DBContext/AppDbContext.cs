using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMicroservicios.DAL.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }
    }
}