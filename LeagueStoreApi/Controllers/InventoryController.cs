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
    public class InventoryController : ControllerBase
    {
        private readonly IStoreItemsBL _leaguebl2;

        public InventoryController(IStoreItemsBL leaguebl2)
        {
            _leaguebl2 = leaguebl2;
        }
    

    [HttpGet("SearchInventoryByStore")]

        public IActionResult SearchInventoryByStore([FromQuery] string _StoreName)
        {
            try
            {
                return Ok(_leaguebl2.SearchStore(_StoreName));
            }
            catch (System.InvalidOperationException)
            {
                
                return NotFound("Store was not found");
            }
        }

    [HttpPut("UpdateInventory")]

        public IActionResult UpdateInventory([FromQuery] int _ChampID, [FromQuery] byte _replenishInventory)
        {
            try
            {
                _leaguebl2.AddUpdateInventory(_ChampID,_replenishInventory);
                return Ok("Iventory Successfully Updated!");
            }
            catch (System.InvalidOperationException)
            {
                
                return NotFound("ChampID was not found");
            }
        }

    }

}