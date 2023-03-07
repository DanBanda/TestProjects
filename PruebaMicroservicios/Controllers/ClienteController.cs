using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaMicroservicios.BE;
using PruebaMicroservicios.BL;
using PruebaMicroservicios.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaMicroservicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        ILogger logger;
        private readonly AppDbContext contextDB;
        public ClienteController(AppDbContext context)
        {
            this.contextDB = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            BLCliente blCliente = new BLCliente(contextDB);
            try
            {
                var clientes = blCliente.GetAll();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                ///TODO: agregar regristo de logeo de objeto "EX"
                logger?.LogError(ex, ex.Message);
                var result = new ResultadoCliente();
                result.EstatusTX = "0";
                result.MessageTX = "Ha ocurrido un error, No es posible atender tu petición.";
                return Ok(result);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BLCliente blCliente = new BLCliente(contextDB);
            var result = new ResultadoCliente();
            try
            {
                result = blCliente.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(result);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Cliente cliente)
        {
            BLCliente blCliente = new BLCliente(contextDB);
            var result = new ResultadoCliente();
            try
            {
                result = blCliente.Add(cliente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(result);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Cliente cliente)
        {
            BLCliente blCliente = new BLCliente(contextDB);
            var result = new ResultadoCliente();
            try
            {
                result = blCliente.Update(id, cliente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(result);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            BLCliente blCliente = new BLCliente(contextDB);
            var result = new ResultadoCliente();
            try
            {
                result = blCliente.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(result);
            }
        }
    }
}