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
    public class ChampionController : ControllerBase
    {
        private readonly ILeagueStoreBL<ChampionInfo>  _leaguebl;

        public ChampionController(ILeagueStoreBL<ChampionInfo> leaguebl)
        {
            _leaguebl = leaguebl;
        }
        //Data annotation to indicate what type of HTTP verb it is
        //This is an action of a controller
        //It needs what HTTP verb it is associated with

        [HttpGet("GetAllChampions")]
        public IActionResult SearchChampion()
        {
            try
            {  
                List<ChampionInfo> listofcurrrentchampion = _leaguebl.GetAllChampion();

                Log.Information("User searched all Champions.");
                
                return Ok(listofcurrrentchampion);
                
            }
            catch (SqlException)
            {
                Log.Warning("A problem occurred");

                return Conflict();
            }

        }

        [HttpGet("SearchChampion")]

        public IActionResult SearchChampion([FromQuery] string _ChampName)
        {
            try
            {
                Log.Information("User tried to search " + _ChampName);

                return Ok(_leaguebl.Search(_ChampName));
            }
            catch (System.InvalidOperationException)
            {
                Log.Warning("User searched" + _ChampName + "and that champion was not found");

                return NotFound("Champion was not found");
            }
        }

    }
}