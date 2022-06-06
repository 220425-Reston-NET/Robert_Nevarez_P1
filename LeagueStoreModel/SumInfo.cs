using System.ComponentModel.DataAnnotations;

namespace Summoner
{
    public class SummonerInfo
    {
        private string _Name;
        public string Name 
        {
        get {return _Name;} 
        
        set
        {
            if (value.Length > 4 )
            {
                _Name = value;
            }
            else
            {
                throw new ValidationException("Your Summoner Name must be longer than 4 characters");
            }
        } 
        }
        private double _Phonenumber;
        public double Phonenumber 
        { 
            get{ return _Phonenumber;}
        
            set
            {
                if (value > 1000000000 && value < 9999999999)
                {
                    _Phonenumber = value;
                }
            
                else
                {
                    throw new ValidationException("Phone number must be 10 digits");
                }
            }
        }   
           
        public string Address { get; set; }

        public int SumID {get;set; }

        public SummonerInfo()
        {
            Name = "XXXXX";
            Phonenumber = 1000000001;
            Address = "";
        }

    }
}