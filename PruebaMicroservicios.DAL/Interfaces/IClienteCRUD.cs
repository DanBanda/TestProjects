using PruebaMicroservicios.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaMicroservicios.DAL.Interfaces
{
    public interface IClienteCRUD
    {
        IEnumerable<Cliente> GetAll();
        ResultadoCliente GetById(int id);
        ResultadoCliente Add(Cliente cliente);
        ResultadoCliente Delete(int id);
        ResultadoCliente Update(int id, Cliente cliente);
    }
}