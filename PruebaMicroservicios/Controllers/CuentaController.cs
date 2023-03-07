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
    public class CuentaController : Controller
    {
        ILogger logger;
        private readonly AppDbContext contextDB;
        public CuentaController(AppDbContext context)
        {
            this.contextDB = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            BLCuenta blCuenta = new BLCuenta(contextDB);
            try
            {
                var cuentas = blCuenta.GetAll();
                return Ok(cuentas);
            }
            catch (Exception ex)
            {
                ///TODO: agregar regristo de logeo de objeto "EX"
                logger?.LogError(ex, ex.Message);
                var result = new ResultadoCuenta();
                result.EstatusTX = "0";
                result.MessageTX = "Ha ocurrido un error, No es posible atender tu petición.";
                return Ok(result);
            }
        }

        [HttpGet("{numCuenta}")]
        public IActionResult GetByNumCuenta(int numCuenta)
        {
            BLCuenta blCuenta = new BLCuenta(contextDB);
            var result = new ResultadoCuenta();
            try
            {
                result = blCuenta.GetByNumCuenta(numCuenta);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(result);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Cuenta cuenta)
        {
            BLCuenta blCuenta = new BLCuenta(contextDB);
            var result = new ResultadoCuenta();
            try
            {
                result = blCuenta.Add(cuenta);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(result);
            }
        }

        [HttpPut("{numCuenta}")]
        public IActionResult Update(int numCuenta, [FromBody] Cuenta cuenta)
        {
            BLCuenta blCuenta = new BLCuenta(contextDB);
            var result = new ResultadoCuenta();
            try
            {
                result = blCuenta.Update(numCuenta, cuenta);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(result);
            }
        }

        [HttpDelete("{numCuenta}")]
        public IActionResult Delete(int numCuenta)
        {
            BLCuenta blCuenta = new BLCuenta(contextDB);
            var result = new ResultadoCuenta();
            try
            {
                result = blCuenta.Delete(numCuenta);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(result);
            }
        }
    }
}