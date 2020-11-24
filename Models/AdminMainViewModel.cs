using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJAutos.Models
{
    public class AdminMainViewModel
    {
        public List<QouteViewModel> TodaysBookings { get; set; } = new List<QouteViewModel>();
        public List<QouteViewModel> PendingBookings { get; set; } = new List<QouteViewModel>();
        public List<QouteViewModel> UnapprovedBookings { get; set; } = new List<QouteViewModel>();
        public List<QouteViewModel> HistoryBookings { get; set; } = new List<QouteViewModel>();
        public List<QouteViewModel> YesterdaysBookings { get; set; } = new List<QouteViewModel>();
    }
}