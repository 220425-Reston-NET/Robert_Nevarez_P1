using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using LeagueStoreBL;
using Summoner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace LeagueStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController : ControllerBase
    {
        
        private readonly IOrderHistoryBL _neworderhistory;

        public OrderHistoryController(IOrderHistoryBL neworderhistory)
        {
            _neworderhistory = neworderhistory;
        }

        [HttpGet("SummonerOrderHistory")]

        public IActionResult SummonerOrderHistory([FromQuery] string _SumName)
        {
            try
            {
                Log.Information("User tried to search order history for " + _SumName);

                List<OrderHistory> Sumorderhistory = _neworderhistory.SumOrderHistory(_SumName);
                

                return Ok(Sumorderhistory);
            }
            catch (System.InvalidOperationException)
            {
                Log.Warning("User searched order history for " + _SumName + " however that user does not exist!");

                return NotFound("Summoner was not found");
            }
        }

        [HttpGet("StoreOrderHistory")]

        public IActionResult StoreOrderHistory([FromQuery] string _StoreName)
        {
            try
            {
                Log.Information("User tried to search store order history for " + _StoreName);

                return Ok(_neworderhistory.StoreOrderHistory(_StoreName));
            }
            catch (System.InvalidOperationException)
            {
                Log.Warning("User searched store order history for " + _StoreName + " however that store does not exist!");

                return NotFound("Store was not found");
            }
        }

    }

}