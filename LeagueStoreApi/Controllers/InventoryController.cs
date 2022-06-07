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
                Log.Information("User tried to search store " + _StoreName);

                return Ok(_leaguebl2.SearchStore(_StoreName));
            }
            catch (System.InvalidOperationException)
            {
                Log.Warning("User searched store " + _StoreName + " and that store does not exist");

                return NotFound("Store was not found");
            }
        }

    [HttpPut("UpdateInventory")]

        public IActionResult UpdateInventory([FromQuery] int _ChampID, [FromQuery] byte _replenishInventory)
        {
            try
            {
                Log.Information("User is replenishing inventory for ChampionID " + _ChampID + " for the amount of " + _replenishInventory);
                
                

                if (_ChampID >= 0 && _ChampID < 16 && _replenishInventory>0)
                {
                    _leaguebl2.AddUpdateInventory(_ChampID,_replenishInventory);
                    return Ok("Iventory Successfully Updated!");
                }
                else
                {
                    throw new InvalidOperationException();
                }
                
            }
            catch (System.InvalidOperationException)
            {
                Log.Warning("User did not follow if condition _ChampID >= 0 && _ChampID < 16 && _replenishInventory>0, Was not able to replenish inventory");

                return Conflict("Please Verify the ChampID is correct and to replenish Inventory, it is a postive integer");
            }
        }

    }

}