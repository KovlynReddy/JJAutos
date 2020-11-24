using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJAutos.Models
{
    public class AdminViewModel
    {
        public List<CarViewModel> AllCars { get; set; } = new List<CarViewModel>();
        public List<UserViewModel> AllUsers { get; set; } = new List<UserViewModel>();
        public List<QouteViewModel> PendingQoutes { get; set; } = new List<QouteViewModel>();
        public List<QouteViewModel> HistoryQoutes { get; set; } = new List<QouteViewModel>();

        public AdminViewModel()
        {
            AllCars = new List<CarViewModel>();
            AllUsers = new List<UserViewModel>();
            PendingQoutes = new List<QouteViewModel>();
            HistoryQoutes = new List<QouteViewModel>();
        }
    }
}