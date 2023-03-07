using PruebaMicroservicios.BE;
using PruebaMicroservicios.DAL;
using PruebaMicroservicios.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMicroservicios.BL
{
    public class BLCuenta
    {
        private readonly AppDbContext contextDB;
        public BLCuenta(AppDbContext context)
        {
            this.contextDB = context;
        }

        public IEnumerable<Cuenta> GetAll()
        {
            DALCuenta dalCuenta = new DALCuenta(contextDB);
            try
            {
                var cuentas = dalCuenta.GetAll();
                return cuentas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResultadoCuenta GetByNumCuenta(int numCuenta)
        {
            DALCuenta dalCuenta = new DALCuenta(contextDB);
            var result = dalCuenta.GetByNumCuenta(numCuenta);
            try
            {
                if (result.Cuenta != null)
                {
                    result.EstatusTX = "1";
                    result.MessageTX = "Consulta Realizada";
                }
                else
                {
                    result.EstatusTX = "0";
                    result.MessageTX = "No existe la cuenta registrada con el NumCuenta: " + numCuenta.ToString();
                }
            }
            catch (Exception ex)
            {
                result.EstatusTX = "0";
                result.MessageTX = "Ha ocurrido un Error: " + ex.Message.ToString() + "\nPor el momento no es posible atender su petición.";
            }
            return result;
        }

        public ResultadoCuenta Add(Cuenta cuenta)
        {
            DALCuenta dalCuenta = new DALCuenta(contextDB);
            var result = dalCuenta.Add(cuenta);
            try
            {
                if (result.Cuenta != null)
                {
                    result.EstatusTX = "1";
                    result.MessageTX = "Se creó una nueva cuenta";
                }
                else
                {
                    result.EstatusTX = "0";
                    result.MessageTX = "No se pudo crear la cuenta";
                }
            }
            catch (Exception ex)
            {
                result.EstatusTX = "0";
                result.MessageTX = "Ha ocurrido un Error: " + ex.Message.ToString() + "\nPor el momento no es posible guardar la información.";
            }
            return result;
        }

        public ResultadoCuenta Update(int numCuenta, Cuenta cuenta)
        {
            DALCuenta dalCuenta = new DALCuenta(contextDB);
            var result = dalCuenta.Update(numCuenta, cuenta);
            try
            {
                if (result.Cuenta != null)
                {
                    result.EstatusTX = "1";
                    result.MessageTX = "Se actualizó la información de la cuenta: " + numCuenta.ToString();
                }
                else
                {
                    result.EstatusTX = "0";
                    result.MessageTX = "No existe la cuenta registrada: " + numCuenta.ToString();
                }
            }
            catch (Exception ex)
            {
                result.EstatusTX = "0";
                result.MessageTX = "Ha ocurrido un Error: " + ex.Message.ToString() + "\nPor el momento no es posible actualizar la información.";
            }
            return result;
        }

        public ResultadoCuenta Delete(int numCuenta)
        {
            DALCuenta dalCuenta = new DALCuenta(contextDB);
            var result = dalCuenta.Delete(numCuenta);
            try
            {
                if (result.EstatusTX == "1")
                {
                    result.MessageTX = "Se eliminó la cuenta: " + numCuenta.ToString();
                }
                else
                {
                    result.MessageTX = "No existe la cuenta: " + numCuenta.ToString();
                }
            }
            catch (Exception ex)
            {
                result.EstatusTX = "0";
                result.MessageTX = "Ha ocurrido un Error: " + ex.Message.ToString() + "\nPor el momento no es posible eliminar la cuenta.";
            }
            return result;
        }
    }
}