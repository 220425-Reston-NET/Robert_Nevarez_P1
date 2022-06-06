using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using LeagueStoreBL;
using Summoner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                return Ok(_neworderhistory.SumOrderHistory(_SumName));
            }
            catch (System.InvalidOperationException)
            {
                
                return NotFound("Summoner was not found");
            }
        }

        [HttpGet("StoreOrderHistory")]

        public IActionResult StoreOrderHistory([FromQuery] string _StoreName)
        {
            try
            {
                return Ok(_neworderhistory.StoreOrderHistory(_StoreName));
            }
            catch (System.InvalidOperationException)
            {
                
                return NotFound("Summoner was not found");
            }
        }

    }

}