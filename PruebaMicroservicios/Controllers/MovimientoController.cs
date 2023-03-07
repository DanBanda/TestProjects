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
    public class MovimientoController : Controller
    {
        ILogger logger;
        private readonly AppDbContext contextDB;

        public MovimientoController(AppDbContext context)
        {
            this.contextDB = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            BLMovimiento blMovimiento = new BLMovimiento(contextDB);
            try
            {
                var movimientos = blMovimiento.GetAll();
                return Ok(movimientos);
            }
            catch (Exception ex)
            {
                ///TODO: agregar regristo de logeo de objeto "EX"
                logger?.LogError(ex, ex.Message);
                var result = new ResultadoMovimiento();
                result.EstatusTX = "0";
                result.MessageTX = "Ha ocurrido un Error: " + ex.Message.ToString() + "\nNo se pudo obtener los Movimientos registrados";
                return Ok(result);
            }
        }

        [HttpGet("{fromDate}/{toDate}")]
        public IActionResult GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            BLMovimiento blMovimientos = new BLMovimiento(contextDB);
            try
            {
                var movimientos = blMovimientos.GetByDateRange(fromDate, toDate);
                return Ok(movimientos);
            }
            catch (Exception ex)
            {
                ///TODO: agregar regristo de logeo de objeto "EX"
                logger?.LogError(ex, ex.Message);
                var result = new ResultadoMovimiento();
                result.EstatusTX = "0";
                result.MessageTX = "Ha ocurrido un Error: " + ex.Message.ToString() + "\nNo se pudo obtener los Movimientos registrados por rango de fechas";
                return Ok(result);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] Movimiento movimiento)
        {
            BLMovimiento blMovimiento = new BLMovimiento(contextDB);
            var result = new ResultadoMovimiento();
            try
            {
                result = blMovimiento.Add(movimiento);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(result);
            }
        }

        [HttpDelete("{idMovimiento}")]
        public IActionResult Delete(int idMovimiento)
        {
            BLMovimiento blMovimiento = new BLMovimiento(contextDB);
            var result = new ResultadoMovimiento();
            try
            {
                result = blMovimiento.Delete(idMovimiento);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(result);
            }
        }
    }
}