using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJAutos.Models
{
    public class ProfileViewModel
    {
        public List<CarViewModel> MyCars { get; set; } = new List<CarViewModel>();
        public List<QouteViewModel> MyHistory { get; set; } = new List<QouteViewModel>();
        public ProfileViewModel()
        {
            MyCars  = new List<CarViewModel>();
            MyHistory = new List<QouteViewModel>();
        }

        public static List<CarViewModel> ToViewModel(List<CarDB> cars) {
            List<CarViewModel> ViewList = new List<CarViewModel>();

            foreach (var car in cars)
            {
                CarViewModel newCar = new CarViewModel() { 
                id = car.Id,
                CarId = car.CarId,
                UserId = car.UserId,
                RegNo = car.RegNo,
                Make = car.Make,
                Model = car.Model,
                Colour = car.Colour,
                PicturePath = car.PicturePath
                
                };

                ViewList.Add(newCar);   
            }
            return ViewList;
        
        }
    }
}