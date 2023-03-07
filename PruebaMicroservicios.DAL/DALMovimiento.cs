using Microsoft.EntityFrameworkCore;
using PruebaMicroservicios.BE;
using PruebaMicroservicios.DAL.DBContext;
using PruebaMicroservicios.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaMicroservicios.DAL
{
    public class DALMovimiento : IMovimientoCRUD
    {
        private readonly AppDbContext contextDB;

        public DALMovimiento(AppDbContext context)
        {
            this.contextDB = context;
        }

        public ResultadoMovimiento Add(Movimiento movimiento)
        {
            decimal saldoInicial;
            Cuenta datosCuenta = new Cuenta();
            var result = new ResultadoMovimiento();
            if (movimiento.TipoMovimiento == "Debito")
            {
                datosCuenta = contextDB.Cuenta.FirstOrDefault(c => c.NumCuenta == movimiento.NumCuenta);
                if (datosCuenta != null)
                {
                    saldoInicial = datosCuenta.SaldoInicial;
                    if (saldoInicial > 0)
                    {
                        contextDB.Movimiento.Add(movimiento);
                        contextDB.SaveChanges();
                        result.EstatusTX = "1";
                        result.MessageTX = "Se registró un movimiento para el NumCuenta: " + movimiento.NumCuenta.ToString() + "\nCliente: " + movimiento.Cliente.ToString();
                        result.Movimiento = movimiento;
                    }
                    else
                    {
                        result.EstatusTX = "0";
                        result.MessageTX = "Saldo No Disponible";
                    }
                }
            }
            else
            {
                contextDB.Movimiento.Add(movimiento);
                contextDB.SaveChanges();
                result.EstatusTX = "1";
                result.MessageTX = "Se registró un movimiento para el NumCuenta: " + movimiento.NumCuenta.ToString() + "\nCliente: " + movimiento.Cliente.ToString();
                result.Movimiento = movimiento;
            }
            return result;
        }

        public ResultadoMovimiento Delete(int idMovimiento)
        {
            var result = new ResultadoMovimiento();
            var movimiento = contextDB.Movimiento.FirstOrDefault(m => m.IdMovimiento == idMovimiento);
            if (movimiento != null)
            {
                contextDB.Movimiento.Remove(movimiento);
                contextDB.SaveChanges();
                result.EstatusTX = "1";
            }
            else
            {
                result.EstatusTX = "0";
            }
            return result;
        }

        public IEnumerable<Movimiento> GetAll()
        {
            return contextDB.Movimiento.ToList();
        }

        public List<Movimiento> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            return contextDB.Movimiento.Where(m => m.Fecha >= fromDate && m.Fecha <= toDate).ToList();
        }
    }
}