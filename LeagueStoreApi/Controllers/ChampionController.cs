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
    public class ChampionController : ControllerBase
    {
        private ILeagueStoreBL<ChampionInfo> _leaguebl;
        private IStoreItemsBL _leaguebl2;
        private IRPBL _leagueblrp;

        public ChampionController(ILeagueStoreBL<ChampionInfo> leaguebl, IStoreItemsBL leaguebl2, IRPBL leagueblrp)
        {
            _leaguebl = leaguebl;
            _leaguebl2 = leaguebl2;
            _leagueblrp = leagueblrp;
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
                return Ok(listofcurrrentchampion);
                
            }
            catch (SqlException)
            {
                
                return Conflict();
            }

        }

        [HttpGet("SearchChampion")]

        public IActionResult SearchChampion([FromQuery] string _ChampName)
        {
            try
            {
                return Ok(_leaguebl.Search(_ChampName));
            }
            catch (System.InvalidOperationException)
            {
                
                return NotFound("Champion was not found");
            }
        }

    }
}