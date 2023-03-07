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
    public class DALCuenta : ICuentaCRUD
    {
        private readonly AppDbContext contextDB;

        public DALCuenta(AppDbContext context)
        {
            this.contextDB = context;
        }

        public ResultadoCuenta Add(Cuenta cuenta)
        {
            var result = new ResultadoCuenta();
            contextDB.Cuenta.Add(cuenta);
            contextDB.SaveChanges();
            result.Cuenta = cuenta;
            return result;
        }

        public ResultadoCuenta Delete(int numCuenta)
        {
            var result = new ResultadoCuenta();
            var cuenta = contextDB.Cuenta.FirstOrDefault(c => c.NumCuenta == numCuenta);
            if (cuenta != null)
            {
                contextDB.Cuenta.Remove(cuenta);
                contextDB.SaveChanges();
                result.EstatusTX = "1";
            }
            else
            {
                result.EstatusTX = "0";
            }
            return result;
        }

        public IEnumerable<Cuenta> GetAll()
        {
            return contextDB.Cuenta.ToList();
        }

        public ResultadoCuenta GetByNumCuenta(int numCuenta)
        {
            var result = new ResultadoCuenta();
            var cuentaEncontrada = contextDB.Cuenta.FirstOrDefault(c => c.NumCuenta == numCuenta);
            result.Cuenta = cuentaEncontrada;
            return result;
        }

        public ResultadoCuenta Update(int numCuenta, Cuenta cuenta)
        {
            var result = new ResultadoCuenta();
            var data = contextDB.Cuenta.FirstOrDefault(c => c.NumCuenta == numCuenta);

            if (data != null)
            {
                data.TipoCuenta = cuenta.TipoCuenta;
                data.SaldoInicial = cuenta.SaldoInicial;
                data.Estado = cuenta.Estado;
                data.Cliente = cuenta.Cliente;
                contextDB.SaveChanges();
                result.Cuenta = data;

                /*
                contextDB.Entry(cuenta).State = EntityState.Modified;
                contextDB.SaveChanges();
                result.Cuenta = cuenta;
                */
            }
            return result;
        }
    }
}