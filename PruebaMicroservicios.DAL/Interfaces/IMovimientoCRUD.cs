using PruebaMicroservicios.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMicroservicios.DAL.Interfaces
{
    public interface IMovimientoCRUD
    {
        IEnumerable<Movimiento> GetAll();
        List<Movimiento> GetByDateRange(DateTime fromDate, DateTime toDate);
        ResultadoMovimiento Add(Movimiento movimiento);
        ResultadoMovimiento Delete(int idMovimiento);
    }
}