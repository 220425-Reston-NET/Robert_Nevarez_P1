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
    public class SummonerController : ControllerBase
    {
        private ILeagueStoreBL<SummonerInfo> _SumInfo;

        public SummonerController(ILeagueStoreBL<SummonerInfo> sumInfo)
        {
            _SumInfo = sumInfo;
        }
    
    [HttpPost("AddAccount")]
    public IActionResult AddSummoner([FromBody] SummonerInfo p_SumInfo)
    {
        try
        {
            _SumInfo.Add(p_SumInfo);
            return Created("Summoner Profile was created!", p_SumInfo);
        }
        catch(System.ComponentModel.DataAnnotations.ValidationException)
        {
            return Conflict("Name must be longer than 4 characters\n Phone must be >1000000001,<9999999999");
        }
        catch (System.InvalidOperationException)
        {
            
            return Conflict("Summoner Already Exist");
        }
        catch (System.Exception)
        {
            return Conflict("Something went wrong");

        }
    }
    }
}