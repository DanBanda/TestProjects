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
    public class DALCliente : IClienteCRUD
    {
        private readonly AppDbContext contextDB;

        public DALCliente(AppDbContext context)
        {
            this.contextDB = context;
        }

        public ResultadoCliente Add(Cliente cliente)
        {
            var result = new ResultadoCliente();
            contextDB.Cliente.Add(cliente);
            contextDB.SaveChanges();
            result.Cliente = cliente;
            return result;
        }

        public ResultadoCliente Delete(int id)
        {
            var result = new ResultadoCliente();
            var cliente = contextDB.Cliente.FirstOrDefault(c => c.IdCliente == id);
            if (cliente != null)
            {
                contextDB.Cliente.Remove(cliente);
                contextDB.SaveChanges();
                result.EstatusTX = "1";
            }
            else
            {
                result.EstatusTX = "0";
            }
            return result;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return contextDB.Cliente.ToList();
        }

        public ResultadoCliente GetById(int id)
        {
            var result = new ResultadoCliente();
            var clienteEncontrado = contextDB.Cliente.FirstOrDefault(c => c.IdCliente == id);
            result.Cliente = clienteEncontrado;
            return result;
        }

        public ResultadoCliente Update(int id, Cliente cliente)
        {
            var result = new ResultadoCliente();
            var data = contextDB.Cliente.FirstOrDefault(c => c.IdCliente == id);

            if (data != null)
            {
                data.Contrasena = cliente.Contrasena;
                data.Estado = cliente.Estado;
                data.Nombre = cliente.Nombre;
                data.Genero = cliente.Genero;
                data.Edad = cliente.Edad;
                data.Direccion = cliente.Direccion;
                data.Telefono = cliente.Telefono;
                contextDB.SaveChanges();
                result.Cliente = data;

                /*
                contextDB.Entry(cliente).State = EntityState.Modified;
                contextDB.SaveChanges();
                result.Cliente = cliente;
                */
            }
            return result;
        }
    }
}