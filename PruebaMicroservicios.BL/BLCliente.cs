using PruebaMicroservicios.BE;
using PruebaMicroservicios.DAL;
using PruebaMicroservicios.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMicroservicios.BL
{
    public class BLCliente
    {
        private readonly AppDbContext contextDB;
        public BLCliente(AppDbContext context)
        {
            this.contextDB = context;
        }

        public IEnumerable<Cliente> GetAll()
        {
            DALCliente dalCliente = new DALCliente(contextDB);
            try
            {
                var clientes = dalCliente.GetAll();
                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResultadoCliente GetById(int id)
        {
            DALCliente dalCliente = new DALCliente(contextDB);
            var result = dalCliente.GetById(id);
            try
            {
                if (result.Cliente != null)
                {
                    result.EstatusTX = "1";
                    result.MessageTX = "Consulta Realizada";
                }
                else
                {
                    result.EstatusTX = "0";
                    result.MessageTX = "No existe el cliente registrado con el Id: " + id.ToString();
                }
            }
            catch (Exception ex)
            {
                result.EstatusTX = "0";
                result.MessageTX = "Ha ocurrido un Error: " + ex.Message.ToString() + "\nPor el momento no es posible atender su petición.";
            }
            return result;
        }

        public ResultadoCliente Add(Cliente cliente)
        {
            DALCliente dalCliente = new DALCliente(contextDB);
            var result = dalCliente.Add(cliente);
            try
            {
                if (result.Cliente != null)
                {
                    result.EstatusTX = "1";
                    result.MessageTX = "Se registró un nuevo cliente";
                }
                else
                {
                    result.EstatusTX = "0";
                    result.MessageTX = "No se pudo registrar el cliente";
                }
            }
            catch (Exception ex)
            {
                result.EstatusTX = "0";
                result.MessageTX = "Ha ocurrido un Error: " + ex.Message.ToString() + "\nPor el momento no es posible guardar la información.";
            }
            return result;
        }

        public ResultadoCliente Update(int id, Cliente cliente)
        {
            DALCliente dalCliente = new DALCliente(contextDB);
            var result = dalCliente.Update(id, cliente);
            try
            {
                if (result.Cliente != null)
                {
                    result.EstatusTX = "1";
                    result.MessageTX = "Se actualizó la información del cliente";
                }
                else
                {
                    result.EstatusTX = "0";
                    result.MessageTX = "No existe el cliente registrado con el Id: " + cliente.IdCliente.ToString();
                }
            }
            catch (Exception ex)
            {
                result.EstatusTX = "0";
                result.MessageTX = "Ha ocurrido un Error: " + ex.Message.ToString() + "\nPor el momento no es posible actualizar la información";
            }
            return result;
        }

        public ResultadoCliente Delete(int id)
        {
            DALCliente dalCliente = new DALCliente(contextDB);
            var result = dalCliente.Delete(id);
            try
            {
                if (result.EstatusTX == "1")
                {
                    result.MessageTX = "Se eliminó el cliente registrado con el Id: " + id.ToString();
                }
                else
                {
                    result.MessageTX = "No existe un cliente registrado con el Id: " + id.ToString();
                }
            }
            catch (Exception ex)
            {
                result.EstatusTX = "0";
                result.MessageTX = "Ha ocurrido un Error: " + ex.Message.ToString() + "\nPor el momento no es posible eliminar el cliente.";
            }
            return result;
        }
    }
}