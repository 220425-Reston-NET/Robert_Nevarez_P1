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
    public class SummonerController : ControllerBase
    {
        private readonly ILeagueStoreBL<SummonerInfo> _SumInfo;
        private readonly IOrderHistoryBL _SumOrder;
        private readonly IStoreItemsBL _Inventory;

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
            Log.Information("User added an account in the following details " + p_SumInfo.ToString());

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
            Log.Information("User viewed account " + p_SumName);

            return Ok(_SumInfo.Search(p_SumName));
        }
        catch (System.InvalidOperationException)
        {
            Log.Warning("User tried to search summoner " + p_SumName + " however that summoner does not exist!");

            return NotFound("Summoner was not found");
        }
    }
    [HttpPost("PlaceOrder")]
    public IActionResult PlaceOrder([FromQuery] int p_SumID, string p_Store, int p_ChampionId, string p_ChampionName, int p_TotalBought)
    {
        try
        {
            Log.Information("User placed on order on following details SumID: " + p_SumID + "\nStore: " + p_Store + "\nChampionID: " + p_ChampionId + "\nChampion Name: " + p_ChampionName + "\nTotal bought: " + p_TotalBought);
            Log.Information("User also updated inventory in " + p_Store + " store. User bought " + p_TotalBought + " " + p_ChampionName);

            _SumOrder.NewOrderHistory(p_ChampionName,p_TotalBought,p_Store,p_SumID);
            _Inventory.UpdateInventory(p_ChampionId,Convert.ToByte(p_TotalBought));
            return Ok("Order was succesfully placed!");
        }
        catch (System.InvalidOperationException)
        {
            Log.Warning("User tried to place order, something went wrong!");
            
            return NotFound("Summoner was not found");
        }
    }
    }
}