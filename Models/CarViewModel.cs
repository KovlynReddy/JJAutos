using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJAutos.Models
{
    public class CarViewModel 
    {
        public int id { get; set; }
        public string CarId { get; set; }
        public string UserId { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public string RegNo { get; set; }
        public string PicturePath { get; set; }


        public static CarViewModel ToViewModel(CarDB dbcar) {
            var ViewCar = new CarViewModel(){
                CarId = dbcar.CarId,
                Colour = dbcar.Colour,
                id = dbcar.Id,
                Make = dbcar.Make,
                Model = dbcar.Model,
                PicturePath = dbcar.PicturePath,
                RegNo = dbcar.RegNo,
                UserId = dbcar.UserId
            };
            
            return ViewCar;
        }
        public decimal GetModelMultiplier()
        {
            int iModel = Convert.ToInt32(Model);
            if (iModel < 1990) { return 1.6M; }
            else if (iModel < 2000) { return 1.5M; }
            else if (iModel < 2010) { return 1; }
            else { return 1.2M; }
            }
                
        
        public decimal GetMakeMultiplier()
        {
            switch (Make)
            {
                case ("VW"):
                    return 1M;
                 
                case ("Toyota"):
                    return 0.9M;
                  
                case ("Ford"):
                    return 1.2M;
                    
                case ("BMW"):
                    return 1.4M;
                   
                case ("Kia"):
                    return 1;

                default:
                    return 2;
                    
            }
        }
    }
}