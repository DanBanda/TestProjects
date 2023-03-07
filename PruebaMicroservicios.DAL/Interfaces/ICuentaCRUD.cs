using PruebaMicroservicios.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMicroservicios.DAL.Interfaces
{
    public interface ICuentaCRUD
    {
        IEnumerable<Cuenta> GetAll();
        ResultadoCuenta GetByNumCuenta(int numCuenta);
        ResultadoCuenta Add(Cuenta cuenta);
        ResultadoCuenta Delete(int numCuenta);
        ResultadoCuenta Update(int numCuenta, Cuenta cuenta);
    }
}