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
        private IOrderHistoryBL _SumOrder;
        private IStoreItemsBL _Inventory;

        public SummonerController(ILeagueStoreBL<SummonerInfo> sumInfo, IOrderHistoryBL sumOrder, IStoreItemsBL inventory)
        {
            _SumInfo = sumInfo;
            _SumOrder = sumOrder;
            _Inventory = inventory;
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
    [HttpGet("ViewAccount")]
    public IActionResult ViewAccount([FromQuery] string p_SumName)
    {
        try
        {
            return Ok(_SumInfo.Search(p_SumName));
        }
        catch (System.InvalidOperationException)
        {
            return NotFound("Summoner was not found");
        }
    }
    [HttpPut("PlaceOrder")]
    public IActionResult PlaceOrder([FromQuery] string p_ChampionName,[FromQuery] int p_TotalBought,[FromQuery] string p_Store,[FromQuery] int p_SumID, int p_ChampionId)
    {
        try
        {

            _SumOrder.NewOrderHistory(p_ChampionName,p_TotalBought,p_Store,p_SumID);
            _Inventory.UpdateInventory(p_ChampionId,Convert.ToByte(p_TotalBought));
            return Ok("Order was succesfully placed!");
        }
        catch (System.InvalidOperationException)
        {
            return NotFound("Summoner was not found");
        }
    }
    }
}