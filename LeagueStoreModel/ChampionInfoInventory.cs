using System.ComponentModel.DataAnnotations;

namespace Summoner
{

    public class ChampionInfoInventory
    {
        public string Store { get ; set; }
        public string ChampionName { get ; set ;}

        public int RP { get ; set ; }
        private byte _ChampionInventory;
        public byte ChampionInventory
        {
         get {return  _ChampionInventory;}  
         
         set
          { 
              if (value > 0)
              {
                  _ChampionInventory = value;
              }
              else
              {
                  throw new ValidationException("Must be greater than 0");
              }
          }
        } 

        public int ChampionID { get ; set ; }


        public ChampionInfoInventory()
        {
        Store = "";
        ChampionName = "";
        RP = 0;
        ChampionInventory = 10;
        
        }
        public override string ToString()
        {
            return $"===Champion Info===\nStore: {Store}\nChampion Name: {ChampionName}\nChampionID: {ChampionID}\nRp Price: {RP}\nInventory: {ChampionInventory}\n=========================";
        }
        
    }
}