using PruebaMicroservicios.BE;
using PruebaMicroservicios.DAL;
using PruebaMicroservicios.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMicroservicios.BL
{
    public class BLMovimiento
    {
        private readonly AppDbContext contextDB;
        public BLMovimiento(AppDbContext context)
        {
            this.contextDB = context;
        }

        public IEnumerable<Movimiento> GetAll()
        {
            DALMovimiento dalMovimiento = new DALMovimiento(contextDB);
            try
            {
                var movimientos = dalMovimiento.GetAll();
                return movimientos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Movimiento> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            DALMovimiento dalMovimiento = new DALMovimiento(contextDB);
            try
            {
                var movimientos = dalMovimiento.GetByDateRange(fromDate, toDate);
                return movimientos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResultadoMovimiento Add(Movimiento movimiento)
        {
            DALMovimiento dalMovimiento = new DALMovimiento(contextDB);
            ResultadoMovimiento result;
            try
            {
                result = dalMovimiento.Add(movimiento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public ResultadoMovimiento Delete(int idMovimiento)
        {
            DALMovimiento dalMovimiento = new DALMovimiento(contextDB);
            var result = dalMovimiento.Delete(idMovimiento);
            try
            {
                if (result.EstatusTX == "1")
                {
                    result.MessageTX = "Se eliminó el movimiento: " + idMovimiento.ToString();
                }
                else
                {
                    result.MessageTX = "No se pudo eliminar el movimiento: " + idMovimiento.ToString();
                }
            }
            catch (Exception ex)
            {
                result.EstatusTX = "0";
                result.MessageTX = "Ha ocurrido un Error: " + ex.Message.ToString() + "\nPor el momento no es posible eliminar el Movimiento.";
            }
            return result;
        }
    }
}