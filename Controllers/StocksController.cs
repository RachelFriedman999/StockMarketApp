using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockMarketApp.BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockMarketApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly ILogger<StocksController> _logger;
        private readonly IStocksManager _stocksManager;

        public StocksController(ILogger<StocksController> logger, IStocksManager stockManager)
        {
            _logger = logger;
            _stocksManager = stockManager;
        }

        [HttpGet]
        public IActionResult Get(DateTime? fromDate = null)
        {
            try
            {
                var res = _stocksManager.GetStocks(fromDate);
                if (res != null)
                {
                    return Ok(res);
                }
                else return BadRequest(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.ToString());

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }

        }
    }
}
